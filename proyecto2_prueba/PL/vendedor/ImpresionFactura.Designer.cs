using System.Windows.Forms;

namespace proyecto2_prueba.PL.vendedor
{
    partial class ImpresionFactura
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNumeroVenta = new System.Windows.Forms.Label();
            this.lblFechaVenta = new System.Windows.Forms.Label();
            this.gbDatosCliente = new System.Windows.Forms.GroupBox();
            this.lblTituloNombre = new System.Windows.Forms.Label();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.lblDniCliente = new System.Windows.Forms.Label();
            this.lblDireccionCliente = new System.Windows.Forms.Label();
            this.lblLocalidadCliente = new System.Windows.Forms.Label();
            this.lblProvinciaCliente = new System.Windows.Forms.Label();
            this.lblEmailCliente = new System.Windows.Forms.Label();
            this.lblTituloDni = new System.Windows.Forms.Label();
            this.lblTituloDireccion = new System.Windows.Forms.Label();
            this.lblTituloLocalidad = new System.Windows.Forms.Label();
            this.lblTituloProvincia = new System.Windows.Forms.Label();
            this.lblTituloEmail = new System.Windows.Forms.Label();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.lblTituloTotal = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.gbDatosCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(170, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Factura de Venta";
            // 
            // lblNumeroVenta
            // 
            this.lblNumeroVenta.AutoSize = true;
            this.lblNumeroVenta.Location = new System.Drawing.Point(14, 40);
            this.lblNumeroVenta.Name = "lblNumeroVenta";
            this.lblNumeroVenta.Size = new System.Drawing.Size(0, 13);
            this.lblNumeroVenta.TabIndex = 1;
            // 
            // lblFechaVenta
            // 
            this.lblFechaVenta.AutoSize = true;
            this.lblFechaVenta.Location = new System.Drawing.Point(400, 40);
            this.lblFechaVenta.Name = "lblFechaVenta";
            this.lblFechaVenta.Size = new System.Drawing.Size(0, 13);
            this.lblFechaVenta.TabIndex = 2;
            // 
            // gbDatosCliente
            // 
            this.gbDatosCliente.Controls.Add(this.lblTituloNombre);
            this.gbDatosCliente.Controls.Add(this.lblNombreCliente);
            this.gbDatosCliente.Location = new System.Drawing.Point(12, 70);
            this.gbDatosCliente.Name = "gbDatosCliente";
            this.gbDatosCliente.Size = new System.Drawing.Size(560, 150);
            this.gbDatosCliente.TabIndex = 3;
            this.gbDatosCliente.TabStop = false;
            this.gbDatosCliente.Text = "Datos del Cliente";
            // 
            // lblTituloNombre
            // 
            this.lblTituloNombre.AutoSize = true;
            this.lblTituloNombre.Location = new System.Drawing.Point(6, 25);
            this.lblTituloNombre.Name = "lblTituloNombre";
            this.lblTituloNombre.Size = new System.Drawing.Size(47, 13);
            this.lblTituloNombre.TabIndex = 0;
            this.lblTituloNombre.Text = "Nombre:";
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Location = new System.Drawing.Point(100, 25);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(0, 13);
            this.lblNombreCliente.TabIndex = 1;
            // 
            // lblDniCliente
            // 
            this.lblDniCliente.Location = new System.Drawing.Point(0, 0);
            this.lblDniCliente.Name = "lblDniCliente";
            this.lblDniCliente.Size = new System.Drawing.Size(100, 23);
            this.lblDniCliente.TabIndex = 0;
            // 
            // lblDireccionCliente
            // 
            this.lblDireccionCliente.Location = new System.Drawing.Point(0, 0);
            this.lblDireccionCliente.Name = "lblDireccionCliente";
            this.lblDireccionCliente.Size = new System.Drawing.Size(100, 23);
            this.lblDireccionCliente.TabIndex = 0;
            // 
            // lblLocalidadCliente
            // 
            this.lblLocalidadCliente.Location = new System.Drawing.Point(0, 0);
            this.lblLocalidadCliente.Name = "lblLocalidadCliente";
            this.lblLocalidadCliente.Size = new System.Drawing.Size(100, 23);
            this.lblLocalidadCliente.TabIndex = 0;
            // 
            // lblProvinciaCliente
            // 
            this.lblProvinciaCliente.Location = new System.Drawing.Point(0, 0);
            this.lblProvinciaCliente.Name = "lblProvinciaCliente";
            this.lblProvinciaCliente.Size = new System.Drawing.Size(100, 23);
            this.lblProvinciaCliente.TabIndex = 0;
            // 
            // lblEmailCliente
            // 
            this.lblEmailCliente.Location = new System.Drawing.Point(0, 0);
            this.lblEmailCliente.Name = "lblEmailCliente";
            this.lblEmailCliente.Size = new System.Drawing.Size(100, 23);
            this.lblEmailCliente.TabIndex = 0;
            // 
            // lblTituloDni
            // 
            this.lblTituloDni.Location = new System.Drawing.Point(0, 0);
            this.lblTituloDni.Name = "lblTituloDni";
            this.lblTituloDni.Size = new System.Drawing.Size(100, 23);
            this.lblTituloDni.TabIndex = 0;
            // 
            // lblTituloDireccion
            // 
            this.lblTituloDireccion.Location = new System.Drawing.Point(0, 0);
            this.lblTituloDireccion.Name = "lblTituloDireccion";
            this.lblTituloDireccion.Size = new System.Drawing.Size(100, 23);
            this.lblTituloDireccion.TabIndex = 0;
            // 
            // lblTituloLocalidad
            // 
            this.lblTituloLocalidad.Location = new System.Drawing.Point(0, 0);
            this.lblTituloLocalidad.Name = "lblTituloLocalidad";
            this.lblTituloLocalidad.Size = new System.Drawing.Size(100, 23);
            this.lblTituloLocalidad.TabIndex = 0;
            // 
            // lblTituloProvincia
            // 
            this.lblTituloProvincia.Location = new System.Drawing.Point(0, 0);
            this.lblTituloProvincia.Name = "lblTituloProvincia";
            this.lblTituloProvincia.Size = new System.Drawing.Size(100, 23);
            this.lblTituloProvincia.TabIndex = 0;
            // 
            // lblTituloEmail
            // 
            this.lblTituloEmail.Location = new System.Drawing.Point(0, 0);
            this.lblTituloEmail.Name = "lblTituloEmail";
            this.lblTituloEmail.Size = new System.Drawing.Size(100, 23);
            this.lblTituloEmail.TabIndex = 0;
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.Location = new System.Drawing.Point(12, 230);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.Size = new System.Drawing.Size(560, 200);
            this.dgvProductos.TabIndex = 4;
            // 
            // lblTituloTotal
            // 
            this.lblTituloTotal.AutoSize = true;
            this.lblTituloTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloTotal.Location = new System.Drawing.Point(400, 440);
            this.lblTituloTotal.Name = "lblTituloTotal";
            this.lblTituloTotal.Size = new System.Drawing.Size(54, 20);
            this.lblTituloTotal.TabIndex = 5;
            this.lblTituloTotal.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(460, 440);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 20);
            this.lblTotal.TabIndex = 6;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(12, 470);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(100, 30);
            this.btnImprimir.TabIndex = 7;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(472, 470);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 30);
            this.btnCerrar.TabIndex = 8;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // ImpresionFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(584, 512);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblNumeroVenta);
            this.Controls.Add(this.lblFechaVenta);
            this.Controls.Add(this.gbDatosCliente);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.lblTituloTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ImpresionFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.gbDatosCliente.ResumeLayout(false);
            this.gbDatosCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNumeroVenta;
        private System.Windows.Forms.Label lblFechaVenta;
        private System.Windows.Forms.GroupBox gbDatosCliente;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.Label lblDniCliente;
        private System.Windows.Forms.Label lblDireccionCliente;
        private System.Windows.Forms.Label lblLocalidadCliente;
        private System.Windows.Forms.Label lblProvinciaCliente;
        private System.Windows.Forms.Label lblEmailCliente;
        private System.Windows.Forms.Label lblTituloNombre;
        private System.Windows.Forms.Label lblTituloDni;
        private System.Windows.Forms.Label lblTituloDireccion;
        private System.Windows.Forms.Label lblTituloLocalidad;
        private System.Windows.Forms.Label lblTituloProvincia;
        private System.Windows.Forms.Label lblTituloEmail;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Label lblTituloTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnCerrar;
    }
}