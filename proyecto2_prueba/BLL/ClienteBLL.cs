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

        public void ValidarCliente(Cliente cliente)
        {
            var errores = new List<string>();

            // Validaciones de datos nulos o cliente
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente), "El cliente no puede ser nulo");

            // Validaciones de formato y longitud
            if (string.IsNullOrWhiteSpace(cliente.Nombre))
                errores.Add("El nombre es obligatorio");
            else if (cliente.Nombre.Length < 2 || cliente.Nombre.Length > 50)
                errores.Add("El nombre debe tener entre 2 y 50 caracteres");

            if (string.IsNullOrWhiteSpace(cliente.Apellido))
                errores.Add("El apellido es obligatorio");
            else if (cliente.Apellido.Length < 2 || cliente.Apellido.Length > 50)
                errores.Add("El apellido debe tener entre 2 y 50 caracteres");

            // Validación de DNI
            if (cliente.Dni <= 0)
                errores.Add("El DNI debe ser un número válido");
            else if (cliente.Dni.ToString().Length < 7 || cliente.Dni.ToString().Length > 8)
                errores.Add("El DNI debe tener entre 7 y 8 dígitos");

            // Validación de Email
            if (string.IsNullOrWhiteSpace(cliente.Email))
                errores.Add("El email es obligatorio");
            else if (!IsValidEmail(cliente.Email))
                errores.Add("El formato del email no es válido");
            else if (cliente.Email.Length > 100)
                errores.Add("El email no puede superar los 100 caracteres");

            // Validaciones de dirección
            if (string.IsNullOrWhiteSpace(cliente.Direccion))
                errores.Add("La dirección es obligatoria");
            else if (cliente.Direccion.Length > 100)
                errores.Add("La dirección no puede superar los 100 caracteres");

            if (string.IsNullOrWhiteSpace(cliente.Localidad))
                errores.Add("La localidad es obligatoria");
            else if (cliente.Localidad.Length > 50)
                errores.Add("La localidad no puede superar los 50 caracteres");

            if (string.IsNullOrWhiteSpace(cliente.Provincia))
                errores.Add("La provincia es obligatoria");
            else if (cliente.Provincia.Length > 50)
                errores.Add("La provincia no puede superar los 50 caracteres");

            // Validación de fecha de nacimiento
            if (cliente.FechaNacimiento > DateTime.Today)
                errores.Add("La fecha de nacimiento no puede ser futura");
            else if (DateTime.Today.Year - cliente.FechaNacimiento.Year < 15)
                errores.Add("El cliente debe ser mayor de 15 años");
            else if (cliente.FechaNacimiento.Year < 1900)
                errores.Add("La fecha de nacimiento no es válida");

            // Validar duplicados
            try
            {
                var clienteExistente = _clienteDAL.ObtenerClientePorDni(cliente.Dni);
                if (clienteExistente != null && clienteExistente.Id != cliente.Id)
                    errores.Add("Ya existe un cliente registrado con ese DNI");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar duplicados: " + ex.Message);
            }

            // Lanzar excepción si hay errores
            if (errores.Any())
                throw new ValidationException(string.Join("\n", errores));
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
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
            ValidarCliente(cliente);

            if (cliente.Id == 0)
                _clienteDAL.InsertarCliente(cliente);
            else
                _clienteDAL.ActualizarCliente(cliente);
        }
    }
}