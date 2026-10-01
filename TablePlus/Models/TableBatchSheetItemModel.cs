using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

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
    private string _sheetName = string.Empty;

    [ObservableProperty]
    private ObservableCollection<string> _availableRegions = new() { "Entire Worksheet" };

    [ObservableProperty]
    private string _selectedRegion = "Entire Worksheet";

    [ObservableProperty]
    private string _targetViewName = string.Empty;

    [ObservableProperty]
    private TargetViewType _selectedViewType = TargetViewType.DraftingView;

    [ObservableProperty]
    private int _selectedScale = 1;

    [ObservableProperty]
    private TableImportType _selectedImportType = TableImportType.Table;

    public TableBatchSheetItemModel(TableBatchFileModel parentFile, string sheetName)
    {
        ParentFile = parentFile ?? throw new ArgumentNullException(nameof(parentFile));
        SheetName = sheetName;
        TargetViewName = $"{parentFile.FileNameWithoutExtension}_{sheetName}".Trim('_');
    }

    partial void OnIsSelectedChanged(bool value)
    {
        ParentFile.OnChildSheetSelectionChanged();
    }
}
