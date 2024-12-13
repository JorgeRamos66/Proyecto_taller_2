using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BLL;
using ML;

namespace proyecto2_prueba.Presentaciones.admin
{
    public partial class listado_productos_admin : Form
    {
        private ProductoBLL productoBLL = new ProductoBLL();

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
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void BAltaProducto_Click(object sender, EventArgs e)
        {
            Form formularioMDI = this.MdiParent;
            Form formularioAbierto = Application.OpenForms.OfType<alta_producto>().FirstOrDefault();

            if (formularioAbierto != null)
            {
                MessageBox.Show("El formulario de alta de producto ya está abierto.");
            }
            else
            {
                alta_producto nuevo_producto = new alta_producto(this);
                nuevo_producto.ShowDialog();
            }
        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BBuscarProducto_Click(object sender, EventArgs e)
        {
            string textoBusqueda = textBoxBusqueda.Text.ToLower();
            if (!string.IsNullOrEmpty(textoBusqueda))
            {
                BuscarProductos(textoBusqueda);
            }
            else
            {
                MostrarTodosLosProductos();
            }
        }

        private void ButtonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxBusqueda.Clear();
            MostrarTodosLosProductos();
        }

        public void CargarProductos()
        {
            datagrid_productos.DataSource = productoBLL.ObtenerProductos();
            CargarImagenes((DataTable)datagrid_productos.DataSource);
        }

        private void CargarImagenes(DataTable dataTable)
        {
            if (!dataTable.Columns.Contains("Imagen"))
            {
                dataTable.Columns.Add("Imagen", typeof(Image));
            }

            foreach (DataRow row in dataTable.Rows)
            {
                string rutaImagen = row["ruta_imagen"].ToString();
                string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\", rutaImagen);

                if (File.Exists(rutaCompleta))
                {
                    row["Imagen"] = Image.FromFile(rutaCompleta);
                }
                else
                {
                    row["Imagen"] = null;
                }
            }
        }

        private void ConfigurarDataGridView()
        {
            datagrid_productos.Columns.Clear();
            datagrid_productos.AllowUserToAddRows = false;
            datagrid_productos.AllowUserToDeleteRows = false;
            datagrid_productos.BackgroundColor = SystemColors.ActiveCaption;
            datagrid_productos.BorderStyle = BorderStyle.Fixed3D;
            datagrid_productos.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            datagrid_productos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            datagrid_productos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datagrid_productos.GridColor = SystemColors.ActiveCaptionText;
            datagrid_productos.Location = new Point(31, 126);
            datagrid_productos.Name = "datagrid_productos";
            datagrid_productos.ReadOnly = true;
            datagrid_productos.RowTemplate.Height = 50;
            datagrid_productos.Size = new Size(1244, 393);
            datagrid_productos.TabIndex = 0;
            datagrid_productos.CellClick -= datagrid_productos_CellClick;
            datagrid_productos.CellClick += new DataGridViewCellEventHandler(this.datagrid_productos_CellClick);

            // Definir columnas
            datagrid_productos.Columns.Add(new DataGridViewTextBoxColumn { Name = "CIdProducto", HeaderText = "ID Producto", DataPropertyName = "id_producto" });
            datagrid_productos.Columns.Add(new DataGridViewTextBoxColumn { Name = "CNombreProducto", HeaderText = "Nombre", DataPropertyName = "nombre_producto" });
            datagrid_productos.Columns.Add(new DataGridViewTextBoxColumn { Name = "CStockProducto", HeaderText = "Stock", DataPropertyName = "stock_producto" });
            datagrid_productos.Columns.Add(new DataGridViewTextBoxColumn { Name = "CPrecio", HeaderText = "Precio", DataPropertyName = "precio_producto" });
            datagrid_productos.Columns.Add(new DataGridViewTextBoxColumn { Name = "CCategoriaProducto", HeaderText = "Categoría", DataPropertyName = "id_categoria" });
            datagrid_productos.Columns.Add(new DataGridViewTextBoxColumn { Name = "CDescripcion", HeaderText = "Descripción", DataPropertyName = "descripcion_producto" });
            datagrid_productos.Columns.Add(new DataGridViewTextBoxColumn { Name = "CModificar", HeaderText = "Modificar" });
            datagrid_productos.Columns.Add(new DataGridViewTextBoxColumn { Name = "CEstado", HeaderText = "Estado" });
            datagrid_productos.Columns.Add(new DataGridViewTextBoxColumn { Name = "CBaja", HeaderText = "Eliminado?", DataPropertyName = "baja_producto" });
            datagrid_productos.Columns.Add(new DataGridViewTextBoxColumn { Name = "CRutaImagen", HeaderText = "Ruta Imagen", DataPropertyName = "ruta_imagen" });

            datagrid_productos.Columns["CIdProducto"].Visible = false;
            datagrid_productos.Columns["CRutaImagen"].Visible = false;
        }

