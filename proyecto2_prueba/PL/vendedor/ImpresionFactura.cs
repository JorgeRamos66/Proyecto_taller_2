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

namespace proyecto2_prueba.PL.vendedor
{
    public partial class ImpresionFactura : Form
    {
        private readonly VentaBLL _ventaBLL;
        private readonly Cliente _cliente;
        private readonly List<CarritoItem> _items;
        private readonly int _idVenta;

        public ImpresionFactura(Cliente cliente, List<CarritoItem> items, int idVenta)
        {
            InitializeComponent();
            _ventaBLL = new VentaBLL();
            _cliente = cliente;
            _items = items;
            _idVenta = idVenta;
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
            dgvProductos.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "Nombre", HeaderText = "Producto", Width = 200 },
                new DataGridViewTextBoxColumn { Name = "Cantidad", HeaderText = "Cantidad", Width = 80 },
                new DataGridViewTextBoxColumn { Name = "Precio", HeaderText = "Precio Unit.", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "Subtotal", HeaderText = "Subtotal", Width = 100 }
            );

            // Cargar productos
            foreach (var item in _items)
            {
                dgvProductos.Rows.Add(
                    item.NombreProducto,
                    item.CantidadProducto,
                    item.PrecioProducto.ToString("C"),
                    item.Subtotal.ToString("C")
                );
            }

            // Calcular y mostrar total
            double total = _items.Sum(i => i.Subtotal);
            lblTotal.Text = total.ToString("C");
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            GenerarPDF();
        }

        private void GenerarPDF()
        {
            string rutaArchivo = $"Factura_{_idVenta}.pdf";

            try
            {
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
                        tabla.AddCell(item.PrecioProducto.ToString("C"));
                        tabla.AddCell(item.Subtotal.ToString("C"));
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