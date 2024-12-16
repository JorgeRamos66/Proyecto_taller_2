using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EstadisticasBLL
    {
        private readonly EstadisticasDAL _estadisticasDAL;

        public EstadisticasBLL()
        {
            _estadisticasDAL = new EstadisticasDAL();
        }

        public DataTable ObtenerProductosMasVendidos(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                return _estadisticasDAL.ObtenerProductosMasVendidos(fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener productos más vendidos", ex);
            }
        }

        public DataTable ObtenerCategoriasMasVendidas(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                return _estadisticasDAL.ObtenerCategoriasMasVendidas(fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener categorías más vendidas", ex);
            }
        }
    }
}
