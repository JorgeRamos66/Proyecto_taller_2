namespace proyecto2_prueba.PL.gerente
{
    partial class estadisticas_stock
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chartStockSinMover = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LFechaInicioS = new System.Windows.Forms.Label();
            this.LFechaFinS = new System.Windows.Forms.Label();
            this.dateTimePickerInicioS = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFinS = new System.Windows.Forms.DateTimePicker();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStockSinMover)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FloralWhite;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(386, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 102);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(23, 252);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(383, 366);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(127, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "CONTROL DE STOCK";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CProducto,
            this.CCategoria,
            this.CStock});
            this.dataGridView1.Location = new System.Drawing.Point(17, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(345, 309);
            this.dataGridView1.TabIndex = 0;
            // 
            // CProducto
            // 
            this.CProducto.HeaderText = "Producto";
            this.CProducto.Name = "CProducto";
            this.CProducto.ReadOnly = true;
            // 
            // CCategoria
            // 
            this.CCategoria.HeaderText = "Categoria";
            this.CCategoria.Name = "CCategoria";
            this.CCategoria.ReadOnly = true;
            // 
            // CStock
            // 
            this.CStock.HeaderText = "Stock";
            this.CStock.Name = "CStock";
            this.CStock.ReadOnly = true;
            // 
            // chartStockSinMover
            // 
            chartArea1.Name = "ChartArea1";
            this.chartStockSinMover.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartStockSinMover.Legends.Add(legend1);
            this.chartStockSinMover.Location = new System.Drawing.Point(21, 60);
            this.chartStockSinMover.Name = "chartStockSinMover";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartStockSinMover.Series.Add(series1);
            this.chartStockSinMover.Size = new System.Drawing.Size(690, 283);
            this.chartStockSinMover.TabIndex = 1;
            this.chartStockSinMover.Text = "chart1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FloralWhite;
            this.label2.Location = new System.Drawing.Point(193, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "STOCK SIN MOVER";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FloralWhite;
            this.label3.Location = new System.Drawing.Point(51, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(282, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "PRODUCTOS SIN STOCK";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FloralWhite;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.LFechaInicioS);
            this.panel3.Controls.Add(this.LFechaFinS);
            this.panel3.Controls.Add(this.dateTimePickerInicioS);
            this.panel3.Controls.Add(this.dateTimePickerFinS);
            this.panel3.Location = new System.Drawing.Point(520, 130);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(218, 97);
            this.panel3.TabIndex = 7;
            // 
            // LFechaInicioS
            // 
            this.LFechaInicioS.AutoSize = true;
            this.LFechaInicioS.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaInicioS.Location = new System.Drawing.Point(72, 6);
            this.LFechaInicioS.Name = "LFechaInicioS";
            this.LFechaInicioS.Size = new System.Drawing.Size(84, 16);
            this.LFechaInicioS.TabIndex = 32;
            this.LFechaInicioS.Text = "Fecha Inicio:";
            // 
            // LFechaFinS
            // 
            this.LFechaFinS.AutoSize = true;
            this.LFechaFinS.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaFinS.Location = new System.Drawing.Point(72, 48);
            this.LFechaFinS.Name = "LFechaFinS";
            this.LFechaFinS.Size = new System.Drawing.Size(69, 16);
            this.LFechaFinS.TabIndex = 33;
            this.LFechaFinS.Text = "Fecha Fin:";
            // 
            // dateTimePickerInicioS
            // 
            this.dateTimePickerInicioS.Location = new System.Drawing.Point(6, 25);
            this.dateTimePickerInicioS.Name = "dateTimePickerInicioS";
            this.dateTimePickerInicioS.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerInicioS.TabIndex = 30;
            // 
            // dateTimePickerFinS
            // 
            this.dateTimePickerFinS.Location = new System.Drawing.Point(6, 67);
            this.dateTimePickerFinS.Name = "dateTimePickerFinS";
            this.dateTimePickerFinS.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerFinS.TabIndex = 31;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SteelBlue;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.chartStockSinMover);
            this.panel4.Location = new System.Drawing.Point(443, 252);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(733, 366);
            this.panel4.TabIndex = 4;
            // 
            // estadisticas_stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1192, 630);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "estadisticas_stock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "estadisticas_stock";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStockSinMover)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn CStock;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStockSinMover;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LFechaInicioS;
        private System.Windows.Forms.Label LFechaFinS;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicioS;
        private System.Windows.Forms.DateTimePicker dateTimePickerFinS;
        private System.Windows.Forms.Panel panel4;
    }
}