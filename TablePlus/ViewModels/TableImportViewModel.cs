using System.Collections.ObjectModel;
using System.IO;
using System.Text.RegularExpressions;
using Autodesk.Revit.DB;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using TablePlus.Models;
using TablePlus.Services;
using TablePlus.Views;

namespace TablePlus.ViewModels;

public class TableSourceOption
{
    public string DisplayName { get; set; } = string.Empty;
    public TableSourceItemModel? SourceModel { get; set; }
    public bool IsLocalDisk => SourceModel == null;
    public override string ToString() => DisplayName;
}

public class CloudSpreadsheetItem
{
    public string Name { get; set; } = string.Empty;
    public string KeyOrPath { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
    public override string ToString() => Name;
}

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

        AvailableImportTypes = new ObservableCollection<TableImportType> { TableImportType.Table, TableImportType.Image };
        SelectedImportType = TableImportType.Table;

        AvailableDpiValues = new ObservableCollection<int> { 72, 96, 150, 300, 600 };
        SelectedDpi = 300;

        AvailablePageOptions = new ObservableCollection<TablePageOption> { TablePageOption.AllPages, TablePageOption.SelectPages };
        SelectedPageOption = TablePageOption.AllPages;
        SelectedPages = "1";

        AvailableViewTypes = new ObservableCollection<TargetViewType> { TargetViewType.DraftingView, TargetViewType.LegendView, TargetViewType.ScheduleView };
        SelectedViewType = TargetViewType.DraftingView;

        AvailableRegionModes = new ObservableCollection<string> { "Entire Worksheet", "Named Range", "Custom Range" };
        SelectedRegionMode = "Entire Worksheet";

        NumberOfCopies = 1;
        CustomRangeText = "A1:G20";
        StatusMessage = "Select an Excel spreadsheet or document to begin.";

