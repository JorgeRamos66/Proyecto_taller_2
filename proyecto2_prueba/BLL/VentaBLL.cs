using System;
using System.Linq;
using DAL;
using ML;

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

        public int ProcesarVenta(int idCliente, int idMetodoPago)
        {
            try
            {
                var itemsCarrito = _carritoBLL.ObtenerItems();
                
                var venta = new Venta
                {
                    FechaVenta = DateTime.Now,
                    PrecioTotal = _carritoBLL.ObtenerTotal(),
                    IdCliente = idCliente,
                    IdMetodoPago = idMetodoPago,
                    IdUsuario = UsuarioSesion.IdUsuario,
                    Detalles = itemsCarrito.Select(item => new DetalleVenta
                    {
                        IdProducto = item.IdProducto,
                        Cantidad = item.Cantidad,
                        Precio = item.Precio
                    }).ToList()
                };

                // Validaciones
                if (venta.IdCliente <= 0)
                    throw new Exception("Cliente no válido");

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
    }
}