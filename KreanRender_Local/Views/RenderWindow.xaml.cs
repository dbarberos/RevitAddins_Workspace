using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace KreanRender.Views;

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

    private void UseGeminiCheckBox_Changed(object sender, RoutedEventArgs e)
    {
        if (GeminiKeyPanel != null)
        {
            GeminiKeyPanel.Visibility = UseGeminiCheckBox.IsChecked == true 
                ? Visibility.Visible 
                : Visibility.Collapsed;
        }
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private async void RenderButton_Click(object sender, RoutedEventArgs e)
    {
        var prompt = PromptTextBox.Text;
        var useGemini = UseGeminiCheckBox.IsChecked == true;
        var apiKey = GeminiKeyTextBox.Text;

        if (useGemini && string.IsNullOrWhiteSpace(apiKey))
        {
            MessageBox.Show("Por favor, introduce tu API Key de Gemini o desactiva la casilla para usar el modelo local gratuito.", "API Key requerida");
            return;
        }

        StatusText.Text = "Conectando al servidor Python local...";
        RenderButton.IsEnabled = false;

        try
        {
            // TODO: Aqui iría el codigo de HttpClient llamando a gradio en http://127.0.0.1:7860/api/predict
            // Mock delay
            await Task.Delay(2000);
            StatusText.Text = "Renderizado completado (Simulado).";
            
            // En una implementación real, guardariamos la imagen devuelta y la mostraríamos
            // RenderedImage.Source = new BitmapImage(new Uri(rutaRespuesta));
        }
        catch (Exception ex)
        {
            StatusText.Text = $"Error de renderizado: {ex.Message}";
        }
        finally
        {
            RenderButton.IsEnabled = true;
        }
    }
}
