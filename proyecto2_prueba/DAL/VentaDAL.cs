using System;
using System.Data.SqlClient;
using System.Configuration;
using ML;

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
                    id_usuario
                ) 
                VALUES (
                    @fechaVenta, 
                    @precioTotal, 
                    @idCliente, 
                    @idMetodoPago, 
                    @idUsuario
                );
                SELECT SCOPE_IDENTITY();";

            using (SqlCommand cmd = new SqlCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@fechaVenta", venta.FechaVenta);
                cmd.Parameters.AddWithValue("@precioTotal", venta.PrecioTotal);
                cmd.Parameters.AddWithValue("@idCliente", venta.IdCliente);
                cmd.Parameters.AddWithValue("@idMetodoPago", venta.IdMetodoPago);
                cmd.Parameters.AddWithValue("@idUsuario", venta.IdUsuario);

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
    }
}