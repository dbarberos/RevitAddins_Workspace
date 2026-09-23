namespace TablePlus.Models;

/// <summary>
/// User configuration parameters for executing a table import into Revit.
/// </summary>
public class TableImportConfig
{
    public string SourceFilePath { get; set; } = string.Empty;
    public string SelectedSheetName { get; set; } = string.Empty;

    public CellRangeSelectionMode RangeMode { get; set; } = CellRangeSelectionMode.EntireSheet;
    public string? CustomRangeAddress { get; set; }
    public string? SelectedNamedRange { get; set; }

    public TargetViewType TargetViewType { get; set; } = TargetViewType.DraftingView;
    public string ViewName { get; set; } = string.Empty;
    public int ViewScale { get; set; } = 1;

    public bool PreserveBackgroundFills { get; set; } = true;
    public bool BlackAndWhiteMode { get; set; } = false;

    public string FallbackFontFamily { get; set; } = "Arial";
    public double DefaultFontSizePoints { get; set; } = 8.0;

    /// <summary>
    /// UTC timestamp of when the table was imported or last synchronized.
    /// </summary>
    public string? LastImportedTimestampUtc { get; set; }

    // Spec 002 additions:
    public bool IsAutoSyncEnabled { get; set; } = false;
    public TableSourceType SourceType { get; set; } = TableSourceType.ExcelXlsx;
    public string? GridLineStyleName { get; set; }
    public string? BodyTextNoteTypeName { get; set; }

    // Header Row Styling Overrides
    public bool HeaderCustomStyleEnabled { get; set; } = false;
    public string? HeaderTextNoteTypeName { get; set; }
    public string? HeaderTextColorHex { get; set; }
    public string? HeaderFillColorHex { get; set; }
}
