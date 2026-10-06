using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TablePlus.Models;

/// <summary>
/// Observable presentation item model representing a table view in the Master Dashboard DataGrid.
/// </summary>
public partial class TableItemModel : ObservableObject
{
    [ObservableProperty]
    private bool _isSelected;

    [ObservableProperty]
    private TableSourceType _sourceType = TableSourceType.ExcelXlsx;

    [ObservableProperty]
    private TableSyncStatus _status = TableSyncStatus.UpToDate;

    [ObservableProperty]
    private string _statusTooltip = "Table is synchronized with source file.";

    [ObservableProperty]
    private long _viewId;

    [ObservableProperty]
    private string _viewName = string.Empty;

    [ObservableProperty]
    private TargetViewType _viewType = TargetViewType.DraftingView;

    [ObservableProperty]
    private int _viewScale = 1;

    [ObservableProperty]
    private string _sourceFilePath = string.Empty;

    [ObservableProperty]
    private string _sourceFileName = string.Empty;

    [ObservableProperty]
    private string _selectedSheetName = string.Empty;

    [ObservableProperty]
    private string _cellRangeAddress = string.Empty;

    [ObservableProperty]
    private ObservableCollection<string> _availableSheets = new();

    [ObservableProperty]
    private ObservableCollection<string> _availableRegionModes = new() { "Entire Worksheet", "Named Range", "Custom Range" };

    [ObservableProperty]
    private string _selectedRegionMode = "Entire Worksheet";

    [ObservableProperty]
    private ObservableCollection<int> _availableScales = new() { 1, 2, 5, 10, 20, 25, 50, 100, 200, 500 };

    [ObservableProperty]
    private ObservableCollection<TargetViewType> _availableViewTypes = new()
    {
        TargetViewType.DraftingView,
        TargetViewType.LegendView,
        TargetViewType.ScheduleView
    };

    [ObservableProperty]
    private ObservableCollection<TableImportType> _availableImportTypes = new()
    {
        TableImportType.Table,
        TableImportType.KeySchedule,
        TableImportType.HeaderSchedule,
        TableImportType.Image
    };

    [ObservableProperty]
    private bool _isAutoSyncEnabled;

    [ObservableProperty]
    private bool _isBlackAndWhite;

    [ObservableProperty]
    private TableImportType _importType = TableImportType.Table;

    [ObservableProperty]
    private TableImportConfig _config = new();

    /// <summary>
    /// Badge text representing vector table (TBL), key schedule (KEY), header schedule (HDR) or raster image (IMG).
    /// </summary>
    public string ImportTypeBadge => ImportType switch
    {
        TableImportType.Image => "IMG",
        TableImportType.KeySchedule => "KEY",
        TableImportType.HeaderSchedule => "HDR",
        _ => "TBL"
    };

    /// <summary>
    /// Human-readable ratio string for display in the DataGrid (e.g. "1:1", "1:20").
    /// </summary>
    public string FormattedScale => $"1:{ViewScale}";

    partial void OnViewScaleChanged(int value)
    {
        OnPropertyChanged(nameof(FormattedScale));
    }

    /// <summary>
    /// Short badge label for source type icon fallback.
    /// </summary>
    public string SourceBadgeText => SourceType switch
    {
        TableSourceType.ExcelXlsx => "XLSX",
        TableSourceType.ExcelXlsm => "XLSM",
        TableSourceType.Csv => "CSV",
        TableSourceType.TextFile => "TXT",
        TableSourceType.PdfDocument => "PDF",
        TableSourceType.WordDocument => "DOC",
        TableSourceType.MarkdownDocument => "MD",
        _ => "TBL"
    };

    /// <summary>
    /// Status badge background hex color.
    /// </summary>
    public string StatusBadgeColorHex => Status switch
    {
        TableSyncStatus.UpToDate => "#107C41",      // Forest Green
        TableSyncStatus.Modified => "#D83B01",      // Warning Orange
        TableSyncStatus.FileNotFound => "#A80000",  // Alert Red
        _ => "#797775"                              // Neutral Grey
    };

    /// <summary>
    /// Status badge human-readable label.
    /// </summary>
    public string StatusLabel => Status switch
    {
        TableSyncStatus.UpToDate => "Up to Date",
        TableSyncStatus.Modified => "Modified",
        TableSyncStatus.FileNotFound => "Missing",
        _ => "Unlinked"
    };

    /// <summary>
    /// The Revit Sheet where this table view is placed (e.g. "A101 - Floor Plan"), or "Unplaced".
    /// </summary>
    [ObservableProperty]
    private string _sheetName = "Unplaced";

    /// <summary>
    /// Master grouping key for table explorer hierarchical display.
    /// </summary>
    public string GroupName => "All";

    /// <summary>
    /// Category / View classification name for hierarchical grouping.
    /// </summary>
    public string CategoryName => ViewType switch
    {
        TargetViewType.DraftingView => "Drafting Views",
        TargetViewType.LegendView => "Legends",
        TargetViewType.ScheduleView => "Schedules",
        _ => "Other Views"
    };

    /// <summary>
    /// Table / Source File Name for hierarchical grouping.
    /// </summary>
    public string TableName => !string.IsNullOrWhiteSpace(SourceFileName) && SourceFileName != "Unknown.xlsx"
        ? SourceFileName
        : (string.IsNullOrWhiteSpace(ViewName) ? "Unnamed Table" : ViewName);
}

