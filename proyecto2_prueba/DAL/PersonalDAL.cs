using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ML;

namespace DAL
{
    public class PersonalDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;

        public DataTable ObtenerPersonal()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT p.id_persona, p.nombre_persona, p.apellido_persona, p.dni, 
                           p.email_persona, p.direccion_persona, u.usuario, r.nombre_rol, 
                           u.baja_usuario 
                    FROM PERSONA p
                    INNER JOIN USUARIO u ON p.id_persona = u.id_persona
                    INNER JOIN ROL r ON u.id_rol = r.id_rol";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        public Personal ObtenerPersonalPorId(int idPersona)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT U.id_usuario, p.nombre_persona, p.apellido_persona, p.dni, p.email_persona, 
                           p.direccion_persona, l.nombre_localidad, pr.nombre_provincia, 
                           U.usuario, R.nombre_rol, p.fecha_nacimiento
                    FROM USUARIO U
                    INNER JOIN PERSONA p ON U.id_persona = p.id_persona
                    INNER JOIN LOCALIDAD l ON p.id_localidad = l.id_localidad
                    INNER JOIN PROVINCIA pr ON l.id_provincia = pr.id_provincia
                    INNER JOIN ROL R ON U.id_rol = R.id_rol
                    WHERE p.id_persona = @IdPersona";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdPersona", idPersona);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Personal
                            {
                                IdUsuario = Convert.ToInt32(reader["id_usuario"]),
                                Nombre = reader["nombre_persona"].ToString(),
                                Apellido = reader["apellido_persona"].ToString(),
                                DNI = reader["dni"].ToString(),
                                Email = reader["email_persona"].ToString(),
                                Direccion = reader["direccion_persona"].ToString(),
                                Localidad = reader["nombre_localidad"].ToString(),
                                Provincia = reader["nombre_provincia"].ToString(),
                                Usuario = reader["usuario"].ToString(),
                                Rol = reader["nombre_rol"].ToString(),
                                FechaNacimiento = reader["fecha_nacimiento"] != DBNull.Value 
                                    ? Convert.ToDateTime(reader["fecha_nacimiento"]) 
                                    : DateTime.MinValue
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public void ModificarEstadoUsuario(int idPersona)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                string selectQuery = "SELECT baja_usuario FROM USUARIO WHERE id_persona = @Id";
                using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@Id", idPersona);
                    object result = selectCommand.ExecuteScalar();
                    
                    if (result != null)
                    {
                        int estadoActual = Convert.ToInt32(result);
                        string updateQuery = estadoActual == 0 
                            ? "UPDATE USUARIO SET baja_usuario = 1 WHERE id_persona = @Id"
                            : "UPDATE USUARIO SET baja_usuario = 0 WHERE id_persona = @Id";

                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@Id", idPersona);
                            updateCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}