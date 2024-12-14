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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.numericUpDownDescuento = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxNombreNivel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BNuevoNivel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BSalir = new System.Windows.Forms.Button();
            this.textBoxIDnivel = new System.Windows.Forms.TextBox();
            this.datagrid_niveles = new System.Windows.Forms.DataGridView();
            this.Cid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNombreNivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CBaja = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDescuento)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_niveles)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Tan;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.numericUpDownDescuento);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.textBoxNombreNivel);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.BNuevoNivel);
            this.panel2.Location = new System.Drawing.Point(10, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(533, 84);
            this.panel2.TabIndex = 10;
            // 
            // numericUpDownDescuento
            // 
            this.numericUpDownDescuento.Location = new System.Drawing.Point(169, 54);
            this.numericUpDownDescuento.Name = "numericUpDownDescuento";
            this.numericUpDownDescuento.Size = new System.Drawing.Size(52, 20);
            this.numericUpDownDescuento.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(40, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Descuento (en %)";
            // 
            // textBoxNombreNivel
            // 
            this.textBoxNombreNivel.Location = new System.Drawing.Point(169, 19);
            this.textBoxNombreNivel.Name = "textBoxNombreNivel";
            this.textBoxNombreNivel.Size = new System.Drawing.Size(184, 20);
            this.textBoxNombreNivel.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nombre de Nivel";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BNuevoNivel
            // 
            this.BNuevoNivel.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BNuevoNivel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BNuevoNivel.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BNuevoNivel.Image = global::proyecto2_prueba.Properties.Resources.niveles_32px;
            this.BNuevoNivel.Location = new System.Drawing.Point(374, 20);
            this.BNuevoNivel.Name = "BNuevoNivel";
            this.BNuevoNivel.Size = new System.Drawing.Size(139, 40);
            this.BNuevoNivel.TabIndex = 5;
            this.BNuevoNivel.Text = "AGREGAR";
            this.BNuevoNivel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BNuevoNivel.UseVisualStyleBackColor = false;
            this.BNuevoNivel.Click += new System.EventHandler(this.BNuevoNivel_Click);
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
            this.label4.Location = new System.Drawing.Point(79, 9);
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
            this.BSalir.Location = new System.Drawing.Point(208, 452);
            this.BSalir.Name = "BSalir";
            this.BSalir.Size = new System.Drawing.Size(92, 47);
            this.BSalir.TabIndex = 11;
            this.BSalir.Text = "SALIR";
            this.BSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BSalir.UseVisualStyleBackColor = false;
            this.BSalir.Click += new System.EventHandler(this.BSalir_Click);
            // 
            // textBoxIDnivel
            // 
            this.textBoxIDnivel.Location = new System.Drawing.Point(443, 465);
            this.textBoxIDnivel.Name = "textBoxIDnivel";
            this.textBoxIDnivel.Size = new System.Drawing.Size(74, 20);
            this.textBoxIDnivel.TabIndex = 12;
            this.textBoxIDnivel.Visible = false;
            // 
            // datagrid_niveles
            // 
            this.datagrid_niveles.AllowUserToAddRows = false;
            this.datagrid_niveles.AllowUserToDeleteRows = false;
            this.datagrid_niveles.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.datagrid_niveles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.datagrid_niveles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.datagrid_niveles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.datagrid_niveles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid_niveles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cid,
            this.CNombreNivel,
            this.CDescuento,
            this.CBaja});
            this.datagrid_niveles.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.datagrid_niveles.Location = new System.Drawing.Point(26, 152);
            this.datagrid_niveles.MaximumSize = new System.Drawing.Size(604, 298);
            this.datagrid_niveles.Name = "datagrid_niveles";
            this.datagrid_niveles.ReadOnly = true;
            this.datagrid_niveles.Size = new System.Drawing.Size(491, 291);
            this.datagrid_niveles.TabIndex = 9;
            this.datagrid_niveles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_niveles_CellClick);
            // 
            // Cid
            // 
            this.Cid.HeaderText = "id";
            this.Cid.Name = "Cid";
            this.Cid.ReadOnly = true;
            this.Cid.Visible = false;
            this.Cid.Width = 50;
            // 
            // CNombreNivel
            // 
            this.CNombreNivel.FillWeight = 50F;
            this.CNombreNivel.HeaderText = "Nombre";
            this.CNombreNivel.Name = "CNombreNivel";
            this.CNombreNivel.ReadOnly = true;
            // 
            // CDescuento
            // 
            this.CDescuento.FillWeight = 50F;
            this.CDescuento.HeaderText = "Descuento (%)";
            this.CDescuento.Name = "CDescuento";
            this.CDescuento.ReadOnly = true;
            // 
            // CBaja
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Red;
            this.CBaja.DefaultCellStyle = dataGridViewCellStyle3;
            this.CBaja.FillWeight = 50F;
            this.CBaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBaja.HeaderText = "Estado";
            this.CBaja.Name = "CBaja";
            this.CBaja.ReadOnly = true;
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
            this.ClientSize = new System.Drawing.Size(554, 516);
            this.Controls.Add(this.textBoxIDnivel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BSalir);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.datagrid_niveles);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "niveles_clientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Niveles";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDescuento)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_niveles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BSalir;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxNombreNivel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BNuevoNivel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownDescuento;
        private System.Windows.Forms.TextBox textBoxIDnivel;
        private System.Windows.Forms.DataGridView datagrid_niveles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cid;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNombreNivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDescuento;
        private System.Windows.Forms.DataGridViewButtonColumn CBaja;
    }
}