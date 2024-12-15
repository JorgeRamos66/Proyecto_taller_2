using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ML;

namespace DAL
{
    public class ClienteDAL
    {
        private readonly string connectionString;

        public ClienteDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;
        }

        public Cliente ObtenerClientePorDni(int dni)
        {
            string query = @"
                SELECT 
                    C.id_cliente,
                    P.id_persona,
                    P.nombre_persona,
                    P.apellido_persona,
                    P.dni,
                    P.email_persona,
                    P.direccion_persona,
                    L.nombre_localidad,
                    Pr.nombre_provincia,
                    P.fecha_nacimiento,
                    C.id_nivel,
                    N.descuento,
                    N.nombre_nivel
                FROM CLIENTE C
                INNER JOIN PERSONA P ON C.id_persona = P.id_persona
                INNER JOIN LOCALIDAD L ON P.id_localidad = L.id_localidad
                INNER JOIN PROVINCIA Pr ON L.id_provincia = Pr.id_provincia
                INNER JOIN NIVEL N ON C.id_nivel = N.id_nivel
                WHERE P.dni = @dni";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@dni", dni);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Cliente
                            {
                                Id = (int)reader["id_cliente"],
                                IdPersona = (int)reader["id_persona"],
                                Nombre = reader["nombre_persona"].ToString(),
                                Apellido = reader["apellido_persona"].ToString(),
                                Dni = (int)reader["dni"],
                                Email = reader["email_persona"].ToString(),
                                Direccion = reader["direccion_persona"].ToString(),
                                Localidad = reader["nombre_localidad"].ToString(),
                                Provincia = reader["nombre_provincia"].ToString(),
                                FechaNacimiento = (DateTime)reader["fecha_nacimiento"],
                                IdNivel = (int)reader["id_nivel"],
                                NivelDescuento = (int)reader["descuento"],
                                NombreNivel = reader["nombre_nivel"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }
        public List<Cliente> ObtenerClientesFiltrados(string filtro)
        {
            List<Cliente> clientes = new List<Cliente>();
            string query = @"
                SELECT 
                    C.id_cliente,
                    P.id_persona,
                    P.nombre_persona,
                    P.apellido_persona,
                    P.dni,
                    P.email_persona,
                    P.direccion_persona,
                    L.nombre_localidad,
                    Pr.nombre_provincia,
                    P.fecha_nacimiento,
                    N.id_nivel,
                    N.descuento,
                    N.nombre_nivel
                FROM CLIENTE C
                INNER JOIN PERSONA P ON C.id_persona = P.id_persona
                INNER JOIN LOCALIDAD L ON P.id_localidad = L.id_localidad
                INNER JOIN PROVINCIA Pr ON L.id_provincia = Pr.id_provincia
                INNER JOIN NIVEL N ON C.id_nivel = N.id_nivel
                WHERE 
                    P.nombre_persona LIKE @filtro OR
                    P.apellido_persona LIKE @filtro OR
                    CAST(P.dni AS NVARCHAR) LIKE @filtro";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@filtro", $"%{filtro}%");
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clientes.Add(new Cliente
                            {
                                Id = (int)reader["id_cliente"],
                                IdPersona = (int)reader["id_persona"],
                                Nombre = reader["nombre_persona"].ToString(),
                                Apellido = reader["apellido_persona"].ToString(),
                                Dni = (int)reader["dni"],
                                Email = reader["email_persona"].ToString(),
                                Direccion = reader["direccion_persona"].ToString(),
                                Localidad = reader["nombre_localidad"].ToString(),
                                Provincia = reader["nombre_provincia"].ToString(),
                                FechaNacimiento = (DateTime)reader["fecha_nacimiento"],
                                IdNivel = (int)reader["id_nivel"],
                                NivelDescuento = (int)reader["descuento"],
                                NombreNivel = reader["nombre_nivel"].ToString()
                            });
                        }
                    }
                }
            }
            return clientes;
        }


        public Cliente ObtenerClientePorId(int idCliente)
        {
            string query = @"
                SELECT 
                    C.id_cliente,
                    P.id_persona,
                    P.nombre_persona,
                    P.apellido_persona,
                    P.dni,
                    P.email_persona,
                    P.direccion_persona,
                    L.nombre_localidad,
                    Pr.nombre_provincia,
                    P.fecha_nacimiento,
                    C.id_nivel,
                    N.descuento,
                    N.nombre_nivel
                FROM CLIENTE C
                INNER JOIN PERSONA P ON C.id_persona = P.id_persona
                INNER JOIN LOCALIDAD L ON P.id_localidad = L.id_localidad
                INNER JOIN PROVINCIA Pr ON L.id_provincia = Pr.id_provincia
                INNER JOIN NIVEL N ON C.id_nivel = N.id_nivel
                WHERE C.id_cliente = @idCliente";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Cliente
                            {
                                Id = (int)reader["id_cliente"],
                                IdPersona = (int)reader["id_persona"],
                                Nombre = reader["nombre_persona"].ToString(),
                                Apellido = reader["apellido_persona"].ToString(),
                                Dni = (int)reader["dni"],
                                Email = reader["email_persona"].ToString(),
                                Direccion = reader["direccion_persona"].ToString(),
                                Localidad = reader["nombre_localidad"].ToString(),
                                Provincia = reader["nombre_provincia"].ToString(),
                                FechaNacimiento = (DateTime)reader["fecha_nacimiento"],
                                IdNivel = (int)reader["id_nivel"],
                                NivelDescuento = (int)reader["descuento"],
                                NombreNivel = reader["nombre_nivel"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public void InsertarCliente(Cliente cliente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int idLocalidad = ObtenerOCrearLocalidad(cliente.Localidad, cliente.Provincia, connection, transaction);
                        int idPersona = InsertarPersona(cliente, idLocalidad, connection, transaction);
                        InsertarClienteBase(idPersona, connection, transaction);

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

        public void ActualizarCliente(Cliente cliente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int idLocalidad = ObtenerOCrearLocalidad(cliente.Localidad, cliente.Provincia, connection, transaction);
                        ActualizarPersona(cliente, idLocalidad, connection, transaction);
                        ActualizarClienteBase(cliente, connection, transaction);

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

        private int ObtenerOCrearLocalidad(string nombreLocalidad, string nombreProvincia, SqlConnection connection, SqlTransaction transaction)
        {
            int idProvincia = ObtenerOCrearProvincia(nombreProvincia, connection, transaction);

            string queryLocalidad = "SELECT id_localidad FROM LOCALIDAD WHERE nombre_localidad = @nombreLocalidad AND id_provincia = @idProvincia";
            using (SqlCommand cmd = new SqlCommand(queryLocalidad, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@nombreLocalidad", nombreLocalidad);
                cmd.Parameters.AddWithValue("@idProvincia", idProvincia);
                var result = cmd.ExecuteScalar();

                if (result != null)
                    return (int)result;

                string insertLocalidad = @"
                    INSERT INTO LOCALIDAD (nombre_localidad, id_provincia) 
                    VALUES (@nombreLocalidad, @idProvincia);
                    SELECT SCOPE_IDENTITY();";

                using (SqlCommand insertCmd = new SqlCommand(insertLocalidad, connection, transaction))
                {
                    insertCmd.Parameters.AddWithValue("@nombreLocalidad", nombreLocalidad);
                    insertCmd.Parameters.AddWithValue("@idProvincia", idProvincia);
                    return Convert.ToInt32(insertCmd.ExecuteScalar());
                }
            }
        }

        private int ObtenerOCrearProvincia(string nombreProvincia, SqlConnection connection, SqlTransaction transaction)
        {
            string queryProvincia = "SELECT id_provincia FROM PROVINCIA WHERE nombre_provincia = @nombreProvincia";
            using (SqlCommand cmd = new SqlCommand(queryProvincia, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@nombreProvincia", nombreProvincia);
                var result = cmd.ExecuteScalar();

                if (result != null)
                    return (int)result;

                string insertProvincia = @"
                    INSERT INTO PROVINCIA (nombre_provincia) 
                    VALUES (@nombreProvincia);
                    SELECT SCOPE_IDENTITY();";

                using (SqlCommand insertCmd = new SqlCommand(insertProvincia, connection, transaction))
                {
                    insertCmd.Parameters.AddWithValue("@nombreProvincia", nombreProvincia);
                    return Convert.ToInt32(insertCmd.ExecuteScalar());
                }
            }
        }

        private int InsertarPersona(Cliente cliente, int idLocalidad, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"
                INSERT INTO PERSONA (
                    nombre_persona, 
                    apellido_persona, 
                    dni, 
                    email_persona, 
                    direccion_persona, 
                    id_localidad, 
                    fecha_nacimiento
                ) 
                VALUES (
                    @nombre, 
                    @apellido, 
                    @dni, 
                    @email, 
                    @direccion, 
                    @idLocalidad, 
                    @fechaNacimiento
                );
                SELECT SCOPE_IDENTITY();";

            using (SqlCommand cmd = new SqlCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@apellido", cliente.Apellido);
                cmd.Parameters.AddWithValue("@dni", cliente.Dni);
                cmd.Parameters.AddWithValue("@email", cliente.Email);
                cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("@idLocalidad", idLocalidad);
                cmd.Parameters.AddWithValue("@fechaNacimiento", cliente.FechaNacimiento);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void InsertarClienteBase(int idPersona, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"
                INSERT INTO CLIENTE (
                    id_persona, 
                    id_nivel, 
                    observaciones, 
                    monto_total
                ) 
                VALUES (
                    @idPersona, 
                    1, 
                    '', 
                    0
                )";

            using (SqlCommand cmd = new SqlCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@idPersona", idPersona);
                cmd.ExecuteNonQuery();
            }
        }

        private void ActualizarPersona(Cliente cliente, int idLocalidad, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"
                UPDATE PERSONA 
                SET 
                    nombre_persona = @nombre,
                    apellido_persona = @apellido,
                    dni = @dni,
                    email_persona = @email,
                    direccion_persona = @direccion,
                    id_localidad = @idLocalidad,
                    fecha_nacimiento = @fechaNacimiento
                WHERE id_persona = @idPersona";

            using (SqlCommand cmd = new SqlCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@idPersona", cliente.IdPersona);
                cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@apellido", cliente.Apellido);
                cmd.Parameters.AddWithValue("@dni", cliente.Dni);
                cmd.Parameters.AddWithValue("@email", cliente.Email);
                cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("@idLocalidad", idLocalidad);
                cmd.Parameters.AddWithValue("@fechaNacimiento", cliente.FechaNacimiento);

                cmd.ExecuteNonQuery();
            }
        }

        private void ActualizarClienteBase(Cliente cliente, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"
                UPDATE CLIENTE 
                SET 
                    observaciones = ''
                WHERE id_cliente = @idCliente";

            using (SqlCommand cmd = new SqlCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@idCliente", cliente.Id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}