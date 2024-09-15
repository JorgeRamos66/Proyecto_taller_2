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
    public partial class alta_producto : Form
    {
        private listado_productos_admin formularioListado;
        public alta_producto(listado_productos_admin listado)
        {
            InitializeComponent();
            formularioListado = listado; // Guardar la referencia del formulario listado_productos_admin
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BSALIR_nuevoProducto_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LAgregarProducto_Click(object sender, EventArgs e)
        {

        }

        private void B_agregarProducto_Click(object sender, EventArgs e)
        {
            // Crear una instancia de la clase Random
            Random random = new Random();

            // Generar un número aleatorio positivo (por ejemplo, entre 1 y 10000)
            int idProducto = random.Next(1, 10001); // El rango va de 1 a 10000
            
            //Obtenenemos los datos ingresados por el usuario
            string nombre = textBoxNombre.Text;
            string stockText = textBoxStock.Text; //Se usa string temporalmente para validar
            string precioText = textBoxPrecio.Text; //Se usa string temporalmente para validar
            string categoria = comboBoxCategoria.SelectedItem != null ? comboBoxCategoria.SelectedItem.ToString() : string.Empty;
            string descripcion = textBoxDescripcion.Text;
            string rutaImagen = textBoxRutaFoto.Text;

            //Validamos los campos como Strings
            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(stockText) ||
                string.IsNullOrWhiteSpace(precioText) ||
                string.IsNullOrWhiteSpace(categoria) ||
                string.IsNullOrWhiteSpace(descripcion) ||
                string.IsNullOrWhiteSpace(rutaImagen))
            {
                MessageBox.Show("Debe rellenar todos los campos para cargar el producto.",
                 "Advertencia",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Warning);
                return; // Salir si no se han completado todos los campos
            }

            string categoriaSeleccionada = comboBoxCategoria.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(categoriaSeleccionada))
            {
                MessageBox.Show("Debe seleccionar una CATEGORIA para cargar el producto.",
                 "Advertencia",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Warning);
                return;
            }

            //Cargar la imagen desde la ruta
            Image imagenProducto;
            if (!string.IsNullOrEmpty(rutaImagen) && System.IO.File.Exists(rutaImagen))
            {
                imagenProducto = Image.FromFile(rutaImagen);
            }
            else
            {
                //Si la imagen no es válida
                MessageBox.Show("Ruta de imagen no válida.");
                return; // Detener la ejecución si la imagen no es válida
            }

            // Validación de formato correcto para stock y precio
            if (!int.TryParse(stockText, out int stock))
            {
                MessageBox.Show("El campo de stock debe ser un número entero válido.");
                return; // Salir si el stock no es válido
            }

            if (!decimal.TryParse(precioText, out decimal precio))
            {
                MessageBox.Show("El campo de precio debe ser un número decimal válido.");
                return; // Salir si el precio no es válido
            }

            // Llamar al método para agregar el producto al DataGridView en listado_productos_admin
            formularioListado.datagrid_productos.Rows.Add(idProducto, nombre, stock, precio, categoria, descripcion,rutaImagen, imagenProducto);

            //Mensaje de que el producto se ha agregado de forma exitosa.
            MessageBox.Show($"El producto '{nombre}' se ha cargado correctamente.",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Cerrar el formulario de alta de producto
            this.Close();
        }

        private void BAgregarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|Todos los archivos (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Obtener la ruta del archivo seleccionado
                string filePath = openFileDialog.FileName;

                // Mostrar la ruta en el TextBox
                textBoxRutaFoto.Text = filePath;

                // Mostrar la imagen en el PictureBox
                pictureBox1.Image = Image.FromFile(filePath);
            }
        }

        private void textBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir letras, números, espacios y caracteres de control (como la tecla de retroceso)
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla si no es una letra, número, espacio o carácter de control
            }
        }

        private void textBoxStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Cancela el evento si no es un número o la tecla de retroceso
            }
        }

        private void textBoxPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Cancela el evento si no es un número o la tecla de retroceso
            }
        }
    }
}
