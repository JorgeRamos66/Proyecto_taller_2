using System;
using System.Linq;
using System.Windows.Forms;
using BLL;
using ML;
using proyecto2_prueba.PL.vendedor;
using System.Collections.Generic;

namespace proyecto2_prueba.Presentaciones.vendedor
{
    public partial class carrito : Form
    {
        private readonly CarritoBLL _carritoBLL;
        private bool _mostrandoResultadosBusqueda;

        public carrito()
        {
            InitializeComponent();
            _carritoBLL = new CarritoBLL();
            _mostrandoResultadosBusqueda = false;
            ConfigurarFormulario();
        }

        private bool ConfirmarAccion(string mensaje)
        {
            return MessageBox.Show(mensaje, "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void ConfigurarFormulario()
        {
            textBoxBusqueda.TextChanged += textBoxBusqueda_TextChanged;
            datagrid_carrito.CellClick += datagrid_CellClick;
            datagrid_carrito.CellValidating += datagrid_carrito_CellValidating;
            ConfigurarColumnas(false);
            ActualizarCarrito();
        }

        private void ConfigurarColumnas(bool paraBusqueda)
        {
            datagrid_carrito.Columns.Clear();

            if (paraBusqueda)
            {
                datagrid_carrito.Columns.AddRange(
                    new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", Visible = false },
                    new DataGridViewTextBoxColumn { Name = "Nombre", HeaderText = "Producto", Width = 200 },
                    new DataGridViewTextBoxColumn { Name = "Categoria", HeaderText = "Categoría", Width = 150 },
                    new DataGridViewTextBoxColumn { Name = "Precio", HeaderText = "Precio", Width = 100 },
                    new DataGridViewTextBoxColumn { Name = "Stock", HeaderText = "Stock", Width = 80 },
                    new DataGridViewButtonColumn
                    {
                        Name = "Agregar",
                        HeaderText = "",
                        Width = 80,
                        Text = "Agregar",
                        UseColumnTextForButtonValue = true
                    }
                );
            }
            else
            {
                datagrid_carrito.Columns.AddRange(
                    new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", Visible = false },
                    new DataGridViewTextBoxColumn { Name = "Nombre", HeaderText = "Producto", Width = 200 },
                    new DataGridViewTextBoxColumn { Name = "Categoria", HeaderText = "Categoría", Width = 150 },
                    new DataGridViewTextBoxColumn { Name = "Precio", HeaderText = "Precio Unit.", Width = 100 },
                    new DataGridViewTextBoxColumn { Name = "Cantidad", HeaderText = "Cantidad", Width = 80 },
                    new DataGridViewTextBoxColumn { Name = "Subtotal", HeaderText = "Subtotal", Width = 100 },
                    new DataGridViewButtonColumn
                    {
                        Name = "Quitar",
                        HeaderText = "",
                        Width = 80,
                        Text = "Quitar",
                        UseColumnTextForButtonValue = true
                    }
                );
            }
        }

        private void textBoxBusqueda_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxBusqueda.Text))
                {
                    _mostrandoResultadosBusqueda = false;
                    ConfigurarColumnas(false);
                    ActualizarCarrito();
                    return;
                }

                var productos = _carritoBLL.BuscarProductos(textBoxBusqueda.Text);
                _mostrandoResultadosBusqueda = true;
                ConfigurarColumnas(true);
                MostrarProductosEnGrid(productos);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar productos: {ex.Message}");
            }
        }

        private void datagrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (_mostrandoResultadosBusqueda)
            {
                if (e.ColumnIndex == datagrid_carrito.Columns["Agregar"].Index)
                {
                    try
                    {
                        int idProducto = Convert.ToInt32(datagrid_carrito.Rows[e.RowIndex].Cells["Id"].Value);
                        int stockDisponible = Convert.ToInt32(datagrid_carrito.Rows[e.RowIndex].Cells["Stock"].Value);

                        using (var cantidadForm = new IngresarCantidad())
                        {
                            if (cantidadForm.ShowDialog() == DialogResult.OK)
                            {
                                if (cantidadForm.Cantidad > stockDisponible)
                                {
                                    MessageBox.Show("No hay suficiente stock disponible", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                _carritoBLL.AgregarProducto(idProducto, cantidadForm.Cantidad);
                                textBoxBusqueda.Clear();
                                _mostrandoResultadosBusqueda = false;
                                ConfigurarColumnas(false);
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
            else
            {
                if (e.ColumnIndex == datagrid_carrito.Columns["Quitar"].Index)
                {
                    if (ConfirmarAccion("¿Está seguro que desea quitar este producto del carrito?"))
                    {
                        int idProducto = Convert.ToInt32(datagrid_carrito.Rows[e.RowIndex].Cells["Id"].Value);
                        _carritoBLL.QuitarProducto(idProducto);
                        ActualizarCarrito();
                    }
                }
            }
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


        private void MostrarProductosEnGrid(List<CarritoItem> productos)
        {
            datagrid_carrito.Rows.Clear();
            foreach (var producto in productos)
            {
                datagrid_carrito.Rows.Add(
                    producto.IdProducto,
                    producto.NombreProducto,
                    producto.CategoriaProducto,
                    producto.PrecioProducto.ToString("C"),
                    producto.StockDisponible,
                    "Agregar"
                );
            }
        }


        private void datagrid_carrito_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (_mostrandoResultadosBusqueda) return;

            if (e.ColumnIndex == datagrid_carrito.Columns["Cantidad"].Index)
            {
                try
                {
                    if (!int.TryParse(e.FormattedValue.ToString(), out int nuevaCantidad))
                    {
                        e.Cancel = true;
                        MessageBox.Show("Por favor ingrese un número válido", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (nuevaCantidad <= 0)
                    {
                        e.Cancel = true;
                        MessageBox.Show("La cantidad debe ser mayor a 0", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int idProducto = Convert.ToInt32(datagrid_carrito.Rows[e.RowIndex].Cells["Id"].Value);
                    _carritoBLL.ActualizarCantidad(idProducto, nuevaCantidad);
                    ActualizarCarrito();
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
                    item.CategoriaProducto,
                    item.PrecioProducto.ToString("C"),
                    item.CantidadProducto,
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
                MessageBox.Show("El carrito está vacío", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var pasarela = new Pasarela(_carritoBLL.ObtenerTotal()))
            {
                if (pasarela.ShowDialog() != DialogResult.OK || !pasarela.PagoConfirmado)
                    return;

                using (var menuClienteForm = new menu_cliente(_carritoBLL))
                {
                    if (menuClienteForm.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            var ventaBLL = new VentaBLL();
                            int idVenta = ventaBLL.ProcesarVenta(
                                menuClienteForm.ClienteSeleccionado.Id,
                                pasarela.MetodoPagoSeleccionado
                            );

                            using (var formFactura = new ImpresionFactura(
                                menuClienteForm.ClienteSeleccionado,
                                _carritoBLL.ObtenerItems(),
                                idVenta))
                            {
                                formFactura.ShowDialog();
                            }
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al procesar la venta: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
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
            ConfigurarColumnas(false);
            ActualizarCarrito();
        }


        private void BBorrar_Click(object sender, EventArgs e)
        {
            textBoxBusqueda.Clear();
            _mostrandoResultadosBusqueda = false;
            ConfigurarColumnas(false);
            ActualizarCarrito();
        }
    }
}