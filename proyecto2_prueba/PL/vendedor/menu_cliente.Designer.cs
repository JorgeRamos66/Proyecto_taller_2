using System.Drawing;

namespace proyecto2_prueba.PL.vendedor
{
    partial class menu_cliente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.lblBuscador = new System.Windows.Forms.Label();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.panelInferior = new System.Windows.Forms.Panel();
            this.BCancelar = new System.Windows.Forms.Button();
            this.BConfirmar = new System.Windows.Forms.Button();
            this.LProvincia = new System.Windows.Forms.Label();
            this.LFechaNacimiento = new System.Windows.Forms.Label();
            this.LDNI = new System.Windows.Forms.Label();
            this.LDireccion = new System.Windows.Forms.Label();
            this.LLocalidad = new System.Windows.Forms.Label();
            this.LEmail = new System.Windows.Forms.Label();
            this.LApellido = new System.Windows.Forms.Label();
            this.LNombre = new System.Windows.Forms.Label();
            this.lblNuevoCliente = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtProvincia = new System.Windows.Forms.TextBox();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.cIdCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSeleccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxIdAuxiliar = new System.Windows.Forms.TextBox();
            this.panelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.panelInferior.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.Color.Tan;
            this.panelSuperior.Controls.Add(this.lblBuscador);
            this.panelSuperior.Controls.Add(this.dgvClientes);
            this.panelSuperior.Controls.Add(this.btnLimpiar);
            this.panelSuperior.Controls.Add(this.txtBuscar);
            this.panelSuperior.Location = new System.Drawing.Point(12, 12);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(776, 229);
            this.panelSuperior.TabIndex = 3;
            // 
            // lblBuscador
            // 
            this.lblBuscador.AutoSize = true;
            this.lblBuscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscador.Location = new System.Drawing.Point(244, 9);
            this.lblBuscador.Name = "lblBuscador";
            this.lblBuscador.Size = new System.Drawing.Size(291, 25);
            this.lblBuscador.TabIndex = 17;
            this.lblBuscador.Text = "CLIENTES REGISTRADOS";
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cIdCliente,
            this.cNombre,
            this.cApellido,
            this.cDNI,
            this.cSeleccion});
            this.dgvClientes.Location = new System.Drawing.Point(132, 78);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.Size = new System.Drawing.Size(522, 121);
            this.dgvClientes.TabIndex = 2;
            this.dgvClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellClick);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(535, 50);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtBuscar.ForeColor = System.Drawing.Color.Gray;
            this.txtBuscar.Location = new System.Drawing.Point(220, 52);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(300, 20);
            this.txtBuscar.TabIndex = 4;
            this.txtBuscar.Text = "Ingrese Nombre, Apellido o DNI";
            this.txtBuscar.Enter += new System.EventHandler(this.TxtBuscar_Enter);
            this.txtBuscar.Leave += new System.EventHandler(this.TxtBuscar_Leave);
            // 
            // panelInferior
            // 
            this.panelInferior.BackColor = System.Drawing.Color.Tan;
            this.panelInferior.Controls.Add(this.textBoxIdAuxiliar);
            this.panelInferior.Controls.Add(this.BCancelar);
            this.panelInferior.Controls.Add(this.BConfirmar);
            this.panelInferior.Controls.Add(this.LProvincia);
            this.panelInferior.Controls.Add(this.LFechaNacimiento);
            this.panelInferior.Controls.Add(this.LDNI);
            this.panelInferior.Controls.Add(this.LDireccion);
            this.panelInferior.Controls.Add(this.LLocalidad);
            this.panelInferior.Controls.Add(this.LEmail);
            this.panelInferior.Controls.Add(this.LApellido);
            this.panelInferior.Controls.Add(this.LNombre);
            this.panelInferior.Controls.Add(this.lblNuevoCliente);
            this.panelInferior.Controls.Add(this.txtNombre);
            this.panelInferior.Controls.Add(this.txtApellido);
            this.panelInferior.Controls.Add(this.txtDni);
            this.panelInferior.Controls.Add(this.txtEmail);
            this.panelInferior.Controls.Add(this.txtProvincia);
            this.panelInferior.Controls.Add(this.txtLocalidad);
            this.panelInferior.Controls.Add(this.txtDomicilio);
            this.panelInferior.Controls.Add(this.dtpFechaNacimiento);
            this.panelInferior.Location = new System.Drawing.Point(12, 247);
            this.panelInferior.Name = "panelInferior";
            this.panelInferior.Size = new System.Drawing.Size(776, 275);
            this.panelInferior.TabIndex = 1;
            // 
            // BCancelar
            // 
            this.BCancelar.BackColor = System.Drawing.Color.Tomato;
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCancelar.Image = global::proyecto2_prueba.Properties.Resources.log_out_32px;
            this.BCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancelar.Location = new System.Drawing.Point(444, 209);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(140, 44);
            this.BCancelar.TabIndex = 36;
            this.BCancelar.Text = "CANCELAR";
            this.BCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BCancelar.UseVisualStyleBackColor = false;
            this.BCancelar.Click += new System.EventHandler(this.BSalir_Click);
            // 
            // BConfirmar
            // 
            this.BConfirmar.BackColor = System.Drawing.Color.SteelBlue;
            this.BConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BConfirmar.Image = global::proyecto2_prueba.Properties.Resources.shopping_cart__1_;
            this.BConfirmar.Location = new System.Drawing.Point(215, 207);
            this.BConfirmar.Name = "BConfirmar";
            this.BConfirmar.Size = new System.Drawing.Size(140, 48);
            this.BConfirmar.TabIndex = 35;
            this.BConfirmar.Text = "CONFIRMAR CLIENTE";
            this.BConfirmar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BConfirmar.UseVisualStyleBackColor = false;
            this.BConfirmar.Click += new System.EventHandler(this.BConfirmar_Click);
            // 
            // LProvincia
            // 
            this.LProvincia.AutoSize = true;
            this.LProvincia.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LProvincia.Location = new System.Drawing.Point(377, 134);
            this.LProvincia.Name = "LProvincia";
            this.LProvincia.Size = new System.Drawing.Size(64, 16);
            this.LProvincia.TabIndex = 34;
            this.LProvincia.Text = "Provincia";
            // 
            // LFechaNacimiento
            // 
            this.LFechaNacimiento.AutoSize = true;
            this.LFechaNacimiento.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaNacimiento.Location = new System.Drawing.Point(389, 61);
            this.LFechaNacimiento.Name = "LFechaNacimiento";
            this.LFechaNacimiento.Size = new System.Drawing.Size(117, 16);
            this.LFechaNacimiento.TabIndex = 33;
            this.LFechaNacimiento.Text = "Fecha Nacimiento";
            // 
            // LDNI
            // 
            this.LDNI.AutoSize = true;
            this.LDNI.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDNI.Location = new System.Drawing.Point(152, 169);
            this.LDNI.Name = "LDNI";
            this.LDNI.Size = new System.Drawing.Size(31, 16);
            this.LDNI.TabIndex = 32;
            this.LDNI.Text = "DNI";
            // 
            // LDireccion
            // 
            this.LDireccion.AutoSize = true;
            this.LDireccion.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDireccion.Location = new System.Drawing.Point(373, 170);
            this.LDireccion.Name = "LDireccion";
            this.LDireccion.Size = new System.Drawing.Size(65, 16);
            this.LDireccion.TabIndex = 31;
            this.LDireccion.Text = "Direccion";
            // 
            // LLocalidad
            // 
            this.LLocalidad.AutoSize = true;
            this.LLocalidad.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLocalidad.Location = new System.Drawing.Point(388, 98);
            this.LLocalidad.Name = "LLocalidad";
            this.LLocalidad.Size = new System.Drawing.Size(50, 16);
            this.LLocalidad.TabIndex = 30;
            this.LLocalidad.Text = "Ciudad";
            // 
            // LEmail
            // 
            this.LEmail.AutoSize = true;
            this.LEmail.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LEmail.Location = new System.Drawing.Point(144, 132);
            this.LEmail.Name = "LEmail";
            this.LEmail.Size = new System.Drawing.Size(41, 16);
            this.LEmail.TabIndex = 29;
            this.LEmail.Text = "Email";
            // 
            // LApellido
            // 
            this.LApellido.AutoSize = true;
            this.LApellido.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LApellido.Location = new System.Drawing.Point(127, 96);
            this.LApellido.Name = "LApellido";
            this.LApellido.Size = new System.Drawing.Size(59, 16);
            this.LApellido.TabIndex = 28;
            this.LApellido.Text = "Apellido";
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNombre.Location = new System.Drawing.Point(126, 60);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(57, 16);
            this.LNombre.TabIndex = 27;
            this.LNombre.Text = "Nombre";
            // 
            // lblNuevoCliente
            // 
            this.lblNuevoCliente.AutoSize = true;
            this.lblNuevoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNuevoCliente.Location = new System.Drawing.Point(261, 11);
            this.lblNuevoCliente.Name = "lblNuevoCliente";
            this.lblNuevoCliente.Size = new System.Drawing.Size(244, 25);
            this.lblNuevoCliente.TabIndex = 18;
            this.lblNuevoCliente.Text = "REGISTRAR CLIENTE";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(189, 58);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(166, 20);
            this.txtNombre.TabIndex = 0;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(189, 94);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(166, 20);
            this.txtApellido.TabIndex = 1;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(189, 167);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(166, 20);
            this.txtDni.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(189, 128);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(166, 20);
            this.txtEmail.TabIndex = 3;
            // 
            // txtProvincia
            // 
            this.txtProvincia.Location = new System.Drawing.Point(444, 132);
            this.txtProvincia.Name = "txtProvincia";
            this.txtProvincia.Size = new System.Drawing.Size(166, 20);
            this.txtProvincia.TabIndex = 4;
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(444, 96);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(166, 20);
            this.txtLocalidad.TabIndex = 5;
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Location = new System.Drawing.Point(444, 168);
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(166, 20);
            this.txtDomicilio.TabIndex = 6;
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(512, 58);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(98, 20);
            this.dtpFechaNacimiento.TabIndex = 7;
            // 
            // cIdCliente
            // 
            this.cIdCliente.HeaderText = "IdCliente";
            this.cIdCliente.Name = "cIdCliente";
            this.cIdCliente.ReadOnly = true;
            this.cIdCliente.Visible = false;
            // 
            // cNombre
            // 
            this.cNombre.HeaderText = "Nombre";
            this.cNombre.Name = "cNombre";
            this.cNombre.ReadOnly = true;
            // 
            // cApellido
            // 
            this.cApellido.HeaderText = "Apellido";
            this.cApellido.Name = "cApellido";
            this.cApellido.ReadOnly = true;
            // 
            // cDNI
            // 
            this.cDNI.HeaderText = "DNI";
            this.cDNI.Name = "cDNI";
            this.cDNI.ReadOnly = true;
            // 
            // cSeleccion
            // 
            this.cSeleccion.HeaderText = "Seleccion";
            this.cSeleccion.Name = "cSeleccion";
            this.cSeleccion.ReadOnly = true;
            // 
            // textBoxIdAuxiliar
            // 
            this.textBoxIdAuxiliar.Location = new System.Drawing.Point(593, 17);
            this.textBoxIdAuxiliar.Name = "textBoxIdAuxiliar";
            this.textBoxIdAuxiliar.Size = new System.Drawing.Size(166, 20);
            this.textBoxIdAuxiliar.TabIndex = 37;
            this.textBoxIdAuxiliar.Visible = false;
            // 
            // menu_cliente
            // 
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(800, 534);
            this.Controls.Add(this.panelInferior);
            this.Controls.Add(this.panelSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "menu_cliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Clientes";
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.panelInferior.ResumeLayout(false);
            this.panelInferior.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Panel panelInferior;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.TextBox txtProvincia;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblBuscador;
        private System.Windows.Forms.Label lblNuevoCliente;
        private System.Windows.Forms.Label LProvincia;
        private System.Windows.Forms.Label LFechaNacimiento;
        private System.Windows.Forms.Label LDNI;
        private System.Windows.Forms.Label LDireccion;
        private System.Windows.Forms.Label LLocalidad;
        private System.Windows.Forms.Label LEmail;
        private System.Windows.Forms.Label LApellido;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BConfirmar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIdCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSeleccion;
        private System.Windows.Forms.TextBox textBoxIdAuxiliar;
    }
}
