using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Management;
using MessageBox = System.Windows.MessageBox;
using ComboBox = System.Windows.Controls.ComboBox;

namespace KreanRenderLocal.Views;

public partial class RenderWindow : Window
{
    private readonly string _viewName;
    private readonly string _materials;
    private readonly string _imageFilePath;
    private string _recommendedMode = "CPU";
    private bool _isHardwareOk = false;
    
    // Almacén para restauración de sliders tras Render Rápido
    private double _lastSteps;
    private double _lastGuidance;
    private double _lastStrength;

    public RenderWindow(string viewName, string materials, string imageFilePath)
    {
        InitializeComponent();
        
        _viewName = viewName;
        _materials = materials;
        _imageFilePath = imageFilePath;
        
        UpdateUIState(0); // Estado inicial: Solo Analizar
        
        // Configurar UI con datos
        Title = $"KreanRender Local - Vista: {_viewName}";
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

    private void Log(string message)
    {
        if (string.IsNullOrEmpty(message)) return;
        Dispatcher.Invoke(() => 
        {
            if (LogTextBox != null)
            {
                LogTextBox.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}\n");
                LogTextBox.ScrollToEnd();
            }
        });
    }

    private void UpdateUIState(int step)
    {
        if (!Dispatcher.CheckAccess())
        {
            Dispatcher.Invoke(() => UpdateUIState(step));
            return;
        }

        if (AnalyzeButton == null) return;

        AnalyzeButton.IsEnabled = (step == 0);
        BrowseButton.IsEnabled = (step >= 1);
        LocalPathTextBox.Background = (step >= 1) ? System.Windows.Media.Brushes.White : System.Windows.Media.Brushes.GhostWhite;
        
        InstallButton.IsEnabled = (step >= 2);
        ModelSelector.IsEnabled = (step >= 1);
        
        // El renderizado solo se activa si hay modelos instalados
        string localPath = LocalPathTextBox.Text;
        bool hasModels = !string.IsNullOrEmpty(localPath) && Directory.Exists(Path.Combine(localPath, "models"));
        
        RenderButton.IsEnabled = hasModels;
        RenderButton.Opacity = hasModels ? 1.0 : 0.5;
        FastRenderButton.IsEnabled = hasModels;
        FastRenderButton.Opacity = hasModels ? 1.0 : 0.5;
        
        PromptTextBox.IsEnabled = hasModels;
        PromptTextBox.Opacity = hasModels ? 1.0 : 0.5;
        PurgeButton.IsEnabled = hasModels;
        PurgeButton.Opacity = hasModels ? 1.0 : 0.5;
        
        Log($"Estado de la interfaz: Paso {step}");
    }

