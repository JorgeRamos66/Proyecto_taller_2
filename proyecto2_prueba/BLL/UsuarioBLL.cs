using DAL;
using ML;
using proyecto2_prueba;
using System;

namespace BLL
{
    public class UsuarioBLL
    {
        private UsuarioDAL usuarioDAL = new UsuarioDAL();

        public UsuarioEntidad ValidarUsuario(string usuario, string password)
        {
            UsuarioEntidad user = usuarioDAL.ObtenerUsuario(usuario);

            if (user == null)
                return null; // El usuario no existe

            if (!user.EstaHabilitado)
                throw new Exception("El usuario está deshabilitado.");

            string hashedInputPassword = PasswordHasher.HashPassword(password);

            if (user.Contraseña != hashedInputPassword)
                return null; // Contraseña incorrecta

            return user;
        }
    }
}
