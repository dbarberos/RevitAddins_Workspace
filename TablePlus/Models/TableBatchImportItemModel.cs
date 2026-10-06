using System;
using System.Collections.ObjectModel;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TablePlus.Models;

/// <summary>
/// Observable item model representing an individual spreadsheet or document in the batch "Add Table" list.
/// Allows per-row configuration of worksheets, region ranges, target view types, view names, and scales.
/// </summary>
public partial class TableBatchImportItemModel : ObservableObject
{
    [ObservableProperty]
    private bool _isSelected = true;

    [ObservableProperty]
    private string _filePath = string.Empty;

    [ObservableProperty]
    private string _fileName = string.Empty;

    [ObservableProperty]
    private TableSourceType _sourceType = TableSourceType.ExcelXlsx;

    [ObservableProperty]
    private bool _isExcelSource = true;

    [ObservableProperty]
    private bool _isPagedDocument;

    [ObservableProperty]
    private ObservableCollection<string> _availableWorksheets = new();

    [ObservableProperty]
    private string _selectedWorksheet = string.Empty;

    [ObservableProperty]
    private ObservableCollection<string> _availableRegionModes = new() { "Entire Worksheet", "Named Range", "Custom Range" };

    [ObservableProperty]
    private string _selectedRegionMode = "Entire Worksheet";

    [ObservableProperty]
    private ObservableCollection<string> _availableNamedRanges = new();

    [ObservableProperty]
    private string? _selectedNamedRange;

    [ObservableProperty]
    private string _customRangeText = "A1:G20";

    [ObservableProperty]
    private ObservableCollection<TargetViewType> _availableViewTypes = new() 
    { 
        TargetViewType.DraftingView, 
        TargetViewType.LegendView, 
        TargetViewType.ScheduleView 
    };

    [ObservableProperty]
    private TargetViewType _selectedViewType = TargetViewType.DraftingView;

    [ObservableProperty]
    private string _targetViewName = string.Empty;

    [ObservableProperty]
    private ObservableCollection<int> _availableScales = new() { 1, 2, 5, 10, 20, 25, 50, 100, 200, 500 };

    [ObservableProperty]
    private int _selectedScale = 1;

    [ObservableProperty]
    private ObservableCollection<TableImportType> _availableImportTypes = new()
    {
        TableImportType.Table,
        TableImportType.KeySchedule,
        TableImportType.HeaderSchedule,
        TableImportType.Image
    };

    [ObservableProperty]
    private TableImportType _selectedImportType = TableImportType.Table;

    [ObservableProperty]
    private int _dpiResolution = 300;

    [ObservableProperty]
    private TablePageOption _pageOption = TablePageOption.AllPages;

    [ObservableProperty]
    private string _selectedPages = "1";

    [ObservableProperty]
    private bool _isRelativePath;

    public bool IsNamedRange => SelectedRegionMode == "Named Range";
    public bool IsCustomRange => SelectedRegionMode == "Custom Range";

    partial void OnSelectedRegionModeChanged(string value)
    {
        OnPropertyChanged(nameof(IsNamedRange));
        OnPropertyChanged(nameof(IsCustomRange));
    }

    partial void OnSelectedWorksheetChanged(string value)
    {
        if (!string.IsNullOrWhiteSpace(value) && (string.IsNullOrWhiteSpace(TargetViewName) || TargetViewName.StartsWith("Table_") || TargetViewName == Path.GetFileNameWithoutExtension(FilePath)))
        {
            var baseName = Path.GetFileNameWithoutExtension(FilePath);
            TargetViewName = $"{baseName}_{value}".Trim('_');
        }
    }
}
