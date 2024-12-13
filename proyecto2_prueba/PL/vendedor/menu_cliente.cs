using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static proyecto2_prueba.Presentaciones.vendedor.carrito;
using static proyecto2_prueba.Presentaciones.vendedor.menu_cliente;
using ML;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;


namespace proyecto2_prueba.Presentaciones.vendedor
{
    public partial class menu_cliente : Form
    {
        private SqlConnection connection;
        private List<carrito.Producto> listaCarrito; // Lista de productos del carrito

        public menu_cliente(List<carrito.Producto> listaProductos)
        {
            InitializeComponent();
            listaCarrito = listaProductos; // Guardamos la lista de productos recibida
            textBoxIdAuxiliar.Text = "0";
            // Obtener la cadena de conexión desde el archivo app.config
            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Error: No se encontró la cadena de conexión en el archivo de configuración.");
                return;
            }

            connection = new SqlConnection(connectionString);

            this.Load += menu_cliente_Load;
            this.txtBuscar.TextChanged += TxtBuscar_TextChanged;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close(); // Cerrar el formulario cuando se presiona Esc
                return true;  // Indicar que la tecla ha sido manejada
            }
            return base.ProcessCmdKey(ref msg, keyData);
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
                    cliente.Id,
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

            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Error: No se encontró la cadena de conexión en el archivo de configuración.");
                return clientes;
            }

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

        private void CargarDatosCliente(int idCliente)
        {
            // Definir la consulta para obtener los datos del cliente desde la base de datos
            string query = @"
                SELECT 
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
                WHERE C.id_cliente = @idCliente";  // Usar el ID del cliente para filtrar

            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Error: No se encontró la cadena de conexión en el archivo de configuración.");
                return;
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Obtener los datos del cliente desde la consulta
                        string nombre = reader["nombre_persona"].ToString();
                        string apellido = reader["apellido_persona"].ToString();
                        int dni = (int)reader["dni"];
                        string domicilio = reader["direccion_persona"].ToString();
                        string localidad = reader["nombre_localidad"].ToString();
                        string provincia = reader["nombre_provincia"].ToString();
                        string email = reader["email_persona"].ToString();
                        DateTime fechaNacimiento = (DateTime)reader["fecha_nacimiento"];

                        // Asignar los valores a los controles del formulario
                        txtNombre.Text = nombre;
                        txtApellido.Text = apellido;
                        txtDni.Text = dni.ToString();
                        txtDomicilio.Text = domicilio;
                        txtLocalidad.Text = localidad;
                        txtProvincia.Text = provincia;
                        txtEmail.Text = email;
                        dtpFechaNacimiento.Value = fechaNacimiento;
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos del cliente: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvClientes.Columns[e.ColumnIndex].Name == "cSeleccion")
            {
                var filaSeleccionada = dgvClientes.Rows[e.RowIndex];

                // Obtener el ID del cliente seleccionado
                int idCliente = (int)filaSeleccionada.Cells["cIdCliente"].Value;

                // Cargar los datos del cliente en el formulario
                CargarDatosCliente(idCliente);

                // Establecer el valor del campo auxiliar con el ID del cliente
                textBoxIdAuxiliar.Text = idCliente.ToString();
            }
        }

        private int ObtenerIdLocalidad(string nombreLocalidad, string nombreProvincia)
        {
            int idProvincia = ObtenerIdProvincia(nombreProvincia); // Obtener el ID de la provincia
            int idLocalidad = 0;

            // Verificar si la localidad ya existe
            string queryLocalidad = "SELECT id_localidad FROM LOCALIDAD WHERE nombre_localidad = @NombreLocalidad AND id_provincia = @IdProvincia";

            using (SqlCommand cmd = new SqlCommand(queryLocalidad, connection))
            {
                cmd.Parameters.AddWithValue("@NombreLocalidad", nombreLocalidad);
                cmd.Parameters.AddWithValue("@IdProvincia", idProvincia);
                connection.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    idLocalidad = Convert.ToInt32(result); // Localidad encontrada
                }
                else
                {
                    // Si no existe, insertar la nueva localidad
                    string insertLocalidad = "INSERT INTO LOCALIDAD (nombre_localidad, id_provincia) VALUES (@NombreLocalidad, @IdProvincia); SELECT SCOPE_IDENTITY();";
                    using (SqlCommand insertCmd = new SqlCommand(insertLocalidad, connection))
                    {
                        insertCmd.Parameters.AddWithValue("@NombreLocalidad", nombreLocalidad);
                        insertCmd.Parameters.AddWithValue("@IdProvincia", idProvincia);
                        idLocalidad = Convert.ToInt32(insertCmd.ExecuteScalar()); // Obtener el ID de la nueva localidad
                    }
                }
                connection.Close();
            }
            return idLocalidad;
        }

        private int ObtenerIdProvincia(string nombreProvincia)
        {
            int idProvincia = 0;

            // Verificar si la provincia ya existe
            string queryProvincia = "SELECT id_provincia FROM PROVINCIA WHERE nombre_provincia = @NombreProvincia";

            using (SqlCommand cmd = new SqlCommand(queryProvincia, connection))
            {
                cmd.Parameters.AddWithValue("@NombreProvincia", nombreProvincia);
                connection.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    idProvincia = Convert.ToInt32(result); // Provincia encontrada
                }
                else
                {
                    // Si no existe, insertar la nueva provincia
                    string insertProvincia = "INSERT INTO PROVINCIA (nombre_provincia) VALUES (@NombreProvincia); SELECT SCOPE_IDENTITY();";
                    using (SqlCommand insertCmd = new SqlCommand(insertProvincia, connection))
                    {
                        insertCmd.Parameters.AddWithValue("@NombreProvincia", nombreProvincia);
                        idProvincia = Convert.ToInt32(insertCmd.ExecuteScalar()); // Obtener el ID de la nueva provincia
                    }
                }
                connection.Close();
            }
            return idProvincia;
        }

        private int ObtenerIdPersona(int idCliente)
        {
            // Verificar que el id_cliente sea válido
            if (idCliente <= 0)
            {
                throw new ArgumentException("El id_cliente debe ser mayor que cero.");
            }

            // Consulta SQL para obtener el id_persona basado en el id_cliente
            string query = "SELECT id_persona FROM CLIENTE WHERE id_cliente = @id_cliente";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                // Asignar el parámetro para la consulta
                cmd.Parameters.AddWithValue("@id_cliente", idCliente);

                // Ejecutar la consulta y obtener el resultado
                connection.Open();
                object result = cmd.ExecuteScalar();
                connection.Close();

                // Si no se encuentra el cliente, retornar 0 o manejar el error
                if (result == null)
                {
                    MessageBox.Show($"No se encontró el cliente con id: {idCliente}.");
                    return 0; // Puedes retornar 0 o el valor que decidas para indicar que no se encontró el cliente
                }

                // Si se encuentra el cliente, retornar el id_persona
                return (int)result;
            }
        }

        private void BSalir_Click(object sender, EventArgs e)
        {

        }

        private void BConfirmar_Click(object sender, EventArgs e)
        {
            // Verificar si todos los campos del formulario están completos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDni.Text) ||
                string.IsNullOrWhiteSpace(txtDomicilio.Text) ||
                string.IsNullOrWhiteSpace(txtLocalidad.Text) ||
                string.IsNullOrWhiteSpace(txtProvincia.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                dtpFechaNacimiento.Value == null)
            {
                MessageBox.Show("Por favor, completa todos los campos del formulario.");
                return; // Evitar continuar si algún campo está vacío
            }

            // Verificar si el DNI ingresado es un número válido
            if (!int.TryParse(txtDni.Text, out int dni))
            {
                MessageBox.Show("El DNI ingresado no es válido.");
                return;
            }

            // Verificar si el correo electrónico tiene el formato correcto (básico)
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("El correo electrónico ingresado no es válido.");
                return;
            }

            // Verificar si el campo auxiliar 'textBoxIdAuxiliar' es 0 (cliente nuevo)
            int idCliente = int.Parse(textBoxIdAuxiliar.Text); // Si es 0, significa que el cliente es nuevo
            int idPersona;

            if (idCliente == 0)
            {
                // Insertar una nueva persona y luego un nuevo cliente
                idPersona = InsertarPersona(); // Método que insertará la persona y devolverá el id_persona
                idCliente = InsertarNuevoCliente(idPersona); // Método que insertará el cliente y devolverá el id_cliente
            }
            else
            {
                // Si el cliente ya existe, actualizar los datos de la persona y del cliente
                idPersona = ObtenerIdPersona(idCliente); // Obtener el id_persona relacionado con el id_cliente
                ActualizarPersona(idCliente); // Actualizar los datos de la persona
                ActualizarCliente(idCliente); // Actualizar los datos del cliente
            }

            // Iniciar transacción para insertar la venta en la base de datos
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    // Calcular el precio total de la venta
                    double precioTotal = 0;
                    foreach (var producto in listaCarrito)
                    {
                        precioTotal += producto.Precio * producto.Cantidad; // Suponiendo que 'Cantidad' está definida en el objeto 'Producto'
                    }

                    // Definir el método de pago y el ID del usuario (esto debería venir de algún lugar, por ejemplo, del formulario o contexto)
                    int idMetodoPago = 1;  // Este método debe devolver el ID del método de pago
                    int idUsuario = UsuarioSesion.IdUsuario;

                    // Insertar venta en la tabla de ventas (cabecera) - Aquí se pasa la transacción
                    int ventaId = InsertarVentaCabecera(idCliente, idPersona, transaction, precioTotal, idMetodoPago, idUsuario);

                    // Insertar productos en la tabla de ventas detalles
                    foreach (var producto in listaCarrito)
                    {
                        // Insertar detalles de la venta
                        InsertarVentaDetalle(ventaId, producto, transaction);

                        // Actualizar stock del producto
                        ActualizarStockProducto(producto.Id, producto.Cantidad, transaction);
                    }

                    // Confirmar transacción
                    transaction.Commit();

                    
                    // 2. Generar el PDF de la factura
                    GenerarFacturaPDF(ventaId,listaCarrito);

                    MessageBox.Show("Venta registrada y factura generada exitosamente.");
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
        // Método para actualizar el stock del producto
        private void ActualizarStockProducto(int idProducto, int cantidadVendida, SqlTransaction transaction)
        {
            try
            {
                string query = @"UPDATE Producto
                         SET stock = stock - @cantidadVendida
                         WHERE id_producto = @idProducto";

                using (SqlCommand cmd = new SqlCommand(query, connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@idProducto", idProducto);
                    cmd.Parameters.AddWithValue("@cantidadVendida", cantidadVendida);

                    cmd.ExecuteNonQuery(); // Ejecuta la consulta
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el stock del producto", ex);
            }
        }
        public void GenerarFacturaPDF(int idVenta, List<carrito.Producto> listaCarrito)
        {
            string rutaArchivo = $"Factura_{idVenta}.pdf"; // Nombre del archivo

            try
            {
                // Crear un archivo PDF
                using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create))
                using (Document documento = new Document(PageSize.A4, 25, 25, 30, 30))
                using (PdfWriter writer = PdfWriter.GetInstance(documento, fs))
                {
                    documento.Open();

                    // Agregar encabezado
                    iTextSharp.text.Font fontTitulo = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 16);
                    documento.Add(new Paragraph("Factura de Venta", fontTitulo));
                    documento.Add(new Paragraph($"ID de la Venta: {idVenta}"));
                    documento.Add(new Paragraph($"Fecha: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}"));
                    documento.Add(new Paragraph("\n"));

                    // Crear tabla con encabezado
                    PdfPTable tabla = new PdfPTable(3); // 3 columnas: Producto, Cantidad, Subtotal
                    tabla.WidthPercentage = 100;
                    tabla.SetWidths(new float[] { 50f, 25f, 25f }); // Ajustar proporciones de las columnas
                    tabla.AddCell(new PdfPCell(new Phrase("Producto", fontTitulo)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    tabla.AddCell(new PdfPCell(new Phrase("Cantidad", fontTitulo)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    tabla.AddCell(new PdfPCell(new Phrase("Subtotal", fontTitulo)) { BackgroundColor = BaseColor.LIGHT_GRAY });

                    // Agregar filas de la tabla
                    foreach (var producto in listaCarrito)
                    {
                        tabla.AddCell(producto.Nombre); // Nombre del producto
                        tabla.AddCell(producto.Cantidad.ToString()); // Cantidad
                        tabla.AddCell($"${(producto.Cantidad * producto.Precio):0.00}"); // Subtotal
                    }

                    // Total de la venta
                    double total = listaCarrito.Sum(p => p.Cantidad * p.Precio);
                    documento.Add(tabla);
                    documento.Add(new Paragraph($"\nTotal: ${total:0.00}", fontTitulo));

                    documento.Close();
                }

                MessageBox.Show($"Factura generada: {rutaArchivo}");
                // Abrir el PDF automáticamente en el navegador
                AbrirPDFEnNavegador(rutaArchivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar la factura: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AbrirPDFEnNavegador(string rutaArchivo)
        {
            try
            {
                // Usar Process.Start para abrir el archivo PDF en el navegador predeterminado
                // Asegúrate de que la ruta sea válida
                if (File.Exists(rutaArchivo))
                {
                    // En algunos sistemas, podrías necesitar pasar la ruta completa
                    string filePath = Path.GetFullPath(rutaArchivo);

                    // Abre el PDF en el navegador predeterminado (generalmente el navegador web predeterminado)
                    Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                }
                else
                {
                    MessageBox.Show("No se pudo encontrar el archivo PDF.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private int InsertarPersona()
        {
            // Asumiendo que los nombres de localidad y provincia se toman de los controles correspondientes:
            string nombreLocalidad = txtLocalidad.Text;
            string nombreProvincia = txtProvincia.Text;

            // Obtener el ID de la localidad, si no existe, se insertará
            int idLocalidad = ObtenerIdLocalidad(nombreLocalidad, nombreProvincia);

            string query = @"
                INSERT INTO PERSONA (nombre_persona, apellido_persona, dni, email_persona, direccion_persona, id_localidad, fecha_nacimiento) 
                OUTPUT INSERTED.id_persona 
                VALUES (@nombre_persona, @apellido_persona, @dni, @email_persona, @direccion_persona, @id_localidad, @fecha_nacimiento)";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                // Asignar los parámetros con los datos del formulario
                cmd.Parameters.AddWithValue("@nombre_persona", txtNombre.Text);
                cmd.Parameters.AddWithValue("@apellido_persona", txtApellido.Text);
                cmd.Parameters.AddWithValue("@dni", txtDni.Text);
                cmd.Parameters.AddWithValue("@email_persona", txtEmail.Text);
                cmd.Parameters.AddWithValue("@direccion_persona", txtDomicilio.Text);
                cmd.Parameters.AddWithValue("@id_localidad", idLocalidad); // Usar el ID de localidad obtenido
                cmd.Parameters.AddWithValue("@fecha_nacimiento", dtpFechaNacimiento.Value);

                connection.Open();
                int idPersona = (int)cmd.ExecuteScalar(); // Obtener el ID de la persona recién insertada
                connection.Close();

                return idPersona;
            }
        }

        private int InsertarNuevoCliente(int idPersona)
        {
            // Luego, insertar en la tabla CLIENTE
            string query = @"
                INSERT INTO CLIENTE (id_persona, id_nivel, observaciones, monto_total) 
                OUTPUT INSERTED.id_cliente 
                VALUES (@id_persona, @id_nivel, @observaciones, @monto_total)";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                // Asignar parámetros con los datos del formulario
                cmd.Parameters.AddWithValue("@id_persona", idPersona);
                cmd.Parameters.AddWithValue("@id_nivel", 1); // Asegúrate de ajustar el valor de id_nivel según sea necesario
                cmd.Parameters.AddWithValue("@observaciones", ""); // Ajustar según sea necesario
                cmd.Parameters.AddWithValue("@monto_total", 0);

                connection.Open();
                int idCliente = (int)cmd.ExecuteScalar(); // Obtener el ID del cliente recién insertado
                connection.Close();

                // Devolver el ID del cliente recién insertado
                return idCliente;
            }
        }

        private void ActualizarPersona(int idCliente)
        {
            // Obtener el id_persona desde la tabla CLIENTE
            int idPersona = ObtenerIdPersona(idCliente);

            // Obtener la localidad y la provincia del formulario
            string nombreLocalidad = txtLocalidad.Text;
            string nombreProvincia = txtProvincia.Text;

            // Obtener el ID de la localidad, si no existe, se insertará
            int idLocalidad = ObtenerIdLocalidad(nombreLocalidad, nombreProvincia);

            string query = @"
                UPDATE PERSONA
                SET nombre_persona = @nombre_persona,
                    apellido_persona = @apellido_persona,
                    dni = @dni,
                    email_persona = @email_persona,
                    direccion_persona = @direccion_persona,
                    id_localidad = @id_localidad,
                    fecha_nacimiento = @fecha_nacimiento
                WHERE id_persona = @id_persona";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                // Asignar los parámetros con los datos del formulario
                cmd.Parameters.AddWithValue("@id_persona", idPersona);
                cmd.Parameters.AddWithValue("@nombre_persona", txtNombre.Text);
                cmd.Parameters.AddWithValue("@apellido_persona", txtApellido.Text);
                cmd.Parameters.AddWithValue("@dni", txtDni.Text);
                cmd.Parameters.AddWithValue("@email_persona", txtEmail.Text);
                cmd.Parameters.AddWithValue("@direccion_persona", txtDomicilio.Text);
                cmd.Parameters.AddWithValue("@id_localidad", idLocalidad); // Usar el ID de localidad obtenido
                cmd.Parameters.AddWithValue("@fecha_nacimiento", dtpFechaNacimiento.Value);

                connection.Open();
                cmd.ExecuteNonQuery(); // Ejecutar el UPDATE
                connection.Close();
            }
        }

        private void ActualizarCliente(int idCliente)
        {
            // Primero, actualizar los datos en la tabla PERSONA
            ActualizarPersona(idCliente);

            // Calcular el monto total a partir de la lista de productos vendidos
            double montoCompraActual = 0;
            foreach (var producto in listaCarrito)
            {
                // Asegúrate de que cada producto tenga propiedades 'Precio' y 'Cantidad'
                montoCompraActual += producto.Precio * producto.Cantidad; // Calcular monto de la compra actual
            }

            // Obtener el monto_total actual desde la base de datos para el cliente
            double montoTotalExistente = 0;
            string queryObtenerMonto = "SELECT monto_total FROM CLIENTE WHERE id_cliente = @id_cliente";
            using (SqlCommand cmd = new SqlCommand(queryObtenerMonto, connection))
            {
                cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                connection.Open();
                var result = cmd.ExecuteScalar(); // Obtener el monto_total actual
                if (result != DBNull.Value)
                {
                    montoTotalExistente = Convert.ToDouble(result); // Convertir el valor a tipo double
                }
                connection.Close();
            }

            // Calcular el nuevo monto total acumulado
            double nuevoMontoTotal = montoTotalExistente + montoCompraActual;

            // Luego, actualizar los datos del cliente en la tabla CLIENTE
            string queryActualizar = @"
                UPDATE CLIENTE
                SET observaciones = @observaciones, monto_total = @monto_total
                WHERE id_cliente = @id_cliente";

            using (SqlCommand cmd = new SqlCommand(queryActualizar, connection))
            {
                // Asignar parámetros con los datos del formulario
                cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                cmd.Parameters.AddWithValue("@observaciones", ""); // Ajustar según sea necesario
                cmd.Parameters.AddWithValue("@monto_total", nuevoMontoTotal);

                connection.Open();
                cmd.ExecuteNonQuery(); // Ejecutar el UPDATE
                connection.Close();
            }
        }

        // Método para validar formato de correo electrónico
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email; // Verifica que el correo tenga un formato válido
            }
            catch
            {
                return false; // Si ocurre una excepción, el correo no es válido
            }
        }

        // Método para insertar la cabecera de la venta
        private int InsertarVentaCabecera(int id_Cliente, int id_Persona, SqlTransaction transaction, double precioTotal, int idMetodoPago, int idUsuario)
        {
            string query = @"
                INSERT INTO VENTA_CABECERA (id_cliente, id_persona, fecha, precio_total, id_metodo, id_usuario) 
                OUTPUT INSERTED.id_venta 
                VALUES (@id_cliente, @id_persona, @fecha_venta, @precio_total, @id_metodo, @id_usuario)";

            using (SqlCommand cmd = new SqlCommand(query, connection, transaction))
            {
                // Agregar los parámetros necesarios
                cmd.Parameters.AddWithValue("@id_cliente", id_Cliente);
                cmd.Parameters.AddWithValue("@id_persona", id_Persona);
                cmd.Parameters.AddWithValue("@fecha_venta", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@precio_total", precioTotal); // El precio total calculado de la compra
                cmd.Parameters.AddWithValue("@id_metodo", idMetodoPago); // Suponemos que el método de pago se pasa como parámetro
                cmd.Parameters.AddWithValue("@id_usuario", idUsuario); // ID del usuario que realiza la venta

                // Ejecutar el comando y retornar el ID de la venta insertada
                return (int)cmd.ExecuteScalar();
            }
        }



        // Método para insertar los productos en la tabla de detalles de venta
        private void InsertarVentaDetalle(int idVenta, carrito.Producto producto, SqlTransaction transaction)
        {
            // Calcular el precio subtotal (cantidad * precio unitario)
            double precioSubtotal = producto.Precio * producto.Cantidad;

            string query = @"
                INSERT INTO VENTA_DETALLE (id_venta, id_producto, cantidad, precio_subtotal) 
                VALUES (@id_venta, @id_producto, @cantidad, @precio_subtotal)";

            using (SqlCommand cmd = new SqlCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@id_venta", idVenta);
                cmd.Parameters.AddWithValue("@id_producto", producto.Id);
                cmd.Parameters.AddWithValue("@cantidad", producto.Cantidad); // Usamos la cantidad del producto
                cmd.Parameters.AddWithValue("@precio_subtotal", precioSubtotal); // El precio calculado

                cmd.ExecuteNonQuery(); // Ejecutar la inserción
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
            txtBuscar.Text = string.Empty;
            MostrarClientes(string.Empty);
        }


    }
}
