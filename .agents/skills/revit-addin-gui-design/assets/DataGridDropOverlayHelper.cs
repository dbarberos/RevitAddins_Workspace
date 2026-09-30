using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RevitAddin.Gui.Helpers;

/// <summary>
/// Helper class for managing modern WPF DataGrid Drag &amp; Drop feedback overlays.
/// Dynamically restricts overlay bounds to the viewport area (ScrollContentPresenter),
/// excluding column headers at the top, vertical scrollbars on the right,
/// and horizontal scrollbars at the bottom, without modifying container borders.
/// </summary>
public static class DataGridDropOverlayHelper
{
    /// <summary>
    /// Synchronizes the overlay margin so that it covers strictly the DataGrid content viewport,
    /// leaving column headers and scrollbars fully uncovered and visible.
    /// </summary>
    /// <param name="overlay">The overlay border element to reposition via Margins.</param>
    /// <param name="dataGrid">The target DataGrid hosting the data.</param>
    /// <param name="container">The outer container (usually Border or Grid) wrapping the DataGrid and overlay.</param>
    /// <param name="fallbackHeaderHeight">Estimated header row height in pixels if template is not yet loaded (default: 29.0).</param>
    /// <param name="fallbackScrollbarSize">Estimated scrollbar thickness in pixels (default: 10.0).</param>
    public static void UpdateOverlayViewportBounds(
        FrameworkElement? overlay,
        DataGrid? dataGrid,
        FrameworkElement? container,
        double fallbackHeaderHeight = 29.0,
        double fallbackScrollbarSize = 10.0)
    {
        if (overlay == null || dataGrid == null || container == null) return;

        try
        {
            var scrollViewer = dataGrid.Template?.FindName("DG_ScrollViewer", dataGrid) as ScrollViewer 
                               ?? FindVisualChild<ScrollViewer>(dataGrid);

            if (scrollViewer != null)
            {
                var presenter = FindVisualChild<ScrollContentPresenter>(scrollViewer);
                if (presenter != null && presenter.ActualWidth > 0 && presenter.ActualHeight > 0)
                {
                    var transform = presenter.TransformToAncestor(container);
                    var topLeft = transform.Transform(new System.Windows.Point(0, 0));

                    double topMargin = Math.Max(0, topLeft.Y);
                    double leftMargin = Math.Max(0, topLeft.X);
                    double rightMargin = Math.Max(0, container.ActualWidth - (topLeft.X + presenter.ActualWidth));
                    double bottomMargin = Math.Max(0, container.ActualHeight - (topLeft.Y + presenter.ActualHeight));

                    overlay.Margin = new Thickness(leftMargin, topMargin, rightMargin, bottomMargin);
                    return;
                }
            }
        }
        catch
        {
            // Fallback below upon layout measurement exceptions
        }

        overlay.Margin = new Thickness(0, fallbackHeaderHeight, fallbackScrollbarSize, fallbackScrollbarSize);
    }

    /// <summary>
    /// Finds the first child of the specified type in the visual tree.
    /// </summary>
    public static T? FindVisualChild<T>(DependencyObject? parent) where T : DependencyObject
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
}
