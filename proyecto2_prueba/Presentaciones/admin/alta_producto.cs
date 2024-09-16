using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace proyecto2_prueba.Presentaciones.admin
{
    public partial class alta_producto : Form
    {
        private listado_productos_admin formularioListado;
        public alta_producto(listado_productos_admin listado)
        {
            InitializeComponent();
            CargarCategorias();
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

        private void CargarCategorias()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString; // Asegúrate de que 'MiCadenaDeConexion' está definido en tu archivo de configuración
            string query = "SELECT id_categoria, nombre_categoria FROM CATEGORIA";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    comboBoxCategoria.Items.Clear(); // Limpiar elementos existentes

                    while (reader.Read())
                    {
                        // Crear un objeto ComboBoxItem para almacenar el ID y el nombre
                        var item = new ComboBoxItem
                        {
                            Value = reader["id_categoria"].ToString(),
                            Text = reader["nombre_categoria"].ToString()
                        };
                        comboBoxCategoria.Items.Add(item);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar las categorías: " + ex.Message);
                }
            }
        }
        public class ComboBoxItem
        {
            public string Value { get; set; }
            public string Text { get; set; }

            public override string ToString()
            {
                return Text; // Esto es lo que se mostrará en el ComboBox
            }
        }

        private void B_agregarProducto_Click(object sender, EventArgs e)
        {
            // Obtener los valores del formulario
            string nombre = textBoxNombre.Text;
            string stockText = textBoxStock.Text;
            string precioText = textBoxPrecio.Text;
            string descripcion = textBoxDescripcion.Text;
            string rutaImagen = textBoxRutaFoto.Text; // Ruta de la imagen

            // Obtener el ID de la categoría seleccionada
            ComboBoxItem selectedItem = comboBoxCategoria.SelectedItem as ComboBoxItem;
            string categoriaId = selectedItem != null ? selectedItem.Value : string.Empty;

            // Validar los campos
            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(stockText) ||
                string.IsNullOrWhiteSpace(precioText) ||
                string.IsNullOrWhiteSpace(categoriaId) ||
                string.IsNullOrWhiteSpace(descripcion))
            {
                MessageBox.Show("Debe rellenar todos los campos para cargar el producto.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(stockText, out int stock))
            {
                MessageBox.Show("El campo de stock debe ser un número entero válido.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(precioText, out decimal precio))
            {
                MessageBox.Show("El campo de precio debe ser un número decimal válido.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(categoriaId, out int categoriaIdInt))
            {
                MessageBox.Show("El ID de la categoría no es válido.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // Cadena de conexión desde el archivo de configuración
            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Crear el comando SQL para insertar el producto
                    string query = @"
                    INSERT INTO PRODUCTO (nombre_producto, stock_producto, precio_producto, id_categoria, descripcion_producto, ruta_imagen) 
                    VALUES (@Nombre, @Stock, @Precio, @Categoria, @Descripcion, @RutaImagen);
                    SELECT SCOPE_IDENTITY();"; // Recuperar el ID del nuevo producto

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@Stock", stock);
                        command.Parameters.AddWithValue("@Precio", precio);
                        command.Parameters.AddWithValue("@Categoria", categoriaIdInt); // Asegúrate de que 'categoriaId' corresponda al ID de la categoría
                        command.Parameters.AddWithValue("@Descripcion", descripcion);
                        command.Parameters.AddWithValue("@RutaImagen", rutaImagen); // Agregar la ruta de la imagen

                        // Ejecutar el comando y obtener el ID generado
                        int idProducto = Convert.ToInt32(command.ExecuteScalar());

                        // Llamar al método para cargar el producto al DataGridView en listado_productos_admin
                        formularioListado.CargarProductos();

                        // Mensaje de éxito
                        MessageBox.Show($"El producto '{nombre}' se ha cargado correctamente.",
                                        "Éxito",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);

                        // Actualizar el DataGridView en listado_productos_admin
                        formularioListado.CargarProductos();

                        // Cerrar el formulario de alta de producto
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al agregar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                string filePath = openFileDialog.FileName;
                string fileName = System.IO.Path.GetFileName(filePath);

                // Ruta relativa desde el directorio bin\Debug
                string targetDirectory = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "imagenes_productos");
                string targetPath = System.IO.Path.Combine(targetDirectory, fileName);

                try
                {
                    // Asegurarse de que el directorio exista
                    if (!System.IO.Directory.Exists(targetDirectory))
                    {
                        System.IO.Directory.CreateDirectory(targetDirectory);
                    }

                    // Verificar si el archivo ya existe
                    if (System.IO.File.Exists(targetPath))
                    {
                        MessageBox.Show("El archivo ya existe. Por favor, elige otro archivo o renómbralo.",
                                        "Archivo Existente",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                        return;
                    }

                    // Copiar el archivo a la carpeta de recursos
                    System.IO.File.Copy(filePath, targetPath);

                    // Mostrar la ruta en el TextBox
                    textBoxRutaFoto.Text = System.IO.Path.Combine("Resources", "imagenes_productos", fileName);

                    // Mostrar la imagen en el PictureBox
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
