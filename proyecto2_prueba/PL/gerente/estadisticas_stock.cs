using proyecto2_prueba.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace proyecto2_prueba.PL.gerente
{
    public partial class estadisticas_stock : Form
    {
        private readonly EstadisticasStockBLL _stockBLL;

        public estadisticas_stock()
        {
            InitializeComponent();
            _stockBLL = new EstadisticasStockBLL();
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            ConfigurarControles();
        }

        private void ConfigurarDataGridView()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;

            // Configurar columnas manualmente
            dataGridView1.Columns.AddRange(new DataGridViewColumn[]
            {
            new DataGridViewTextBoxColumn
            {
                Name = "CProducto",
                DataPropertyName = "Producto",
                HeaderText = "Producto",
                Width = 150,
                ReadOnly = true
            },
            new DataGridViewTextBoxColumn
            {
                Name = "CCategoria",
                DataPropertyName = "Categoria",
                HeaderText = "Categoría",
                Width = 100,
                ReadOnly = true
            },
            new DataGridViewTextBoxColumn
            {
                Name = "CStock",
                DataPropertyName = "Stock",
                HeaderText = "Stock",
                Width = 60,
                ReadOnly = true
            }
            });

            // Configurar estilos
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.BackgroundColor = Color.White;
        }

        private void ConfigurarControles()
        {
            try
            {
                // Configurar DataGridView
                ConfigurarDataGridView();

                // Configurar Chart
                ConfigurarGrafico();

                // Configurar fechas
                ConfigurarFechas();

                // Suscribirse al evento Load
                this.Load += estadisticas_stock_Load;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al configurar controles: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrafico()
        {
            chartStockSinMover.Series.Clear();

            // Configurar área del gráfico
            var area = chartStockSinMover.ChartAreas[0];

            // Configurar eje X
            area.AxisX.LabelStyle.Angle = -45;
            area.AxisX.LabelStyle.Font = new Font("Arial", 8);
            area.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            area.AxisX.Interval = 1;
            area.AxisX.LabelAutoFitStyle = LabelAutoFitStyles.WordWrap;

            // Ajustar márgenes
            area.InnerPlotPosition.Auto = false;
            area.InnerPlotPosition.Width = 85;
            area.InnerPlotPosition.Height = 65;
            area.InnerPlotPosition.X = 5;
            area.InnerPlotPosition.Y = 5;

            // Configurar eje Y
            area.AxisY.LabelStyle.Format = "N0";
            area.AxisY.Title = "Cantidad";
            area.AxisY.TitleFont = new Font("Arial", 10, FontStyle.Bold);

            // Agregar series
            var seriesStockTotal = chartStockSinMover.Series.Add("Stock Total");
            var seriesStockMovido = chartStockSinMover.Series.Add("Stock Movido");

            seriesStockTotal.ChartType = SeriesChartType.Column;
            seriesStockMovido.ChartType = SeriesChartType.Column;

            seriesStockTotal.Color = Color.SteelBlue;
            seriesStockMovido.Color = Color.Crimson;

            // Configurar leyenda
            chartStockSinMover.Legends[0].Docking = Docking.Top;
            chartStockSinMover.Legends[0].Alignment = StringAlignment.Center;

            // Configurar ancho de columnas
            seriesStockTotal["PointWidth"] = "0.8";
            seriesStockMovido["PointWidth"] = "0.8";
        }

        private void ConfigurarFechas()
        {
            dateTimePickerFinS.Value = DateTime.Now;
            dateTimePickerFinS.MaxDate = DateTime.Now;
            dateTimePickerInicioS.Value = DateTime.Now.AddMonths(-1);
            dateTimePickerInicioS.MaxDate = DateTime.Now;

            // Agregar eventos para validación
            dateTimePickerInicioS.CloseUp += ValidarFechaInicio;
            dateTimePickerFinS.CloseUp += ValidarFechaFin;

            dateTimePickerInicioS.ValueChanged += (s, e) => ActualizarGraficoStock();
            dateTimePickerFinS.ValueChanged += (s, e) => ActualizarGraficoStock();
        }

        private void ValidarFechaInicio(object sender, EventArgs e)
        {
            // Si la fecha inicio es mayor que la fecha fin, la ajustamos
            if (dateTimePickerInicioS.Value > dateTimePickerFinS.Value)
            {
                dateTimePickerInicioS.Value = dateTimePickerFinS.Value;
            }
        }

        private void ValidarFechaFin(object sender, EventArgs e)
        {
            // Si la fecha fin es mayor que hoy, la ajustamos a hoy
            if (dateTimePickerFinS.Value > DateTime.Now)
            {
                dateTimePickerFinS.Value = DateTime.Now;
            }

            // Si la fecha fin es menor que la fecha inicio, ajustamos la fecha inicio
            if (dateTimePickerFinS.Value < dateTimePickerInicioS.Value)
            {
                dateTimePickerInicioS.Value = dateTimePickerFinS.Value;
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["CStock"].Index)
            {
                if (e.Value != null && int.TryParse(e.Value.ToString(), out int stock))
                {
                    if (stock <= 5)
                    {
                        e.CellStyle.BackColor = Color.Red;
                    }
                    else if (stock <= 10)
                    {
                        e.CellStyle.BackColor = Color.Orange;
                    }
                    else if (stock <= 20)
                    {
                        e.CellStyle.BackColor = Color.Yellow;
                    }
                }
            }
        }

        private void CargarDatos()
        {
            try
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

                var dt = _stockBLL.ObtenerProductosBajoStock();

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron datos de stock.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dataGridView1.DataSource = dt;

                // Aplicar colores según el stock
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["CStock"].Value != null)
                    {
                        int stock = Convert.ToInt32(row.Cells["CStock"].Value);
                        int redIntensity = Math.Max(255 - (stock * 10), 0);
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255 - redIntensity, 255 - redIntensity);
                    }
                }

                ActualizarGraficoStock();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
            }
        }

        private void estadisticas_stock_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }


        private void ActualizarGraficoStock()
        {
            var dt = _stockBLL.ObtenerStockSinMover(
                dateTimePickerInicioS.Value,
                dateTimePickerFinS.Value
            );

            chartStockSinMover.Series["Stock Total"].Points.Clear();
            chartStockSinMover.Series["Stock Movido"].Points.Clear();

            // Ajustar el tamaño del área según la cantidad de productos
            int cantidadProductos = dt.Rows.Count;
            chartStockSinMover.ChartAreas[0].AxisX.Interval = Math.Max(1, cantidadProductos / 15.0);

            foreach (DataRow row in dt.Rows)
            {
                string producto = row["nombre_producto"].ToString();
                double stockTotal = Convert.ToDouble(row["StockTotal"]);
                double stockMovido = Convert.ToDouble(row["StockMovido"]);

                var pointTotal = chartStockSinMover.Series["Stock Total"].Points.Add(stockTotal);
                var pointMovido = chartStockSinMover.Series["Stock Movido"].Points.Add(stockMovido);

                pointTotal.AxisLabel = producto;
                pointTotal.Label = stockTotal.ToString();
                pointMovido.Label = stockMovido.ToString();

                // Ajustar el formato de las etiquetas
                pointTotal.LabelAngle = -45;
                pointMovido.LabelAngle = -45;
            }

            // Ajustar el zoom si hay muchos productos
            if (cantidadProductos > 10)
            {
                chartStockSinMover.ChartAreas[0].AxisX.ScaleView.Zoom(0, 10);
                chartStockSinMover.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
                chartStockSinMover.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            }
            else
            {
                chartStockSinMover.ChartAreas[0].AxisX.ScaleView.Zoom(0, cantidadProductos);
            }
        }
    }
}
