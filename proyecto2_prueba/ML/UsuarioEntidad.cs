namespace ML
{
    public class UsuarioEntidad
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Rol { get; set; }
        public bool EstaHabilitado { get; set; }
        public string Contraseña { get; set; }
    }
}
