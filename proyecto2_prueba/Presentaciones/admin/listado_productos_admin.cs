using System;
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
    public partial class listado_productos_admin : Form
    {
        public listado_productos_admin()
        {
            InitializeComponent();
        }

        

        private void BAltaProducto_Click(object sender, EventArgs e)
        {
            
            // Accedemos al formulario MDI principal (menu_admin)
            Form formularioMDI = this.MdiParent;

            // Verificamos si el formulario de alta_producto ya está abierto
            Form formularioAbierto = Application.OpenForms.OfType<alta_producto>().FirstOrDefault();

            if (formularioAbierto != null)
            {
                // Si ya está abierto, mostramos un mensaje o no hacemos nada, según lo que quieras
                MessageBox.Show("El formulario de alta de producto ya está abierto.");
            }
            else
            {
                // Creamos una nueva instancia del formulario alta_producto
                alta_producto nuevo_producto = new alta_producto(this);

                // Establecemos el formulario MDI principal (menu_admin) como el padre
                //nuevo_producto.MdiParent = formularioMDI;

                //Mostramos el formulario de alta de producto de forma modal (por encima del principal)
                nuevo_producto.ShowDialog();
            }
        }


        private void BSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BBuscarProducto_Click(object sender, EventArgs e)
        {
            // Obtener el texto que se está buscando
            string textoBusqueda = textBoxBusqueda.Text.ToLower();

            // Verificar si el texto de búsqueda no está vacío
            if (!string.IsNullOrEmpty(textoBusqueda))
            {
                // Iterar sobre las filas del DataGridView
                foreach (DataGridViewRow fila in datagrid_productos.Rows)
                {
                    // Obtener el valor de la columna que contiene el nombre del producto (ajusta el índice si es necesario)
                    string nombreProducto = fila.Cells["CNombre_producto"].Value?.ToString().ToLower();

                    // Comparar el texto de búsqueda con el nombre del producto
                    if (nombreProducto != null && nombreProducto.Contains(textoBusqueda))
                    {
                        fila.Visible = true; // Mostrar fila si coincide
                    }
                    else
                    {
                        fila.Visible = false; // Ocultar fila si no coincide
                    }
                }

                // Verificar si alguna fila coincide (si no hay filas visibles)
                bool algunaFilaVisible = false;
                foreach (DataGridViewRow fila in datagrid_productos.Rows)
                {
                    if (fila.Visible)
                    {
                        algunaFilaVisible = true;
                        break;
                    }
                }

                if (!algunaFilaVisible)
                {
                    MessageBox.Show("No se encontraron coincidencias.");
                }
            }
            else
            {
                //Si el cuadro de búsqueda está vacío, mostrar todas las filas
                foreach (DataGridViewRow fila in datagrid_productos.Rows)
                {
                    fila.Visible = true;
                }
            }
        }

        private void datagrid_productos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si el clic fue en una celda de los botones (para no manejar clics en otras celdas)
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewButtonColumn column = datagrid_productos.Columns[e.ColumnIndex] as DataGridViewButtonColumn;

                if (column != null)
                {
                    // Verifica si el botón "Modificar" fue presionado
                    if (e.ColumnIndex == datagrid_productos.Columns["CModificar"].Index && e.RowIndex >= 0)
                    {
                        // Accedemos al formulario MDI principal (menu_admin)
                        Form formularioMDI = this.MdiParent;

                        //Extrae los datos de la fila seleccionada
                        string nombre = datagrid_productos.Rows[e.RowIndex].Cells["CNombre_producto"].Value.ToString();
                        int stock = Convert.ToInt32(datagrid_productos.Rows[e.RowIndex].Cells["CStock_producto"].Value);
                        decimal precio = Convert.ToDecimal(datagrid_productos.Rows[e.RowIndex].Cells["CPrecio"].Value);
                        string categoria = datagrid_productos.Rows[e.RowIndex].Cells["CCategoria_producto"].Value.ToString();
                        string descripcion = datagrid_productos.Rows[e.RowIndex].Cells["CDescripcion"].Value.ToString();
                        string rutaImagen = datagrid_productos.Rows[e.RowIndex].Cells["CRutaImagen"].Value.ToString();

                        

                        //Crea una instancia del formulario modificar_producto
                        //Pasa el formulario principal como referencia
                        modificar_producto formModificar = new modificar_producto(this);

                        //Establecemos el formulario MDI principal (menu_admin) como el padre
                        //formModificar.MdiParent = formularioMDI;

                        //Pasa los datos a los controles del formulario
                        formModificar.textBoxNombre.Text = nombre;
                        formModificar.textBoxStock.Text = stock.ToString();
                        formModificar.textBoxPrecio.Text = precio.ToString();
                        formModificar.comboBoxCategoria.Text = categoria;
                        formModificar.textBoxDescripcion.Text = descripcion;
                        formModificar.textBoxRutaFoto.Text = rutaImagen;

                        // Muestra la imagen en el PictureBox
                        formModificar.pictureBoxProducto.ImageLocation = rutaImagen;

                        //Pasar el índice de la fila para saber en cual realizar los cambios
                        formModificar.FilaIndex = e.RowIndex;

                        //Abre el formulario de modificación
                        formModificar.ShowDialog();
                    }
                    else if (e.ColumnIndex == datagrid_productos.Columns["CBaja"].Index && e.RowIndex >= 0)
                    {
                            // Eliminar la fila correspondiente
                            datagrid_productos.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }

    }
}
