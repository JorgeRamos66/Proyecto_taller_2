using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration; // Necesario para ConfigurationManager
using ML;


namespace proyecto2_prueba.Presentaciones.vendedor
{
    public partial class ventas : Form
    {
        public ventas()
        {
            InitializeComponent();
            // Registrar los eventos ValueChanged para actualizar los datos
            dateTimePicker1.ValueChanged += DateTimePicker_ValueChanged;
            dateTimePicker2.ValueChanged += DateTimePicker_ValueChanged;
        }

        // Método para cargar el historial de ventas
        private void CargarHistorialVentas(int idUsuario, DateTime fechaInicio, DateTime fechaFin)
        {
            // Cadena de conexión a la base de datos
            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;


            // Consulta SQL
            string query = @"
            SELECT v.id_venta, v.fecha, v.precio_total, p.nombre_persona + ' ' + p.apellido_persona AS cliente
            FROM VENTA_CABECERA v
            JOIN CLIENTE c ON v.id_cliente = c.id_cliente
            JOIN PERSONA p ON c.id_persona = p.id_persona
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

                // Asignar los datos al DataGridView
                datagrid_carrito.DataSource = dataTable;

                // Rellenar la columna CFactura con el texto "Ver"
                foreach (DataGridViewRow row in datagrid_carrito.Rows)
                {
                    row.Cells["CFactura"].Value = "Ver";
                }
            }
        }
        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            // Aquí debes obtener el ID del usuario logueado
            int idUsuario = UsuarioSesion.IdUsuario;

            // Obtener las fechas desde los controles DateTimePickers
            DateTime fechaInicio = dateTimePicker1.Value;
            DateTime fechaFin = dateTimePicker2.Value;

            // Cargar el historial de ventas con las nuevas fechas
            CargarHistorialVentas(idUsuario, fechaInicio, fechaFin);
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
