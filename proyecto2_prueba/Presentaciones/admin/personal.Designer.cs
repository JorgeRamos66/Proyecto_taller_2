namespace proyecto2_prueba.Presentaciones.admin
{
    partial class personal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LAdministracionPersonal = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.datagrid_personal = new System.Windows.Forms.DataGridView();
            this.Cid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNombreUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cdni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cemail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cdireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CModificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CBaja = new System.Windows.Forms.DataGridViewButtonColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BBuscarPersonal = new System.Windows.Forms.Button();
            this.BAgregarPersonal = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_personal)).BeginInit();
            this.SuspendLayout();
            // 
            // LAdministracionPersonal
            // 
            this.LAdministracionPersonal.AutoSize = true;
            this.LAdministracionPersonal.Font = new System.Drawing.Font("Microsoft Tai Le", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LAdministracionPersonal.Location = new System.Drawing.Point(35, 17);
            this.LAdministracionPersonal.Name = "LAdministracionPersonal";
            this.LAdministracionPersonal.Size = new System.Drawing.Size(368, 34);
            this.LAdministracionPersonal.TabIndex = 0;
            this.LAdministracionPersonal.Text = "Administracion de Personal";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.Controls.Add(this.LAdministracionPersonal);
            this.panel1.Location = new System.Drawing.Point(318, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 67);
            this.panel1.TabIndex = 1;
            // 
            // datagrid_personal
            // 
            this.datagrid_personal.AllowUserToAddRows = false;
            this.datagrid_personal.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.datagrid_personal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid_personal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cid,
            this.CNombreUsuario,
            this.CApellido,
            this.Cdni,
            this.Cemail,
            this.Cdireccion,
            this.CUsuario,
            this.CModificar,
            this.CBaja});
            this.datagrid_personal.Location = new System.Drawing.Point(12, 149);
            this.datagrid_personal.Name = "datagrid_personal";
            this.datagrid_personal.Size = new System.Drawing.Size(1030, 414);
            this.datagrid_personal.TabIndex = 2;
            // 
            // Cid
            // 
            this.Cid.HeaderText = "ID";
            this.Cid.Name = "Cid";
            this.Cid.Width = 50;
            // 
            // CNombreUsuario
            // 
            this.CNombreUsuario.HeaderText = "Nombre";
            this.CNombreUsuario.Name = "CNombreUsuario";
            // 
            // CApellido
            // 
            this.CApellido.HeaderText = "Apellido";
            this.CApellido.Name = "CApellido";
            // 
            // Cdni
            // 
            this.Cdni.HeaderText = "DNI";
            this.Cdni.Name = "Cdni";
            // 
            // Cemail
            // 
            this.Cemail.HeaderText = "Email";
            this.Cemail.Name = "Cemail";
            this.Cemail.Width = 150;
            // 
            // Cdireccion
            // 
            this.Cdireccion.HeaderText = "Direccion";
            this.Cdireccion.Name = "Cdireccion";
            this.Cdireccion.Width = 200;
            // 
            // CUsuario
            // 
            this.CUsuario.HeaderText = "Usuario";
            this.CUsuario.Name = "CUsuario";
            // 
            // CModificar
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.CModificar.DefaultCellStyle = dataGridViewCellStyle3;
            this.CModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CModificar.HeaderText = "Modificar";
            this.CModificar.Name = "CModificar";
            this.CModificar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CModificar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CModificar.Text = "Modificar";
            this.CModificar.ToolTipText = "Modificar";
            this.CModificar.UseColumnTextForButtonValue = true;
            // 
            // CBaja
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Red;
            this.CBaja.DefaultCellStyle = dataGridViewCellStyle4;
            this.CBaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBaja.HeaderText = "Baja";
            this.CBaja.Name = "CBaja";
            this.CBaja.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CBaja.Text = "Baja";
            this.CBaja.ToolTipText = "Baja";
            this.CBaja.UseColumnTextForButtonValue = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 123);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(138, 20);
            this.textBox1.TabIndex = 4;
            // 
            // BBuscarPersonal
            // 
            this.BBuscarPersonal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BBuscarPersonal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BBuscarPersonal.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBuscarPersonal.Location = new System.Drawing.Point(156, 123);
            this.BBuscarPersonal.Name = "BBuscarPersonal";
            this.BBuscarPersonal.Size = new System.Drawing.Size(75, 21);
            this.BBuscarPersonal.TabIndex = 5;
            this.BBuscarPersonal.Text = "BUSCAR";
            this.BBuscarPersonal.UseVisualStyleBackColor = false;
            // 
            // BAgregarPersonal
            // 
            this.BAgregarPersonal.BackColor = System.Drawing.Color.SteelBlue;
            this.BAgregarPersonal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BAgregarPersonal.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAgregarPersonal.Image = global::proyecto2_prueba.Properties.Resources.user_32px;
            this.BAgregarPersonal.Location = new System.Drawing.Point(844, 97);
            this.BAgregarPersonal.Name = "BAgregarPersonal";
            this.BAgregarPersonal.Size = new System.Drawing.Size(196, 47);
            this.BAgregarPersonal.TabIndex = 3;
            this.BAgregarPersonal.Text = "AGREGAR PERSONAL";
            this.BAgregarPersonal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BAgregarPersonal.UseVisualStyleBackColor = false;
            this.BAgregarPersonal.Click += new System.EventHandler(this.BAgregarPersonal_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Tomato;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::proyecto2_prueba.Properties.Resources.log_out_32px;
            this.button1.Location = new System.Drawing.Point(948, 569);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 43);
            this.button1.TabIndex = 6;
            this.button1.Text = "SALIR";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // personal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(1052, 624);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BBuscarPersonal);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BAgregarPersonal);
            this.Controls.Add(this.datagrid_personal);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "personal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar Personal";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_personal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LAdministracionPersonal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView datagrid_personal;
        private System.Windows.Forms.Button BAgregarPersonal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cid;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNombreUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn CApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cdni;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cemail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cdireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUsuario;
        private System.Windows.Forms.DataGridViewButtonColumn CModificar;
        private System.Windows.Forms.DataGridViewButtonColumn CBaja;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BBuscarPersonal;
        private System.Windows.Forms.Button button1;
    }
}