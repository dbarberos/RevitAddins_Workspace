using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using TablePlus.Models;
using MediaColor = System.Windows.Media.Color;
using WpfVisibility = System.Windows.Visibility;

namespace TablePlus.Views;

/// <summary>
/// Converts a hex color string (e.g. #0284C7) to a WPF SolidColorBrush.
/// Safely falls back to a transparent brush if invalid.
/// </summary>
public class HexStringToBrushConverter : IValueConverter
{
    private static readonly SolidColorBrush FallbackBrush = Brushes.Transparent;

    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is string hex && !string.IsNullOrWhiteSpace(hex))
        {
            try
            {
                var brush = (SolidColorBrush)new BrushConverter().ConvertFromInvariantString(hex.Trim())!;
                return brush;
            }
            catch
            {
                return FallbackBrush;
            }
        }
        return FallbackBrush;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        throw new NotSupportedException();
}

/// <summary>
/// Converts TableSyncStatus to a status text string.
/// </summary>
public class StatusToTextConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is TableSyncStatus status)
        {
            return status switch
            {
                TableSyncStatus.UpToDate => "Up to Date",
                TableSyncStatus.Modified => "Modified",
                TableSyncStatus.FileNotFound => "File Missing",
                TableSyncStatus.Unlinked => "Unlinked",
                _ => status.ToString()
            };
        }
        return string.Empty;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        throw new NotSupportedException();
}

/// <summary>
/// Converts TableSyncStatus to a badge foreground brush (green, amber, red, gray).
/// </summary>
public class StatusToBrushConverter : IValueConverter
{
    private static readonly SolidColorBrush GreenBrush = new(MediaColor.FromRgb(16, 185, 129));
    private static readonly SolidColorBrush AmberBrush = new(MediaColor.FromRgb(217, 119, 6));
    private static readonly SolidColorBrush RedBrush = new(MediaColor.FromRgb(239, 68, 68));
    private static readonly SolidColorBrush GrayBrush = new(MediaColor.FromRgb(148, 163, 184));

    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is TableSyncStatus status)
        {
            return status switch
            {
                TableSyncStatus.UpToDate => GreenBrush,
                TableSyncStatus.Modified => AmberBrush,
                TableSyncStatus.FileNotFound => RedBrush,
                _ => GrayBrush
            };
        }
        return GrayBrush;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        throw new NotSupportedException();
}

/// <summary>
/// Converts TableSyncStatus to a badge background brush.
/// </summary>
public class StatusToBgBrushConverter : IValueConverter
{
    private static readonly SolidColorBrush GreenBg = new(MediaColor.FromRgb(236, 253, 245));
    private static readonly SolidColorBrush AmberBg = new(MediaColor.FromRgb(254, 243, 199));
    private static readonly SolidColorBrush RedBg = new(MediaColor.FromRgb(254, 242, 242));
    private static readonly SolidColorBrush GrayBg = new(MediaColor.FromRgb(241, 245, 249));

    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is TableSyncStatus status)
        {
            return status switch
            {
                TableSyncStatus.UpToDate => GreenBg,
                TableSyncStatus.Modified => AmberBg,
                TableSyncStatus.FileNotFound => RedBg,
                _ => GrayBg
            };
        }
        return GrayBg;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        throw new NotSupportedException();
}

/// <summary>
/// Converts Boolean to Visibility inverting the standard logic.
/// </summary>
public class InverseBooleanToVisibilityConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        bool b = value is true;
        return b ? WpfVisibility.Collapsed : WpfVisibility.Visible;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is WpfVisibility v)
        {
            return v != WpfVisibility.Visible;
        }
        return false;
    }
}

/// <summary>
/// Converts TargetViewType to a short display label.
/// </summary>
public class ViewTypeToTextConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is TargetViewType viewType)
        {
            return viewType switch
            {
                TargetViewType.DraftingView => "Drafting",
                TargetViewType.LegendView => "Legend",
                _ => viewType.ToString()
            };
        }
        return string.Empty;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        throw new NotSupportedException();
}

