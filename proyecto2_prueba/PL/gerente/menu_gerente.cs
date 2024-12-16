
using System;
using System.Linq;
using System.Windows.Forms;
using ML;
using BLL;
using proyecto2_prueba.PL.gerente;

namespace proyecto2_prueba
{
    public partial class menu_gerente : Form
    {
        public menu_gerente()
        {
            InitializeComponent();
            this.IsMdiContainer = true; // Hace que el formulario sea un contenedor MDI
            // Actualizar el label con el nombre y apellido del usuario
            LNombreUsuario.Text = $"{UsuarioSesion.Nombre} {UsuarioSesion.Apellido}";
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
            // Cerrar el formulario de gerente y se redirige al inicio de sesión por el evento form closed
            this.Close();
            inicio_sesion sesion = new inicio_sesion();
        }

        private void StripMenuItemEstadisticasProductos_Click(object sender, EventArgs e)
        {
            AbrirFormulario<estadisticas_productos>("Hay un formulario activo en pantalla, ¿desea cerrar el anterior y abrir uno nuevo?");
        }

        private void ToolStripMenuEstadisticasVentas_Click(object sender, EventArgs e)
        {
            AbrirFormulario<estadisticas_ventas>("Hay un formulario activo en pantalla, ¿desea cerrar el anterior y abrir uno nuevo?");
        }

        private void StripMenuItemStock_Click(object sender, EventArgs e)
        {
            AbrirFormulario<estadisticas_stock>("Hay un formulario activo en pantalla, ¿desea cerrar el anterior y abrir uno nuevo?");
        }

        private void StripMenuItemCerrarPrograma_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StripMenuItemCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
            inicio_sesion sesion = new inicio_sesion();
        }
    }
}
