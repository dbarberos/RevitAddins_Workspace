namespace TablePlus.Models;

/// <summary>
/// Definition of a single border edge.
/// </summary>
public record CellBorderLine(CellBorderStyle Style, string? ColorHex = null);

/// <summary>
/// Four-side border specification for an Excel cell.
/// </summary>
public class CellBorders
{
    public CellBorderLine Left { get; set; } = new(CellBorderStyle.None);
    public CellBorderLine Top { get; set; } = new(CellBorderStyle.None);
    public CellBorderLine Right { get; set; } = new(CellBorderStyle.None);
    public CellBorderLine Bottom { get; set; } = new(CellBorderStyle.None);

    public bool HasAnyBorder =>
        Left.Style != CellBorderStyle.None ||
        Top.Style != CellBorderStyle.None ||
        Right.Style != CellBorderStyle.None ||
        Bottom.Style != CellBorderStyle.None;
}

/// <summary>
/// Pure representation of an Excel cell with styling, geometry, and contents.
/// </summary>
public class ExcelCellModel
{
    public int RowIndex { get; set; }
    public int ColumnIndex { get; set; }
    public string FormattedValue { get; set; } = string.Empty;

    public double WidthMillimeters { get; set; }
    public double HeightMillimeters { get; set; }

    public string FontFamily { get; set; } = "Arial";
    public double FontSizePoints { get; set; } = 10.0;
    public bool IsBold { get; set; }
    public bool IsItalic { get; set; }
    public bool IsUnderline { get; set; }

    public CellHorizontalAlignment HorizontalAlign { get; set; } = CellHorizontalAlignment.Left;
    public CellVerticalAlignment VerticalAlign { get; set; } = CellVerticalAlignment.Middle;

    public string? BackgroundColorHex { get; set; }
    public string? TextColorHex { get; set; }

    public CellBorders Borders { get; set; } = new();

    public bool IsMerged { get; set; }
    public bool IsMergeMaster { get; set; }
    public MergedCellRange? MergeRange { get; set; }
}
