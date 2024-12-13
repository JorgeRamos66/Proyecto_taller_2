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

        public void InsertarProducto(Producto producto)
        {
            // Validaciones de negocio 
            if (string.IsNullOrEmpty(producto.NombreProducto))
                throw new Exception("El nombre del producto es requerido");

            if (producto.StockProducto < 0)
                throw new Exception("El stock no puede ser negativo");

            if (producto.PrecioProducto <= 0)
                throw new Exception("El precio debe ser mayor a 0");

            // Validación de imagen
            if (string.IsNullOrEmpty(producto.RutaImagen))
                throw new Exception("La ruta de la imagen es requerida");

            string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\", producto.RutaImagen);
            if (!File.Exists(rutaCompleta))
                throw new Exception("No se encontró la imagen en la ruta especificada");

            productoDAL.InsertarProducto(producto);
        }

        public void ActualizarProducto(Producto producto)
        {
            // Validaciones de negocio
            if (string.IsNullOrEmpty(producto.NombreProducto))
                throw new Exception("El nombre del producto es requerido");

            if (producto.StockProducto < 0)
                throw new Exception("El stock no puede ser negativo");

            if (producto.PrecioProducto <= 0)
                throw new Exception("El precio debe ser mayor a 0");

            // Validación de imagen
            if (string.IsNullOrEmpty(producto.RutaImagen))
                throw new Exception("La ruta de la imagen es requerida");

            string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\", producto.RutaImagen);
            if (!File.Exists(rutaCompleta))
                throw new Exception("No se encontró la imagen en la ruta especificada");

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
