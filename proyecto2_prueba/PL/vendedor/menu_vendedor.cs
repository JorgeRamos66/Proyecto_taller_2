using System;
using System.Linq;
using System.Windows.Forms;
using BLL;
using ML;
using proyecto2_prueba.PL.vendedor;
using proyecto2_prueba.Presentaciones.admin;
using proyecto2_prueba.Presentaciones.vendedor;

namespace proyecto2_prueba
{
    public partial class menu_vendedor : Form
    {
        private readonly MenuVendedorBLL _menuVendedorBLL;

        public menu_vendedor()
        {
            InitializeComponent();
            _menuVendedorBLL = new MenuVendedorBLL();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            this.IsMdiContainer = true;
            LNombreUsuario.Text = $"{UsuarioSesion.Nombre} {UsuarioSesion.Apellido}";
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

        private void AbrirFormulario<T>(string mensaje) where T : Form, new()
        {
            Form formularioAbierto = this.MdiChildren.FirstOrDefault();

            if (formularioAbierto != null)
            {
                DialogResult resultado = MessageBox.Show(mensaje,
                                                         "Formulario en Uso",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    formularioAbierto.Close();

                    T nuevoFormulario = new T();
                    nuevoFormulario.MdiParent = this;
                    nuevoFormulario.Show();
                }
            }
            else
            {
                T nuevoFormulario = new T();
                nuevoFormulario.MdiParent = this;
                nuevoFormulario.Show();
            }
        }

        private void StripMenuItemClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario<menu_cliente>("Hay un formulario activo en pantalla. ¿desea cerrar el anterior y abrir uno nuevo?");
        }

        private void StripMenuItemCarrito_Click(object sender, EventArgs e)
        {
            AbrirFormulario<carrito>("Hay un formulario activo en pantalla. ¿desea cerrar el anterior y abrir uno nuevo?");
        }

        private void StripMenuItemMiHistorial_Click(object sender, EventArgs e)
        {
            AbrirFormulario<ventas>("Hay un formulario activo en pantalla. ¿Deseas cerrar el anterior y abrir uno nuevo?");
                
        }


        private void cerrarSesionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            _menuVendedorBLL.CerrarSesion(this);
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
                
        
                
    }
}