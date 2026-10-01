using System.Windows;
using System.Windows.Interop;
using TablePlus.Models;
using TablePlus.ViewModels;

namespace TablePlus.Views;

/// <summary>
/// Interaction logic for TableImportView.xaml.
/// Hosts the modern FilterPlus card-based user interface for importing Excel vector tables.
/// </summary>
public partial class TableImportView : Window
{
    private readonly TableImportViewModel _viewModel;

    public TableImportView(TableImportViewModel viewModel)
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

        // Wire close request from ViewModel
        _viewModel.RequestClose = () =>
        {
            DialogResult = _viewModel.CreatedView != null;
            Close();
        };

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
                // Silently fallback if running outside live Revit host (e.g. preview)
            }
        };
    }

    private void Window_DragOver(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            e.Effects = DragDropEffects.Copy;
            e.Handled = true;
        }
        else
        {
            e.Effects = DragDropEffects.None;
        }
    }

    private async void Window_Drop(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            var files = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (files != null && files.Length > 0)
            {
                var targetFile = files[0];
                await _viewModel.HandleFileDropAsync(targetFile);
            }
        }
    }
}

/// <summary>
/// Provides user-friendly descriptions for Enums in ComboBox dropdowns (TargetViewType, TableImportType, TablePageOption).
/// </summary>
public class EnumDisplayConverter : System.Windows.Data.IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        return value switch
        {
            TargetViewType.DraftingView => "Drafting View (ViewDrafting)",
            TargetViewType.LegendView => "Legend View (Multi-Sheet Placeable)",
            TargetViewType.ScheduleView => "Schedule View (ViewSchedule)",
            TableImportType.Table => "Table (Editable Vector Lines & Text)",
            TableImportType.Image => "Image (High-Resolution Raster)",
            TablePageOption.AllPages => "All Pages",
            TablePageOption.SelectPages => "Select Pages...",
            _ => value?.ToString() ?? string.Empty
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
