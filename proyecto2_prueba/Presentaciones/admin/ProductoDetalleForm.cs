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

            // Asigna la imagen al PictureBox
            pictureBoxProducto.Image = imagenProducto;

        }
    }
}
