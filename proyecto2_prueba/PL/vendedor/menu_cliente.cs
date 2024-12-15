using System;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using ML;
using proyecto2_prueba.Presentaciones.vendedor;

namespace proyecto2_prueba.PL.vendedor
{
    public partial class menu_cliente : Form
    {
        private readonly ClienteBLL _clienteBLL;
        private readonly CarritoBLL _carritoBLL;
        private readonly VentaBLL _ventaBLL;
        private readonly bool _esVentaDirecta;
        private const string TEXTO_BUSQUEDA_DEFAULT = "Ingrese Nombre, Apellido o DNI";
        private bool _ignorarEventoTextChanged = false;

        public bool VentaRealizada { get; private set; }
        public Cliente ClienteSeleccionado { get; private set; }

        public menu_cliente()
        {
            InitializeComponent();
            _clienteBLL = new ClienteBLL();
            _carritoBLL = null;
            _ventaBLL = new VentaBLL();
            _esVentaDirecta = false;
            ConfigurarFormulario();
        }

        public menu_cliente(CarritoBLL carritoBLL = null)
        {
            InitializeComponent();
            _clienteBLL = new ClienteBLL();
            _carritoBLL = carritoBLL;
            _ventaBLL = new VentaBLL();
            _esVentaDirecta = carritoBLL != null;
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            ConfigurarDataGridView();

            textBoxIdAuxiliar.Text = "0";

            // Configuración inicial del TextBox de búsqueda
            txtBuscar.Text = TEXTO_BUSQUEDA_DEFAULT;
            txtBuscar.ForeColor = Color.Gray;

            this.Load += menu_cliente_Load;
            this.txtBuscar.TextChanged += TxtBuscar_TextChanged;
            this.txtBuscar.Enter += TxtBuscar_Enter;
            this.txtBuscar.Leave += TxtBuscar_Leave;
            this.dgvClientes.CellFormatting += DgvClientes_CellFormatting;

            txtNombre.KeyPress += SoloLetras_KeyPress;
            txtApellido.KeyPress += SoloLetras_KeyPress;
            txtProvincia.KeyPress += SoloLetras_KeyPress;
            txtLocalidad.KeyPress += SoloLetras_KeyPress;
            txtDni.KeyPress += SoloNumeros_KeyPress;

            // Validar fecha de nacimiento
            dtpFechaNacimiento.ValueChanged += DtpFechaNacimiento_ValueChanged;
            dtpFechaNacimiento.MaxDate = DateTime.Today;
        }

        private void ConfigurarDataGridView()
        {
            dgvClientes.Columns.Clear();
            dgvClientes.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", Visible = false },
                new DataGridViewTextBoxColumn { Name = "Nombre", HeaderText = "Nombre", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "Apellido", HeaderText = "Apellido", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "Dni", HeaderText = "DNI", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "Nivel", HeaderText = "Nivel", Width = 50 },
                new DataGridViewTextBoxColumn { Name = "Descuento", HeaderText = "Descuento", Width = 80 },
                new DataGridViewTextBoxColumn { Name = "Seleccionar", HeaderText = "Acción", Width = 80 }
            );
        }

