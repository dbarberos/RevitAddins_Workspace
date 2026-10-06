using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Data;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TablePlus.Models;
using TablePlus.Services;
using TablePlus.Views;

namespace TablePlus.ViewModels;

/// <summary>
/// Master presentation ViewModel driving the TablePlus Dashboard and Table Manager.
/// Manages table discovery, real-time status tracking, filtering, batch synchronization,
/// and design dialog orchestration.
/// </summary>
public partial class MainWindowViewModel : ObservableObject
{
    private readonly Document _doc;
    private readonly UIDocument? _uiDoc;
    private readonly ITableRegistryService _registryService;
    private readonly ITableGeometryService _geometryService;
    private readonly IExcelReaderService _excelReader;
    private readonly ISchemaService _schemaService;

    private bool _isUpdatingSelectAll;

    [ObservableProperty]
    private ObservableCollection<TableItemModel> _tables = new();

    public ICollectionView FilteredTables { get; }

    [ObservableProperty]
    private string _searchFilter = string.Empty;

    public string SearchText
    {
        get => SearchFilter;
        set => SearchFilter = value;
    }

    [ObservableProperty]
    private bool _filterUseOr;

    [ObservableProperty]
    private bool _filterOnlyNames;

    [ObservableProperty]
    private bool _filterUseRegex;

    #region Select Details/Table Card Properties (Origin & Organize)

    [ObservableProperty]
    private bool _originDraftingViews = true;

    [ObservableProperty]
    private bool _originLegends = true;

    [ObservableProperty]
    private bool _originSchedules = true;

    [ObservableProperty]
    private bool _sortByCategory;

    [ObservableProperty]
    private bool _sortByName;

    [ObservableProperty]
    private bool _sortBySheet;

    [ObservableProperty]
    private bool _sortByView;

    #endregion

    private readonly HashSet<TableItemModel> _matchedItems = new();
    private bool _isFilterActive;

    [ObservableProperty]
    private string _selectedViewTypeFilter = "All";

    [ObservableProperty]
    private string _selectedStatusFilter = "All";

    [ObservableProperty]
    private TableItemModel? _selectedTable;

    [ObservableProperty]
    private bool? _isSelectAllChecked = false;

    [ObservableProperty]
    private bool _isAllGroupExpanded = true;

    [ObservableProperty]
    private int _totalCount;

    [ObservableProperty]
    private int _selectedCount;

    public bool HasSelectedTables => SelectedCount > 0;

    [ObservableProperty]
    private int _outOfDateCount;

    [ObservableProperty]
    private int _upToDateCount;

    [ObservableProperty]
    private int _modifiedCount;

    [ObservableProperty]
    private int _fileNotFoundCount;

    [ObservableProperty]
    private bool _isBusy;

    [ObservableProperty]
    private string _busyStatusMessage = "Ready";

    [ObservableProperty]
    private double _progressValue;

    public ObservableCollection<string> ViewTypeFilterOptions { get; } = new()
    {
        "All",
        "Drafting Views",
        "Legend Views"
    };

    public ObservableCollection<string> StatusFilterOptions { get; } = new()
    {
        "All",
        "Up to Date",
        "Modified",
        "File Missing"
    };

    public MainWindowViewModel(
        Document doc,
        UIDocument? uiDoc = null,
        ITableRegistryService? registryService = null,
        ITableGeometryService? geometryService = null,
        IExcelReaderService? excelReader = null,
        ISchemaService? schemaService = null)
    {
        _doc = doc ?? throw new ArgumentNullException(nameof(doc));
        _uiDoc = uiDoc;
        _schemaService = schemaService ?? new SchemaService();
        _excelReader = excelReader ?? new ExcelReaderService();
        _geometryService = geometryService ?? new TableGeometryService(_schemaService);
        _registryService = registryService ?? new TableRegistryService(_schemaService, _excelReader);

        FilteredTables = CollectionViewSource.GetDefaultView(Tables);
        FilteredTables.Filter = FilterPredicate;
        ApplyGroupings();
    }

    private readonly List<string> _activeGroupings = new();

    /// <summary>
    /// Action callback provided by the View to expand or collapse all group containers.
    /// </summary>
    public Action<bool>? RequestSetAllGroupsExpanded { get; set; }

    [RelayCommand]
    public void ExpandAll()
    {
        IsAllGroupExpanded = true;
        RequestSetAllGroupsExpanded?.Invoke(true);
    }

