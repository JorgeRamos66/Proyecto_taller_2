using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ML;
using proyecto2_prueba;

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

        public void InsertarPersonal(Personal personal)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Insertar en la tabla PERSONA
                        string queryPersona = @"
                            INSERT INTO PERSONA (nombre_persona, apellido_persona, dni, email_persona, 
                                            direccion_persona, id_localidad, fecha_nacimiento)
                            OUTPUT INSERTED.id_persona
                            VALUES (@Nombre, @Apellido, @DNI, @Email, @Direccion, 
                                (SELECT id_localidad FROM LOCALIDAD WHERE nombre_localidad = @Localidad), 
                                @FechaNacimiento)";

                        int idPersona;
                        using (SqlCommand cmd = new SqlCommand(queryPersona, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Nombre", personal.Nombre);
                            cmd.Parameters.AddWithValue("@Apellido", personal.Apellido);
                            cmd.Parameters.AddWithValue("@DNI", personal.DNI);
                            cmd.Parameters.AddWithValue("@Email", personal.Email);
                            cmd.Parameters.AddWithValue("@Direccion", personal.Direccion);
                            cmd.Parameters.AddWithValue("@Localidad", personal.Localidad);
                            cmd.Parameters.AddWithValue("@FechaNacimiento", personal.FechaNacimiento);

                            idPersona = (int)cmd.ExecuteScalar();
                        }

                        // 2. Insertar en la tabla USUARIO
                        string queryUsuario = @"
                            INSERT INTO USUARIO (id_persona, usuario, pass, id_rol, baja_usuario)
                            VALUES (@IdPersona, @Usuario, @Password, @IdRol, @BajaUsuario)";

                        using (SqlCommand cmd = new SqlCommand(queryUsuario, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@IdPersona", idPersona);
                            cmd.Parameters.AddWithValue("@Usuario", personal.Usuario);
                            cmd.Parameters.AddWithValue("@Password", PasswordHasher.HashPassword(personal.Password));
                            cmd.Parameters.AddWithValue("@IdRol", personal.IdRol);
                            cmd.Parameters.AddWithValue("@BajaUsuario", personal.BajaUsuario);

                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void ActualizarPersonal(Personal personal)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Obtener id_persona desde USUARIO
                        string queryGetIdPersona = "SELECT id_persona FROM USUARIO WHERE id_usuario = @IdUsuario";
                        int idPersona;
                        using (SqlCommand cmd = new SqlCommand(queryGetIdPersona, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@IdUsuario", personal.IdUsuario);
                            idPersona = (int)cmd.ExecuteScalar();
                        }

                        // 2. Actualizar PERSONA
                        string queryPersona = @"
                            UPDATE PERSONA 
                            SET nombre_persona = @Nombre,
                                apellido_persona = @Apellido,
                                dni = @DNI,
                                email_persona = @Email,
                                direccion_persona = @Direccion,
                                id_localidad = (SELECT id_localidad FROM LOCALIDAD WHERE nombre_localidad = @Localidad),
                                fecha_nacimiento = @FechaNacimiento
                            WHERE id_persona = @IdPersona";

                        using (SqlCommand cmd = new SqlCommand(queryPersona, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@IdPersona", idPersona);
                            cmd.Parameters.AddWithValue("@Nombre", personal.Nombre);
                            cmd.Parameters.AddWithValue("@Apellido", personal.Apellido);
                            cmd.Parameters.AddWithValue("@DNI", personal.DNI);
                            cmd.Parameters.AddWithValue("@Email", personal.Email);
                            cmd.Parameters.AddWithValue("@Direccion", personal.Direccion);
                            cmd.Parameters.AddWithValue("@Localidad", personal.Localidad);
                            cmd.Parameters.AddWithValue("@FechaNacimiento", personal.FechaNacimiento);

                            cmd.ExecuteNonQuery();
                        }

                        // 3. Actualizar USUARIO
                        string queryUsuario = @"
                            UPDATE USUARIO 
                            SET usuario = @Usuario,
                                pass = CASE WHEN @Password = '' THEN pass ELSE @Password END,
                                id_rol = @IdRol
                            WHERE id_usuario = @IdUsuario";

                        using (SqlCommand cmd = new SqlCommand(queryUsuario, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@IdUsuario", personal.IdUsuario);
                            cmd.Parameters.AddWithValue("@Usuario", personal.Usuario);
                            cmd.Parameters.AddWithValue("@Password", PasswordHasher.HashPassword(personal.Password));
                            cmd.Parameters.AddWithValue("@IdRol", personal.IdRol);

                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
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