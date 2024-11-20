using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static proyecto2_prueba.inicio_sesion;

namespace proyecto2_prueba.Presentaciones.vendedor
{
    public partial class ventas : Form
    {
        public ventas()
        {
            InitializeComponent();
        }

        // Método para cargar el historial de ventas
        private void CargarHistorialVentas(int idUsuario, DateTime fechaInicio, DateTime fechaFin)
        {
            // Cadena de conexión a la base de datos
            string connectionString = "your_connection_string_here";

            // Consulta SQL
            string query = @"
                SELECT v.id_venta, v.fecha, v.precio_total, p.nombre_persona + ' ' + p.apellido_persona AS cliente, f.numero_factura
                FROM VENTA_CABECERA v
                JOIN CLIENTE c ON v.id_cliente = c.id_cliente
                JOIN PERSONA p ON c.id_persona = p.id_persona
                LEFT JOIN FACTURA f ON v.id_venta = f.id_venta -- Asegúrate de que la tabla FACTURA esté definida
                WHERE v.id_usuario = @id_usuario
                AND v.fecha BETWEEN @fechaInicio AND @fechaFin
                ORDER BY v.fecha DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Agregar los parámetros de fecha
                command.Parameters.AddWithValue("@id_usuario", idUsuario);
                command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                command.Parameters.AddWithValue("@fechaFin", fechaFin);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                datagrid_carrito.DataSource = dataTable;
            }
        }

        // Este evento se ejecutará al cargar el formulario de ventas
        private void ventas_Load(object sender, EventArgs e)
        {
            // Aquí debes obtener el ID del usuario logueado
            int idUsuario = UsuarioSesion.IdUsuario; // Asegúrate de que UsuarioSesion tenga el ID del usuario logueado.

            // Obtener las fechas desde los controles DateTimePickers
            DateTime fechaInicio = dateTimePicker1.Value;
            DateTime fechaFin = dateTimePicker2.Value;

            // Cargar el historial de ventas
            CargarHistorialVentas(idUsuario, fechaInicio, fechaFin);
        }
    }
}
