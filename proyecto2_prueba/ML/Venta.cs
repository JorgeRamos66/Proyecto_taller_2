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
        public int IdMetodoPago { get; set; }
        public int IdUsuario { get; set; }
        public List<DetalleVenta> Detalles { get; set; }
        public string DetallesPago { get; set; }  // Para guardar detalles del pago
        public Cliente Cliente { get; set; }  // Referencia al cliente completo
    }

    public class DetalleVenta
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
    }
}