    [RelayCommand]
    public void CollapseAll()
    {
        IsAllGroupExpanded = false;
        RequestSetAllGroupsExpanded?.Invoke(false);
    }

    public IEnumerable<TableItemModel> GetFilteredItems() => Tables.Where(FilterPredicate);

    partial void OnSearchFilterChanged(string value)
    {
        ApplyFilterCommand.NotifyCanExecuteChanged();
        if (string.IsNullOrWhiteSpace(value) && _isFilterActive)
        {
            _isFilterActive = false;
            _matchedItems.Clear();
            RefreshFilter();
            BusyStatusMessage = "Ready";
        }
    }

    partial void OnFilterOnlyNamesChanged(bool value)
    {
        if (_isFilterActive) ApplyFilter();
    }

    partial void OnFilterUseRegexChanged(bool value)
    {
        if (_isFilterActive) ApplyFilter();
    }

    partial void OnFilterUseOrChanged(bool value)
    {
        if (_isFilterActive && !value) ApplyFilter();
    }


    partial void OnSelectedViewTypeFilterChanged(string value) => RefreshFilter();
    partial void OnSelectedStatusFilterChanged(string value) => RefreshFilter();
    partial void OnOriginDraftingViewsChanged(bool value) => RefreshFilter();
    partial void OnOriginLegendsChanged(bool value) => RefreshFilter();
    partial void OnOriginSchedulesChanged(bool value) => RefreshFilter();

    partial void OnSortByCategoryChanged(bool value) => UpdateGrouping("Category", value);
    partial void OnSortByNameChanged(bool value) => UpdateGrouping("Name", value);
    partial void OnSortBySheetChanged(bool value) => UpdateGrouping("Sheet", value);
    partial void OnSortByViewChanged(bool value) => UpdateGrouping("View", value);

    private void UpdateGrouping(string groupingName, bool isAdded)
    {
        if (isAdded)
        {
            if (!_activeGroupings.Contains(groupingName))
                _activeGroupings.Add(groupingName);
        }
        else
        {
            _activeGroupings.Remove(groupingName);
        }

        ApplyGroupings();
    }

    private void ApplyGroupings()
    {
        if (FilteredTables == null) return;

        using (FilteredTables.DeferRefresh())
        {
            FilteredTables.GroupDescriptions.Clear();
            FilteredTables.SortDescriptions.Clear();

            if (_activeGroupings.Count == 0)
            {
                FilteredTables.GroupDescriptions.Add(new PropertyGroupDescription(nameof(TableItemModel.GroupName)));
            }
            else
            {
                foreach (var grouping in _activeGroupings)
                {
                    switch (grouping)
                    {
                        case "Category":
                            FilteredTables.GroupDescriptions.Add(new PropertyGroupDescription(nameof(TableItemModel.CategoryName)));
                            break;
                        case "Sheet":
                            FilteredTables.GroupDescriptions.Add(new PropertyGroupDescription(nameof(TableItemModel.SheetName)));
                            break;
                        case "View":
                            FilteredTables.GroupDescriptions.Add(new PropertyGroupDescription(nameof(TableItemModel.ViewName)));
                            break;
                        case "Name":
                            FilteredTables.GroupDescriptions.Add(new PropertyGroupDescription(nameof(TableItemModel.TableName)));
                            break;
                    }
                }
            }

            if (SortByName)
            {
                FilteredTables.SortDescriptions.Add(new SortDescription(nameof(TableItemModel.TableName), ListSortDirection.Ascending));
            }
            else
            {
                FilteredTables.SortDescriptions.Add(new SortDescription(nameof(TableItemModel.ViewName), ListSortDirection.Ascending));
            }
        }
    }

    private bool CanApplyFilter() => !string.IsNullOrWhiteSpace(SearchFilter) || _isFilterActive;

    [RelayCommand(CanExecute = nameof(CanApplyFilter))]
    private void ApplyFilter()
    {
        string searchText = SearchFilter?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(searchText))
        {
            _isFilterActive = false;
            _matchedItems.Clear();
            RefreshFilter();
            BusyStatusMessage = "Filter cleared. All tables displayed.";
            return;
        }

        Regex? compiledRegex = null;
        if (FilterUseRegex)
        {
            try
            {
                compiledRegex = new Regex(
                    searchText,
                    RegexOptions.IgnoreCase | RegexOptions.Compiled,
                    TimeSpan.FromSeconds(2));
            }
            catch (Exception)
            {
                BusyStatusMessage = "Invalid Regex Pattern";
                return;
            }
        }

