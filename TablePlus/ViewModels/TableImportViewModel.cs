using System.Collections.ObjectModel;
using System.IO;
using System.Text.RegularExpressions;
using Autodesk.Revit.DB;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using TablePlus.Models;
using TablePlus.Services;

namespace TablePlus.ViewModels;

/// <summary>
/// Presentation logic for the TablePlus Excel Vector Import modal window.
/// Governs file selection, worksheet inspection, range configuration, view creation options,
/// and vector generation execution.
/// </summary>
public partial class TableImportViewModel : ObservableObject
{
    private static readonly Regex RangeRegex = new(
        @"^(?:[A-Za-z0-9_'\s]+!)?\$?[A-Za-z]+\$?[1-9][0-9]*(?::\$?[A-Za-z]+\$?[1-9][0-9]*)?$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    private readonly Document _doc;
    private readonly IExcelReaderService _excelReaderService;
    private readonly ITableGeometryService _geometryService;
    private readonly ISchemaService _schemaService;

    private ExcelWorkbookModel? _currentWorkbook;

    public TableImportViewModel(
        Document doc,
        IExcelReaderService excelReaderService,
        ITableGeometryService geometryService,
        ISchemaService schemaService)
    {
        _doc = doc ?? throw new ArgumentNullException(nameof(doc));
        _excelReaderService = excelReaderService ?? throw new ArgumentNullException(nameof(excelReaderService));
        _geometryService = geometryService ?? throw new ArgumentNullException(nameof(geometryService));
        _schemaService = schemaService ?? throw new ArgumentNullException(nameof(schemaService));

        AvailableScales = new ObservableCollection<int> { 1, 2, 5, 10, 20, 25, 50, 100, 200, 500 };
        SelectedScale = 1;
        CustomRangeText = "A1:G20";
        StatusMessage = "Select an Excel spreadsheet to begin.";
        UpdateCanImport();
    }

    #region Observable Properties - Source File

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CanImport))]
    private string _filePath = string.Empty;

    [ObservableProperty]
    private string _fileName = string.Empty;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CanImport))]
    private bool _isFileLoaded;

    #endregion

    #region Observable Properties - Worksheets & Range

    [ObservableProperty]
    private ObservableCollection<string> _worksheets = new();

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CanImport))]
    private string? _selectedWorksheet;

    [ObservableProperty]
    private CellRangeSelectionMode _rangeMode = CellRangeSelectionMode.EntireSheet;

    [ObservableProperty]
    private bool _isEntireSheet = true;

    [ObservableProperty]
    private bool _isNamedRange;

    [ObservableProperty]
    private bool _isCustomRange;

    [ObservableProperty]
    private ObservableCollection<string> _namedRanges = new();

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CanImport))]
    private string? _selectedNamedRange;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CanImport))]
    private string _customRangeText = string.Empty;

    [ObservableProperty]
    private string _usedRangePreview = string.Empty;

    #endregion

    #region Observable Properties - Target View Settings

    [ObservableProperty]
    private TargetViewType _targetViewType = TargetViewType.DraftingView;

    [ObservableProperty]
    private bool _isDraftingView = true;

    [ObservableProperty]
    private bool _isLegendView;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CanImport))]
    private string _viewName = string.Empty;

    [ObservableProperty]
    private int _selectedScale;

    [ObservableProperty]
    private ObservableCollection<int> _availableScales;

    [ObservableProperty]
    private bool _preserveBackgroundFills = true;

    [ObservableProperty]
    private bool _blackAndWhiteMode;

    #endregion

    #region Observable Properties - UI Execution & State

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CanImport))]
    private bool _isBusy;

    [ObservableProperty]
    private string _statusMessage = string.Empty;

    [ObservableProperty]
    private double _progressPercent;

    [ObservableProperty]
    private string? _errorMessage;

    [ObservableProperty]
    private bool _hasError;

    [ObservableProperty]
    private bool _canImport;

    /// <summary>
    /// Action invoked when the import process finishes or the user cancels, requesting the host window to close.
    /// </summary>
    public Action? RequestClose { get; set; }

    /// <summary>
    /// The generated Revit View upon successful import.
    /// </summary>
    public View? CreatedView { get; private set; }

    #endregion

    #region Property Change Callbacks

    partial void OnSelectedWorksheetChanged(string? value)
    {
        if (string.IsNullOrWhiteSpace(value) || _currentWorkbook == null)
        {
            NamedRanges.Clear();
            UsedRangePreview = string.Empty;
            UpdateCanImport();
            return;
        }

        var sheetInfo = _currentWorkbook.Sheets.FirstOrDefault(s =>
            s.Name.Equals(value, StringComparison.OrdinalIgnoreCase));

        NamedRanges.Clear();
        if (sheetInfo != null)
        {
            foreach (var nr in sheetInfo.NamedRanges)
            {
                NamedRanges.Add(nr);
            }

            UsedRangePreview = $"{sheetInfo.UsedRangeAddress} ({sheetInfo.RowCount} rows × {sheetInfo.ColumnCount} cols)";
        }
        else
        {
            UsedRangePreview = string.Empty;
        }

        if (NamedRanges.Count > 0)
        {
            SelectedNamedRange = NamedRanges[0];
        }

        // Auto-suggest unique view name if current is empty or auto-generated
        if (string.IsNullOrWhiteSpace(ViewName) || ViewName.StartsWith("Table - "))
        {
            ViewName = GetUniqueViewName($"Table - {value}");
        }

        UpdateCanImport();
    }

    partial void OnIsEntireSheetChanged(bool value)
    {
        if (value)
        {
            RangeMode = CellRangeSelectionMode.EntireSheet;
            IsNamedRange = false;
            IsCustomRange = false;
            UpdateCanImport();
        }
    }

    partial void OnIsNamedRangeChanged(bool value)
    {
        if (value)
        {
            RangeMode = CellRangeSelectionMode.NamedRange;
            IsEntireSheet = false;
            IsCustomRange = false;
            UpdateCanImport();
        }
    }

    partial void OnIsCustomRangeChanged(bool value)
    {
        if (value)
        {
            RangeMode = CellRangeSelectionMode.CustomRange;
            IsEntireSheet = false;
            IsNamedRange = false;
            UpdateCanImport();
        }
    }

    partial void OnIsDraftingViewChanged(bool value)
    {
        if (value)
        {
            TargetViewType = TargetViewType.DraftingView;
            IsLegendView = false;
        }
    }

    partial void OnIsLegendViewChanged(bool value)
    {
        if (value)
        {
            TargetViewType = TargetViewType.LegendView;
            IsDraftingView = false;
        }
    }

    partial void OnCustomRangeTextChanged(string value)
    {
        UpdateCanImport();
    }

    partial void OnViewNameChanged(string value)
    {
        UpdateCanImport();
    }

    #endregion

    #region Commands

    /// <summary>
    /// Launches the Windows file picker dialog allowing the user to select an Excel workbook.
    /// </summary>
    [RelayCommand]
    private async Task BrowseFileAsync()
    {
        var dialog = new OpenFileDialog
        {
            Title = "TablePlus — Select Source Spreadsheet",
            Filter = "Excel Workbooks (*.xlsx;*.xls;*.csv)|*.xlsx;*.xls;*.csv|All Files (*.*)|*.*",
            Multiselect = false,
            CheckFileExists = true
        };

        if (dialog.ShowDialog() == true)
        {
            await LoadFileAsync(dialog.FileName);
        }
    }

    /// <summary>
    /// Handles drag and drop file path input.
    /// </summary>
    public async Task HandleFileDropAsync(string droppedPath)
    {
        if (string.IsNullOrWhiteSpace(droppedPath)) return;

        var ext = Path.GetExtension(droppedPath).ToLowerInvariant();
        if (ext is ".xlsx" or ".xls" or ".csv")
        {
            await LoadFileAsync(droppedPath);
        }
        else
        {
            HasError = true;
            ErrorMessage = "Unsupported file type. Please select an Excel workbook (.xlsx, .xls) or CSV file.";
        }
    }

    /// <summary>
    /// Asynchronously inspects the Excel file structure and populates worksheets list.
    /// </summary>
    [RelayCommand]
    public async Task LoadFileAsync(string path)
    {
        if (string.IsNullOrWhiteSpace(path)) return;

        try
        {
            IsBusy = true;
            HasError = false;
            ErrorMessage = null;
            StatusMessage = "Reading workbook structure...";
            ProgressPercent = 25;

            var fullPath = Path.GetFullPath(path);
            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException($"The specified file does not exist: {fullPath}");
            }

            FilePath = fullPath;
            FileName = Path.GetFileName(fullPath);

            var workbookModel = await Task.Run(() => _excelReaderService.InspectWorkbook(fullPath));

            _currentWorkbook = workbookModel;
            Worksheets.Clear();

            foreach (var sheet in workbookModel.Sheets)
            {
                Worksheets.Add(sheet.Name);
            }

            if (Worksheets.Count > 0)
            {
                SelectedWorksheet = Worksheets[0];
            }

            IsFileLoaded = true;
            StatusMessage = $"Workbook loaded successfully: {workbookModel.Sheets.Count} sheet(s) found.";
            ProgressPercent = 100;
        }
        catch (IOException ioEx)
        {
            HasError = true;
            ErrorMessage = $"File access error: {ioEx.Message}. If open in Microsoft Excel, please save and close it first.";
            StatusMessage = "File loading failed.";
            IsFileLoaded = false;
        }
        catch (Exception ex)
        {
            HasError = true;
            ErrorMessage = $"Failed to parse Excel workbook: {ex.Message}";
            StatusMessage = "File loading failed.";
            IsFileLoaded = false;
        }
        finally
        {
            IsBusy = false;
            UpdateCanImport();
        }
    }

    /// <summary>
    /// Validates parameters, extracts cell data from Excel, and generates the native Revit vector table.
    /// </summary>
    [RelayCommand]
    private async Task ImportTableAsync()
    {
        if (!CanImport) return;

        try
        {
            IsBusy = true;
            HasError = false;
            ErrorMessage = null;
            StatusMessage = "Extracting cells and formatting...";
            ProgressPercent = 20;

            string? rangeAddress = null;
            if (IsCustomRange)
            {
                rangeAddress = CustomRangeText.Trim();
            }
            else if (IsNamedRange && !string.IsNullOrWhiteSpace(SelectedNamedRange))
            {
                rangeAddress = SelectedNamedRange!.Trim();
            }

            var sheetName = SelectedWorksheet!;
            var filePath = FilePath;

            // Extract cells asynchronously to prevent UI freeze
            var (cells, mergedRanges) = await Task.Run(() =>
            {
                var extractedCells = _excelReaderService.ExtractCells(filePath, sheetName, rangeAddress);
                var extractedMerges = _excelReaderService.ExtractMergedCells(filePath, sheetName);
                return (extractedCells, extractedMerges);
            });

            if (cells.Count == 0)
            {
                throw new InvalidOperationException("No populated cells or formatting found in the selected range.");
            }

            StatusMessage = $"Generating Revit vector table ({cells.Count} cells)...";
            ProgressPercent = 65;

            var config = new TableImportConfig
            {
                SourceFilePath = filePath,
                SelectedSheetName = sheetName,
                RangeMode = RangeMode,
                CustomRangeAddress = IsCustomRange ? rangeAddress : null,
                SelectedNamedRange = IsNamedRange ? SelectedNamedRange : null,
                TargetViewType = TargetViewType,
                ViewName = ViewName.Trim(),
                ViewScale = Math.Max(SelectedScale, 1),
                PreserveBackgroundFills = PreserveBackgroundFills,
                BlackAndWhiteMode = BlackAndWhiteMode
            };

            // Geometry generation operates in Revit external command context
            CreatedView = _geometryService.GenerateTable(_doc, config, cells, mergedRanges);

            StatusMessage = "Table created successfully!";
            ProgressPercent = 100;

            RequestClose?.Invoke();
        }
        catch (Exception ex)
        {
            HasError = true;
            ErrorMessage = $"Import failed: {ex.Message}";
            StatusMessage = "Table import encountered an error.";
        }
        finally
        {
            IsBusy = false;
            UpdateCanImport();
        }
    }

    /// <summary>
    /// Cancels the dialog and requests the host window to close without action.
    /// </summary>
    [RelayCommand]
    private void Cancel()
    {
        RequestClose?.Invoke();
    }

    #endregion

    #region Helper Methods

    private void UpdateCanImport()
    {
        if (IsBusy)
        {
            CanImport = false;
            return;
        }

        if (!IsFileLoaded || string.IsNullOrWhiteSpace(FilePath) || string.IsNullOrWhiteSpace(SelectedWorksheet))
        {
            CanImport = false;
            return;
        }

        if (string.IsNullOrWhiteSpace(ViewName))
        {
            CanImport = false;
            return;
        }

        if (IsCustomRange)
        {
            if (string.IsNullOrWhiteSpace(CustomRangeText) || !RangeRegex.IsMatch(CustomRangeText.Trim()))
            {
                CanImport = false;
                return;
            }
        }
        else if (IsNamedRange)
        {
            if (string.IsNullOrWhiteSpace(SelectedNamedRange))
            {
                CanImport = false;
                return;
            }
        }

        CanImport = true;
    }

    private string GetUniqueViewName(string baseName)
    {
        var existingNames = new FilteredElementCollector(_doc)
            .OfClass(typeof(View))
            .Cast<View>()
            .Select(v => v.Name)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        if (!existingNames.Contains(baseName))
        {
            return baseName;
        }

        int counter = 1;
        string candidate;
        do
        {
            candidate = $"{baseName} ({counter})";
            counter++;
        } while (existingNames.Contains(candidate));

        return candidate;
    }

    #endregion
}
