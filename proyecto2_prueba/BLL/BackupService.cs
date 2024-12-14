using System;
using System.Windows.Forms;
using DAL;
using System.IO;

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
            try
            {
                //  
                string backupFolder = Path.Combine(@"C:\", "ProyectoTaller2Backups");

                // Crear el directorio si no existe
                if (!Directory.Exists(backupFolder))
                {
                    Directory.CreateDirectory(backupFolder);
                }

                // Generar nombre del archivo con fecha y hora
                string fileName = $"backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
                string rutaCompleta = Path.Combine(backupFolder, fileName);

                bool resultado = _databaseService.RealizarBackup(rutaCompleta);

                if (resultado)
                {
                    MessageBox.Show($"Backup realizado con éxito.\nArchivo guardado en: {rutaCompleta}",
                                "Éxito",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                }

                return resultado;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar el backup: {ex.Message}",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                return false;
            }
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