using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace proyecto2_prueba.PL.vendedor
{
    public partial class Pasarela : Form
    {
        public int MetodoPagoSeleccionado { get; private set; }
        public bool PagoConfirmado { get; private set; }
        private readonly double _totalVenta;

        public Pasarela(double totalVenta)
        {
            InitializeComponent();
            _totalVenta = totalVenta;
            ConfigurarFormulario();
            // Configurar paneles de pago
            ConfigurarPanelTarjeta();
            ConfigurarPanelEfectivo();
            ConfigurarPanelMercadoPago();
        }

        private void ConfigurarFormulario()
        {
            lblTotal.Text = $"Total a pagar: {_totalVenta:C}";
            panelTarjeta.Visible = false;
            panelMercadoPago.Visible = false;
            panelEfectivo.Visible = false;
        }

        private void btnTarjeta_Click(object sender, EventArgs e)
        {
            panelTarjeta.Visible = true;
            panelMercadoPago.Visible = false;
            panelEfectivo.Visible = false;
            MetodoPagoSeleccionado = 1; // ID método pago tarjeta
        }

        private void btnEfectivo_Click(object sender, EventArgs e)
        {
            panelTarjeta.Visible = false;
            panelMercadoPago.Visible = false;
            panelEfectivo.Visible = true;
            MetodoPagoSeleccionado = 2; // ID método pago efectivo
        }

        private void btnMercadoPago_Click(object sender, EventArgs e)
        {
            panelTarjeta.Visible = false;
            panelMercadoPago.Visible = true;
            panelEfectivo.Visible = false;
            MetodoPagoSeleccionado = 3; // ID método pago MercadoPago
        }

        private void btnConfirmarTarjeta_Click(object sender, EventArgs e)
        {
            if (ValidarDatosTarjeta())
            {
                PagoConfirmado = true;
                this.Close();
            }
        }

        private void btnConfirmarEfectivo_Click(object sender, EventArgs e)
        {
            if (ValidarMontoEfectivo())
            {
                PagoConfirmado = true;
                this.Close();
            }
        }

        private void btnConfirmarMP_Click(object sender, EventArgs e)
        {
            // Aquí iría la lógica de verificación del pago con MercadoPago
            MessageBox.Show("Pago confirmado con MercadoPago", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            PagoConfirmado = true;
            this.Close();
        }

        private bool ValidarDatosTarjeta()
        {
            if (string.IsNullOrWhiteSpace(txtNumeroTarjeta.Text) ||
                string.IsNullOrWhiteSpace(txtVencimiento.Text) ||
                string.IsNullOrWhiteSpace(txtCVV.Text))
            {
                MessageBox.Show("Por favor complete todos los campos de la tarjeta",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Aquí irían más validaciones de tarjeta
            return true;
        }

        private bool ValidarMontoEfectivo()
        {
            if (!double.TryParse(txtMontoEfectivo.Text, out double monto))
            {
                MessageBox.Show("Por favor ingrese un monto válido",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (monto < _totalVenta)
            {
                MessageBox.Show("El monto ingresado es menor al total de la venta",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            double vuelto = monto - _totalVenta;
            lblVuelto.Text = $"Vuelto: {vuelto.ToString("C", CultureInfo.CreateSpecificCulture("es-AR"))}";
            return true;
        }

        private void txtMontoEfectivo_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtMontoEfectivo.Text, out double monto))
            {
                double vuelto = monto - _totalVenta;
                lblVuelto.Text = $"Vuelto: {vuelto.ToString("C", CultureInfo.CreateSpecificCulture("es-AR"))}";
            }
            else
            {
                lblVuelto.Text = "Vuelto: $0.00";
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