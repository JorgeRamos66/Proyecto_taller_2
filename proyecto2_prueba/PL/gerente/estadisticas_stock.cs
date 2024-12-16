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
            ConfigurarControles();
            ConfigurarGrafico();
            ConfigurarFechas();
            CargarDatosIniciales();
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
                ConfigurarDataGridView();
                dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al configurar controles: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosIniciales()
        {
            CargarDataGridView();
            ActualizarGraficoStock(); // Llamada separada para el gráfico
        }

        private void CargarDataGridView()
        {
            try
            {
                var dt = _stockBLL.ObtenerProductosBajoStock();

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron datos de stock.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dataGridView1.DataSource = dt;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["CStock"].Value != null)
                    {
                        int stock = Convert.ToInt32(row.Cells["CStock"].Value);
                        int redIntensity = Math.Max(255 - (stock * 10), 0);
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255 - redIntensity, 255 - redIntensity);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el DataGridView: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrafico()
        {
            chartStockSinMover.Series.Clear();

            // Agregar y configurar series
            var seriesStockTotal = chartStockSinMover.Series.Add("Stock Total");
            var seriesStockMovido = chartStockSinMover.Series.Add("Stock Movido");

            seriesStockTotal.ChartType = SeriesChartType.Column;
            seriesStockMovido.ChartType = SeriesChartType.Column;

            seriesStockTotal.Color = Color.SteelBlue;
            seriesStockMovido.Color = Color.Crimson;

            // Configurar área del gráfico
            chartStockSinMover.ChartAreas[0].AxisX.Interval = 1;
            chartStockSinMover.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chartStockSinMover.ChartAreas[0].AxisY.LabelStyle.Format = "N0";

            // Agregar título
            chartStockSinMover.Titles.Add("Stock de Productos");
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

            // Reemplazar los eventos lambda con manejadores de eventos más explícitos
            dateTimePickerInicioS.ValueChanged += DateTimePickerInicioS_ValueChanged;
            dateTimePickerFinS.ValueChanged += DateTimePickerFinS_ValueChanged;
        }

        private void DateTimePickerInicioS_ValueChanged(object sender, EventArgs e)
        {
            ActualizarGraficoStock();
        }

        private void DateTimePickerFinS_ValueChanged(object sender, EventArgs e)
        {
            ActualizarGraficoStock();
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

        private void ActualizarGraficoStock()
        {
            try
            {
                var dt = _stockBLL.ObtenerStockSinMover(
                    dateTimePickerInicioS.Value,
                    dateTimePickerFinS.Value
                );

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron datos para el período seleccionado.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                chartStockSinMover.Series["Stock Total"].Points.Clear();
                chartStockSinMover.Series["Stock Movido"].Points.Clear();

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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el gráfico: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
