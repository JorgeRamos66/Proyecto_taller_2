using System;
using System.Linq;
using System.Windows.Forms;
using BLL;
using ML;
using proyecto2_prueba.PL.vendedor;
using System.Collections.Generic;
using System.Globalization;
using System.Drawing;

namespace proyecto2_prueba.Presentaciones.vendedor
{
    public partial class carrito : Form
    {
        private readonly CarritoBLL _carritoBLL;
        private bool _mostrandoResultadosBusqueda;
        private bool _debeActualizarCarrito = false;
        private Cliente _clienteSeleccionado;
        private Label lblCliente;
        private Label lblDescuento;
        private Label lblClienteNombre;

        public carrito()
        {
            InitializeComponent();
            _carritoBLL = new CarritoBLL();
            _mostrandoResultadosBusqueda = false;
            ConfigurarFormulario();
        }

        public void EstablecerCliente(Cliente cliente)
        {
            _clienteSeleccionado = cliente;
            if (_clienteSeleccionado != null)
            {
                _carritoBLL.AplicarDescuento(_clienteSeleccionado.NivelDescuento);
                ActualizarInformacionCliente();
                ActualizarCarrito();
            }
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
            datagrid_carrito.CellEndEdit += datagrid_carrito_CellEndEdit;
            ConfigurarColumnas(false);
            ActualizarCarrito();

            // Agregar nuevos labels
            lblCliente = new Label
            {
                Location = new Point(70, 500),
                AutoSize = true,
                Text = "Cliente: ",
                Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold)
            };

            lblClienteNombre = new Label
            {
                Location = new Point(lblCliente.Right, 500),
                AutoSize = true,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular)
            };

            lblDescuento = new Label
            {
                Location = new Point(lblClienteNombre.Right + 30, 500),
                AutoSize = true,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold)
            };

            this.Controls.Add(lblCliente);
            this.Controls.Add(lblClienteNombre);
            this.Controls.Add(lblDescuento);

            ActualizarInformacionCliente();
        }
        private void ActualizarInformacionCliente()
        {
            if (_clienteSeleccionado == null)
            {
                lblCliente.Text = "Cliente: ";
                lblCliente.ForeColor = Color.Black;
                lblClienteNombre.Text = "sin seleccionar";
                lblClienteNombre.ForeColor = Color.Red;
                lblDescuento.Text = "Descuento: 0%";
            }
            else
            {
                lblCliente.Text = "Cliente: ";
                lblClienteNombre.Text = $"{_clienteSeleccionado.Nombre} {_clienteSeleccionado.Apellido}";
                lblClienteNombre.ForeColor = Color.Black;
                lblDescuento.Text = $"Descuento: {_clienteSeleccionado.NivelDescuento}%";
            }
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
                    new DataGridViewTextBoxColumn  // Cambiado a TextBoxColumn
                    {
                        Name = "Agregar",
                        HeaderText = "Operacion",
                        Width = 80
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
                    new DataGridViewTextBoxColumn  // Cambiado a TextBoxColumn
                    {
                        Name = "Quitar",
                        HeaderText = "Operacion",
                        Width = 80
                    }
                );
            }

            // Agregar el evento CellFormatting
            datagrid_carrito.CellFormatting += Datagrid_carrito_CellFormatting;
        }
        private void Datagrid_carrito_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Obtener el nombre de la columna de operación según el estado
            string nombreColumnaOperacion = _mostrandoResultadosBusqueda ? "Agregar" : "Quitar";

            // Verificar si la columna existe
            if (datagrid_carrito.Columns[nombreColumnaOperacion] != null &&
                e.ColumnIndex == datagrid_carrito.Columns[nombreColumnaOperacion].Index)
            {
                if (_mostrandoResultadosBusqueda)
                {
                    e.Value = "Agregar";
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.FromArgb(0, 122, 204);
                    e.CellStyle.SelectionForeColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.FromArgb(0, 102, 204);
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    e.Value = "Quitar";
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.SelectionForeColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.DarkRed;
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
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
                                if (cantidadForm.Cantidad <= 0)
                                {
                                    MessageBox.Show("Ingrese una cantidad válida", "Error",
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
                    producto.PrecioProducto.ToString("C", CultureInfo.CreateSpecificCulture("es-AR")),
                    producto.StockDisponible,
                    "Agregar"  // El texto se sobreescribirá en el CellFormatting
                );
            }
        }


        private void datagrid_carrito_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (_mostrandoResultadosBusqueda) return;

            // Verificar si la columna "Cantidad" existe
            if (datagrid_carrito.Columns["Cantidad"] == null) return;

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

                    _debeActualizarCarrito = true;
                }
                catch (Exception ex)
                {
                    e.Cancel = true;
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void datagrid_carrito_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (_debeActualizarCarrito)
            {
                ActualizarCarrito();
                _debeActualizarCarrito = false; // Resetear la bandera
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
                    item.PrecioProducto.ToString("C", CultureInfo.CreateSpecificCulture("es-AR")),
                    item.CantidadProducto,
                    item.Subtotal.ToString("C", CultureInfo.CreateSpecificCulture("es-AR")),
                    "Quitar"  // El texto se sobreescribirá en el CellFormatting
                );
            }
            double total = _carritoBLL.ObtenerTotal();
            if (_clienteSeleccionado != null)
            {
                double descuento = total * (_clienteSeleccionado.NivelDescuento / 100.0);
                total -= descuento;
            }
            lblTotal.Text = $"Total del carro: {_carritoBLL.ObtenerTotal().ToString("C", CultureInfo.CreateSpecificCulture("es-AR"))}";
        }

        private void bConfirmarVenta_Click(object sender, EventArgs e)
        {
            if (!_carritoBLL.ObtenerItems().Any())
            {
                MessageBox.Show("El carrito está vacío", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_clienteSeleccionado == null)
            {
                var result = MessageBox.Show("No hay cliente seleccionado. ¿Desea seleccionar un cliente ahora?",
                    "Cliente requerido", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    btnSeleccionarCliente_Click(sender, e); // Reutilizar el método existente
                    if (_clienteSeleccionado == null) return; // Si no se seleccionó cliente, salir
                }
                else
                {
                    return;
                }
            }


            using (var pasarela = new Pasarela(
                _carritoBLL.ObtenerTotal(),
                _clienteSeleccionado,  // Pasar el cliente seleccionado
                _carritoBLL))          // Pasar el carrito
            {
                if (pasarela.ShowDialog() != DialogResult.OK || !pasarela.PagoConfirmado)
                    return;

                try
                {
                    var ventaBLL = new VentaBLL();
                    // Usar ProcesarVentaCompleta en lugar de ProcesarVenta
                    int idVenta = ventaBLL.ProcesarVentaCompleta(
                        _clienteSeleccionado,
                        pasarela.MetodoPagoSeleccionado,
                        "Venta procesada" // Detalles del pago
                    );

                    using (var formFactura = new ImpresionFactura(
                        _clienteSeleccionado,
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

        private void btnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            using (var menuClienteForm = new menu_cliente(_carritoBLL))
            {
                if (menuClienteForm.ShowDialog() == DialogResult.OK)
                {
                    _clienteSeleccionado = menuClienteForm.ClienteSeleccionado;
                    ActualizarInformacionCliente();
                    ActualizarCarrito();
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