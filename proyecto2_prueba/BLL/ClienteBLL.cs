using ML;
using DAL;
using System.Collections.Generic;
using System;
using System.Linq;

namespace BLL
{
    public class ClienteBLL
    {
        private readonly ClienteDAL _clienteDAL;
        private readonly VentaBLL _ventaBLL;

        public ClienteBLL()
        {
            _clienteDAL = new ClienteDAL();
            _ventaBLL = new VentaBLL();
        }

        public List<Cliente> ObtenerClientesFiltrados(string filtro)
        {
            return _clienteDAL.ObtenerClientesFiltrados(filtro);
        }

        public void GuardarCliente(Cliente cliente)
        {
            if (cliente.Id == 0)
            {
                _clienteDAL.InsertarCliente(cliente);
            }
            else
            {
                _clienteDAL.ActualizarCliente(cliente);
            }
        }

        public void RealizarVenta(Cliente cliente, List<Producto> productos)
        {
            var venta = new Venta
            {
                IdCliente = cliente.Id,
                IdMetodoPago = 1, // Predeterminado
                IdUsuario = UsuarioSesion.IdUsuario,
                PrecioTotal = productos.Sum(p => p.Precio * p.Cantidad),
                FechaVenta = DateTime.Now,
                Detalles = productos.Select(p => new DetalleVenta
                {
                    IdProducto = p.Id,
                    Cantidad = p.Cantidad,
                    Precio = p.Precio
                }).ToList()
            };

            _ventaBLL.ProcesarVenta(venta);
        }
    }
}