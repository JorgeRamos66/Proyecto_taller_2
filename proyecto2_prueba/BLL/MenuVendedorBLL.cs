using System;
using System.Windows.Forms;
using ML;
using proyecto2_prueba;

namespace BLL
{
    public class MenuVendedorBLL
    {
        public void AbrirFormulario<T>(Form mdiParent, string mensaje) where T : Form, new()
        {
            try
            {
                Form formularioAbierto = null;
                foreach (Form form in mdiParent.MdiChildren)
                {
                    if (form is T)
                    {
                        formularioAbierto = form;
                        break;
                    }
                }

                if (formularioAbierto != null)
                {
                    DialogResult resultado = MessageBox.Show(mensaje,
                                                         "Formulario en Uso",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        formularioAbierto.Close();
                        AbrirNuevoFormulario<T>(mdiParent);
                    }
                }
                else
                {
                    AbrirNuevoFormulario<T>(mdiParent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el formulario: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void AbrirNuevoFormulario<T>(Form mdiParent) where T : Form, new()
        {
            T nuevoFormulario = new T();
            nuevoFormulario.MdiParent = mdiParent;
            nuevoFormulario.Show();
        }

        public void CerrarSesion(Form formularioActual)
        {
            formularioActual.Close();
            inicio_sesion sesion = new inicio_sesion();
            sesion.Show();
        }
    }
}