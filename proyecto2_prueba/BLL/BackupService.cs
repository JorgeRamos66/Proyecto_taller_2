using System;
using System.Windows.Forms;
using DAL;

namespace BLL
{
    public class BackupService
    {
        private readonly DatabaseService _databaseService;

        public BackupService()
        {
            _databaseService = new DatabaseService();
        }

        public bool EjecutarBackup()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivo de Backup (*.bak)|*.bak",
                FileName = $"backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                bool resultado = _databaseService.RealizarBackup(saveFileDialog.FileName);

                if (resultado)
                {
                    MessageBox.Show($"Backup realizado con éxito. El archivo se guardó en: {saveFileDialog.FileName}");
                }

                return resultado;
            }

            return false;
        }

        public bool EjecutarRestauracion()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivo de Backup (*.bak)|*.bak",
                Title = "Seleccionar archivo de backup para restaurar"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                bool resultado = _databaseService.RestaurarBackup(openFileDialog.FileName);

                if (resultado)
                {
                    MessageBox.Show($"Restauración completada con éxito desde el archivo: {openFileDialog.FileName}");
                }

                return resultado;
            }

            return false;
        }
    }
}