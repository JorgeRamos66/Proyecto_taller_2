using System;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Linq;
using BLL;
using ML;
using proyecto2_prueba;

namespace proyecto2_prueba.Presentaciones.admin
{
    public partial class personal : Form
    {
        private PersonalBLL personalBLL = new PersonalBLL();
        private DataTable personalData;

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
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void CargarPersonal()
        {
            try
            {
                personalData = personalBLL.ObtenerPersonal();
                datagrid_personal.DataSource = personalData;
                datagrid_personal.Columns["CId"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el personal: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDataGridView()
        {
            datagrid_personal.Columns.Clear();
            datagrid_personal.AllowUserToAddRows = false;
            datagrid_personal.AllowUserToDeleteRows = false;
            datagrid_personal.BackgroundColor = SystemColors.ActiveCaption;
            datagrid_personal.BorderStyle = BorderStyle.Fixed3D;
            datagrid_personal.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            datagrid_personal.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            datagrid_personal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datagrid_personal.GridColor = SystemColors.ActiveCaptionText;
            datagrid_personal.Location = new Point(13, 149);
            datagrid_personal.Name = "datagrid_personal";
            datagrid_personal.ReadOnly = true;
            datagrid_personal.RowTemplate.Height = 50;
            datagrid_personal.Size = new Size(1143, 414);
            datagrid_personal.TabIndex = 2;

            // Configurar columnas
            var columnas = new[]
            {
                new { Name = "CId", Header = "ID", Property = "id_persona" },
                new { Name = "CNombre", Header = "Nombre", Property = "nombre_persona" },
                new { Name = "CApellido", Header = "Apellido", Property = "apellido_persona" },
                new { Name = "CDNI", Header = "DNI", Property = "dni" },
                new { Name = "CEmail", Header = "Email", Property = "email_persona" },
                new { Name = "CDireccion", Header = "Dirección", Property = "direccion_persona" },
                new { Name = "CUsuario", Header = "Usuario", Property = "usuario" },
                new { Name = "CRol", Header = "Rol", Property = "nombre_rol" },
                new { Name = "CModificar", Header = "Modificar", Property = "modificar_personal" },
                new { Name = "CEstado", Header = "Estado", Property = "eliminar_personal" },
                new { Name = "CBaja", Header = "Eliminado?", Property = "baja_usuario" }
            };

            foreach (var col in columnas)
            {
                datagrid_personal.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = col.Name,
                    HeaderText = col.Header,
                    DataPropertyName = col.Property
                });
            }

            datagrid_personal.CellClick -= datagrid_personal_CellClick;
            datagrid_personal.CellClick += datagrid_personal_CellClick;
        }

        private void datagrid_personal_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            switch (datagrid_personal.Columns[e.ColumnIndex].Name)
            {
                case "CBaja":
                    if (e.Value != null && e.Value != DBNull.Value)
                    {
                        e.Value = Convert.ToInt32(e.Value) == 1 ? "No" : "Si";
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        e.FormattingApplied = true;
                    }
                    break;

                case "CModificar":
                    e.Value = "Modificar";
                    e.CellStyle.BackColor = Color.ForestGreen;
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.FormattingApplied = true;
                    break;

                case "CEstado":
                    FormatearCeldaEstado(e);
                    break;
            }

            // Formatear fila si el usuario está eliminado
            if (Convert.ToInt32(datagrid_personal.Rows[e.RowIndex].Cells["CBaja"].Value) == 0)
            {
                datagrid_personal.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkGray;
            }
        }

        private void FormatearCeldaEstado(DataGridViewCellFormattingEventArgs e)
{
        if (e.Value == null)
        {
            e.Value = "Estado";
        }

        try
        {
            int bajaUsuario = Convert.ToInt32(datagrid_personal.Rows[e.RowIndex].Cells["CBaja"].Value);
            bool estaActivo = bajaUsuario == 1;

            e.Value = estaActivo ? "Eliminar" : "Activar";
            e.CellStyle.BackColor = estaActivo ? Color.Red : Color.LightBlue;
            e.CellStyle.ForeColor = estaActivo ? Color.White : Color.Black;
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            e.FormattingApplied = true;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al obtener el estado del usuario: {ex.Message}");
            e.FormattingApplied = false;
        }
    }

        private void datagrid_personal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var columna = datagrid_personal.Columns[e.ColumnIndex].Name;
            var idPersona = Convert.ToInt32(datagrid_personal.Rows[e.RowIndex].Cells["CId"].Value);

            switch (columna)
            {
                case "CDireccion":
                    MostrarDetallesDireccion(e.RowIndex);
                    break;

                case "CEstado":
                    ModificarEstadoUsuario(idPersona);
                    break;

                case "CModificar":
                    AbrirFormularioModificacion(idPersona);
                    break;
            }
        }

        private void MostrarDetallesDireccion(int rowIndex)
        {
            string direccion = datagrid_personal.Rows[rowIndex].Cells["CDireccion"].Value.ToString();
            string nombreUsuario = datagrid_personal.Rows[rowIndex].Cells["CNombre"].Value.ToString();
            string apellidoUsuario = datagrid_personal.Rows[rowIndex].Cells["CApellido"].Value.ToString();

            MessageBox.Show($"Usuario: {apellidoUsuario}, {nombreUsuario} \nDireccion: {direccion}",
                          "Detalles del Usuario",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        }

        private void ModificarEstadoUsuario(int idPersona)
        {
            try
            {
                personalBLL.ModificarEstadoUsuario(idPersona);
                MessageBox.Show("Estado del usuario actualizado correctamente.",
                              "Éxito",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
                CargarPersonal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el estado del usuario: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void AbrirFormularioModificacion(int idPersona)
        {
            try
            {
                var personal = personalBLL.ObtenerPersonalPorId(idPersona);
                if (personal != null)
                {
                    var modificarUsuario = new registrar_personal(
                        personal.IdUsuario,
                        personal.Nombre,
                        personal.Apellido,
                        personal.DNI,
                        personal.Email,
                        personal.Direccion,
                        personal.Localidad,
                        personal.Provincia,
                        personal.Usuario,
                        personal.Rol,
                        personal.FechaNacimiento,
                        this);

                    modificarUsuario.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el formulario de modificación: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void BAgregarPersonal_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<registrar_personal>().Any())
            {
                MessageBox.Show("El formulario de registro de personal ya está abierto.");
                return;
            }

            var nuevo_personal = new registrar_personal(listado: this);
            nuevo_personal.ShowDialog();
        }

        private void BBuscarPersonal_Click(object sender, EventArgs e)
        {
            string textoBusqueda = textBoxBusqueda.Text.ToLower();
            try
            {
                DataTable resultados = personalBLL.BuscarPersonal(textoBusqueda, personalData);
                datagrid_personal.DataSource = resultados;

                if (resultados.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron coincidencias.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la búsqueda: {ex.Message}");
            }
        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            textBoxBusqueda.Clear();
            CargarPersonal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}