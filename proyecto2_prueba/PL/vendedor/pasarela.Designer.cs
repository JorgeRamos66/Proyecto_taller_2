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
            // 
            // btnEfectivo
            // 
            this.btnEfectivo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnEfectivo.Location = new System.Drawing.Point(160, 10);
            this.btnEfectivo.Name = "btnEfectivo";
            this.btnEfectivo.Size = new System.Drawing.Size(140, 80);
            this.btnEfectivo.TabIndex = 1;
            this.btnEfectivo.Text = "Efectivo";
            // 
            // btnMercadoPago
            // 
            this.btnMercadoPago.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMercadoPago.Location = new System.Drawing.Point(310, 10);
            this.btnMercadoPago.Name = "btnMercadoPago";
            this.btnMercadoPago.Size = new System.Drawing.Size(140, 80);
            this.btnMercadoPago.TabIndex = 2;
            this.btnMercadoPago.Text = "MercadoPago";
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
            this.ClientSize = new System.Drawing.Size(503, 561);
            this.Controls.Add(this.LPasarela);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.panelMetodos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Pasarela";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Método de Pago";
            this.panelMetodos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ConfigurarPanelTarjeta()
        {
            panelTarjeta.Location = new Point(20, 190);
            panelTarjeta.Size = new Size(460, 300);
            panelTarjeta.BorderStyle = BorderStyle.FixedSingle;

            // Configurar controles del panel tarjeta
            // ... (configuración detallada de los controles)

            this.Controls.Add(panelTarjeta);
        }

        private void ConfigurarPanelEfectivo()
        {
            panelEfectivo.Location = new Point(20, 190);
            panelEfectivo.Size = new Size(460, 300);
            panelEfectivo.BorderStyle = BorderStyle.FixedSingle;

            // Configurar controles del panel efectivo
            // ... (configuración detallada de los controles)

            this.Controls.Add(panelEfectivo);
        }

        private void ConfigurarPanelMercadoPago()
        {
            panelMercadoPago.Location = new Point(20, 190);
            panelMercadoPago.Size = new Size(460, 300);
            panelMercadoPago.BorderStyle = BorderStyle.FixedSingle;

            // Configurar controles del panel MercadoPago
            // ... (configuración detallada de los controles)

            this.Controls.Add(panelMercadoPago);
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