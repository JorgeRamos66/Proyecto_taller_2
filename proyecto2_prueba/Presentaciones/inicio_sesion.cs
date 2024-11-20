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
                // Consulta con JOIN para obtener el nombre del rol, estado de baja, id_usuario, nombre y apellido
                string query = @"
                    SELECT R.nombre_rol, U.id_usuario, U.baja_usuario, U.pass, P.nombre_persona, P.apellido_persona
                    FROM USUARIO U
                    INNER JOIN ROL R ON U.id_rol = R.id_rol
                    INNER JOIN PERSONA P ON U.id_persona = P.id_persona
                    WHERE U.usuario = @usuario";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@usuario", usuario);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Obtener valores de nombre_rol y baja_usuario
                            tipoUsuario = reader["nombre_rol"].ToString();
                            bool usuarioDeshabilitado = Convert.ToBoolean(reader["baja_usuario"]);

                            if (!usuarioDeshabilitado)
                            {
                                MessageBox.Show("Su usuario fue deshabilitado. Contacte con el administrador para recuperarlo.",
                                                "USUARIO DESHABILITADO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            // Hashea la contraseña ingresada y compárala con la almacenada
                            string storedHashedPassword = reader["pass"].ToString();
                            string hashedInputPassword = PasswordHasher.HashPassword(pass);
                            if (hashedInputPassword != storedHashedPassword)
                            {
                                MessageBox.Show("El usuario y/o contraseña son incorrectos",
                                                "Usuario Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            // Obtener el id del usuario
                            int idUsuario = Convert.ToInt32(reader["id_usuario"]);
                            // Obtener nombre y apellido de la persona
                            string nombre = reader["nombre_persona"].ToString();
                            string apellido = reader["apellido_persona"].ToString();

                            // Guardar los detalles del usuario en la clase estática
                            UsuarioSesion.IdUsuario = idUsuario;
                            UsuarioSesion.Nombre = nombre;
                            UsuarioSesion.Apellido = apellido;

                            // Verificar el tipo de usuario y abrir la vista correspondiente
                            Form menu = null;
                            if (tipoUsuario == "admin")
                            {
                                menu = new menu_admin();
                            }
                            else if (tipoUsuario == "gerente")
                            {
                                menu = new menu_gerente();
                            }
                            else if (tipoUsuario == "vendedor")
                            {
                                menu = new menu_vendedor();
                            }

                            if (menu != null)
                            {
                                menu.FormClosed += (s, args) => this.Show();
                                menu.Show();

                                // Limpiar campos de texto por seguridad
                                textBoxUsuario.Clear();
                                textBoxPass.Clear();

                                // Ocultar formulario de inicio de sesión
                                this.Hide();
                            }
                        }
                        else
                        {
                            MessageBox.Show("El usuario y/o contraseña son incorrectos",
                                            "Usuario Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}",
                                    "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static class UsuarioSesion
        {
            public static int IdUsuario { get; set; }
            public static string Nombre { get; set; }                        
            public static string Apellido { get; set; }
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