    private async void AnalyzeButton_Click(object sender, RoutedEventArgs e)
    {
        AnalyzeButton.IsEnabled = false;
        Log("Iniciando análisis de hardware...");
        HardwareInfoText.Text = "Analizando hardware... Por favor, espera.";

        try
        {
            await Task.Delay(500); 

            string gpuName = "Desconocida";
            long vramBytes = 0;
            long totalRamBytes = 0;

            // 1. Detectar GPU y VRAM
            using (var searcher = new ManagementObjectSearcher("select * from Win32_VideoController"))
            {
                foreach (var obj in searcher.Get())
                {
                    gpuName = obj["Caption"]?.ToString() ?? "Desconocida";
                    var ram = obj["AdapterRAM"];
                    if (ram != null) vramBytes = Convert.ToInt64(ram);
                    Log($"GPU Detectada: {gpuName} ({vramBytes / (1024.0 * 1024 * 1024):F1} GB VRAM)");
                    break;
                }
            }

            // 2. Detectar RAM Total
            using (var searcher = new ManagementObjectSearcher("select * from Win32_ComputerSystem"))
            {
                foreach (var obj in searcher.Get())
                {
                    var ram = obj["TotalPhysicalMemory"];
                    if (ram != null) totalRamBytes = Convert.ToInt64(ram);
                    Log($"RAM Total: {totalRamBytes / (1024.0 * 1024 * 1024):F1} GB");
                }
            }

            double vramGb = vramBytes / (1024.0 * 1024 * 1024);
            double ramGb = totalRamBytes / (1024.0 * 1024 * 1024);

            // 3. Lógica de Decisión
            _isHardwareOk = ramGb >= 7.5; 

            if (!_isHardwareOk)
            {
                Log("ERROR: Hardware insuficiente (RAM < 8GB).");
                HardwareInfoText.Text = $"❌ BLOQUEO: Se han detectado {ramGb:F1}GB RAM. Se requieren mínimo 8GB.";
                HardwareInfoText.Foreground = System.Windows.Media.Brushes.Red;
                return;
            }

            if (vramGb >= 6.0)
            {
                _recommendedMode = "GPU (Turbo)";
                HardwareInfoText.Text = $"✅ {gpuName} ({vramGb:F1}GB VRAM). MODO: GPU Turbo.";
            }
            else if (vramGb >= 3.5)
            {
                _recommendedMode = "GPU (Optimizado)";
                HardwareInfoText.Text = $"✅ {gpuName} ({vramGb:F1}GB VRAM). RECOMENDADO: Modo GPU (Low-VRAM).";
            }
            else
            {
                _recommendedMode = "CPU";
                HardwareInfoText.Text = $"⚠️ {gpuName} ({vramGb:F1}GB VRAM). RECOMENDADO: Modo CPU (Seguridad).";
            }

            StatusText.Text = "Análisis completado. Selecciona una carpeta para continuar.";
            UpdateUIState(1);
        }
        catch (Exception ex)
        {
            HardwareInfoText.Text = $"Error al analizar hardware: {ex.Message}";
            AnalyzeButton.IsEnabled = true;
        }
    }

