// ProductoBLL.cs
using System;
using System.Data;
using System.IO;
using DAL;
using ML;

namespace BLL
{
    public class ProductoBLL
    {
        private ProductoDAL productoDAL = new ProductoDAL();

        public DataTable ObtenerProductos()
        {
            return productoDAL.ObtenerProductos();
        }

        public void ModificarEstadoProducto(int id)
        {
            productoDAL.ModificarEstadoProducto(id);
        }

        public Producto ObtenerProductoPorId(int id)
        {
            return productoDAL.ObtenerProductoPorId(id);
        }

        public string ObtenerNombreCategoria(int idCategoria)
        {
            return productoDAL.ObtenerNombreCategoria(idCategoria);
        }
        public DataTable ObtenerCategorias()
        {
            return productoDAL.ObtenerCategorias();
        }

        public void ModificarProducto(Producto producto)
        {
            // Validaciones de negocio
            if (string.IsNullOrWhiteSpace(producto.NombreProducto) ||
                producto.StockProducto < 0 ||
                producto.PrecioProducto <= 0 ||
                string.IsNullOrWhiteSpace(producto.DescripcionProducto) ||
                string.IsNullOrWhiteSpace(producto.RutaImagen))
            {
                throw new Exception("Todos los campos son obligatorios y deben ser válidos.");
            }

            // Validar que la imagen existe
            string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\", producto.RutaImagen);
            if (!File.Exists(rutaCompleta))
            {
                throw new Exception("La imagen no existe en la ruta especificada.");
            }

            productoDAL.ActualizarProducto(producto);
        }

        public int ValidarCategoria(string nombreCategoria)
        {
            if (string.IsNullOrWhiteSpace(nombreCategoria))
                throw new Exception("La categoría no puede estar vacía.");

            int idCategoria = productoDAL.ValidarCategoria(nombreCategoria);
            if (idCategoria == -1)
                throw new Exception("La categoría seleccionada no existe o está inactiva.");

            return idCategoria;
        }
    }
}
