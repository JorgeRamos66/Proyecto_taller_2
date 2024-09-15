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
    public partial class categorias_productos : Form
    {
        public categorias_productos()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BNuevaCategoria_Click(object sender, EventArgs e)
        {
            //Generador de numero aleatorio para un ID aleatorio
            Random random = new Random();

            //Validacion de que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(textBoxNombreCategoria.Text) ||
                string.IsNullOrWhiteSpace(textBoxDescripcionCategoria.Text))
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
            string nombreCategoria = textBoxNombreCategoria.Text;
            string descripcionCategoria = textBoxDescripcionCategoria.Text;

            //Agregar una nueva fila al datagrid_categorias
            datagrid_categorias.Rows.Add(idCategoria, nombreCategoria, descripcionCategoria);

            //Limpiar los TextBox después de agregar la categoría
            textBoxNombreCategoria.Clear();
            textBoxDescripcionCategoria.Clear();
        }

        private void textBoxNombreCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir letras, números, espacios y caracteres de control (como la tecla de retroceso)
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla si no es una letra, número, espacio o carácter de control
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void datagrid_categorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == datagrid_categorias.Columns["CBaja"].Index && e.RowIndex >= 0)
            {
                // Eliminar la fila correspondiente
                datagrid_categorias.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
}
