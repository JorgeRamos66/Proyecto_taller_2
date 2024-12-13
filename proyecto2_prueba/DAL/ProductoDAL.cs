// ProductoDAL.cs
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ML;

namespace DAL
{
    public class ProductoDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;

        public DataTable ObtenerProductos()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT p.id_producto, p.nombre_producto, p.stock_producto, p.precio_producto, 
                           p.id_categoria, p.descripcion_producto, p.ruta_imagen, p.baja_producto 
                    FROM PRODUCTO p
                    INNER JOIN CATEGORIA c ON p.id_categoria = c.id_categoria
                    WHERE c.estado_categoria = 1";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }
        

        public void ModificarEstadoProducto(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT baja_producto FROM PRODUCTO WHERE id_producto = @Id";
                using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@Id", id);
                    object result = selectCommand.ExecuteScalar();
                    if (result != null)
                    {
                        int estadoActual = Convert.ToInt32(result);
                        string updateQuery = estadoActual == 0 ?
                            "UPDATE PRODUCTO SET baja_producto = 1 WHERE id_producto = @Id" :
                            "UPDATE PRODUCTO SET baja_producto = 0 WHERE id_producto = @Id";

                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@Id", id);
                            updateCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public Producto ObtenerProductoPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT nombre_producto, stock_producto, precio_producto, id_categoria, descripcion_producto, ruta_imagen, baja_producto FROM PRODUCTO WHERE id_producto = @IdProducto";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdProducto", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Producto
                            {
                                IdProducto = id,
                                NombreProducto = reader["nombre_producto"].ToString(),
                                StockProducto = Convert.ToInt32(reader["stock_producto"]),
                                PrecioProducto = Convert.ToDecimal(reader["precio_producto"]),
                                IdCategoria = Convert.ToInt32(reader["id_categoria"]),
                                DescripcionProducto = reader["descripcion_producto"].ToString(),
                                RutaImagen = reader["ruta_imagen"].ToString(),
                                BajaProducto = Convert.ToBoolean(reader["baja_producto"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        public string ObtenerNombreCategoria(int idCategoria)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT nombre_categoria FROM CATEGORIA WHERE id_categoria = @IdCategoria";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdCategoria", idCategoria);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    return result?.ToString();
                }
            }
        }
        public DataTable ObtenerCategorias()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT id_categoria, nombre_categoria FROM CATEGORIA WHERE estado_categoria = 1";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public void ActualizarProducto(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE PRODUCTO 
                               SET nombre_producto = @nombre,
                                   precio_producto = @precio,
                                   descripcion_producto = @descripcion,
                                   stock_producto = @stock,
                                   id_categoria = @idCategoria,
                                   ruta_imagen = @rutaImagen
                               WHERE id_producto = @idProducto";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@nombre", producto.NombreProducto);
                cmd.Parameters.AddWithValue("@precio", producto.PrecioProducto);
                cmd.Parameters.AddWithValue("@descripcion", producto.DescripcionProducto);
                cmd.Parameters.AddWithValue("@stock", producto.StockProducto);
                cmd.Parameters.AddWithValue("@idCategoria", producto.IdCategoria);
                cmd.Parameters.AddWithValue("@rutaImagen", producto.RutaImagen);
                cmd.Parameters.AddWithValue("@idProducto", producto.IdProducto);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public int ValidarCategoria(string nombreCategoria)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT id_categoria FROM CATEGORIA WHERE nombre_categoria = @categoria AND estado_categoria = 1";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@categoria", nombreCategoria);
                
                connection.Open();
                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }
        
    }
}
