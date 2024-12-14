using System;
using System.Data;
using DAL;
using ML;

namespace BLL
{
    public class NivelBLL
    {
        private readonly NivelDAL nivelDAL = new NivelDAL();

        public DataTable ObtenerNiveles()
        {
            try
            {
                return nivelDAL.ObtenerNiveles();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GuardarNivel(Nivel nivel)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nivel.NombreNivel))
                    throw new ArgumentException("El nombre del nivel es obligatorio");

                if (nivel.Descuento < 0 || nivel.Descuento > 100)
                    throw new ArgumentException("El descuento debe estar entre 0 y 100");

                if (nivel.IdNivel == 0)
                {
                    nivelDAL.InsertarNivel(nivel);
                }
                else
                {
                    nivelDAL.ActualizarNivel(nivel);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarEstadoNivel(int idNivel)
        {
            try
            {
                nivelDAL.ModificarEstadoNivel(idNivel);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}