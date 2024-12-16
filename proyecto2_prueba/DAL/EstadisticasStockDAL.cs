using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto2_prueba.DAL
{
    public class EstadisticasStockDAL
    {
        private readonly string connectionString;

        public EstadisticasStockDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;
        }

        public DataTable ObtenerProductosBajoStock()
        {
            var dt = new DataTable();
            string query = @"
                SELECT 
                    P.nombre_producto AS Producto,
                    C.nombre_categoria AS Categoria,
                    ISNULL(P.stock_producto, 0) AS Stock
                FROM PRODUCTO P
                INNER JOIN CATEGORIA C ON P.id_categoria = C.id_categoria
                WHERE P.baja_producto = 1 
                AND C.estado_categoria = 1
                ORDER BY P.stock_producto ASC";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener datos de stock", ex);
            }

            return dt;
        }

        public DataTable ObtenerStockSinMover(DateTime fechaInicio, DateTime fechaFin)
        {
            var dt = new DataTable();
            string query = @"
            WITH MovimientosStock AS (
                    SELECT 
                        P.id_producto,
                        P.nombre_producto,
                        P.stock_producto as StockTotal,
                        ISNULL(SUM(VD.cantidad), 0) as StockMovido
                    FROM PRODUCTO P
                    LEFT JOIN VENTA_DETALLE VD ON P.id_producto = VD.id_producto
                    LEFT JOIN VENTA_CABECERA VC ON VD.id_venta = VC.id_venta
                        AND VC.fecha BETWEEN @fechaInicio AND @fechaFin
                        AND VC.venta_estado = 1
                    WHERE P.baja_producto = 1
                    GROUP BY P.id_producto, P.nombre_producto, P.stock_producto
                )
                SELECT TOP 10
                    nombre_producto,
                    StockTotal,
                    StockMovido,
                    (StockTotal - StockMovido) as StockSinMover
                FROM MovimientosStock
                ORDER BY StockSinMover DESC, StockMovido ASC";

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
