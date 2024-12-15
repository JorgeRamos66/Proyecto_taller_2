using System.Drawing;
using System.Windows.Forms;

namespace proyecto2_prueba.Presentaciones.vendedor
{
    partial class carrito
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.BBorrar = new System.Windows.Forms.Button();
            this.textBoxBusqueda = new System.Windows.Forms.TextBox();
            this.datagrid_carrito = new System.Windows.Forms.DataGridView();
            this.CNombre_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCategoria_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CStock_Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCantidad_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operacionAgregar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operacionQuitar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CIdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proyecto_Taller_2DataSet = new proyecto2_prueba.Proyecto_Taller_2DataSet();
            this.proyectoTaller2DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pRODUCTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pRODUCTOTableAdapter = new proyecto2_prueba.Proyecto_Taller_2DataSetTableAdapters.PRODUCTOTableAdapter();
            this.proyectoTaller2DataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bConfirmarVenta = new System.Windows.Forms.Button();
            this.BLimpiarCarrito = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnSeleccionarCliente = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_carrito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proyecto_Taller_2DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proyectoTaller2DataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRODUCTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proyectoTaller2DataSetBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(379, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 56);
            this.panel1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "CARRITO DE COMPRAS";
            // 
            // BBorrar
            // 
            this.BBorrar.BackColor = System.Drawing.Color.Beige;
            this.BBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BBorrar.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBorrar.Location = new System.Drawing.Point(629, 78);
            this.BBorrar.Name = "BBorrar";
            this.BBorrar.Size = new System.Drawing.Size(75, 23);
            this.BBorrar.TabIndex = 12;
            this.BBorrar.Text = "Borrar";
            this.BBorrar.UseVisualStyleBackColor = false;
            this.BBorrar.Click += new System.EventHandler(this.BBorrar_Click);
            // 
            // textBoxBusqueda
            // 
            this.textBoxBusqueda.Location = new System.Drawing.Point(383, 80);
            this.textBoxBusqueda.Name = "textBoxBusqueda";
            this.textBoxBusqueda.Size = new System.Drawing.Size(239, 20);
            this.textBoxBusqueda.TabIndex = 10;
            // 
            // datagrid_carrito
            // 
            this.datagrid_carrito.AllowUserToAddRows = false;
            this.datagrid_carrito.AllowUserToDeleteRows = false;
            this.datagrid_carrito.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.datagrid_carrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid_carrito.Location = new System.Drawing.Point(72, 106);
            this.datagrid_carrito.Name = "datagrid_carrito";
            this.datagrid_carrito.ReadOnly = true;
            this.datagrid_carrito.Size = new System.Drawing.Size(971, 371);
            this.datagrid_carrito.TabIndex = 8;
            // 
            // CNombre_producto
            // 
            this.CNombre_producto.HeaderText = "Nombre";
            this.CNombre_producto.Name = "CNombre_producto";
            this.CNombre_producto.ReadOnly = true;
            this.CNombre_producto.Width = 150;
            // 
            // CCategoria_producto
            // 
            this.CCategoria_producto.HeaderText = "Categoria";
            this.CCategoria_producto.Name = "CCategoria_producto";
            this.CCategoria_producto.ReadOnly = true;
            this.CCategoria_producto.Width = 150;
            // 
            // CPrecio
            // 
            this.CPrecio.HeaderText = "Precio";
            this.CPrecio.Name = "CPrecio";
            this.CPrecio.ReadOnly = true;
            // 
            // CStock_Producto
            // 
            this.CStock_Producto.HeaderText = "En Stock";
            this.CStock_Producto.Name = "CStock_Producto";
            this.CStock_Producto.ReadOnly = true;
            // 
            // CCantidad_producto
            // 
            this.CCantidad_producto.HeaderText = "Cantidad";
            this.CCantidad_producto.Name = "CCantidad_producto";
            // 
            // operacionAgregar
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.operacionAgregar.DefaultCellStyle = dataGridViewCellStyle1;
            this.operacionAgregar.HeaderText = "Operacion";
            this.operacionAgregar.Name = "operacionAgregar";
            this.operacionAgregar.ToolTipText = "Agregar";
            this.operacionAgregar.Visible = false;
            // 
            // operacionQuitar
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.operacionQuitar.DefaultCellStyle = dataGridViewCellStyle2;
            this.operacionQuitar.HeaderText = "Operacion";
            this.operacionQuitar.Name = "operacionQuitar";
            this.operacionQuitar.ToolTipText = "Quitar";
            this.operacionQuitar.Visible = false;
            // 
            // CIdProducto
            // 
            this.CIdProducto.HeaderText = "IdProducto";
            this.CIdProducto.Name = "CIdProducto";
            this.CIdProducto.Visible = false;
            // 
            // proyecto_Taller_2DataSet
            // 
            this.proyecto_Taller_2DataSet.DataSetName = "Proyecto_Taller_2DataSet";
            this.proyecto_Taller_2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // proyectoTaller2DataSetBindingSource
            // 
            this.proyectoTaller2DataSetBindingSource.DataSource = this.proyecto_Taller_2DataSet;
            this.proyectoTaller2DataSetBindingSource.Position = 0;
            // 
            // pRODUCTOBindingSource
            // 
            this.pRODUCTOBindingSource.DataMember = "PRODUCTO";
            this.pRODUCTOBindingSource.DataSource = this.proyectoTaller2DataSetBindingSource;
            // 
            // pRODUCTOTableAdapter
            // 
            this.pRODUCTOTableAdapter.ClearBeforeFill = true;
            // 
            // proyectoTaller2DataSetBindingSource1
            // 
            this.proyectoTaller2DataSetBindingSource1.DataSource = this.proyecto_Taller_2DataSet;
            this.proyectoTaller2DataSetBindingSource1.Position = 0;
            // 
            // bConfirmarVenta
            // 
            this.bConfirmarVenta.BackColor = System.Drawing.Color.ForestGreen;
            this.bConfirmarVenta.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bConfirmarVenta.ForeColor = System.Drawing.SystemColors.Control;
            this.bConfirmarVenta.Location = new System.Drawing.Point(811, 67);
            this.bConfirmarVenta.Name = "bConfirmarVenta";
            this.bConfirmarVenta.Size = new System.Drawing.Size(113, 33);
            this.bConfirmarVenta.TabIndex = 13;
            this.bConfirmarVenta.Text = "Confirmar Venta";
            this.bConfirmarVenta.UseVisualStyleBackColor = false;
            this.bConfirmarVenta.Click += new System.EventHandler(this.bConfirmarVenta_Click);
            // 
            // BLimpiarCarrito
            // 
            this.BLimpiarCarrito.BackColor = System.Drawing.Color.Red;
            this.BLimpiarCarrito.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BLimpiarCarrito.ForeColor = System.Drawing.SystemColors.Control;
            this.BLimpiarCarrito.Location = new System.Drawing.Point(930, 67);
            this.BLimpiarCarrito.Name = "BLimpiarCarrito";
            this.BLimpiarCarrito.Size = new System.Drawing.Size(113, 34);
            this.BLimpiarCarrito.TabIndex = 14;
            this.BLimpiarCarrito.Text = "Limpiar Carrito";
            this.BLimpiarCarrito.UseVisualStyleBackColor = false;
            this.BLimpiarCarrito.Click += new System.EventHandler(this.BLimpiarCarrito_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(800, 500);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 20);
            this.lblTotal.TabIndex = 0;
            // 
            // btnSeleccionarCliente
            // 
            this.btnSeleccionarCliente.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSeleccionarCliente.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarCliente.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSeleccionarCliente.Location = new System.Drawing.Point(72, 55);
            this.btnSeleccionarCliente.Name = "btnSeleccionarCliente";
            this.btnSeleccionarCliente.Size = new System.Drawing.Size(113, 45);
            this.btnSeleccionarCliente.TabIndex = 15;
            this.btnSeleccionarCliente.Text = "Seleccionar Cliente";
            this.btnSeleccionarCliente.UseVisualStyleBackColor = false;
            this.btnSeleccionarCliente.Click += new System.EventHandler(this.btnSeleccionarCliente_Click);
            // 
            // carrito
            // 
            this.AcceptButton = this.bConfirmarVenta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 546);
            this.Controls.Add(this.btnSeleccionarCliente);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.BLimpiarCarrito);
            this.Controls.Add(this.bConfirmarVenta);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BBorrar);
            this.Controls.Add(this.textBoxBusqueda);
            this.Controls.Add(this.datagrid_carrito);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "carrito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "carrito";
            this.Load += new System.EventHandler(this.carrito_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_carrito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proyecto_Taller_2DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proyectoTaller2DataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRODUCTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proyectoTaller2DataSetBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblTotal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BBorrar;
        private System.Windows.Forms.TextBox textBoxBusqueda;
        public System.Windows.Forms.DataGridView datagrid_carrito;
        private Proyecto_Taller_2DataSet proyecto_Taller_2DataSet;
        private System.Windows.Forms.BindingSource proyectoTaller2DataSetBindingSource;
        private System.Windows.Forms.BindingSource pRODUCTOBindingSource;
        private Proyecto_Taller_2DataSetTableAdapters.PRODUCTOTableAdapter pRODUCTOTableAdapter;
        private System.Windows.Forms.BindingSource proyectoTaller2DataSetBindingSource1;
        private Button bConfirmarVenta;
        private Button BLimpiarCarrito;
        private DataGridViewTextBoxColumn CNombre_producto;
        private DataGridViewTextBoxColumn CCategoria_producto;
        private DataGridViewTextBoxColumn CPrecio;
        private DataGridViewTextBoxColumn CStock_Producto;
        private DataGridViewTextBoxColumn CCantidad_producto;
        private DataGridViewTextBoxColumn operacionAgregar;
        private DataGridViewTextBoxColumn operacionQuitar;
        private DataGridViewTextBoxColumn CIdProducto;
        private Button btnSeleccionarCliente;
    }
}