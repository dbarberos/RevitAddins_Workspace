using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using TablePlus.Models;
using TablePlus.Services;
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
            DialogResult = _viewModel.CreatedView != null || _viewModel.CreatedViews.Count > 0;
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
                await _viewModel.InitializeBatchFilesAsync(files, _viewModel.IsRelativePath, append: true);
            }
        }
    }

    private void SelectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is ComboBox cb && cb.SelectedItem is string option)
        {
            _viewModel.ExecuteSelectionOption(option);
            Dispatcher.BeginInvoke(new Action(() => cb.SelectedIndex = -1));
        }
    }

    private void CloseFilterRegexPopup(object sender, RoutedEventArgs e)
    {
        BtnFilterRegexHelper.IsChecked = false;
    }

    private void ChevronButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is FrameworkElement fe && fe.DataContext is TableBatchFileModel fileModel)
        {
            LoggerService.LogInfo($"[TableImportView] ChevronButton_Click caught for file '{fileModel.FileName}'. Sheets: {fileModel.Sheets.Count}, HasSheets: {fileModel.HasSheets}, Current IsExpanded: {fileModel.IsExpanded}");
            fileModel.ToggleExpand();
            e.Handled = true;
        }
    }

    private void SheetRow_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        if (sender is FrameworkElement fe && fe.DataContext is TableBatchSheetItemModel sheetModel)
        {
            _viewModel.SelectSheetRow(sheetModel);
        }
    }
}