    private void ModelSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // Defensa contra fuego durante inicialización
        if (LocalPathTextBox == null || string.IsNullOrEmpty(LocalPathTextBox.Text)) return;
        if (LocalPathTextBox.Text.Contains("Analiza")) return;
        UpdateUIState(2); 
    }

    private void BrowseButton_Click(object sender, RoutedEventArgs e)
    {
        using (var dialog = new FolderBrowserDialog())
        {
            dialog.Description = "Selecciona una carpeta vacía o con espacio suficiente (Min. 12GB)";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LocalPathTextBox.Text = dialog.SelectedPath;
                
                // Comprobar espacio en disco
                try
                {
                    string drive = Path.GetPathRoot(dialog.SelectedPath);
                    DriveInfo di = new DriveInfo(drive);
                    double freeGb = di.AvailableFreeSpace / (1024.0 * 1024 * 1024);

                    // Comprobar si ya existe una instalación funcional
                    string pythonExe = Path.Combine(dialog.SelectedPath, "python_env", "python.exe");
                    if (File.Exists(pythonExe))
                    {
                        Log("Instalación previa detectada en esta carpeta.");
                        InstallStatusText.Text = "Motor detectado. Listo para renderizar.";
                        UpdateUIState(3); 
                    }
                    else
                    {
                        InstallStatusText.Text = $"Carpeta lista ({freeGb:F1}GB libres). Selecciona el motor arriba.";
                        UpdateUIState(2);
                    }
                }
                catch { UpdateUIState(2); }
            }
        }
    }

    private async Task<bool> DownloadPythonEnvAsync(string targetPath)
    {
        string enginePath = Path.Combine(targetPath, "python_env");
        string pythonExe = Path.Combine(enginePath, "python.exe");

        if (File.Exists(pythonExe)) return true;

        try
        {
            Log("Descargando Python base (C# Bootstrap)... esto puede tardar unos minutos.");
            if (!Directory.Exists(enginePath)) Directory.CreateDirectory(enginePath);

            string zipPath = Path.Combine(targetPath, "python_tmp.zip");
            string url = "https://www.python.org/ftp/python/3.10.11/python-3.10.11-embed-amd64.zip";

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                using (var fs = new FileStream(zipPath, FileMode.Create))
                {
                    await response.Content.CopyToAsync(fs);
                }
            }

            Log("Extrayendo Python embebido...");
            ZipFile.ExtractToDirectory(zipPath, enginePath);
            File.Delete(zipPath);

            // Configurar import site
            string pthFile = Path.Combine(enginePath, "python310._pth");
            if (File.Exists(pthFile))
            {
                var content = File.ReadAllText(pthFile);
                content = content.Replace("#import site", "import site");
                File.WriteAllText(pthFile, content);
            }

            Log("Python base extraído con éxito.");
            return true;
        }
        catch (Exception ex)
        {
            Log($"ERROR descargando Python: {ex.Message}");
            return false;
        }
    }

    private async void InstallButton_Click(object sender, RoutedEventArgs e)
    {
        InstallButton.IsEnabled = false;
        InstallProgressBar.Visibility = System.Windows.Visibility.Visible;
        InstallProgressBar.Value = 0;
        
        string selectedModel = (ModelSelector.SelectedItem as ComboBoxItem)?.Content.ToString();
        string installPath = LocalPathTextBox.Text;

        Log($"--- INICIANDO PROCESO DE INSTALACIÓN ---");

        // 1. Asegurar Python base desde C# (Bootstrapper)
        bool pythonOk = await DownloadPythonEnvAsync(installPath);
        if (!pythonOk) 
        {
            MessageBox.Show("No se pudo preparar el entorno de Python inicial.");
            InstallButton.IsEnabled = true;
            return;
        }

        InstallProgressBar.Value = 30;
        string pythonExe = Path.Combine(installPath, "python_env", "python.exe");
        string scriptPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Server", "install_engine.py");

        if (!File.Exists(scriptPath))
        {
            Log($"ERROR CRÍTICO: No se encuentra el script en {scriptPath}");
            MessageBox.Show("Archivo de instalación no encontrado. Contacte con soporte.");
            return;
        }

        try
        {
            Log($"Ejecutando script de motor: {scriptPath}");
            await Task.Run(() => 
            {
                var startInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = pythonExe, // Usar el python que acabamos de descargar
                    Arguments = $"\"{scriptPath}\" --path \"{installPath}\" --mode \"{_recommendedMode}\" --model \"{selectedModel}\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                using (var process = System.Diagnostics.Process.Start(startInfo))
                {
                    // Leer salida estándar
                    Task.Run(() => {
                        while (!process.StandardOutput.EndOfStream)
                            Log(process.StandardOutput.ReadLine());
                    });

                    // Leer errores
                    Task.Run(() => {
                        while (!process.StandardError.EndOfStream)
                            Log($"[PYTHON ERROR] {process.StandardError.ReadLine()}");
                    });

                    process.WaitForExit();
                }
            });

            InstallProgressBar.Value = 100;
            Log("¡INSTALACIÓN COMPLETADA!");
            UpdateUIState(3);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}");
            UpdateUIState(2);
        }
    }

    private void PurgeButton_Click(object sender, RoutedEventArgs e)
    {
        string path = LocalPathTextBox.Text;
        var result = MessageBox.Show($"¿Deseas liberar los 12GB de {path}?", "Confirmar limpieza", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            try { 
                Directory.Delete(path, true); 
                Directory.CreateDirectory(path);
                UpdateUIState(1);
                StatusText.Text = "Espacio liberado. Motor desinstalado.";
            } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e) => Close();

    private async void FastRenderButton_Click(object sender, RoutedEventArgs e)
    {
        // Guardar estado actual
        _lastSteps = StepsSlider.Value;
        _lastGuidance = GuidanceSlider.Value;
        _lastStrength = StrengthSlider.Value;
        
        // Aplicar valores rápidos (basados en requerimientos: optimizados para render rápido e IA)
        StepsSlider.Value = 12;
        GuidanceSlider.Value = 5.0;
        StrengthSlider.Value = 0.6; // Valor equilibrado para rapidez
        
        StepsSlider.IsEnabled = false;
        GuidanceSlider.IsEnabled = false;
        StrengthSlider.IsEnabled = false;
        
        await ExecuteRenderProcess("RÁPIDO (Borrador)");
        
        // Restaurar
        StepsSlider.Value = _lastSteps;
        GuidanceSlider.Value = _lastGuidance;
        StrengthSlider.Value = _lastStrength;
        
        StepsSlider.IsEnabled = true;
        GuidanceSlider.IsEnabled = true;
        StrengthSlider.IsEnabled = true;
    }

    private async void RenderButton_Click(object sender, RoutedEventArgs e)
    {
        await ExecuteRenderProcess("FINAL");
    }

    private async Task ExecuteRenderProcess(string modeName)
    {
        var prompt = PromptTextBox.Text;
        var negPrompt = NegativePromptTextBox.Text;
        var steps = (int)StepsSlider.Value;
        var guidance = GuidanceSlider.Value;
        var strength = StrengthSlider.Value;

        if (string.IsNullOrWhiteSpace(prompt)) { MessageBox.Show("Escribe un prompt."); return; }

        RenderButton.IsEnabled = false;
        FastRenderButton.IsEnabled = false;
        
        string installPath = LocalPathTextBox.Text;
        string outputPath = Path.Combine(installPath, "render_output.png");
        string enginePath = Path.Combine(installPath, "python_env", "python.exe");
        string scriptPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Server", "render_engine.py");
        string modelsDir = Path.Combine(installPath, "models");

        Log($"Lanzando Render {modeName}...");
        RenderProgressPanel.Visibility = System.Windows.Visibility.Visible;
        RenderProgressBar.Value = 0;
        RenderPercentText.Text = "0%";

        try
        {
            await Task.Run(() => 
            {
                var startInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = enginePath,
                    Arguments = $"\"{scriptPath}\" --image \"{_imageFilePath}\" --prompt \"{prompt}\" --neg \"{negPrompt}\" --out \"{outputPath}\" --models_path \"{modelsDir}\" --steps {steps} --guidance {guidance.ToString(System.Globalization.CultureInfo.InvariantCulture)} --strength {strength.ToString(System.Globalization.CultureInfo.InvariantCulture)}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                using (var process = System.Diagnostics.Process.Start(startInfo))
                {
                    while (!process.StandardOutput.EndOfStream)
                    {
                        string line = process.StandardOutput.ReadLine();
                        Log(line);

                        // Detectar progreso enviado por Python
                        if (line.StartsWith("PROGRESS:"))
                        {
                            if (int.TryParse(line.Replace("PROGRESS:", "").Trim(), out int val))
                            {
                                Dispatcher.Invoke(() => 
                                {
                                    RenderProgressBar.Value = val;
                                    RenderPercentText.Text = $"{val}%";
                                });
                            }
                        }
                    }
                    process.WaitForExit();
                }
            });

            RenderProgressBar.Value = 100;
            RenderPercentText.Text = "100%";
            await Task.Delay(500); // Pequeña pausa para ver el 100%
            RenderProgressPanel.Visibility = System.Windows.Visibility.Collapsed;

            if (File.Exists(outputPath))
            {
                Dispatcher.Invoke(() => 
                {
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.UriSource = new Uri(outputPath);
                    bitmap.EndInit();
                    RenderedImage.Source = bitmap;
                    SaveResultButton.IsEnabled = true; // Habilitar guardado
                });
                Log($"Render {modeName} finalizado y cargado.");
            }
            else
            {
                throw new Exception("El motor no generó la imagen de salida. Revisa los logs.");
            }
        }
        catch (Exception ex) { MessageBox.Show($"Error en el Render: {ex.Message}"); }
        finally 
        { 
            RenderButton.IsEnabled = true; 
            FastRenderButton.IsEnabled = true;
        }
    }

    private void SaveResultButton_Click(object sender, RoutedEventArgs e)
    {
        string sourcePath = Path.Combine(LocalPathTextBox.Text, "render_output.png");
        if (!File.Exists(sourcePath))
        {
            MessageBox.Show("No hay ningún render para guardar.");
            return;
        }

        var saveDialog = new Microsoft.Win32.SaveFileDialog
        {
            Filter = "Imagen PNG|*.png|Imagen JPEG|*.jpg",
            FileName = $"KreanRender_{DateTime.Now:yyyyMMdd_HHmmss}",
            Title = "Guardar Resultado del Render"
        };

        if (saveDialog.ShowDialog() == true)
        {
            try
            {
                File.Copy(sourcePath, saveDialog.FileName, true);
                Log($"Imagen guardada en: {saveDialog.FileName}");
                MessageBox.Show("Imagen guardada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}");
            }
        }
    }
}
