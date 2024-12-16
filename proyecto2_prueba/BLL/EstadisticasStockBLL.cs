using proyecto2_prueba.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto2_prueba.BLL
{
    public class EstadisticasStockBLL
    {
        private readonly EstadisticasStockDAL _stockDAL;

        public EstadisticasStockBLL()
        {
            _stockDAL = new EstadisticasStockDAL();
        }

        public DataTable ObtenerProductosBajoStock()
        {
            return _stockDAL.ObtenerProductosBajoStock();
        }

        public DataTable ObtenerStockSinMover(DateTime fechaInicio, DateTime fechaFin)
        {
            return _stockDAL.ObtenerStockSinMover(fechaInicio, fechaFin);
        }
    }
}
