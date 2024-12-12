using proyecto2_prueba.Presentaciones.admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyecto2_prueba;

namespace proyecto2_prueba
{
    public partial class registrar_personal : Form
    {
        private personal formularioListado; // Campo para almacenar la referencia del formulario listado
        private int IdUsuario; // Campo para almacenar el ID del usuario

        public registrar_personal(personal listado)
        {
            InitializeComponent();
            CargarRoles();
            formularioListado = listado; // Guardar la referencia del formulario listado_personal
            IdUsuario = 0; // Establecer por defecto a 0 para inserción nueva
        }

        public registrar_personal(int idUsuario, string nombre, string apellido, string dni, string email, string direccion, string ciudad, string provincia, string usuarioNombre, string rol, DateTime fechaNacimiento, personal listado)
        {
            InitializeComponent();
            CargarRoles();
            formularioListado = listado; // Guardar la referencia del formulario listado_personal
            IdUsuario = idUsuario; // Guardar el ID del usuario
            Linfo.Text = "MODIFICAR PERSONAL";

            // Cargar los datos en los controles del formulario
            textBoxNombre.Text = nombre;
            textBoxApellido.Text = apellido;
            textBoxEmail.Text = email;
            textBoxDNI.Text = dni;
            textCiudad.Text = ciudad;
            textProvincia.Text = provincia;
            textBoxDireccion.Text = direccion;
            textBoxUsuario.Text = usuarioNombre;

            // Asignar la fecha de nacimiento al DateTimePicker
            dateTimePicker1.Value = fechaNacimiento;
            
            // Seleccionar el rol en el ComboBox
            int rolIndex = comboBoxRol.Items.Cast<ComboBoxItem>()
                    .ToList()
                    .FindIndex(item => string.Equals(item.Text, rol, StringComparison.OrdinalIgnoreCase));

            if (rolIndex != -1)
            {
                comboBoxRol.SelectedIndex = rolIndex;
            }
            else
            {
                MessageBox.Show("Rol no encontrado en la lista de roles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close(); // Cerrar el formulario cuando se presiona Esc
                return true;  // Indicar que la tecla ha sido manejada
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void LNombre_Click(object sender, EventArgs e)
        {

        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarRoles()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString; // Asegúrate de que 'MiCadenaDeConexion' está definido en tu archivo de configuración
            string query = "SELECT id_rol, nombre_rol FROM ROL";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    comboBoxRol.Items.Clear(); // Limpiar elementos existentes

                    while (reader.Read())
                    {
                        // Crear un objeto ComboBoxItem para almacenar el ID y el nombre
                        var item = new ComboBoxItem
                        {
                            Value = reader["id_rol"].ToString(),
                            Text = reader["nombre_rol"].ToString()
                        };
                        comboBoxRol.Items.Add(item);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los roles: " + ex.Message);
                }
            }
        }
        public class ComboBoxItem
        {
            public string Value { get; set; }
            public string Text { get; set; }

            public override string ToString()
            {
                return Text; // Esto es lo que se mostrará en el ComboBox
            }
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            // Obtener los valores del formulario
            string nombre = textBoxNombre.Text;
            string apellido = textBoxApellido.Text;
            string dni = textBoxDNI.Text;
            string email = textBoxEmail.Text;
            string direccion = textBoxDireccion.Text;
            string ciudad = textCiudad.Text;
            string provincia = textProvincia.Text;
            string nombreUsuario = textBoxUsuario.Text;
            string password = textBoxContraseña.Text;
            DateTime fechaNacimiento = dateTimePicker1.Value;

            // Obtener el ID del rol seleccionado
            ComboBoxItem selectedItem = comboBoxRol.SelectedItem as ComboBoxItem;
            string rolId = selectedItem != null ? selectedItem.Value : string.Empty;

            // Hashear la contraseña antes de almacenarla
            string hashedPassword = PasswordHasher.HashPassword(password);

            // Validar los campos
            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(dni) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(direccion) ||
                string.IsNullOrWhiteSpace(ciudad) ||
                string.IsNullOrWhiteSpace(provincia) ||
                string.IsNullOrWhiteSpace(nombreUsuario) ||
                (IdUsuario == 0 && string.IsNullOrWhiteSpace(password)) || // Solo verificar la contraseña si el ID es 0 (nuevo usuario)
                string.IsNullOrWhiteSpace(rolId))
            {
                MessageBox.Show("Debe rellenar todos los campos para registrar el personal.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(rolId, out int rolIdInt))
            {
                MessageBox.Show("El ID del rol no es válido.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // Cadena de conexión desde el archivo de configuración
            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Verificar si la provincia ya existe
                    string queryProvincia = "SELECT id_provincia FROM PROVINCIA WHERE nombre_provincia = @NombreProvincia";
                    int idProvincia;

                    using (SqlCommand commandProvincia = new SqlCommand(queryProvincia, connection))
                    {
                        commandProvincia.Parameters.AddWithValue("@NombreProvincia", provincia);
                        object result = commandProvincia.ExecuteScalar();
                        if (result != null)
                        {
                            idProvincia = Convert.ToInt32(result); // Provincia encontrada
                        }
                        else
                        {
                            // Insertar la nueva provincia si no existe
                            string insertProvincia = "INSERT INTO PROVINCIA (nombre_provincia) VALUES (@NombreProvincia); SELECT SCOPE_IDENTITY();";
                            using (SqlCommand insertCommandProvincia = new SqlCommand(insertProvincia, connection))
                            {
                                insertCommandProvincia.Parameters.AddWithValue("@NombreProvincia", provincia);
                                idProvincia = Convert.ToInt32(insertCommandProvincia.ExecuteScalar());
                            }
                        }
                    }

                    // Verificar si la localidad ya existe
                    string queryLocalidad = "SELECT id_localidad FROM LOCALIDAD WHERE nombre_localidad = @NombreLocalidad AND id_provincia = @IdProvincia";
                    int idLocalidad;

                    using (SqlCommand commandLocalidad = new SqlCommand(queryLocalidad, connection))
                    {
                        commandLocalidad.Parameters.AddWithValue("@NombreLocalidad", ciudad);
                        commandLocalidad.Parameters.AddWithValue("@IdProvincia", idProvincia);
                        object result = commandLocalidad.ExecuteScalar();
                        if (result != null)
                        {
                            idLocalidad = Convert.ToInt32(result); // Localidad encontrada
                        }
                        else
                        {
                            // Insertar la nueva localidad si no existe
                            string insertLocalidad = "INSERT INTO LOCALIDAD (nombre_localidad, id_provincia) VALUES (@NombreLocalidad, @IdProvincia); SELECT SCOPE_IDENTITY();";
                            using (SqlCommand insertCommandLocalidad = new SqlCommand(insertLocalidad, connection))
                            {
                                insertCommandLocalidad.Parameters.AddWithValue("@NombreLocalidad", ciudad);
                                insertCommandLocalidad.Parameters.AddWithValue("@IdProvincia", idProvincia);
                                idLocalidad = Convert.ToInt32(insertCommandLocalidad.ExecuteScalar());
                            }
                        }
                    }

                    if (IdUsuario == 0)
                    {
                        // Crear el comando SQL para insertar la persona
                        string queryPersona = @"
                        INSERT INTO PERSONA (nombre_persona, apellido_persona, dni, email_persona, direccion_persona, id_localidad, fecha_nacimiento) 
                        VALUES (@Nombre, @Apellido, @DNI, @Email, @Direccion, @IdLocalidad, @FechaNacimiento);
                        SELECT SCOPE_IDENTITY();"; // Recuperar el ID de la nueva persona

                        using (SqlCommand commandPersona = new SqlCommand(queryPersona, connection))
                        {
                            commandPersona.Parameters.AddWithValue("@Nombre", nombre);
                            commandPersona.Parameters.AddWithValue("@Apellido", apellido);
                            commandPersona.Parameters.AddWithValue("@DNI", dni);
                            commandPersona.Parameters.AddWithValue("@Email", email);
                            commandPersona.Parameters.AddWithValue("@Direccion", direccion);
                            commandPersona.Parameters.AddWithValue("@IdLocalidad", idLocalidad); // Asegúrate de obtener este valor correctamente
                            commandPersona.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);

                            // Ejecutar el comando y obtener el ID de la nueva persona
                            int idPersona = Convert.ToInt32(commandPersona.ExecuteScalar());

                            // Ahora, crear el comando SQL para insertar el usuario relacionado
                            string queryUsuario = @"
                            INSERT INTO USUARIO (usuario, pass, baja_usuario, id_persona, id_rol) 
                            VALUES (@Usuario, @Pass, @BajaUsuario, @IdPersona, @Rol);
                            SELECT SCOPE_IDENTITY();"; // Recuperar el ID del nuevo usuario

                            using (SqlCommand commandUsuario = new SqlCommand(queryUsuario, connection))
                            {
                                commandUsuario.Parameters.AddWithValue("@Usuario", nombreUsuario);
                                commandUsuario.Parameters.AddWithValue("@Pass", hashedPassword);
                                commandUsuario.Parameters.AddWithValue("@BajaUsuario", 1); // Suponiendo que el usuario no está dado de baja inicialmente
                                commandUsuario.Parameters.AddWithValue("@IdPersona", idPersona);
                                commandUsuario.Parameters.AddWithValue("@Rol", rolIdInt);

                                // Ejecutar el comando y obtener el ID generado
                                int idUsuario = Convert.ToInt32(commandUsuario.ExecuteScalar());

                                // Mensaje de éxito
                                MessageBox.Show($"El personal '{nombre} {apellido}' se ha registrado correctamente.",
                                                "Éxito",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        // Verificar si el usuario existe antes de actualizar
                        string checkQuery = "SELECT COUNT(*) FROM USUARIO WHERE id_usuario = @IdUsuario";
                        using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                        {
                            checkCommand.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                            int count = (int)checkCommand.ExecuteScalar();

                            if (count == 0)
                            {
                                MessageBox.Show("El usuario que intenta modificar no existe.",
                                                "Error",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
                                return;
                            }
                        }

                        // Crear el comando SQL para actualizar la persona relacionada con el usuario
                        string updateQueryPersona = @"
                        UPDATE PERSONA 
                        SET nombre_persona = @Nombre, apellido_persona = @Apellido, dni = @DNI, 
                            email_persona = @Email, direccion_persona = @Direccion, id_localidad = @IdLocalidad, fecha_nacimiento = @FechaNacimiento 
                        WHERE id_persona = (SELECT id_persona FROM USUARIO WHERE id_usuario = @IdUsuario)";

                        using (SqlCommand commandPersona = new SqlCommand(updateQueryPersona, connection))
                        {
                            commandPersona.Parameters.AddWithValue("@Nombre", nombre);
                            commandPersona.Parameters.AddWithValue("@Apellido", apellido);
                            commandPersona.Parameters.AddWithValue("@DNI", dni);
                            commandPersona.Parameters.AddWithValue("@Email", email);
                            commandPersona.Parameters.AddWithValue("@Direccion", direccion);
                            commandPersona.Parameters.AddWithValue("@IdLocalidad", idLocalidad); // Asegúrate de obtener este valor correctamente
                            commandPersona.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                            commandPersona.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                            commandPersona.ExecuteNonQuery();
                        }

                        // Crear el comando SQL para actualizar los datos del usuario
                        string updateQueryUsuario = @"
                            UPDATE USUARIO 
                            SET usuario = @Usuario, baja_usuario = @BajaUsuario, id_rol = @Rol 
                            WHERE id_usuario = @IdUsuario";

                        // Si la contraseña no está vacía, agregarla al comando de actualización
                        if (!string.IsNullOrWhiteSpace(password))
                        {
                            
                            updateQueryUsuario = @"
                                UPDATE USUARIO 
                                SET usuario = @Usuario, pass = @Pass, baja_usuario = @BajaUsuario, id_rol = @Rol 
                                WHERE id_usuario = @IdUsuario";

                            using (SqlCommand commandUsuario = new SqlCommand(updateQueryUsuario, connection))
                            {
                                commandUsuario.Parameters.AddWithValue("@Usuario", nombreUsuario);
                                commandUsuario.Parameters.AddWithValue("@Pass", hashedPassword);
                                commandUsuario.Parameters.AddWithValue("@BajaUsuario", 1); // Suponiendo que el usuario no está dado de baja inicialmente
                                commandUsuario.Parameters.AddWithValue("@Rol", rolIdInt);
                                commandUsuario.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                                commandUsuario.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // Si la contraseña está vacía, no la actualices
                            using (SqlCommand commandUsuario = new SqlCommand(updateQueryUsuario, connection))
                            {
                                commandUsuario.Parameters.AddWithValue("@Usuario", nombreUsuario);
                                commandUsuario.Parameters.AddWithValue("@BajaUsuario", 0); // Suponiendo que el usuario no está dado de baja inicialmente
                                commandUsuario.Parameters.AddWithValue("@Rol", rolIdInt);
                                commandUsuario.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                                commandUsuario.ExecuteNonQuery();
                            }
                        }

                        // Mensaje de éxito
                        MessageBox.Show($"El personal '{nombre} {apellido}' se ha actualizado correctamente.",
                                        "Éxito",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }

                    // Llamar al método para cargar el personal al DataGridView en listado_personal
                    formularioListado.CargarPersonal();

                    // Cerrar el formulario de registro de personal
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al agregar/actualizar el personal: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}
