using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using TablePlus.Models;
using TablePlus.ViewModels;

namespace TablePlus.Views;

/// <summary>
/// Interaction logic for MainWindowView.xaml.
/// Master Table Dashboard providing inventory overview, live status tracking,
/// batch synchronization, and design management.
/// </summary>
public partial class MainWindowView : Window
{
    private readonly MainWindowViewModel _viewModel;
    private ScrollViewer? _dataGridScrollViewer;
    private double _lastCalculatedMinWidth = -1;

    public MainWindowView(MainWindowViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        DataContext = _viewModel;

        // Register UI dispatcher for real-time log streaming
        TablePlus.Services.LoggerService.SetDispatcher(this.Dispatcher);

        TablesDataGrid.LayoutUpdated += TablesDataGrid_LayoutUpdated;

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

        // Attach owner window to Revit main process and trigger initial inventory discovery
        Loaded += async (_, _) =>
        {
#if DEBUG
            TablePlus.Application.ShowDebugLogWindow(this);
            this.Closed += (_, _) => TablePlus.Application.CloseDebugLogWindow();
#endif
            try
            {
                var revitWindowHandle = Process.GetCurrentProcess().MainWindowHandle;
                if (revitWindowHandle != IntPtr.Zero)
                {
                    new WindowInteropHelper(this).Owner = revitWindowHandle;
                }
            }
            catch
            {
                // Silently fallback if running outside live Revit host
            }

            await _viewModel.RefreshInventoryAsync();
        };
    }

    private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        _viewModel.OpenSelectedView();
    }

    private void WorksheetComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is FrameworkElement { DataContext: TableItemModel item } && e.AddedItems.Count > 0)
        {
            _ = _viewModel.OnSheetChangedAsync(item);
        }
    }

    private void TablesDataGrid_LayoutUpdated(object? sender, EventArgs e)
    {
        if (_dataGridScrollViewer == null)
        {
            _dataGridScrollViewer = TablesDataGrid.Template?.FindName("DG_ScrollViewer", TablesDataGrid) as ScrollViewer;
        }

        if (_dataGridScrollViewer?.Content is FrameworkElement scrollContent)
        {
            double totalColumnsWidth = 0;
            foreach (var col in TablesDataGrid.Columns)
            {
                if (col.ActualWidth > 0)
                {
                    totalColumnsWidth += col.ActualWidth;
                }
                else if (col.Width.IsAbsolute)
                {
                    totalColumnsWidth += col.Width.Value;
                }
                else if (col.MinWidth > 0)
                {
                    totalColumnsWidth += col.MinWidth;
                }
            }

            if (totalColumnsWidth > 0 && Math.Abs(_lastCalculatedMinWidth - totalColumnsWidth) > 1.0)
            {
                _lastCalculatedMinWidth = totalColumnsWidth;
                scrollContent.MinWidth = totalColumnsWidth;
            }
        }
    }

    private void CloseFilterRegexPopup(object sender, RoutedEventArgs e)
    {
        BtnFilterRegexHelper.IsChecked = false;
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
