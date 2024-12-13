using System;

namespace ML
{
    public class Personal
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string Usuario { get; set; }
        public string Rol { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Password { get; set; }
        public int IdRol { get; set; }
        public int BajaUsuario { get; set; }
    }
}