        private void datagrid_productos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (datagrid_productos.Columns[e.ColumnIndex].Name == "CCategoriaProducto")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    if (int.TryParse(e.Value.ToString(), out int idCategoria))
                    {
                        string nombreCategoria = productoBLL.ObtenerNombreCategoria(idCategoria);
                        if (!string.IsNullOrEmpty(nombreCategoria))
                        {
                            e.Value = nombreCategoria;
                            e.FormattingApplied = true;
                        }
                    }
                }
            }

            if (datagrid_productos.Columns[e.ColumnIndex].Name == "CBaja")
            {
                if (e.Value != null && e.Value != DBNull.Value && e.Value is int bajaValue)
                {
                    e.Value = bajaValue == 1 ? "No" : "Si";
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.FormattingApplied = true;
                }
            }

            if (datagrid_productos.Columns[e.ColumnIndex].Name == "CEstado")
            {
                if (e.Value == null)
                {
                    e.Value = "Estado";
                }
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    int idProducto = Convert.ToInt32(datagrid_productos.Rows[e.RowIndex].Cells["CIdProducto"].Value);
                    Producto producto = productoBLL.ObtenerProductoPorId(idProducto);
                    if (producto != null)
                    {
                        if (!producto.BajaProducto)
                        {
                            e.Value = "Activar";
                            e.CellStyle.BackColor = Color.LightBlue;
                            e.CellStyle.ForeColor = Color.Black;
                        }
                        else
                        {
                            e.Value = "Eliminar";
                            e.CellStyle.BackColor = Color.Red;
                            e.CellStyle.ForeColor = Color.White;
                        }
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        e.FormattingApplied = true;
                    }
                }
            }

            if (datagrid_productos.Columns[e.ColumnIndex].Name == "CModificar")
            {
                e.Value = "Modificar";
                e.CellStyle.BackColor = Color.Green;
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.FormattingApplied = true;
            }

            if (Convert.ToInt32(datagrid_productos.Rows[e.RowIndex].Cells["CBaja"].Value) == 0)
            {
                datagrid_productos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkGray;
            }
        }

        private void datagrid_productos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (datagrid_productos.Columns[e.ColumnIndex].Name == "Imagen")
                {
                    Image imagenProducto = null;
                    if (datagrid_productos.Rows[e.RowIndex].Cells["Imagen"].Value != DBNull.Value)
                    {
                        imagenProducto = (Image)datagrid_productos.Rows[e.RowIndex].Cells["Imagen"].Value;
                    }

                    ProductoDetalleForm detalleForm = new ProductoDetalleForm(imagenProducto);
                    detalleForm.ShowDialog();
                }

                if (datagrid_productos.Columns[e.ColumnIndex].Name == "CDescripcion")
                {
                    string descripcion = datagrid_productos.Rows[e.RowIndex].Cells["CDescripcion"].Value.ToString();
                    string nombreProducto = datagrid_productos.Rows[e.RowIndex].Cells["CNombreProducto"].Value.ToString();
                    MessageBox.Show($"Producto: {nombreProducto}\nDescripción: {descripcion}", "Detalles del Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (datagrid_productos.Columns[e.ColumnIndex].Name == "CEstado")
                {
                    object cellValue = datagrid_productos.Rows[e.RowIndex].Cells["CIdProducto"].Value;
                    if (cellValue != null && int.TryParse(cellValue.ToString(), out int idProducto))
                    {
                        try
                        {
                            productoBLL.ModificarEstadoProducto(idProducto);
                            CargarProductos();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al modificar el estado del producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                if (datagrid_productos.Columns[e.ColumnIndex].Name == "CModificar")
                {
                    object cellValue = datagrid_productos.Rows[e.RowIndex].Cells["CIdProducto"].Value;
                    if (cellValue != null && int.TryParse(cellValue.ToString(), out int idProducto))
                    {
                        Producto producto = productoBLL.ObtenerProductoPorId(idProducto);
                        if (producto != null)
                        {
                            modificar_producto modificarProducto = new modificar_producto(idProducto, producto.NombreProducto, producto.StockProducto, producto.PrecioProducto, producto.IdCategoria, producto.DescripcionProducto, producto.RutaImagen, this);
                            modificarProducto.ShowDialog();
                        }
                    }
                }
            }
        }

        private void BuscarProductos(string textoBusqueda)
        {
            // Desactivar temporalmente el CurrencyManager
            CurrencyManager currencyManager = (CurrencyManager)BindingContext[datagrid_productos.DataSource];
            currencyManager.SuspendBinding();

            bool algunaFilaVisible = false;
            foreach (DataGridViewRow fila in datagrid_productos.Rows)
            {
                string nombreProducto = fila.Cells["CNombreProducto"].Value?.ToString().ToLower();
                string descripcionProducto = fila.Cells["CDescripcion"].Value?.ToString().ToLower();
                string stockProducto = fila.Cells["CStockProducto"].Value?.ToString().ToLower();
                string precioProducto = fila.Cells["CPrecio"].Value?.ToString().ToLower();

                int idCategoria = Convert.ToInt32(fila.Cells["CCategoriaProducto"].Value);
                string categoriaProducto = productoBLL.ObtenerNombreCategoria(idCategoria)?.ToLower();

                if ((nombreProducto != null && nombreProducto.Contains(textoBusqueda))
                    || (descripcionProducto != null && descripcionProducto.Contains(textoBusqueda))
                    || (stockProducto != null && stockProducto.Contains(textoBusqueda))
                    || (precioProducto != null && precioProducto.Contains(textoBusqueda))
                    || (categoriaProducto != null && categoriaProducto.Contains(textoBusqueda)))
                {
                    fila.Visible = true;
                    algunaFilaVisible = true;
                }
                else
                {
                    fila.Visible = false;
                }
            }

            // Reactivar el CurrencyManager
            currencyManager.ResumeBinding();

            if (!algunaFilaVisible)
            {
                MessageBox.Show("No se encontraron coincidencias.");
            }
        }

        private void MostrarTodosLosProductos()
        {
            foreach (DataGridViewRow fila in datagrid_productos.Rows)
            {
                fila.Visible = true;
            }
        }
    }
}
