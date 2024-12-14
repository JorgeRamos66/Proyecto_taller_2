using System.Collections.Generic;
using System.Linq;

namespace ML
{
    public class CarritoItem
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Categoria { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public int StockDisponible { get; set; }
        public double Subtotal => Precio * Cantidad;
    }

    public class Carrito
    {
        public List<CarritoItem> Items { get; set; } = new List<CarritoItem>();
        public double Total => Items.Sum(item => item.Subtotal);
        public int CantidadItems => Items.Count;
    }
}