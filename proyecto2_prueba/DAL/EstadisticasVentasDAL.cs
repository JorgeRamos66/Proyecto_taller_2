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
    public class EstadisticasVentasDAL
    {
        private readonly string connectionString;

        public EstadisticasVentasDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;
        }

        public DataTable ObtenerVendedoresTopRecaudacion(DateTime fechaInicio, DateTime fechaFin)
        {
            var dt = new DataTable();
            string query = @"
                WITH TodosVendedores AS (
                    SELECT DISTINCT 
                        u.id_usuario,
                        p.nombre_persona + ' ' + p.apellido_persona AS Vendedor
                    FROM usuario u
                    INNER JOIN persona p ON u.id_persona = p.id_persona
                    WHERE u.id_rol = 2 AND u.baja_usuario = 1
                )
                SELECT 
                    tv.Vendedor,
                    ISNULL(SUM(vc.precio_total), 0) AS TotalRecaudado,
                    COUNT(vc.id_venta) AS CantidadVentas
                FROM TodosVendedores tv
                LEFT JOIN venta_cabecera vc ON vc.id_usuario = tv.id_usuario
                    AND vc.fecha BETWEEN @fechaInicio AND @fechaFin
                    AND vc.venta_estado = 1
                GROUP BY tv.Vendedor
                ORDER BY TotalRecaudado DESC";

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@fechaFin", fechaFin);

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public DataTable ObtenerVentasPorDiaSemana(DateTime fechaInicio, DateTime fechaFin)
        {
            var dt = new DataTable();
            string query = @"
                WITH DiasSemana AS (
                    SELECT 1 AS DiaNumero, 'Domingo' AS DiaSemana UNION
                    SELECT 2, 'Lunes' UNION
                    SELECT 3, 'Martes' UNION
                    SELECT 4, 'Miércoles' UNION
                    SELECT 5, 'Jueves' UNION
                    SELECT 6, 'Viernes' UNION
                    SELECT 7, 'Sábado'
                )
                SELECT 
                    ds.DiaSemana,
                    ISNULL(COUNT(vc.id_venta), 0) AS CantidadVentas,
                    ISNULL(SUM(vc.precio_total), 0) AS TotalVentas
                FROM DiasSemana ds
                LEFT JOIN venta_cabecera vc ON 
                    DATEPART(WEEKDAY, vc.fecha) = ds.DiaNumero
                    AND vc.fecha BETWEEN @fechaInicio AND @fechaFin
                    AND vc.venta_estado = 1
                GROUP BY ds.DiaNumero, ds.DiaSemana
                ORDER BY ds.DiaNumero";

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@fechaFin", fechaFin);

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}
