using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
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

        // Wire up group expander and checkbox synchronization
        _viewModel.RequestSetAllGroupsExpanded = SetAllGroupsExpanded;
        _viewModel.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName is nameof(MainWindowViewModel.SelectedCount) or nameof(MainWindowViewModel.IsSelectAllChecked))
            {
                Dispatcher.BeginInvoke(new Action(UpdateGroupCheckboxes));
            }
        };

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

        if (DropOverlay != null && DropOverlay.Visibility == System.Windows.Visibility.Visible)
        {
            UpdateDropOverlayBounds();
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

    private void SetAllGroupsExpanded(bool isExpanded)
    {
        foreach (var expander in FindVisualChildren<Expander>(TablesDataGrid))
        {
            expander.IsExpanded = isExpanded;
        }
    }

    private void GroupCheckBox_Loaded(object sender, RoutedEventArgs e)
    {
        if (sender is CheckBox checkBox && checkBox.DataContext is CollectionViewGroup group)
        {
            UpdateGroupCheckBoxState(checkBox, group);
        }
    }

    private void GroupCheckBox_Click(object sender, RoutedEventArgs e)
    {
        if (sender is CheckBox checkBox && checkBox.DataContext is CollectionViewGroup group)
        {
            bool target = checkBox.IsChecked == true;
            var leafItems = GetLeafItems(group).ToList();
            foreach (var item in leafItems)
            {
                item.IsSelected = target;
            }
            Dispatcher.BeginInvoke(new Action(UpdateGroupCheckboxes));
        }
    }

    private void UpdateGroupCheckboxes()
    {
        var groupItems = FindVisualChildren<GroupItem>(TablesDataGrid);
        foreach (var groupItem in groupItems)
        {
            if (groupItem.DataContext is CollectionViewGroup group)
            {
                var checkBox = FindVisualChild<CheckBox>(groupItem);
                if (checkBox != null)
                {
                    UpdateGroupCheckBoxState(checkBox, group);
                }
            }
        }
    }

    private static void UpdateGroupCheckBoxState(CheckBox checkBox, CollectionViewGroup group)
    {
        var leafItems = GetLeafItems(group).ToList();
        if (leafItems.Count == 0)
        {
            checkBox.IsChecked = false;
        }
        else if (leafItems.All(i => i.IsSelected))
        {
            checkBox.IsChecked = true;
        }
        else if (leafItems.Any(i => i.IsSelected))
        {
            checkBox.IsChecked = null;
        }
        else
        {
            checkBox.IsChecked = false;
        }
    }

    private static IEnumerable<TableItemModel> GetLeafItems(CollectionViewGroup group)
    {
        foreach (var item in group.Items)
        {
            if (item is TableItemModel tableItem)
            {
                yield return tableItem;
            }
            else if (item is CollectionViewGroup subGroup)
            {
                foreach (var leaf in GetLeafItems(subGroup))
                {
                    yield return leaf;
                }
            }
        }
    }

    private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
    {
        if (depObj == null) yield break;
        int childCount = VisualTreeHelper.GetChildrenCount(depObj);
        for (int i = 0; i < childCount; i++)
        {
            var child = VisualTreeHelper.GetChild(depObj, i);
            if (child is T t)
            {
                yield return t;
            }
            foreach (var childOfChild in FindVisualChildren<T>(child))
            {
                yield return childOfChild;
            }
        }
    }

    private static T? FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
    {
        if (parent == null) return null;
        int childCount = VisualTreeHelper.GetChildrenCount(parent);
        for (int i = 0; i < childCount; i++)
        {
            var child = VisualTreeHelper.GetChild(parent, i);
            if (child is T typedChild)
            {
                return typedChild;
            }
            var result = FindVisualChild<T>(child);
            if (result != null)
            {
                return result;
            }
        }
        return null;
    }

    #region Drag and Drop Table Files

    private static readonly HashSet<string> SupportedTableExtensions = new(StringComparer.OrdinalIgnoreCase)
    {
        ".xlsx",
        ".xls",
        ".csv",
        ".xlsm",
        ".xltx",
        ".xltm",
        ".txt",
        ".tsv",
        ".tab",
        ".prn",
        ".dat",
        ".log",
        ".asc",
        ".pdf",
        ".docx",
        ".doc",
        ".rtf",
        ".md",
        ".markdown"
    };

    private static bool IsAuthorizedTableFile(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath)) return false;
        var ext = Path.GetExtension(filePath);
        return !string.IsNullOrEmpty(ext) && SupportedTableExtensions.Contains(ext);
    }

    private void TablesDataGrid_DragEnter(object sender, DragEventArgs e)
    {
        UpdateDataGridDropEffect(e);
    }

    private void TablesDataGrid_DragOver(object sender, DragEventArgs e)
    {
        UpdateDataGridDropEffect(e);
    }

    private void TablesDataGrid_DragLeave(object sender, DragEventArgs e)
    {
        ResetDataGridDropFeedback();
    }

    private void UpdateDataGridDropEffect(DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            if (e.Data.GetData(DataFormats.FileDrop) is string[] files && files.Length > 0)
            {
                var targetFile = files.FirstOrDefault(f => !string.IsNullOrWhiteSpace(f) && IsAuthorizedTableFile(f));
                if (targetFile != null)
                {
                    e.Effects = DragDropEffects.Copy;
                    e.Handled = true;
                    SetDataGridDropFeedback(true);
                    return;
                }
            }
        }

        e.Effects = DragDropEffects.None;
        e.Handled = true;
        SetDataGridDropFeedback(false);
    }

    private async void TablesDataGrid_Drop(object sender, DragEventArgs e)
    {
        ResetDataGridDropFeedback();

        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            if (e.Data.GetData(DataFormats.FileDrop) is string[] files && files.Length > 0)
            {
                var validFiles = files.Where(f => !string.IsNullOrWhiteSpace(f) && IsAuthorizedTableFile(f)).ToList();
                if (validFiles.Count > 0)
                {
                    e.Handled = true;
                    if (validFiles.Count == 1)
                    {
                        await _viewModel.AddTableAsync(validFiles[0]);
                    }
                    else
                    {
                        await _viewModel.AddTableWithFilesAsync(validFiles);
                    }
                }
            }
        }
    }

    private void SetDataGridDropFeedback(bool isValid)
    {
        if (isValid)
        {
            if (DropOverlay != null)
            {
                UpdateDropOverlayBounds();
                DropOverlay.Visibility = System.Windows.Visibility.Visible;
            }
        }
        else
        {
            ResetDataGridDropFeedback();
        }
    }

    private void ResetDataGridDropFeedback()
    {
        if (DropOverlay != null)
        {
            DropOverlay.Visibility = System.Windows.Visibility.Collapsed;
        }
    }

    private void UpdateDropOverlayBounds()
    {
        if (DropOverlay == null) return;

        try
        {
            if (_dataGridScrollViewer == null)
            {
                _dataGridScrollViewer = TablesDataGrid.Template?.FindName("DG_ScrollViewer", TablesDataGrid) as ScrollViewer;
            }

            if (_dataGridScrollViewer != null)
            {
                var presenter = FindVisualChild<ScrollContentPresenter>(_dataGridScrollViewer);
                if (presenter != null && presenter.ActualWidth > 0 && presenter.ActualHeight > 0)
                {
                    var transform = presenter.TransformToAncestor(DataGridContainer);
                    var topLeft = transform.Transform(new System.Windows.Point(0, 0));

                    double topMargin = Math.Max(0, topLeft.Y);
                    double leftMargin = Math.Max(0, topLeft.X);
                    double rightMargin = Math.Max(0, DataGridContainer.ActualWidth - (topLeft.X + presenter.ActualWidth));
                    double bottomMargin = Math.Max(0, DataGridContainer.ActualHeight - (topLeft.Y + presenter.ActualHeight));

                    DropOverlay.Margin = new Thickness(leftMargin, topMargin, rightMargin, bottomMargin);
                    return;
                }
            }
        }
        catch
        {
            // Silently fallback
        }

        DropOverlay.Margin = new Thickness(0, 29, 10, 10);
    }

    #endregion
}
