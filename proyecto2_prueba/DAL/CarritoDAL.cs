using ML;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System;

namespace DAL
{
    public class CarritoDAL
    {
        private readonly string connectionString;

        public CarritoDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;
        }

        public List<CarritoItem> BuscarProductos(string filtro)
        {
            var productos = new List<CarritoItem>();
            string query = @"
                SELECT 
                    P.id_producto,
                    P.nombre_producto,
                    C.nombre_categoria,
                    P.precio_producto,
                    P.stock_producto
                FROM PRODUCTO P
                INNER JOIN CATEGORIA C ON P.id_categoria = C.id_categoria
                WHERE 
                    P.baja_producto = 0 AND
                    (P.nombre_producto LIKE @filtro OR
                     C.nombre_categoria LIKE @filtro)";

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@filtro", $"%{filtro}%");
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productos.Add(new CarritoItem
                            {
                                IdProducto = Convert.ToInt32(reader["id_producto"]),
                                NombreProducto = reader["nombre_producto"].ToString(),
                                Categoria = reader["nombre_categoria"].ToString(),
                                Precio = Convert.ToDouble(reader["precio_producto"]),
                                StockDisponible = Convert.ToInt32(reader["stock_producto"])
                            });
                        }
                    }
                }
            }
            return productos;
        }

        public CarritoItem ObtenerProductoPorId(int idProducto)
        {
            string query = @"
                SELECT 
                    P.id_producto,
                    P.nombre_producto,
                    C.nombre_categoria,
                    P.precio_producto,
                    P.stock_producto
                FROM PRODUCTO P
                INNER JOIN CATEGORIA C ON P.id_categoria = C.id_categoria
                WHERE P.id_producto = @idProducto AND P.baja_producto = 0";

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idProducto", idProducto);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new CarritoItem
                            {
                                IdProducto = Convert.ToInt32(reader["id_producto"]),
                                NombreProducto = reader["nombre_producto"].ToString(),
                                Categoria = reader["nombre_categoria"].ToString(),
                                Precio = Convert.ToDouble(reader["precio_producto"]),
                                StockDisponible = Convert.ToInt32(reader["stock_producto"])
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}