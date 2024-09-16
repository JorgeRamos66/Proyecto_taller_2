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
    public partial class listado_productos_admin : Form
    {
        public listado_productos_admin()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            CargarProductos();
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
                // Iterar sobre las filas del DataGridView
                foreach (DataGridViewRow fila in datagrid_productos.Rows)
                {
                    // Obtener el valor de la columna que contiene el nombre del producto (ajusta el índice si es necesario)
                    string nombreProducto = fila.Cells["CNombre_producto"].Value?.ToString().ToLower();

                    // Comparar el texto de búsqueda con el nombre del producto
                    if (nombreProducto != null && nombreProducto.Contains(textoBusqueda))
                    {
                        fila.Visible = true; // Mostrar fila si coincide
                    }
                    else
                    {
                        fila.Visible = false; // Ocultar fila si no coincide
                    }
                }

                // Verificar si alguna fila coincide (si no hay filas visibles)
                bool algunaFilaVisible = false;
                foreach (DataGridViewRow fila in datagrid_productos.Rows)
                {
                    if (fila.Visible)
                    {
                        algunaFilaVisible = true;
                        break;
                    }
                }

                if (!algunaFilaVisible)
                {
                    MessageBox.Show("No se encontraron coincidencias.");
                }
            }
            else
            {
                //Si el cuadro de búsqueda está vacío, mostrar todas las filas
                foreach (DataGridViewRow fila in datagrid_productos.Rows)
                {
                    fila.Visible = true;
                }
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
                    string query = "SELECT * FROM PRODUCTO";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        datagrid_productos.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            datagrid_productos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_productos_CellContentClick);

            // Definir columnas
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

            datagrid_productos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CRutaImagen",
                HeaderText = "Ruta Imagen",
                DataPropertyName = "ruta_imagen"
            });

            // Agregar otras columnas si es necesario (por ejemplo, para la imagen del producto)
            datagrid_productos.Columns.Add(new DataGridViewImageColumn
            {
                Name = "CImagenProducto",
                HeaderText = "Imagen",
                ImageLayout = DataGridViewImageCellLayout.Zoom // Ajustar la imagen en la celda
            });

            // Agregar columnas para botones de modificar y eliminar
            datagrid_productos.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "CModificar",
                HeaderText = "Modificar",
                Text = "Modificar",
                UseColumnTextForButtonValue = true
            });

            datagrid_productos.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "CBaja",
                HeaderText = "Eliminar",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true
            });
        }

        private void EliminarProducto(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM PRODUCTO WHERE id_producto = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }

            // Actualiza el DataGridView
            CargarProductos();
        }

        private void datagrid_productos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica si la celda clicada es válida
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Verifica si la columna es un botón
                DataGridViewButtonColumn buttonColumn = datagrid_productos.Columns[e.ColumnIndex] as DataGridViewButtonColumn;
                if (buttonColumn != null)
                {
                    // Verifica si se ha hecho clic en la columna de eliminación
                    if (e.ColumnIndex == datagrid_productos.Columns["CBaja"].Index)
                    {
                        // Obtiene el ID del producto de la celda correspondiente
                        object cellValue = datagrid_productos.Rows[e.RowIndex].Cells["CIdProducto"].Value;

                        if (cellValue != null && int.TryParse(cellValue.ToString(), out int idProducto))
                        {
                            // Confirmar la eliminación del producto
                            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este producto?",
                                                                  "Confirmar eliminación",
                                                                  MessageBoxButtons.YesNo,
                                                                  MessageBoxIcon.Warning);
                            if (result == DialogResult.Yes)
                            {
                                try
                                {
                                    // Eliminar el producto de la base de datos
                                    EliminarProducto(idProducto);

                                    // Eliminar la fila del DataGridView
                                    datagrid_productos.Rows.RemoveAt(e.RowIndex);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Error al eliminar el producto: {ex.Message}",
                                                    "Error",
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Error);
                                }
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
                }
            }
        }

    }
}
