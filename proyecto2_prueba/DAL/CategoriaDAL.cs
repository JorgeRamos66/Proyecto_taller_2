using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ML;

namespace DAL
{
    public class CategoriaDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;

        public DataTable ObtenerCategorias()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT id_categoria, nombre_categoria, descripcion_categoria, estado_categoria 
                               FROM CATEGORIA";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        public void InsertarCategoria(Categoria categoria)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO CATEGORIA (nombre_categoria, descripcion_categoria, estado_categoria) 
                               VALUES (@Nombre, @Descripcion, 1)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", categoria.NombreCategoria);
                    command.Parameters.AddWithValue("@Descripcion", categoria.DescripcionCategoria);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarCategoria(Categoria categoria)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE CATEGORIA 
                               SET nombre_categoria = @Nombre, 
                                   descripcion_categoria = @Descripcion 
                               WHERE id_categoria = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", categoria.IdCategoria);
                    command.Parameters.AddWithValue("@Nombre", categoria.NombreCategoria);
                    command.Parameters.AddWithValue("@Descripcion", categoria.DescripcionCategoria);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ModificarEstadoCategoria(int idCategoria)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT estado_categoria FROM CATEGORIA WHERE id_categoria = @Id";
                using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@Id", idCategoria);
                    object result = selectCommand.ExecuteScalar();

                    if (result != null)
                    {
                        int estadoActual = Convert.ToInt32(result);
                        string updateQuery = "UPDATE CATEGORIA SET estado_categoria = @NuevoEstado WHERE id_categoria = @Id";

                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@Id", idCategoria);
                            updateCommand.Parameters.AddWithValue("@NuevoEstado", estadoActual == 0 ? 1 : 0);
                            updateCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}