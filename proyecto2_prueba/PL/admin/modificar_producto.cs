using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using BLL;
using ML;
using System.Configuration;
using System.Data;

namespace proyecto2_prueba.Presentaciones.admin
{
    public partial class modificar_producto : Form
    {
        private ProductoBLL productoBLL = new ProductoBLL();
        private listado_productos_admin formularioListado;
        private string rutaImagen;
        private int idProducto;

        public modificar_producto(int idProducto, string nombre, int stock, decimal precio, 
                                int idCategoria, string descripcion, string rutaImagen, 
                                listado_productos_admin formularioListado)
        {
            InitializeComponent();
            this.idProducto = idProducto;
            this.formularioListado = formularioListado;
            this.rutaImagen = rutaImagen;

            CargarCategorias();
            InicializarCampos(nombre, stock, precio, idCategoria, descripcion, rutaImagen);
        }

        private void InicializarCampos(string nombre, int stock, decimal precio, int idCategoria, string descripcion, string rutaImagen)
        {
            textBoxNombre.Text = nombre;
            textBoxStock.Text = stock.ToString();
            textBoxPrecio.Text = precio.ToString();
            textBoxDescripcion.Text = descripcion;
            textBoxRutaFoto.Text = rutaImagen;

            // Seleccionar la categoría correspondiente
            foreach (DataRowView item in comboBoxCategoria.Items)
            {
                if (Convert.ToInt32(item["id_categoria"]) == idCategoria)
                {
                    comboBoxCategoria.SelectedItem = item;
                    break;
                }
            }

            // Cargar la imagen en el PictureBox
            string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\", rutaImagen);
            if (File.Exists(rutaCompleta))
            {
                pictureBoxProducto.Image = Image.FromFile(rutaCompleta);
            }
            else
            {
                MessageBox.Show("No se encontró la imagen del producto en la ruta especificada.");
            }
        }

        private void CargarCategorias()
        {
            try
            {
                comboBoxCategoria.DataSource = productoBLL.ObtenerCategorias();
                comboBoxCategoria.DisplayMember = "nombre_categoria";
                comboBoxCategoria.ValueMember = "id_categoria";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las categorías: " + ex.Message);
            }
        }

        private void textBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void textBoxPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void BModificarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones básicas
                if (string.IsNullOrWhiteSpace(textBoxNombre.Text) ||
                    string.IsNullOrWhiteSpace(textBoxStock.Text) ||
                    string.IsNullOrWhiteSpace(textBoxPrecio.Text) ||
                    string.IsNullOrWhiteSpace(textBoxDescripcion.Text) ||
                    string.IsNullOrWhiteSpace(textBoxRutaFoto.Text) ||
                    comboBoxCategoria.SelectedItem == null)
                {
                    MessageBox.Show("Debe rellenar todos los campos para modificar el producto.",
                                  "Advertencia",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    return;
                }

                Producto producto = new Producto
                {
                    IdProducto = this.idProducto,
                    NombreProducto = textBoxNombre.Text,
                    StockProducto = Convert.ToInt32(textBoxStock.Text),
                    PrecioProducto = Convert.ToDecimal(textBoxPrecio.Text),
                    DescripcionProducto = textBoxDescripcion.Text,
                    IdCategoria = Convert.ToInt32(comboBoxCategoria.SelectedValue),
                    RutaImagen = textBoxRutaFoto.Text
                };

                productoBLL.ModificarProducto(producto);
                MessageBox.Show($"El producto '{producto.NombreProducto}' se ha modificado correctamente.",
                              "Éxito",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);

                formularioListado.CargarProductos();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el producto: " + ex.Message,
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void BAgregarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openFileDialog.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|Todos los archivos (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(filePath);
                    string targetDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Resources\\imagenes_productos");
                    string targetPath = Path.Combine(targetDirectory, uniqueFileName);

                    if (!Directory.Exists(targetDirectory))
                    {
                        Directory.CreateDirectory(targetDirectory);
                    }

                    File.Copy(filePath, targetPath);
                    textBoxRutaFoto.Text = Path.Combine("Resources", "imagenes_productos", uniqueFileName);
                    pictureBoxProducto.Image = Image.FromFile(targetPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar la imagen: {ex.Message}",
                                  "Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }
        }

        private void BSalirModificacion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Clase auxiliar para el ComboBox
        public class ComboBoxItem
        {
            public string Value { get; set; }
            public string Text { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
    }
}
