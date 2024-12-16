namespace proyecto2_prueba
{
    partial class menu_gerente
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
            this.toolStripMenuItemHome = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuItemCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuItemCerrarPrograma = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuItemEstadisticasProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuEstadisticasVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuItemStock = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.sALIRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.LNombreUsuario = new System.Windows.Forms.Label();
            this.menuStripGerente.SuspendLayout();
            this.menuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripGerente
            // 
            this.menuStripGerente.BackColor = System.Drawing.Color.LightBlue;
            this.menuStripGerente.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStripGerente.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemHome,
            this.StripMenuItemEstadisticasProductos,
            this.ToolStripMenuEstadisticasVentas,
            this.StripMenuItemStock});
            this.menuStripGerente.Location = new System.Drawing.Point(0, 47);
            this.menuStripGerente.Name = "menuStripGerente";
            this.menuStripGerente.Padding = new System.Windows.Forms.Padding(6, 1, 0, 1);
            this.menuStripGerente.Size = new System.Drawing.Size(126, 368);
            this.menuStripGerente.TabIndex = 0;
            this.menuStripGerente.Text = "menuStripGerente";
            // 
            // toolStripMenuItemHome
            // 
            this.toolStripMenuItemHome.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripMenuItemCerrarSesion,
            this.StripMenuItemCerrarPrograma});
            this.toolStripMenuItemHome.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItemHome.Image = global::proyecto2_prueba.Properties.Resources.main_32px;
            this.toolStripMenuItemHome.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItemHome.Name = "toolStripMenuItemHome";
            this.toolStripMenuItemHome.Size = new System.Drawing.Size(113, 52);
            this.toolStripMenuItemHome.Text = "Menu";
            this.toolStripMenuItemHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // StripMenuItemCerrarSesion
            // 
            this.StripMenuItemCerrarSesion.Name = "StripMenuItemCerrarSesion";
            this.StripMenuItemCerrarSesion.Size = new System.Drawing.Size(180, 22);
            this.StripMenuItemCerrarSesion.Text = "Cerrar Sesion";
            this.StripMenuItemCerrarSesion.Click += new System.EventHandler(this.StripMenuItemCerrarSesion_Click);
            // 
            // StripMenuItemCerrarPrograma
            // 
            this.StripMenuItemCerrarPrograma.Name = "StripMenuItemCerrarPrograma";
            this.StripMenuItemCerrarPrograma.Size = new System.Drawing.Size(180, 22);
            this.StripMenuItemCerrarPrograma.Text = "Cerrar Programa";
            this.StripMenuItemCerrarPrograma.Click += new System.EventHandler(this.StripMenuItemCerrarPrograma_Click);
            // 
            // StripMenuItemEstadisticasProductos
            // 
            this.StripMenuItemEstadisticasProductos.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StripMenuItemEstadisticasProductos.Image = global::proyecto2_prueba.Properties.Resources.analytic_10802930;
            this.StripMenuItemEstadisticasProductos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.StripMenuItemEstadisticasProductos.Name = "StripMenuItemEstadisticasProductos";
            this.StripMenuItemEstadisticasProductos.Size = new System.Drawing.Size(113, 52);
            this.StripMenuItemEstadisticasProductos.Text = "Productos";
            this.StripMenuItemEstadisticasProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.StripMenuItemEstadisticasProductos.Click += new System.EventHandler(this.StripMenuItemEstadisticasProductos_Click);
            // 
            // ToolStripMenuEstadisticasVentas
            // 
            this.ToolStripMenuEstadisticasVentas.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripMenuEstadisticasVentas.Image = global::proyecto2_prueba.Properties.Resources.chart_7461071;
            this.ToolStripMenuEstadisticasVentas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolStripMenuEstadisticasVentas.Name = "ToolStripMenuEstadisticasVentas";
            this.ToolStripMenuEstadisticasVentas.Size = new System.Drawing.Size(113, 52);
            this.ToolStripMenuEstadisticasVentas.Text = "Ventas";
            this.ToolStripMenuEstadisticasVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolStripMenuEstadisticasVentas.Click += new System.EventHandler(this.ToolStripMenuEstadisticasVentas_Click);
            // 
            // StripMenuItemStock
            // 
            this.StripMenuItemStock.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StripMenuItemStock.Image = global::proyecto2_prueba.Properties.Resources.boxes_32px;
            this.StripMenuItemStock.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.StripMenuItemStock.Name = "StripMenuItemStock";
            this.StripMenuItemStock.Size = new System.Drawing.Size(113, 52);
            this.StripMenuItemStock.Text = "Stock";
            this.StripMenuItemStock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.StripMenuItemStock.Click += new System.EventHandler(this.StripMenuItemStock_Click);
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
            this.label1.ForeColor = System.Drawing.Color.LightBlue;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "MENU GERENTE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LNombreUsuario
            // 
            this.LNombreUsuario.AutoSize = true;
            this.LNombreUsuario.BackColor = System.Drawing.Color.SteelBlue;
            this.LNombreUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LNombreUsuario.Font = new System.Drawing.Font("Microsoft Tai Le", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNombreUsuario.ForeColor = System.Drawing.Color.LightBlue;
            this.LNombreUsuario.Location = new System.Drawing.Point(237, 9);
            this.LNombreUsuario.Name = "LNombreUsuario";
            this.LNombreUsuario.Size = new System.Drawing.Size(69, 34);
            this.LNombreUsuario.TabIndex = 4;
            this.LNombreUsuario.Text = "user";
            this.LNombreUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menu_gerente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(800, 415);
            this.Controls.Add(this.LNombreUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStripGerente);
            this.Controls.Add(this.menuPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStripGerente;
            this.Name = "menu_gerente";
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
        private System.Windows.Forms.ToolStripMenuItem StripMenuItemEstadisticasProductos;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuEstadisticasVentas;
        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem sALIRToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LNombreUsuario;
        private System.Windows.Forms.ToolStripMenuItem StripMenuItemStock;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHome;
        private System.Windows.Forms.ToolStripMenuItem StripMenuItemCerrarSesion;
        private System.Windows.Forms.ToolStripMenuItem StripMenuItemCerrarPrograma;
    }
}
