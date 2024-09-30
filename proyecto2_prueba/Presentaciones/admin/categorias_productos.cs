using System;
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
    public partial class categorias_productos : Form
    {
        public categorias_productos()
        {
            InitializeComponent();
            ConfigurarDataGridViewCategorias();
            CargarCategorias();
            datagrid_categorias.CellFormatting += datagrid_categorias_CellFormatting;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void BNuevaCategoria_Click(object sender, EventArgs e)
        {
            // Validación de que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(textBoxNombreCategoria.Text) ||
                string.IsNullOrWhiteSpace(textBoxDescripcionCategoria.Text))
            {
                MessageBox.Show("Debe rellenar todos los campos para agregar o modificar una categoría.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // Se extraen los datos de los TextBox
            string nombreCategoria = textBoxNombreCategoria.Text;
            string descripcionCategoria = textBoxDescripcionCategoria.Text;

            // Verificar si hay un ID de categoría en el textBoxIDcategoria
            if (int.TryParse(textBoxIDcategoria.Text, out int idCategoria) && idCategoria > 0) // Validar que el ID sea un número y mayor que 0
            {
                // Si hay un ID válido, se actualiza la categoría existente
                ActualizarCategoria(idCategoria, nombreCategoria, descripcionCategoria);
            }
            else // Si no hay un ID, se agrega una nueva categoría
            {
                // Llamar al método para agregar la nueva categoría a la base de datos
                AgregarNuevaCategoria(nombreCategoria, descripcionCategoria);
            }

            // Limpiar los TextBox después de agregar o modificar la categoría
            textBoxIDcategoria.Clear();
            textBoxNombreCategoria.Clear();
            textBoxDescripcionCategoria.Clear();

            // Actualizar el DataGridView
            CargarCategorias(); // Llama a este método para recargar la lista de categorías
        }

        private void ActualizarCategoria(int idCategoria, string nombreCategoria, string descripcionCategoria)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta para actualizar la categoría existente
                    string query = "UPDATE CATEGORIA SET nombre_categoria = @Nombre, descripcion_categoria = @Descripcion WHERE id_categoria = @Id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", nombreCategoria);
                        command.Parameters.AddWithValue("@Descripcion", descripcionCategoria);
                        command.Parameters.AddWithValue("@Id", idCategoria);

                        // Ejecutar el comando de actualización
                        command.ExecuteNonQuery();

                        MessageBox.Show("Categoría actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarNuevaCategoria(string nombreCategoria, string descripcionCategoria)
        {
            // Validar los campos
            if (string.IsNullOrWhiteSpace(nombreCategoria) || string.IsNullOrWhiteSpace(descripcionCategoria))
            {
                MessageBox.Show("Debe rellenar todos los campos para agregar la categoría.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // Cadena de conexión desde el archivo de configuración
            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta para insertar la nueva categoría
                    string query = "INSERT INTO CATEGORIA (nombre_categoria, descripcion_categoria) VALUES (@Nombre, @Descripcion)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", nombreCategoria);
                        command.Parameters.AddWithValue("@Descripcion", descripcionCategoria);

                        // Ejecutar el comando de inserción
                        command.ExecuteNonQuery();

                        MessageBox.Show("Categoría agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ConfigurarDataGridViewCategorias()
        {
            // Limpiar columnas existentes
            datagrid_categorias.Columns.Clear();

            // Configurar propiedades del DataGridView
            datagrid_categorias.AllowUserToAddRows = false;
            datagrid_categorias.AllowUserToDeleteRows = false;
            datagrid_categorias.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            datagrid_categorias.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            datagrid_categorias.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            datagrid_categorias.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            datagrid_categorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datagrid_categorias.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            datagrid_categorias.Location = new System.Drawing.Point(31, 126);
            datagrid_categorias.Name = "datagrid_categorias";
            datagrid_categorias.ReadOnly = true;
            datagrid_categorias.RowTemplate.Height = 50;
            datagrid_categorias.Size = new System.Drawing.Size(800, 393);
            datagrid_categorias.TabIndex = 0;
            datagrid_categorias.CellClick -= datagrid_categorias_CellClick;
            datagrid_categorias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_categorias_CellClick);

            // Definir columnas de la tabla CATEGORIA
            datagrid_categorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CIdCategoria",
                HeaderText = "ID Categoría",
                DataPropertyName = "id_categoria" // Nombre de la columna en la base de datos
            });

            datagrid_categorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CNombreCategoria",
                HeaderText = "Nombre",
                DataPropertyName = "nombre_categoria"
            });

            datagrid_categorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CDescripcionCategoria",
                HeaderText = "Descripción",
                DataPropertyName = "descripcion_categoria"
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
            datagrid_categorias.Columns.Add(modificarButtonColumn);

            // Botón Baja/Alta (Color Rojo)
            var bajaButtonColumn = new DataGridViewButtonColumn
            {
                Name = "CBaja_Alta",
                HeaderText = "Baja",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Popup,
            };
            datagrid_categorias.Columns.Add(bajaButtonColumn);

            datagrid_categorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CBaja",
                HeaderText = "Eliminado?",
                DataPropertyName = "estado_categoria"
            });

            // Formateo del DataGridView (si es necesario)
            datagrid_categorias.CellFormatting += new DataGridViewCellFormattingEventHandler(datagrid_categorias_CellFormatting);
        }

        private void datagrid_categorias_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            // Verifica si la columna es la de baja_producto
            if (datagrid_categorias.Columns[e.ColumnIndex].Name == "CBaja")
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

            // Verifica si la columna es la de "Nombre de la Categoría"
            if (datagrid_categorias.Columns[e.ColumnIndex].Name == "CNombreCategoria")
            {
                // Aquí se puede realizar cualquier formateo para el nombre de la categoría si es necesario.
                e.FormattingApplied = true;
            }

            // Verifica si la columna es la de descripción de la categoría
            if (datagrid_categorias.Columns[e.ColumnIndex].Name == "CDescripcionCategoria")
            {
                // Aquí se puede realizar cualquier formateo para la descripción si es necesario.
                e.FormattingApplied = true;
            }

            // Verifica si la columna es la de "CBaja_Alta" para cambiar el estado de Baja/Alta
            if (datagrid_categorias.Columns[e.ColumnIndex].Name == "CBaja_Alta")
            {
                // Verifica que el valor de la celda no sea nulo o DBNull
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    try
                    {
                        // Obtén el ID de la categoría de la fila actual
                        int idCategoria = Convert.ToInt32(datagrid_categorias.Rows[e.RowIndex].Cells["CIdCategoria"].Value);

                        // Conectar a la base de datos para obtener el estado de la categoría
                        string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string selectQuery = "SELECT estado_categoria FROM CATEGORIA WHERE id_categoria = @IdCategoria";

                            using (SqlCommand command = new SqlCommand(selectQuery, connection))
                            {
                                command.Parameters.AddWithValue("@IdCategoria", idCategoria);

                                // Ejecutar la consulta y obtener el estado de la categoría
                                object result = command.ExecuteScalar();
                                if (result != null)
                                {
                                    int estado = Convert.ToInt32(result);

                                    // Si el estado es 0, significa que está inactiva (baja), entonces mostramos "Activar"
                                    // Si el estado es 1, está activa, entonces mostramos "Eliminar"
                                    if (estado == 0) // Categoría eliminada
                                    {
                                        e.Value = "Alta";
                                        e.CellStyle.BackColor = Color.LightBlue; // Cambia el color de fondo
                                        e.CellStyle.ForeColor = Color.Black; // Cambia el color del texto
                                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centra el texto
                                    }
                                    else
                                    {
                                        e.Value = "Baja";
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
                        MessageBox.Show($"Error al obtener el estado de la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.FormattingApplied = false;
                    }
                }
            }

            // Cambiar color del botón Modificar a amarillo
            if (datagrid_categorias.Columns[e.ColumnIndex].Name == "CModificar")
            {
                e.CellStyle.BackColor = Color.Yellow; // Cambia el color de fondo
                e.CellStyle.ForeColor = Color.Black; // Cambia el color del texto
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centra el texto
                e.FormattingApplied = true;
            }

            
            // Cambiar el fondo de la fila si el producto está eliminado
            if (Convert.ToInt32(datagrid_categorias.Rows[e.RowIndex].Cells["CBaja"].Value) == 0)
            {
                datagrid_categorias.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkGray;
            }
        }

        private void textBoxNombreCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir letras, números, espacios y caracteres de control (como la tecla de retroceso)
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla si no es una letra, número, espacio o carácter de control
            }
        }

        private void ModificarEstadoCategoria(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta para obtener el estado actual de la categoría
                    string selectQuery = "SELECT estado_categoria FROM CATEGORIA WHERE id_categoria = @Id";
                    using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@Id", id);

                        // Ejecutar el comando y verificar si se obtuvo un resultado
                        object result = selectCommand.ExecuteScalar();
                        if (result == null)
                        {
                            MessageBox.Show("No se encontró la categoría con el ID especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Salir si no hay resultado
                        }

                        int estadoActual = Convert.ToInt32(result);

                        // Alterna el estado: si está activo (0), lo inactivamos (1); si está inactivo, lo activamos
                        string updateQuery;
                        if (estadoActual == 0)
                        {
                            updateQuery = "UPDATE CATEGORIA SET estado_categoria = 1 WHERE id_categoria = @Id";
                        }
                        else
                        {
                            updateQuery = "UPDATE CATEGORIA SET estado_categoria = 0 WHERE id_categoria = @Id";
                        }

                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@Id", id);

                            // Ejecuta la actualización
                            int rowsAffected = updateCommand.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Estado de la categoría actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No se pudo actualizar el estado de la categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                // Actualiza el DataGridView después de cambiar el estado
                CargarCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el estado de la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CargarCategorias()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id_categoria, nombre_categoria, descripcion_categoria, estado_categoria FROM CATEGORIA";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        // Asignar el DataTable como DataSource del DataGridView
                        datagrid_categorias.DataSource = dataTable; // Asegúrate de que el nombre del DataGridView es correcto

                        // Ocultar la columna id_categoria
                        datagrid_categorias.Columns["CIdCategoria"].Visible = false; // Ocultar ID Categoría
                    }
                }
                catch (Exception ex)
                {
                    // Muestra el mensaje de error completo en la consola o en un cuadro de mensaje
                    Console.WriteLine(ex.Message); // Para ver en la consola
                    MessageBox.Show($"Error al cargar las categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void datagrid_categorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que no se está haciendo clic en el encabezado
            if (e.RowIndex >= 0)
            {
                // Si se hace clic en la columna de descripción
                if (datagrid_categorias.Columns[e.ColumnIndex].Name == "CDescripcionCategoria")
                {
                    // Obtener la información de la categoría de la fila seleccionada
                    string descripcion = datagrid_categorias.Rows[e.RowIndex].Cells["CDescripcionCategoria"].Value.ToString();
                    string nombreCategoria = datagrid_categorias.Rows[e.RowIndex].Cells["CNombreCategoria"].Value.ToString();

                    // Mostrar un MessageBox con la información
                    MessageBox.Show($"Categoría: {nombreCategoria}\nDescripción: {descripcion}", "Detalles de la Categoría", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Verifica si la celda clicada es válida
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Verifica si la celda clicada es un botón
                    if (datagrid_categorias.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                    {
                        // Verifica si se ha hecho clic en la columna de estado (CBaja_Alta)
                        if (datagrid_categorias.Columns[e.ColumnIndex].Name == "CBaja_Alta")
                        {
                            // Obtiene el ID de la categoría de la celda correspondiente
                            object cellValue = datagrid_categorias.Rows[e.RowIndex].Cells["CIdCategoria"].Value;

                            if (cellValue != null && int.TryParse(cellValue.ToString(), out int idCategoria))
                            {
                                try
                                {
                                    // Modifica el estado de la categoría
                                    ModificarEstadoCategoria(idCategoria);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Error al modificar el estado de la categoría: {ex.Message}",
                                                    "Error",
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se pudo determinar el ID de la categoría.",
                                                "Error",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
                            }
                        }

                        // Si se hizo clic en la columna "Modificar"
                        if (datagrid_categorias.Columns[e.ColumnIndex].Name == "CModificar")
                        {
                            // Obtener el ID de la categoría de la fila seleccionada
                            object cellValue = datagrid_categorias.Rows[e.RowIndex].Cells["CIdCategoria"].Value;

                            if (cellValue != null && int.TryParse(cellValue.ToString(), out int idCategoria))
                            {
                                string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;

                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    connection.Open();

                                    // Consulta para obtener los detalles de la categoría
                                    string query = "SELECT id_categoria, nombre_categoria, descripcion_categoria FROM CATEGORIA WHERE id_categoria = @IdCategoria";
                                    using (SqlCommand command = new SqlCommand(query, connection))
                                    {
                                        command.Parameters.AddWithValue("@IdCategoria", idCategoria);

                                        using (SqlDataReader reader = command.ExecuteReader())
                                        {
                                            if (reader.Read()) // Verifica si se encontró la categoría
                                            {
                                                // Obtener los datos de la categoría
                                                string idCat = reader["id_categoria"].ToString();
                                                string nombre = reader["nombre_categoria"].ToString();
                                                string descripcion = reader["descripcion_categoria"].ToString();

                                                // Llenar los TextBox con los datos de la categoría seleccionada
                                                textBoxIDcategoria.Text = idCat;
                                                textBoxNombreCategoria.Text = nombre;
                                                textBoxDescripcionCategoria.Text = descripcion;
                                            }
                                            else
                                            {
                                                MessageBox.Show("No se encontró la categoría seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }
        }

        private void datagrid_categorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
