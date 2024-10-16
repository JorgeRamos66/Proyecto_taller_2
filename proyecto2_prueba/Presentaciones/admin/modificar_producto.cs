﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto2_prueba.Presentaciones.admin
{
    public partial class modificar_producto : Form
    {
        //Referencia al formulario principal
        private listado_productos_admin formularioListado; 

        //Se pasa como referencia el formulario listado de productos
        public modificar_producto(listado_productos_admin formularioListado)
        {
            InitializeComponent();
            this.formularioListado = formularioListado; // Asigna la referencia
        }

        private void textBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir letras, números, espacios y caracteres de control (como la tecla de retroceso)
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla si no es una letra, número, espacio o carácter de control
            }
        }

        private void textBoxStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Cancela el evento si no es un número o la tecla de retroceso
            }
        }

        private void textBoxPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Cancela el evento si no es un número o la tecla de retroceso
            }
        }

        //FilaIndex guarda el indice de la fila para saber cual modificar
        public int FilaIndex { get; set; }

        //Al presionar el boton de modificar producto se realiza la modificacion.
        private void BModificarProducto_Click(object sender, EventArgs e)
        {
            //OBTENCION DE LOS DATOS DEL FORMULARIO
            //Obtenenemos los datos ingresados por el usuario
            string nombre = textBoxNombre.Text;
            string stockText = textBoxStock.Text; //Se usa string temporalmente para validar
            string precioText = textBoxPrecio.Text; //Se usa string temporalmente para validar
            string categoria = comboBoxCategoria.SelectedItem.ToString();
            string descripcion = textBoxDescripcion.Text;
            string rutaImagen = textBoxRutaFoto.Text;

            //INICIO VALIDACIONES
            //Validamos los campos como Strings
            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(stockText) ||
                string.IsNullOrWhiteSpace(precioText) ||
                string.IsNullOrWhiteSpace(categoria) ||
                string.IsNullOrWhiteSpace(descripcion) ||
                string.IsNullOrWhiteSpace(rutaImagen))
            {
                MessageBox.Show("Debe rellenar todos los campos para cargar el producto.",
                 "Advertencia",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Warning);

                return; //Salir si no se han completado todos los campos
            }

            //Cargar la imagen desde la ruta
            Image imagenProducto;
            if (!string.IsNullOrEmpty(rutaImagen) && System.IO.File.Exists(rutaImagen))
            {
                imagenProducto = Image.FromFile(rutaImagen);
            }
            else
            {
                //Si la imagen no es válida
                MessageBox.Show("Ruta de imagen no válida.");
                return; // Detener la ejecución si la imagen no es válida
            }

            // Validación de formato correcto para stock y precio
            if (!int.TryParse(stockText, out int stock))
            {
                MessageBox.Show("El campo de stock debe ser un número entero válido.");
                return; // Salir si el stock no es válido
            }

            if (!decimal.TryParse(precioText, out decimal precio))
            {
                MessageBox.Show("El campo de precio debe ser un número decimal válido.");
                return; // Salir si el precio no es válido
            }

            //FIN VALIDACIONES

            //INICIO ACTUALIZACION DE FILA EN DATAGRID
            // Obtener la fila correspondiente en el DataGridView
            DataGridViewRow fila = formularioListado.datagrid_productos.Rows[FilaIndex];

            // Actualizar los valores de la fila
            fila.Cells["CNombre_producto"].Value = nombre;
            fila.Cells["CStock_producto"].Value = stock;
            fila.Cells["CPrecio"].Value = precio;
            fila.Cells["CCategoria_producto"].Value = categoria;
            fila.Cells["CDescripcion"].Value = descripcion;
            fila.Cells["CRutaImagen"].Value = rutaImagen; // Actualizar la ruta de la imagen
            fila.Cells["CImagen_Producto"].Value = Image.FromFile(rutaImagen); // Actualizar la imagen

            //Mensaje de que el producto se ha agregado de forma exitosa.
            MessageBox.Show($"El producto '{nombre}' se ha modificado correctamente.",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Cerrar el formulario de modificación
            this.Close();
        }

        private void BAgregarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|Todos los archivos (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Obtener la ruta del archivo seleccionado
                string filePath = openFileDialog.FileName;

                // Mostrar la ruta en el TextBox
                textBoxRutaFoto.Text = filePath;

                // Mostrar la imagen en el PictureBox
                pictureBoxProducto.Image = Image.FromFile(filePath);
            }
        }

        private void BSalirModificacion_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
