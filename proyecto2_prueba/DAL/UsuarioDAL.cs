using System;
using System.Configuration;
using System.Data.SqlClient;
using ML;

namespace DAL
{
    public class UsuarioDAL
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;

        public UsuarioEntidad ObtenerUsuario(string usuario)
        {
            UsuarioEntidad user = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT R.nombre_rol, U.id_usuario, U.baja_usuario, U.pass, P.nombre_persona, P.apellido_persona
                    FROM USUARIO U
                    INNER JOIN ROL R ON U.id_rol = R.id_rol
                    INNER JOIN PERSONA P ON U.id_persona = P.id_persona
                    WHERE U.usuario = @usuario";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@usuario", usuario);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    user = new UsuarioEntidad
                    {
                        IdUsuario = Convert.ToInt32(reader["id_usuario"]),
                        Nombre = reader["nombre_persona"].ToString(),
                        Apellido = reader["apellido_persona"].ToString(),
                        Rol = reader["nombre_rol"].ToString(),
                        EstaHabilitado = Convert.ToBoolean(reader["baja_usuario"]),
                        Contraseña = reader["pass"].ToString()
                    };
                }
            }

            return user;
        }
    }
}
