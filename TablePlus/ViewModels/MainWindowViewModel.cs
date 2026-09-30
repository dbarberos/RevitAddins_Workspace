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
                }
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
        }
        catch (Exception ex)
        {
            BusyStatusMessage = $"Discovery failed: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    public void AddTable()
    {
        try
        {
            var importVm = new TableImportViewModel(_doc, _excelReader, _geometryService, _schemaService);
            var importView = new TableImportView(importVm);

            var result = importView.ShowDialog();
            if (result == true || importVm.CreatedView != null)
            {
                // Refresh inventory to discover the newly imported table view
                _ = RefreshInventoryAsync();
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

            using var tg = new TransactionGroup(_doc, "TablePlus: Batch Sync Tables");
            tg.Start();

            int successCount = 0;
            int errorCount = 0;

            for (int i = 0; i < targets.Count; i++)
            {
                var item = targets[i];
                BusyStatusMessage = $"Synchronizing table {i + 1} of {targets.Count}: {item.ViewName}...";
                ProgressValue = (double)(i + 1) / targets.Count * 100.0;

                try
                {
                    if (!File.Exists(item.SourceFilePath))
                    {
                        item.Status = TableSyncStatus.FileNotFound;
                        item.StatusTooltip = $"Source file missing: {item.SourceFilePath}";
                        errorCount++;
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
                        continue;
                    }

                    // Synchronize in-memory config
                    item.Config.BlackAndWhiteMode = item.IsBlackAndWhite;
                    item.Config.IsAutoSyncEnabled = item.IsAutoSyncEnabled;
                    item.Config.SelectedSheetName = item.SelectedSheetName;

                    _geometryService.UpdateTableInView(_doc, targetView, item.Config, cells, mergedRanges);

                    item.Status = TableSyncStatus.UpToDate;
                    item.StatusTooltip = $"Synchronized successfully on {DateTime.Now:g}";
                    successCount++;
                }
                catch (Exception ex)
                {
                    errorCount++;
                    item.StatusTooltip = $"Sync failed: {ex.Message}";
                }
            }

            tg.Assimilate();
            UpdateCounters();

            BusyStatusMessage = $"Synchronization complete. {successCount} succeeded, {errorCount} failed.";
        }
        catch (Exception ex)
        {
            BusyStatusMessage = $"Batch sync error: {ex.Message}";
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
                _uiDoc.ActiveView = view;
            }
            catch (Exception ex)
            {
                TaskDialog.Show("TablePlus", $"Could not switch active view: {ex.Message}");
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
        if (result != true) return;

        using var tx = new Transaction(_doc, "TablePlus: Delete Table Views");
        tx.Start();

        foreach (var item in targets)
        {
            _registryService.DeleteOrUnlinkTable(_doc, item, deleteView: true);
        }

        tx.Commit();

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

            if (!File.Exists(item.SourceFilePath))
            {
                item.Status = TableSyncStatus.FileNotFound;
                item.StatusTooltip = $"Source file missing: {item.SourceFilePath}";
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
                return;
            }

            item.Config.BlackAndWhiteMode = item.IsBlackAndWhite;
            item.Config.IsAutoSyncEnabled = item.IsAutoSyncEnabled;
            item.Config.SelectedSheetName = item.SelectedSheetName;

            _geometryService.UpdateTableInView(_doc, targetView, item.Config, cells, mergedRanges);

            item.Status = TableSyncStatus.UpToDate;
            item.StatusTooltip = $"Synchronized successfully on {DateTime.Now:g}";
            BusyStatusMessage = $"Table '{item.ViewName}' synchronized successfully.";
        }
        catch (Exception ex)
        {
            item.StatusTooltip = $"Sync failed: {ex.Message}";
            BusyStatusMessage = $"Sync failed: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
            UpdateCounters();
        }
    }
}
