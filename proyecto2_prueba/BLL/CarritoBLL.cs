using DAL;
using ML;
using System.Collections.Generic;
using System;
using System.Linq;

namespace BLL
{
    public class CarritoBLL
    {
        private readonly CarritoDAL _carritoDAL;
        private readonly Carrito _carrito;

        public CarritoBLL()
        {
            _carritoDAL = new CarritoDAL();
            _carrito = new Carrito();
        }

        public List<CarritoItem> BuscarProductos(string filtro)
        {
            return _carritoDAL.BuscarProductos(filtro);
        }

        public void AgregarProducto(int idProducto, int cantidad)
        {
            var producto = _carritoDAL.ObtenerProductoPorId(idProducto);
            if (producto == null)
                throw new Exception("Producto no encontrado");

            if (producto.StockDisponible < cantidad)
                throw new Exception("Stock insuficiente");

            var itemExistente = _carrito.Items.FirstOrDefault(i => i.IdProducto == idProducto);
            if (itemExistente != null)
            {
                if (itemExistente.CantidadProducto + cantidad > producto.StockDisponible)
                    throw new Exception("Stock insuficiente");

                itemExistente.CantidadProducto += cantidad;
            }
            else
            {
                producto.CantidadProducto = cantidad;
                _carrito.Items.Add(producto);
            }
        }

        public void ActualizarCantidad(int idProducto, int nuevaCantidad)
        {
            var item = _carrito.Items.FirstOrDefault(i => i.IdProducto == idProducto);
            if (item == null)
                throw new Exception("Producto no encontrado en el carrito");

            if (nuevaCantidad <= 0)
            {
                _carrito.Items.Remove(item);
                return;
            }

            if (nuevaCantidad > item.StockDisponible)
                throw new Exception("Stock insuficiente");

            item.CantidadProducto = nuevaCantidad;
        }

        public void QuitarProducto(int idProducto)
        {
            var item = _carrito.Items.FirstOrDefault(i => i.IdProducto == idProducto);
            if (item != null)
                _carrito.Items.Remove(item);
        }

        public void LimpiarCarrito()
        {
            _carrito.Items.Clear();
        }

        public List<CarritoItem> ObtenerItems()
        {
            return _carrito.Items;
        }

        public double ObtenerTotal()
        {
            return _carrito.Total;
        }
    }
}