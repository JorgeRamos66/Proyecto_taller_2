using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace proyecto2_prueba.Presentaciones.vendedor
{
    public partial class carrito : Form
    {
        private SqlConnection connection;
        private List<Producto> listaCarrito = new List<Producto>(); // Lista para almacenar productos en el carrito

        public carrito()
        {
            InitializeComponent();
            
            // Obtener la cadena de conexión desde el archivo app.config
            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Error: No se encontró la cadena de conexión en el archivo de configuración.");
                return;
            }

            connection = new SqlConnection(connectionString); // Usar la cadena de conexión válida
            textBoxBusqueda.TextChanged += textBoxBusqueda_TextChanged;
            datagrid_carrito.CellClick += datagrid_carrito_CellClick;
            datagrid_carrito.CellValidating += datagrid_carrito_CellValidating;
        }

        private void textBoxBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxBusqueda.Text))
            {
                // Si el cuadro de búsqueda está vacío, hacer visible la columna
                datagrid_carrito.Columns["operacionQuitar"].Visible = true;
                datagrid_carrito.Columns["operacionAgregar"].Visible = false;
            }
            else
            {
                // Si hay texto en el cuadro de búsqueda, ocultar la columna
                datagrid_carrito.Columns["operacionQuitar"].Visible = false;
                datagrid_carrito.Columns["operacionAgregar"].Visible = true;
            }
            string busqueda = textBoxBusqueda.Text;
            MostrarProductos(busqueda);
        }

        private void MostrarProductos(string busqueda)
        {
            var productos = ObtenerProductosFiltrados(busqueda);
            datagrid_carrito.Rows.Clear();

            foreach (var producto in productos)
            {
                var row = datagrid_carrito.Rows.Add();
                datagrid_carrito.Rows[row].Cells["CNombre_producto"].Value = producto.Nombre;
                datagrid_carrito.Rows[row].Cells["CCategoria_producto"].Value = producto.Categoria;
                datagrid_carrito.Rows[row].Cells["CPrecio"].Value = producto.Precio;
                datagrid_carrito.Rows[row].Cells["CStock_producto"].Value = 1; // Establecer valor predeterminado 1
                datagrid_carrito.Rows[row].Cells["CIdProducto"].Value = producto.Id;  // Asignamos el ID del producto

                datagrid_carrito.Rows[row].Cells["CStock_producto"].ReadOnly = false; // Esto permite que la celda sea editable

                // Asignar el texto "Agregar" a la celda de la columna operacionAgregar
                datagrid_carrito.Rows[row].Cells["operacionAgregar"].Value = "Agregar";  // Aquí asignamos el texto
            }
        }

        private void datagrid_carrito_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Verificar si estamos en la columna "CStock_producto"
            if (datagrid_carrito.Columns[e.ColumnIndex].Name == "CStock_producto")
            {
                // Intentar convertir el valor ingresado a un número
                if (!int.TryParse(e.FormattedValue.ToString(), out int newValue) || newValue < 0)
                {
                    // Si no es un número válido o es negativo, mostrar un mensaje de error
                    MessageBox.Show("Por favor ingresa un valor válido para el stock (número entero no negativo).");
                    e.Cancel = true; // Evitar que el valor no válido se guarde en la celda
                }
            }
        }
        private List<Producto> ObtenerProductosFiltrados(string busqueda)
        {
            List<Producto> productos = new List<Producto>();

            // Modificar la consulta para que también busque por la categoría
            string query = @"
                SELECT * 
                FROM PRODUCTO 
                WHERE (nombre_producto LIKE @busqueda OR id_categoria IN (SELECT id_categoria FROM CATEGORIA WHERE nombre_categoria LIKE @busqueda)) 
                AND baja_producto = 1";

            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Error: No se encontró la cadena de conexión en el archivo de configuración.");
                return productos;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@busqueda", "%" + busqueda + "%"); // Buscar en nombre del producto y en categoría

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Producto prod = new Producto
                        {
                            Id = (int)reader["id_producto"],
                            Nombre = reader["nombre_producto"].ToString(),
                            Categoria = ObtenerNombreCategoria((int)reader["id_categoria"]),
                            Precio = (double)reader["precio_producto"],
                            Stock = (int)reader["stock_producto"]
                        };

                        // Depuración: Verificar si Categoria es nula o vacía
                        if (string.IsNullOrEmpty(prod.Categoria))
                        {
                            MessageBox.Show("Categoria nula o vacía para el producto: " + prod.Nombre);
                        }

                        if (!listaCarrito.Any(c => c.Id == prod.Id))
                            productos.Add(prod);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener productos: " + ex.Message);
            }
            return productos;
        }



        private string ObtenerNombreCategoria(int idCategoria)
        {
            string nombreCategoria = "Desconocido"; // Valor predeterminado
            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Error: No se encontró la cadena de conexión en el archivo de configuración.");
                return nombreCategoria;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT nombre_categoria FROM CATEGORIA WHERE id_categoria = @idCategoria";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idCategoria", idCategoria);

                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        nombreCategoria = result.ToString();
                    }
                    else
                    {
                        // Depuración: Verificar si no se encontró categoría
                        MessageBox.Show("No se encontró categoría para el ID: " + idCategoria);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener nombre de categoría: " + ex.Message + "\n" + ex.StackTrace);
            }
            return nombreCategoria;
        }



        private void datagrid_carrito_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = datagrid_carrito.Rows[e.RowIndex];
                int idProducto = (int)row.Cells["CIdProducto"].Value;

                // Verificar si la celda modificada es la de "Agregar" o "Quitar"
                if (datagrid_carrito.Columns[e.ColumnIndex].Name == "operacionAgregar")
                {
                    Producto producto = ObtenerProductoPorId(idProducto);

                    // Obtener el valor de la celda de stock en el DataGridView
                    int stockDesdeCelda = Convert.ToInt32(row.Cells["CStock_producto"].Value);

                    if (producto != null)
                    {
                        // Asignar el valor del stock ingresado en la celda al StockReal del producto
                        producto.StockReal = stockDesdeCelda;

                        // Verificar si el producto ya está en el carrito
                        if (!listaCarrito.Any(p => p.Id == idProducto))
                        {
                            listaCarrito.Add(producto);

                            // Limpiar el cuadro de búsqueda después de agregar el producto
                            textBoxBusqueda.Text = string.Empty;

                            // Actualizar el carrito en el DataGridView
                            ActualizarCarrito();
                        }
                    }
                }
                else if (datagrid_carrito.Columns[e.ColumnIndex].Name == "operacionQuitar")
                {
                    listaCarrito.RemoveAll(p => p.Id == idProducto);
                    ActualizarCarrito();
                }
            }
        }



        public Producto ObtenerProductoPorId(int idProducto)
        {
            Producto producto = null;
            try
            {
                connection.Open();
                string query = "SELECT * FROM PRODUCTO WHERE id_producto = @idProducto";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idProducto", idProducto);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    producto = new Producto
                    {
                        Id = reader.GetInt32(0), // Asumiendo que este campo nunca será null
                        Nombre = reader.IsDBNull(1) ? null : reader.GetString(1), // Si es null, asigna null
                        Precio = reader.IsDBNull(2) ? 0.0 : reader.GetDouble(2), // Si es null, asigna 0.0
                        Descripcion = reader.IsDBNull(3) ? null : reader.GetString(3), // Si es null, asigna null
                        Stock = reader.IsDBNull(4) ? 0 : reader.GetInt32(4), // Si es null, asigna 0
                        BajaProducto = reader.IsDBNull(5) ? 0 : reader.GetInt32(5), // Si es null, asigna 0
                        IdCategoria = reader.IsDBNull(6) ? 0 : reader.GetInt32(6), // Si es null, asigna 0
                        RutaImagen = reader.IsDBNull(7) ? null : reader.GetString(7), // Si es null, asigna null
                    };
                    // Asignamos el nombre de la categoría usando el ID de la categoría
                    producto.Categoria = ObtenerNombreCategoria(producto.IdCategoria);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el producto: " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return producto;
        }


        private void ActualizarCarrito()
        {
            datagrid_carrito.Rows.Clear();
            foreach (var producto in listaCarrito)
            {
                // Verifica que la categoría no esté vacía
                if (string.IsNullOrEmpty(producto.Categoria))
                {
                    MessageBox.Show("Categoria es null o vacío para el producto: " + producto.Nombre);
                }

                var row = datagrid_carrito.Rows.Add();

                // Asignar valores a las celdas
                datagrid_carrito.Rows[row].Cells["CNombre_producto"].Value = producto.Nombre;
                datagrid_carrito.Rows[row].Cells["CCategoria_producto"].Value = producto.Categoria;
                datagrid_carrito.Rows[row].Cells["CPrecio"].Value = producto.Precio;
                datagrid_carrito.Rows[row].Cells["CStock_producto"].Value = producto.StockReal;  // Usa StockReal, no el valor original
                datagrid_carrito.Rows[row].Cells["CIdProducto"].Value = producto.Id;

                // Aquí asignamos "Quitar" a la celda de la columna operacionQuitar
                datagrid_carrito.Rows[row].Cells["operacionQuitar"].Value = "Quitar";
            }
        }

        public class Producto
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Categoria { get; set; }
            public double Precio { get; set; }
            public int Stock { get; set; }
            public string Descripcion { get; set; }
            public int BajaProducto { get; set; }
            public int IdCategoria { get; set; }
            public string RutaImagen { get; set; }
            public int? StockReal { get; set; }
        }

        private void BBorrar_Click(object sender, EventArgs e)
        {
            // Limpiar el cuadro de búsqueda
            textBoxBusqueda.Text = string.Empty;
            ActualizarCarrito();
        }

        private void carrito_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'proyecto_Taller_2DataSet.PRODUCTO' Puede moverla o quitarla según sea necesario.
            this.pRODUCTOTableAdapter.Fill(this.proyecto_Taller_2DataSet.PRODUCTO);

        }

        private void bConfirmarVenta_Click(object sender, EventArgs e)
        {

        }
    }
}

