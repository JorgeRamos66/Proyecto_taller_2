using System.Collections.Generic;
using System.Linq;

namespace ML
{
    public class CarritoItem
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string CategoriaProducto { get; set; }
        public double PrecioProducto { get; set; }
        public int CantidadProducto { get; set; }
        public int StockDisponible { get; set; }
        public double Subtotal => PrecioProducto * CantidadProducto;
    }

    public class Carrito
    {
        public List<CarritoItem> Items { get; set; } = new List<CarritoItem>();
        public double Total => Items.Sum(item => item.Subtotal);
        public int CantidadItems => Items.Count;
    }
}