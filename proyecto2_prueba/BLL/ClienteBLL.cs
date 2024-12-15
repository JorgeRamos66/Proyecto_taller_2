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

        public ClienteBLL()
        {
            _clienteDAL = new ClienteDAL();
        }

        public Cliente ObtenerClientePorId(int id)
        {
            try
            {
                return _clienteDAL.ObtenerClientePorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener cliente: {ex.Message}");
            }
        }
        public Cliente ObtenerClientePorDni(int dni)
        {
            try
            {
                return _clienteDAL.ObtenerClientePorDni(dni);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener cliente por DNI: {ex.Message}");
            }
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
    }
}