using System;
using System.Data.SqlClient;
using System.Configuration;
using ML;
using System.Collections.Generic;

namespace DAL
{
    public class VentaDAL
    {
        private readonly string connectionString;

        public VentaDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;
        }

        public int InsertarVenta(Venta venta)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insertar la venta
                        int idVenta = InsertarVentaCabecera(venta, connection, transaction);

                        // Insertar los detalles de la venta
                        foreach (var detalle in venta.Detalles)
                        {
                            detalle.IdVenta = idVenta;
                            InsertarDetalleVenta(detalle, connection, transaction);
                            ActualizarStock(detalle.IdProducto, detalle.Cantidad, connection, transaction);
                        }

                        transaction.Commit();
                        return idVenta;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private int InsertarVentaCabecera(Venta venta, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"
                INSERT INTO VENTA (
                    fecha_venta, 
                    precio_total, 
                    id_cliente, 
                    id_metodo_pago, 
                    id_usuario,
                    detalles_pago  // Agregar este campo
                ) 
                VALUES (
                    @fechaVenta, 
                    @precioTotal, 
                    @idCliente, 
                    @idMetodoPago, 
                    @idUsuario,
                    @detallesPago  // Agregar este parámetro
                );
                SELECT SCOPE_IDENTITY();";

            using (SqlCommand cmd = new SqlCommand(query, connection, transaction))
            {
                // Parámetros existentes...
                cmd.Parameters.AddWithValue("@detallesPago", venta.DetallesPago);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void InsertarDetalleVenta(DetalleVenta detalle, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"
                INSERT INTO DETALLE_VENTA (
                    id_venta, 
                    id_producto, 
                    cantidad_producto, 
                    precio_producto
                ) 
                VALUES (
                    @idVenta, 
                    @idProducto, 
                    @cantidad, 
                    @precio
                )";

            using (SqlCommand cmd = new SqlCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@idVenta", detalle.IdVenta);
                cmd.Parameters.AddWithValue("@idProducto", detalle.IdProducto);
                cmd.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                cmd.Parameters.AddWithValue("@precio", detalle.Precio);
                cmd.ExecuteNonQuery();
            }
        }

        private void ActualizarStock(int idProducto, int cantidad, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"
                UPDATE PRODUCTO 
                SET stock_producto = stock_producto - @cantidad 
                WHERE id_producto = @idProducto";

            using (SqlCommand cmd = new SqlCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@idProducto", idProducto);
                cmd.ExecuteNonQuery();
            }
        }

        public Venta ObtenerVentaPorId(int idVenta)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        v.*,
                        p.id_persona,
                        p.nombre_persona,
                        p.apellido_persona,
                        p.dni,
                        p.email_persona,
                        p.direccion_persona,
                        l.nombre_localidad,
                        pr.nombre_provincia,
                        c.id_cliente
                    FROM VENTA_CABECERA v
                    INNER JOIN CLIENTE c ON v.id_cliente = c.id_cliente
                    INNER JOIN PERSONA p ON c.id_persona = p.id_persona
                    INNER JOIN LOCALIDAD l ON p.id_localidad = l.id_localidad
                    INNER JOIN PROVINCIA pr ON l.id_provincia = pr.id_provincia
                    WHERE v.id_venta = @idVenta";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@idVenta", idVenta);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapearVenta(reader);
                        }
                    }
                }
            }
            return null;
        }

        private Venta MapearVenta(SqlDataReader reader)
        {
            return new Venta
            {
                Id = Convert.ToInt32(reader["id_venta"]),
                FechaVenta = Convert.ToDateTime(reader["fecha"]),
                PrecioTotal = Convert.ToDouble(reader["precio_total"]),
                IdMetodoPago = Convert.ToInt32(reader["id_metodo"]),
                IdUsuario = Convert.ToInt32(reader["id_usuario"]),
                Cliente = new Cliente
                {
                    Id = Convert.ToInt32(reader["id_cliente"]),
                    IdPersona = Convert.ToInt32(reader["id_persona"]),
                    Nombre = reader["nombre_persona"].ToString(),
                    Apellido = reader["apellido_persona"].ToString(),
                    Dni = Convert.ToInt32(reader["dni"]),
                    Email = reader["email_persona"].ToString(),
                    Direccion = reader["direccion_persona"].ToString(),
                    Localidad = reader["nombre_localidad"].ToString(),
                    Provincia = reader["nombre_provincia"].ToString()
                },
                Detalles = ObtenerDetallesVenta(Convert.ToInt32(reader["id_venta"]))
            };
        }

        private List<DetalleVenta> ObtenerDetallesVenta(int idVenta)
        {
            var detalles = new List<DetalleVenta>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        d.id_venta,
                        d.cantidad,
                        d.precio_subtotal,
                        d.id_producto
                    FROM VENTA_DETALLE d
                    WHERE d.id_venta = @idVenta";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@idVenta", idVenta);
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            detalles.Add(new DetalleVenta
                            {
                                IdVenta = idVenta,
                                IdProducto = Convert.ToInt32(reader["id_producto"]),
                                Cantidad = Convert.ToInt32(reader["cantidad"]),
                                Precio = Convert.ToDouble(reader["precio_subtotal"])
                            });
                        }
                    }
                }
            }

            return detalles;
        }

        public Producto ObtenerProducto(int idProducto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT * 
            FROM PRODUCTO 
            WHERE id_producto = @idProducto";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@idProducto", idProducto);
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Producto
                            {
                                IdProducto = Convert.ToInt32(reader["id_producto"]),
                                NombreProducto = reader["nombre_producto"].ToString(),
                                PrecioProducto = Convert.ToDouble(reader["precio_producto"]),
                                StockProducto = Convert.ToInt32(reader["stock_producto"]),
                                IdCategoria = Convert.ToInt32(reader["id_categoria"])
                            };
                        }
                    }
                }
            }
            throw new Exception($"Producto con ID {idProducto} no encontrado");
        }
    }
}