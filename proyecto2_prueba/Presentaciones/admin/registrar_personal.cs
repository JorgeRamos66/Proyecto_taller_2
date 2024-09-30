using proyecto2_prueba.Presentaciones.admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto2_prueba
{
    public partial class registrar_personal : Form
    {
        private personal formularioListado; // Campo para almacenar la referencia del formulario listado
        private int IdUsuario; // Campo para almacenar el ID del usuario

        public registrar_personal(personal listado)
        {
            InitializeComponent();
            formularioListado = listado; // Guardar la referencia del formulario listado_personal
            IdUsuario = 0; // Establecer por defecto a 0 para inserción
        }

        public registrar_personal(int idUsuario, string nombre, string apellido, string dni, string email, string direccion, string ciudad, string provincia, personal listado)
        {
            InitializeComponent();
            formularioListado = listado; // Guardar la referencia del formulario listado_personal
            IdUsuario = idUsuario; // Guardar el ID del usuario

            // Cargar los datos en los controles del formulario
            textBoxNombre.Text = nombre;
            textBoxApellido.Text = apellido;
            textBoxEmail.Text = email;
            textBoxDNI.Text = dni;
            textCiudad.Text = ciudad;
            textProvincia.Text = provincia;
            textBoxDireccion.Text = direccion;
        }

        private void LNombre_Click(object sender, EventArgs e)
        {

        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LDni_Click(object sender, EventArgs e)
        {

        }

        private void LCalle_Click(object sender, EventArgs e)
        {

        }

        private void LLocalidad_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
