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
    private bool _isAutoSyncEnabled;

    [ObservableProperty]
    private bool _isBlackAndWhite;

    [ObservableProperty]
    private TableImportConfig _config = new();

    /// <summary>
    /// Human-readable ratio string for display in the DataGrid (e.g. "1:1", "1:20").
    /// </summary>
    public string FormattedScale => $"1:{ViewScale}";

    /// <summary>
    /// Short badge label for source type icon fallback.
    /// </summary>
    public string SourceBadgeText => SourceType switch
    {
        TableSourceType.ExcelXlsx => "XLSX",
        TableSourceType.ExcelXlsm => "XLSM",
        TableSourceType.Csv => "CSV",
        TableSourceType.PdfDocument => "PDF",
        TableSourceType.WordDocument => "DOC",
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
}