        InitializeSources();
        UpdateCanImport();
    }

    #region Observable Properties - Configured External Sources

    [ObservableProperty]
    private ObservableCollection<TableSourceOption> _sourceOptions = new();

    [ObservableProperty]
    private TableSourceOption? _selectedSourceOption;

    [ObservableProperty]
    private ObservableCollection<CloudSpreadsheetItem> _availableSpreadsheets = new();

    [ObservableProperty]
    private CloudSpreadsheetItem? _selectedSpreadsheetItem;

    [ObservableProperty]
    private bool _hasSourceFiles;

    [ObservableProperty]
    private bool _isCloudSource;

    #endregion

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

    #region Observable Properties - DiRoots Form Controls & Options

    [ObservableProperty]
    private TableImportType _selectedImportType = TableImportType.Table;

    [ObservableProperty]
    private ObservableCollection<TableImportType> _availableImportTypes = new();

    [ObservableProperty]
    private int _selectedDpi = 300;

    [ObservableProperty]
    private ObservableCollection<int> _availableDpiValues = new();

    [ObservableProperty]
    private TablePageOption _selectedPageOption = TablePageOption.AllPages;

    [ObservableProperty]
    private ObservableCollection<TablePageOption> _availablePageOptions = new();

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CanImport))]
    private string _selectedPages = "1";

    [ObservableProperty]
    private TargetViewType _selectedViewType = TargetViewType.DraftingView;

    [ObservableProperty]
    private ObservableCollection<TargetViewType> _availableViewTypes = new();

    [ObservableProperty]
    private ObservableCollection<string> _availableRegionModes = new();

    [ObservableProperty]
    private string _selectedRegionMode = "Entire Worksheet";

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CanImport))]
    private int _numberOfCopies = 1;

    [ObservableProperty]
    private bool _isExcelSource = true;

    [ObservableProperty]
    private bool _isPagedDocument;

    [ObservableProperty]
    private bool _isImageImport;

    [ObservableProperty]
    private bool _isScaleEnabled = true;

    [ObservableProperty]
    private bool _isPageSelectionCustom;

    [ObservableProperty]
    private bool _isAutoSyncEnabled;

    [ObservableProperty]
    private List<string> _selectedFilePaths = new();

    [ObservableProperty]
    private bool _isRelativePath;

    [ObservableProperty]
    private ObservableCollection<TableBatchImportItemModel> _batchItems = new();

    [ObservableProperty]
    private TableBatchImportItemModel? _selectedBatchItem;

    [ObservableProperty]
    private TargetViewType _batchTargetViewType = TargetViewType.DraftingView;

    [ObservableProperty]
    private int _batchScale = 1;

    [ObservableProperty]
    private string _batchSearchFilter = string.Empty;

    public int SelectedBatchCount => BatchItems.Count(i => i.IsSelected);
    public bool CanImportBatch => SelectedBatchCount > 0 && !IsBusy;

    /// <summary>
    /// Collection of all generated views (when NumberOfCopies >= 1).
    /// </summary>
    public List<View> CreatedViews { get; } = new();

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

    partial void OnSelectedImportTypeChanged(TableImportType value)
    {
        IsImageImport = value == TableImportType.Image;
        UpdateCanImport();
    }

    partial void OnSelectedPageOptionChanged(TablePageOption value)
    {
        IsPageSelectionCustom = value == TablePageOption.SelectPages;
        UpdateCanImport();
    }

    partial void OnSelectedPagesChanged(string value)
    {
        UpdateCanImport();
    }

    partial void OnSelectedViewTypeChanged(TargetViewType value)
    {
        TargetViewType = value;
        IsDraftingView = value == TargetViewType.DraftingView;
        IsLegendView = value == TargetViewType.LegendView;
        IsScaleEnabled = value != TargetViewType.ScheduleView;
        UpdateCanImport();
    }

    partial void OnSelectedRegionModeChanged(string value)
    {
        if (value == "Entire Worksheet")
        {
            RangeMode = CellRangeSelectionMode.EntireSheet;
            IsEntireSheet = true;
            IsNamedRange = false;
            IsCustomRange = false;
        }
        else if (value == "Named Range")
        {
            RangeMode = CellRangeSelectionMode.NamedRange;
            IsEntireSheet = false;
            IsNamedRange = true;
            IsCustomRange = false;
        }
        else if (value == "Custom Range")
        {
            RangeMode = CellRangeSelectionMode.CustomRange;
            IsEntireSheet = false;
            IsNamedRange = false;
            IsCustomRange = true;
        }
        UpdateCanImport();
    }

    partial void OnNumberOfCopiesChanged(int value)
    {
        if (value < 1) NumberOfCopies = 1;
        else if (value > 50) NumberOfCopies = 50;
        UpdateCanImport();
    }

    #endregion

    #region Source Management Logic

    private void InitializeSources()
    {
        SourceOptions.Clear();
        SourceOptions.Add(new TableSourceOption
        {
            DisplayName = "💻 Local Disk / File Explorer (Custom)",
            SourceModel = null
        });

        try
        {
            var savedSources = TableSourceConfigService.LoadSources().Where(s => s.IsActive).ToList();
            foreach (var src in savedSources)
            {
                string icon = src.SourceType switch
                {
                    ExternalTableSourceType.Directory => "📁",
                    ExternalTableSourceType.AutodeskDocs => "☁️ ACC:",
                    ExternalTableSourceType.AzureStorage => "☁️ Azure:",
                    ExternalTableSourceType.AwsS3 => "☁️ AWS S3:",
                    _ => "📄"
                };

                SourceOptions.Add(new TableSourceOption
                {
                    DisplayName = $"{icon} {src.Name} ({src.SourceDescription})",
                    SourceModel = src
                });
            }
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("Error loading active table sources into TableImportViewModel", ex);
        }

        SelectedSourceOption = SourceOptions.FirstOrDefault();
    }

    partial void OnSelectedSourceOptionChanged(TableSourceOption? value)
    {
        AvailableSpreadsheets.Clear();
        SelectedSpreadsheetItem = null;

        if (value == null || value.IsLocalDisk)
        {
            HasSourceFiles = false;
            IsCloudSource = false;
            return;
        }

        var model = value.SourceModel;
        if (model == null) return;

        if (model.SourceType == ExternalTableSourceType.Directory)
        {
            IsCloudSource = false;
            if (!string.IsNullOrWhiteSpace(model.Path) && Directory.Exists(model.Path))
            {
                try
                {
                    var files = Directory.GetFiles(model.Path, "*.*", SearchOption.TopDirectoryOnly)
                        .Where(f =>
                        {
                            var ext = Path.GetExtension(f).ToLowerInvariant();
                            return ext is ".xlsx" or ".xlsm" or ".xls" or ".csv" or ".txt" or ".tsv" or ".tab" or ".prn" or ".dat" or ".log" or ".asc" or ".pdf" or ".docx" or ".doc" or ".rtf" or ".md" or ".markdown";
                        })
                        .OrderBy(Path.GetFileName);

                    foreach (var file in files)
                    {
                        var fi = new FileInfo(file);
                        AvailableSpreadsheets.Add(new CloudSpreadsheetItem
                        {
                            Name = Path.GetFileName(file),
                            KeyOrPath = file,
                            Details = $"{fi.Length / 1024.0:F1} KB"
                        });
                    }
                }
                catch (Exception ex)
                {
                    TelemetryLogger.LogError($"Error enumerating directory '{model.Path}'", ex);
                }
            }

            HasSourceFiles = AvailableSpreadsheets.Count > 0;
            if (HasSourceFiles)
            {
                SelectedSpreadsheetItem = AvailableSpreadsheets[0];
            }
        }
        else
        {
            // Cloud Source (Azure, AWS S3, ACC)
            IsCloudSource = true;
            HasSourceFiles = false;
            _ = FetchCloudFilesAsync();
        }
    }

    [RelayCommand]
    public async Task FetchCloudFilesAsync()
    {
        var model = SelectedSourceOption?.SourceModel;
        if (model == null || SelectedSourceOption?.IsLocalDisk == true) return;

        try
        {
            IsBusy = true;
            StatusMessage = $"Fetching spreadsheets from {model.Name}...";
            AvailableSpreadsheets.Clear();
            SelectedSpreadsheetItem = null;

            if (model.SourceType == ExternalTableSourceType.AzureStorage)
            {
                var blobs = await AzureStorageService.GetAvailableSpreadsheetsAsync(model.ConnectionString, model.ContainerName, model.RootPath);
                foreach (var blob in blobs)
                {
                    AvailableSpreadsheets.Add(new CloudSpreadsheetItem
                    {
                        Name = blob.FileName + "." + blob.Extension,
                        KeyOrPath = blob.BlobName,
                        Details = blob.FormattedSize
                    });
                }
            }
            else if (model.SourceType == ExternalTableSourceType.AwsS3)
            {
                var s3Objs = await AwsS3StorageService.GetAvailableSpreadsheetsAsync(model);
                foreach (var obj in s3Objs)
                {
                    AvailableSpreadsheets.Add(new CloudSpreadsheetItem
                    {
                        Name = obj.FileName + "." + obj.Extension,
                        KeyOrPath = obj.ObjectKey,
                        Details = obj.FormattedSize
                    });
                }
            }
            else if (model.SourceType == ExternalTableSourceType.AutodeskDocs)
            {
                if (!string.IsNullOrWhiteSpace(model.AccessToken) && !string.IsNullOrWhiteSpace(model.ProjectId) && !string.IsNullOrWhiteSpace(model.FolderId))
                {
                    var (_, items) = await AutodeskDocsService.GetFolderSpreadsheetContentsAsync(model.AccessToken, model.ProjectId, model.FolderId);
                    foreach (var item in items)
                    {
                        AvailableSpreadsheets.Add(new CloudSpreadsheetItem
                        {
                            Name = item.DisplayName,
                            KeyOrPath = item.Id,
                            Details = $"{item.ContentLength / 1024.0:F1} KB"
                        });
                    }
                }
            }

            HasSourceFiles = AvailableSpreadsheets.Count > 0;
            if (HasSourceFiles)
            {
                SelectedSpreadsheetItem = AvailableSpreadsheets[0];
                StatusMessage = $"Loaded {AvailableSpreadsheets.Count} spreadsheet(s) from {model.Name}.";
            }
            else
            {
                StatusMessage = $"No spreadsheets found in {model.Name}.";
            }
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error fetching cloud files from '{model.Name}'", ex);
            HasError = true;
            ErrorMessage = $"Failed to fetch files from cloud source: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    public async Task LoadSelectedSourceFileAsync()
    {
        if (SelectedSpreadsheetItem == null) return;
        var model = SelectedSourceOption?.SourceModel;

        try
        {
            if (model == null || model.SourceType == ExternalTableSourceType.Directory)
            {
                await LoadFileAsync(SelectedSpreadsheetItem.KeyOrPath);
                return;
            }

            IsBusy = true;
            StatusMessage = $"Downloading {SelectedSpreadsheetItem.Name}...";

            string localPath = string.Empty;
            if (model.SourceType == ExternalTableSourceType.AzureStorage)
            {
                localPath = await AzureStorageService.DownloadSpreadsheetBlobAsync(model.ConnectionString, model.ContainerName, SelectedSpreadsheetItem.KeyOrPath);
            }
            else if (model.SourceType == ExternalTableSourceType.AwsS3)
            {
                localPath = await AwsS3StorageService.DownloadSpreadsheetAsync(model, SelectedSpreadsheetItem.KeyOrPath);
            }
            else if (model.SourceType == ExternalTableSourceType.AutodeskDocs)
            {
                string? downloadUrl = await AutodeskDocsService.GetLatestVersionDownloadUrlAsync(model.AccessToken, model.ProjectId, SelectedSpreadsheetItem.KeyOrPath);
                if (string.IsNullOrWhiteSpace(downloadUrl))
                {
                    throw new InvalidOperationException($"Could not get download URL for {SelectedSpreadsheetItem.Name} from Autodesk Docs.");
                }
                localPath = await AutodeskDocsService.DownloadAccSpreadsheetAsync(model.AccessToken, downloadUrl!, SelectedSpreadsheetItem.Name);
            }

            if (!string.IsNullOrWhiteSpace(localPath))
            {
                await LoadFileAsync(localPath);
            }
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error loading selected source spreadsheet '{SelectedSpreadsheetItem.Name}'", ex);
            HasError = true;
            ErrorMessage = $"Failed to load source file: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
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
            Title = "TablePlus — Select Source Spreadsheet or Document",
            Filter = "All Supported Tables (*.xlsx;*.xls;*.csv;*.xlsm;*.txt;*.tsv;*.tab;*.prn;*.pdf;*.docx;*.doc;*.rtf;*.md;*.markdown)|*.xlsx;*.xls;*.csv;*.xlsm;*.txt;*.tsv;*.tab;*.prn;*.pdf;*.docx;*.doc;*.rtf;*.md;*.markdown|Excel Workbooks (*.xlsx;*.xls;*.xlsm;*.xltx;*.xltm)|*.xlsx;*.xls;*.xlsm;*.xltx;*.xltm|Markdown Files (*.md;*.markdown)|*.md;*.markdown|Word & RTF Documents (*.docx;*.doc;*.rtf)|*.docx;*.doc;*.rtf|PDF Documents (*.pdf)|*.pdf|Text & Delimited Files (*.txt;*.csv;*.tsv;*.tab;*.prn;*.dat;*.log;*.asc)|*.txt;*.csv;*.tsv;*.tab;*.prn;*.dat;*.log;*.asc|All Files (*.*)|*.*",
            Multiselect = false,
            CheckFileExists = true
        };

        if (SelectedSourceOption?.SourceModel?.SourceType == ExternalTableSourceType.Directory &&
            !string.IsNullOrWhiteSpace(SelectedSourceOption.SourceModel.Path) &&
            Directory.Exists(SelectedSourceOption.SourceModel.Path))
        {
            dialog.InitialDirectory = SelectedSourceOption.SourceModel.Path;
        }

        if (dialog.ShowDialog() == true)
        {
            await LoadFileAsync(dialog.FileName);
        }
    }

    /// <summary>
    /// Handles drag and drop file path input.
    /// </summary>
    public async Task HandleFileDropAsync(string? droppedPath)
    {
        if (string.IsNullOrWhiteSpace(droppedPath)) return;

        var ext = Path.GetExtension(droppedPath).ToLowerInvariant();
        if (ext is ".xlsx" or ".xls" or ".csv" or ".xlsm" or ".xltx" or ".xltm" or ".txt" or ".tsv" or ".tab" or ".prn" or ".dat" or ".log" or ".asc" or ".pdf" or ".docx" or ".doc" or ".rtf" or ".md" or ".markdown")
        {
            await LoadFileAsync(droppedPath!);
        }
        else
        {
            HasError = true;
            ErrorMessage = "Unsupported file type. Please select an Excel workbook (.xlsx, .xls, .xlsm), Word document (.docx, .doc, .rtf), Markdown file (.md), PDF (.pdf), or Text file (.txt, .csv, .tsv).";
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

            var ext = Path.GetExtension(fullPath).ToLowerInvariant();
            IsExcelSource = ext is ".xlsx" or ".xls" or ".xlsm";
            IsPagedDocument = ext is ".docx" or ".doc" or ".rtf" or ".pdf" or ".md" or ".markdown";

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

            var sheetName = SelectedWorksheet ?? (Worksheets.Count > 0 ? Worksheets[0] : "Sheet1");
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

            // Infer source type from extension
            var ext = Path.GetExtension(filePath).ToLowerInvariant();
            var inferredSourceType = ext switch
            {
                ".xlsm" => TableSourceType.ExcelXlsm,
                ".csv" => TableSourceType.Csv,
                ".txt" or ".tsv" or ".tab" or ".prn" or ".dat" or ".log" or ".asc" => TableSourceType.TextFile,
                ".pdf" => TableSourceType.PdfDocument,
                ".docx" or ".doc" or ".rtf" => TableSourceType.WordDocument,
                ".md" or ".markdown" => TableSourceType.MarkdownDocument,
                _ => TableSourceType.ExcelXlsx
            };

            CreatedViews.Clear();
            int totalCopies = Math.Clamp(NumberOfCopies, 1, 50);

            for (int i = 1; i <= totalCopies; i++)
            {
                string targetName;
                if (totalCopies > 1)
                {
                    targetName = GetUniqueViewName($"{ViewName.Trim()} {i:D3}");
                }
                else
                {
                    targetName = ViewName.Trim();
                }

                var config = new TableImportConfig
                {
                    SourceFilePath = filePath,
                    SelectedSheetName = sheetName,
                    RangeMode = RangeMode,
                    CustomRangeAddress = IsCustomRange ? rangeAddress : null,
                    SelectedNamedRange = IsNamedRange ? SelectedNamedRange : null,
                    TargetViewType = SelectedViewType,
                    ViewName = targetName,
                    ViewScale = Math.Max(SelectedScale, 1),
                    PreserveBackgroundFills = PreserveBackgroundFills,
                    BlackAndWhiteMode = BlackAndWhiteMode,
                    SourceType = inferredSourceType,
                    ImportType = SelectedImportType,
                    DpiResolution = SelectedDpi,
                    PageOption = SelectedPageOption,
                    SelectedPages = SelectedPages,
                    NumberOfCopies = totalCopies,
                    IsAutoSyncEnabled = IsAutoSyncEnabled
                };

                // Geometry generation operates in Revit external command context
                var v = _geometryService.GenerateTable(_doc, config, cells, mergedRanges);
                if (v != null)
                {
                    CreatedViews.Add(v);
                    CreatedView = v;
                }
            }

            StatusMessage = totalCopies > 1
                ? $"{totalCopies} tables created successfully!"
                : "Table created successfully!";
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

    public async Task InitializeBatchFilesAsync(IEnumerable<string> filePaths, bool isRelative = false, bool append = false)
    {
        if (!append)
        {
            BatchItems.Clear();
        }

        foreach (var path in filePaths)
        {
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path)) continue;

            var ext = Path.GetExtension(path).ToLowerInvariant();
            var fileName = Path.GetFileName(path);
            var baseName = Path.GetFileNameWithoutExtension(path);

            var item = new TableBatchImportItemModel
            {
                FilePath = path,
                FileName = fileName,
                IsRelativePath = isRelative,
                TargetViewName = baseName
            };

            if (ext is ".xlsx" or ".xls" or ".xlsm")
            {
                item.SourceType = ext == ".xlsm" ? TableSourceType.ExcelXlsm : TableSourceType.ExcelXlsx;
                item.IsExcelSource = true;
                item.IsPagedDocument = false;

                try
                {
                    var wb = await Task.Run(() => _excelReaderService.InspectWorkbook(path));
                    foreach (var s in wb.Sheets)
                    {
                        item.AvailableWorksheets.Add(s.Name);
                        foreach (var nr in s.NamedRanges)
                        {
                            if (!item.AvailableNamedRanges.Contains(nr))
                                item.AvailableNamedRanges.Add(nr);
                        }
                    }

                    if (item.AvailableWorksheets.Count > 0)
                    {
                        item.SelectedWorksheet = item.AvailableWorksheets[0];
                        item.TargetViewName = $"{baseName}_{item.SelectedWorksheet}".Trim('_');
                    }
                }
                catch (Exception ex)
                {
                    TelemetryLogger.LogError($"Error inspecting workbook '{path}'", ex);
                    item.AvailableWorksheets.Add("Sheet1");
                    item.SelectedWorksheet = "Sheet1";
                }
            }
            else if (ext is ".csv" or ".tsv" or ".txt" or ".tab" or ".prn" or ".dat" or ".log" or ".asc")
            {
                item.SourceType = ext == ".csv" ? TableSourceType.Csv : TableSourceType.TextFile;
                item.IsExcelSource = true;
                item.IsPagedDocument = false;
                item.AvailableWorksheets.Add(baseName);
                item.SelectedWorksheet = baseName;
                item.TargetViewName = baseName;
            }
            else
            {
                // Word, PDF, Markdown
                item.SourceType = ext switch
                {
                    ".pdf" => TableSourceType.PdfDocument,
                    ".md" or ".markdown" => TableSourceType.MarkdownDocument,
                    _ => TableSourceType.WordDocument
                };
                item.IsExcelSource = false;
                item.IsPagedDocument = true;
                item.AvailableWorksheets.Add(baseName);
                item.SelectedWorksheet = baseName;
                item.TargetViewName = baseName;
            }

            item.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(TableBatchImportItemModel.IsSelected))
                {
                    OnPropertyChanged(nameof(SelectedBatchCount));
                    OnPropertyChanged(nameof(CanImportBatch));
                }
            };

            BatchItems.Add(item);
        }

        if (BatchItems.Count > 0 && SelectedBatchItem == null)
        {
            SelectedBatchItem = BatchItems[0];
        }

        OnPropertyChanged(nameof(SelectedBatchCount));
        OnPropertyChanged(nameof(CanImportBatch));
    }

    [ObservableProperty]
    private ObservableCollection<string> _batchSelectionOptions = new() { "Select All", "Deselect All", "Invert Selection" };

    [ObservableProperty]
    private string? _selectedBatchSelectionOption;

    public void ExecuteSelectionOption(string option)
    {
        switch (option)
        {
            case "Select All":
                SelectAllBatch();
                break;
            case "Deselect All":
                DeselectAllBatch();
                break;
            case "Invert Selection":
                InvertBatchSelection();
                break;
        }
    }

    [RelayCommand]
    public void SelectAllBatch()
    {
        foreach (var item in BatchItems) item.IsSelected = true;
        OnPropertyChanged(nameof(SelectedBatchCount));
        OnPropertyChanged(nameof(CanImportBatch));
    }

    [RelayCommand]
    public void DeselectAllBatch()
    {
        foreach (var item in BatchItems) item.IsSelected = false;
        OnPropertyChanged(nameof(SelectedBatchCount));
        OnPropertyChanged(nameof(CanImportBatch));
    }

    [RelayCommand]
    public void InvertBatchSelection()
    {
        foreach (var item in BatchItems) item.IsSelected = !item.IsSelected;
        OnPropertyChanged(nameof(SelectedBatchCount));
        OnPropertyChanged(nameof(CanImportBatch));
    }

    [RelayCommand]
    public void RemoveSelectedBatch()
    {
        var toRemove = BatchItems.Where(i => i.IsSelected).ToList();
        foreach (var item in toRemove)
        {
            BatchItems.Remove(item);
        }
        OnPropertyChanged(nameof(SelectedBatchCount));
        OnPropertyChanged(nameof(CanImportBatch));
    }

    [RelayCommand]
    public async Task AddMoreFilesAsync(System.Windows.Window? ownerWindow)
    {
        var sourcePickerVm = new TableSourceSelectionViewModel();
        var sourcePickerView = new TableSourceSelectionView(sourcePickerVm);

        if (ownerWindow != null)
        {
            sourcePickerView.Owner = ownerWindow;
        }

        var result = sourcePickerView.ShowDialog();
        if (result == true && sourcePickerVm.ResultFilePaths.Count > 0)
        {
            await InitializeBatchFilesAsync(sourcePickerVm.ResultFilePaths, sourcePickerVm.IsRelativePath, append: true);
        }
    }

    [RelayCommand]
    public void DuplicateRow(TableBatchImportItemModel? targetItem = null)
    {
        var item = targetItem ?? SelectedBatchItem;
        if (item == null) return;

        var copy = new TableBatchImportItemModel
        {
            FilePath = item.FilePath,
            FileName = item.FileName,
            SourceType = item.SourceType,
            IsExcelSource = item.IsExcelSource,
            IsPagedDocument = item.IsPagedDocument,
            SelectedRegionMode = item.SelectedRegionMode,
            CustomRangeText = item.CustomRangeText,
            SelectedViewType = item.SelectedViewType,
            SelectedScale = item.SelectedScale,
            SelectedImportType = item.SelectedImportType,
            DpiResolution = item.DpiResolution,
            PageOption = item.PageOption,
            SelectedPages = item.SelectedPages,
            IsRelativePath = item.IsRelativePath
        };

        foreach (var ws in item.AvailableWorksheets)
        {
            copy.AvailableWorksheets.Add(ws);
        }

        foreach (var nr in item.AvailableNamedRanges)
        {
            copy.AvailableNamedRanges.Add(nr);
        }

        var currentIndex = item.AvailableWorksheets.IndexOf(item.SelectedWorksheet);
        if (currentIndex >= 0 && currentIndex + 1 < item.AvailableWorksheets.Count)
        {
            copy.SelectedWorksheet = item.AvailableWorksheets[currentIndex + 1];
        }
        else
        {
            copy.SelectedWorksheet = item.SelectedWorksheet;
        }

        var baseName = Path.GetFileNameWithoutExtension(item.FilePath);
        copy.TargetViewName = $"{baseName}_{copy.SelectedWorksheet}".Trim('_');

        copy.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName == nameof(TableBatchImportItemModel.IsSelected))
            {
                OnPropertyChanged(nameof(SelectedBatchCount));
                OnPropertyChanged(nameof(CanImportBatch));
            }
        };

        var index = BatchItems.IndexOf(item);
        if (index >= 0)
        {
            BatchItems.Insert(index + 1, copy);
        }
        else
        {
            BatchItems.Add(copy);
        }

        OnPropertyChanged(nameof(SelectedBatchCount));
        OnPropertyChanged(nameof(CanImportBatch));
    }

    [RelayCommand]
    public void ApplyBatchViewType()
    {
        foreach (var item in BatchItems.Where(i => i.IsSelected))
        {
            item.SelectedViewType = BatchTargetViewType;
        }
    }

    [RelayCommand]
    public void ApplyBatchScale()
    {
        foreach (var item in BatchItems.Where(i => i.IsSelected))
        {
            item.SelectedScale = BatchScale;
        }
    }

    [RelayCommand]
    public async Task ImportBatchTablesAsync()
    {
        var itemsToImport = BatchItems.Where(i => i.IsSelected).ToList();
        if (itemsToImport.Count == 0) return;

        try
        {
            IsBusy = true;
            HasError = false;
            ErrorMessage = null;
            CreatedViews.Clear();

            using var tg = new TransactionGroup(_doc, "TablePlus — Batch Create Tables");
            tg.Start();

            int current = 0;
            int total = itemsToImport.Count;

            foreach (var item in itemsToImport)
            {
                current++;
                StatusMessage = $"Creating table {current} of {total}: {item.TargetViewName}...";
                ProgressPercent = (int)((double)current / total * 100);

                string? rangeAddress = null;
                if (item.IsCustomRange)
                {
                    rangeAddress = item.CustomRangeText.Trim();
                }
                else if (item.IsNamedRange && !string.IsNullOrWhiteSpace(item.SelectedNamedRange))
                {
                    rangeAddress = item.SelectedNamedRange!.Trim();
                }

                var sheetName = item.SelectedWorksheet;
                var filePath = item.FilePath;

                var (cells, mergedRanges) = await Task.Run(() =>
                {
                    var extractedCells = _excelReaderService.ExtractCells(filePath, sheetName, rangeAddress);
                    var extractedMerges = _excelReaderService.ExtractMergedCells(filePath, sheetName);
                    return (extractedCells, extractedMerges);
                });

                if (cells.Count == 0) continue;

                var targetName = GetUniqueViewName(item.TargetViewName);

                var config = new TableImportConfig
                {
                    SourceFilePath = filePath,
                    SelectedSheetName = sheetName,
                    RangeMode = item.IsCustomRange ? CellRangeSelectionMode.CustomRange : CellRangeSelectionMode.EntireSheet,
                    CustomRangeAddress = item.IsCustomRange ? item.CustomRangeText : null,
                    SelectedNamedRange = item.IsNamedRange ? item.SelectedNamedRange : null,
                    TargetViewType = item.SelectedViewType,
                    ViewName = targetName,
                    ViewScale = Math.Max(item.SelectedScale, 1),
                    PreserveBackgroundFills = true,
                    BlackAndWhiteMode = false,
                    SourceType = item.SourceType,
                    ImportType = item.SelectedImportType,
                    DpiResolution = item.DpiResolution,
                    PageOption = item.PageOption,
                    SelectedPages = item.SelectedPages,
                    IsRelativePath = item.IsRelativePath
                };

                var v = _geometryService.GenerateTable(_doc, config, cells, mergedRanges);
                if (v != null)
                {
                    CreatedViews.Add(v);
                    CreatedView = v;
                }
            }

            tg.Assimilate();

            StatusMessage = $"{CreatedViews.Count} table(s) created successfully!";
            ProgressPercent = 100;
            RequestClose?.Invoke();
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("Error in ImportBatchTablesAsync", ex);
            HasError = true;
            ErrorMessage = $"Import failed: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
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

        if (!IsFileLoaded || string.IsNullOrWhiteSpace(FilePath))
        {
            CanImport = false;
            return;
        }

        if (IsExcelSource && string.IsNullOrWhiteSpace(SelectedWorksheet))
        {
            CanImport = false;
            return;
        }

        if (string.IsNullOrWhiteSpace(ViewName))
        {
            CanImport = false;
            return;
        }

        if (NumberOfCopies < 1 || NumberOfCopies > 50)
        {
            CanImport = false;
            return;
        }

        if (IsPagedDocument && IsPageSelectionCustom && string.IsNullOrWhiteSpace(SelectedPages))
        {
            CanImport = false;
            return;
        }

        if (IsExcelSource)
        {
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
