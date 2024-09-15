using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LUsuario_Click(object sender, EventArgs e)
        {

        }

        private void BInicioSesion_Click(object sender, EventArgs e)
        {
            string usuario, pass;
            usuario = textBoxUsuario.Text;
            pass = textBoxPass.Text;

            if(usuario == "admin" && pass == "admin")
            {
                //Se instancia un objeto del tipo menu_admin
                menu_admin Principal = new menu_admin();

                //Suscribir al evento FormClosed del formulario de admin
                //Explicacion: Cuando Principal se cierre, se vuelve a mostrar este form.
                //Esto hace que el Inicio de Sesion vuelve a aparecer evitando que la aplicacion
                // siga en estado de ejecucion aunque se hayan cerrado todas las ventanas.
                Principal.FormClosed += (s, args) => this.Show();

                //Mostrar menu del administrador
                Principal.Show();

                //Se limpian las textboxes por seguridad.
                textBoxUsuario.Clear();
                textBoxPass.Clear();

                //Ocultar Formulario inicio de sesion
                //Esta alternativa si no se utiliza con un evento que la vuelva a activar
                // deja a la aplicación en estado de ejecución, lo que imposibilita volver a ejecutarla.
                this.Hide();
                
            }else if (usuario == "gerente" && pass == "gerente")
            {
                MessageBox.Show("EN CONSTRUCCION: Menú de Gerente");
                textBoxUsuario.Clear();
                textBoxPass.Clear();

            }
            else
            {
                //En caso de error al ingresar los datos, se muestra un mensaje.
                MessageBox.Show("El usuario y/o contraseña son incorrectos","Usuario Invalido", MessageBoxButtons.OK,MessageBoxIcon.Error);
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
