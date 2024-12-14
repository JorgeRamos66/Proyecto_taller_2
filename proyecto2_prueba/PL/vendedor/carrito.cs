using System;
using System.Windows.Forms;
using BLL;
using ML;

namespace proyecto2_prueba.Presentaciones.vendedor
{
    public partial class carrito : Form
    {
        private readonly CarritoBLL _carritoBLL;

        public carrito()
        {
            InitializeComponent();
            _carritoBLL = new CarritoBLL();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            textBoxBusqueda.TextChanged += textBoxBusqueda_TextChanged;
            datagrid_productos.CellClick += datagrid_productos_CellClick;
            datagrid_carrito.CellClick += datagrid_carrito_CellClick;
            datagrid_carrito.CellValidating += datagrid_carrito_CellValidating;
            ActualizarCarrito();
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

        private void textBoxBusqueda_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var productos = _carritoBLL.BuscarProductos(textBoxBusqueda.Text);
                MostrarProductosEnGrid(productos);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar productos: {ex.Message}");
            }
        }

        private void MostrarProductosEnGrid(List<CarritoItem> productos)
        {
            datagrid_productos.Rows.Clear();
            foreach (var producto in productos)
            {
                datagrid_productos.Rows.Add(
                    producto.IdProducto,
                    producto.NombreProducto,
                    producto.Categoria,
                    producto.Precio.ToString("C"),
                    producto.StockDisponible,
                    "Agregar"
                );
            }
        }

        private void datagrid_productos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == datagrid_productos.Columns["Agregar"].Index)
            {
                try
                {
                    int idProducto = Convert.ToInt32(datagrid_productos.Rows[e.RowIndex].Cells["Id"].Value);
                    using (var cantidadForm = new IngresarCantidad())
                    {
                        if (cantidadForm.ShowDialog() == DialogResult.OK)
                        {
                            _carritoBLL.AgregarProducto(idProducto, cantidadForm.Cantidad);
                            ActualizarCarrito();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void datagrid_carrito_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == datagrid_carrito.Columns["operacionQuitar"]?.Index)
                {
                    int idProducto = Convert.ToInt32(datagrid_carrito.Rows[e.RowIndex].Cells["Id"].Value);
                    _carritoBLL.QuitarProducto(idProducto);
                    ActualizarCarrito();
                }
            }
        }

        private void datagrid_carrito_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == datagrid_carrito.Columns["Cantidad"].Index)
            {
                try
                {
                    if (int.TryParse(e.FormattedValue.ToString(), out int nuevaCantidad))
                    {
                        int idProducto = Convert.ToInt32(datagrid_carrito.Rows[e.RowIndex].Cells["Id"].Value);
                        _carritoBLL.ActualizarCantidad(idProducto, nuevaCantidad);
                        ActualizarCarrito();
                    }
                    else
                    {
                        e.Cancel = true;
                        MessageBox.Show("Por favor ingrese un número válido", "Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    e.Cancel = true;
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ActualizarCarrito()
        {
            datagrid_carrito.Rows.Clear();
            var items = _carritoBLL.ObtenerItems();
            
            foreach (var item in items)
            {
                datagrid_carrito.Rows.Add(
                    item.IdProducto,
                    item.NombreProducto,
                    item.Categoria,
                    item.Precio.ToString("C"),
                    item.Cantidad,
                    item.Subtotal.ToString("C"),
                    "Quitar"
                );
            }

            lblTotal.Text = _carritoBLL.ObtenerTotal().ToString("C");
        }

        private void bConfirmarVenta_Click(object sender, EventArgs e)
        {
            if (!_carritoBLL.ObtenerItems().Any())
            {
                MessageBox.Show("El carrito está vacío", "Aviso", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var menuClienteForm = new menu_cliente(_carritoBLL);
            menuClienteForm.ShowDialog();

            if (menuClienteForm.VentaRealizada)
            {
                this.Close();
            }
        }

        private void BLimpiarCarrito_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea limpiar el carrito?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _carritoBLL.LimpiarCarrito();
                ActualizarCarrito();
            }
        }

        private void carrito_Load(object sender, EventArgs e)
        {
            ConfigurarGrillas();
            ActualizarCarrito();
        }

        private void ConfigurarGrillas()
        {
            // Configurar datagrid_productos
            datagrid_productos.AutoGenerateColumns = false;
            datagrid_productos.Columns.Clear();
            datagrid_productos.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", Visible = false },
                new DataGridViewTextBoxColumn { Name = "Nombre", HeaderText = "Producto", Width = 200 },
                new DataGridViewTextBoxColumn { Name = "Categoria", HeaderText = "Categoría", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "Precio", HeaderText = "Precio", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "Stock", HeaderText = "Stock", Width = 80 },
                new DataGridViewButtonColumn { Name = "Agregar", HeaderText = "", Width = 80 }
            );

            // Configurar datagrid_carrito
            datagrid_carrito.AutoGenerateColumns = false;
            datagrid_carrito.Columns.Clear();
            datagrid_carrito.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", Visible = false },
                new DataGridViewTextBoxColumn { Name = "Nombre", HeaderText = "Producto", Width = 200 },
                new DataGridViewTextBoxColumn { Name = "Categoria", HeaderText = "Categoría", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "Precio", HeaderText = "Precio Unit.", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "Cantidad", HeaderText = "Cantidad", Width = 80 },
                new DataGridViewTextBoxColumn { Name = "Subtotal", HeaderText = "Subtotal", Width = 100 },
                new DataGridViewButtonColumn { Name = "operacionQuitar", HeaderText = "", Width = 80 }
            );
        }
    }
}