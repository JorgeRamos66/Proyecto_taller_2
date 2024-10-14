using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto2_prueba.Presentaciones.admin
{
    public partial class listado_productos_admin : Form
    {
        public listado_productos_admin()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            CargarProductos();
            datagrid_productos.CellFormatting += datagrid_productos_CellFormatting;
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


        private void BAltaProducto_Click(object sender, EventArgs e)
        {
            
            // Accedemos al formulario MDI principal (menu_admin)
            Form formularioMDI = this.MdiParent;

            // Verificamos si el formulario de alta_producto ya está abierto
            Form formularioAbierto = Application.OpenForms.OfType<alta_producto>().FirstOrDefault();

            if (formularioAbierto != null)
            {
                // Si ya está abierto, mostramos un mensaje o no hacemos nada, según lo que quieras
                MessageBox.Show("El formulario de alta de producto ya está abierto.");
            }
            else
            {
                // Creamos una nueva instancia del formulario alta_producto
                alta_producto nuevo_producto = new alta_producto(this);

                // Establecemos el formulario MDI principal (menu_admin) como el padre
                //nuevo_producto.MdiParent = formularioMDI;

                //Mostramos el formulario de alta de producto de forma modal (por encima del principal)
                nuevo_producto.ShowDialog();
            }
        }

        private bool TestConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true; // Conexión exitosa
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false; // Conexión fallida
                }
            }
        }


        private void BSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BBuscarProducto_Click(object sender, EventArgs e)
        {
            // Obtener el texto que se está buscando
            string textoBusqueda = textBoxBusqueda.Text.ToLower();

            // Verificar si el texto de búsqueda no está vacío
            if (!string.IsNullOrEmpty(textoBusqueda))
            {
                // Variable para controlar si se encontraron coincidencias
                bool algunaFilaVisible = false;

                // Desactivar temporalmente el CurrencyManager
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[datagrid_productos.DataSource];
                currencyManager.SuspendBinding();

                // Iterar sobre las filas del DataGridView
                foreach (DataGridViewRow fila in datagrid_productos.Rows)
                {
                    // Obtener los valores de las columnas relevantes y convertir a minúsculas
                    string nombreProducto = fila.Cells["CNombreProducto"].Value?.ToString().ToLower();
                    string descripcionProducto = fila.Cells["CDescripcion"].Value?.ToString().ToLower();
                    string stockProducto = fila.Cells["CStockProducto"].Value?.ToString().ToLower();
                    string precioProducto = fila.Cells["CPrecio"].Value?.ToString().ToLower();

                    // Obtener el ID de la categoría desde el DataGridView (almacena el número)
                    string idCategoria = fila.Cells["CCategoriaProducto"].Value?.ToString();

                    string categoriaProducto = null; // Inicializa la variable para almacenar el nombre de la categoría

                    // Verificar si hay un ID de categoría válido
                    if (!string.IsNullOrEmpty(idCategoria))
                    {
                        // Realizar una consulta a la base de datos para obtener el nombre de la categoría
                        string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            try
                            {
                                connection.Open();
                                string query = "SELECT nombre_categoria FROM CATEGORIA WHERE id_categoria = @IdCategoria";
                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@IdCategoria", Convert.ToInt32(idCategoria));
                                    object resultado = command.ExecuteScalar();

                                    // Asigna el nombre de la categoría si se encuentra en la base de datos
                                    if (resultado != null)
                                    {
                                        categoriaProducto = resultado.ToString().ToLower();
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error al obtener el nombre de la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    // Verificar si alguna de las columnas coincide con el texto de búsqueda
                    if ((nombreProducto != null && nombreProducto.Contains(textoBusqueda))
                        || (descripcionProducto != null && descripcionProducto.Contains(textoBusqueda))
                        || (stockProducto != null && stockProducto.Contains(textoBusqueda))
                        || (precioProducto != null && precioProducto.Contains(textoBusqueda))
                        || (categoriaProducto != null && categoriaProducto.Contains(textoBusqueda)))
                    {
                        fila.Visible = true; // Mostrar fila si coincide
                        algunaFilaVisible = true; // Se encontró al menos una coincidencia
                    }
                    else
                    {
                        fila.Visible = false; // Ocultar fila si no coincide
                    }
                }

                // Reactivar el CurrencyManager
                currencyManager.ResumeBinding();

                // Si no se encontró ninguna fila visible, mostrar un mensaje
                if (!algunaFilaVisible)
                {
                    MessageBox.Show("No se encontraron coincidencias.");
                }
            }
            else
            {
                // Si el cuadro de búsqueda está vacío, mostrar todas las filas
                foreach (DataGridViewRow fila in datagrid_productos.Rows)
                {
                    fila.Visible = true;
                }
            }
        }

        private void ButtonLimpiar_Click(object sender, EventArgs e)
        {
            // Limpiar el contenido del textBox de búsqueda
            textBoxBusqueda.Clear();

            // Opcional: mostrar todas las filas nuevamente
            foreach (DataGridViewRow fila in datagrid_productos.Rows)
            {
                fila.Visible = true;
            }
        }

        public void CargarProductos()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                SELECT p.id_producto, p.nombre_producto, p.stock_producto, p.precio_producto, 
                       p.id_categoria, p.descripcion_producto, p.ruta_imagen, p.baja_producto 
                FROM PRODUCTO p
                INNER JOIN CATEGORIA c ON p.id_categoria = c.id_categoria
                WHERE c.estado_categoria = 1"; // Solo productos de categorías activas
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        // Asignar el DataTable como DataSource del DataGridView
                        datagrid_productos.DataSource = dataTable;

                        // Cargar las imágenes en la columna CImagenProducto
                        CargarImagenes(dataTable); // Llamar al nuevo método para cargar imágenes

                        // Ocultar las columnas id_producto y ruta_imagen
                        datagrid_productos.Columns["CIdProducto"].Visible = false; // Ocultar ID Producto
                        datagrid_productos.Columns["ruta_imagen"].Visible = false; // Ocultar Ruta Imagen
                    }
                }
                catch (Exception ex)
                {
                    // Muestra el mensaje de error completo en la consola o en un cuadro de mensaje
                    Console.WriteLine(ex.Message); // Para ver en la consola
                    MessageBox.Show($"Error al cargar los productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarImagenes(DataTable dataTable)
        {
            // Asegúrate de que la columna de imágenes existe
            if (!dataTable.Columns.Contains("Imagen"))
            {
                // Agrega la columna para las imágenes si no existe
                dataTable.Columns.Add("Imagen", typeof(Image));
            }

            foreach (DataRow row in dataTable.Rows)
            {
                string rutaImagen = row["ruta_imagen"].ToString();
                string rutaCompleta = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\", rutaImagen);

                if (File.Exists(rutaCompleta))
                {
                    // Convertir la imagen a un objeto Image y asignarla a la columna de imagen
                    row["Imagen"] = Image.FromFile(rutaCompleta);
                }
                else
                {
                    // Asignar una imagen predeterminada o null si no se encuentra
                    row["Imagen"] = null; // O asigna Image.FromFile("ruta_a_imagen_predeterminada");
                }
            }
        }

        
        private void ConfigurarDataGridView()
        {
            // Limpiar columnas existentes
            datagrid_productos.Columns.Clear();

            // Configurar propiedades del DataGridView
            datagrid_productos.AllowUserToAddRows = false;
            datagrid_productos.AllowUserToDeleteRows = false;
            datagrid_productos.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            datagrid_productos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            datagrid_productos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            datagrid_productos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            datagrid_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datagrid_productos.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            datagrid_productos.Location = new System.Drawing.Point(31, 126);
            datagrid_productos.Name = "datagrid_productos";
            datagrid_productos.ReadOnly = true;
            datagrid_productos.RowTemplate.Height = 50;
            datagrid_productos.Size = new System.Drawing.Size(1244, 393);
            datagrid_productos.TabIndex = 0;
            datagrid_productos.CellClick -= datagrid_productos_CellClick;
            datagrid_productos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_productos_CellClick);

            // Definir columnas (sin "ID Producto" y "Ruta Imagen")
            datagrid_productos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CIdProducto",
                HeaderText = "ID Producto",
                DataPropertyName = "id_producto" // Nombre de la columna en la base de datos
            });

            datagrid_productos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CNombreProducto",
                HeaderText = "Nombre",
                DataPropertyName = "nombre_producto"
            });

            datagrid_productos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CStockProducto",
                HeaderText = "Stock",
                DataPropertyName = "stock_producto"
            });

            datagrid_productos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CPrecio",
                HeaderText = "Precio",
                DataPropertyName = "precio_producto"
            });

            datagrid_productos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CCategoriaProducto",
                HeaderText = "Categoría",
                DataPropertyName = "id_categoria"
            });

            datagrid_productos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CDescripcion",
                HeaderText = "Descripción",
                DataPropertyName = "descripcion_producto"
            });

            // Botón Modificar (Color Amarillo)
            var modificarButtonColumn = new DataGridViewButtonColumn
            {
                Name = "CModificar",
                HeaderText = "Modificar",
                Text = "Modificar",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Popup,
            };
            datagrid_productos.Columns.Add(modificarButtonColumn);

            // Botón Estado (Color Rojo o Verde según el estado)
            var estadoButtonColumn = new DataGridViewButtonColumn
            {
                Name = "CEstado",
                HeaderText = "Estado",
                Text = "Eliminar", // Se cambiará dinámicamente a "Activar" según el estado del producto
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Popup,
            };
            datagrid_productos.Columns.Add(estadoButtonColumn);

            datagrid_productos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CBaja",
                HeaderText = "Eliminado?",
                DataPropertyName = "baja_producto"
            });


            // Formateo del datagrid
            datagrid_productos.CellFormatting += new DataGridViewCellFormattingEventHandler(datagrid_productos_CellFormatting);
        }

        private void datagrid_productos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verifica si la columna es la de la categoría
            if (datagrid_productos.Columns[e.ColumnIndex].Name == "CCategoriaProducto")
            {
                // Verifica que el valor de la celda no sea nulo o DBNull antes de intentar convertirlo
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    try
                    {
                        // Intenta convertir el valor de la celda a un entero
                        if (int.TryParse(e.Value.ToString(), out int idCategoria))
                        {
                            // Conectar a la base de datos para obtener el nombre de la categoría
                            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;
                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();
                                string selectQuery = "SELECT nombre_categoria FROM CATEGORIA WHERE id_categoria = @IdCategoria";

                                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                                {
                                    command.Parameters.AddWithValue("@IdCategoria", idCategoria);

                                    // Ejecutar la consulta y obtener el nombre de la categoría
                                    object result = command.ExecuteScalar();
                                    if (result != null)
                                    {
                                        e.Value = result.ToString(); // Cambia el valor por el nombre de la categoría
                                        e.FormattingApplied = true; // Evita que el valor predeterminado se siga mostrando
                                    }
                                }
                            }
                        }
                        else
                        {
                            // Si la conversión falla, se puede manejar aquí (p.ej., establecer un valor predeterminado)
                            e.FormattingApplied = false; // No aplicar formateo
                        }
                    }
                    catch (Exception ex)
                    {
                        // Si ocurre un error, manejarlo y no aplicar el formateo
                        MessageBox.Show($"Error al obtener el nombre de la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.FormattingApplied = false;
                    }
                }
            }

            // Verifica si la columna es la de baja_producto
            if (datagrid_productos.Columns[e.ColumnIndex].Name == "CBaja")
            {
                // Verifica que el valor de la celda no sea nulo o DBNull
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    // Verifica si el valor es del tipo correcto antes de convertir
                    if (e.Value is int bajaValue)
                    {
                        // Cambia el valor a "Sí" o "No" según el estado
                        e.Value = bajaValue == 1 ? "No" : "Si";
                        e.FormattingApplied = true; // Evita que el valor predeterminado se siga mostrando
                    }
                    else
                    {
                        // Si el valor no es un entero, podrías manejarlo como desees
                        e.FormattingApplied = false; // No aplicar formateo
                    }
                }
            }

            // Verifica si la columna es la de "CEstado"
            if (datagrid_productos.Columns[e.ColumnIndex].Name == "CEstado")
            {
                // Verifica que el valor de la celda no sea nulo o DBNull
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    try
                    {
                        // Obtén el ID del producto de la fila actual
                        int idProducto = Convert.ToInt32(datagrid_productos.Rows[e.RowIndex].Cells["CIdProducto"].Value);

                        // Conectar a la base de datos para obtener el estado del producto
                        string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string selectQuery = "SELECT baja_producto FROM PRODUCTO WHERE id_producto = @IdProducto";

                            using (SqlCommand command = new SqlCommand(selectQuery, connection))
                            {
                                command.Parameters.AddWithValue("@IdProducto", idProducto);

                                // Ejecutar la consulta y obtener el estado del producto
                                object result = command.ExecuteScalar();
                                if (result != null)
                                {
                                    int estado = Convert.ToInt32(result);

                                    // Si el estado es 0, significa que está inactivo (baja), entonces mostramos "Activar"
                                    // Si el estado es 1, está activo, entonces mostramos "Eliminar"
                                    if (estado == 0) // Producto eliminado
                                    {
                                        e.Value = "Activar";
                                        e.CellStyle.BackColor = Color.LightBlue; // Cambia el color de fondo
                                        e.CellStyle.ForeColor = Color.Black; // Cambia el color del texto
                                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centra el texto
                                    }
                                    else
                                    {
                                        e.Value = "Eliminar";
                                        e.CellStyle.BackColor = Color.Red; // Cambia el color de fondo
                                        e.CellStyle.ForeColor = Color.White; // Cambia el color del texto
                                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centra el texto
                                    }

                                    // Indica que el formateo ha sido aplicado
                                    e.FormattingApplied = true;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Si ocurre un error, manejarlo y no aplicar el formateo
                        MessageBox.Show($"Error al obtener el estado del producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.FormattingApplied = false;
                    }
                }
            }
            // Cambiar color del botón Modificar a amarillo
            if (datagrid_productos.Columns[e.ColumnIndex].Name == "CModificar")
            {
                e.CellStyle.BackColor = Color.Green; // Cambia el color de fondo
                e.CellStyle.ForeColor = Color.White; // Cambia el color del texto
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centra el texto
                e.FormattingApplied = true;
            }

            // Cambiar el fondo de la fila si el producto está eliminado
            if (Convert.ToInt32(datagrid_productos.Rows[e.RowIndex].Cells["CBaja"].Value) == 0)
            {
                datagrid_productos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkGray;
            }

        }

        private void ModificarEstadoProducto(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta para obtener el estado actual del producto
                    string selectQuery = "SELECT baja_producto FROM PRODUCTO WHERE id_producto = @Id";
                    using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@Id", id);

                        // Ejecutar el comando y verificar si se obtuvo un resultado
                        object result = selectCommand.ExecuteScalar();
                        if (result == null)
                        {
                            MessageBox.Show("No se encontró el producto con el ID especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Salir si no hay resultado
                        }

                        int estadoActual = Convert.ToInt32(result);

                        // Alterna el estado: si está activo (0), lo inactivamos (1); si está inactivo, lo activamos
                        string updateQuery;
                        if (estadoActual == 0)
                        {
                            updateQuery = "UPDATE PRODUCTO SET baja_producto = 1 WHERE id_producto = @Id";
                        }
                        else
                        {
                            updateQuery = "UPDATE PRODUCTO SET baja_producto = 0 WHERE id_producto = @Id";
                        }

                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@Id", id);

                            // Ejecuta la actualización
                            int rowsAffected = updateCommand.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Estado del producto actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No se pudo actualizar el estado del producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                // Actualiza el DataGridView después de cambiar el estado
                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el estado del producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void datagrid_productos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que no se está haciendo clic en el encabezado
            if (e.RowIndex >= 0)
            {
                // Si se hace clic en la columna de descripción o imagen
                if (datagrid_productos.Columns[e.ColumnIndex].Name == "Imagen")
                {

                    // Obtener la imagen del producto
                    Image imagenProducto = null;
                    if (datagrid_productos.Rows[e.RowIndex].Cells["Imagen"].Value != DBNull.Value)
                    {
                        imagenProducto = (Image)datagrid_productos.Rows[e.RowIndex].Cells["Imagen"].Value;
                    }

                    // Crear una instancia del formulario de detalles
                    ProductoDetalleForm detalleForm = new ProductoDetalleForm(imagenProducto);

                    // Mostrar el formulario como ventana modal
                    detalleForm.ShowDialog();
                }
            }
            
            // Verifica si la celda clicada es válida
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Si se hace clic en la columna de descripción o imagen
                if (datagrid_productos.Columns[e.ColumnIndex].Name == "CDescripcion")
                {
                    // Obtener la información del producto de la fila seleccionada
                    string descripcion = datagrid_productos.Rows[e.RowIndex].Cells["CDescripcion"].Value.ToString();
                    string nombreProducto = datagrid_productos.Rows[e.RowIndex].Cells["CNombreProducto"].Value.ToString();

                    // Mostrar un MessageBox con la información
                    MessageBox.Show($"Producto: {nombreProducto}\nDescripción: {descripcion}", "Detalles del Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // Verifica si la columna es un botón
                if (datagrid_productos.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    // Verifica si se ha hecho clic en la columna de estado
                    if (datagrid_productos.Columns[e.ColumnIndex].Name == "CEstado")
                    {
                        // Obtiene el ID del producto de la celda correspondiente
                        object cellValue = datagrid_productos.Rows[e.RowIndex].Cells["CIdProducto"].Value;

                        if (cellValue != null && int.TryParse(cellValue.ToString(), out int idProducto))
                        {
                            try
                            {
                                // Modifica el estado del producto 
                                ModificarEstadoProducto(idProducto);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error al eliminar el producto: {ex.Message}",
                                                "Error",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se pudo determinar el ID del producto.",
                                            "Error",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        }
                    }
                    // Si se hizo clic en la columna "Modificar"
                    if (datagrid_productos.Columns[e.ColumnIndex].Name == "CModificar")
                    {
                        // Obtener el ID del producto de la fila seleccionada
                        object cellValue = datagrid_productos.Rows[e.RowIndex].Cells["CIdProducto"].Value;

                        if (cellValue != null && int.TryParse(cellValue.ToString(), out int idProducto))
                        {
                            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;

                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();

                                // Consulta para obtener los detalles del producto
                                string query = "SELECT nombre_producto, stock_producto, precio_producto, id_categoria, descripcion_producto, ruta_imagen FROM PRODUCTO WHERE id_producto = @IdProducto";
                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@IdProducto", idProducto);

                                    using (SqlDataReader reader = command.ExecuteReader())
                                    {
                                        if (reader.Read()) // Verifica si se encontró el producto
                                        {
                                            // Obtener los datos del producto
                                            string nombre = reader["nombre_producto"].ToString();
                                            int stock = Convert.ToInt32(reader["stock_producto"]);
                                            decimal precio = Convert.ToDecimal(reader["precio_producto"]);
                                            int idCategoria = Convert.ToInt32(reader["id_categoria"]);
                                            string descripcion = reader["descripcion_producto"].ToString();
                                            string rutaImagen = reader["ruta_imagen"]?.ToString(); // Ruta de la imagen

                                            // Abrir el formulario de alta_producto con los datos cargados
                                            alta_producto modificarProducto = new alta_producto(idProducto, nombre, stock, precio, idCategoria, descripcion, rutaImagen, this);
                                            modificarProducto.ShowDialog();
                                        }
                                        else
                                        {
                                            MessageBox.Show("No se encontró el producto seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.pRODUCTOTableAdapter.FillBy(this.proyecto_Taller_2DataSet.PRODUCTO);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
