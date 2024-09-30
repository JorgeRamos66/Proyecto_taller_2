namespace proyecto2_prueba.Presentaciones.admin
{
    partial class niveles_clientes
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.numericUpDownDescuento = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxDescripcionNivel = new System.Windows.Forms.TextBox();
            this.textBoxNombreNivel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BNuevoNivel = new System.Windows.Forms.Button();
            this.datagrid_niveles = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BSalir = new System.Windows.Forms.Button();
            this.Cid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNombreCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CBaja = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_niveles)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Tan;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.numericUpDownDescuento);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.textBoxDescripcionNivel);
            this.panel2.Controls.Add(this.textBoxNombreNivel);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.BNuevoNivel);
            this.panel2.Location = new System.Drawing.Point(149, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(533, 163);
            this.panel2.TabIndex = 10;
            // 
            // numericUpDownDescuento
            // 
            this.numericUpDownDescuento.Location = new System.Drawing.Point(174, 115);
            this.numericUpDownDescuento.Name = "numericUpDownDescuento";
            this.numericUpDownDescuento.Size = new System.Drawing.Size(52, 20);
            this.numericUpDownDescuento.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(45, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Descuento (en %)";
            // 
            // textBoxDescripcionNivel
            // 
            this.textBoxDescripcionNivel.Location = new System.Drawing.Point(174, 47);
            this.textBoxDescripcionNivel.Multiline = true;
            this.textBoxDescripcionNivel.Name = "textBoxDescripcionNivel";
            this.textBoxDescripcionNivel.Size = new System.Drawing.Size(322, 53);
            this.textBoxDescripcionNivel.TabIndex = 9;
            // 
            // textBoxNombreNivel
            // 
            this.textBoxNombreNivel.Location = new System.Drawing.Point(174, 13);
            this.textBoxNombreNivel.Name = "textBoxNombreNivel";
            this.textBoxNombreNivel.Size = new System.Drawing.Size(322, 20);
            this.textBoxNombreNivel.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(82, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Descripcion";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nombre de Nivel";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BNuevoNivel
            // 
            this.BNuevoNivel.BackColor = System.Drawing.Color.SteelBlue;
            this.BNuevoNivel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BNuevoNivel.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BNuevoNivel.Image = global::proyecto2_prueba.Properties.Resources.suma_24px;
            this.BNuevoNivel.Location = new System.Drawing.Point(389, 106);
            this.BNuevoNivel.Name = "BNuevoNivel";
            this.BNuevoNivel.Size = new System.Drawing.Size(107, 45);
            this.BNuevoNivel.TabIndex = 5;
            this.BNuevoNivel.Text = "AGREGAR";
            this.BNuevoNivel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BNuevoNivel.UseVisualStyleBackColor = false;
            this.BNuevoNivel.Click += new System.EventHandler(this.BNuevoNivel_Click);
            // 
            // datagrid_niveles
            // 
            this.datagrid_niveles.AllowUserToAddRows = false;
            this.datagrid_niveles.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.datagrid_niveles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid_niveles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cid,
            this.CNombreCategoria,
            this.CDescuento,
            this.CDescripcion,
            this.CBaja});
            this.datagrid_niveles.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.datagrid_niveles.Location = new System.Drawing.Point(12, 238);
            this.datagrid_niveles.Name = "datagrid_niveles";
            this.datagrid_niveles.Size = new System.Drawing.Size(802, 291);
            this.datagrid_niveles.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(128, -59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 56);
            this.panel1.TabIndex = 8;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(218, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(409, 34);
            this.label4.TabIndex = 1;
            this.label4.Text = "LISTA DE NIVELES DE CLIENTES";
            // 
            // BSalir
            // 
            this.BSalir.BackColor = System.Drawing.Color.Tomato;
            this.BSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BSalir.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BSalir.Image = global::proyecto2_prueba.Properties.Resources.log_out_32px;
            this.BSalir.Location = new System.Drawing.Point(722, 535);
            this.BSalir.Name = "BSalir";
            this.BSalir.Size = new System.Drawing.Size(92, 47);
            this.BSalir.TabIndex = 11;
            this.BSalir.Text = "SALIR";
            this.BSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BSalir.UseVisualStyleBackColor = false;
            this.BSalir.Click += new System.EventHandler(this.BSalir_Click);
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
            // CDescuento
            // 
            this.CDescuento.HeaderText = "Descuento (%)";
            this.CDescuento.Name = "CDescuento";
            // 
            // CDescripcion
            // 
            this.CDescripcion.HeaderText = "Descripcion";
            this.CDescripcion.Name = "CDescripcion";
            this.CDescripcion.Width = 300;
            // 
            // CBaja
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Red;
            this.CBaja.DefaultCellStyle = dataGridViewCellStyle1;
            this.CBaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBaja.HeaderText = "Baja";
            this.CBaja.Name = "CBaja";
            this.CBaja.Text = "BAJA";
            this.CBaja.ToolTipText = "BAJA";
            this.CBaja.UseColumnTextForButtonValue = true;
            // 
            // niveles_clientes
            // 
            this.AcceptButton = this.BNuevoNivel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.CancelButton = this.BSalir;
            this.ClientSize = new System.Drawing.Size(827, 590);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BSalir);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.datagrid_niveles);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "niveles_clientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Niveles";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDescuento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_niveles)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BSalir;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxDescripcionNivel;
        private System.Windows.Forms.TextBox textBoxNombreNivel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BNuevoNivel;
        private System.Windows.Forms.DataGridView datagrid_niveles;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cid;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNombreCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDescripcion;
        private System.Windows.Forms.DataGridViewButtonColumn CBaja;
    }
}