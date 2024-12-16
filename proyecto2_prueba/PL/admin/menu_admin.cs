using System;
using System.Linq;
using System.Windows.Forms;
using ML;
using BLL;
using proyecto2_prueba.Presentaciones.admin;

namespace proyecto2_prueba
{
    public partial class menu_admin : Form
    {
        private readonly BackupService _backupService;

        public menu_admin()
        {
            InitializeComponent();
            _backupService = new BackupService();

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

        private void cerrarProgramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            inicio_sesion sesion = new inicio_sesion();
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aBMEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<personal>("Hay un formulario activo en pantalla, ¿desea cerrar el anterior y abrir uno nuevo?");
        }

        private void aBMProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<listado_productos_admin>("Hay un formulario activo en pantalla, ¿desea cerrar el anterior y abrir uno nuevo?");
        }

        private void aBMCategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<categorias_productos>("Hay un formulario activo en pantalla, ¿desea cerrar el anterior y abrir uno nuevo?");
        }

        private void aBMNivelesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<niveles_clientes>("Hay un formulario activo en pantalla, ¿desea cerrar el anterior y abrir uno nuevo?");
        }

        private void realizarBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _backupService.EjecutarBackup();
        }

        private void restaurarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _backupService.EjecutarRestauracion();
        }
    }
}