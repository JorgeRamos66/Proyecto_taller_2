using System;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using ML;

namespace proyecto2_prueba.PL.vendedor
{
    public partial class menu_cliente : Form
    {
        private readonly ClienteBLL _clienteBLL;
        private readonly CarritoBLL _carritoBLL;
        private readonly VentaBLL _ventaBLL;
        private readonly bool _esVentaDirecta;
        public bool VentaRealizada { get; private set; }

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
            bConfirmarVenta.Visible = _esVentaDirecta;
            textBoxIdAuxiliar.Text = "0";
            this.Load += menu_cliente_Load;
            this.txtBuscar.TextChanged += TxtBuscar_TextChanged;
            this.txtBuscar.Enter += TxtBuscar_Enter;
            this.txtBuscar.Leave += TxtBuscar_Leave;
            this.BCancelar.Click += BSalir_Click;
            this.BConfirmar.Click += BConfirmar_Click;
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
            MostrarClientes(txtBuscar.Text);
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
            }
        }

        private void CargarDatosCliente(int idCliente)
        {
            try
            {
                var cliente = _clienteBLL.ObtenerClientePorId(idCliente);
                if (cliente != null)
                {
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                var cliente = ObtenerClienteDesdeFormulario();
                _clienteBLL.GuardarCliente(cliente);

                if (_esVentaDirecta)
                {
                    int idVenta = _ventaBLL.ProcesarVenta(cliente.Id, 1); // 1 = método de pago predeterminado
                    var formFactura = new ImpresionFactura(cliente, _carritoBLL.ObtenerItems(), idVenta);
                    formFactura.ShowDialog();
                    VentaRealizada = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cliente guardado exitosamente.");
                    LimpiarCampos();
                    MostrarClientes(string.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
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
                FechaNacimiento = dtpFechaNacimiento.Value
            };
        }

        private void LimpiarCampos()
        {
            textBoxIdAuxiliar.Text = "0";
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtDni.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDomicilio.Text = string.Empty;
            txtLocalidad.Text = string.Empty;
            txtProvincia.Text = string.Empty;
            dtpFechaNacimiento.Value = DateTime.Now;
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
            if (txtBuscar.Text == "Buscar...")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.Black;
            }
        }

        private void TxtBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.Text = "Buscar...";
                txtBuscar.ForeColor = Color.Gray;
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

        private void BConfirmar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                var cliente = ObtenerClienteDesdeFormulario();
                _clienteBLL.GuardarCliente(cliente);

                if (_esVentaDirecta)
                {
                    int idVenta = _ventaBLL.ProcesarVenta(cliente.Id, 1); // 1 = método de pago predeterminado
                    var formFactura = new ImpresionFactura(cliente, _carritoBLL.ObtenerItems(), idVenta);
                    formFactura.ShowDialog();
                    VentaRealizada = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cliente guardado exitosamente.");
                    LimpiarCampos();
                    MostrarClientes(string.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
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
    }
}