        private void DgvClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvClientes.Columns["Seleccionar"].Index)
            {
                e.Value = "Seleccionar";
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.BackColor = Color.FromArgb(0, 122, 204);
                e.CellStyle.SelectionForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(0, 102, 204);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void menu_cliente_Load(object sender, EventArgs e)
        {
            try
            {
                MostrarClientes(string.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}");
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (_ignorarEventoTextChanged) return;

            string filtro = txtBuscar.Text;
            if (filtro == TEXTO_BUSQUEDA_DEFAULT)
            {
                filtro = string.Empty;
            }
            MostrarClientes(filtro);
        }

        private void MostrarClientes(string filtro)
        {
            try
            {
                var clientes = _clienteBLL.ObtenerClientesFiltrados(filtro);
                dgvClientes.Rows.Clear();

                foreach (var cliente in clientes)
                {
                    dgvClientes.Rows.Add(
                        cliente.Id,
                        cliente.Nombre,
                        cliente.Apellido,
                        cliente.Dni,
                        cliente.NombreNivel,
                        $"{cliente.NivelDescuento}%",
                        "Seleccionar"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar clientes: {ex.Message}");
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvClientes.Columns["Seleccionar"].Index && e.RowIndex >= 0)
            {
                int idCliente = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells["Id"].Value);
                CargarDatosCliente(idCliente);

                ClienteSeleccionado = _clienteBLL.ObtenerClientePorId(idCliente);

                if (_carritoBLL != null)
                {
                    // Si venimos del carrito, aplicamos el descuento y volvemos
                    _carritoBLL.AplicarDescuento(ClienteSeleccionado.NivelDescuento);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    // Si no hay carrito, creamos uno nuevo y abrimos la vista del carrito
                    var nuevoCarrito = new carrito();
                    nuevoCarrito.EstablecerCliente(ClienteSeleccionado);
                    this.Hide();
                    nuevoCarrito.ShowDialog();
                    this.Close();
                }
            }
        }
        private void CargarDatosCliente(int idCliente)
        {
            try
            {
                var cliente = _clienteBLL.ObtenerClientePorId(idCliente);
                if (cliente != null)
                {
                    ClienteSeleccionado = cliente; // Actualizar ClienteSeleccionado
                    textBoxIdAuxiliar.Text = cliente.Id.ToString();
                    txtNombre.Text = cliente.Nombre;
                    txtApellido.Text = cliente.Apellido;
                    txtDni.Text = cliente.Dni.ToString();
                    txtEmail.Text = cliente.Email;
                    txtDomicilio.Text = cliente.Direccion;
                    txtLocalidad.Text = cliente.Localidad;
                    txtProvincia.Text = cliente.Provincia;
                    dtpFechaNacimiento.Value = cliente.FechaNacimiento;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos del cliente: {ex.Message}");
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDni.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtDomicilio.Text) ||
                string.IsNullOrWhiteSpace(txtLocalidad.Text) ||
                string.IsNullOrWhiteSpace(txtProvincia.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return false;
            }

            if (!int.TryParse(txtDni.Text, out _))
            {
                MessageBox.Show("El DNI debe ser un número válido.");
                return false;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("El formato del correo electrónico no es válido.");
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private Cliente ObtenerClienteDesdeFormulario()
        {
            return new Cliente
            {
                Id = int.Parse(textBoxIdAuxiliar.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Dni = int.Parse(txtDni.Text),
                Email = txtEmail.Text,
                Direccion = txtDomicilio.Text,
                Localidad = txtLocalidad.Text,
                Provincia = txtProvincia.Text,
                FechaNacimiento = dtpFechaNacimiento.Value,
                IdNivel = 1  // Nivel por defecto para nuevos clientes
            };
        }

        private void LimpiarCampos()
        {
            _ignorarEventoTextChanged = true;
            txtBuscar.Text = TEXTO_BUSQUEDA_DEFAULT;
            txtBuscar.ForeColor = Color.Gray;
            _ignorarEventoTextChanged = false;
            MostrarClientes(string.Empty); // Mostrar todos los clientes
        }

        private void LimpiarFormularioRegistro()
        {
            textBoxIdAuxiliar.Text = "0";
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtDni.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDomicilio.Text = string.Empty;
            txtLocalidad.Text = string.Empty;
            txtProvincia.Text = string.Empty;
            dtpFechaNacimiento.Value = DateTime.Today;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == TEXTO_BUSQUEDA_DEFAULT)
            {
                _ignorarEventoTextChanged = true;
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.Black;
                _ignorarEventoTextChanged = false;
            }
        }

        private void TxtBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                _ignorarEventoTextChanged = true;
                txtBuscar.Text = TEXTO_BUSQUEDA_DEFAULT;
                txtBuscar.ForeColor = Color.Gray;
                _ignorarEventoTextChanged = false;
                MostrarClientes(string.Empty); // Mostrar todos los clientes
            }
        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea salir?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void BRegistrarCliente_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                var cliente = ObtenerClienteDesdeFormulario();
                _clienteBLL.GuardarCliente(cliente);

                // Obtener el cliente recién guardado con todos sus datos
                ClienteSeleccionado = _clienteBLL.ObtenerClientePorDni(cliente.Dni);

                if (_carritoBLL != null)
                {
                    // Si venimos del carrito, aplicamos el descuento y volvemos
                    _carritoBLL.AplicarDescuento(ClienteSeleccionado.NivelDescuento);
                    MessageBox.Show("Cliente registrado exitosamente.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    // Si estamos en la vista de clientes, actualizamos el formulario
                    MessageBox.Show("Cliente registrado exitosamente.");
                    LimpiarFormularioRegistro();
                    MostrarClientes(string.Empty); // Actualizar el grid
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar cliente: {ex.Message}");
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

        private void SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir letras, espacios y teclas de control (como backspace)
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Cancelar el carácter
                                  // Opcional: Mostrar un tooltip o mensaje
                ToolTip toolTip = new ToolTip();
                toolTip.Show("Solo se permiten letras y espacios", (TextBox)sender, 0, -20, 1000);
            }
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                ToolTip toolTip = new ToolTip();
                toolTip.Show("Solo se permiten números", (TextBox)sender, 0, -20, 1000);
            }
            else if (sender is TextBox txtDni && char.IsDigit(e.KeyChar))
            {
                // Verificar longitud máxima del DNI
                if (txtDni.Text.Length >= 8 && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                    ToolTip toolTip = new ToolTip();
                    toolTip.Show("El DNI no puede tener más de 8 dígitos", txtDni, 0, -20, 1000);
                }
            }
        }

        private void DtpFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaNacimiento.Value > DateTime.Today)
            {
                MessageBox.Show("No se puede seleccionar una fecha futura.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpFechaNacimiento.Value = DateTime.Today;
            }
        }
    }
}