using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto2_prueba.Presentaciones.admin
{
    public partial class personal : Form
    {
        public personal()
        {
            InitializeComponent();
        }

        private void BAgregarPersonal_Click(object sender, EventArgs e)
        {

            // Accedemos al formulario MDI principal (menu_admin)
            Form formularioMDI = this.MdiParent;

            // Verificamos si el formulario de alta_producto ya está abierto
            Form formularioAbierto = Application.OpenForms.OfType<registrar_personal>().FirstOrDefault();

            if (formularioAbierto != null)
            {
                // Si ya está abierto, mostramos un mensaje o no hacemos nada, según lo que quieras
                MessageBox.Show("El formulario de alta de producto ya está abierto.");
            }
            else
            {
                // Creamos una nueva instancia del formulario alta_producto
                registrar_personal nuevo_personal = new registrar_personal();

                // Establecemos el formulario MDI principal (menu_admin) como el padre
                //nuevo_producto.MdiParent = formularioMDI;

                //Mostramos el formulario de alta de producto de forma modal (por encima del principal)
                nuevo_personal.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
