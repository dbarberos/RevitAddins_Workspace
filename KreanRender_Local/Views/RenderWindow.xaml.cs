using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace KreanRenderLocal.Views;

public partial class RenderWindow : Window
{
    private readonly string _viewName;
    private readonly string _materials;
    private readonly string _imageFilePath;

    public RenderWindow(string viewName, string materials, string imageFilePath)
    {
        InitializeComponent();
        
        _viewName = viewName;
        _materials = materials;
        _imageFilePath = imageFilePath;
        
        // Configurar UI con datos
        Title = $"KreanRender - Vista: {_viewName}";
        MaterialsTextBlock.Text = string.IsNullOrEmpty(_materials) ? "No se encontraron materiales" : _materials;
        PromptTextBox.Text = "A high quality photorealistic architectural render of a modern bright facade...";
        
        // Cargar y mostrar la imagen original
        if (File.Exists(_imageFilePath))
        {
            try
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad; // Liberar archivo
                bitmap.UriSource = new Uri(_imageFilePath);
                bitmap.EndInit();
                OriginalImage.Source = bitmap;
                StatusText.Text = "Vista capturada correctamente. Listo para renderizar.";
            }
            catch (Exception ex)
            {
                StatusText.Text = $"Error cargando la vista: {ex.Message}";
            }
        }
    }

    private void BrowseButton_Click(object sender, RoutedEventArgs e)
    {
        using (var dialog = new FolderBrowserDialog())
        {
            dialog.Description = "Selecciona una carpeta para descargar los modelos de IA (Minimo 10GB libres)";
            
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LocalPathTextBox.Text = dialog.SelectedPath;
                UpdateEngineStatus();
            }
        }
    }

    private void UpdateEngineStatus()
    {
        string path = LocalPathTextBox.Text;
        if (string.IsNullOrEmpty(path) || path.Contains("Selecciona"))
        {
            EngineStatusText.Text = "No inicializado";
            EngineStatusText.Foreground = System.Windows.Media.Brushes.Red;
            return;
        }

        if (Directory.Exists(Path.Combine(path, "models")))
        {
            EngineStatusText.Text = "Listo para Renderizar";
            EngineStatusText.Foreground = System.Windows.Media.Brushes.Green;
        }
        else
        {
            EngineStatusText.Text = "Pendiente de Descarga";
            EngineStatusText.Foreground = System.Windows.Media.Brushes.Orange;
        }
    }

    private void PurgeButton_Click(object sender, RoutedEventArgs e)
    {
        string path = LocalPathTextBox.Text;
        if (string.IsNullOrEmpty(path) || !Directory.Exists(path) || path.Contains("Selecciona"))
        {
            MessageBox.Show("No hay ninguna carpeta de instalación seleccionada para limpiar.", "Aviso");
            return;
        }

        var result = MessageBox.Show($"¿Estás seguro de que deseas eliminar TODOS los archivos en {path}?\n\nEsta acción liberará varios Gigabytes pero tendrás que volver a descargarlos si quieres usar el render local.", "Confirmar limpieza", MessageBoxButton.YesNo, MessageBoxImage.Warning);

        if (result == MessageBoxResult.Yes)
        {
            try
            {
                StatusText.Text = "Limpiando directorio...";
                Directory.Delete(path, true);
                Directory.CreateDirectory(path); // Recrear la carpeta vacía
                UpdateEngineStatus();
                StatusText.Text = "Espacio liberado correctamente.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al limpiar: {ex.Message}");
            }
        }
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private async void RenderButton_Click(object sender, RoutedEventArgs e)
    {
        var prompt = PromptTextBox.Text;
        var localPath = LocalPathTextBox.Text;

        if (string.IsNullOrWhiteSpace(localPath) || localPath.Contains("Selecciona"))
        {
            MessageBox.Show("Por favor, selecciona una carpeta de instalación primero.", "Configuración requerida");
            return;
        }

        if (string.IsNullOrWhiteSpace(prompt))
        {
            MessageBox.Show("El prompt no puede estar vacío.", "Prompt requerido");
            return;
        }

        RenderButton.IsEnabled = false;
        PurgeButton.IsEnabled = false;

        try
        {
            // Simulación de descarga e inicialización si no existe
            if (EngineStatusText.Text == "Pendiente de Descarga")
            {
                StatusText.Text = "Descargando entorno Python y Modelos ControlNet (Simulado)...";
                await Task.Delay(3000); // Simulando descarga pesada
                Directory.CreateDirectory(Path.Combine(localPath, "models"));
                UpdateEngineStatus();
            }

            StatusText.Text = "Analizando geometría de la vista de Revit...";
            await Task.Delay(1000);

            StatusText.Text = "Ejecutando ControlNet (Image-to-Image) localmente...";
            
            // Aquí llamaríamos al script de Python pasando el _imageFilePath y el prompt
            // string pythonApp = Path.Combine(localPath, "engine", "render.py");
            
            await Task.Delay(3000);

            // Simulación de resultado
            StatusText.Text = "¡Carga completada! El render local ha respetado tu geometría.";
            
            // En una implementación real cargaríamos el archivo resultante
            // RenderedImage.Source = ...
        }
        catch (Exception ex)
        {
            StatusText.Text = $"Error en motor local: {ex.Message}";
        }
        finally
        {
            RenderButton.IsEnabled = true;
            PurgeButton.IsEnabled = true;
        }
    }
}
