using ML;
using BLL;
using System;
using System.Windows.Forms;

namespace proyecto2_prueba
{
    public partial class inicio_sesion : Form
    {
        private UsuarioBLL usuarioBLL = new UsuarioBLL();

        public inicio_sesion()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close(); // Cerrar el formulario cuando se presiona Esc
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void BInicioSesion_Click(object sender, EventArgs e)
        {
            string usuario = textBoxUsuario.Text;
            string pass = textBoxPass.Text;

            try
            {
                UsuarioEntidad user = usuarioBLL.ValidarUsuario(usuario, pass);

                if (user == null)
                {
                    MessageBox.Show("El usuario y/o contraseña son incorrectos.",
                                    "Usuario Inválido", 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Error);
                    return;
                }

                // Guardar los detalles del usuario en la clase estática UsuarioSesion
                UsuarioSesion.IdUsuario = user.IdUsuario;
                UsuarioSesion.Nombre = user.Nombre;
                UsuarioSesion.Apellido = user.Apellido;
                UsuarioSesion.NombreUsuario = usuario;
                UsuarioSesion.Rol = user.Rol;

                // Verificar el tipo de usuario y abrir la vista correspondiente
                Form menu = null;
                switch (user.Rol.ToLower())
                {
                    case "admin":
                        menu = new menu_admin();
                        break;
                    case "gerente":
                        menu = new menu_gerente();
                        break;
                    case "vendedor":
                        menu = new menu_vendedor();
                        break;
                }

                if (menu != null)
                {
                    menu.FormClosed += (s, args) => 
                    {
                        // Limpiar los datos de sesión al cerrar el formulario
                        UsuarioSesion.IdUsuario = 0;
                        UsuarioSesion.Nombre = null;
                        UsuarioSesion.Apellido = null;
                        UsuarioSesion.NombreUsuario = null;
                        UsuarioSesion.Rol = null;
                        
                        this.Show();
                    };

                    menu.Show();
                    textBoxUsuario.Clear();
                    textBoxPass.Clear();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBoxPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
