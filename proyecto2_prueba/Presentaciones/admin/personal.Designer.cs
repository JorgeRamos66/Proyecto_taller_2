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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LAdministracionPersonal = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.datagrid_personal = new System.Windows.Forms.DataGridView();
            this.textBoxBusqueda = new System.Windows.Forms.TextBox();
            this.BBuscarPersonal = new System.Windows.Forms.Button();
            this.BAgregarPersonal = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Cid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNombreUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cdni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cemail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cdireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CRol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CModificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CBaja_Alta = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CBaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonBorrar = new System.Windows.Forms.Button();
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
            this.datagrid_personal.AllowUserToDeleteRows = false;
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
            this.CRol,
            this.CModificar,
            this.CBaja_Alta,
            this.CBaja});
            this.datagrid_personal.Location = new System.Drawing.Point(13, 149);
            this.datagrid_personal.Name = "datagrid_personal";
            this.datagrid_personal.ReadOnly = true;
            this.datagrid_personal.Size = new System.Drawing.Size(1143, 414);
            this.datagrid_personal.TabIndex = 2;
            // 
            // textBoxBusqueda
            // 
            this.textBoxBusqueda.Location = new System.Drawing.Point(459, 123);
            this.textBoxBusqueda.Name = "textBoxBusqueda";
            this.textBoxBusqueda.Size = new System.Drawing.Size(162, 20);
            this.textBoxBusqueda.TabIndex = 4;
            // 
            // BBuscarPersonal
            // 
            this.BBuscarPersonal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BBuscarPersonal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BBuscarPersonal.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBuscarPersonal.Location = new System.Drawing.Point(627, 123);
            this.BBuscarPersonal.Name = "BBuscarPersonal";
            this.BBuscarPersonal.Size = new System.Drawing.Size(75, 21);
            this.BBuscarPersonal.TabIndex = 5;
            this.BBuscarPersonal.Text = "Buscar";
            this.BBuscarPersonal.UseVisualStyleBackColor = false;
            this.BBuscarPersonal.Click += new System.EventHandler(this.BBuscarPersonal_Click);
            // 
            // BAgregarPersonal
            // 
            this.BAgregarPersonal.BackColor = System.Drawing.Color.SteelBlue;
            this.BAgregarPersonal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BAgregarPersonal.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAgregarPersonal.Image = global::proyecto2_prueba.Properties.Resources.user_32px;
            this.BAgregarPersonal.Location = new System.Drawing.Point(1023, 97);
            this.BAgregarPersonal.Name = "BAgregarPersonal";
            this.BAgregarPersonal.Size = new System.Drawing.Size(131, 47);
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
            this.button1.Location = new System.Drawing.Point(1059, 569);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 43);
            this.button1.TabIndex = 6;
            this.button1.Text = "SALIR";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Cid
            // 
            this.Cid.HeaderText = "ID";
            this.Cid.Name = "Cid";
            this.Cid.ReadOnly = true;
            this.Cid.Width = 50;
            // 
            // CNombreUsuario
            // 
            this.CNombreUsuario.HeaderText = "Nombre";
            this.CNombreUsuario.Name = "CNombreUsuario";
            this.CNombreUsuario.ReadOnly = true;
            // 
            // CApellido
            // 
            this.CApellido.HeaderText = "Apellido";
            this.CApellido.Name = "CApellido";
            this.CApellido.ReadOnly = true;
            // 
            // Cdni
            // 
            this.Cdni.HeaderText = "DNI";
            this.Cdni.Name = "Cdni";
            this.Cdni.ReadOnly = true;
            // 
            // Cemail
            // 
            this.Cemail.HeaderText = "Email";
            this.Cemail.Name = "Cemail";
            this.Cemail.ReadOnly = true;
            this.Cemail.Width = 150;
            // 
            // Cdireccion
            // 
            this.Cdireccion.HeaderText = "Direccion";
            this.Cdireccion.Name = "Cdireccion";
            this.Cdireccion.ReadOnly = true;
            // 
            // CUsuario
            // 
            this.CUsuario.HeaderText = "Usuario";
            this.CUsuario.Name = "CUsuario";
            this.CUsuario.ReadOnly = true;
            // 
            // CRol
            // 
            this.CRol.HeaderText = "Rol";
            this.CRol.Name = "CRol";
            this.CRol.ReadOnly = true;
            // 
            // CModificar
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.CModificar.DefaultCellStyle = dataGridViewCellStyle9;
            this.CModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CModificar.HeaderText = "Modificar";
            this.CModificar.Name = "CModificar";
            this.CModificar.ReadOnly = true;
            this.CModificar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CModificar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CModificar.Text = "Modificar";
            this.CModificar.ToolTipText = "Modificar";
            this.CModificar.UseColumnTextForButtonValue = true;
            // 
            // CBaja_Alta
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Red;
            this.CBaja_Alta.DefaultCellStyle = dataGridViewCellStyle10;
            this.CBaja_Alta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBaja_Alta.HeaderText = "Baja/Alta";
            this.CBaja_Alta.Name = "CBaja_Alta";
            this.CBaja_Alta.ReadOnly = true;
            this.CBaja_Alta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CBaja_Alta.Text = "Baja";
            this.CBaja_Alta.ToolTipText = "Baja";
            this.CBaja_Alta.UseColumnTextForButtonValue = true;
            // 
            // CBaja
            // 
            this.CBaja.HeaderText = "Eliminado?";
            this.CBaja.Name = "CBaja";
            this.CBaja.ReadOnly = true;
            // 
            // buttonBorrar
            // 
            this.buttonBorrar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonBorrar.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBorrar.Location = new System.Drawing.Point(708, 123);
            this.buttonBorrar.Name = "buttonBorrar";
            this.buttonBorrar.Size = new System.Drawing.Size(75, 21);
            this.buttonBorrar.TabIndex = 7;
            this.buttonBorrar.Text = "Borrar";
            this.buttonBorrar.UseVisualStyleBackColor = false;
            this.buttonBorrar.Click += new System.EventHandler(this.buttonBorrar_Click);
            // 
            // personal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(1194, 624);
            this.Controls.Add(this.buttonBorrar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BBuscarPersonal);
            this.Controls.Add(this.textBoxBusqueda);
            this.Controls.Add(this.BAgregarPersonal);
            this.Controls.Add(this.datagrid_personal);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
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
        private System.Windows.Forms.TextBox textBoxBusqueda;
        private System.Windows.Forms.Button BBuscarPersonal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cid;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNombreUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn CApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cdni;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cemail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cdireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn CRol;
        private System.Windows.Forms.DataGridViewButtonColumn CModificar;
        private System.Windows.Forms.DataGridViewButtonColumn CBaja_Alta;
        private System.Windows.Forms.DataGridViewTextBoxColumn CBaja;
        private System.Windows.Forms.Button buttonBorrar;
    }
}