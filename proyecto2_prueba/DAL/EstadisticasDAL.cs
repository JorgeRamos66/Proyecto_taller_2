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
    public class EstadisticasDAL
    {
        private readonly string connectionString;

        public EstadisticasDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;
        }

        public DataTable ObtenerProductosMasVendidos(DateTime fechaInicio, DateTime fechaFin)
        {
            var dt = new DataTable();
            string query = @"
                SELECT TOP 10 
                    P.nombre_producto AS Producto,
                    SUM(VD.cantidad) AS CantidadVendida
                FROM PRODUCTO P
                INNER JOIN VENTA_DETALLE VD ON P.id_producto = VD.id_producto
                INNER JOIN VENTA_CABECERA VC ON VD.id_venta = VC.id_venta
                WHERE VC.fecha BETWEEN @fechaInicio AND @fechaFin
                GROUP BY P.nombre_producto
                ORDER BY CantidadVendida DESC";

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

        public DataTable ObtenerCategoriasMasVendidas(DateTime fechaInicio, DateTime fechaFin)
        {
            var dt = new DataTable();
            string query = @"
                SELECT 
                    C.nombre_categoria AS Categoria,
                    SUM(VD.cantidad) AS CantidadVendida
                FROM CATEGORIA C
                INNER JOIN PRODUCTO P ON C.id_categoria = P.id_categoria
                INNER JOIN VENTA_DETALLE VD ON P.id_producto = VD.id_producto
                INNER JOIN VENTA_CABECERA VC ON VD.id_venta = VC.id_venta
                WHERE VC.fecha BETWEEN @fechaInicio AND @fechaFin
                GROUP BY C.nombre_categoria
                ORDER BY CantidadVendida DESC";

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
