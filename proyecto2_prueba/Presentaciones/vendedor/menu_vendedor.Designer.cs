namespace proyecto2_prueba
{
    partial class menu_vendedor
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
            this.menuStripGerente = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarProgramaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuItemCarrito = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuItemMiHistorial = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.sALIRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStripGerente.SuspendLayout();
            this.menuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripGerente
            // 
            this.menuStripGerente.BackColor = System.Drawing.Color.Gold;
            this.menuStripGerente.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStripGerente.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.StripMenuItemCarrito,
            this.StripMenuItemMiHistorial});
            this.menuStripGerente.Location = new System.Drawing.Point(0, 47);
            this.menuStripGerente.Name = "menuStripGerente";
            this.menuStripGerente.Padding = new System.Windows.Forms.Padding(6, 1, 0, 1);
            this.menuStripGerente.Size = new System.Drawing.Size(126, 368);
            this.menuStripGerente.TabIndex = 0;
            this.menuStripGerente.Text = "menuStripGerente";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarSesionToolStripMenuItem,
            this.cerrarProgramaToolStripMenuItem});
            this.archivoToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.archivoToolStripMenuItem.Image = global::proyecto2_prueba.Properties.Resources.main_32px;
            this.archivoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(113, 52);
            this.archivoToolStripMenuItem.Text = "Menu";
            this.archivoToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // cerrarSesionToolStripMenuItem
            // 
            this.cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            this.cerrarSesionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cerrarSesionToolStripMenuItem.Text = "Cerrar Sesion";
            this.cerrarSesionToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesionToolStripMenuItem_Click_1);
            // 
            // cerrarProgramaToolStripMenuItem
            // 
            this.cerrarProgramaToolStripMenuItem.Name = "cerrarProgramaToolStripMenuItem";
            this.cerrarProgramaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cerrarProgramaToolStripMenuItem.Text = "Cerrar Programa";
            this.cerrarProgramaToolStripMenuItem.Click += new System.EventHandler(this.cerrarProgramaToolStripMenuItem_Click_1);
            // 
            // StripMenuItemCarrito
            // 
            this.StripMenuItemCarrito.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StripMenuItemCarrito.Image = global::proyecto2_prueba.Properties.Resources.shopping_cart__1_;
            this.StripMenuItemCarrito.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.StripMenuItemCarrito.Name = "StripMenuItemCarrito";
            this.StripMenuItemCarrito.Size = new System.Drawing.Size(113, 52);
            this.StripMenuItemCarrito.Text = "Carrito";
            this.StripMenuItemCarrito.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.StripMenuItemCarrito.Click += new System.EventHandler(this.StripMenuItemCarrito_Click);
            // 
            // StripMenuItemMiHistorial
            // 
            this.StripMenuItemMiHistorial.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StripMenuItemMiHistorial.Image = global::proyecto2_prueba.Properties.Resources.pie_chart;
            this.StripMenuItemMiHistorial.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.StripMenuItemMiHistorial.Name = "StripMenuItemMiHistorial";
            this.StripMenuItemMiHistorial.Size = new System.Drawing.Size(113, 52);
            this.StripMenuItemMiHistorial.Text = "Mi historial";
            this.StripMenuItemMiHistorial.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.StripMenuItemMiHistorial.Click += new System.EventHandler(this.StripMenuItemMiHistorial_Click);
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.AutoSize = false;
            this.menuPrincipal.BackColor = System.Drawing.Color.SteelBlue;
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sALIRToolStripMenuItem});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuPrincipal.Size = new System.Drawing.Size(800, 47);
            this.menuPrincipal.TabIndex = 1;
            this.menuPrincipal.Text = "MenuPrincipal";
            // 
            // sALIRToolStripMenuItem
            // 
            this.sALIRToolStripMenuItem.BackColor = System.Drawing.Color.Tomato;
            this.sALIRToolStripMenuItem.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sALIRToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.sALIRToolStripMenuItem.Image = global::proyecto2_prueba.Properties.Resources.log_out_32px;
            this.sALIRToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sALIRToolStripMenuItem.Name = "sALIRToolStripMenuItem";
            this.sALIRToolStripMenuItem.Size = new System.Drawing.Size(87, 43);
            this.sALIRToolStripMenuItem.Text = "SALIR";
            this.sALIRToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "MENU VENDEDOR";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menu_vendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(800, 415);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStripGerente);
            this.Controls.Add(this.menuPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStripGerente;
            this.Name = "menu_vendedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "menu_gerente";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStripGerente.ResumeLayout(false);
            this.menuStripGerente.PerformLayout();
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripGerente;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarProgramaToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem sALIRToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem StripMenuItemCarrito;
        private System.Windows.Forms.ToolStripMenuItem StripMenuItemMiHistorial;
    }
}
