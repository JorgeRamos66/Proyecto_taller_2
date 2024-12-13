using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using BLL;
using ML;
using proyecto2_prueba.Presentaciones.admin;
using System.Linq;

namespace proyecto2_prueba
{
    public partial class registrar_personal : Form
    {
        private personal formularioListado;
        private int IdUsuario;
        private readonly PersonalBLL personalBLL = new PersonalBLL();

        public registrar_personal(personal listado)
        {
            InitializeComponent();

            // Vincular eventos KeyPress
            textBoxNombre.KeyPress += new KeyPressEventHandler(textBoxNombre_KeyPress);
            textBoxApellido.KeyPress += new KeyPressEventHandler(textBoxApellido_KeyPress);
            textCiudad.KeyPress += new KeyPressEventHandler(textCiudad_KeyPress);
            textProvincia.KeyPress += new KeyPressEventHandler(textProvincia_KeyPress);
            textBoxDNI.KeyPress += new KeyPressEventHandler(textBoxDNI_KeyPress);

            LinfoNuevo.Visible = true;
            CargarRoles();
            formularioListado = listado;
            IdUsuario = 0;
        }
        
        public registrar_personal(int idUsuario, string nombre, string apellido, string dni, string email, string direccion, string ciudad, string provincia, string usuarioNombre, string rol, DateTime fechaNacimiento, personal listado)
        {
            InitializeComponent();

            // Vincular eventos KeyPress
            textBoxNombre.KeyPress += new KeyPressEventHandler(textBoxNombre_KeyPress);
            textBoxApellido.KeyPress += new KeyPressEventHandler(textBoxApellido_KeyPress);
            textCiudad.KeyPress += new KeyPressEventHandler(textCiudad_KeyPress);
            textProvincia.KeyPress += new KeyPressEventHandler(textProvincia_KeyPress);
            textBoxDNI.KeyPress += new KeyPressEventHandler(textBoxDNI_KeyPress);

            CargarRoles();
            formularioListado = listado;
            IdUsuario = idUsuario;
            LInfoModificar.Visible = true;
            LModificarContraseña.Visible = true;

            // Cargar los datos en los controles
            textBoxNombre.Text = nombre;
            textBoxApellido.Text = apellido;
            textBoxEmail.Text = email;
            textBoxDNI.Text = dni;
            textCiudad.Text = ciudad;
            textProvincia.Text = provincia;
            textBoxDireccion.Text = direccion;
            textBoxUsuario.Text = usuarioNombre;
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
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void CargarRoles()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;
            string query = "SELECT id_rol, nombre_rol FROM ROL";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    comboBoxRol.Items.Clear();

                    while (reader.Read())
                    {
                        var item = new ComboBoxItem
                        {
                            Value = reader["id_rol"].ToString(),
                            Text = reader["nombre_rol"].ToString()
                        };
                        comboBoxRol.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los roles: " + ex.Message);
                }
            }
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que se haya seleccionado un tipo de documento
                if (!radioButtonDNI.Checked && !radioButtonCUIT.Checked && !radioButtonCUIL.Checked)
                {
                    throw new ArgumentException("Debe seleccionar un tipo de documento");
                }

                // Validar que los campos no estén vacíos
                if (string.IsNullOrWhiteSpace(textBoxNombre.Text) ||
                    string.IsNullOrWhiteSpace(textBoxApellido.Text) ||
                    string.IsNullOrWhiteSpace(textBoxDNI.Text) ||
                    string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
                    string.IsNullOrWhiteSpace(textBoxDireccion.Text) ||
                    string.IsNullOrWhiteSpace(textCiudad.Text) ||
                    string.IsNullOrWhiteSpace(textProvincia.Text) ||
                    string.IsNullOrWhiteSpace(textBoxUsuario.Text) ||
                    (IdUsuario == 0 && string.IsNullOrWhiteSpace(textBoxContraseña.Text)) ||
                    comboBoxRol.SelectedItem == null)
                {
                    throw new ArgumentException("Todos los campos son obligatorios");
                }

                // Validar formato de email
                if (!textBoxEmail.Text.Contains("@") || !textBoxEmail.Text.Contains("."))
                {
                    throw new ArgumentException("El formato del email no es válido");
                }

                // Validar DNI (8 dígitos)
                if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxDNI.Text, @"^\d{8}$"))
                {
                    throw new ArgumentException("El DNI debe contener 8 dígitos");
                }

                // Validar fecha de nacimiento
                if (dateTimePicker1.Value > DateTime.Now)
                {
                    throw new ArgumentException("La fecha de nacimiento no puede ser futura");
                }

                var personal = new Personal
                {
                    IdUsuario = IdUsuario,
                    Nombre = textBoxNombre.Text.Trim(),
                    Apellido = textBoxApellido.Text.Trim(),
                    DNI = textBoxDNI.Text.Trim(),
                    Email = textBoxEmail.Text.Trim(),
                    Direccion = textBoxDireccion.Text.Trim(),
                    Localidad = textCiudad.Text.Trim(),
                    Provincia = textProvincia.Text.Trim(),
                    Usuario = textBoxUsuario.Text.Trim(),
                    Password = textBoxContraseña.Text,
                    FechaNacimiento = dateTimePicker1.Value,
                    IdRol = int.Parse(((ComboBoxItem)comboBoxRol.SelectedItem).Value),
                    BajaUsuario = 1
                };

                personalBLL.GuardarPersonal(personal);

                MessageBox.Show($"El personal '{personal.Nombre} {personal.Apellido}' se ha {(IdUsuario == 0 ? "registrado" : "actualizado")} correctamente.",
                              "Éxito",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);

                formularioListado.CargarPersonal();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al {(IdUsuario == 0 ? "registrar" : "actualizar")} el personal: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public class ComboBoxItem
        {
            public string Value { get; set; }
            public string Text { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
        // Solo letras y espacios para nombres y ubicaciones
        private void textBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textProvincia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Solo números para DNI/CUIT/CUIL
        private void textBoxDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }    
}