using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Data;
using BLL;
using ML;

namespace proyecto2_prueba.Presentaciones.admin
{
    public partial class alta_producto : Form
    {
        private ProductoBLL productoBLL = new ProductoBLL();
        private listado_productos_admin formularioListado;
        private int IdProducto;

        public alta_producto(listado_productos_admin listado)
        {
            InitializeComponent();
            CargarCategorias();
            formularioListado = listado;
            IdProducto = 0;
        }

        public alta_producto(int idProducto, string nombre, int stock, decimal precio, 
                           int idCategoria, string descripcion, string rutaImagen, 
                           listado_productos_admin listado)
        {
            InitializeComponent();
            CargarCategorias();
            formularioListado = listado;
            IdProducto = idProducto;

            textBoxNombre.Text = nombre;
            textBoxStock.Text = stock.ToString();
            textBoxPrecio.Text = precio.ToString();
            comboBoxCategoria.SelectedValue = idCategoria;
            textBoxDescripcion.Text = descripcion;
            textBoxRutaFoto.Text = rutaImagen;

            if (!string.IsNullOrEmpty(rutaImagen))
            {
                string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\", rutaImagen);
                if (File.Exists(rutaCompleta))
                {
                    pictureBox1.Image = Image.FromFile(rutaCompleta);
                }
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

        private void B_agregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones de interfaz
                if (string.IsNullOrWhiteSpace(textBoxNombre.Text) ||
                    string.IsNullOrWhiteSpace(textBoxStock.Text) ||
                    string.IsNullOrWhiteSpace(textBoxPrecio.Text) ||
                    string.IsNullOrWhiteSpace(textBoxDescripcion.Text) ||
                    string.IsNullOrWhiteSpace(textBoxRutaFoto.Text) ||
                    comboBoxCategoria.SelectedItem == null)
                {
                    MessageBox.Show("Debe rellenar todos los campos para continuar.",
                                  "Advertencia",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    return;
                }

                Producto producto = new Producto
                {
                    IdProducto = this.IdProducto,
                    NombreProducto = textBoxNombre.Text,
                    StockProducto = Convert.ToInt32(textBoxStock.Text),
                    PrecioProducto = Convert.ToDecimal(textBoxPrecio.Text),
                    IdCategoria = Convert.ToInt32(((DataRowView)comboBoxCategoria.SelectedItem)["id_categoria"]),
                    DescripcionProducto = textBoxDescripcion.Text,
                    RutaImagen = textBoxRutaFoto.Text
                };

                if (IdProducto == 0)
                {
                    productoBLL.InsertarProducto(producto);
                    MessageBox.Show($"El producto '{producto.NombreProducto}' se ha agregado correctamente.",
                                  "Éxito",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
                else
                {
                    productoBLL.ActualizarProducto(producto);
                    MessageBox.Show($"El producto '{producto.NombreProducto}' se ha actualizado correctamente.",
                                  "Éxito",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }

                formularioListado.CargarProductos();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void BAgregarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|Todos los archivos (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

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
                    pictureBox1.Image = Image.FromFile(targetPath);
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

            if (e.KeyChar == '.' && textBoxPrecio.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void BSALIR_nuevoProducto_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}