using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using ML;

namespace proyecto2_prueba.Presentaciones.admin
{
    public partial class niveles_clientes : Form
    {
        private readonly NivelBLL nivelBLL = new NivelBLL();

        public niveles_clientes()
        {
            InitializeComponent();
            ConfigurarDataGridViewNiveles();
            CargarNiveles();
            datagrid_niveles.CellFormatting += datagrid_niveles_CellFormatting;
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

        private void ConfigurarDataGridViewNiveles()
        {
            datagrid_niveles.AllowUserToAddRows = false;
            datagrid_niveles.AllowUserToDeleteRows = false;
            datagrid_niveles.ReadOnly = true;
            datagrid_niveles.AutoGenerateColumns = false;
            datagrid_niveles.BackgroundColor = SystemColors.ActiveCaption;
            datagrid_niveles.BorderStyle = BorderStyle.Fixed3D;
            datagrid_niveles.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            datagrid_niveles.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;

            // Configurar columnas
            datagrid_niveles.Columns.Clear();

            datagrid_niveles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CIdNivel",
                HeaderText = "ID",
                DataPropertyName = "id_nivel",
                Width = 50,
                Visible = false
            });

            datagrid_niveles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CNombreNivel",
                HeaderText = "Nombre",
                DataPropertyName = "nombre_nivel",
                Width = 80
            });

            datagrid_niveles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CDescuentoNivel",
                HeaderText = "Descuento %",
                DataPropertyName = "descuento",
                Width = 90
            });

            datagrid_niveles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CModificar",
                HeaderText = "Modificar",
                Width = 80
            });

            datagrid_niveles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CEstado",
                HeaderText = "Estado",
                Width = 80
            });

            datagrid_niveles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CBaja",
                HeaderText = "Eliminado?",
                DataPropertyName = "estado_nivel",
                Width = 80
            });
        }

        private void CargarNiveles()
        {
            try
            {
                datagrid_niveles.DataSource = nivelBLL.ObtenerNiveles();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los niveles: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BNuevoNivel_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxNombreNivel.Text) ||
                    numericUpDownDescuento.Value == 0)
                {
                    MessageBox.Show("Debe rellenar todos los campos para agregar o modificar un nivel.",
                                  "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var nivel = new Nivel
                {
                    IdNivel = string.IsNullOrEmpty(textBoxIDnivel.Text) ? 
                             0 : int.Parse(textBoxIDnivel.Text),
                    NombreNivel = textBoxNombreNivel.Text.Trim(),
                    Descuento = (int)numericUpDownDescuento.Value
                };

                nivelBLL.GuardarNivel(nivel);

                MessageBox.Show($"Nivel {(nivel.IdNivel == 0 ? "agregado" : "actualizado")} correctamente.",
                              "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
                CargarNiveles();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el nivel: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void datagrid_niveles_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (datagrid_niveles.Columns[e.ColumnIndex].Name == "CBaja")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    e.Value = Convert.ToInt32(e.Value) == 1 ? "No" : "Si";
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.FormattingApplied = true;
                }
            }

            if (datagrid_niveles.Columns[e.ColumnIndex].Name == "CModificar")
            {
                e.Value = "Modificar";
                e.CellStyle.BackColor = Color.Yellow;
                e.CellStyle.ForeColor = Color.Black;
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.FormattingApplied = true;
            }

            if (datagrid_niveles.Columns[e.ColumnIndex].Name == "CEstado")
            {
                try
                {
                    int estado = Convert.ToInt32(datagrid_niveles.Rows[e.RowIndex].Cells["CBaja"].Value);

                    if (estado == 0)
                    {
                        e.Value = "Alta";
                        e.CellStyle.BackColor = Color.LightBlue;
                    }
                    else
                    {
                        e.Value = "Baja";
                        e.CellStyle.BackColor = Color.Red;
                        e.CellStyle.ForeColor = Color.White;
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

            if (Convert.ToInt32(datagrid_niveles.Rows[e.RowIndex].Cells["CBaja"].Value) == 0)
            {
                datagrid_niveles.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkGray;
            }
        }

        private void datagrid_niveles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                int idNivel = Convert.ToInt32(datagrid_niveles.Rows[e.RowIndex].Cells["CIdNivel"].Value);

                if (datagrid_niveles.Columns[e.ColumnIndex].Name == "CModificar")
                {
                    BNuevoNivel.Text = "MODIFICAR";
                    textBoxIDnivel.Text = idNivel.ToString();
                    textBoxNombreNivel.Text = datagrid_niveles.Rows[e.RowIndex].Cells["CNombreNivel"].Value.ToString();
                    numericUpDownDescuento.Value = Convert.ToDecimal(datagrid_niveles.Rows[e.RowIndex].Cells["CDescuentoNivel"].Value);
                }
                else if (datagrid_niveles.Columns[e.ColumnIndex].Name == "CEstado")
                {
                    if (MessageBox.Show("¿Está seguro de cambiar el estado de este nivel?",
                                      "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        nivelBLL.ModificarEstadoNivel(idNivel);
                        CargarNiveles();
                    }
                }
                else if (datagrid_niveles.Columns[e.ColumnIndex].Name == "CDescuentoNivel")
                {
                    string nombreNivel = datagrid_niveles.Rows[e.RowIndex].Cells["CNombreNivel"].Value.ToString();
                    string descuento = datagrid_niveles.Rows[e.RowIndex].Cells["CDescuentoNivel"].Value.ToString();
                    
                    MessageBox.Show($"Nivel: {nombreNivel}\nDescuento: {descuento}%",
                                  "Detalles del Nivel",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
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
            BNuevoNivel.Text = "AGREGAR";
            textBoxIDnivel.Clear();
            textBoxNombreNivel.Clear();
            numericUpDownDescuento.Value = 0;
        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxNombreNivel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}