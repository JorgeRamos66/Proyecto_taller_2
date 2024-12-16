using BLL;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace proyecto2_prueba.PL.gerente
{
    public partial class estadisticas_productos : Form
    {
        private EstadisticasBLL _estadisticasBLL;

        public estadisticas_productos()
        {
            InitializeComponent();
            _estadisticasBLL = new EstadisticasBLL();
            ConfigurarGraficos();
            ConfigurarFechas();
            CargarEstadisticas();
        }

        private void ConfigurarGraficos()
        {
            // Configurar gráfico de productos
            chartProductosMasVendidos.Titles.Clear();
            var titleProductos = chartProductosMasVendidos.Titles.Add("Productos Más Vendidos");
            titleProductos.Font = new Font("Microsoft Tai Le", 12, FontStyle.Bold);

            chartProductosMasVendidos.Series[0].Name = "Productos";
            chartProductosMasVendidos.Series[0].ChartType = SeriesChartType.Column;

            // Configurar gráfico de categorías
            chartCategoriasMasVendidas.Titles.Clear();
            var titleCategorias = chartCategoriasMasVendidas.Titles.Add("Categorías Más Vendidas");
            titleCategorias.Font = new Font("Microsoft Tai Le", 12, FontStyle.Bold);

            chartCategoriasMasVendidas.Series[0].Name = "Categorías";
            chartCategoriasMasVendidas.Series[0].ChartType = SeriesChartType.Pie;
        }

        private void ConfigurarFechas()
        {
            // Configurar fecha fin como la fecha actual
            dateTimePickerFin.Value = DateTime.Now;
            dateTimePickerFin.MaxDate = DateTime.Now;

            // Configurar fecha inicio como 30 días antes
            dateTimePickerInicio.Value = DateTime.Now.AddDays(-30);
            dateTimePickerInicio.MaxDate = DateTime.Now;

            // Agregar eventos para validación
            dateTimePickerInicio.CloseUp += ValidarFechaInicio;
            dateTimePickerFin.CloseUp += ValidarFechaFin;

            // Mantener el evento para actualizar los gráficos
            dateTimePickerInicio.ValueChanged += (s, e) => CargarEstadisticas();
            dateTimePickerFin.ValueChanged += (s, e) => CargarEstadisticas();
        }

        private void ValidarFechaInicio(object sender, EventArgs e)
        {
            // Si la fecha inicio es mayor que la fecha fin, la ajustamos
            if (dateTimePickerInicio.Value > dateTimePickerFin.Value)
            {
                dateTimePickerInicio.Value = dateTimePickerFin.Value;
            }
        }

        private void ValidarFechaFin(object sender, EventArgs e)
        {
            // Si la fecha fin es mayor que hoy, la ajustamos a hoy
            if (dateTimePickerFin.Value > DateTime.Now)
            {
                dateTimePickerFin.Value = DateTime.Now;
            }

            // Si la fecha fin es menor que la fecha inicio, ajustamos la fecha inicio
            if (dateTimePickerFin.Value < dateTimePickerInicio.Value)
            {
                dateTimePickerInicio.Value = dateTimePickerFin.Value;
            }
        }

        private void CargarEstadisticas()
        {
            try
            {
                CargarGraficoProductos();
                CargarGraficoCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las estadísticas: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGraficoProductos()
        {
            var dtProductos = _estadisticasBLL.ObtenerProductosMasVendidos(
                dateTimePickerInicio.Value,
                dateTimePickerFin.Value
            );

            chartProductosMasVendidos.Series[0].Points.Clear();

            foreach (DataRow row in dtProductos.Rows)
            {
                string producto = row["Producto"].ToString();
                int cantidad = Convert.ToInt32(row["CantidadVendida"]);

                var point = chartProductosMasVendidos.Series[0].Points.Add(cantidad);
                point.AxisLabel = producto;
                point.Label = cantidad.ToString();
            }
        }

        private void CargarGraficoCategorias()
        {
            var dtCategorias = _estadisticasBLL.ObtenerCategoriasMasVendidas(
                dateTimePickerInicio.Value,
                dateTimePickerFin.Value
            );

            chartCategoriasMasVendidas.Series[0].Points.Clear();

            foreach (DataRow row in dtCategorias.Rows)
            {
                string categoria = row["Categoria"].ToString();
                int cantidad = Convert.ToInt32(row["CantidadVendida"]);

                var point = chartCategoriasMasVendidas.Series[0].Points.Add(cantidad);
                point.LegendText = categoria;
                point.Label = $"{categoria}\n{cantidad}";
            }
        }
    }
}