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
    }

    [ObservableProperty]
    private string _targetViewName = string.Empty;

    [ObservableProperty]
    private TargetViewType _selectedViewType = TargetViewType.LegendView;

    [ObservableProperty]
    private int _selectedScale = 1;

    public string ScaleInputText
    {
        get => SelectedScale.ToString();
        set
        {
            if (int.TryParse(value, out var parsed) && parsed > 0)
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

    partial void OnSelectedImportTypeChanged(TableImportType value)
    {
        LoggerService.LogInfo($"[TableBatchSheetItemModel] Sheet '{SheetName}' Origin (ImportType) changed to: {value}");
    }

    partial void OnSelectedViewTypeChanged(TargetViewType value)
    {
        LoggerService.LogInfo($"[TableBatchSheetItemModel] Sheet '{SheetName}' Type of view (TargetViewType) changed to: {value}");
    }

    public TableBatchSheetItemModel(TableBatchFileModel parentFile, string sheetName)
    {
        ParentFile = parentFile ?? throw new ArgumentNullException(nameof(parentFile));
        SheetName = sheetName;
        TargetViewName = $"{parentFile.FileNameWithoutExtension}_{sheetName}".Trim('_');

        // Defaults: Table, Legend View, and 1 for table-compatible files; Image, Legend View, and 1 for PDF.
        SelectedViewType = TargetViewType.LegendView;
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
