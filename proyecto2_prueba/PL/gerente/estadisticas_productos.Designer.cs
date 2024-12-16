using System.Windows.Forms.DataVisualization.Charting;

namespace proyecto2_prueba.PL.gerente
{
    partial class estadisticas_productos
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chartProductosMasVendidos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartCategoriasMasVendidas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.LFechaFin = new System.Windows.Forms.Label();
            this.LFechaInicio = new System.Windows.Forms.Label();
            this.dateTimePickerFin = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerInicio = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartProductosMasVendidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCategoriasMasVendidas)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(164, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "ESTADISTICAS PRODUCTOS";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FloralWhite;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(187, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(613, 66);
            this.panel1.TabIndex = 1;
            // 
            // chartProductosMasVendidos
            // 
            this.chartProductosMasVendidos.BackColor = System.Drawing.Color.FloralWhite;
            this.chartProductosMasVendidos.BorderlineColor = System.Drawing.Color.Black;
            chartArea1.Name = "ChartArea1";
            this.chartProductosMasVendidos.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartProductosMasVendidos.Legends.Add(legend1);
            this.chartProductosMasVendidos.Location = new System.Drawing.Point(25, 235);
            this.chartProductosMasVendidos.Name = "chartProductosMasVendidos";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartProductosMasVendidos.Series.Add(series1);
            this.chartProductosMasVendidos.Size = new System.Drawing.Size(444, 349);
            this.chartProductosMasVendidos.TabIndex = 2;
            this.chartProductosMasVendidos.Text = "Productos";
            // 
            // chartCategoriasMasVendidas
            // 
            this.chartCategoriasMasVendidas.BackColor = System.Drawing.Color.FloralWhite;
            chartArea2.Name = "ChartArea1";
            this.chartCategoriasMasVendidas.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartCategoriasMasVendidas.Legends.Add(legend2);
            this.chartCategoriasMasVendidas.Location = new System.Drawing.Point(26, 35);
            this.chartCategoriasMasVendidas.Name = "chartCategoriasMasVendidas";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartCategoriasMasVendidas.Series.Add(series2);
            this.chartCategoriasMasVendidas.Size = new System.Drawing.Size(428, 349);
            this.chartCategoriasMasVendidas.TabIndex = 2;
            this.chartCategoriasMasVendidas.Text = "Categorias";
            // 
            // LFechaFin
            // 
            this.LFechaFin.AutoSize = true;
            this.LFechaFin.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaFin.Location = new System.Drawing.Point(315, 12);
            this.LFechaFin.Name = "LFechaFin";
            this.LFechaFin.Size = new System.Drawing.Size(69, 16);
            this.LFechaFin.TabIndex = 33;
            this.LFechaFin.Text = "Fecha Fin:";
            // 
            // LFechaInicio
            // 
            this.LFechaInicio.AutoSize = true;
            this.LFechaInicio.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaInicio.Location = new System.Drawing.Point(19, 12);
            this.LFechaInicio.Name = "LFechaInicio";
            this.LFechaInicio.Size = new System.Drawing.Size(84, 16);
            this.LFechaInicio.TabIndex = 32;
            this.LFechaInicio.Text = "Fecha Inicio:";
            // 
            // dateTimePickerFin
            // 
            this.dateTimePickerFin.Location = new System.Drawing.Point(390, 9);
            this.dateTimePickerFin.Name = "dateTimePickerFin";
            this.dateTimePickerFin.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerFin.TabIndex = 31;
            // 
            // dateTimePickerInicio
            // 
            this.dateTimePickerInicio.Location = new System.Drawing.Point(109, 9);
            this.dateTimePickerInicio.MaxDate = new System.DateTime(2024, 12, 16, 0, 0, 0, 0);
            this.dateTimePickerInicio.Name = "dateTimePickerInicio";
            this.dateTimePickerInicio.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerInicio.TabIndex = 30;
            this.dateTimePickerInicio.Value = new System.DateTime(2024, 12, 16, 0, 0, 0, 0);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FloralWhite;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.LFechaInicio);
            this.panel2.Controls.Add(this.LFechaFin);
            this.panel2.Controls.Add(this.dateTimePickerInicio);
            this.panel2.Controls.Add(this.dateTimePickerFin);
            this.panel2.Location = new System.Drawing.Point(187, 121);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(613, 39);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(12, 190);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(472, 408);
            this.panel3.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FloralWhite;
            this.label2.Location = new System.Drawing.Point(104, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "TOP PRODUCTOS";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SteelBlue;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.chartCategoriasMasVendidas);
            this.panel4.Location = new System.Drawing.Point(529, 190);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(472, 408);
            this.panel4.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FloralWhite;
            this.label3.Location = new System.Drawing.Point(129, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(211, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "TOP CATEGORIAS";
            // 
            // estadisticas_productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1013, 610);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.chartProductosMasVendidos);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "estadisticas_productos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "estadisticas_productos";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartProductosMasVendidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCategoriasMasVendidas)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private Chart chartProductosMasVendidos;
        private Chart chartCategoriasMasVendidas;
        private System.Windows.Forms.Label LFechaFin;
        private System.Windows.Forms.Label LFechaInicio;
        private System.Windows.Forms.DateTimePicker dateTimePickerFin;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicio;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
    }
}