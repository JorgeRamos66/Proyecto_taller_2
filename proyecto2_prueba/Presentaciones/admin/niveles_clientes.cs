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
    public partial class niveles_clientes : Form
    {
        public niveles_clientes()
        {
            InitializeComponent();
            ConfigurarDataGridViewNiveles();
            CargarNiveles();
            datagrid_niveles.CellFormatting += datagrid_niveles_CellFormatting;
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
            // Validación de que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(textBoxNombreNivel.Text) ||
                numericUpDownDescuento.Value == 0)  // Valida si el valor del descuento es 0
            {
                MessageBox.Show("Debe rellenar todos los campos para agregar o modificar una nivel.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // Se extraen los datos de los TextBox
            string nombreNivel = textBoxNombreNivel.Text;
            int descuentoNivel = (int)numericUpDownDescuento.Value;  // Aquí obtenemos el valor numérico del NumericUpDown


            // Verificar si hay un ID de nivel en el textBoxIDnivel
            if (int.TryParse(textBoxIDnivel.Text, out int idNivel) && idNivel > 0) // Validar que el ID sea un número y mayor que 0
            {
                // Si hay un ID válido, se actualiza la nivel existente
                ActualizarNivel(idNivel, nombreNivel, descuentoNivel);
            }
            else // Si no hay un ID, se agrega una nueva nivel
            {
                // Llamar al método para agregar la nueva nivel a la base de datos
                AgregarNuevoNivel(nombreNivel, descuentoNivel);
            }

            // Limpiar los TextBox después de agregar o modificar la nivel
            textBoxIDnivel.Clear();
            textBoxNombreNivel.Clear();
            numericUpDownDescuento.Value = 0;

            // Actualizar el DataGridView
            CargarNiveles(); // Llama a este método para recargar la lista de niveles
        }

        private void ActualizarNivel(int idNivel, string nombreNivel, int descuentoNivel)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta para actualizar la nivel existente
                    string query = "UPDATE NIVEL SET nombre_nivel = @Nombre, descuento = @Descuento WHERE id_nivel = @Id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", nombreNivel);
                        command.Parameters.AddWithValue("@Descuento", descuentoNivel);
                        command.Parameters.AddWithValue("@Id", idNivel);

                        // Ejecutar el comando de actualización
                        command.ExecuteNonQuery();

                        MessageBox.Show("Nivel actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la nivel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarNuevoNivel(string nombreNivel, int descuentoNivel)
        {
            // Validar los campos
            if (string.IsNullOrWhiteSpace(nombreNivel) || descuentoNivel == 0)
            {
                MessageBox.Show("Debe rellenar todos los campos para agregar el nivel.",
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

                    // Consulta para insertar la nueva nivel
                    string query = "INSERT INTO NIVEL (nombre_nivel, descuento) VALUES (@Nombre, @Descuento)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", nombreNivel);
                        command.Parameters.AddWithValue("@Descuento", descuentoNivel);

                        // Ejecutar el comando de inserción
                        command.ExecuteNonQuery();

                        MessageBox.Show("Nivel agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el nivel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDataGridViewNiveles()
        {
            // Limpiar columnas existentes
            datagrid_niveles.Columns.Clear();

            // Configurar propiedades del DataGridView
            datagrid_niveles.AllowUserToAddRows = false;
            datagrid_niveles.AllowUserToDeleteRows = false;
            datagrid_niveles.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            datagrid_niveles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            datagrid_niveles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            datagrid_niveles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            datagrid_niveles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datagrid_niveles.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            datagrid_niveles.Location = new System.Drawing.Point(26, 152);
            datagrid_niveles.Name = "datagrid_niveles";
            datagrid_niveles.ReadOnly = true;
            datagrid_niveles.RowTemplate.Height = 50;
            datagrid_niveles.Size = new System.Drawing.Size(491, 291);
            datagrid_niveles.TabIndex = 0;
            datagrid_niveles.CellClick -= datagrid_niveles_CellClick;
            datagrid_niveles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_niveles_CellClick);

            // Definir columnas de la tabla NIVEL
            datagrid_niveles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CIdNivel",
                HeaderText = "ID Nivel",
                DataPropertyName = "id_nivel" // Nombre de la columna en la base de datos
            });

            datagrid_niveles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CNombreNivel",
                HeaderText = "Nombre",
                DataPropertyName = "nombre_nivel"
            });

            datagrid_niveles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CDescuentoNivel",
                HeaderText = "Descuento",
                DataPropertyName = "descuento"
            });

            // Botón Modificar (Color Amarillo)
            datagrid_niveles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CModificar",
                HeaderText = "Modificar",
                DataPropertyName = "modificar_nivel"
            });

            // Botón Baja/Alta (Color Rojo)
            datagrid_niveles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CEstado",
                HeaderText = "Estado",
                DataPropertyName = "eliminar_nivel"
            });

            datagrid_niveles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CBaja",
                HeaderText = "Eliminado?",
                DataPropertyName = "estado_nivel"
            });

            datagrid_niveles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Formateo del DataGridView (si es necesario)
            datagrid_niveles.CellFormatting += new DataGridViewCellFormattingEventHandler(datagrid_niveles_CellFormatting);
        }

        private void datagrid_niveles_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            // Verifica si la columna es la de baja_producto
            if (datagrid_niveles.Columns[e.ColumnIndex].Name == "CBaja")
            {
                // Verifica que el valor de la celda no sea nulo o DBNull
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    // Verifica si el valor es del tipo correcto antes de convertir
                    if (e.Value is int bajaValue)
                    {
                        // Cambia el valor a "Sí" o "No" según el estado
                        e.Value = bajaValue == 1 ? "No" : "Si";
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centra el texto
                        e.FormattingApplied = true; // Evita que el valor predeterminado se siga mostrando
                    }
                    else
                    {
                        // Si el valor no es un entero, podrías manejarlo como desees
                        e.FormattingApplied = false; // No aplicar formateo
                    }
                }
            }

            // Verifica si la columna es la de "Nombre de la Nivel"
            if (datagrid_niveles.Columns[e.ColumnIndex].Name == "CNombreNivel")
            {
                // Aquí se puede realizar cualquier formateo para el nombre de la nivel si es necesario.
                e.FormattingApplied = true;
            }

            // Verifica si la columna es la de "CEstado" para cambiar el estado de Baja/Alta
            if (datagrid_niveles.Columns[e.ColumnIndex].Name == "CEstado")
            {
                // Verifica que el valor de la celda no sea nulo o DBNull
                if (e.Value == null)
                {
                    e.Value = "Estado";
                }
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    try
                    {
                        // Obtén el ID de la nivel de la fila actual
                        int idNivel = Convert.ToInt32(datagrid_niveles.Rows[e.RowIndex].Cells["CIdNivel"].Value);

                        // Conectar a la base de datos para obtener el estado de la nivel
                        string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string selectQuery = "SELECT estado_nivel FROM NIVEL WHERE id_nivel = @IdNivel";

                            using (SqlCommand command = new SqlCommand(selectQuery, connection))
                            {
                                command.Parameters.AddWithValue("@IdNivel", idNivel);

                                // Ejecutar la consulta y obtener el estado de la nivel
                                object result = command.ExecuteScalar();
                                if (result != null)
                                {
                                    int estado = Convert.ToInt32(result);

                                    // Si el estado es 0, significa que está inactiva (baja), entonces mostramos "Activar"
                                    // Si el estado es 1, está activa, entonces mostramos "Eliminar"
                                    if (estado == 0) // Nivel eliminada
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
                        MessageBox.Show($"Error al obtener el estado de la nivel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.FormattingApplied = false;
                    }
                }
            }

            // Cambiar color del botón Modificar a amarillo
            if (datagrid_niveles.Columns[e.ColumnIndex].Name == "CModificar")
            {
                // Solo aplicar formateo si la celda tiene un valor no nulo
                if (datagrid_niveles.Columns[e.ColumnIndex].Name == "CModificar")
                {
                    e.Value = "Modificar";
                    e.CellStyle.BackColor = Color.Yellow;
                    e.CellStyle.ForeColor = Color.Black;
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.FormattingApplied = true;
                }
            }


            // Cambiar el fondo de la fila si el producto está eliminado
            if (Convert.ToInt32(datagrid_niveles.Rows[e.RowIndex].Cells["CBaja"].Value) == 0)
            {
                datagrid_niveles.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkGray;
            }
        }

        private void textBoxNombreNivel_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir letras, números, espacios y caracteres de control (como la tecla de retroceso)
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla si no es una letra, número, espacio o carácter de control
            }
        }

        private void ModificarEstadoNivel(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta para obtener el estado actual de la nivel
                    string selectQuery = "SELECT estado_nivel FROM NIVEL WHERE id_nivel = @Id";
                    using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@Id", id);

                        // Ejecutar el comando y verificar si se obtuvo un resultado
                        object result = selectCommand.ExecuteScalar();
                        if (result == null)
                        {
                            MessageBox.Show("No se encontró la nivel con el ID especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Salir si no hay resultado
                        }

                        int estadoActual = Convert.ToInt32(result);

                        // Alterna el estado: si está activo (0), lo inactivamos (1); si está inactivo, lo activamos
                        string updateQuery;
                        if (estadoActual == 0)
                        {
                            updateQuery = "UPDATE NIVEL SET estado_nivel = 1 WHERE id_nivel = @Id";
                        }
                        else
                        {
                            updateQuery = "UPDATE NIVEL SET estado_nivel = 0 WHERE id_nivel = @Id";
                        }

                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@Id", id);

                            // Ejecuta la actualización
                            int rowsAffected = updateCommand.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Estado de la nivel actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No se pudo actualizar el estado de la nivel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                // Actualiza el DataGridView después de cambiar el estado
                CargarNiveles();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el estado de la nivel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CargarNiveles()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id_nivel, nombre_nivel, descuento, estado_nivel FROM NIVEL";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        // Asignar el DataTable como DataSource del DataGridView
                        datagrid_niveles.DataSource = dataTable;

                        // Ocultar la columna id_nivel
                        datagrid_niveles.Columns["CIdNivel"].Visible = false; // Ocultar ID Nivel
                    }
                }
                catch (Exception ex)
                {
                    // Muestra el mensaje de error completo en la consola o en un cuadro de mensaje
                    Console.WriteLine(ex.Message); // Para ver en la consola
                    MessageBox.Show($"Error al cargar los niveles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void datagrid_niveles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que no se está haciendo clic en el encabezado
            if (e.RowIndex >= 0)
            {
                // Verifica si la celda clicada es válida
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Verifica si la columna es un textbox
                    if (datagrid_niveles.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn)
                    {
                        // Verifica si se ha hecho clic en la columna de estado (CEstado)
                        if (datagrid_niveles.Columns[e.ColumnIndex].Name == "CEstado")
                        {
                            // Obtiene el ID de la nivel de la celda correspondiente
                            object cellValue = datagrid_niveles.Rows[e.RowIndex].Cells["CIdNivel"].Value;

                            if (cellValue != null && int.TryParse(cellValue.ToString(), out int idNivel))
                            {
                                try
                                {
                                    // Modifica el estado de la nivel
                                    ModificarEstadoNivel(idNivel);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Error al modificar el estado del nivel: {ex.Message}",
                                                    "Error",
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se pudo determinar el ID del nivel.",
                                                "Error",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
                            }
                        }

                        // Si se hizo clic en la columna "Modificar"
                        if (datagrid_niveles.Columns[e.ColumnIndex].Name == "CModificar")
                        {
                            // Obtener el ID de la nivel de la fila seleccionada
                            object cellValue = datagrid_niveles.Rows[e.RowIndex].Cells["CIdNivel"].Value;

                            if (cellValue != null && int.TryParse(cellValue.ToString(), out int idNivel))
                            {
                                string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;

                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    connection.Open();

                                    // Consulta para obtener los detalles de la nivel
                                    string query = "SELECT id_nivel, nombre_nivel, descuento FROM NIVEL WHERE id_nivel = @IdNivel";
                                    using (SqlCommand command = new SqlCommand(query, connection))
                                    {
                                        command.Parameters.AddWithValue("@IdNivel", idNivel);

                                        using (SqlDataReader reader = command.ExecuteReader())
                                        {
                                            if (reader.Read()) // Verifica si se encontró la nivel
                                            {
                                                // Obtener los datos de la nivel
                                                string idNiv = reader["id_nivel"].ToString();
                                                string nombre = reader["nombre_nivel"].ToString();
                                                int descuento = Convert.ToInt32(reader["descuento"]);

                                                // Llenar los TextBox con los datos de la nivel seleccionada
                                                textBoxIDnivel.Text = idNiv;
                                                textBoxNombreNivel.Text = nombre;
                                                numericUpDownDescuento.Value = descuento;
                                            }
                                            else
                                            {
                                                MessageBox.Show("No se encontró la nivel seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void BSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void datagrid_niveles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datagrid_niveles_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
