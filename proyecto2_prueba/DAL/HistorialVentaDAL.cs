using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HistorialVentaDAL
    {
        private readonly string connectionString;

        public HistorialVentaDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;
        }

        public DataTable ObtenerHistorialVentas(int idUsuario, DateTime fechaInicio, DateTime fechaFin)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        v.id_venta,
                        v.fecha,
                        v.precio_total,
                        p.nombre_persona + ' ' + p.apellido_persona AS nombre_cliente,
                        v.venta_estado
                    FROM VENTA_CABECERA v
                    JOIN PERSONA p ON v.id_persona = p.id_persona
                    WHERE v.id_usuario = @id_usuario
                    AND v.fecha BETWEEN @fechaInicio AND @fechaFin
                    ORDER BY v.fecha DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id_usuario", idUsuario);
                    command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@fechaFin", fechaFin);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        public void CambiarEstadoVenta(int idVenta)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            UPDATE VENTA_CABECERA 
            SET venta_estado = CASE WHEN venta_estado = 1 THEN 0 ELSE 1 END 
            WHERE id_venta = @idVenta";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@idVenta", idVenta);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
