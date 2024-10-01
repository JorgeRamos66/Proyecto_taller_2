namespace proyecto2_prueba.Presentaciones.admin
{
    partial class modificar_producto
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxCategoria = new System.Windows.Forms.ComboBox();
            this.textBoxRutaFoto = new System.Windows.Forms.TextBox();
            this.BAgregarImagen = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBoxProducto = new System.Windows.Forms.PictureBox();
            this.BSalirModificacion = new System.Windows.Forms.Button();
            this.BModificarProducto = new System.Windows.Forms.Button();
            this.textBoxDescripcion = new System.Windows.Forms.TextBox();
            this.textBoxPrecio = new System.Windows.Forms.TextBox();
            this.textBoxStock = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LModificarProducto = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.Controls.Add(this.comboBoxCategoria);
            this.panel1.Controls.Add(this.textBoxRutaFoto);
            this.panel1.Controls.Add(this.BAgregarImagen);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.pictureBoxProducto);
            this.panel1.Controls.Add(this.BSalirModificacion);
            this.panel1.Controls.Add(this.BModificarProducto);
            this.panel1.Controls.Add(this.textBoxDescripcion);
            this.panel1.Controls.Add(this.textBoxPrecio);
            this.panel1.Controls.Add(this.textBoxStock);
            this.panel1.Controls.Add(this.textBoxNombre);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.LModificarProducto);
            this.panel1.Location = new System.Drawing.Point(42, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(658, 426);
            this.panel1.TabIndex = 0;
            // 
            // comboBoxCategoria
            // 
            this.comboBoxCategoria.FormattingEnabled = true;
            this.comboBoxCategoria.Items.AddRange(new object[] {
            "Estaciones Totales",
            "Niveles",
            "GPS",
            "Drones",
            "Otros"});
            this.comboBoxCategoria.Location = new System.Drawing.Point(135, 206);
            this.comboBoxCategoria.Name = "comboBoxCategoria";
            this.comboBoxCategoria.Size = new System.Drawing.Size(245, 21);
            this.comboBoxCategoria.TabIndex = 32;
            // 
            // textBoxRutaFoto
            // 
            this.textBoxRutaFoto.Location = new System.Drawing.Point(414, 118);
            this.textBoxRutaFoto.Name = "textBoxRutaFoto";
            this.textBoxRutaFoto.ReadOnly = true;
            this.textBoxRutaFoto.Size = new System.Drawing.Size(190, 20);
            this.textBoxRutaFoto.TabIndex = 31;
            // 
            // BAgregarImagen
            // 
            this.BAgregarImagen.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BAgregarImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BAgregarImagen.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAgregarImagen.Image = global::proyecto2_prueba.Properties.Resources.photo_24px;
            this.BAgregarImagen.Location = new System.Drawing.Point(447, 61);
            this.BAgregarImagen.Name = "BAgregarImagen";
            this.BAgregarImagen.Size = new System.Drawing.Size(118, 51);
            this.BAgregarImagen.TabIndex = 30;
            this.BAgregarImagen.Text = "Cambiar Imagen";
            this.BAgregarImagen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BAgregarImagen.UseVisualStyleBackColor = false;
            this.BAgregarImagen.Click += new System.EventHandler(this.BAgregarImagen_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(434, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 18);
            this.label6.TabIndex = 29;
            this.label6.Text = "Imagen del Producto";
            // 
            // pictureBoxProducto
            // 
            this.pictureBoxProducto.BackColor = System.Drawing.Color.DarkKhaki;
            this.pictureBoxProducto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxProducto.Location = new System.Drawing.Point(415, 165);
            this.pictureBoxProducto.Name = "pictureBoxProducto";
            this.pictureBoxProducto.Size = new System.Drawing.Size(190, 175);
            this.pictureBoxProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProducto.TabIndex = 28;
            this.pictureBoxProducto.TabStop = false;
            // 
            // BSalirModificacion
            // 
            this.BSalirModificacion.BackColor = System.Drawing.Color.Tomato;
            this.BSalirModificacion.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BSalirModificacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BSalirModificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BSalirModificacion.Image = global::proyecto2_prueba.Properties.Resources.log_out_32px;
            this.BSalirModificacion.Location = new System.Drawing.Point(415, 361);
            this.BSalirModificacion.Name = "BSalirModificacion";
            this.BSalirModificacion.Size = new System.Drawing.Size(103, 46);
            this.BSalirModificacion.TabIndex = 27;
            this.BSalirModificacion.Text = "SALIR";
            this.BSalirModificacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BSalirModificacion.UseVisualStyleBackColor = false;
            this.BSalirModificacion.Click += new System.EventHandler(this.BSalirModificacion_Click);
            // 
            // BModificarProducto
            // 
            this.BModificarProducto.BackColor = System.Drawing.Color.SteelBlue;
            this.BModificarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BModificarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BModificarProducto.Image = global::proyecto2_prueba.Properties.Resources.editar_32px;
            this.BModificarProducto.Location = new System.Drawing.Point(196, 361);
            this.BModificarProducto.Name = "BModificarProducto";
            this.BModificarProducto.Size = new System.Drawing.Size(123, 46);
            this.BModificarProducto.TabIndex = 26;
            this.BModificarProducto.Text = "MODIFICAR";
            this.BModificarProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BModificarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BModificarProducto.UseVisualStyleBackColor = false;
            this.BModificarProducto.Click += new System.EventHandler(this.BModificarProducto_Click);
            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.Location = new System.Drawing.Point(135, 253);
            this.textBoxDescripcion.Multiline = true;
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.Size = new System.Drawing.Size(245, 88);
            this.textBoxDescripcion.TabIndex = 25;
            // 
            // textBoxPrecio
            // 
            this.textBoxPrecio.Location = new System.Drawing.Point(135, 165);
            this.textBoxPrecio.Name = "textBoxPrecio";
            this.textBoxPrecio.Size = new System.Drawing.Size(245, 20);
            this.textBoxPrecio.TabIndex = 23;
            this.textBoxPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPrecio_KeyPress);
            // 
            // textBoxStock
            // 
            this.textBoxStock.Location = new System.Drawing.Point(135, 121);
            this.textBoxStock.Name = "textBoxStock";
            this.textBoxStock.Size = new System.Drawing.Size(245, 20);
            this.textBoxStock.TabIndex = 22;
            this.textBoxStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxStock_KeyPress);
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(135, 77);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(245, 20);
            this.textBoxNombre.TabIndex = 21;
            this.textBoxNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNombre_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(54, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Descripcion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(91, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "Stock";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(86, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "Precio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Categoria";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Nombre";
            // 
            // LModificarProducto
            // 
            this.LModificarProducto.AutoSize = true;
            this.LModificarProducto.BackColor = System.Drawing.Color.Tan;
            this.LModificarProducto.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LModificarProducto.Font = new System.Drawing.Font("Corbel", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LModificarProducto.Location = new System.Drawing.Point(207, 13);
            this.LModificarProducto.Name = "LModificarProducto";
            this.LModificarProducto.Size = new System.Drawing.Size(237, 33);
            this.LModificarProducto.TabIndex = 1;
            this.LModificarProducto.Text = "Modificar Producto";
            this.LModificarProducto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // modificar_producto
            // 
            this.AcceptButton = this.BModificarProducto;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.CancelButton = this.BSalirModificacion;
            this.ClientSize = new System.Drawing.Size(753, 450);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "modificar_producto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Producto";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProducto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LModificarProducto;
        private System.Windows.Forms.Button BAgregarImagen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BSalirModificacion;
        private System.Windows.Forms.Button BModificarProducto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBoxRutaFoto;
        public System.Windows.Forms.PictureBox pictureBoxProducto;
        public System.Windows.Forms.TextBox textBoxDescripcion;
        public System.Windows.Forms.TextBox textBoxPrecio;
        public System.Windows.Forms.TextBox textBoxStock;
        public System.Windows.Forms.TextBox textBoxNombre;
        public System.Windows.Forms.ComboBox comboBoxCategoria;
    }
}