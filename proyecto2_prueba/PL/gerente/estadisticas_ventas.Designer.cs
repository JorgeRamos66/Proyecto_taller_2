namespace proyecto2_prueba.PL.gerente
{
    partial class estadisticas_ventas
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
            this.chartDiasMasVendidos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartVendedoresMasRecaudaron = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LFechaInicioV = new System.Windows.Forms.Label();
            this.LFechaFinV = new System.Windows.Forms.Label();
            this.dateTimePickerInicioV = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFinV = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.chartDiasMasVendidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVendedoresMasRecaudaron)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(183, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "ESTADISTICAS VENTAS";
            // 
            // chartDiasMasVendidos
            // 
            this.chartDiasMasVendidos.BackColor = System.Drawing.Color.FloralWhite;
            chartArea1.Name = "ChartArea1";
            this.chartDiasMasVendidos.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartDiasMasVendidos.Legends.Add(legend1);
            this.chartDiasMasVendidos.Location = new System.Drawing.Point(394, 133);
            this.chartDiasMasVendidos.Name = "chartDiasMasVendidos";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartDiasMasVendidos.Series.Add(series1);
            this.chartDiasMasVendidos.Size = new System.Drawing.Size(623, 213);
            this.chartDiasMasVendidos.TabIndex = 4;
            this.chartDiasMasVendidos.Text = "Categorias";
            // 
            // chartVendedoresMasRecaudaron
            // 
            this.chartVendedoresMasRecaudaron.BackColor = System.Drawing.Color.FloralWhite;
            this.chartVendedoresMasRecaudaron.BorderlineColor = System.Drawing.Color.Black;
            chartArea2.Name = "ChartArea1";
            this.chartVendedoresMasRecaudaron.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartVendedoresMasRecaudaron.Legends.Add(legend2);
            this.chartVendedoresMasRecaudaron.Location = new System.Drawing.Point(394, 445);
            this.chartVendedoresMasRecaudaron.Name = "chartVendedoresMasRecaudaron";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartVendedoresMasRecaudaron.Series.Add(series2);
            this.chartVendedoresMasRecaudaron.Size = new System.Drawing.Size(623, 213);
            this.chartVendedoresMasRecaudaron.TabIndex = 5;
            this.chartVendedoresMasRecaudaron.Text = "Productos";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FloralWhite;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(204, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(613, 66);
            this.panel1.TabIndex = 3;
            // 
            // LFechaInicioV
            // 
            this.LFechaInicioV.AutoSize = true;
            this.LFechaInicioV.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaInicioV.Location = new System.Drawing.Point(83, 12);
            this.LFechaInicioV.Name = "LFechaInicioV";
            this.LFechaInicioV.Size = new System.Drawing.Size(84, 16);
            this.LFechaInicioV.TabIndex = 32;
            this.LFechaInicioV.Text = "Fecha Inicio:";
            // 
            // LFechaFinV
            // 
            this.LFechaFinV.AutoSize = true;
            this.LFechaFinV.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaFinV.Location = new System.Drawing.Point(83, 65);
            this.LFechaFinV.Name = "LFechaFinV";
            this.LFechaFinV.Size = new System.Drawing.Size(69, 16);
            this.LFechaFinV.TabIndex = 33;
            this.LFechaFinV.Text = "Fecha Fin:";
            // 
            // dateTimePickerInicioV
            // 
            this.dateTimePickerInicioV.Location = new System.Drawing.Point(17, 31);
            this.dateTimePickerInicioV.Name = "dateTimePickerInicioV";
            this.dateTimePickerInicioV.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerInicioV.TabIndex = 30;
            // 
            // dateTimePickerFinV
            // 
            this.dateTimePickerFinV.Location = new System.Drawing.Point(17, 84);
            this.dateTimePickerFinV.Name = "dateTimePickerFinV";
            this.dateTimePickerFinV.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerFinV.TabIndex = 31;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FloralWhite;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.LFechaInicioV);
            this.panel2.Controls.Add(this.LFechaFinV);
            this.panel2.Controls.Add(this.dateTimePickerInicioV);
            this.panel2.Controls.Add(this.dateTimePickerFinV);
            this.panel2.Location = new System.Drawing.Point(68, 345);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(237, 125);
            this.panel2.TabIndex = 6;
            // 
            // estadisticas_ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1084, 685);
            this.Controls.Add(this.chartDiasMasVendidos);
            this.Controls.Add(this.chartVendedoresMasRecaudaron);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "estadisticas_ventas";
            this.Text = "estadisticas_ventas";
            ((System.ComponentModel.ISupportInitialize)(this.chartDiasMasVendidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVendedoresMasRecaudaron)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDiasMasVendidos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVendedoresMasRecaudaron;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LFechaInicioV;
        private System.Windows.Forms.Label LFechaFinV;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicioV;
        private System.Windows.Forms.DateTimePicker dateTimePickerFinV;
        private System.Windows.Forms.Panel panel2;
    }
}