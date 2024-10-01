using proyecto2_prueba.Presentaciones.admin;
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
    public partial class menu_admin : Form
    {
        public menu_admin()
        {
            InitializeComponent();
            this.IsMdiContainer = true; //Hace que el formulario sea un contenedor MDI

        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void cerrarProgramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AbrirFormulario<T>(string mensaje) where T : Form, new()
        {
            // Verificar si ya hay un formulario MDI abierto
            Form formularioAbierto = this.MdiChildren.FirstOrDefault();

            if (formularioAbierto != null)
            {
                // Si hay un formulario abierto, preguntar si desea cerrarlo
                DialogResult resultado = MessageBox.Show(mensaje,
                                                         "Formulario en Uso",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Cerrar el formulario anterior
                    formularioAbierto.Close();

                    // Crear una nueva instancia y abrirla
                    T nuevoFormulario = new T();
                    nuevoFormulario.MdiParent = this;
                    nuevoFormulario.Show();
                }
                // Si elige "No", no se hace nada
            }
            else
            {
                // Si no hay ningún formulario abierto, se crea uno nuevo
                T nuevoFormulario = new T();
                nuevoFormulario.MdiParent = this;
                nuevoFormulario.Show();
            }
        }


        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Cerrar el formulario de admin y se redirige al inicio de sesion por el evento form closed
            this.Close();
            inicio_sesion sesion = new inicio_sesion();
        }

        private void registrarPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario que deseas abrir
            personal nuevo_personal = new personal();

            // Establece el formulario de administración como el formulario padre MDI
            nuevo_personal.MdiParent = this;

            // Abre el formulario hijo dentro del formulario de administración
            nuevo_personal.Show();
        }

        private void menuStripAdmin_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menu_admin_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aBMEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<personal>("Este formulario ya se encuentra abierto, ¿desea cerrar el anterior y abrir uno nuevo?");
        }

        private void aBMProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<listado_productos_admin>("Este formulario ya se encuentra abierto, ¿desea cerrar el anterior y abrir uno nuevo?");
        }


        private void aBMCategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<categorias_productos>("Este formulario ya se encuentra abierto, ¿desea cerrar el anterior y abrir uno nuevo?");
        }


        private void aBMNivelesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<niveles_clientes>("Este formulario ya se encuentra abierto, ¿desea cerrar el anterior y abrir uno nuevo?");
        }

    }
}
