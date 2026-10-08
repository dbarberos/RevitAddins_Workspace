using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using TablePlus.Services;

namespace TablePlus.Models;

/// <summary>
/// Observable item model representing an individual worksheet or page within a batch-imported file.
/// </summary>
public partial class TableBatchSheetItemModel : ObservableObject
{
    public TableBatchFileModel ParentFile { get; }

    [ObservableProperty]
    private bool _isSelected = true;

    [ObservableProperty]
    private bool _isRowSelected;

    [ObservableProperty]
    private string _sheetName = string.Empty;

    public const string SeparatorLine = "───";

    [ObservableProperty]
    private ObservableCollection<string> _availableRegions = new() { "Entire Worksheet" };

    [ObservableProperty]
    private string _selectedRegion = "Entire Worksheet";

    partial void OnSelectedRegionChanged(string value)
    {
        if (value is SeparatorLine or "---")
        {
            SelectedRegion = AvailableRegions.FirstOrDefault(r => r != SeparatorLine && r != "---") ?? "Entire Worksheet";
        }
        LoggerService.LogInfo($"[TableBatchSheetItemModel] Sheet '{SheetName}' Region changed to: '{SelectedRegion}'");
    }

    [ObservableProperty]
    private string _targetViewName = string.Empty;

    [ObservableProperty]
    private TargetViewType _selectedViewType = TargetViewType.DraftingView;

    [ObservableProperty]
    private int _selectedScale = 1;

    public bool IsViewTypeEnabled => SelectedImportType is TableImportType.Table or TableImportType.Image;

    public bool IsScaleEnabled => SelectedImportType is TableImportType.Table or TableImportType.Image;

    public string ScaleInputText
    {
        get => IsScaleEnabled ? SelectedScale.ToString() : "N/A";
        set
        {
            if (IsScaleEnabled && int.TryParse(value, out var parsed) && parsed > 0)
            {
                SelectedScale = parsed;
            }
            OnPropertyChanged(nameof(ScaleInputText));
        }
    }

    partial void OnSelectedScaleChanged(int value)
    {
        OnPropertyChanged(nameof(ScaleInputText));
        LoggerService.LogInfo($"[TableBatchSheetItemModel] Sheet '{SheetName}' Scale changed to: 1:{value}");
    }

    [ObservableProperty]
    private TableImportType _selectedImportType = TableImportType.Table;

    public string OriginHelpText => SelectedImportType switch
    {
        TableImportType.KeySchedule => "Key Schedule: Creates a native Revit ViewSchedule with database rows and a reusable parameter pool (TP_Column_XX). Allows multi-sheet splitting.",
        TableImportType.HeaderSchedule => "Header Grid: Creates a native Revit ViewSchedule using the freeform Header grid with ZERO project parameters. Supports merged cells; not split-paginable.",
        TableImportType.Table => "Vector Table: Creates 2D lines, text notes, and cell shading in a Legend or Drafting view. Exact Excel fidelity.",
        TableImportType.Image => "Raster Image: Inserts a high-resolution raster image of the sheet or document.",
        _ => string.Empty
    };

    partial void OnSelectedImportTypeChanged(TableImportType value)
    {
        if (value is TableImportType.KeySchedule or TableImportType.HeaderSchedule)
        {
            SelectedViewType = TargetViewType.ScheduleView;
        }
        else if (SelectedViewType == TargetViewType.ScheduleView)
        {
            SelectedViewType = TargetViewType.DraftingView;
        }

        OnPropertyChanged(nameof(IsViewTypeEnabled));
        OnPropertyChanged(nameof(IsScaleEnabled));
        OnPropertyChanged(nameof(ScaleInputText));
        OnPropertyChanged(nameof(OriginHelpText));
        LoggerService.LogInfo($"[TableBatchSheetItemModel] Sheet '{SheetName}' Origin (ImportType) changed to: {value}");
    }

    partial void OnSelectedViewTypeChanged(TargetViewType value)
    {
        OnPropertyChanged(nameof(IsScaleEnabled));
        OnPropertyChanged(nameof(ScaleInputText));
        LoggerService.LogInfo($"[TableBatchSheetItemModel] Sheet '{SheetName}' Type of view (TargetViewType) changed to: {value}");
    }

    public TableBatchSheetItemModel(TableBatchFileModel parentFile, string sheetName)
    {
        ParentFile = parentFile ?? throw new ArgumentNullException(nameof(parentFile));
        SheetName = sheetName;
        TargetViewName = $"{parentFile.FileNameWithoutExtension}_{sheetName}".Trim('_');

        // Defaults: Table, Drafting View, and 1 for table-compatible files; Image, Drafting View, and 1 for PDF.
        SelectedViewType = TargetViewType.DraftingView;
        SelectedScale = 1;
        SelectedImportType = parentFile.SourceType == TableSourceType.PdfDocument
            ? TableImportType.Image
            : TableImportType.Table;
    }

    partial void OnIsSelectedChanged(bool value)
    {
        LoggerService.LogInfo($"[TableBatchSheetItemModel] Sheet '{SheetName}' in '{ParentFile.FileName}' IsSelected changed to: {value}");
        ParentFile.OnChildSheetSelectionChanged();
    }
}
