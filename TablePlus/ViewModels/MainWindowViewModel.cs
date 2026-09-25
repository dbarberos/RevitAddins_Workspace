using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
    private string _searchText = string.Empty;

    [ObservableProperty]
    private string _selectedViewTypeFilter = "All";

    [ObservableProperty]
    private string _selectedStatusFilter = "All";

    [ObservableProperty]
    private TableItemModel? _selectedTable;

    [ObservableProperty]
    private bool _isSelectAllChecked;

    [ObservableProperty]
    private int _totalCount;

    [ObservableProperty]
    private int _selectedCount;

    [ObservableProperty]
    private int _outOfDateCount;

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
    }

    partial void OnSearchTextChanged(string value) => RefreshFilter();
    partial void OnSelectedViewTypeFilterChanged(string value) => RefreshFilter();
    partial void OnSelectedStatusFilterChanged(string value) => RefreshFilter();

    partial void OnIsSelectAllCheckedChanged(bool value)
    {
        if (_isUpdatingSelectAll) return;
        _isUpdatingSelectAll = true;

        foreach (var item in FilteredTables.Cast<TableItemModel>())
        {
            item.IsSelected = value;
        }

        UpdateCounters();
        _isUpdatingSelectAll = false;
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

        // 1. Text search
        if (!string.IsNullOrWhiteSpace(SearchText))
        {
            string query = SearchText.Trim();
            bool matchName = item.ViewName.Contains(query, StringComparison.OrdinalIgnoreCase);
            bool matchFile = item.SourceFileName.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                             item.SourceFilePath.Contains(query, StringComparison.OrdinalIgnoreCase);
            if (!matchName && !matchFile) return false;
        }

        // 2. View Type filter
        if (SelectedViewTypeFilter == "Drafting Views" && item.ViewType != TargetViewType.DraftingView)
            return false;
        if (SelectedViewTypeFilter == "Legend Views" && item.ViewType != TargetViewType.LegendView)
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

        var list = FilteredTables.Cast<TableItemModel>().ToList();
        IsSelectAllChecked = list.Count > 0 && list.All(i => i.IsSelected);

        _isUpdatingSelectAll = false;
    }

    private void UpdateCounters()
    {
        TotalCount = Tables.Count;
        SelectedCount = Tables.Count(t => t.IsSelected);
        OutOfDateCount = Tables.Count(t => t.Status is TableSyncStatus.Modified or TableSyncStatus.FileNotFound);
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

            FilteredTables.Refresh();
            UpdateSelectAllState();
            UpdateCounters();

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
            configView.ShowDialog();
        }
        catch (Exception ex)
        {
            TaskDialog.Show("TablePlus Error", $"Failed to open Configuration window: {ex.Message}");
        }
    }

    [RelayCommand]
    public async Task SyncSelectedAsync()
    {
        var targets = Tables.Where(t => t.IsSelected).ToList();
        if (targets.Count == 0)
        {
            if (SelectedTable != null)
            {
                targets.Add(SelectedTable);
            }
            else
            {
                TaskDialog.Show("TablePlus", "Please select at least one table to synchronize.");
                return;
            }
        }

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

    [RelayCommand]
    public async Task DeleteSelectedAsync()
    {
        var targets = Tables.Where(t => t.IsSelected).ToList();
        if (targets.Count == 0 && SelectedTable != null)
        {
            targets.Add(SelectedTable);
        }

        if (targets.Count == 0)
        {
            TaskDialog.Show("TablePlus", "Please select at least one table to delete or unlink.");
            return;
        }

        var td = new TaskDialog("TablePlus — Remove Tables")
        {
            MainInstruction = $"Remove {targets.Count} selected table(s)?",
            MainContent = "You can permanently delete the Revit views from the project, or unlink them to remove TablePlus metadata while preserving the graphical lines and text.",
            CommonButtons = TaskDialogCommonButtons.Cancel
        };

        td.AddCommandLink(TaskDialogCommandLinkId.CommandLink1, "Delete Revit Views", "Permanently delete the Drafting/Legend views from the Revit project.");
        td.AddCommandLink(TaskDialogCommandLinkId.CommandLink2, "Unlink Tables Only", "Remove TablePlus sync tracking but keep existing lines, fills, and text notes in Revit.");

        var res = td.Show();
        if (res == TaskDialogResult.Cancel) return;

        bool deleteView = res == TaskDialogResult.CommandLink1;

        using var tx = new Transaction(_doc, deleteView ? "TablePlus: Delete Table Views" : "TablePlus: Unlink Tables");
        tx.Start();

        foreach (var item in targets)
        {
            _registryService.DeleteOrUnlinkTable(_doc, item, deleteView);
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
