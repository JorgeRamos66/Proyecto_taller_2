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

namespace proyecto2_prueba
{
    public partial class inicio_sesion : Form
    {
        public inicio_sesion()
        {
            InitializeComponent();

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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LUsuario_Click(object sender, EventArgs e)
        {

        }

        private void BInicioSesion_Click(object sender, EventArgs e)
        {
            string usuario = textBoxUsuario.Text;
            string pass = textBoxPass.Text;
            string tipoUsuario = null;

            // Obtener cadena de conexión desde el archivo de configuración
            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;

            // Conectar a la base de datos y verificar el usuario junto con su rol
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Consulta con JOIN para obtener el nombre del rol desde la tabla ROL
                string query = @"SELECT R.nombre_rol
                         FROM USUARIO U
                         INNER JOIN ROL R ON U.id_rol = R.id_rol
                         WHERE U.usuario = @usuario AND U.pass = @pass";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@usuario", usuario);
                command.Parameters.AddWithValue("@pass", pass);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        tipoUsuario = result.ToString();

                        // Verificar el tipo de usuario y abrir la vista correspondiente
                        if (tipoUsuario == "admin")
                        {
                            menu_admin Principal = new menu_admin();
                            Principal.FormClosed += (s, args) => this.Show();
                            Principal.Show();
                        }
                        else if (tipoUsuario == "gerente")
                        {
                            menu_gerente Principal = new menu_gerente();
                            Principal.FormClosed += (s, args) => this.Show();
                            Principal.Show();
                        }
                        else if (tipoUsuario == "vendedor")
                        {
                            menu_vendedor Principal = new menu_vendedor();
                            Principal.FormClosed += (s, args) => this.Show();
                            Principal.Show();
                            MessageBox.Show("En construccion xd", "Alert xd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        // Limpiar campos de texto por seguridad
                        textBoxUsuario.Clear();
                        textBoxPass.Clear();

                        // Ocultar formulario de inicio de sesión
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("El usuario y/o contraseña son incorrectos", "Usuario Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void textBoxUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras, numeros y teclas de control (como backspace)
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras y teclas de control (como backspace)
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        

       
    }
}
