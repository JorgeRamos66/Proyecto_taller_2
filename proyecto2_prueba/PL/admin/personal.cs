using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto2_prueba.Presentaciones.admin
{
    public partial class personal : Form
    {
        public personal()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            CargarPersonal();
            datagrid_personal.CellFormatting += datagrid_personal_CellFormatting;

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

        public void CargarPersonal()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                    SELECT p.id_persona, p.nombre_persona, p.apellido_persona, p.dni, 
                            p.email_persona, p.direccion_persona, u.usuario, r.nombre_rol, 
                            u.baja_usuario 
                    FROM PERSONA p
                    INNER JOIN USUARIO u ON p.id_persona = u.id_persona
                    INNER JOIN ROL r ON u.id_rol = r.id_rol";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        // Asignar el DataTable como DataSource del DataGridView
                        datagrid_personal.DataSource = dataTable;

                        datagrid_personal.Columns["CId"].Visible = false; // Ocultar ID Personal

                    }
                }
                catch (Exception ex)
                {
                    // Muestra el mensaje de error completo en la consola o en un cuadro de mensaje
                    Console.WriteLine(ex.Message); // Para ver en la consola
                    MessageBox.Show($"Error al cargar el personal: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ConfigurarDataGridView()
        {
            // Limpiar columnas existentes
            datagrid_personal.Columns.Clear();

            // Configurar propiedades del DataGridView
            datagrid_personal.AllowUserToAddRows = false;
            datagrid_personal.AllowUserToDeleteRows = false;
            datagrid_personal.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            datagrid_personal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            datagrid_personal.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            datagrid_personal.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            datagrid_personal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datagrid_personal.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            datagrid_personal.Location = new System.Drawing.Point(13, 149);
            datagrid_personal.Name = "datagrid_personal";
            datagrid_personal.ReadOnly = true;
            datagrid_personal.RowTemplate.Height = 50;
            datagrid_personal.Size = new System.Drawing.Size(1143, 414);
            datagrid_personal.TabIndex = 2;
            datagrid_personal.CellClick -= datagrid_personal_CellClick;
            datagrid_personal.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_personal_CellClick);

            // Definir columnas según la tabla PERSONA y USUARIO
            datagrid_personal.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CId",
                HeaderText = "ID",
                DataPropertyName = "id_persona"
            });

            datagrid_personal.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CNombre",
                HeaderText = "Nombre",
                DataPropertyName = "nombre_persona"
            });

            datagrid_personal.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CApellido",
                HeaderText = "Apellido",
                DataPropertyName = "apellido_persona"
            });

            datagrid_personal.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CDNI",
                HeaderText = "DNI",
                DataPropertyName = "dni"
            });

            datagrid_personal.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CEmail",
                HeaderText = "Email",
                DataPropertyName = "email_persona"
            });

            datagrid_personal.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CDireccion",
                HeaderText = "Dirección",
                DataPropertyName = "direccion_persona"
            });

            datagrid_personal.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CUsuario",
                HeaderText = "Usuario",
                DataPropertyName = "usuario"
            });

            datagrid_personal.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CRol",
                HeaderText = "Rol",
                DataPropertyName = "nombre_rol"
            });



            // Botón Modificar (Color Amarillo)
            datagrid_personal.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CModificar",
                HeaderText = "Modificar",
                DataPropertyName = "modificar_personal"
            });

            // Botón Estado (Color Rojo o Celeste según el estado)
            datagrid_personal.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CEstado",
                HeaderText = "Estado",
                DataPropertyName = "eliminar_personal"
            });

            datagrid_personal.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CBaja",
                HeaderText = "Eliminado?",
                DataPropertyName = "baja_usuario"
            });

            // Formateo del datagrid
            datagrid_personal.CellFormatting += new DataGridViewCellFormattingEventHandler(datagrid_personal_CellFormatting);
        }

        private void datagrid_personal_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            // Verifica si la columna es la de CBaja
            if (datagrid_personal.Columns[e.ColumnIndex].Name == "CBaja")
            {
                // Verifica que el valor de la celda no sea nulo o DBNull
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    // Verifica si el valor es del tipo correcto antes de convertir
                    if (e.Value is int bajaValue)
                    {
                        // Cambia el valor a "No" o "Sí" según el estado
                        e.Value = bajaValue == 1 ? "No" : "Si";
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centra el texto
                        e.FormattingApplied = true; // Evita que el valor predeterminado se siga mostrando
                    }
                    else
                    {
                        // Si el valor no es un entero, podrías manejarlo como desees
                        e.FormattingApplied = false; // No aplicar formateo
                    }
                }
            }

            // Verifica si la columna es la de "Estado"
            if (datagrid_personal.Columns[e.ColumnIndex].Name == "CEstado")
            {
                // Verifica que el valor de la celda no sea nulo o DBNull
                if (e.Value == null)
                {
                    e.Value = "Estado";
                }
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    try
                    {
                        // Obtiene el ID del usuario de la fila actual
                        int idPersona = Convert.ToInt32(datagrid_personal.Rows[e.RowIndex].Cells["CId"].Value);

                        // Conectar a la base de datos para obtener el estado del usuario
                        string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string selectQuery = "SELECT baja_usuario FROM USUARIO WHERE id_persona = @IdPersona";

                            using (SqlCommand command = new SqlCommand(selectQuery, connection))
                            {
                                command.Parameters.AddWithValue("@IdPersona", idPersona);

                                // Ejecutar la consulta y obtener el estado del usuario
                                object result = command.ExecuteScalar();
                                if (result != null)
                                {
                                    int estado = Convert.ToInt32(result);

                                    // Cambia el valor a "Activar" o "Eliminar" según el estado
                                    if (estado == 0) // Usuario eliminado
                                    {
                                        e.Value = "Activar";
                                        e.CellStyle.BackColor = Color.LightBlue; // Cambia el color de fondo
                                        e.CellStyle.ForeColor = Color.Black; // Cambia el color del texto
                                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centra el texto
                                    }
                                    else
                                    {
                                        e.Value = "Eliminar";
                                        e.CellStyle.BackColor = Color.Red; // Cambia el color de fondo
                                        e.CellStyle.ForeColor = Color.White; // Cambia el color del texto
                                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centra el texto
                                    }

                                    // Indica que el formateo ha sido aplicado
                                    e.FormattingApplied = true;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Si ocurre un error, manejarlo y no aplicar el formateo
                        MessageBox.Show($"Error al obtener el estado del usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.FormattingApplied = false;
                    }
                }
                else
                {
                    // Si el valor es nulo o no es válido, no aplicar el formato
                    e.FormattingApplied = false;
                }
            }

            // Cambiar el color del texto de "Modificar"
            if (datagrid_personal.Columns[e.ColumnIndex].Name == "CModificar")
            {
                // Solo aplicar formateo si la celda tiene un valor no nulo
                if (datagrid_personal.Columns[e.ColumnIndex].Name == "CModificar")
                {
                    e.Value = "Modificar";
                    e.CellStyle.BackColor = Color.ForestGreen;
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.FormattingApplied = true;
                }
            }

            // Cambiar el fondo de la fila si el usuario está eliminado
            if (Convert.ToInt32(datagrid_personal.Rows[e.RowIndex].Cells["CBaja"].Value) == 0)
            {
                datagrid_personal.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkGray;
            }
        }

        private void ModificarEstadoUsuario(int idPersona)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta para obtener el estado actual del usuario
                    string selectQuery = "SELECT baja_usuario FROM USUARIO WHERE id_persona = @Id";
                    using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@Id", idPersona);

                        // Ejecutar el comando y verificar si se obtuvo un resultado
                        object result = selectCommand.ExecuteScalar();
                        if (result == null)
                        {
                            MessageBox.Show("No se encontró el usuario con el ID especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Salir si no hay resultado
                        }

                        int estadoActual = Convert.ToInt32(result);

                        // Alterna el estado: si está activo (0), lo inactivamos (1); si está inactivo, lo activamos
                        string updateQuery;
                        if (estadoActual == 0)
                        {
                            updateQuery = "UPDATE USUARIO SET baja_usuario = 1 WHERE id_persona = @Id";
                        }
                        else
                        {
                            updateQuery = "UPDATE USUARIO SET baja_usuario = 0 WHERE id_persona = @Id";
                        }

                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@Id", idPersona);

                            // Ejecuta la actualización
                            int rowsAffected = updateCommand.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Estado del usuario actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No se pudo actualizar el estado del usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                // Actualiza el DataGridView después de cambiar el estado
                CargarPersonal(); // Asegúrate de tener este método para cargar el DataGridView de personal
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el estado del usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void datagrid_personal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            // Verifica si la celda clicada es válida
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Si se hace clic en la columna de descripción
                if (datagrid_personal.Columns[e.ColumnIndex].Name == "CDireccion")
                {
                    // Obtener la información del usuario de la fila seleccionada
                    string direccion = datagrid_personal.Rows[e.RowIndex].Cells["CDireccion"].Value.ToString();
                    string nombreUsuario = datagrid_personal.Rows[e.RowIndex].Cells["CNombre"].Value.ToString();
                    string apellidoUsuario = datagrid_personal.Rows[e.RowIndex].Cells["CApellido"].Value.ToString();

                    // Mostrar un MessageBox con la información
                    MessageBox.Show($"Usuario: {apellidoUsuario}, {nombreUsuario} \nDireccion: {direccion}", "Detalles del Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Verifica si la columna es un textbox
                if (datagrid_personal.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn)
                {
                    // Verifica si se ha hecho clic en la columna de estado
                    if (datagrid_personal.Columns[e.ColumnIndex].Name == "CEstado")
                    {
                        // Obtiene el ID de la persona de la celda correspondiente
                        object cellValue = datagrid_personal.Rows[e.RowIndex].Cells["CId"].Value;

                        if (cellValue != null && int.TryParse(cellValue.ToString(), out int idPersona))
                        {
                            try
                            {
                                // Modifica el estado del usuario
                                ModificarEstadoUsuario(idPersona);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error al modificar el estado del usuario: {ex.Message}",
                                                "Error",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se pudo determinar el ID del usuario.",
                                            "Error",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        }
                    }

                    // Si se hizo clic en la columna "Modificar"
                    if (datagrid_personal.Columns[e.ColumnIndex].Name == "CModificar")
                    {
                        // Obtener el ID de la persona de la fila seleccionada en el DataGridView
                        object cellValue = datagrid_personal.Rows[e.RowIndex].Cells["CId"].Value;

                        if (cellValue != null && int.TryParse(cellValue.ToString(), out int idPersona))
                        {
                            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;

                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();

                                // Consulta para obtener detalles de usuario, persona, y rol basado en idPersona
                                string query = @"
                                    SELECT U.id_usuario, p.nombre_persona, p.apellido_persona, p.dni, p.email_persona, 
                                           p.direccion_persona, l.nombre_localidad, pr.nombre_provincia, 
                                           U.usuario, R.nombre_rol, p.fecha_nacimiento
                                    FROM USUARIO U
                                    INNER JOIN PERSONA p ON U.id_persona = p.id_persona
                                    INNER JOIN LOCALIDAD l ON p.id_localidad = l.id_localidad
                                    INNER JOIN PROVINCIA pr ON l.id_provincia = pr.id_provincia
                                    INNER JOIN ROL R ON U.id_rol = R.id_rol
                                    WHERE p.id_persona = @IdPersona";

                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@IdPersona", idPersona);

                                    using (SqlDataReader reader = command.ExecuteReader())
                                    {
                                        if (reader.Read()) // Verifica si se encontró el usuario
                                        {
                                            // Obtener los datos de la persona y usuario
                                            int idUsuario = Convert.ToInt32(reader["id_usuario"]);
                                            string nombre = reader["nombre_persona"].ToString();
                                            string apellido = reader["apellido_persona"].ToString();
                                            string dni = reader["dni"].ToString();
                                            string email = reader["email_persona"].ToString();
                                            string direccion = reader["direccion_persona"].ToString();
                                            string ciudad = reader["nombre_localidad"].ToString();
                                            string provincia = reader["nombre_provincia"].ToString();
                                            string usuarioNombre = reader["usuario"].ToString();
                                            string rol = reader["nombre_rol"].ToString();

                                            // Recuperar la fecha de nacimiento, asegurándonos de que no sea nula
                                            DateTime fechaNacimiento = reader["fecha_nacimiento"] != DBNull.Value
                                                ? Convert.ToDateTime(reader["fecha_nacimiento"])
                                                : DateTime.MinValue; // Si no tiene fecha, asignar un valor por defecto

                                            // Abrir el formulario de modificar usuario con los datos cargados
                                            registrar_personal modificarUsuario = new registrar_personal(
                                                idUsuario, nombre, apellido, dni, email, direccion, ciudad, provincia, usuarioNombre, rol, fechaNacimiento, this);
                                            modificarUsuario.ShowDialog();
                                        }
                                        else
                                        {
                                            MessageBox.Show("No se encontró el usuario seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                            }
                        }


                    }
                }
            }
        }


        private void BAgregarPersonal_Click(object sender, EventArgs e)
        {
            // Accedemos al formulario MDI principal (menu_admin)
            Form formularioMDI = this.MdiParent;

            // Verificamos si el formulario de registrar_personal ya está abierto
            Form formularioAbierto = Application.OpenForms.OfType<registrar_personal>().FirstOrDefault();

            if (formularioAbierto != null)
            {
                // Si ya está abierto, mostramos un mensaje o no hacemos nada, según lo que quieras
                MessageBox.Show("El formulario de registro de personal ya está abierto.");
            }
            else
            {
                // Creamos una nueva instancia del formulario registrar_personal
                registrar_personal nuevo_personal = new registrar_personal(this); // Pasar la referencia del formulario listado

                // Establecemos el formulario MDI principal (menu_admin) como el padre
                // nuevo_personal.MdiParent = formularioMDI;

                // Mostramos el formulario de registro de personal de forma modal (por encima del principal)
                nuevo_personal.ShowDialog();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BBuscarPersonal_Click(object sender, EventArgs e)
        {
            // Obtener el texto que se está buscando
            string textoBusqueda = textBoxBusqueda.Text.ToLower();

            // Verificar si el texto de búsqueda no está vacío
            if (!string.IsNullOrEmpty(textoBusqueda))
            {
                // Variable para controlar si se encontraron coincidencias
                bool algunaFilaVisible = false;

                // Desactivar temporalmente el CurrencyManager
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[datagrid_personal.DataSource];
                currencyManager.SuspendBinding();

                // Iterar sobre las filas del DataGridView
                foreach (DataGridViewRow fila in datagrid_personal.Rows)
                {
                    // Obtener los valores de las columnas relevantes y convertir a minúsculas
                    string nombrePersonal = fila.Cells["CNombre"].Value?.ToString().ToLower();
                    string apellidoPersonal = fila.Cells["CApellido"].Value?.ToString().ToLower();
                    string dniPersonal = fila.Cells["CDNI"].Value?.ToString().ToLower();
                    string rolPersonal = fila.Cells["CRol"].Value?.ToString().ToLower();
                    string usuarioPersonal = fila.Cells["CUsuario"].Value?.ToString().ToLower();
                    string emailPersonal = fila.Cells["CEmail"].Value?.ToString().ToLower();

                    // Verificar si alguna de las columnas coincide con el texto de búsqueda
                    if ((nombrePersonal != null && nombrePersonal.Contains(textoBusqueda))
                        || (apellidoPersonal != null && apellidoPersonal.Contains(textoBusqueda))
                        || (dniPersonal != null && dniPersonal.Contains(textoBusqueda))
                        || (rolPersonal != null && rolPersonal.Contains(textoBusqueda))
                        || (usuarioPersonal != null && usuarioPersonal.Contains(textoBusqueda))
                        || (emailPersonal != null && emailPersonal.Contains(textoBusqueda)))
                    {
                        fila.Visible = true; // Mostrar fila si coincide
                        algunaFilaVisible = true; // Se encontró al menos una coincidencia
                    }
                    else
                    {
                        fila.Visible = false; // Ocultar fila si no coincide
                    }
                }

                // Reactivar el CurrencyManager
                currencyManager.ResumeBinding();

                // Si no se encontró ninguna fila visible, mostrar un mensaje
                if (!algunaFilaVisible)
                {
                    MessageBox.Show("No se encontraron coincidencias.");
                }
            }
            else
            {
                // Si el cuadro de búsqueda está vacío, mostrar todas las filas
                foreach (DataGridViewRow fila in datagrid_personal.Rows)
                {
                    fila.Visible = true;
                }
            }
        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            // Limpiar el contenido del textBox de búsqueda
            textBoxBusqueda.Clear();

            // Opcional: mostrar todas las filas nuevamente
            foreach (DataGridViewRow fila in datagrid_personal.Rows)
            {
                fila.Visible = true;
            }
        }
    }
}
