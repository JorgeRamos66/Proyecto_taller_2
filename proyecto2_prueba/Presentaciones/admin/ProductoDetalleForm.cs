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

    public partial class ProductoDetalleForm : Form
    {
        public ProductoDetalleForm(Image imagenProducto)
        {
            InitializeComponent();

            // Asignar la imagen al PictureBox o control que usas para mostrar la imagen
            pictureBoxProducto.Image = imagenProducto;

            // Subscribirse al evento Deactivate para cerrar cuando se pierde el foco
            this.Deactivate += new EventHandler(Form_Deactivate);
        }

        // Evento que se dispara cuando el formulario pierde el foco
        private void Form_Deactivate(object sender, EventArgs e)
        {
            this.Close(); // Cerrar el formulario cuando pierde el foco
        }

        // Sobrescribir el evento de teclas para interceptar la tecla Esc
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close(); // Cerrar el formulario cuando se presiona Esc
                return true;  // Indicar que la tecla ha sido manejada
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }

}
