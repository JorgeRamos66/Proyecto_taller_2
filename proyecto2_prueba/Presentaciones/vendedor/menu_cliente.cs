using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static proyecto2_prueba.Presentaciones.vendedor.carrito;

namespace proyecto2_prueba.Presentaciones.vendedor
{
    public partial class menu_cliente : Form
    {
        private SqlConnection connection;
        private List<Producto> listaCarrito; // Lista de productos del carrito

        public menu_cliente(List<Producto> listaProductos)
        {
            InitializeComponent();
            listaCarrito = listaProductos; // Guardamos la lista de productos recibida
            connection = new SqlConnection("Data Source=servidor;Initial Catalog=baseDatos;Integrated Security=True;");
        }

        // Clase para representar datos de cliente
        public class Cliente
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public int Dni { get; set; }
            public string Email { get; set; }
            public string Direccion { get; set; }
            public string Localidad { get; set; }
            public string Provincia { get; set; }
            public DateTime FechaNacimiento { get; set; }
        }


        private void menu_cliente_Load(object sender, EventArgs e)
        {
            try
            {
                // Mostrar todos los clientes al cargar el formulario
                MostrarClientes(string.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }


        private void MostrarClientes(string filtro)
        {
            var clientes = ObtenerClientesFiltrados(filtro);
            dgvClientes.Rows.Clear();

            foreach (var cliente in clientes)
            {
                dgvClientes.Rows.Add(
                    cliente.Nombre,
                    cliente.Apellido,
                    cliente.Dni,
                    "Seleccionar" // Texto para la columna de acción
                );
            }
        }

        // Método para obtener los clientes filtrados (sin cambios)
        private List<Cliente> ObtenerClientesFiltrados(string filtro)
        {
            List<Cliente> clientes = new List<Cliente>();
            string query = @"
            SELECT 
                C.id_cliente,
                P.nombre_persona,
                P.apellido_persona,
                P.dni,
                P.email_persona,
                P.direccion_persona,
                L.nombre_localidad,
                Pr.nombre_provincia,
                P.fecha_nacimiento
            FROM CLIENTE C
            INNER JOIN PERSONA P ON C.id_persona = P.id_persona
            INNER JOIN LOCALIDAD L ON P.id_localidad = L.id_localidad
            INNER JOIN PROVINCIA Pr ON L.id_provincia = Pr.id_provincia
            WHERE 
                P.nombre_persona LIKE @filtro OR
                P.apellido_persona LIKE @filtro OR
                CAST(P.dni AS NVARCHAR) LIKE @filtro";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@filtro", $"%{filtro}%");
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Cliente cliente = new Cliente
                        {
                            Id = (int)reader["id_cliente"],
                            Nombre = reader["nombre_persona"].ToString(),
                            Apellido = reader["apellido_persona"].ToString(),
                            Dni = (int)reader["dni"],
                            Email = reader["email_persona"].ToString(),
                            Direccion = reader["direccion_persona"].ToString(),
                            Localidad = reader["nombre_localidad"].ToString(),
                            Provincia = reader["nombre_provincia"].ToString(),
                            FechaNacimiento = (DateTime)reader["fecha_nacimiento"]
                        };

                        clientes.Add(cliente);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener clientes: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return clientes;
        }


        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvClientes.Columns[e.ColumnIndex].Name == "cSeleccion")
            {
                string nombre = dgvClientes.Rows[e.RowIndex].Cells["cNombre"].Value.ToString();
                MessageBox.Show($"Cliente seleccionado: {nombre}");
            }
        }

        private void BSalir_Click(object sender, EventArgs e)
        {

        }

        private void BConfirmar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un cliente.");
                return;
            }

            var filaSeleccionada = dgvClientes.SelectedRows[0];

            // Obtener datos del cliente seleccionado
            var clienteSeleccionado = new
            {
                Id = (int)filaSeleccionada.Cells["cIdCliente"].Value,
                Nombre = filaSeleccionada.Cells["cNombre"].Value.ToString(),
                Apellido = filaSeleccionada.Cells["cApellido"].Value.ToString(),
                Dni = (int)filaSeleccionada.Cells["cDni"].Value
            };

            // Iniciar transacción para insertar la venta en la base de datos
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    // Insertar venta en la tabla de ventas (cabecera)
                    int ventaId = InsertarVentaCabecera(clienteSeleccionado, transaction);

                    // Insertar productos en la tabla de ventas detalles
                    foreach (var producto in listaCarrito)
                    {
                        InsertarVentaDetalle(ventaId, producto, transaction);
                    }

                    // Confirmar transacción
                    transaction.Commit();

                    MessageBox.Show("Venta registrada exitosamente.");
                    this.DialogResult = DialogResult.OK; // Cerrar formulario
                    this.Close();
                }
                catch (Exception ex)
                {
                    // Si ocurre un error, hacer rollback
                    transaction.Rollback();
                    MessageBox.Show($"Error al registrar la venta: {ex.Message}");
                }
            }
        }

        // Método para insertar la cabecera de la venta
        private int InsertarVentaCabecera(dynamic clienteSeleccionado, SqlTransaction transaction)
        {
            string query = @"
            INSERT INTO VENTA (id_cliente, fecha_venta) 
            OUTPUT INSERTED.id_venta 
            VALUES (@id_cliente, @fecha_venta)";

            using (SqlCommand cmd = new SqlCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@id_cliente", clienteSeleccionado.Id);
                cmd.Parameters.AddWithValue("@fecha_venta", DateTime.Now); // Fecha actual de la venta

                return (int)cmd.ExecuteScalar(); // Retorna el ID de la venta insertada
            }
        }

        // Método para insertar los productos en la tabla de detalles de venta
        private void InsertarVentaDetalle(int idVenta, Producto producto, SqlTransaction transaction)
        {
            string query = @"
            INSERT INTO VENTA_DETALLE (id_venta, id_producto, cantidad, precio_unitario) 
            VALUES (@id_venta, @id_producto, @cantidad, @precio_unitario)";

            using (SqlCommand cmd = new SqlCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@id_venta", idVenta);
                cmd.Parameters.AddWithValue("@id_producto", producto.Id);
                cmd.Parameters.AddWithValue("@cantidad", 1); // Suponemos una cantidad de 1 por cada producto
                cmd.Parameters.AddWithValue("@precio_unitario", producto.Precio);

                cmd.ExecuteNonQuery();
            }
        }

        
        private void TxtBuscar_Enter(object sender, EventArgs e)
        {
            // Limpiar el texto si contiene la leyenda inicial
            if (txtBuscar.Text == "Ingrese Nombre, Apellido o DNI")
            {
                txtBuscar.Text = string.Empty;
                txtBuscar.ForeColor = Color.Black; // Cambiar el color del texto para que sea normal
            }
        }
        private void TxtBuscar_Leave(object sender, EventArgs e)
        {
            // Si el campo está vacío, restaurar la leyenda
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.Text = "Ingrese Nombre, Apellido o DNI";
                txtBuscar.ForeColor = Color.Gray; // Cambiar el color del texto a gris
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Si el texto no es la leyenda inicial, filtrar los clientes
            if (txtBuscar.Text != "Ingrese Nombre, Apellido o DNI")
            {
                string busqueda = txtBuscar.Text;
                MostrarClientes(busqueda);
            }
            else
            {
                MostrarClientes(string.Empty); // Mostrar todos los clientes si es la leyenda inicial
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }
    }
}
