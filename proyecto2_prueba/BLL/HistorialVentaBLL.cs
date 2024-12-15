using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HistorialVentaBLL
    {
        private readonly HistorialVentaDAL _historialVentaDAL;
        private readonly VentaBLL _ventaBLL;

        public HistorialVentaBLL()
        {
            _historialVentaDAL = new HistorialVentaDAL();
            _ventaBLL = new VentaBLL();
        }

        public DataTable ObtenerHistorialVentas(int idUsuario, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                // Validaciones
                if (idUsuario <= 0)
                    throw new ArgumentException("ID de usuario no válido");

                if (fechaInicio > fechaFin)
                    throw new ArgumentException("La fecha de inicio no puede ser posterior a la fecha fin");

                return _historialVentaDAL.ObtenerHistorialVentas(idUsuario, fechaInicio, fechaFin);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CambiarEstadoVenta(int idVenta)
        {
            try
            {
                _historialVentaDAL.CambiarEstadoVenta(idVenta);
            }
            catch
            {
                throw;
            }
        }

        public void GenerarFacturaPDF(int idVenta, string rutaArchivo)
        {
            try
            {
                _ventaBLL.GenerarPDF(idVenta, rutaArchivo);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
