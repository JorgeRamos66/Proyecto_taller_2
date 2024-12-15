using System;
using System.Drawing;
using System.Windows.Forms;

public class IngresarCantidad : Form
{
    private NumericUpDown numCantidad;
    private Button btnAceptar;
    private Label LIngreseCantidad;
    private Button btnCancelar;

    public int Cantidad => (int)numCantidad.Value;

    public IngresarCantidad()
    {
        InitializeComponent();
        ConfigurarEventos();
    }
    private void ConfigurarEventos()
    {
        // Agregar el manejador del evento KeyPress
        numCantidad.KeyPress += NumCantidad_KeyPress;

        // Agregar el manejador del evento ValueChanged
        numCantidad.ValueChanged += NumCantidad_ValueChanged;
    }
    private void NumCantidad_KeyPress(object sender, KeyPressEventArgs e)
    {
        // Solo permitir números y teclas de control
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        {
            e.Handled = true;
        }
    }

    private void NumCantidad_ValueChanged(object sender, EventArgs e)
    {
        // Asegurarse que el valor no sea menor a 1
        if (numCantidad.Value < 1)
        {
            numCantidad.Value = 1;
        }
    }
    private void InitializeComponent()
    {
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.LIngreseCantidad = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // numCantidad
            // 
            this.numCantidad.Location = new System.Drawing.Point(35, 37);
            this.numCantidad.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(120, 20);
            this.numCantidad.TabIndex = 0;
            this.numCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Green;
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAceptar.Location = new System.Drawing.Point(12, 65);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancelar.Location = new System.Drawing.Point(93, 65);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            // 
            // LIngreseCantidad
            // 
            this.LIngreseCantidad.AutoSize = true;
            this.LIngreseCantidad.BackColor = System.Drawing.Color.Tan;
            this.LIngreseCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LIngreseCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LIngreseCantidad.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LIngreseCantidad.Location = new System.Drawing.Point(35, 9);
            this.LIngreseCantidad.Name = "LIngreseCantidad";
            this.LIngreseCantidad.Size = new System.Drawing.Size(112, 18);
            this.LIngreseCantidad.TabIndex = 3;
            this.LIngreseCantidad.Text = "Ingrese cantidad:";
            // 
            // IngresarCantidad
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(184, 99);
            this.Controls.Add(this.LIngreseCantidad);
            this.Controls.Add(this.numCantidad);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IngresarCantidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ingrese cantidad";
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
}