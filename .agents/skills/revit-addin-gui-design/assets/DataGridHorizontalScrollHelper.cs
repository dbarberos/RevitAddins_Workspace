using System.Windows;
using System.Windows.Controls;

namespace RevitAddin.Common.UI.Helpers;

/// <summary>
/// Attached behavior and extension helpers for WPF DataGrid controls with frozen columns.
/// Resolves the WPF issue where the horizontal scrollbar locks up (ScrollableWidth = 0)
/// when items are empty or when columns overflow the viewport with FrozenColumnCount > 0.
/// </summary>
public static class DataGridHorizontalScrollHelper
{
    public static readonly DependencyProperty EnableDynamicHorizontalScrollProperty =
        DependencyProperty.RegisterAttached(
            "EnableDynamicHorizontalScroll",
            typeof(bool),
            typeof(DataGridHorizontalScrollHelper),
            new PropertyMetadata(false, OnEnableDynamicHorizontalScrollChanged));

    public static bool GetEnableDynamicHorizontalScroll(DependencyObject obj) =>
        (bool)obj.GetValue(EnableDynamicHorizontalScrollProperty);

    public static void SetEnableDynamicHorizontalScroll(DependencyObject obj, bool value) =>
        obj.SetValue(EnableDynamicHorizontalScrollProperty, value);

    private static void OnEnableDynamicHorizontalScrollChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is DataGrid dataGrid && e.NewValue is true)
        {
            Attach(dataGrid);
        }
    }

    /// <summary>
    /// Programmatically attaches dynamic horizontal scroll synchronization to a DataGrid.
    /// </summary>
    /// <param name="dataGrid">Target WPF DataGrid.</param>
    public static void Attach(DataGrid dataGrid)
    {
        if (dataGrid == null) return;

        // Enforce physical pixel scrolling for reliable frozen column tracking
        ScrollViewer.SetCanContentScroll(dataGrid, false);

        ScrollViewer? scrollViewer = null;
        double lastCalculatedWidth = -1;

        dataGrid.LayoutUpdated += (_, _) =>
        {
            scrollViewer ??= dataGrid.Template?.FindName("DG_ScrollViewer", dataGrid) as ScrollViewer;

            if (scrollViewer?.Content is FrameworkElement scrollContent)
            {
                double totalColumnsWidth = 0;
                foreach (var col in dataGrid.Columns)
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

                // Guard with delta threshold to prevent layout cycle loops (LayoutCycleException)
                if (totalColumnsWidth > 0 && Math.Abs(lastCalculatedWidth - totalColumnsWidth) > 1.0)
                {
                    lastCalculatedWidth = totalColumnsWidth;
                    scrollContent.MinWidth = totalColumnsWidth;
                }
            }
        };
    }
}
