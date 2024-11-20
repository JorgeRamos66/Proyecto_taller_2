namespace proyecto2_prueba.Presentaciones.vendedor
{
    partial class ventas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BLimpiarCarrito = new System.Windows.Forms.Button();
            this.bConfirmarVenta = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LHistorialVentas = new System.Windows.Forms.Label();
            this.datagrid_carrito = new System.Windows.Forms.DataGridView();
            this.CIdVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CFechaVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMontoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.LFechaInicio = new System.Windows.Forms.Label();
            this.LFechaFin = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_carrito)).BeginInit();
            this.SuspendLayout();
            // 
            // BLimpiarCarrito
            // 
            this.BLimpiarCarrito.BackColor = System.Drawing.Color.Red;
            this.BLimpiarCarrito.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BLimpiarCarrito.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BLimpiarCarrito.Location = new System.Drawing.Point(870, 75);
            this.BLimpiarCarrito.Name = "BLimpiarCarrito";
            this.BLimpiarCarrito.Size = new System.Drawing.Size(113, 34);
            this.BLimpiarCarrito.TabIndex = 20;
            this.BLimpiarCarrito.Text = "Limpiar Carrito";
            this.BLimpiarCarrito.UseVisualStyleBackColor = false;
            // 
            // bConfirmarVenta
            // 
            this.bConfirmarVenta.BackColor = System.Drawing.Color.ForestGreen;
            this.bConfirmarVenta.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bConfirmarVenta.ForeColor = System.Drawing.SystemColors.Control;
            this.bConfirmarVenta.Location = new System.Drawing.Point(751, 75);
            this.bConfirmarVenta.Name = "bConfirmarVenta";
            this.bConfirmarVenta.Size = new System.Drawing.Size(113, 33);
            this.bConfirmarVenta.TabIndex = 19;
            this.bConfirmarVenta.Text = "Confirmar Venta";
            this.bConfirmarVenta.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.LHistorialVentas);
            this.panel1.Location = new System.Drawing.Point(319, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 56);
            this.panel1.TabIndex = 16;
            // 
            // LHistorialVentas
            // 
            this.LHistorialVentas.AutoSize = true;
            this.LHistorialVentas.Font = new System.Drawing.Font("Microsoft Tai Le", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LHistorialVentas.Location = new System.Drawing.Point(6, 9);
            this.LHistorialVentas.Name = "LHistorialVentas";
            this.LHistorialVentas.Size = new System.Drawing.Size(307, 34);
            this.LHistorialVentas.TabIndex = 1;
            this.LHistorialVentas.Text = "HISTORIAL DE VENTAS";
            // 
            // datagrid_carrito
            // 
            this.datagrid_carrito.AllowUserToAddRows = false;
            this.datagrid_carrito.AllowUserToOrderColumns = true;
            this.datagrid_carrito.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.datagrid_carrito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.datagrid_carrito.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.datagrid_carrito.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.datagrid_carrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid_carrito.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CIdVenta,
            this.CFechaVenta,
            this.CMontoTotal,
            this.CCliente,
            this.CFactura});
            this.datagrid_carrito.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.datagrid_carrito.Location = new System.Drawing.Point(12, 114);
            this.datagrid_carrito.Name = "datagrid_carrito";
            this.datagrid_carrito.RowTemplate.Height = 50;
            this.datagrid_carrito.Size = new System.Drawing.Size(971, 371);
            this.datagrid_carrito.TabIndex = 15;
            // 
            // CIdVenta
            // 
            this.CIdVenta.HeaderText = "ID Venta";
            this.CIdVenta.Name = "CIdVenta";
            this.CIdVenta.ReadOnly = true;
            // 
            // CFechaVenta
            // 
            this.CFechaVenta.HeaderText = "Fecha de la venta";
            this.CFechaVenta.Name = "CFechaVenta";
            this.CFechaVenta.ReadOnly = true;
            // 
            // CMontoTotal
            // 
            this.CMontoTotal.HeaderText = "Monto Total";
            this.CMontoTotal.Name = "CMontoTotal";
            this.CMontoTotal.ReadOnly = true;
            // 
            // CCliente
            // 
            this.CCliente.HeaderText = "Nombre Cliente";
            this.CCliente.Name = "CCliente";
            this.CCliente.ReadOnly = true;
            // 
            // CFactura
            // 
            this.CFactura.HeaderText = "Factura";
            this.CFactura.Name = "CFactura";
            this.CFactura.ReadOnly = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(137, 88);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 21;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(505, 89);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 22;
            // 
            // LFechaInicio
            // 
            this.LFechaInicio.AutoSize = true;
            this.LFechaInicio.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaInicio.Location = new System.Drawing.Point(51, 89);
            this.LFechaInicio.Name = "LFechaInicio";
            this.LFechaInicio.Size = new System.Drawing.Size(80, 16);
            this.LFechaInicio.TabIndex = 28;
            this.LFechaInicio.Text = "Fecha Inicio";
            // 
            // LFechaFin
            // 
            this.LFechaFin.AutoSize = true;
            this.LFechaFin.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaFin.Location = new System.Drawing.Point(403, 92);
            this.LFechaFin.Name = "LFechaFin";
            this.LFechaFin.Size = new System.Drawing.Size(65, 16);
            this.LFechaFin.TabIndex = 29;
            this.LFechaFin.Text = "Fecha Fin";
            // 
            // ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 523);
            this.Controls.Add(this.LFechaFin);
            this.Controls.Add(this.LFechaInicio);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.BLimpiarCarrito);
            this.Controls.Add(this.bConfirmarVenta);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.datagrid_carrito);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ventas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventas";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_carrito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BLimpiarCarrito;
        private System.Windows.Forms.Button bConfirmarVenta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LHistorialVentas;
        public System.Windows.Forms.DataGridView datagrid_carrito;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIdVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFechaVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMontoTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFactura;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label LFechaInicio;
        private System.Windows.Forms.Label LFechaFin;
    }
}