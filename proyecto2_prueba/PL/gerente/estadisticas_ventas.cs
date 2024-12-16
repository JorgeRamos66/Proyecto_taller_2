﻿using BLL;
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
    public partial class estadisticas_ventas : Form
    {
        private readonly EstadisticasVentasBLL _estadisticasBLL;

        public estadisticas_ventas()
        {
            InitializeComponent();
            _estadisticasBLL = new EstadisticasVentasBLL();
            ConfigurarGraficos();
            ConfigurarFechas();
            CargarEstadisticas();
        }

        private void ConfigurarGraficos()
        {
            // Configurar gráfico de vendedores
            chartVendedoresMasRecaudaron.Series[0].Name = "Recaudación";
            chartVendedoresMasRecaudaron.Series[0].ChartType = SeriesChartType.Column;
            chartVendedoresMasRecaudaron.Titles.Add("Vendedores con Mayor Recaudación");

            // Configurar gráfico de días
            chartDiasMasVendidos.Series[0].Name = "Ventas";
            chartDiasMasVendidos.Series[0].ChartType = SeriesChartType.Line;
            chartDiasMasVendidos.Titles.Add("Ventas por Día de la Semana");
        }

        private void ConfigurarFechas()
        {
            // Configurar fecha fin como la fecha actual
            dateTimePickerFinV.Value = DateTime.Now;
            dateTimePickerFinV.MaxDate = DateTime.Now;

            // Configurar fecha inicio como 30 días antes
            dateTimePickerInicioV.Value = DateTime.Now.AddDays(-30);
            dateTimePickerInicioV.MaxDate = DateTime.Now;

            // Agregar eventos para validación
            dateTimePickerInicioV.CloseUp += ValidarFechaInicio;
            dateTimePickerFinV.CloseUp += ValidarFechaFin;

            // Mantener el evento para actualizar los gráficos
            dateTimePickerInicioV.ValueChanged += (s, e) => CargarEstadisticas();
            dateTimePickerFinV.ValueChanged += (s, e) => CargarEstadisticas();
        }
        private void ValidarFechaInicio(object sender, EventArgs e)
        {
            // Si la fecha inicio es mayor que la fecha fin, la ajustamos
            if (dateTimePickerInicioV.Value > dateTimePickerFinV.Value)
            {
                dateTimePickerInicioV.Value = dateTimePickerFinV.Value;
            }
        }

        private void ValidarFechaFin(object sender, EventArgs e)
        {
            // Si la fecha fin es mayor que hoy, la ajustamos a hoy
            if (dateTimePickerFinV.Value > DateTime.Now)
            {
                dateTimePickerFinV.Value = DateTime.Now;
            }

            // Si la fecha fin es menor que la fecha inicio, ajustamos la fecha inicio
            if (dateTimePickerFinV.Value < dateTimePickerInicioV.Value)
            {
                dateTimePickerInicioV.Value = dateTimePickerFinV.Value;
            }
        }


        private void CargarEstadisticas()
        {
            try
            {
                CargarGraficoVendedores();
                CargarGraficoDias();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar estadísticas: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGraficoVendedores()
        {
            var dtVendedores = _estadisticasBLL.ObtenerVendedoresTopRecaudacion(
                dateTimePickerInicioV.Value,
                dateTimePickerFinV.Value
            );

            chartVendedoresMasRecaudaron.Series[0].Points.Clear();

            foreach (DataRow row in dtVendedores.Rows)
            {
                string vendedor = row["Vendedor"].ToString();
                double totalRecaudado = Convert.ToDouble(row["TotalRecaudado"]);

                var point = chartVendedoresMasRecaudaron.Series[0].Points.Add(totalRecaudado);
                point.AxisLabel = vendedor;
                point.Label = $"${totalRecaudado:N0}";
            }
        }

        private void CargarGraficoDias()
        {
            var dtDias = _estadisticasBLL.ObtenerVentasPorDiaSemana(
                dateTimePickerInicioV.Value,
                dateTimePickerFinV.Value
            );

            chartDiasMasVendidos.Series[0].Points.Clear();

            foreach (DataRow row in dtDias.Rows)
            {
                string dia = row["DiaSemana"].ToString();
                int cantidadVentas = Convert.ToInt32(row["CantidadVentas"]);

                var point = chartDiasMasVendidos.Series[0].Points.Add(cantidadVentas);
                point.AxisLabel = dia;
                point.Label = cantidadVentas.ToString();
            }
        }
    }
}