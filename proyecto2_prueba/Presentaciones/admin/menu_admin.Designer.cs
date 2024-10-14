namespace proyecto2_prueba
{
    partial class menu_admin
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
            this.menuStripAdmin = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarProgramaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMEmpleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMCategoriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMNivelesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.realizarBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restaurarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.sALIRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStripAdmin.SuspendLayout();
            this.menuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripAdmin
            // 
            this.menuStripAdmin.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.menuStripAdmin.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStripAdmin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.aBMProductosToolStripMenuItem,
            this.aBMEmpleadosToolStripMenuItem,
            this.aBMCategoriasToolStripMenuItem,
            this.aBMNivelesToolStripMenuItem,
            this.backupToolStripMenuItem});
            this.menuStripAdmin.Location = new System.Drawing.Point(0, 47);
            this.menuStripAdmin.Name = "menuStripAdmin";
            this.menuStripAdmin.Padding = new System.Windows.Forms.Padding(6, 1, 0, 1);
            this.menuStripAdmin.Size = new System.Drawing.Size(88, 368);
            this.menuStripAdmin.TabIndex = 0;
            this.menuStripAdmin.Text = "menuStripAdmin";
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
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(75, 52);
            this.archivoToolStripMenuItem.Text = "Menu";
            this.archivoToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.archivoToolStripMenuItem.Click += new System.EventHandler(this.archivoToolStripMenuItem_Click);
            // 
            // cerrarSesionToolStripMenuItem
            // 
            this.cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            this.cerrarSesionToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.cerrarSesionToolStripMenuItem.Text = "Cerrar Sesion";
            this.cerrarSesionToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesionToolStripMenuItem_Click);
            // 
            // cerrarProgramaToolStripMenuItem
            // 
            this.cerrarProgramaToolStripMenuItem.Name = "cerrarProgramaToolStripMenuItem";
            this.cerrarProgramaToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.cerrarProgramaToolStripMenuItem.Text = "Cerrar Programa";
            this.cerrarProgramaToolStripMenuItem.Click += new System.EventHandler(this.cerrarProgramaToolStripMenuItem_Click);
            // 
            // aBMProductosToolStripMenuItem
            // 
            this.aBMProductosToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aBMProductosToolStripMenuItem.Image = global::proyecto2_prueba.Properties.Resources.boxes_16px;
            this.aBMProductosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.aBMProductosToolStripMenuItem.Name = "aBMProductosToolStripMenuItem";
            this.aBMProductosToolStripMenuItem.Size = new System.Drawing.Size(75, 44);
            this.aBMProductosToolStripMenuItem.Text = "Productos";
            this.aBMProductosToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.aBMProductosToolStripMenuItem.Click += new System.EventHandler(this.aBMProductosToolStripMenuItem_Click);
            // 
            // aBMEmpleadosToolStripMenuItem
            // 
            this.aBMEmpleadosToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aBMEmpleadosToolStripMenuItem.Image = global::proyecto2_prueba.Properties.Resources.user_32px;
            this.aBMEmpleadosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.aBMEmpleadosToolStripMenuItem.Name = "aBMEmpleadosToolStripMenuItem";
            this.aBMEmpleadosToolStripMenuItem.Size = new System.Drawing.Size(75, 52);
            this.aBMEmpleadosToolStripMenuItem.Text = "Personal";
            this.aBMEmpleadosToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.aBMEmpleadosToolStripMenuItem.Click += new System.EventHandler(this.aBMEmpleadosToolStripMenuItem_Click);
            // 
            // aBMCategoriasToolStripMenuItem
            // 
            this.aBMCategoriasToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aBMCategoriasToolStripMenuItem.Image = global::proyecto2_prueba.Properties.Resources.categories_32px;
            this.aBMCategoriasToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.aBMCategoriasToolStripMenuItem.Name = "aBMCategoriasToolStripMenuItem";
            this.aBMCategoriasToolStripMenuItem.Size = new System.Drawing.Size(75, 52);
            this.aBMCategoriasToolStripMenuItem.Text = "Categorias";
            this.aBMCategoriasToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.aBMCategoriasToolStripMenuItem.Click += new System.EventHandler(this.aBMCategoriasToolStripMenuItem_Click);
            // 
            // aBMNivelesToolStripMenuItem
            // 
            this.aBMNivelesToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aBMNivelesToolStripMenuItem.Image = global::proyecto2_prueba.Properties.Resources.niveles_32px;
            this.aBMNivelesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.aBMNivelesToolStripMenuItem.Name = "aBMNivelesToolStripMenuItem";
            this.aBMNivelesToolStripMenuItem.Size = new System.Drawing.Size(75, 50);
            this.aBMNivelesToolStripMenuItem.Text = "Niveles";
            this.aBMNivelesToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.aBMNivelesToolStripMenuItem.Click += new System.EventHandler(this.aBMNivelesToolStripMenuItem_Click);
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.realizarBackupToolStripMenuItem,
            this.restaurarToolStripMenuItem});
            this.backupToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.backupToolStripMenuItem.Image = global::proyecto2_prueba.Properties.Resources.server_32px;
            this.backupToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(75, 54);
            this.backupToolStripMenuItem.Text = "Backup";
            this.backupToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // realizarBackupToolStripMenuItem
            // 
            this.realizarBackupToolStripMenuItem.Name = "realizarBackupToolStripMenuItem";
            this.realizarBackupToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.realizarBackupToolStripMenuItem.Text = "Realizar Backup";
            // 
            // restaurarToolStripMenuItem
            // 
            this.restaurarToolStripMenuItem.Name = "restaurarToolStripMenuItem";
            this.restaurarToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.restaurarToolStripMenuItem.Text = "Restaurar";
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
            this.sALIRToolStripMenuItem.Click += new System.EventHandler(this.sALIRToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(333, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "MENU ADMINISTRADOR";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menu_admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(800, 415);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStripAdmin);
            this.Controls.Add(this.menuPrincipal);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStripAdmin;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "menu_admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Administrador";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.menu_admin_FormClosed);
            this.menuStripAdmin.ResumeLayout(false);
            this.menuStripAdmin.PerformLayout();
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripAdmin;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarProgramaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMEmpleadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMCategoriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMNivelesToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem sALIRToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem realizarBackupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restaurarToolStripMenuItem;
    }
}