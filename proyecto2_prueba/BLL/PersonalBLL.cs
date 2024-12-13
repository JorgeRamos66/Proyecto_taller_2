using System;
using System.Data;
using DAL;
using ML;

namespace BLL
{
    public class PersonalBLL
    {
        private PersonalDAL personalDAL = new PersonalDAL();

        public DataTable ObtenerPersonal()
        {
            return personalDAL.ObtenerPersonal();
        }

        public Personal ObtenerPersonalPorId(int idPersona)
        {
            return personalDAL.ObtenerPersonalPorId(idPersona);
        }

        public void ModificarEstadoUsuario(int idPersona)
        {
            try
            {
                personalDAL.ModificarEstadoUsuario(idPersona);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al modificar el estado del usuario: {ex.Message}");
            }
        }

        public void GuardarPersonal(Personal personal)
        {
            try
            {
                if (personal.IdUsuario == 0)
                {
                    personalDAL.InsertarPersonal(personal);
                }
                else
                {
                    personalDAL.ActualizarPersonal(personal);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar el personal: {ex.Message}");
            }
        }

        public DataTable BuscarPersonal(string textoBusqueda, DataTable dataTable)
        {
            if (string.IsNullOrEmpty(textoBusqueda))
                return dataTable;

            DataTable resultado = dataTable.Clone();
            
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["nombre_persona"].ToString().ToLower().Contains(textoBusqueda.ToLower()) ||
                    row["apellido_persona"].ToString().ToLower().Contains(textoBusqueda.ToLower()) ||
                    row["dni"].ToString().ToLower().Contains(textoBusqueda.ToLower()) ||
                    row["nombre_rol"].ToString().ToLower().Contains(textoBusqueda.ToLower()) ||
                    row["usuario"].ToString().ToLower().Contains(textoBusqueda.ToLower()) ||
                    row["email_persona"].ToString().ToLower().Contains(textoBusqueda.ToLower()))
                {
                    resultado.ImportRow(row);
                }
            }

            return resultado;
        }
    }
}