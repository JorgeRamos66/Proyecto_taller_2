using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration; // Necesario para ConfigurationManager
using ML;
using BLL;
using System.Globalization;
using System.Diagnostics;
using System.IO;
using System.Drawing;


namespace proyecto2_prueba.Presentaciones.vendedor
{
    public partial class ventas : Form
    {
        private readonly HistorialVentaBLL _historialVentaBLL;

        public ventas()
        {
            InitializeComponent();
            _historialVentaBLL = new HistorialVentaBLL();
            ConfigurarDataGridView();
            ConfigurarFechas();

            // Usar ValueChanged para actualizar los datos
            dateTimePicker1.ValueChanged += DateTimePicker_ValueChanged;
            dateTimePicker2.ValueChanged += DateTimePicker_ValueChanged;

            // Agregar eventos para validar antes del cambio
            dateTimePicker1.CloseUp += ValidarFechaInicio;
            dateTimePicker2.CloseUp += ValidarFechaFin;
        }

        private void ConfigurarFechas()
        {
            // Configurar fecha fin como la fecha actual
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker2.MaxDate = DateTime.Now;

            // Configurar fecha inicio como 30 días antes
            dateTimePicker1.Value = DateTime.Now.AddDays(-30);
            dateTimePicker1.MaxDate = DateTime.Now;
        }

        private void ValidarFechaInicio(object sender, EventArgs e)
        {
            // Si la fecha inicio es mayor que la fecha fin, la ajustamos
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                dateTimePicker1.Value = dateTimePicker2.Value;
            }
        }

        private void ValidarFechaFin(object sender, EventArgs e)
        {
            // Si la fecha fin es mayor que hoy, la ajustamos a hoy
            if (dateTimePicker2.Value > DateTime.Now)
            {
                dateTimePicker2.Value = DateTime.Now;
            }

            // Si la fecha fin es menor que la fecha inicio, ajustamos la fecha inicio
            if (dateTimePicker2.Value < dateTimePicker1.Value)
            {
                dateTimePicker1.Value = dateTimePicker2.Value;
            }
        }

