using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class HistorialVenta
    {
        public int IdVenta { get; set; }
        public DateTime Fecha { get; set; }
        public double PrecioTotal { get; set; }
        public string NombreCliente { get; set; }
    }
}
