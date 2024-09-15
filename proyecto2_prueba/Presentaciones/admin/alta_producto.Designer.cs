namespace proyecto2_prueba.Presentaciones.admin
{
    partial class alta_producto
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LAgregarProducto = new System.Windows.Forms.Label();
            this.BSALIR_nuevoProducto = new System.Windows.Forms.Button();
            this.B_agregarProducto = new System.Windows.Forms.Button();
            this.textBoxDescripcion = new System.Windows.Forms.TextBox();
            this.textBoxPrecio = new System.Windows.Forms.TextBox();
            this.textBoxStock = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.comboBoxCategoria);
            this.panel1.Controls.Add(this.textBoxRutaFoto);
            this.panel1.Controls.Add(this.BAgregarImagen);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.LAgregarProducto);
            this.panel1.Controls.Add(this.BSALIR_nuevoProducto);
            this.panel1.Controls.Add(this.B_agregarProducto);
            this.panel1.Controls.Add(this.textBoxDescripcion);
            this.panel1.Controls.Add(this.textBoxPrecio);
            this.panel1.Controls.Add(this.textBoxStock);
            this.panel1.Controls.Add(this.textBoxNombre);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(49, 12);
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
            this.comboBoxCategoria.Location = new System.Drawing.Point(123, 213);
            this.comboBoxCategoria.Name = "comboBoxCategoria";
            this.comboBoxCategoria.Size = new System.Drawing.Size(245, 21);
            this.comboBoxCategoria.TabIndex = 16;
            // 
            // textBoxRutaFoto
            // 
            this.textBoxRutaFoto.Location = new System.Drawing.Point(402, 122);
            this.textBoxRutaFoto.Name = "textBoxRutaFoto";
            this.textBoxRutaFoto.ReadOnly = true;
            this.textBoxRutaFoto.Size = new System.Drawing.Size(190, 20);
            this.textBoxRutaFoto.TabIndex = 15;
            // 
            // BAgregarImagen
            // 
            this.BAgregarImagen.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BAgregarImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BAgregarImagen.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAgregarImagen.Image = global::proyecto2_prueba.Properties.Resources.photo_24px;
            this.BAgregarImagen.Location = new System.Drawing.Point(435, 65);
            this.BAgregarImagen.Name = "BAgregarImagen";
            this.BAgregarImagen.Size = new System.Drawing.Size(118, 51);
            this.BAgregarImagen.TabIndex = 14;
            this.BAgregarImagen.Text = "Agregar Imagen";
            this.BAgregarImagen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BAgregarImagen.UseVisualStyleBackColor = false;
            this.BAgregarImagen.Click += new System.EventHandler(this.BAgregarImagen_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(423, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 18);
            this.label6.TabIndex = 13;
            this.label6.Text = "Imagen del Producto";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkKhaki;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::proyecto2_prueba.Properties.Resources.producto_256px;
            this.pictureBox1.Location = new System.Drawing.Point(403, 169);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 175);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // LAgregarProducto
            // 
            this.LAgregarProducto.AutoSize = true;
            this.LAgregarProducto.BackColor = System.Drawing.Color.Tan;
            this.LAgregarProducto.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LAgregarProducto.Font = new System.Drawing.Font("Corbel", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LAgregarProducto.Location = new System.Drawing.Point(174, 17);
            this.LAgregarProducto.Name = "LAgregarProducto";
            this.LAgregarProducto.Size = new System.Drawing.Size(305, 33);
            this.LAgregarProducto.TabIndex = 0;
            this.LAgregarProducto.Text = "Agregar Nuevo Producto";
            this.LAgregarProducto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LAgregarProducto.Click += new System.EventHandler(this.LAgregarProducto_Click);
            // 
            // BSALIR_nuevoProducto
            // 
            this.BSALIR_nuevoProducto.BackColor = System.Drawing.Color.Tomato;
            this.BSALIR_nuevoProducto.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BSALIR_nuevoProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BSALIR_nuevoProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BSALIR_nuevoProducto.Image = global::proyecto2_prueba.Properties.Resources.log_out_32px;
            this.BSALIR_nuevoProducto.Location = new System.Drawing.Point(402, 365);
            this.BSALIR_nuevoProducto.Name = "BSALIR_nuevoProducto";
            this.BSALIR_nuevoProducto.Size = new System.Drawing.Size(103, 46);
            this.BSALIR_nuevoProducto.TabIndex = 11;
            this.BSALIR_nuevoProducto.Text = "SALIR";
            this.BSALIR_nuevoProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BSALIR_nuevoProducto.UseVisualStyleBackColor = false;
            this.BSALIR_nuevoProducto.Click += new System.EventHandler(this.BSALIR_nuevoProducto_Click);
            // 
            // B_agregarProducto
            // 
            this.B_agregarProducto.BackColor = System.Drawing.Color.SteelBlue;
            this.B_agregarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_agregarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_agregarProducto.Image = global::proyecto2_prueba.Properties.Resources.floppy_disk_32px;
            this.B_agregarProducto.Location = new System.Drawing.Point(191, 365);
            this.B_agregarProducto.Name = "B_agregarProducto";
            this.B_agregarProducto.Size = new System.Drawing.Size(110, 46);
            this.B_agregarProducto.TabIndex = 10;
            this.B_agregarProducto.Text = "GUARDAR";
            this.B_agregarProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_agregarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_agregarProducto.UseVisualStyleBackColor = false;
            this.B_agregarProducto.Click += new System.EventHandler(this.B_agregarProducto_Click);
            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.Location = new System.Drawing.Point(123, 257);
            this.textBoxDescripcion.Multiline = true;
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.Size = new System.Drawing.Size(245, 88);
            this.textBoxDescripcion.TabIndex = 9;
            // 
            // textBoxPrecio
            // 
            this.textBoxPrecio.Location = new System.Drawing.Point(123, 169);
            this.textBoxPrecio.Name = "textBoxPrecio";
            this.textBoxPrecio.Size = new System.Drawing.Size(245, 20);
            this.textBoxPrecio.TabIndex = 7;
            this.textBoxPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPrecio_KeyPress);
            // 
            // textBoxStock
            // 
            this.textBoxStock.Location = new System.Drawing.Point(123, 125);
            this.textBoxStock.Name = "textBoxStock";
            this.textBoxStock.Size = new System.Drawing.Size(245, 20);
            this.textBoxStock.TabIndex = 6;
            this.textBoxStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxStock_KeyPress);
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(123, 81);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(245, 20);
            this.textBoxNombre.TabIndex = 5;
            this.textBoxNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNombre_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(42, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Descripcion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(79, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Stock";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(74, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Precio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(53, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Categoria";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // alta_producto
            // 
            this.AcceptButton = this.B_agregarProducto;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.CancelButton = this.BSALIR_nuevoProducto;
            this.ClientSize = new System.Drawing.Size(753, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "alta_producto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta Producto";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LAgregarProducto;
        private System.Windows.Forms.TextBox textBoxDescripcion;
        private System.Windows.Forms.TextBox textBoxPrecio;
        private System.Windows.Forms.TextBox textBoxStock;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BSALIR_nuevoProducto;
        private System.Windows.Forms.Button B_agregarProducto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBoxRutaFoto;
        private System.Windows.Forms.Button BAgregarImagen;
        private System.Windows.Forms.ComboBox comboBoxCategoria;
    }
}