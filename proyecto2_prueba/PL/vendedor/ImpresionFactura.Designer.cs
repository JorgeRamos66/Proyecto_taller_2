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
            this.components = new System.ComponentModel.Container();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNumeroVenta = new System.Windows.Forms.Label();
            this.lblFechaVenta = new System.Windows.Forms.Label();

            // Grupo de datos del cliente
            this.gbDatosCliente = new System.Windows.Forms.GroupBox();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.lblDniCliente = new System.Windows.Forms.Label();
            this.lblDireccionCliente = new System.Windows.Forms.Label();
            this.lblLocalidadCliente = new System.Windows.Forms.Label();
            this.lblProvinciaCliente = new System.Windows.Forms.Label();
            this.lblEmailCliente = new System.Windows.Forms.Label();

            // Labels de títulos
            this.lblTituloNombre = new System.Windows.Forms.Label();
            this.lblTituloDni = new System.Windows.Forms.Label();
            this.lblTituloDireccion = new System.Windows.Forms.Label();
            this.lblTituloLocalidad = new System.Windows.Forms.Label();
            this.lblTituloProvincia = new System.Windows.Forms.Label();
            this.lblTituloEmail = new System.Windows.Forms.Label();

            // DataGridView para productos
            this.dgvProductos = new System.Windows.Forms.DataGridView();

            // Total y botones
            this.lblTituloTotal = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();

            // Configuración de componentes
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(200, 24);
            this.lblTitulo.Text = "Factura de Venta";

            // lblNumeroVenta
            this.lblNumeroVenta.AutoSize = true;
            this.lblNumeroVenta.Location = new System.Drawing.Point(14, 40);
            this.lblNumeroVenta.Name = "lblNumeroVenta";
            this.lblNumeroVenta.Size = new System.Drawing.Size(100, 13);

            // lblFechaVenta
            this.lblFechaVenta.AutoSize = true;
            this.lblFechaVenta.Location = new System.Drawing.Point(400, 40);
            this.lblFechaVenta.Name = "lblFechaVenta";
            this.lblFechaVenta.Size = new System.Drawing.Size(100, 13);

            // gbDatosCliente
            this.gbDatosCliente.Location = new System.Drawing.Point(12, 70);
            this.gbDatosCliente.Name = "gbDatosCliente";
            this.gbDatosCliente.Size = new System.Drawing.Size(560, 150);
            this.gbDatosCliente.Text = "Datos del Cliente";

            // Labels de títulos dentro del GroupBox
            this.lblTituloNombre.AutoSize = true;
            this.lblTituloNombre.Location = new System.Drawing.Point(6, 25);
            this.lblTituloNombre.Text = "Nombre:";

            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Location = new System.Drawing.Point(100, 25);

            // ... (configuración similar para los demás labels)

            // dgvProductos
            this.dgvProductos.Location = new System.Drawing.Point(12, 230);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.Size = new System.Drawing.Size(560, 200);
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.ReadOnly = true;

            // Total
            this.lblTituloTotal.AutoSize = true;
            this.lblTituloTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloTotal.Location = new System.Drawing.Point(400, 440);
            this.lblTituloTotal.Text = "Total:";

            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(460, 440);

            // Botones
            this.btnImprimir.Location = new System.Drawing.Point(12, 470);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(100, 30);
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);

            this.btnCerrar.Location = new System.Drawing.Point(472, 470);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 30);
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 512);

            // Agregar controles al form
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblNumeroVenta);
            this.Controls.Add(this.lblFechaVenta);
            this.Controls.Add(this.gbDatosCliente);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.lblTituloTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnCerrar);

            // Agregar controles al GroupBox
            this.gbDatosCliente.Controls.Add(this.lblTituloNombre);
            this.gbDatosCliente.Controls.Add(this.lblNombreCliente);
            // ... (agregar los demás controles al GroupBox)

            this.Name = "ImpresionFactura";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Impresión de Factura";
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