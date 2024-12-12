using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DAL
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;
        }

        public bool RealizarBackup(string rutaArchivo)
        {
            try
            {
                string query = "BACKUP DATABASE [Proyecto_Taller_2] TO DISK = @backupFilePath";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@backupFilePath", rutaArchivo);

                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar el backup: " + ex.Message);
                return false;
            }
        }

        public bool RestaurarBackup(string rutaArchivo)
        {
            try
            {
                string query = "RESTORE DATABASE [Proyecto_Taller_2] FROM DISK = @backupFilePath WITH REPLACE";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@backupFilePath", rutaArchivo);

                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al restaurar la base de datos: " + ex.Message);
                return false;
            }
        }
    }
}
