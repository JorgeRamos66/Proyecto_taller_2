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
    public partial class niveles_clientes : Form
    {
        public niveles_clientes()
        {
            InitializeComponent();
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
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void BNuevoNivel_Click(object sender, EventArgs e)
        {
            //Generador de numero aleatorio para un ID aleatorio
            Random random = new Random();

            //Validacion de que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(textBoxNombreNivel.Text) ||
                string.IsNullOrWhiteSpace(textBoxDescripcionNivel.Text))
            {
                MessageBox.Show("Debe rellenar todos los campos para agregar una nueva categoría.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            //SE generar un id aleatorio
            int idCategoria = random.Next(1000, 9999);

            //Se extraen los datos de los textBox
            string nombreNivel = textBoxNombreNivel.Text;
            string descripcionNivel = textBoxDescripcionNivel.Text;
            decimal descuento = numericUpDownDescuento.Value;

            //Agregar una nueva fila al datagrid_categorias
            datagrid_niveles.Rows.Add(idCategoria, nombreNivel, descuento, descripcionNivel);

            //Mensaje de que el producto se ha agregado de forma exitosa.
            MessageBox.Show($"El nivel: '{nombreNivel}' se ha cargado correctamente.",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            //Limpiar los TextBox después de agregar la categoría
            textBoxNombreNivel.Clear();
            textBoxDescripcionNivel.Clear();
            numericUpDownDescuento.Value = 0;
        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
