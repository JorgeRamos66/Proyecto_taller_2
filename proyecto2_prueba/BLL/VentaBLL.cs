﻿using System;
using System.IO;
using System.Linq;
using DAL;
using iTextSharp.text.pdf;
using iTextSharp.text;
using ML;
using System.Collections.Generic;

namespace BLL
{
    public class VentaBLL
    {
        private readonly VentaDAL _ventaDAL;
        private readonly CarritoBLL _carritoBLL;

        public VentaBLL()
        {
            _ventaDAL = new VentaDAL();
            _carritoBLL = new CarritoBLL();
        }

        public VentaBLL(CarritoBLL carritoBLL = null)
        {
            _ventaDAL = new VentaDAL();
            _carritoBLL = carritoBLL;
        }

        public int ProcesarVentaCompleta(Cliente cliente, int idMetodoPago, string detallesPago)
        {
            try
            {
                if (_carritoBLL == null)
                    throw new Exception("No se ha inicializado el carrito");

                var itemsCarrito = _carritoBLL.ObtenerItems();

                var venta = new Venta
                {
                    FechaVenta = DateTime.Now,
                    PrecioTotal = _carritoBLL.ObtenerTotal(),
                    IdCliente = cliente.Id,
                    IdMetodo = idMetodoPago,
                    IdUsuario = UsuarioSesion.IdUsuario,
                    IdPersona = cliente.IdPersona,
                    VentaEstado = 1,
                    DetallesPago = detallesPago,
                    Cliente = cliente,
                    Detalles = itemsCarrito.Select(item => new DetalleVenta
                    {
                        IdProducto = item.IdProducto,
                        Cantidad = item.CantidadProducto,
                        PrecioSubtotal = item.PrecioProducto * item.CantidadProducto 
                    }).ToList()
                };

                // Validaciones
                if (venta.IdCliente <= 0)
                    throw new Exception("Cliente no válido");

                if (venta.IdPersona <= 0)
                    throw new Exception("ID de persona no válido");

                if (venta.IdUsuario <= 0)
                    throw new Exception("Usuario no válido");

                if (!venta.Detalles.Any())
                    throw new Exception("El carrito está vacío");

                int idVenta = _ventaDAL.InsertarVenta(venta);
                _carritoBLL.LimpiarCarrito();
                return idVenta;
            }
            catch
            {
                throw;
            }
        }

        public List<CarritoItem> ObtenerDetallesVenta(int idVenta)
        {
            try
            {
                var venta = _ventaDAL.ObtenerVentaPorId(idVenta);
                if (venta == null)
                    throw new Exception("Venta no encontrada");

                var items = new List<CarritoItem>();
                foreach (var detalle in venta.Detalles)
                {
                    var producto = _ventaDAL.ObtenerProducto(detalle.IdProducto);
                    items.Add(new CarritoItem
                    {
                        IdProducto = detalle.IdProducto,
                        NombreProducto = producto.NombreProducto,
                        CantidadProducto = detalle.Cantidad,
                        PrecioProducto = detalle.PrecioSubtotal / detalle.Cantidad
                    });
                }
                return items;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener detalles de la venta: {ex.Message}");
            }
        }

        public void GenerarPDF(int idVenta, string rutaArchivo)
        {
            try
            {
                var venta = _ventaDAL.ObtenerVentaPorId(idVenta);
                if (venta == null)
                    throw new Exception("Venta no encontrada");

                using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create))
                using (Document documento = new Document(PageSize.A4, 25, 25, 30, 30))
                using (PdfWriter writer = PdfWriter.GetInstance(documento, fs))
                {
                    documento.Open();

                    // Título
                    Font fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                    documento.Add(new Paragraph("Factura de Venta", fontTitulo));
                    documento.Add(new Paragraph($"N° de Venta: {venta.Id}"));
                    documento.Add(new Paragraph($"Fecha: {venta.FechaVenta:dd/MM/yyyy HH:mm}"));
                    documento.Add(new Paragraph("\n"));

                    // Datos del cliente
                    Font fontSubtitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                    documento.Add(new Paragraph("Datos del Cliente:", fontSubtitulo));
                    documento.Add(new Paragraph($"Nombre: {venta.Cliente.Nombre} {venta.Cliente.Apellido}"));
                    documento.Add(new Paragraph($"DNI: {venta.Cliente.Dni}"));
                    documento.Add(new Paragraph($"Dirección: {venta.Cliente.Direccion}"));
                    documento.Add(new Paragraph($"Localidad: {venta.Cliente.Localidad}, {venta.Cliente.Provincia}"));
                    documento.Add(new Paragraph($"Email: {venta.Cliente.Email}"));
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
                    foreach (var detalle in venta.Detalles)
                    {
                        var producto = _ventaDAL.ObtenerProducto(detalle.IdProducto);
                        tabla.AddCell(producto.NombreProducto);
                        tabla.AddCell(detalle.Cantidad.ToString());
                        tabla.AddCell(producto.PrecioProducto.ToString("C"));
                        tabla.AddCell((detalle.PrecioSubtotal.ToString("C")));
                    }

                    documento.Add(tabla);

                    // Detalles del pago
                    documento.Add(new Paragraph("\nDetalles del Pago:", fontSubtitulo));
                    documento.Add(new Paragraph(venta.DetallesPago));

                    // Total
                    documento.Add(new Paragraph($"\nTotal: {venta.PrecioTotal:C}", fontTitulo));

                    documento.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al generar el PDF: {ex.Message}");
            }
        }
    }
}