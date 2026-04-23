using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;

namespace AIRender.Views;

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
        Title = $"AIRender - ArchViz Excellence: {_viewName}";
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



    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private async void RenderButton_Click(object sender, RoutedEventArgs e)
    {
        var prompt = PromptTextBox.Text;

        if (string.IsNullOrWhiteSpace(prompt))
        {
            MessageBox.Show("Por favor, introduce un texto descriptivo para el render.", "Prompt requerido");
            return;
        }

        StatusText.Text = "Conectando a Pollinations AI (Modelo Libre)...";
        RenderButton.IsEnabled = false;

        try
        {
            string cleanMaterials = _materials.Replace(Environment.NewLine, " ");
            string fullPrompt = $"{prompt}. The architecture must strongly reflect these materials: {cleanMaterials}. Extremely high quality photorealistic render.";
        
            string encodedPrompt = Uri.EscapeDataString(fullPrompt);
            string requestUrl = $"https://image.pollinations.ai/prompt/{encodedPrompt}?width=800&height=600&nologo=true";

            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(120);
                
                var response = await client.GetAsync(requestUrl);
                
                if (response.IsSuccessStatusCode)
                {
                    StatusText.Text = "Descargando imagen...";
                    byte[] imageBytes = await response.Content.ReadAsByteArrayAsync();
                    
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        string outPath = Path.Combine(Path.GetTempPath(), $"KreanRender_Out_{Guid.NewGuid()}.jpg");
                        File.WriteAllBytes(outPath, imageBytes);
                        
                        var bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.UriSource = new Uri(outPath);
                        bitmap.EndInit();
                        
                        RenderedImage.Source = bitmap;
                        StatusText.Text = "¡Renderizado completado con éxito!";
                    }
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error HTTP: {response.StatusCode}\n{error}", "Error de Conexión");
                    StatusText.Text = "Fallo en la comunicación con la API descentralizada.";
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ocurrió un error inesperado al renderizar: {ex.Message}", "Excepción");
            StatusText.Text = "Error interno.";
        }
        finally
        {
            RenderButton.IsEnabled = true;
        }
    }
}
