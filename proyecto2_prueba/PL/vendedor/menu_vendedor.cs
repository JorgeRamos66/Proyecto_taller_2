using System;
using System.Windows.Forms;
using BLL;
using ML;
using proyecto2_prueba.PL.vendedor;
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

        private void StripMenuItemClientes_Click(object sender, EventArgs e)
        {
            _menuVendedorBLL.AbrirFormulario<menu_cliente>(this,
                "El formulario de clientes ya está abierto. ¿Deseas cerrar el anterior y abrir uno nuevo?");
        }

        private void StripMenuItemCarrito_Click(object sender, EventArgs e)
        {
            _menuVendedorBLL.AbrirFormulario<carrito>(this,
                "El carrito ya está abierto. ¿Deseas cerrar el anterior y abrir uno nuevo?");
        }

        private void StripMenuItemMiHistorial_Click(object sender, EventArgs e)
        {
            _menuVendedorBLL.AbrirFormulario<ventas>(this,
                "El historial ya está abierto. ¿Deseas cerrar el anterior y abrir uno nuevo?");
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