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

    public MainWindowView(MainWindowViewModel viewModel)
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

        // Attach owner window to Revit main process and trigger initial inventory discovery
        Loaded += async (_, _) =>
        {
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

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