        private void ConfigurarDataGridView()
        {
            datagrid_historialVentas.AutoGenerateColumns = false;
            datagrid_historialVentas.Columns.Clear();

            datagrid_historialVentas.Columns.AddRange(new DataGridViewColumn[]
            {
            new DataGridViewTextBoxColumn
            {
                Name = "CIdVenta",
                DataPropertyName = "id_venta",
                HeaderText = "ID Venta",
                Visible = false
            },
            new DataGridViewTextBoxColumn
            {
                Name = "CFechaVenta",
                DataPropertyName = "fecha",
                HeaderText = "Fecha de la venta",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd/MM/yyyy HH:mm"
                }
            },
            new DataGridViewTextBoxColumn
            {
                Name = "CMontoTotal",
                DataPropertyName = "precio_total",
                HeaderText = "Monto Total",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "C",
                    FormatProvider = new CultureInfo("es-AR")
                }
            },
            new DataGridViewTextBoxColumn
            {
                Name = "CCliente",
                DataPropertyName = "nombre_cliente",
                HeaderText = "Nombre Cliente",
                Width = 200
            },
            new DataGridViewTextBoxColumn
            {
                Name = "CFactura",
                HeaderText = "Factura",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    ForeColor = Color.Red,
                    BackColor = Color.White,
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            },
            new DataGridViewTextBoxColumn
            {
                Name = "CEstado",
                DataPropertyName = "venta_estado",
                HeaderText = "Estado",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            }
        });

            datagrid_historialVentas.CellFormatting += Datagrid_historialVentas_CellFormatting;
            datagrid_historialVentas.CellClick += Datagrid_historialVentas_CellClick;
            datagrid_historialVentas.DataBindingComplete += Datagrid_historialVentas_DataBindingComplete;
        }

        private void Datagrid_historialVentas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == datagrid_historialVentas.Columns["CEstado"].Index)
                {
                    int estado = Convert.ToInt32(e.Value);
                    if (estado == 1)
                    {
                        e.Value = "Anular";
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.BackColor = Color.FromArgb(192, 0, 0); // Rojo oscuro
                    }
                    else
                    {
                        e.Value = "Activar";
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.BackColor = Color.FromArgb(0, 122, 204); // Azul
                    }
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.FormattingApplied = true;
                }
                if (e.ColumnIndex == datagrid_historialVentas.Columns["CFactura"].Index && e.RowIndex >= 0)
                {
                    e.Value = "Ver";
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.BackColor = Color.White;
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.FormattingApplied = true;
                }
                if (e.ColumnIndex == datagrid_historialVentas.Columns["CFechaVenta"].Index)
                {
                    if (e.Value is DateTime fecha)
                    {
                        e.Value = fecha.ToString("dd/MM/yyyy HH:mm");
                        e.FormattingApplied = true;
                    }
                }
                else if (e.ColumnIndex == datagrid_historialVentas.Columns["CMontoTotal"].Index)
                {
                    if (double.TryParse(e.Value.ToString(), out double monto))
                    {
                        e.Value = monto.ToString("C", new CultureInfo("es-AR"));
                        e.FormattingApplied = true;
                    }
                }
            }
            // Cambiar el fondo de la fila si la venta está anulada
            if (Convert.ToInt32(datagrid_historialVentas.Rows[e.RowIndex].Cells["CEstado"].Value) == 0)
            {
                datagrid_historialVentas.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.DarkGray;
            }
        }

        private void Datagrid_historialVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                int idVenta = Convert.ToInt32(datagrid_historialVentas.Rows[e.RowIndex].Cells["CIdVenta"].Value);

                if (e.ColumnIndex == datagrid_historialVentas.Columns["CFactura"].Index)
                {
                    MostrarFactura(idVenta);
                }
                else if (e.ColumnIndex == datagrid_historialVentas.Columns["CEstado"].Index)
                {
                    int estadoActual = Convert.ToInt32(datagrid_historialVentas.Rows[e.RowIndex].Cells["CEstado"].Value);
                    string accion = estadoActual == 1 ? "anular" : "activar";

                    if (MessageBox.Show($"¿Está seguro que desea {accion} esta venta?",
                        "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _historialVentaBLL.CambiarEstadoVenta(idVenta);
                        // Mostrar mensaje de éxito
                        string mensaje = estadoActual == 1 ?
                            "La factura ha sido anulada con éxito" :
                            "La factura ha sido activada con éxito";
                        MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Recargar los datos
                        int idUsuario = UsuarioSesion.IdUsuario;
                        DateTime fechaInicio = dateTimePicker1.Value.Date;
                        DateTime fechaFin = dateTimePicker2.Value.Date.AddDays(1).AddSeconds(-1);
                        CargarHistorialVentas(idUsuario, fechaInicio, fechaFin);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar la acción: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
                
        private void MostrarFactura(int idVenta)
        {
            try
            {
                // Obtener la ruta base del proyecto (subiendo tres niveles desde bin\Debug)
                string rutaProyecto = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName;

                // Combinar con proyecto2_prueba\Resources\Facturas
                string directorioFacturas = Path.Combine(rutaProyecto, "proyecto2_prueba", "Resources", "Facturas");

                // Asegurarse que exista el directorio Facturas
                if (!Directory.Exists(directorioFacturas))
                {
                    Directory.CreateDirectory(directorioFacturas);
                }

                string rutaFactura = Path.Combine(directorioFacturas, $"Factura_{idVenta}.pdf");


                if (File.Exists(rutaFactura))
                {
                    Process.Start(new ProcessStartInfo(rutaFactura) { UseShellExecute = true });
                }
                else
                {
                    _historialVentaBLL.GenerarFacturaPDF(idVenta, rutaFactura);

                    if (File.Exists(rutaFactura))
                    {
                        MessageBox.Show($"Factura generada y guardada en:\n{rutaFactura}",
                            "Factura Creada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Process.Start(new ProcessStartInfo(rutaFactura) { UseShellExecute = true });
                    }
                    else
                    {
                        throw new Exception($"No se pudo crear el archivo PDF en la ruta: {rutaFactura}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar la factura: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarHistorialVentas(int idUsuario, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                var dataTable = _historialVentaBLL.ObtenerHistorialVentas(idUsuario, fechaInicio, fechaFin);
                datagrid_historialVentas.DataSource = dataTable;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el historial: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Datagrid_historialVentas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in datagrid_historialVentas.Rows)
            {
                if (row.Cells["CFactura"].Value == null)
                {
                    row.Cells["CFactura"].Value = "Ver";
                }
                if (row.Cells["CEstado"].Value == null)
                {
                    row.Cells["CEstado"].Value = "Operacion";
                }
            }
        }

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            int idUsuario = UsuarioSesion.IdUsuario;
            DateTime fechaInicio = dateTimePicker1.Value.Date;
            DateTime fechaFin = dateTimePicker2.Value.Date.AddDays(1).AddSeconds(-1);
            CargarHistorialVentas(idUsuario, fechaInicio, fechaFin);
        }

        private void ventas_Load(object sender, EventArgs e)
        {
            int idUsuario = UsuarioSesion.IdUsuario;
            DateTime fechaInicio = dateTimePicker1.Value;
            DateTime fechaFin = dateTimePicker2.Value;
            CargarHistorialVentas(idUsuario, fechaInicio, fechaFin);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
