﻿using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static proyecto2_prueba.Presentaciones.vendedor.carrito;

namespace proyecto2_prueba.Presentaciones.admin
{
    public partial class modificar_producto : Form
    {
        //Referencia al formulario principal
        private listado_productos_admin formularioListado;
        private string rutaImagen;
        private int idProducto;

        //Se pasa como referencia el formulario listado de productos
        public modificar_producto(int idProducto, string nombre, int stock, decimal precio, int idCategoria, string descripcion, string rutaImagen, listado_productos_admin formularioListado)
        {
            InitializeComponent();
            this.idProducto = idProducto; // Almacenar el ID del producto en el campo privado
            this.formularioListado = formularioListado;
            this.rutaImagen = rutaImagen; // Asigna la ruta de imagen recibida

            // Llama a un método para inicializar los valores de los controles
            CargarCategorias(); // Llenar las categorías en el ComboBox
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
            foreach (ComboBoxItem item in comboBoxCategoria.Items)
            {
                if (item.Value == idCategoria.ToString())
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
            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;
            string query = "SELECT id_categoria, nombre_categoria FROM CATEGORIA WHERE estado_categoria = 1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    comboBoxCategoria.Items.Clear(); // Limpiar los elementos existentes

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

                    // Configurar el valor seleccionado
                    comboBoxCategoria.DisplayMember = "Text";
                    comboBoxCategoria.ValueMember = "Value";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar las categorías: " + ex.Message);
                }
            }
        }

        // Clase auxiliar para manejar las categorías en el ComboBox
        public class ComboBoxItem
        {
            public string Value { get; set; }
            public string Text { get; set; }

            public override string ToString()
            {
                return Text; // Esto es lo que se mostrará en el ComboBox
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


        //Al presionar el boton de modificar producto se realiza la modificacion.
        private void BModificarProducto_Click(object sender, EventArgs e)
        {
            // OBTENCION DE LOS DATOS DEL FORMULARIO
            string nombre = textBoxNombre.Text;
            string stockText = textBoxStock.Text;
            string precioText = textBoxPrecio.Text;
            string categoria = comboBoxCategoria.SelectedItem != null ? comboBoxCategoria.SelectedItem.ToString() : string.Empty;
            string descripcion = textBoxDescripcion.Text;
            string rutaImagen = textBoxRutaFoto.Text;

            // VALIDACIONES
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
                return;
            }

            // Validación de imagen
            string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\", rutaImagen);
            if (!File.Exists(rutaCompleta))
            {
                MessageBox.Show("Ruta de imagen no válida.");
                return;
            }

            // Validación de stock y precio
            if (!int.TryParse(stockText, out int stock))
            {
                MessageBox.Show("El campo de stock debe ser un número entero válido.");
                return;
            }

            if (!decimal.TryParse(precioText, out decimal precio))
            {
                MessageBox.Show("El campo de precio debe ser un número decimal válido.");
                return;
            }

            // Obtener cadena de conexión desde el archivo config
            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;

            int idCategoriaSeleccionada = 0;

            // 1. Validar si la categoría seleccionada existe en la tabla CATEGORIA
            string queryCategoria = "SELECT id_categoria FROM CATEGORIA WHERE nombre_categoria = @categoria AND estado_categoria = 1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(queryCategoria, connection))
                    {
                        cmd.Parameters.AddWithValue("@categoria", categoria);

                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            idCategoriaSeleccionada = Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("La categoría seleccionada no existe o está inactiva.");
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar la categoría: " + ex.Message);
                    return;
                }
            }

            // 2. Realizar la actualización en la tabla PRODUCTO
            string queryUpdateProducto = "UPDATE PRODUCTO " +
                                         "SET nombre_producto = @nombre, " +
                                         "precio_producto = @precio, " +
                                         "descripcion_producto = @descripcion, " +
                                         "stock_producto = @stock, " +
                                         "id_categoria = @idCategoria, " +
                                         "ruta_imagen = @rutaImagen " +
                                         "WHERE id_producto = @idProducto";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(queryUpdateProducto, connection))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@precio", precio);
                        cmd.Parameters.AddWithValue("@descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@stock", stock);
                        cmd.Parameters.AddWithValue("@idCategoria", idCategoriaSeleccionada);
                        cmd.Parameters.AddWithValue("@rutaImagen", rutaImagen);
                        cmd.Parameters.AddWithValue("@idProducto", this.idProducto);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"El producto '{nombre}' se ha modificado correctamente.",
                                             "Éxito",
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo modificar el producto. Asegúrate de que el producto exista en la base de datos.",
                                             "Error",
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar el producto: " + ex.Message,
                                     "Error",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);
                }
            }

            // Cerrar el formulario de modificación
            this.Close();
        }



        private void BAgregarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures); // Carpeta de imágenes del usuario
            openFileDialog.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|Todos los archivos (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Generar un nombre único aleatorio para la imagen
                string uniqueFileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(filePath);

                // Ruta relativa donde se copiará la imagen
                string targetDirectory = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Resources\\imagenes_productos");
                string targetPath = System.IO.Path.Combine(targetDirectory, uniqueFileName);

                try
                {
                    // Crear el directorio si no existe
                    if (!System.IO.Directory.Exists(targetDirectory))
                    {
                        System.IO.Directory.CreateDirectory(targetDirectory);
                    }

                    // Copiar el archivo al directorio de recursos
                    System.IO.File.Copy(filePath, targetPath);

                    // Mostrar la ruta relativa en el TextBox
                    textBoxRutaFoto.Text = System.IO.Path.Combine("Resources", "imagenes_productos", uniqueFileName);

                    // Mostrar la imagen en el PictureBox
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
    }
}
