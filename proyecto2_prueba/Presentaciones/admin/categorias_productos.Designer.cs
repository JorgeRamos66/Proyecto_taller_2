namespace proyecto2_prueba.Presentaciones.admin
{
    partial class categorias_productos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.datagrid_categorias = new System.Windows.Forms.DataGridView();
            this.BNuevaCategoria = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxDescripcionCategoria = new System.Windows.Forms.TextBox();
            this.textBoxNombreCategoria = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Cid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNombreCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CBaja = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_categorias)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(88, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 56);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(513, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "LISTA DE CATEGORIAS DE PRODUCTOS";
            // 
            // datagrid_categorias
            // 
            this.datagrid_categorias.AllowUserToAddRows = false;
            this.datagrid_categorias.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.datagrid_categorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid_categorias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cid,
            this.CNombreCategoria,
            this.CDescripcion,
            this.CBaja});
            this.datagrid_categorias.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.datagrid_categorias.Location = new System.Drawing.Point(12, 95);
            this.datagrid_categorias.Name = "datagrid_categorias";
            this.datagrid_categorias.Size = new System.Drawing.Size(696, 326);
            this.datagrid_categorias.TabIndex = 4;
            this.datagrid_categorias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_categorias_CellContentClick);
            // 
            // BNuevaCategoria
            // 
            this.BNuevaCategoria.BackColor = System.Drawing.Color.LimeGreen;
            this.BNuevaCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BNuevaCategoria.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BNuevaCategoria.Image = global::proyecto2_prueba.Properties.Resources.categories_32px;
            this.BNuevaCategoria.Location = new System.Drawing.Point(520, 18);
            this.BNuevaCategoria.Name = "BNuevaCategoria";
            this.BNuevaCategoria.Size = new System.Drawing.Size(148, 68);
            this.BNuevaCategoria.TabIndex = 5;
            this.BNuevaCategoria.Text = "Agregar Categoria";
            this.BNuevaCategoria.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BNuevaCategoria.UseVisualStyleBackColor = false;
            this.BNuevaCategoria.Click += new System.EventHandler(this.BNuevaCategoria_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Tan;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.textBoxDescripcionCategoria);
            this.panel2.Controls.Add(this.textBoxNombreCategoria);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.BNuevaCategoria);
            this.panel2.Location = new System.Drawing.Point(12, 434);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(696, 104);
            this.panel2.TabIndex = 6;
            // 
            // textBoxDescripcionCategoria
            // 
            this.textBoxDescripcionCategoria.Location = new System.Drawing.Point(174, 44);
            this.textBoxDescripcionCategoria.Multiline = true;
            this.textBoxDescripcionCategoria.Name = "textBoxDescripcionCategoria";
            this.textBoxDescripcionCategoria.Size = new System.Drawing.Size(314, 53);
            this.textBoxDescripcionCategoria.TabIndex = 9;
            // 
            // textBoxNombreCategoria
            // 
            this.textBoxNombreCategoria.Location = new System.Drawing.Point(174, 13);
            this.textBoxNombreCategoria.Name = "textBoxNombreCategoria";
            this.textBoxNombreCategoria.Size = new System.Drawing.Size(314, 20);
            this.textBoxNombreCategoria.TabIndex = 8;
            this.textBoxNombreCategoria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNombreCategoria_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(85, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Descripcion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nombre de Categoria";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Cid
            // 
            this.Cid.HeaderText = "id";
            this.Cid.Name = "Cid";
            this.Cid.Width = 50;
            // 
            // CNombreCategoria
            // 
            this.CNombreCategoria.HeaderText = "Nombre";
            this.CNombreCategoria.Name = "CNombreCategoria";
            this.CNombreCategoria.Width = 200;
            // 
            // CDescripcion
            // 
            this.CDescripcion.HeaderText = "Descripcion";
            this.CDescripcion.Name = "CDescripcion";
            this.CDescripcion.Width = 300;
            // 
            // CBaja
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Red;
            this.CBaja.DefaultCellStyle = dataGridViewCellStyle8;
            this.CBaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBaja.HeaderText = "Baja";
            this.CBaja.Name = "CBaja";
            this.CBaja.Text = "BAJA";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Tomato;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::proyecto2_prueba.Properties.Resources.log_out_32px;
            this.button1.Location = new System.Drawing.Point(327, 544);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 47);
            this.button1.TabIndex = 7;
            this.button1.Text = "EXIT";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // categorias_productos
            // 
            this.AcceptButton = this.BNuevaCategoria;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(719, 597);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.datagrid_categorias);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "categorias_productos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Categorias Productos";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_categorias)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView datagrid_categorias;
        private System.Windows.Forms.Button BNuevaCategoria;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxNombreCategoria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDescripcionCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cid;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNombreCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDescripcion;
        private System.Windows.Forms.DataGridViewButtonColumn CBaja;
        private System.Windows.Forms.Button button1;
    }
}