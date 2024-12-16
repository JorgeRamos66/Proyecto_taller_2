using System.Collections.Generic;
using System;

namespace ML
{
    public class Venta
    {
        public int Id { get; set; }
        public DateTime FechaVenta { get; set; }
        public double PrecioTotal { get; set; }
        public int IdCliente { get; set; }
        public int IdMetodo { get; set; } 
        public int IdUsuario { get; set; }
        public int IdPersona { get; set; } 
        public int VentaEstado { get; set; }
        public List<DetalleVenta> Detalles { get; set; }
        public string DetallesPago { get; set; }
        public Cliente Cliente { get; set; }
    }

    public class DetalleVenta
    {
        public int IdVenta { get; set; } 
        public int IdProducto { get; set; } 
        public int Cantidad { get; set; }
        public double PrecioSubtotal { get; set; }
    }
}