        _isFilterActive = true;

        if (!FilterUseOr)
        {
            _matchedItems.Clear();
        }

        bool isNegativeFilter = FilterUseRegex && compiledRegex != null && (searchText.Contains("(?!") || searchText.Contains("(?<!"));

        foreach (var item in Tables)
        {
            bool match = false;
            if (compiledRegex != null)
            {
                try
                {
                    match = compiledRegex.IsMatch(item.ViewName ?? string.Empty);
                    if (!match && !FilterOnlyNames)
                    {
                        match = compiledRegex.IsMatch(item.SourceFileName ?? string.Empty) ||
                                compiledRegex.IsMatch(item.SourceFilePath ?? string.Empty);
                    }
                }
                catch
                {
                    // Timeout or evaluation error guard
                }
            }
            else
            {
                match = (item.ViewName ?? string.Empty).IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0;
                if (!match && !FilterOnlyNames)
                {
                    match = (item.SourceFileName ?? string.Empty).IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                            (item.SourceFilePath ?? string.Empty).IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0;
                }
            }

            if (match)
            {
                _matchedItems.Add(item);
            }
        }

        RefreshFilter();
        BusyStatusMessage = $"Filter applied. {_matchedItems.Count} of {Tables.Count} tables matched.";
        LoggerService.LogInfo($"[MainWindowViewModel] Filter applied: '{searchText}' (Regex={FilterUseRegex}, NamesOnly={FilterOnlyNames}, UseOr={FilterUseOr}) -> Matched {_matchedItems.Count} of {Tables.Count} tables.");
    }

    public IRelayCommand FilterTreeCommand => ApplyFilterCommand;

    [RelayCommand]
    private void InsertFilterRegexHelper(string snippet)
    {
        if (snippet.Contains("text") && !string.IsNullOrWhiteSpace(SearchFilter) && !SearchFilter.Contains("(?") && !SearchFilter.Contains(".*"))
        {
            SearchFilter = snippet.Replace("text", SearchFilter.Trim());
        }
        else
        {
            SearchFilter = string.IsNullOrWhiteSpace(SearchFilter) ? snippet : (SearchFilter + snippet);
        }
        FilterUseRegex = true;
        if (snippet.Contains("(?"))
        {
            FilterOnlyNames = true;
        }
    }

    partial void OnIsSelectAllCheckedChanged(bool? value)
    {
        if (_isUpdatingSelectAll) return;
        _isUpdatingSelectAll = true;

        bool target = value == true;

        foreach (var item in GetFilteredItems())
        {
            item.IsSelected = target;
        }

        UpdateCounters();
        _isUpdatingSelectAll = false;
        UpdateSelectAllState();
    }

    private void RefreshFilter()
    {
        FilteredTables.Refresh();
        UpdateSelectAllState();
        UpdateCounters();
    }

    private bool FilterPredicate(object obj)
    {
        if (obj is not TableItemModel item) return false;

        if (_isFilterActive && !_matchedItems.Contains(item))
        {
            return false;
        }

        // 2. View Type (Origin) filter - allows selecting one or multiple simultaneously
        bool matchesOrigin = false;
        if (OriginDraftingViews && item.ViewType == TargetViewType.DraftingView)
            matchesOrigin = true;
        if (OriginLegends && item.ViewType == TargetViewType.LegendView)
            matchesOrigin = true;
        if (OriginSchedules && item.ViewType == TargetViewType.ScheduleView)
            matchesOrigin = true;

        if (!matchesOrigin)
            return false;

        // 3. Status filter
        if (SelectedStatusFilter == "Up to Date" && item.Status != TableSyncStatus.UpToDate)
            return false;
        if (SelectedStatusFilter == "Modified" && item.Status != TableSyncStatus.Modified)
            return false;
        if (SelectedStatusFilter == "File Missing" && item.Status != TableSyncStatus.FileNotFound)
            return false;

        return true;
    }

    private void UpdateSelectAllState()
    {
        if (_isUpdatingSelectAll) return;
        _isUpdatingSelectAll = true;

        var list = GetFilteredItems().ToList();
        if (list.Count == 0)
        {
            IsSelectAllChecked = false;
        }
        else if (list.All(i => i.IsSelected))
        {
            IsSelectAllChecked = true;
        }
        else if (list.Any(i => i.IsSelected))
        {
            IsSelectAllChecked = null;
        }
        else
        {
            IsSelectAllChecked = false;
        }

        _isUpdatingSelectAll = false;
    }

    private void UpdateCounters()
    {
        TotalCount = Tables.Count;
        SelectedCount = Tables.Count(t => t.IsSelected);
        UpToDateCount = Tables.Count(t => t.Status == TableSyncStatus.UpToDate);
        ModifiedCount = Tables.Count(t => t.Status == TableSyncStatus.Modified);
        FileNotFoundCount = Tables.Count(t => t.Status == TableSyncStatus.FileNotFound);
        OutOfDateCount = ModifiedCount + FileNotFoundCount;
        OnPropertyChanged(nameof(HasSelectedTables));
        SyncSelectedCommand.NotifyCanExecuteChanged();
        DeleteSelectedCommand.NotifyCanExecuteChanged();
    }

    [RelayCommand]
    public void FilterByStatusBadge(string status)
    {
        if (SelectedStatusFilter == status)
        {
            SelectedStatusFilter = "All";
        }
        else
        {
            SelectedStatusFilter = status;
        }
    }

    private void OnItemPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(TableItemModel.IsSelected))
        {
            UpdateCounters();
            UpdateSelectAllState();
        }
        else if (e.PropertyName == nameof(TableItemModel.IsBlackAndWhite))
        {
            if (sender is TableItemModel item)
            {
                item.Config.BlackAndWhiteMode = item.IsBlackAndWhite;
                item.Status = TableSyncStatus.Modified;
                item.StatusTooltip = "Black & White mode changed. Synchronize to apply.";
                LoggerService.LogInfo($"[MainWindowViewModel] Table '{item.ViewName}' B&W mode toggled to: {item.IsBlackAndWhite}");
                UpdateCounters();
            }
        }
        else if (e.PropertyName == nameof(TableItemModel.IsAutoSyncEnabled))
        {
            if (sender is TableItemModel item)
            {
                item.Config.IsAutoSyncEnabled = item.IsAutoSyncEnabled;
#if REVIT2024_OR_GREATER
                var viewId = new ElementId(item.ViewId);
#else
                var viewId = new ElementId((int)item.ViewId);
#endif
                if (_doc.GetElement(viewId) is View view)
                {
                    using var tx = new Transaction(_doc, "TablePlus: Update AutoSync Setting");
                    tx.Start();
                    _schemaService.StampTableMetadata(view, item.Config, item.Config.SourceFilePath);
                    tx.Commit();
                    LoggerService.LogInfo($"[MainWindowViewModel] Table '{item.ViewName}' AutoSync setting updated in Revit to: {item.IsAutoSyncEnabled}");
                }
            }
        }
        else if (e.PropertyName == nameof(TableItemModel.ViewScale))
        {
            if (sender is TableItemModel item && item.ViewScale > 0)
            {
                item.Config.ViewScale = item.ViewScale;
#if REVIT2024_OR_GREATER
                var viewId = new ElementId(item.ViewId);
#else
                var viewId = new ElementId((int)item.ViewId);
#endif
                if (_doc.GetElement(viewId) is View view && view.Scale != item.ViewScale)
                {
                    try
                    {
                        using var tx = new Transaction(_doc, "TablePlus: Update View Scale");
                        tx.Start();
                        view.Scale = item.ViewScale;
                        _schemaService.StampTableMetadata(view, item.Config, item.Config.SourceFilePath);
                        tx.Commit();
                        LoggerService.LogInfo($"[MainWindowViewModel] Table '{item.ViewName}' scale updated in Revit to: 1:{item.ViewScale}");
                    }
                    catch (Exception ex)
                    {
                        TelemetryLogger.LogError("Error updating view scale in Revit", ex);
                    }
                }
            }
        }
        else if (e.PropertyName == nameof(TableItemModel.SelectedRegionMode))
        {
            if (sender is TableItemModel item)
            {
                item.Config.RangeMode = item.SelectedRegionMode switch
                {
                    "Custom Range" => CellRangeSelectionMode.CustomRange,
                    "Named Range" => CellRangeSelectionMode.NamedRange,
                    _ => CellRangeSelectionMode.EntireSheet
                };
                item.Status = TableSyncStatus.Modified;
                item.StatusTooltip = $"Region mode changed to '{item.SelectedRegionMode}'. Synchronize to apply.";
                LoggerService.LogInfo($"[MainWindowViewModel] Table '{item.ViewName}' RegionMode set to: '{item.SelectedRegionMode}'");
                UpdateCounters();
            }
        }
        else if (e.PropertyName == nameof(TableItemModel.ImportType))
        {
            if (sender is TableItemModel item)
            {
                item.Config.ImportType = item.ImportType;
                item.Status = TableSyncStatus.Modified;
                item.StatusTooltip = $"Import type changed to '{item.ImportType}'. Synchronize to apply.";
                LoggerService.LogInfo($"[MainWindowViewModel] Table '{item.ViewName}' ImportType set to: '{item.ImportType}'");
                UpdateCounters();
            }
        }
    }

    [RelayCommand]
    public async Task RefreshInventoryAsync()
    {
        try
        {
            IsBusy = true;
            BusyStatusMessage = "Discovering linked tables in Revit document...";
            ProgressValue = 10;
            LoggerService.LogInfo($"[MainWindowViewModel] RefreshInventoryAsync started for document '{_doc.Title}'...");

            var discovered = await _registryService.DiscoverTablesAsync(_doc);

            // Detach previous listeners
            foreach (var item in Tables)
            {
                item.PropertyChanged -= OnItemPropertyChanged;
            }

            Tables.Clear();

            foreach (var item in discovered)
            {
                item.PropertyChanged += OnItemPropertyChanged;
                Tables.Add(item);
            }

            if (_isFilterActive)
            {
                ApplyFilter();
            }
            else
            {
                FilteredTables.Refresh();
                UpdateSelectAllState();
                UpdateCounters();
            }

            BusyStatusMessage = $"Discovered {Tables.Count} table(s).";
            ProgressValue = 100;
            LoggerService.LogInfo($"[MainWindowViewModel] RefreshInventoryAsync finished: {Tables.Count} table(s) registered in dashboard (UpToDate={UpToDateCount}, Modified={ModifiedCount}, Missing={FileNotFoundCount}).");
        }
        catch (Exception ex)
        {
            BusyStatusMessage = $"Discovery failed: {ex.Message}";
            LoggerService.LogError("[MainWindowViewModel] RefreshInventoryAsync failed", ex);
        }
        finally
        {
            IsBusy = false;
        }
    }

    public async Task AddTableWithFilesAsync(IEnumerable<string> filePaths)
    {
        var filesList = filePaths.Where(File.Exists).ToList();
        if (filesList.Count == 0) return;
        await OpenAddTableFlowAsync(filesList);
    }

    [RelayCommand]
    public async Task AddTableAsync(string? initialFilePath = null)
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(initialFilePath) && File.Exists(initialFilePath))
            {
                await OpenAddTableFlowAsync(new List<string> { initialFilePath! });
                return;
            }

            // Open intermediate source selection window
            var sourcePickerVm = new TableSourceSelectionViewModel();
            var sourcePickerView = new TableSourceSelectionView(sourcePickerVm);

            var activeWindow = System.Windows.Application.Current?.Windows.OfType<MainWindowView>().FirstOrDefault();
            if (activeWindow != null)
            {
                sourcePickerView.Owner = activeWindow;
            }

            var pickerResult = sourcePickerView.ShowDialog();
            if (pickerResult != true || sourcePickerVm.ResultFilePaths.Count == 0)
            {
                // User canceled source selection or file dialog
                return;
            }

            await OpenAddTableFlowAsync(sourcePickerVm.ResultFilePaths, sourcePickerVm.IsRelativePath);
        }
        catch (Exception ex)
        {
            TaskDialog.Show("TablePlus Error", $"Failed to open Source Selection dialog: {ex.Message}");
        }
    }

    private async Task OpenAddTableFlowAsync(List<string> filesToLoad, bool isRelativePath = false)
    {
        try
        {
            var importVm = new TableImportViewModel(_doc, _excelReader, _geometryService, _schemaService);
            importVm.SelectedFilePaths = filesToLoad;
            importVm.IsRelativePath = isRelativePath;

            await importVm.InitializeBatchFilesAsync(filesToLoad, isRelativePath);

            var importView = new TableImportView(importVm);
            var parentWin = System.Windows.Application.Current?.Windows.OfType<MainWindowView>().FirstOrDefault();
            if (parentWin != null)
            {
                importView.Owner = parentWin;
            }

            var result = importView.ShowDialog();
            if (result == true || importVm.CreatedViews.Count > 0 || importVm.CreatedView != null)
            {
                // Refresh inventory to discover the newly imported table view(s)
                await RefreshInventoryAsync();
            }
        }
        catch (Exception ex)
        {
            TaskDialog.Show("TablePlus Error", $"Failed to open Import dialog: {ex.Message}");
        }
    }

    [RelayCommand]
    public void OpenConfiguration()
    {
        try
        {
            var configView = new ConfigurationView();
            var activeWindow = System.Windows.Application.Current?.Windows.OfType<MainWindowView>().FirstOrDefault();
            if (activeWindow != null)
            {
                configView.Owner = activeWindow;
            }
            configView.ShowDialog();
        }
        catch (Exception ex)
        {
            LoggerService.LogError("OpenConfiguration", ex);
        }
    }

    [RelayCommand(CanExecute = nameof(HasSelectedTables))]
    public async Task SyncSelectedAsync()
    {
        var targets = Tables.Where(t => t.IsSelected).ToList();
        if (targets.Count == 0) return;

        try
        {
            IsBusy = true;
            ProgressValue = 0;
            LoggerService.LogInfo($"[MainWindowViewModel] SyncSelectedAsync started for {targets.Count} selected table(s)...");

            using var tg = new TransactionGroup(_doc, "TablePlus: Batch Sync Tables");
            tg.Start();

            int successCount = 0;
            int errorCount = 0;

            for (int i = 0; i < targets.Count; i++)
            {
                var item = targets[i];
                BusyStatusMessage = $"Synchronizing table {i + 1} of {targets.Count}: {item.ViewName}...";
                ProgressValue = (double)(i + 1) / targets.Count * 100.0;
                LoggerService.LogInfo($"[MainWindowViewModel] Synchronizing table {i + 1}/{targets.Count}: '{item.ViewName}' from '{item.SourceFileName}' (Sheet: '{item.SelectedSheetName}', Region: '{item.CellRangeAddress}')...");

                try
                {
                    if (!File.Exists(item.SourceFilePath))
                    {
                        item.Status = TableSyncStatus.FileNotFound;
                        item.StatusTooltip = $"Source file missing: {item.SourceFilePath}";
                        errorCount++;
                        LoggerService.LogWarning($"[MainWindowViewModel] Table '{item.ViewName}' skipped: source file does not exist ('{item.SourceFilePath}')");
                        continue;
                    }

                    // Extract spreadsheet cells in background
                    var (cells, mergedRanges) = await Task.Run(() =>
                    {
                        var extractedCells = _excelReader.ExtractCells(
                            item.SourceFilePath,
                            item.SelectedSheetName,
                            item.Config.CustomRangeAddress);

                        var extractedMerges = _excelReader.ExtractMergedCells(
                            item.SourceFilePath,
                            item.SelectedSheetName);

                        return (extractedCells, extractedMerges);
                    });

#if REVIT2024_OR_GREATER
                    var viewId = new ElementId(item.ViewId);
#else
                    var viewId = new ElementId((int)item.ViewId);
#endif
                    if (_doc.GetElement(viewId) is not View targetView)
                    {
                        item.Status = TableSyncStatus.Unlinked;
                        item.StatusTooltip = "Revit view no longer exists.";
                        errorCount++;
                        LoggerService.LogWarning($"[MainWindowViewModel] Table '{item.ViewName}' view {item.ViewId} was deleted in Revit.");
                        continue;
                    }

                    // Synchronize in-memory config
                    item.Config.BlackAndWhiteMode = item.IsBlackAndWhite;
                    item.Config.IsAutoSyncEnabled = item.IsAutoSyncEnabled;
                    item.Config.SelectedSheetName = item.SelectedSheetName;

                    if (targetView is ViewSchedule scheduleView && item.Config.ImportType == TableImportType.KeySchedule)
                    {
                        var keyService = new KeyScheduleService(_schemaService);
                        keyService.UpdateKeySchedule(_doc, scheduleView, item.Config, cells);
                    }
                    else if (targetView is ViewSchedule scheduleViewHdr && item.Config.ImportType == TableImportType.HeaderSchedule)
                    {
                        var headerService = new HeaderScheduleService(_schemaService);
                        headerService.UpdateHeaderSchedule(_doc, scheduleViewHdr, item.Config, cells, mergedRanges);
                    }
                    else
                    {
                        _geometryService.UpdateTableInView(_doc, targetView, item.Config, cells, mergedRanges);
                    }

                    item.Status = TableSyncStatus.UpToDate;
                    item.StatusTooltip = $"Synchronized successfully on {DateTime.Now:g}";
                    successCount++;
                    LoggerService.LogInfo($"[MainWindowViewModel] Table '{item.ViewName}' synchronized successfully ({cells.Count} cells, {mergedRanges.Count} merges).");
                }
                catch (Exception ex)
                {
                    errorCount++;
                    item.StatusTooltip = $"Sync failed: {ex.Message}";
                    LoggerService.LogError($"[MainWindowViewModel] Error synchronizing table '{item.ViewName}'", ex);
                }
            }

            tg.Assimilate();
            UpdateCounters();

            BusyStatusMessage = $"Synchronization complete. {successCount} succeeded, {errorCount} failed.";
            LoggerService.LogInfo($"[MainWindowViewModel] Batch sync finished. Succeeded: {successCount}, Failed: {errorCount}.");
        }
        catch (Exception ex)
        {
            BusyStatusMessage = $"Batch sync error: {ex.Message}";
            LoggerService.LogError("[MainWindowViewModel] Batch sync encountered critical error", ex);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    public void OpenSelectedView()
    {
        if (SelectedTable == null) return;

#if REVIT2024_OR_GREATER
        var viewId = new ElementId(SelectedTable.ViewId);
#else
        var viewId = new ElementId((int)SelectedTable.ViewId);
#endif
        if (_doc.GetElement(viewId) is View view && _uiDoc != null)
        {
            try
            {
                LoggerService.LogInfo($"[MainWindowViewModel] Activating view '{view.Name}' (Id: {view.Id}) in Revit UI...");
                _uiDoc.ActiveView = view;
            }
            catch (Exception ex)
            {
                TaskDialog.Show("TablePlus", $"Could not switch active view: {ex.Message}");
                LoggerService.LogError($"[MainWindowViewModel] Error activating view '{view.Name}'", ex);
            }
        }
    }

    [RelayCommand(CanExecute = nameof(HasSelectedTables))]
    public async Task DeleteSelectedAsync()
    {
        var targets = Tables.Where(t => t.IsSelected).ToList();
        if (targets.Count == 0) return;

        var confirmDialog = new ConfirmTableDeleteWindow(targets);
        var result = confirmDialog.ShowDialog();
        if (result != true)
        {
            LoggerService.LogInfo("[MainWindowViewModel] Table deletion cancelled by user.");
            return;
        }

        LoggerService.LogInfo($"[MainWindowViewModel] Deleting {targets.Count} selected table(s) from document...");

        using var tx = new Transaction(_doc, "TablePlus: Delete Table Views");
        tx.Start();

        foreach (var item in targets)
        {
            LoggerService.LogInfo($"[MainWindowViewModel] Deleting table '{item.ViewName}' (ViewId: {item.ViewId})...");
            _registryService.DeleteOrUnlinkTable(_doc, item, deleteView: true);
        }

        tx.Commit();
        LoggerService.LogInfo($"[MainWindowViewModel] Successfully deleted {targets.Count} table(s). Refreshing inventory...");

        await RefreshInventoryAsync();
    }

    [RelayCommand]
    public async Task OpenDesignWindow(TableItemModel? item)
    {
        var target = item ?? SelectedTable;
        if (target == null) return;

        try
        {
            var vm = new TableStyleMappingViewModel(_doc, target);
            var view = new TableStyleMappingView(vm);

            var res = view.ShowDialog();
            if (vm.DialogResult)
            {
                target.Status = TableSyncStatus.Modified;
                target.StatusTooltip = "Styling modified. Synchronize to apply.";
                UpdateCounters();

                // Instantly sync the modified table so Revit graphics update immediately
                await SyncSingleTableAsync(target);
            }
        }
        catch (Exception ex)
        {
            TaskDialog.Show("TablePlus Error", $"Failed to open Design window: {ex.Message}");
        }
    }

    [RelayCommand]
    public async Task OnSheetChangedAsync(TableItemModel? item)
    {
        if (item == null) return;

        item.Config.SelectedSheetName = item.SelectedSheetName;
        item.Status = TableSyncStatus.Modified;
        item.StatusTooltip = $"Worksheet changed to '{item.SelectedSheetName}'. Synchronizing...";
        UpdateCounters();

        await SyncSingleTableAsync(item);
    }

    private async Task SyncSingleTableAsync(TableItemModel item)
    {
        try
        {
            IsBusy = true;
            BusyStatusMessage = $"Synchronizing {item.ViewName}...";
            LoggerService.LogInfo($"[MainWindowViewModel] SyncSingleTableAsync started for table '{item.ViewName}' from '{item.SourceFileName}' (Sheet: '{item.SelectedSheetName}')...");

            if (!File.Exists(item.SourceFilePath))
            {
                item.Status = TableSyncStatus.FileNotFound;
                item.StatusTooltip = $"Source file missing: {item.SourceFilePath}";
                LoggerService.LogWarning($"[MainWindowViewModel] Table '{item.ViewName}' source file not found: '{item.SourceFilePath}'");
                return;
            }

            var (cells, mergedRanges) = await Task.Run(() =>
            {
                var extractedCells = _excelReader.ExtractCells(
                    item.SourceFilePath,
                    item.SelectedSheetName,
                    item.Config.CustomRangeAddress);

                var extractedMerges = _excelReader.ExtractMergedCells(
                    item.SourceFilePath,
                    item.SelectedSheetName);

                return (extractedCells, extractedMerges);
            });

#if REVIT2024_OR_GREATER
            var viewId = new ElementId(item.ViewId);
#else
            var viewId = new ElementId((int)item.ViewId);
#endif
            if (_doc.GetElement(viewId) is not View targetView)
            {
                item.Status = TableSyncStatus.Unlinked;
                item.StatusTooltip = "Revit view no longer exists.";
                LoggerService.LogWarning($"[MainWindowViewModel] Table '{item.ViewName}' view {item.ViewId} was deleted in Revit.");
                return;
            }

            item.Config.BlackAndWhiteMode = item.IsBlackAndWhite;
            item.Config.IsAutoSyncEnabled = item.IsAutoSyncEnabled;
            item.Config.SelectedSheetName = item.SelectedSheetName;

            _geometryService.UpdateTableInView(_doc, targetView, item.Config, cells, mergedRanges);

            item.Status = TableSyncStatus.UpToDate;
            item.StatusTooltip = $"Synchronized successfully on {DateTime.Now:g}";
            BusyStatusMessage = $"Table '{item.ViewName}' synchronized successfully.";
            LoggerService.LogInfo($"[MainWindowViewModel] Single table '{item.ViewName}' synchronized successfully ({cells.Count} cells, {mergedRanges.Count} merges).");
        }
        catch (Exception ex)
        {
            item.StatusTooltip = $"Sync failed: {ex.Message}";
            BusyStatusMessage = $"Sync failed: {ex.Message}";
            LoggerService.LogError($"[MainWindowViewModel] SyncSingleTableAsync failed for '{item.ViewName}'", ex);
        }
        finally
        {
            IsBusy = false;
            UpdateCounters();
        }
    }

    [RelayCommand]
    public async Task RenameViewAsync(TableItemModel? item)
    {
        if (item == null) return;

        string newName = item.ViewName.Trim();
        if (string.IsNullOrWhiteSpace(newName))
        {
            await RefreshInventoryAsync();
            return;
        }

        char[] invalidChars = { '\\', ':', '{', '}', '[', ']', '|', ';', '<', '>', '?', '`', '~' };
        if (newName.IndexOfAny(invalidChars) >= 0)
        {
            TaskDialog.Show("TablePlus", "View name cannot contain any of the following characters:\n\\ : { } [ ] | ; < > ? ` ~");
            await RefreshInventoryAsync();
            return;
        }

#if REVIT2024_OR_GREATER
        var viewId = new ElementId(item.ViewId);
#else
        var viewId = new ElementId((int)item.ViewId);
#endif
        if (_doc.GetElement(viewId) is View view)
        {
            if (view.Name == newName) return;

            try
            {
                LoggerService.LogInfo($"[MainWindowViewModel] Renaming view '{view.Name}' (Id: {viewId}) to '{newName}'...");
                using var tx = new Transaction(_doc, "TablePlus: Rename Table View");
                tx.Start();
                view.Name = newName;
                item.Config.ViewName = newName;
                _schemaService.StampTableMetadata(view, item.Config, item.Config.SourceFilePath);
                tx.Commit();
                item.ViewName = newName;
                LoggerService.LogInfo($"[MainWindowViewModel] View renamed successfully to '{newName}'.");
            }
            catch (Exception ex)
            {
                TelemetryLogger.LogError($"Error renaming view to '{newName}'", ex);
                TaskDialog.Show("TablePlus", $"Could not rename view to '{newName}':\n{ex.Message}");
                item.ViewName = view.Name; // Revert to Revit current name
            }
        }
    }
}

