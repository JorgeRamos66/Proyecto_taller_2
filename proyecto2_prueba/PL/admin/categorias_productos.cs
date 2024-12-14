using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using ML;

namespace proyecto2_prueba.Presentaciones.admin
{
    public partial class categorias_productos : Form
    {
        private readonly CategoriaBLL categoriaBLL = new CategoriaBLL();

        public categorias_productos()
        {
            InitializeComponent();
            ConfigurarDataGridViewCategorias();
            CargarCategorias();
            datagrid_categorias.CellFormatting += datagrid_categorias_CellFormatting;
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

        private void ConfigurarDataGridViewCategorias()
        {
            datagrid_categorias.AllowUserToAddRows = false;
            datagrid_categorias.AllowUserToDeleteRows = false;
            datagrid_categorias.ReadOnly = true;
            datagrid_categorias.AutoGenerateColumns = false;

            // Configurar columnas
            datagrid_categorias.Columns.Clear();

            datagrid_categorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CIdCategoria",
                HeaderText = "ID",
                DataPropertyName = "id_categoria",
                Width = 50
            });

            datagrid_categorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CNombreCategoria",
                HeaderText = "Nombre",
                DataPropertyName = "nombre_categoria",
                Width = 100
            });

            datagrid_categorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CDescripcionCategoria",
                HeaderText = "Descripción",
                DataPropertyName = "descripcion_categoria",
                Width = 200
            });

            datagrid_categorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CModificar",
                HeaderText = "Modificar",
                Width = 80
            });

            datagrid_categorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CEstado",
                HeaderText = "Estado",
                Width = 80
            });

            datagrid_categorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CBaja",
                HeaderText = "Eliminado?",
                DataPropertyName = "estado_categoria",
                Width = 80
            });

            datagrid_categorias.Columns["CIdCategoria"].Visible = false;
        }

        private void CargarCategorias()
        {
            try
            {
                DataTable categorias = categoriaBLL.ObtenerCategorias();
                datagrid_categorias.DataSource = categorias;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las categorías: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BNuevaCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxNombreCategoria.Text) ||
                    string.IsNullOrWhiteSpace(textBoxDescripcionCategoria.Text))
                {
                    MessageBox.Show("Debe rellenar todos los campos.", 
                                  "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var categoria = new Categoria
                {
                    IdCategoria = string.IsNullOrEmpty(textBoxIDcategoria.Text) ? 
                                 0 : int.Parse(textBoxIDcategoria.Text),
                    NombreCategoria = textBoxNombreCategoria.Text.Trim(),
                    DescripcionCategoria = textBoxDescripcionCategoria.Text.Trim()
                };

                categoriaBLL.GuardarCategoria(categoria);

                MessageBox.Show("Categoría guardada correctamente.", 
                              "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
                CargarCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la categoría: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void datagrid_categorias_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (datagrid_categorias.Columns[e.ColumnIndex].Name == "CBaja")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    e.Value = Convert.ToInt32(e.Value) == 1 ? "No" : "Si";
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.FormattingApplied = true;
                }
            }

            if (datagrid_categorias.Columns[e.ColumnIndex].Name == "CModificar")
            {
                e.Value = "Modificar";
                e.CellStyle.BackColor = System.Drawing.Color.Yellow;
                e.CellStyle.ForeColor = System.Drawing.Color.Black;
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.FormattingApplied = true;
            }

            if (datagrid_categorias.Columns[e.ColumnIndex].Name == "CEstado")
            {
                try
                {
                    int idCategoria = Convert.ToInt32(datagrid_categorias.Rows[e.RowIndex].Cells["CIdCategoria"].Value);
                    int estado = Convert.ToInt32(datagrid_categorias.Rows[e.RowIndex].Cells["CBaja"].Value);

                    if (estado == 0)
                    {
                        e.Value = "Alta";
                        e.CellStyle.BackColor = System.Drawing.Color.LightBlue;
                    }
                    else
                    {
                        e.Value = "Baja";
                        e.CellStyle.BackColor = System.Drawing.Color.Red;
                        e.CellStyle.ForeColor = System.Drawing.Color.White;
                    }

                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.FormattingApplied = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al formatear el estado: {ex.Message}", 
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Cambiar el fondo de la fila si la categoría está eliminada
            if (Convert.ToInt32(datagrid_categorias.Rows[e.RowIndex].Cells["CBaja"].Value) == 0)
            {
                datagrid_categorias.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.DarkGray;
            }
        }

        private void datagrid_categorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                int idCategoria = Convert.ToInt32(datagrid_categorias.Rows[e.RowIndex].Cells["CIdCategoria"].Value);

                if (datagrid_categorias.Columns[e.ColumnIndex].Name == "CModificar")
                {
                    textBoxIDcategoria.Text = idCategoria.ToString();
                    textBoxNombreCategoria.Text = datagrid_categorias.Rows[e.RowIndex].Cells["CNombreCategoria"].Value.ToString();
                    textBoxDescripcionCategoria.Text = datagrid_categorias.Rows[e.RowIndex].Cells["CDescripcionCategoria"].Value.ToString();
                }
                else if (datagrid_categorias.Columns[e.ColumnIndex].Name == "CEstado")
                {
                    if (MessageBox.Show("¿Está seguro de cambiar el estado de esta categoría?", 
                                      "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        categoriaBLL.ModificarEstadoCategoria(idCategoria);
                        CargarCategorias();
                    }
                }
                // Mostrar la descripcion de la categoria   
                else if (datagrid_categorias.Columns[e.ColumnIndex].Name == "CDescripcionCategoria")
                {
                    string descripcion = datagrid_categorias.Rows[e.RowIndex].Cells["CDescripcionCategoria"].Value.ToString();
                    string nombreCategoria = datagrid_categorias.Rows[e.RowIndex].Cells["CNombreCategoria"].Value.ToString();
                    
                    MessageBox.Show(
                        $"Categoría: {nombreCategoria}\n\nDescripción:\n{descripcion}", 
                        "Detalles de la Categoría",
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar la acción: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            textBoxIDcategoria.Clear();
            textBoxNombreCategoria.Clear();
            textBoxDescripcionCategoria.Clear();
        }

        private void textBoxNombreCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}