using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using ML;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;
using BLL;
using System.Globalization;

namespace proyecto2_prueba.PL.vendedor
{
    public partial class ImpresionFactura : Form
    {
        private readonly VentaBLL _ventaBLL;
        private readonly Cliente _cliente;
        private readonly List<CarritoItem> _items;
        private readonly int _idVenta;

        public ImpresionFactura(Cliente cliente, int idVenta)
        {
            InitializeComponent();
            _ventaBLL = new VentaBLL();
            _cliente = cliente;
            _idVenta = idVenta;
            // Obtener los items de la venta desde la base de datos
            _items = _ventaBLL.ObtenerDetallesVenta(idVenta);
            CargarDatosFactura();
        }

        private void CargarDatosFactura()
        {
            // Cargar datos del cliente
            lblNombreCliente.Text = $"{_cliente.Nombre} {_cliente.Apellido}";
            lblDniCliente.Text = _cliente.Dni.ToString();
            lblDireccionCliente.Text = _cliente.Direccion;
            lblLocalidadCliente.Text = _cliente.Localidad;
            lblProvinciaCliente.Text = _cliente.Provincia;
            lblEmailCliente.Text = _cliente.Email;

            // Cargar datos de la venta
            lblFechaVenta.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            lblNumeroVenta.Text = _idVenta.ToString();

            // Configurar DataGridView
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.Columns.Clear();

            // Definir las columnas
            var colProducto = new DataGridViewTextBoxColumn
            {
                Name = "Producto",
                HeaderText = "Producto",
                DataPropertyName = "NombreProducto",
                Width = 200
            };

            var colCantidad = new DataGridViewTextBoxColumn
            {
                Name = "Cantidad",
                HeaderText = "Cantidad",
                DataPropertyName = "CantidadProducto",
                Width = 80
            };

            var colPrecio = new DataGridViewTextBoxColumn
            {
                Name = "Precio",
                HeaderText = "Precio Unit.",
                DataPropertyName = "PrecioProducto",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C" }
            };

            var colSubtotal = new DataGridViewTextBoxColumn
            {
                Name = "Subtotal",
                HeaderText = "Subtotal",
                DataPropertyName = "Subtotal",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C" }
            };

            // Agregar las columnas al DataGridView
            dgvProductos.Columns.AddRange(new DataGridViewColumn[]
            {
                colProducto,
                colCantidad,
                colPrecio,
                colSubtotal
            });

            // Limpiar filas existentes
            dgvProductos.Rows.Clear();

            // Agregar los items al DataGridView
            if (_items != null && _items.Any())
            {
                foreach (var item in _items)
                {
                    dgvProductos.Rows.Add(
                        item.NombreProducto,
                        item.CantidadProducto,
                        item.PrecioProducto,
                        item.CantidadProducto * item.PrecioProducto
                    );
                }
            }

            // Calcular y mostrar total
            double total = _items?.Sum(i => i.CantidadProducto * i.PrecioProducto) ?? 0;
            lblTotal.Text = total.ToString("C", CultureInfo.CreateSpecificCulture("es-AR"));

            // Refrescar el DataGridView
            dgvProductos.Refresh();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            GenerarPDF();
        }

        private void GenerarPDF()
        {

            try
            {
                // Obtener la ruta base del proyecto
                string rutaProyecto = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName;

                // Combinar con la ruta de Facturas
                string directorioFacturas = Path.Combine(rutaProyecto, "proyecto2_prueba", "Resources", "Facturas");

                // Crear el directorio si no existe
                if (!Directory.Exists(directorioFacturas))
                {
                    Directory.CreateDirectory(directorioFacturas);
                }

                // Crear la ruta completa del archivo
                string rutaArchivo = Path.Combine(directorioFacturas, $"Factura_{_idVenta}.pdf");

                using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create))
                using (Document documento = new Document(PageSize.A4, 25, 25, 30, 30))
                using (PdfWriter writer = PdfWriter.GetInstance(documento, fs))
                {
                    documento.Open();

                    // Título
                    Font fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                    documento.Add(new Paragraph("Factura de Venta", fontTitulo));
                    documento.Add(new Paragraph($"N° de Venta: {_idVenta}"));
                    documento.Add(new Paragraph($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}"));
                    documento.Add(new Paragraph("\n"));

                    // Datos del cliente
                    Font fontSubtitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                    documento.Add(new Paragraph("Datos del Cliente:", fontSubtitulo));
                    documento.Add(new Paragraph($"Nombre: {_cliente.Nombre} {_cliente.Apellido}"));
                    documento.Add(new Paragraph($"DNI: {_cliente.Dni}"));
                    documento.Add(new Paragraph($"Dirección: {_cliente.Direccion}"));
                    documento.Add(new Paragraph($"Localidad: {_cliente.Localidad}, {_cliente.Provincia}"));
                    documento.Add(new Paragraph($"Email: {_cliente.Email}"));
                    documento.Add(new Paragraph("\n"));

                    // Tabla de productos
                    PdfPTable tabla = new PdfPTable(4);
                    tabla.WidthPercentage = 100;
                    tabla.SetWidths(new float[] { 40f, 20f, 20f, 20f });

                    // Encabezados
                    tabla.AddCell(new PdfPCell(new Phrase("Producto", fontSubtitulo)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    tabla.AddCell(new PdfPCell(new Phrase("Cantidad", fontSubtitulo)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    tabla.AddCell(new PdfPCell(new Phrase("Precio Unit.", fontSubtitulo)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    tabla.AddCell(new PdfPCell(new Phrase("Subtotal", fontSubtitulo)) { BackgroundColor = BaseColor.LIGHT_GRAY });

                    // Productos
                    foreach (var item in _items)
                    {
                        tabla.AddCell(item.NombreProducto);
                        tabla.AddCell(item.CantidadProducto.ToString());
                        tabla.AddCell(item.PrecioProducto.ToString("C", CultureInfo.CreateSpecificCulture("es-AR")));
                        tabla.AddCell(item.Subtotal.ToString("C", CultureInfo.CreateSpecificCulture("es-AR")));
                    }

                    documento.Add(tabla);

                    // Total
                    double total = _items.Sum(i => i.Subtotal);
                    documento.Add(new Paragraph($"\nTotal: {total:C}", fontTitulo));

                    documento.Close();
                }

                MessageBox.Show($"Factura generada: {rutaArchivo}");
                Process.Start(new ProcessStartInfo(rutaArchivo) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar la factura: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}