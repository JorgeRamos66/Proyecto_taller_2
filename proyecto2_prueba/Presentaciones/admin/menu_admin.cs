using proyecto2_prueba.Presentaciones.admin;
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
using static proyecto2_prueba.inicio_sesion;

namespace proyecto2_prueba
{
    public partial class menu_admin : Form
    {
        public menu_admin()
        {
            InitializeComponent();
            this.IsMdiContainer = true; //Hace que el formulario sea un contenedor MDI
            // Actualizar el label con el nombre y apellido del usuario
            LNombreUsuario.Text = $"{UsuarioSesion.Nombre} {UsuarioSesion.Apellido}";
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void cerrarProgramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AbrirFormulario<T>(string mensaje) where T : Form, new()
        {
            // Verificar si ya hay un formulario MDI abierto
            Form formularioAbierto = this.MdiChildren.FirstOrDefault();

            if (formularioAbierto != null)
            {
                // Si hay un formulario abierto, preguntar si desea cerrarlo
                DialogResult resultado = MessageBox.Show(mensaje,
                                                         "Formulario en Uso",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Cerrar el formulario anterior
                    formularioAbierto.Close();

                    // Crear una nueva instancia y abrirla
                    T nuevoFormulario = new T();
                    nuevoFormulario.MdiParent = this;
                    nuevoFormulario.Show();
                }
                // Si elige "No", no se hace nada
            }
            else
            {
                // Si no hay ningún formulario abierto, se crea uno nuevo
                T nuevoFormulario = new T();
                nuevoFormulario.MdiParent = this;
                nuevoFormulario.Show();
            }
        }


        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Cerrar el formulario de admin y se redirige al inicio de sesion por el evento form closed
            this.Close();
            inicio_sesion sesion = new inicio_sesion();
        }

        private void registrarPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario que deseas abrir
            personal nuevo_personal = new personal();

            // Establece el formulario de administración como el formulario padre MDI
            nuevo_personal.MdiParent = this;

            // Abre el formulario hijo dentro del formulario de administración
            nuevo_personal.Show();
        }

        private void menuStripAdmin_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menu_admin_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aBMEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<personal>("Este formulario ya se encuentra abierto, ¿desea cerrar el anterior y abrir uno nuevo?");
        }

        private void aBMProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<listado_productos_admin>("Este formulario ya se encuentra abierto, ¿desea cerrar el anterior y abrir uno nuevo?");
        }


        private void aBMCategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<categorias_productos>("Este formulario ya se encuentra abierto, ¿desea cerrar el anterior y abrir uno nuevo?");
        }


        private void aBMNivelesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<niveles_clientes>("Este formulario ya se encuentra abierto, ¿desea cerrar el anterior y abrir uno nuevo?");
        }

        private void realizarBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Establecer la cadena de conexión a tu base de datos
            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;

            // Pedir al usuario que elija una ubicación para guardar el archivo de backup
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivo de Backup (*.bak)|*.bak"; // Filtro para solo mostrar archivos .bak
            saveFileDialog.FileName = "backup_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".bak"; // Nombre por defecto del archivo

            // Si el usuario selecciona una ubicación y un nombre de archivo, realizar el backup
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string backupFilePath = saveFileDialog.FileName; // Obtener la ruta del archivo seleccionado

                // Consulta SQL para realizar el backup de la base de datos
                string query = "BACKUP DATABASE [Proyecto_Taller_2] TO DISK = @backupFilePath";

                // Establecer la conexión a la base de datos y ejecutar el backup
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@backupFilePath", backupFilePath);

                    try
                    {
                        // Abrir la conexión y ejecutar el comando de backup
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Backup realizado con éxito. El archivo se guardó en: " + backupFilePath);
                    }
                    catch (Exception ex)
                    {
                        // En caso de error, mostrar un mensaje
                        MessageBox.Show("Error al realizar el backup: " + ex.Message);
                    }
                }
            }
        }

        private void restaurarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Establecer la cadena de conexión a tu base de datos
            string connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;

            // Pedir al usuario que seleccione el archivo de backup (.bak) a restaurar
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivo de Backup (*.bak)|*.bak"; // Filtro para solo mostrar archivos .bak
            openFileDialog.Title = "Seleccionar archivo de backup para restaurar";

            // Si el usuario selecciona un archivo, realizar la restauración
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string backupFilePath = openFileDialog.FileName; // Obtener la ruta del archivo seleccionado

                // Consulta SQL para restaurar la base de datos desde el archivo de backup
                string query = "RESTORE DATABASE [Proyecto_Taller_2] FROM DISK = @backupFilePath WITH REPLACE";

                // Establecer la conexión a la base de datos y ejecutar la restauración
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@backupFilePath", backupFilePath);

                    try
                    {
                        // Abrir la conexión y ejecutar el comando de restauración
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Restauración completada con éxito desde el archivo: " + backupFilePath);
                    }
                    catch (Exception ex)
                    {
                        // En caso de error, mostrar un mensaje
                        MessageBox.Show("Error al restaurar la base de datos: " + ex.Message);
                    }
                }
            }
        }
    }
}
