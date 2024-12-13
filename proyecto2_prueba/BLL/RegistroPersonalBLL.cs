using System;
using DAL;
using ML;
using proyecto2_prueba;

namespace BLL
{
    public class RegistroPersonalBLL
    {
        private readonly RegistroPersonalDAL _registroPersonalDAL = new RegistroPersonalDAL();

        public void GuardarPersonal(Personal personal)
        {
            try
            {
                ValidarDatosPersonal(personal);

                // Obtener o crear provincia y localidad
                int idProvincia = _registroPersonalDAL.ObtenerOCrearProvincia(personal.Provincia);
                int idLocalidad = _registroPersonalDAL.ObtenerOCrearLocalidad(personal.Localidad, idProvincia);

                // Hash de la contraseña si existe
                if (!string.IsNullOrEmpty(personal.Password))
                {
                    personal.Password = PasswordHasher.HashPassword(personal.Password);
                }

                if (personal.IdUsuario == 0)
                {
                    _registroPersonalDAL.InsertarPersonal(personal, idLocalidad);
                }
                else
                {
                    _registroPersonalDAL.ActualizarPersonal(personal, idLocalidad);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidarDatosPersonal(Personal personal)
        {
            if (string.IsNullOrWhiteSpace(personal.Nombre) ||
                string.IsNullOrWhiteSpace(personal.Apellido) ||
                string.IsNullOrWhiteSpace(personal.DNI) ||
                string.IsNullOrWhiteSpace(personal.Email) ||
                string.IsNullOrWhiteSpace(personal.Direccion) ||
                string.IsNullOrWhiteSpace(personal.Localidad) ||
                string.IsNullOrWhiteSpace(personal.Provincia) ||
                string.IsNullOrWhiteSpace(personal.Usuario) ||
                (personal.IdUsuario == 0 && string.IsNullOrWhiteSpace(personal.Password)) ||
                personal.IdRol == 0)
            {
                throw new ArgumentException("Todos los campos son obligatorios");
            }
        }
    }
}