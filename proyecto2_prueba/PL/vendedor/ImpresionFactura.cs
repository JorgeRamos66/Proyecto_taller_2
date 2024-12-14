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

namespace proyecto2_prueba.PL.vendedor
{
    public partial class ImpresionFactura : Form
    {
        private readonly Cliente _cliente;
        private readonly List<Producto> _productos;
        private int _idVenta;

        public ImpresionFactura(Cliente cliente, List<Producto> productos, int idVenta)
        {
            InitializeComponent();
            _cliente = cliente;
            _productos = productos;
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
            foreach (var producto in _productos)
            {
                dgvProductos.Rows.Add(
                    producto.Nombre,
                    producto.Cantidad,
                    producto.Precio.ToString("C"),
                    (producto.Precio * producto.Cantidad).ToString("C")
                );
            }

            // Calcular y mostrar total
            double total = _productos.Sum(p => p.Precio * p.Cantidad);
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
                    foreach (var producto in _productos)
                    {
                        tabla.AddCell(producto.Nombre);
                        tabla.AddCell(producto.Cantidad.ToString());
                        tabla.AddCell(producto.Precio.ToString("C"));
                        tabla.AddCell((producto.Precio * producto.Cantidad).ToString("C"));
                    }

                    documento.Add(tabla);

                    // Total
                    double total = _productos.Sum(p => p.Precio * p.Cantidad);
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