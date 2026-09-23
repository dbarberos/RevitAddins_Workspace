namespace TablePlus.Models;

/// <summary>
/// Target Revit view type for table generation.
/// </summary>
public enum TargetViewType
{
    DraftingView,
    LegendView
}

/// <summary>
/// Horizontal alignment within an Excel cell.
/// </summary>
public enum CellHorizontalAlignment
{
    General,
    Left,
    Center,
    Right,
    Justify
}

/// <summary>
/// Vertical alignment within an Excel cell.
/// </summary>
public enum CellVerticalAlignment
{
    Top,
    Middle,
    Bottom
}

/// <summary>
/// Border line style for cell boundaries.
/// </summary>
public enum CellBorderStyle
{
    None,
    Thin,
    Medium,
    Thick,
    Double,
    Dashed,
    Dotted,
    Hair
}

/// <summary>
/// Selection scope within an Excel worksheet.
/// </summary>
public enum CellRangeSelectionMode
{
    EntireSheet,
    NamedRange,
    CustomRange
}
