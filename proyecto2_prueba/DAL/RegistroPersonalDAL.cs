using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ML;

namespace DAL
{
    public class RegistroPersonalDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;

        public int ObtenerOCrearProvincia(string nombreProvincia)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string queryProvincia = "SELECT id_provincia FROM PROVINCIA WHERE nombre_provincia = @NombreProvincia";
                
                using (SqlCommand command = new SqlCommand(queryProvincia, connection))
                {
                    command.Parameters.AddWithValue("@NombreProvincia", nombreProvincia);
                    object result = command.ExecuteScalar();
                    
                    if (result != null)
                        return Convert.ToInt32(result);

                    string insertProvincia = "INSERT INTO PROVINCIA (nombre_provincia) VALUES (@NombreProvincia); SELECT SCOPE_IDENTITY();";
                    command.CommandText = insertProvincia;
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public int ObtenerOCrearLocalidad(string nombreLocalidad, int idProvincia)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string queryLocalidad = "SELECT id_localidad FROM LOCALIDAD WHERE nombre_localidad = @NombreLocalidad AND id_provincia = @IdProvincia";
                
                using (SqlCommand command = new SqlCommand(queryLocalidad, connection))
                {
                    command.Parameters.AddWithValue("@NombreLocalidad", nombreLocalidad);
                    command.Parameters.AddWithValue("@IdProvincia", idProvincia);
                    object result = command.ExecuteScalar();
                    
                    if (result != null)
                        return Convert.ToInt32(result);

                    string insertLocalidad = "INSERT INTO LOCALIDAD (nombre_localidad, id_provincia) VALUES (@NombreLocalidad, @IdProvincia); SELECT SCOPE_IDENTITY();";
                    command.CommandText = insertLocalidad;
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public void InsertarPersonal(Personal personal, int idLocalidad)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insertar persona
                        string queryPersona = @"
                            INSERT INTO PERSONA (nombre_persona, apellido_persona, dni, email_persona, 
                                              direccion_persona, id_localidad, fecha_nacimiento) 
                            VALUES (@Nombre, @Apellido, @DNI, @Email, @Direccion, @IdLocalidad, @FechaNacimiento);
                            SELECT SCOPE_IDENTITY();";

                        int idPersona;
                        using (SqlCommand command = new SqlCommand(queryPersona, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Nombre", personal.Nombre);
                            command.Parameters.AddWithValue("@Apellido", personal.Apellido);
                            command.Parameters.AddWithValue("@DNI", personal.DNI);
                            command.Parameters.AddWithValue("@Email", personal.Email);
                            command.Parameters.AddWithValue("@Direccion", personal.Direccion);
                            command.Parameters.AddWithValue("@IdLocalidad", idLocalidad);
                            command.Parameters.AddWithValue("@FechaNacimiento", personal.FechaNacimiento);

                            idPersona = Convert.ToInt32(command.ExecuteScalar());
                        }

                        // Insertar usuario
                        string queryUsuario = @"
                            INSERT INTO USUARIO (usuario, pass, baja_usuario, id_persona, id_rol) 
                            VALUES (@Usuario, @Pass, @BajaUsuario, @IdPersona, @Rol);";

                        using (SqlCommand command = new SqlCommand(queryUsuario, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Usuario", personal.Usuario);
                            command.Parameters.AddWithValue("@Pass", personal.Password);
                            command.Parameters.AddWithValue("@BajaUsuario", personal.BajaUsuario);
                            command.Parameters.AddWithValue("@IdPersona", idPersona);
                            command.Parameters.AddWithValue("@Rol", personal.IdRol);

                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void ActualizarPersonal(Personal personal, int idLocalidad)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Actualizar persona
                        string updateQueryPersona = @"
                            UPDATE PERSONA 
                            SET nombre_persona = @Nombre, 
                                apellido_persona = @Apellido, 
                                dni = @DNI, 
                                email_persona = @Email, 
                                direccion_persona = @Direccion, 
                                id_localidad = @IdLocalidad, 
                                fecha_nacimiento = @FechaNacimiento 
                            WHERE id_persona = (SELECT id_persona FROM USUARIO WHERE id_usuario = @IdUsuario)";

                        using (SqlCommand command = new SqlCommand(updateQueryPersona, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Nombre", personal.Nombre);
                            command.Parameters.AddWithValue("@Apellido", personal.Apellido);
                            command.Parameters.AddWithValue("@DNI", personal.DNI);
                            command.Parameters.AddWithValue("@Email", personal.Email);
                            command.Parameters.AddWithValue("@Direccion", personal.Direccion);
                            command.Parameters.AddWithValue("@IdLocalidad", idLocalidad);
                            command.Parameters.AddWithValue("@FechaNacimiento", personal.FechaNacimiento);
                            command.Parameters.AddWithValue("@IdUsuario", personal.IdUsuario);

                            command.ExecuteNonQuery();
                        }

                        // Actualizar usuario
                        string updateQueryUsuario = string.IsNullOrEmpty(personal.Password) ?
                            @"UPDATE USUARIO 
                              SET usuario = @Usuario, 
                                  baja_usuario = @BajaUsuario, 
                                  id_rol = @Rol 
                              WHERE id_usuario = @IdUsuario" :
                            @"UPDATE USUARIO 
                              SET usuario = @Usuario, 
                                  pass = @Pass, 
                                  baja_usuario = @BajaUsuario, 
                                  id_rol = @Rol 
                              WHERE id_usuario = @IdUsuario";

                        using (SqlCommand command = new SqlCommand(updateQueryUsuario, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Usuario", personal.Usuario);
                            if (!string.IsNullOrEmpty(personal.Password))
                                command.Parameters.AddWithValue("@Pass", personal.Password);
                            command.Parameters.AddWithValue("@BajaUsuario", personal.BajaUsuario);
                            command.Parameters.AddWithValue("@Rol", personal.IdRol);
                            command.Parameters.AddWithValue("@IdUsuario", personal.IdUsuario);

                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}