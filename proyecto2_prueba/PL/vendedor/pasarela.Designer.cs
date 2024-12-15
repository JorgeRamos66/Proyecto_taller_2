using Org.BouncyCastle.Asn1.Pkcs;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace proyecto2_prueba.PL.vendedor
{
    partial class Pasarela
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTotal = new System.Windows.Forms.Label();
            this.panelMetodos = new System.Windows.Forms.Panel();
            this.btnTarjeta = new System.Windows.Forms.Button();
            this.btnEfectivo = new System.Windows.Forms.Button();
            this.btnMercadoPago = new System.Windows.Forms.Button();
            this.panelTarjeta = new System.Windows.Forms.Panel();
            this.txtNumeroTarjeta = new System.Windows.Forms.TextBox();
            this.txtVencimiento = new System.Windows.Forms.TextBox();
            this.txtCVV = new System.Windows.Forms.TextBox();
            this.btnConfirmarTarjeta = new System.Windows.Forms.Button();
            this.panelEfectivo = new System.Windows.Forms.Panel();
            this.txtMontoEfectivo = new System.Windows.Forms.TextBox();
            this.lblVuelto = new System.Windows.Forms.Label();
            this.btnConfirmarEfectivo = new System.Windows.Forms.Button();
            this.panelMercadoPago = new System.Windows.Forms.Panel();
            this.picQR = new System.Windows.Forms.PictureBox();
            this.btnConfirmarMP = new System.Windows.Forms.Button();
            this.LPasarela = new System.Windows.Forms.Label();
            this.panelMetodos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
            this.SuspendLayout();
            this.Load += new System.EventHandler(this.Pasarela_Load);
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.Tan;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(20, 20);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(460, 51);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMetodos
            // 
            this.panelMetodos.BackColor = System.Drawing.Color.Tan;
            this.panelMetodos.Controls.Add(this.btnTarjeta);
            this.panelMetodos.Controls.Add(this.btnEfectivo);
            this.panelMetodos.Controls.Add(this.btnMercadoPago);
            this.panelMetodos.Location = new System.Drawing.Point(20, 86);
            this.panelMetodos.Name = "panelMetodos";
            this.panelMetodos.Size = new System.Drawing.Size(460, 100);
            this.panelMetodos.TabIndex = 1;
            // 
            // btnTarjeta
            // 
            this.btnTarjeta.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnTarjeta.Location = new System.Drawing.Point(10, 10);
            this.btnTarjeta.Name = "btnTarjeta";
            this.btnTarjeta.Size = new System.Drawing.Size(140, 80);
            this.btnTarjeta.TabIndex = 0;
            this.btnTarjeta.Text = "Tarjeta";
            this.btnTarjeta.Click += new System.EventHandler(this.btnTarjeta_Click);
            // 
            // btnEfectivo
            // 
            this.btnEfectivo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnEfectivo.Location = new System.Drawing.Point(160, 10);
            this.btnEfectivo.Name = "btnEfectivo";
            this.btnEfectivo.Size = new System.Drawing.Size(140, 80);
            this.btnEfectivo.TabIndex = 1;
            this.btnEfectivo.Text = "Efectivo";
            this.btnEfectivo.Click += new System.EventHandler(this.btnEfectivo_Click);
            // 
            // btnMercadoPago
            // 
            this.btnMercadoPago.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMercadoPago.Location = new System.Drawing.Point(310, 10);
            this.btnMercadoPago.Name = "btnMercadoPago";
            this.btnMercadoPago.Size = new System.Drawing.Size(140, 80);
            this.btnMercadoPago.TabIndex = 2;
            this.btnMercadoPago.Text = "MercadoPago";
            this.btnMercadoPago.Click += new System.EventHandler(this.btnMercadoPago_Click);
            // 
            // panelTarjeta
            // 
            this.panelTarjeta.Location = new System.Drawing.Point(0, 0);
            this.panelTarjeta.Name = "panelTarjeta";
            this.panelTarjeta.Size = new System.Drawing.Size(200, 100);
            this.panelTarjeta.TabIndex = 0;
            // 
            // txtNumeroTarjeta
            // 
            this.txtNumeroTarjeta.Location = new System.Drawing.Point(0, 0);
            this.txtNumeroTarjeta.Name = "txtNumeroTarjeta";
            this.txtNumeroTarjeta.Size = new System.Drawing.Size(100, 20);
            this.txtNumeroTarjeta.TabIndex = 0;
            // 
            // txtVencimiento
            // 
            this.txtVencimiento.Location = new System.Drawing.Point(0, 0);
            this.txtVencimiento.Name = "txtVencimiento";
            this.txtVencimiento.Size = new System.Drawing.Size(100, 20);
            this.txtVencimiento.TabIndex = 0;
            // 
            // txtCVV
            // 
            this.txtCVV.Location = new System.Drawing.Point(0, 0);
            this.txtCVV.Name = "txtCVV";
            this.txtCVV.Size = new System.Drawing.Size(100, 20);
            this.txtCVV.TabIndex = 0;
            // 
            // btnConfirmarTarjeta
            // 
            this.btnConfirmarTarjeta.Location = new System.Drawing.Point(0, 0);
            this.btnConfirmarTarjeta.Name = "btnConfirmarTarjeta";
            this.btnConfirmarTarjeta.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmarTarjeta.TabIndex = 0;
            // 
            // panelEfectivo
            // 
            this.panelEfectivo.Location = new System.Drawing.Point(0, 0);
            this.panelEfectivo.Name = "panelEfectivo";
            this.panelEfectivo.Size = new System.Drawing.Size(200, 100);
            this.panelEfectivo.TabIndex = 0;
            // 
            // txtMontoEfectivo
            // 
            this.txtMontoEfectivo.Location = new System.Drawing.Point(0, 0);
            this.txtMontoEfectivo.Name = "txtMontoEfectivo";
            this.txtMontoEfectivo.Size = new System.Drawing.Size(100, 20);
            this.txtMontoEfectivo.TabIndex = 0;
            // 
            // lblVuelto
            // 
            this.lblVuelto.Location = new System.Drawing.Point(0, 0);
            this.lblVuelto.Name = "lblVuelto";
            this.lblVuelto.Size = new System.Drawing.Size(100, 23);
            this.lblVuelto.TabIndex = 0;
            // 
            // btnConfirmarEfectivo
            // 
            this.btnConfirmarEfectivo.Location = new System.Drawing.Point(0, 0);
            this.btnConfirmarEfectivo.Name = "btnConfirmarEfectivo";
            this.btnConfirmarEfectivo.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmarEfectivo.TabIndex = 0;
            // 
            // panelMercadoPago
            // 
            this.panelMercadoPago.Location = new System.Drawing.Point(0, 0);
            this.panelMercadoPago.Name = "panelMercadoPago";
            this.panelMercadoPago.Size = new System.Drawing.Size(200, 100);
            this.panelMercadoPago.TabIndex = 0;
            // 
            // picQR
            // 
            this.picQR.Location = new System.Drawing.Point(0, 0);
            this.picQR.Name = "picQR";
            this.picQR.Size = new System.Drawing.Size(100, 50);
            this.picQR.TabIndex = 0;
            this.picQR.TabStop = false;
            // 
            // btnConfirmarMP
            // 
            this.btnConfirmarMP.Location = new System.Drawing.Point(0, 0);
            this.btnConfirmarMP.Name = "btnConfirmarMP";
            this.btnConfirmarMP.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmarMP.TabIndex = 0;
            // 
            // LPasarela
            // 
            this.LPasarela.AutoSize = true;
            this.LPasarela.BackColor = System.Drawing.Color.Tan;
            this.LPasarela.Font = new System.Drawing.Font("Microsoft Tai Le", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPasarela.Location = new System.Drawing.Point(104, 28);
            this.LPasarela.Name = "LPasarela";
            this.LPasarela.Size = new System.Drawing.Size(273, 34);
            this.LPasarela.TabIndex = 2;
            this.LPasarela.Text = "PASARELA DE PAGO";
            // 
            // Pasarela
            // 
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(503, 202);
            this.Controls.Add(this.LPasarela);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.panelMetodos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Pasarela";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Método de Pago";
            this.panelMetodos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void Pasarela_Load(object sender, EventArgs e)
        {
            // Establecer StartPosition en Manual
            this.StartPosition = FormStartPosition.Manual;

            // Obtener el tamaño de la pantalla
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            // Calcular el centro de la pantalla y ajustarlo hacia arriba
            int posX = (screenWidth - this.Width) / 2;
            int posY = ((screenHeight - this.Height) / 2) - 200; // Subir 50 píxeles hacia arriba

            // Asignar la nueva posición
            this.Location = new Point(posX, posY);
        }
        private void ConfigurarPanelEfectivo()
        {
            panelEfectivo.Location = new Point(20, 190);
            panelEfectivo.Size = new Size(460, 300);
            panelEfectivo.BorderStyle = BorderStyle.FixedSingle;
            panelEfectivo.BackColor = Color.Tan;

            // Configurar label para monto a pagar
            Label lblMontoAPagar = new Label();
            lblMontoAPagar.Location = new Point(20, 20);
            lblMontoAPagar.Size = new Size(200, 25);
            lblMontoAPagar.Text = "Monto recibido:";
            lblMontoAPagar.Font = new Font("Segoe UI", 12F, FontStyle.Regular);

            // Configurar txtMontoEfectivo
            txtMontoEfectivo.Location = new Point(20, 50);
            txtMontoEfectivo.Size = new Size(200, 30);
            txtMontoEfectivo.Text = "Ingrese el monto";
            txtMontoEfectivo.TextChanged += new EventHandler(txtMontoEfectivo_TextChanged);

            // Configurar lblVuelto
            lblVuelto.Location = new Point(20, 90);
            lblVuelto.Size = new Size(200, 25);
            lblVuelto.Text = "Vuelto: $0.00";
            lblVuelto.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            // Configurar btnConfirmarEfectivo
            btnConfirmarEfectivo.Location = new Point(20, 130);
            btnConfirmarEfectivo.Size = new Size(200, 40);
            btnConfirmarEfectivo.Text = "Confirmar Pago";
            btnConfirmarEfectivo.BackColor = Color.FromArgb(94, 153, 83);
            btnConfirmarEfectivo.ForeColor = Color.White;
            btnConfirmarEfectivo.Click += new EventHandler(btnConfirmarEfectivo_Click);

            // Agregar controles al panel
            panelEfectivo.Controls.Add(lblMontoAPagar);
            panelEfectivo.Controls.Add(txtMontoEfectivo);
            panelEfectivo.Controls.Add(lblVuelto);
            panelEfectivo.Controls.Add(btnConfirmarEfectivo);

            this.Controls.Add(panelEfectivo);
        }

        private void ConfigurarPanelMercadoPago()
        {
            panelMercadoPago.Location = new Point(20, 190);
            panelMercadoPago.Size = new Size(460, 400);
            panelMercadoPago.BorderStyle = BorderStyle.FixedSingle;
            panelMercadoPago.BackColor = Color.Tan;

            // Configurar label de instrucciones
            Label lblInstrucciones = new Label();
            lblInstrucciones.Location = new Point(20, 20);
            lblInstrucciones.Size = new Size(420, 50);
            lblInstrucciones.Text = "Escanee el código QR con la aplicación de MercadoPago";
            lblInstrucciones.Font = new Font("Segoe UI", 12F, FontStyle.Regular);

            // Configurar PictureBox para el código QR
            picQR.Location = new Point(130, 80);
            picQR.Size = new Size(200, 200);
            picQR.SizeMode = PictureBoxSizeMode.StretchImage;
            picQR.BorderStyle = BorderStyle.FixedSingle;
            // Aquí deberías cargar la imagen del QR
            // picQR.Image = Image.FromFile("ruta_a_tu_qr.png");
            // Cargar la imagen del recurso al PictureBox
            picQR.Image = Properties.Resources.scan_afx;

            // Configurar btnConfirmarMP
            btnConfirmarMP.Location = new Point(130, 290);
            btnConfirmarMP.Size = new Size(200, 40);
            btnConfirmarMP.Text = "Confirmar Pago";
            btnConfirmarMP.BackColor = Color.FromArgb(94, 153, 83);
            btnConfirmarMP.ForeColor = Color.White;
            btnConfirmarMP.Click += new EventHandler(btnConfirmarMP_Click);

            // Agregar controles al panel
            panelMercadoPago.Controls.Add(lblInstrucciones);
            panelMercadoPago.Controls.Add(picQR);
            panelMercadoPago.Controls.Add(btnConfirmarMP);

            this.Controls.Add(panelMercadoPago);
        }

        private void ConfigurarPanelTarjeta()
        {
            panelTarjeta.Location = new Point(20, 190);
            panelTarjeta.Size = new Size(460, 300);
            panelTarjeta.BorderStyle = BorderStyle.FixedSingle;
            panelTarjeta.BackColor = Color.Tan;

            // Label para número de tarjeta
            Label lblNumeroTarjeta = new Label();
            lblNumeroTarjeta.Location = new Point(20, 20);
            lblNumeroTarjeta.Size = new Size(200, 25);
            lblNumeroTarjeta.Text = "Número de Tarjeta:";
            lblNumeroTarjeta.Font = new Font("Segoe UI", 12F, FontStyle.Regular);

            // Configurar txtNumeroTarjeta
            txtNumeroTarjeta.Location = new Point(20, 50);
            txtNumeroTarjeta.Size = new Size(300, 30);
            txtNumeroTarjeta.Text = "1234 5678 9012 3456";
            txtNumeroTarjeta.MaxLength = 16;

            // Label para fecha de vencimiento
            Label lblVencimiento = new Label();
            lblVencimiento.Location = new Point(20, 90);
            lblVencimiento.Size = new Size(200, 25);
            lblVencimiento.Text = "Fecha de Vencimiento:";
            lblVencimiento.Font = new Font("Segoe UI", 12F, FontStyle.Regular);

            // Configurar txtVencimiento
            txtVencimiento.Location = new Point(20, 120);
            txtVencimiento.Size = new Size(100, 30);
            txtVencimiento.Text = "MM/YY";
            txtVencimiento.MaxLength = 5;

            // Label para CVV
            Label lblCVV = new Label();
            lblCVV.Location = new Point(140, 90);
            lblCVV.Size = new Size(100, 25);
            lblCVV.Text = "CVV:";
            lblCVV.Font = new Font("Segoe UI", 12F, FontStyle.Regular);

            // Configurar txtCVV
            txtCVV.Location = new Point(140, 120);
            txtCVV.Size = new Size(80, 30);
            txtCVV.Text = "123";
            txtCVV.MaxLength = 3;
            txtCVV.UseSystemPasswordChar = true;

            // Configurar btnConfirmarTarjeta
            btnConfirmarTarjeta.Location = new Point(20, 170);
            btnConfirmarTarjeta.Size = new Size(200, 40);
            btnConfirmarTarjeta.Text = "Confirmar Pago";
            btnConfirmarTarjeta.BackColor = Color.FromArgb(94, 153, 83);
            btnConfirmarTarjeta.ForeColor = Color.White;
            btnConfirmarTarjeta.Click += new EventHandler(btnConfirmarTarjeta_Click);

            // Agregar controles al panel
            panelTarjeta.Controls.Add(lblNumeroTarjeta);
            panelTarjeta.Controls.Add(txtNumeroTarjeta);
            panelTarjeta.Controls.Add(lblVencimiento);
            panelTarjeta.Controls.Add(txtVencimiento);
            panelTarjeta.Controls.Add(lblCVV);
            panelTarjeta.Controls.Add(txtCVV);
            panelTarjeta.Controls.Add(btnConfirmarTarjeta);

            this.Controls.Add(panelTarjeta);
        }

        private Label lblTotal;
        private Panel panelMetodos;
        private Button btnTarjeta;
        private Button btnEfectivo;
        private Button btnMercadoPago;
        private Panel panelTarjeta;
        private TextBox txtNumeroTarjeta;
        private TextBox txtVencimiento;
        private TextBox txtCVV;
        private Button btnConfirmarTarjeta;
        private Panel panelEfectivo;
        private TextBox txtMontoEfectivo;
        private Label lblVuelto;
        private Button btnConfirmarEfectivo;
        private Panel panelMercadoPago;
        private PictureBox picQR;
        private Button btnConfirmarMP;
        private Label LPasarela;
    }
}