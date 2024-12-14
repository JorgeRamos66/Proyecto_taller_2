// Producto.cs
using System;

namespace ML
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int StockProducto { get; set; }
        public int CantidadProducto { get; set; }
        public double PrecioProducto { get; set; }
        public int IdCategoria { get; set; }
        public string DescripcionProducto { get; set; }
        public string RutaImagen { get; set; }
        public bool BajaProducto { get; set; }
    }
}
