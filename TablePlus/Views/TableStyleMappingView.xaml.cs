using System.Windows;
using System.Windows.Interop;
using TablePlus.ViewModels;

namespace TablePlus.Views;

/// <summary>
/// Interaction logic for TableStyleMappingView.xaml.
/// Modal dialog for configuring custom line styles, body typography, and header row overrides.
/// </summary>
public partial class TableStyleMappingView : Window
{
    private readonly TableStyleMappingViewModel _viewModel;

    public TableStyleMappingView(TableStyleMappingViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        DataContext = _viewModel;

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
                var revitWindowHandle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
                if (revitWindowHandle != IntPtr.Zero)
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
}
