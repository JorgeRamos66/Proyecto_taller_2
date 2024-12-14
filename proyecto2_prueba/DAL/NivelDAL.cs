using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ML;

namespace DAL
{
    public class NivelDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;

        public DataTable ObtenerNiveles()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT id_nivel, nombre_nivel, descuento, estado_nivel FROM NIVEL";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        public void InsertarNivel(Nivel nivel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO NIVEL (nombre_nivel, descuento, estado_nivel) VALUES (@Nombre, @Descuento, 1)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nivel.NombreNivel);
                    command.Parameters.AddWithValue("@Descuento", nivel.Descuento);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarNivel(Nivel nivel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE NIVEL SET nombre_nivel = @Nombre, descuento = @Descuento WHERE id_nivel = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", nivel.IdNivel);
                    command.Parameters.AddWithValue("@Nombre", nivel.NombreNivel);
                    command.Parameters.AddWithValue("@Descuento", nivel.Descuento);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ModificarEstadoNivel(int idNivel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string selectQuery = "SELECT estado_nivel FROM NIVEL WHERE id_nivel = @Id";
                        int estadoActual;

                        using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection, transaction))
                        {
                            selectCommand.Parameters.AddWithValue("@Id", idNivel);
                            estadoActual = Convert.ToInt32(selectCommand.ExecuteScalar());
                        }

                        string updateQuery = "UPDATE NIVEL SET estado_nivel = @NuevoEstado WHERE id_nivel = @Id";
                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection, transaction))
                        {
                            updateCommand.Parameters.AddWithValue("@Id", idNivel);
                            updateCommand.Parameters.AddWithValue("@NuevoEstado", estadoActual == 0 ? 1 : 0);
                            updateCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}