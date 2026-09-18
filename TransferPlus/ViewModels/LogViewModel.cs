using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using TransferPlus.Services;

namespace TransferPlus.ViewModels;

public partial class LogViewModel : ObservableObject
{
    public ObservableCollection<string> Logs => LoggerService.Logs;

    public LogViewModel()
    {
    }

    [RelayCommand]
    private void ExportLogs()
    {
        try
        {
            if (Logs == null || !Logs.Any())
            {
                MessageBox.Show("No hay registros en el log para exportar.", "Exportar Logs", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            string defaultFileName = $"{DateTime.Now:yyyyMMdd_HHmmss}_DebugLogWindow.txt";

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = "Guardar Logs de Depuración",
                Filter = "Archivo de Texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*",
                FileName = defaultFileName,
                DefaultExt = ".txt"
            };

            bool? result = saveFileDialog.ShowDialog();
            if (result == true)
            {
                string filePath = saveFileDialog.FileName;
                string logContent = string.Join(Environment.NewLine, Logs);

                File.WriteAllText(filePath, logContent, Encoding.UTF8);

                MessageBox.Show($"Logs exportados exitosamente en:\n{filePath}", "Exportación Completada", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al exportar el archivo de log: {ex.Message}", "Error al Exportar", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
