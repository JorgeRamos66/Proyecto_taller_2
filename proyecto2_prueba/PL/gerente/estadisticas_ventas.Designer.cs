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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.chartDiasMasVendidos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartVendedoresMasRecaudaron = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LFechaInicioV = new System.Windows.Forms.Label();
            this.LFechaFinV = new System.Windows.Forms.Label();
            this.dateTimePickerInicioV = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFinV = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.labelGananciaMenusal = new System.Windows.Forms.Label();
            this.chartGananciaMensual = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel5 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.chartDiasMasVendidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVendedoresMasRecaudaron)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartGananciaMensual)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(172, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "ESTADISTICAS VENTAS";
            // 
            // chartDiasMasVendidos
            // 
            this.chartDiasMasVendidos.BackColor = System.Drawing.Color.FloralWhite;
            chartArea4.Name = "ChartArea1";
            this.chartDiasMasVendidos.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartDiasMasVendidos.Legends.Add(legend4);
            this.chartDiasMasVendidos.Location = new System.Drawing.Point(14, 45);
            this.chartDiasMasVendidos.Name = "chartDiasMasVendidos";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartDiasMasVendidos.Series.Add(series4);
            this.chartDiasMasVendidos.Size = new System.Drawing.Size(455, 202);
            this.chartDiasMasVendidos.TabIndex = 4;
            this.chartDiasMasVendidos.Text = "Categorias";
            // 
            // chartVendedoresMasRecaudaron
            // 
            this.chartVendedoresMasRecaudaron.BackColor = System.Drawing.Color.FloralWhite;
            this.chartVendedoresMasRecaudaron.BorderlineColor = System.Drawing.Color.Black;
            chartArea5.Name = "ChartArea1";
            this.chartVendedoresMasRecaudaron.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chartVendedoresMasRecaudaron.Legends.Add(legend5);
            this.chartVendedoresMasRecaudaron.Location = new System.Drawing.Point(15, 47);
            this.chartVendedoresMasRecaudaron.Name = "chartVendedoresMasRecaudaron";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chartVendedoresMasRecaudaron.Series.Add(series5);
            this.chartVendedoresMasRecaudaron.Size = new System.Drawing.Size(455, 202);
            this.chartVendedoresMasRecaudaron.TabIndex = 5;
            this.chartVendedoresMasRecaudaron.Text = "Productos";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FloralWhite;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(208, 29);
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
            this.LFechaFinV.Location = new System.Drawing.Point(292, 12);
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
            this.dateTimePickerFinV.Location = new System.Drawing.Point(226, 31);
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
            this.panel2.Location = new System.Drawing.Point(295, 111);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(444, 66);
            this.panel2.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.chartDiasMasVendidos);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(16, 382);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(491, 266);
            this.panel3.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FloralWhite;
            this.label2.Location = new System.Drawing.Point(104, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "DIAS MAS VENDIDOS";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SteelBlue;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.chartVendedoresMasRecaudaron);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(570, 382);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(491, 266);
            this.panel4.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FloralWhite;
            this.label3.Location = new System.Drawing.Point(129, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "TOP VENDEDORES";
            // 
            // labelGananciaMenusal
            // 
            this.labelGananciaMenusal.AutoSize = true;
            this.labelGananciaMenusal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGananciaMenusal.ForeColor = System.Drawing.Color.FloralWhite;
            this.labelGananciaMenusal.Location = new System.Drawing.Point(355, 7);
            this.labelGananciaMenusal.Name = "labelGananciaMenusal";
            this.labelGananciaMenusal.Size = new System.Drawing.Size(289, 25);
            this.labelGananciaMenusal.TabIndex = 0;
            this.labelGananciaMenusal.Text = "GANANCIAS MENSUALES";
            // 
            // chartGananciaMensual
            // 
            this.chartGananciaMensual.BackColor = System.Drawing.Color.FloralWhite;
            chartArea6.Name = "ChartArea1";
            this.chartGananciaMensual.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chartGananciaMensual.Legends.Add(legend6);
            this.chartGananciaMensual.Location = new System.Drawing.Point(14, 40);
            this.chartGananciaMensual.Name = "chartGananciaMensual";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chartGananciaMensual.Series.Add(series6);
            this.chartGananciaMensual.Size = new System.Drawing.Size(1010, 106);
            this.chartGananciaMensual.TabIndex = 4;
            this.chartGananciaMensual.Text = "Categorias";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SteelBlue;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.chartGananciaMensual);
            this.panel5.Controls.Add(this.labelGananciaMenusal);
            this.panel5.Location = new System.Drawing.Point(16, 200);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1045, 162);
            this.panel5.TabIndex = 5;
            // 
            // estadisticas_ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1084, 685);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "estadisticas_ventas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "estadisticas_ventas";
            ((System.ComponentModel.ISupportInitialize)(this.chartDiasMasVendidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVendedoresMasRecaudaron)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartGananciaMensual)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
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
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelGananciaMenusal;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGananciaMensual;
        private System.Windows.Forms.Panel panel5;
    }
}