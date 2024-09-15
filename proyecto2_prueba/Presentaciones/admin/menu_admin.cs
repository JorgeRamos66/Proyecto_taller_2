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

        private void cerrarProgramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            registrar_personal nuevo_personal = new registrar_personal();

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
           

        }

        private void aBMProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Nuevo Metodo:

            // Verificar si el formulario ya está abierto
            Form formularioAbierto = Application.OpenForms.OfType<listado_productos_admin>().FirstOrDefault();

            if (formularioAbierto != null)
            {
                // El formulario ya está abierto, preguntar al usuario
                DialogResult resultado = MessageBox.Show("Este formulario ya se encuentra abierto, ¿desea cerrar el anterior y abrir uno nuevo?",
                                                         "Formulario en Uso",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Cerrar el formulario anterior
                    formularioAbierto.Close();

                    // Crear una nueva instancia y abrirla
                    listado_productos_admin lista_productos = new listado_productos_admin();
                    lista_productos.MdiParent = this;
                    lista_productos.Show();
                }
                // Si elige "No", no se hace nada
            }
            else
            {
                // Si no hay ningún formulario abierto, se crea uno nuevo
                listado_productos_admin lista_productos = new listado_productos_admin();
                lista_productos.MdiParent = this;
                lista_productos.Show();
            }

        }

        private void aBMCategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Verificar si el formulario ya está abierto
            Form formularioAbierto = Application.OpenForms.OfType<categorias_productos>().FirstOrDefault();

            if (formularioAbierto != null)
            {
                // El formulario ya está abierto, preguntar al usuario
                DialogResult resultado = MessageBox.Show("Este formulario ya se encuentra abierto, ¿desea cerrar el anterior y abrir uno nuevo?",
                                                         "Formulario en Uso",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Cerrar el formulario anterior
                    formularioAbierto.Close();

                    // Crear una nueva instancia y abrirla
                    categorias_productos lista_categorias = new categorias_productos();
                    lista_categorias.MdiParent = this;
                    lista_categorias.Show();
                }
                // Si elige "No", no se hace nada
            }
            else
            {
                // Si no hay ningún formulario abierto, se crea uno nuevo
                categorias_productos lista_categorias = new categorias_productos();
                lista_categorias.MdiParent = this;
                lista_categorias.Show();
            }
        }

       
    }
}
