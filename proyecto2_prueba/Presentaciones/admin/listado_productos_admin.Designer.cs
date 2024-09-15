namespace proyecto2_prueba.Presentaciones.admin
{
    partial class listado_productos_admin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.datagrid_productos = new System.Windows.Forms.DataGridView();
            this.CId_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNombre_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CStock_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCategoria_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CRutaImagen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CImagen_Producto = new System.Windows.Forms.DataGridViewImageColumn();
            this.CModificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CBaja = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxBusqueda = new System.Windows.Forms.TextBox();
            this.BBuscarProducto = new System.Windows.Forms.Button();
            this.BSalir = new System.Windows.Forms.Button();
            this.BAltaProducto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_productos)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // datagrid_productos
            // 
            this.datagrid_productos.AllowUserToAddRows = false;
            this.datagrid_productos.AllowUserToDeleteRows = false;
            this.datagrid_productos.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.datagrid_productos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.datagrid_productos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.datagrid_productos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.datagrid_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid_productos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CId_producto,
            this.CNombre_producto,
            this.CStock_producto,
            this.CPrecio,
            this.CCategoria_producto,
            this.CDescripcion,
            this.CRutaImagen,
            this.CImagen_Producto,
            this.CModificar,
            this.CBaja});
            this.datagrid_productos.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.datagrid_productos.Location = new System.Drawing.Point(31, 126);
            this.datagrid_productos.Name = "datagrid_productos";
            this.datagrid_productos.ReadOnly = true;
            this.datagrid_productos.RowTemplate.Height = 50;
            this.datagrid_productos.Size = new System.Drawing.Size(1244, 393);
            this.datagrid_productos.TabIndex = 0;
            this.datagrid_productos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_productos_CellContentClick);
            // 
            // CId_producto
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CId_producto.DefaultCellStyle = dataGridViewCellStyle1;
            this.CId_producto.HeaderText = "ID";
            this.CId_producto.Name = "CId_producto";
            this.CId_producto.ReadOnly = true;
            this.CId_producto.Width = 50;
            // 
            // CNombre_producto
            // 
            this.CNombre_producto.HeaderText = "Nombre";
            this.CNombre_producto.Name = "CNombre_producto";
            this.CNombre_producto.ReadOnly = true;
            this.CNombre_producto.Width = 150;
            // 
            // CStock_producto
            // 
            this.CStock_producto.HeaderText = "Stock";
            this.CStock_producto.Name = "CStock_producto";
            this.CStock_producto.ReadOnly = true;
            this.CStock_producto.Width = 50;
            // 
            // CPrecio
            // 
            this.CPrecio.HeaderText = "Precio";
            this.CPrecio.Name = "CPrecio";
            this.CPrecio.ReadOnly = true;
            // 
            // CCategoria_producto
            // 
            this.CCategoria_producto.HeaderText = "Categoria";
            this.CCategoria_producto.Name = "CCategoria_producto";
            this.CCategoria_producto.ReadOnly = true;
            this.CCategoria_producto.Width = 150;
            // 
            // CDescripcion
            // 
            this.CDescripcion.HeaderText = "Descripcion";
            this.CDescripcion.Name = "CDescripcion";
            this.CDescripcion.ReadOnly = true;
            this.CDescripcion.Width = 200;
            // 
            // CRutaImagen
            // 
            this.CRutaImagen.HeaderText = "RutaImagen";
            this.CRutaImagen.Name = "CRutaImagen";
            this.CRutaImagen.ReadOnly = true;
            // 
            // CImagen_Producto
            // 
            this.CImagen_Producto.HeaderText = "Imagen";
            this.CImagen_Producto.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.CImagen_Producto.Name = "CImagen_Producto";
            this.CImagen_Producto.ReadOnly = true;
            this.CImagen_Producto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CImagen_Producto.Width = 200;
            // 
            // CModificar
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CModificar.DefaultCellStyle = dataGridViewCellStyle2;
            this.CModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CModificar.HeaderText = "Modificar";
            this.CModificar.Name = "CModificar";
            this.CModificar.ReadOnly = true;
            this.CModificar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CModificar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CModificar.Text = "Modificar";
            this.CModificar.UseColumnTextForButtonValue = true;
            // 
            // CBaja
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBaja.DefaultCellStyle = dataGridViewCellStyle3;
            this.CBaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBaja.HeaderText = "Baja";
            this.CBaja.Name = "CBaja";
            this.CBaja.ReadOnly = true;
            this.CBaja.Text = "Baja";
            this.CBaja.UseColumnTextForButtonValue = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "LISTA DE PRODUCTOS";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(471, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 56);
            this.panel1.TabIndex = 2;
            // 
            // textBoxBusqueda
            // 
            this.textBoxBusqueda.Location = new System.Drawing.Point(471, 100);
            this.textBoxBusqueda.Name = "textBoxBusqueda";
            this.textBoxBusqueda.Size = new System.Drawing.Size(239, 20);
            this.textBoxBusqueda.TabIndex = 3;
            // 
            // BBuscarProducto
            // 
            this.BBuscarProducto.BackColor = System.Drawing.Color.Beige;
            this.BBuscarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BBuscarProducto.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBuscarProducto.Location = new System.Drawing.Point(723, 97);
            this.BBuscarProducto.Name = "BBuscarProducto";
            this.BBuscarProducto.Size = new System.Drawing.Size(75, 23);
            this.BBuscarProducto.TabIndex = 4;
            this.BBuscarProducto.Text = "Buscar";
            this.BBuscarProducto.UseVisualStyleBackColor = false;
            this.BBuscarProducto.Click += new System.EventHandler(this.BBuscarProducto_Click);
            // 
            // BSalir
            // 
            this.BSalir.BackColor = System.Drawing.Color.Tomato;
            this.BSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BSalir.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BSalir.Image = global::proyecto2_prueba.Properties.Resources.log_out_32px;
            this.BSalir.Location = new System.Drawing.Point(1167, 522);
            this.BSalir.Name = "BSalir";
            this.BSalir.Size = new System.Drawing.Size(108, 43);
            this.BSalir.TabIndex = 6;
            this.BSalir.Text = "SALIR";
            this.BSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BSalir.UseVisualStyleBackColor = false;
            this.BSalir.Click += new System.EventHandler(this.BSalir_Click);
            // 
            // BAltaProducto
            // 
            this.BAltaProducto.BackColor = System.Drawing.Color.LimeGreen;
            this.BAltaProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BAltaProducto.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAltaProducto.Image = global::proyecto2_prueba.Properties.Resources.box_32px;
            this.BAltaProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAltaProducto.Location = new System.Drawing.Point(31, 525);
            this.BAltaProducto.Name = "BAltaProducto";
            this.BAltaProducto.Size = new System.Drawing.Size(182, 43);
            this.BAltaProducto.TabIndex = 5;
            this.BAltaProducto.Text = "ALTA PRODUCTO";
            this.BAltaProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAltaProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BAltaProducto.UseVisualStyleBackColor = false;
            this.BAltaProducto.Click += new System.EventHandler(this.BAltaProducto_Click);
            // 
            // listado_productos_admin
            // 
            this.AcceptButton = this.BBuscarProducto;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.CancelButton = this.BSalir;
            this.ClientSize = new System.Drawing.Size(1301, 577);
            this.Controls.Add(this.BSalir);
            this.Controls.Add(this.BAltaProducto);
            this.Controls.Add(this.BBuscarProducto);
            this.Controls.Add(this.textBoxBusqueda);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.datagrid_productos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "listado_productos_admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Productos";
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_productos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView datagrid_productos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxBusqueda;
        private System.Windows.Forms.Button BBuscarProducto;
        private System.Windows.Forms.Button BAltaProducto;
        private System.Windows.Forms.Button BSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn CId_producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNombre_producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CStock_producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCategoria_producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CRutaImagen;
        private System.Windows.Forms.DataGridViewImageColumn CImagen_Producto;
        private System.Windows.Forms.DataGridViewButtonColumn CModificar;
        private System.Windows.Forms.DataGridViewButtonColumn CBaja;
    }
}