using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EstadisticasVentasBLL
    {
        private readonly EstadisticasVentasDAL _estadisticasDAL;

        public EstadisticasVentasBLL()
        {
            _estadisticasDAL = new EstadisticasVentasDAL();
        }

        public DataTable ObtenerVendedoresTopRecaudacion(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                return _estadisticasDAL.ObtenerVendedoresTopRecaudacion(fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener estadísticas de vendedores", ex);
            }
        }

        public DataTable ObtenerVentasPorDiaSemana(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                return _estadisticasDAL.ObtenerVentasPorDiaSemana(fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener estadísticas por día", ex);
            }
        }
        public DataTable ObtenerGananciasMensuales(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                return _estadisticasDAL.ObtenerGananciasMensuales(fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener estadísticas de ganancias mensuales", ex);
            }
        }

    }
}
