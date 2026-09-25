using System.Diagnostics;
using System.Windows;
using System.Windows.Interop;

namespace TablePlus.Views;

/// <summary>
/// Interaction logic for ConfigurationView.xaml.
/// Settings and external source providers configuration dialog.
/// </summary>
public partial class ConfigurationView : Window
{
    public ConfigurationView()
    {
        InitializeComponent();

        // Enforce Window Icon via absolute pack URI to prevent external host Revit.exe fallback
        try
        {
            Icon = new System.Windows.Media.Imaging.BitmapImage(
                new Uri("pack://application:,,,/TablePlus;component/Resources/Icons/TablePlus32x32.png", UriKind.Absolute));
        }
        catch
        {
            // Silently continue with XAML declaration
        }

        // Attach owner window to Revit main process to preserve modal stacking and centering
        Loaded += (_, _) =>
        {
            try
            {
                var revitWindowHandle = Process.GetCurrentProcess().MainWindowHandle;
                if (revitWindowHandle != IntPtr.Zero && Owner == null)
                {
                    new WindowInteropHelper(this).Owner = revitWindowHandle;
                }
            }
            catch
            {
                // Silently fallback if running outside live Revit host
            }
        };
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
