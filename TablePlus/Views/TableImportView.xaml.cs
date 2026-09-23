using System.Windows;
using System.Windows.Interop;
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
