using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using TransferPlus.Models;
using TransferPlus.Services;
using TransferPlus.Views;

namespace TransferPlus.ViewModels;

public partial class TransferPlusViewModel : ObservableObject
{
    private readonly Document _targetDoc;
    private readonly UIApplication _app;

    [ObservableProperty]
    private ObservableCollection<Archivo> _sourceDocuments = new();

    [ObservableProperty]
    private Archivo? _selectedSourceDocument;

    [ObservableProperty]
    private ObservableCollection<Archivo> _destinationDocuments = new();

    [ObservableProperty]
    private ObservableCollection<TreeItemViewModel> _rootNodes = new();

    [ObservableProperty]
    private string _searchFilter = string.Empty;

    // Filters
    [ObservableProperty]
    private bool _filterUseOr;

    [ObservableProperty]
    private bool _filterOnlyNames;

    [ObservableProperty]
    private bool _filterUseRegex;

    [ObservableProperty]
    private bool _isBusy;

    [ObservableProperty]
    private int _progressPercentage;

    [ObservableProperty]
    private string _statusMessage = "Ready";

    // Count of checked elements
    [ObservableProperty]
    private int _checkedElementsCount;

    // Options
    [ObservableProperty]
    private bool _overrideDuplicates = true;

    [ObservableProperty]
    private bool _cancelDuplicates;

    [ObservableProperty]
    private bool _askDuplicates;

    [ObservableProperty]
    private bool _includeCallouts;

    [ObservableProperty]
    private bool _includeViewElements;

    [ObservableProperty]
    private bool _includeSheetsWithViews;

    // Sub-options for Sheets
    [ObservableProperty]
    private bool _useLegendIfExists = true;

    [ObservableProperty]
    private bool _useScheduleIfExists = true;

    [ObservableProperty]
    private bool _useAssemblyViewsIfExists = true;

    [ObservableProperty]
    private bool _copyLinks;

    [ObservableProperty]
    private bool _transformNone;

    [ObservableProperty]
    private bool _transformLink = true;

    [ObservableProperty]
    private bool _transformShared;

    [ObservableProperty]
    private bool _acceptAllWarnings = true;

    [ObservableProperty]
    private bool _forceLevelInLevelBaseViews;

    private List<Elemento> _allSourceItems = new();
    private Configuraciones _config = new();

    public TransferPlusViewModel(UIApplication app, Document targetDoc)
    {
        _app = app;
        _targetDoc = targetDoc;
        LoadDocuments();

        // Register to receive messages when elements check state changes
        WeakReferenceMessenger.Default.Register<CheckedItemsChangedMessage>(this, (r, m) => UpdateCheckedCount());
    }

    public string CheckedDestinationsText
    {
        get
        {
            int count = DestinationDocuments.Count(d => d.Checked);
            return count == 1 ? "1 selected model" : $"{count} selected models";
        }
    }

    private void LoadDocuments()
    {
        TransferPlus.Services.LoggerService.LogInfo("LoadDocuments: Loading open documents and links from Revit Session...");
        SourceDocuments.Clear();
        DestinationDocuments.Clear();

        // Load all documents in the session, including links
        foreach (Document doc in _app.Application.Documents)
        {
            var arch = new Archivo(doc);
            if (doc.IsLinked)
            {
                arch.EsVinculo = true;
            }
            arch.Nombre = GetDocumentDisplayName(doc);
            SourceDocuments.Add(arch);
        }

        // Default selection to the active target document
        SelectedSourceDocument = SourceDocuments.FirstOrDefault(d => d.Adoc.PathName.Equals(_targetDoc.PathName, StringComparison.OrdinalIgnoreCase))
                                 ?? SourceDocuments.FirstOrDefault();

        OnPropertyChanged(nameof(CheckedDestinationsText));
        TransferPlus.Services.LoggerService.LogInfo($"LoadDocuments: Found {SourceDocuments.Count} source documents. Selected default source: '{SelectedSourceDocument?.Nombre}'");
    }

    partial void OnSelectedSourceDocumentChanged(Archivo? value)
    {
        TransferPlus.Services.LoggerService.LogInfo($"OnSelectedSourceDocumentChanged: Selected source document changed to '{value?.Nombre ?? "null"}'");
        if (value != null)
        {
            LoadSourceItems(value.Adoc);

            // Rebuild destination documents: all open non-linked documents except the selected source
            DestinationDocuments.Clear();
            foreach (Document doc in _app.Application.Documents)
            {
                if (doc.IsLinked) continue;
                if (doc.PathName.Equals(value.Adoc.PathName, StringComparison.OrdinalIgnoreCase)) continue;

                var dest = new Archivo(doc) { Checked = true };
                dest.Nombre = GetDocumentDisplayName(doc);
                dest.OnCheckedPropertyChanged = () => OnPropertyChanged(nameof(CheckedDestinationsText));
                DestinationDocuments.Add(dest);
            }
            TransferPlus.Services.LoggerService.LogInfo($"OnSelectedSourceDocumentChanged: Rebuilt destination documents. Target destinations count: {DestinationDocuments.Count}");
        }
        else
        {
            RootNodes.Clear();
            _allSourceItems.Clear();
            CheckedElementsCount = 0;
            DestinationDocuments.Clear();
        }
        OnPropertyChanged(nameof(CheckedDestinationsText));
    }

    private string GetDocumentDisplayName(Document doc)
    {
        if (doc.IsLinked)
        {
            try
            {
                var linkInst = new FilteredElementCollector(_targetDoc)
                    .OfClass(typeof(RevitLinkInstance))
                    .Cast<RevitLinkInstance>()
                    .FirstOrDefault(li => li.GetLinkDocument() != null && li.GetLinkDocument().PathName.Equals(doc.PathName, StringComparison.OrdinalIgnoreCase));

                if (linkInst != null)
                {
                    return $"Link: {linkInst.Name}";
                }
            }
            catch { }

            return "Link: " + doc.Title;
        }
        else if (doc.PathName.Equals(_targetDoc.PathName, StringComparison.OrdinalIgnoreCase))
        {
            return "Active Model: " + doc.Title;
        }
        else
        {
            return "Model: " + doc.Title;
        }
    }

    partial void OnCopyLinksChanged(bool value)
    {
        // If Include Links as Source is turned off, and the selected document is a link, reset selection
        if (!value && SelectedSourceDocument != null && SelectedSourceDocument.EsVinculo)
        {
            SelectedSourceDocument = SourceDocuments.FirstOrDefault(d => !d.EsVinculo);
        }
    }

    // No automatic filtering on property changes (triggered by Apply button only)

    private void LoadSourceItems(Document sourceDoc)
    {
        TransferPlus.Services.LoggerService.LogInfo($"LoadSourceItems: Starting element collection from '{sourceDoc.Title}'...");
        IsBusy = true;
        StatusMessage = "Collecting elements...";
        ProgressPercentage = 0;

        try
        {
            _allSourceItems = DocumentCollector.GetTransferableElements(sourceDoc, (stepName, stepIndex, maxSteps) =>
            {
                StatusMessage = $"{stepName}...";
                ProgressPercentage = (int)((double)stepIndex / maxSteps * 100);
            });
            TransferPlus.Services.LoggerService.LogInfo($"LoadSourceItems: Collection complete. Collected {_allSourceItems.Count} elements. Initiating tree build...");
            BuildTree();
        }
        catch (Exception ex)
        {
            TransferPlus.Services.LoggerService.LogError("LoadSourceItems", ex);
        }
        finally
        {
            IsBusy = false;
            StatusMessage = "Ready";
            ProgressPercentage = 0;
            UpdateCheckedCount();
        }
    }

    private void BuildTree()
    {
        TransferPlus.Services.LoggerService.LogInfo("BuildTree: Generating TreeView nodes from collected elements...");
        RootNodes.Clear();
        if (!_allSourceItems.Any()) return;

        var allNode = new TreeItemViewModel("All", "Root", null, null, 0)
        {
            Count = _allSourceItems.Count,
            IsExpanded = true
        };

        var groups = _allSourceItems.GroupBy(x => x.Categoria).OrderBy(g => g.Key);

        foreach (var group in groups)
        {
            var categoryNode = new TreeItemViewModel(group.Key, "Category", null, allNode, 1)
            {
                Count = group.Count()
            };
            
            if (group.Key == "Views" || group.Key == "View Templates")
            {
                var disciplineGroups = group.GroupBy(x => string.IsNullOrEmpty(x.Discipline) || x.Discipline == "Undefined" ? "Coordination" : x.Discipline).OrderBy(g => g.Key);
                foreach (var discGroup in disciplineGroups)
                {
                    var disciplineNode = new TreeItemViewModel(discGroup.Key, "Discipline", null, categoryNode, 2)
                    {
                        Count = discGroup.Count()
                    };
                    
                    var familyGroups = discGroup.GroupBy(x => x.Familia).OrderBy(g => g.Key);
                    foreach (var famGroup in familyGroups)
                    {
                        var familyNode = new TreeItemViewModel(famGroup.Key, "Family", null, disciplineNode, 3)
                        {
                            Count = famGroup.Count()
                        };
                        
                        foreach (var item in famGroup.OrderBy(x => x.Nombre))
                        {
                            var itemNode = new TreeItemViewModel(item.Nombre, item.Tipo ?? "Undefined", item, familyNode, 4)
                            {
                                Count = 1
                            };
                            familyNode.Children.Add(itemNode);
                        }
                        disciplineNode.Children.Add(familyNode);
                    }
                    categoryNode.Children.Add(disciplineNode);
                }
            }
            else
            {
                var familyGroups = group.GroupBy(x => x.Familia).OrderBy(g => g.Key);
                foreach (var famGroup in familyGroups)
                {
                    var familyNode = new TreeItemViewModel(famGroup.Key, "Family", null, categoryNode, 2)
                    {
                        Count = famGroup.Count()
                    };
                    
                    foreach (var item in famGroup.OrderBy(x => x.Nombre))
                    {
                        var itemNode = new TreeItemViewModel(item.Nombre, item.Tipo ?? "Undefined", item, familyNode, 3)
                        {
                            Count = 1
                        };
                        familyNode.Children.Add(itemNode);
                    }
                    categoryNode.Children.Add(familyNode);
                }
            }
            allNode.Children.Add(categoryNode);
        }
        RootNodes.Add(allNode);
        TransferPlus.Services.LoggerService.LogInfo($"BuildTree: Tree built successfully. Total nodes grouped in root: {allNode.Count}");
    }

    [RelayCommand]
    private void FilterTree()
    {
        string searchText = SearchFilter;
        if (string.IsNullOrWhiteSpace(searchText)) return;

        TransferPlus.Services.LoggerService.LogInfo($"FilterTree: Applying filter '{searchText}' (Regex: {FilterUseRegex}, Only Names: {FilterOnlyNames}, Use OR: {FilterUseOr})");
        StatusMessage = "Applying search filter...";
        IsBusy = true;

        System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke(
            System.Windows.Threading.DispatcherPriority.Background,
            new Action(delegate { }));

        try
        {
            Regex? searchRegex = null;

            if (FilterUseRegex)
            {
                try
                {
                    searchRegex = new Regex(
                        searchText, 
                        RegexOptions.IgnoreCase | RegexOptions.Compiled,
                        TimeSpan.FromSeconds(2));
                }
                catch (Exception ex)
                {
                    TransferPlus.Services.LoggerService.LogError("FilterTree (Regex Compile)", ex);
                    StatusMessage = "Invalid Regex Pattern";
                    return;
                }
            }
            else
            {
                searchText = searchText.ToLowerInvariant();
            }

            TreeItemViewModel.IsBulkUpdating = true;

            // If Use OR is OFF, the new search replaces the current selection.
            if (!FilterUseOr)
            {
                foreach (var node in RootNodes)
                {
                    node.SetCheckedState(false);
                }
            }

            // Apply the current search matches on the nodes shown in the explorer
            foreach (var node in RootNodes)
            {
                FilterNode(node, searchText, searchRegex);
            }

            // Ensure parent nodes reflect child states properly
            foreach (var node in RootNodes)
            {
                node.RefreshState();
            }

            TreeItemViewModel.IsBulkUpdating = false;
            UpdateCheckedCount();

            // Clear the text box after applying
            SearchFilter = string.Empty;
            TransferPlus.Services.LoggerService.LogInfo($"FilterTree: Filter applied successfully. Elements checked count is now {CheckedElementsCount}");
        }
        catch (Exception ex)
        {
            TransferPlus.Services.LoggerService.LogError("FilterTree", ex);
        }
        finally
        {
            IsBusy = false;
            StatusMessage = "Ready";
        }
    }

    private void FilterNode(TreeItemViewModel node, string searchText, Regex? searchRegex)
    {
        bool match = false;
        if (node.Level > 0)
        {
            try
            {
                if (searchRegex != null)
                {
                    match = searchRegex.IsMatch(node.Name);
                    if (!match && !FilterOnlyNames)
                    {
                        match = searchRegex.IsMatch(node.Category);
                        if (!match && node.Item != null)
                        {
                            if (node.Item.Familia != null) match = searchRegex.IsMatch(node.Item.Familia);
                            if (!match && node.Item.Tipo != null) match = searchRegex.IsMatch(node.Item.Tipo);
                        }
                    }
                }
                else
                {
                    match = node.Name.ToLowerInvariant().Contains(searchText);
                    if (!match && !FilterOnlyNames)
                    {
                        match = node.Category.ToLowerInvariant().Contains(searchText);
                        if (!match && node.Item != null)
                        {
                            if (node.Item.Familia != null) match = node.Item.Familia.ToLowerInvariant().Contains(searchText);
                            if (!match && node.Item.Tipo != null) match = node.Item.Tipo.ToLowerInvariant().Contains(searchText);
                        }
                    }
                }
            }
            catch {}
        }

        if (match)
        {
            node.SetCheckedState(true);
        }

        foreach (var child in node.Children)
        {
            FilterNode(child, searchText, searchRegex);
        }
    }

    [RelayCommand(CanExecute = nameof(HasCheckedElements))]
    private void ClearFilter()
    {
        SearchFilter = string.Empty;
        FilterUseOr = false;
        FilterOnlyNames = false;
        FilterUseRegex = false;

        if (RootNodes != null)
        {
            TreeItemViewModel.IsBulkUpdating = true;
            foreach (var node in RootNodes)
            {
                node.SetCheckedState(false);
            }
            TreeItemViewModel.IsBulkUpdating = false;
            UpdateCheckedCount();
        }
    }

    [RelayCommand]
    private void ExpandAll()
    {
        if (RootNodes == null || !RootNodes.Any()) return;
        
        int targetLevel = FindLowestUnexpandedLevel(RootNodes);
        if (targetLevel != int.MaxValue)
        {
            if (targetLevel == 0)
            {
                ForceCollapseAll(RootNodes.SelectMany(r => r.Children));
            }
            SetExpandedStateAtLevel(RootNodes, targetLevel, true);
        }
    }

    [RelayCommand]
    private void CollapseAll()
    {
        if (RootNodes == null || !RootNodes.Any()) return;

        int targetLevel = FindHighestExpandedLevel(RootNodes);
        if (targetLevel > 0) // Never collapse Level 0 (Root "All")
        {
            SetExpandedStateAtLevel(RootNodes, targetLevel, false);
        }
    }

    private int FindLowestUnexpandedLevel(IEnumerable<TreeItemViewModel> nodes)
    {
        int lowest = int.MaxValue;
        foreach (var node in nodes)
        {
            if (node.Children.Count > 0)
            {
                if (!node.IsExpanded)
                {
                    if (node.Level < lowest) lowest = node.Level;
                }
                else
                {
                    int childLowest = FindLowestUnexpandedLevel(node.Children);
                    if (childLowest < lowest) lowest = childLowest;
                }
            }
        }
        return lowest;
    }

    private int FindHighestExpandedLevel(IEnumerable<TreeItemViewModel> nodes)
    {
        int highest = -1;
        foreach (var node in nodes)
        {
            if (node.IsExpanded && node.Children.Count > 0)
            {
                if (node.Level > highest) highest = node.Level;
                int childHighest = FindHighestExpandedLevel(node.Children);
                if (childHighest > highest) highest = childHighest;
            }
        }
        return highest;
    }

    private void SetExpandedStateAtLevel(IEnumerable<TreeItemViewModel> nodes, int targetLevel, bool state)
    {
        foreach (var node in nodes)
        {
            if (node.Level == targetLevel)
            {
                if (node.Children.Count > 0) node.IsExpanded = state;
            }
            else if (node.Level < targetLevel)
            {
                SetExpandedStateAtLevel(node.Children, targetLevel, state);
            }
        }
    }

    private void ForceCollapseAll(IEnumerable<TreeItemViewModel> nodes)
    {
        foreach (var node in nodes)
        {
            node.IsExpanded = false;
            ForceCollapseAll(node.Children);
        }
    }

    private void SyncConfig()
    {
        _config.cf_rbOverride = OverrideDuplicates;
        _config.cf_rbCancel = CancelDuplicates;
        _config.cf_rbAsk = AskDuplicates;
        _config.cf_chk_Callout = IncludeCallouts;
        _config.cf_chk_ViewElements = IncludeViewElements;
        _config.cf_chk_SheetWithViews = IncludeSheetsWithViews;
        _config.cf_chk_Links = CopyLinks;
        _config.cf_chk_GetTransformNone = TransformNone;
        _config.cf_chk_GetTransformLink = TransformLink;
        _config.cf_chk_GetTransformShared = TransformShared;
        _config.cf_chk_AcceptAll = AcceptAllWarnings;
    }

    [RelayCommand(CanExecute = nameof(HasCheckedElements))]
    private void Transfer()
    {
        if (SelectedSourceDocument == null) return;

        TransferPlus.Services.LoggerService.LogInfo($"Transfer: Initiating transfer from '{SelectedSourceDocument.Nombre}'...");
        SyncConfig();

        var checkedItems = new List<Elemento>();
        CollectCheckedItems(RootNodes, checkedItems);

        if (!checkedItems.Any())
        {
            TransferPlus.Services.LoggerService.LogInfo("Transfer: Operation aborted. No items are checked for transfer.");
            TaskDialog.Show("TransferPlus", "No items selected to transfer.");
            return;
        }

        var elementsToCopy = checkedItems;
        TransferPlus.Services.LoggerService.LogInfo($"Transfer: Collected {elementsToCopy.Count} elements to transfer.");

        IsBusy = true;
        StatusMessage = "Transferring elements...";
        ProgressPercentage = 0;

        try
        {
            // Diccionario de renombrado
            Dictionary<ElementId, string>? customNames = null;
            if (IsRenamePanelOpen && RenamePreviewItems.Any())
            {
                customNames = new Dictionary<ElementId, string>();
                foreach (var item in RenamePreviewItems)
                {
                    if (item.IsSelected && item.NewName != item.OriginalName)
                    {
                        customNames[item.SourceId] = item.NewName;
                    }
                }
                if (!customNames.Any()) customNames = null;
            }

            int transferTargetCount = 0;
            foreach (var destDoc in DestinationDocuments)
            {
                if (destDoc.Checked)
                {
                    transferTargetCount++;
                    TransferPlus.Services.LoggerService.LogInfo($"Transfer: Copying elements to target model '{destDoc.Nombre}'...");
                    TransferOrchestrator.TransferElements(SelectedSourceDocument.Adoc, destDoc.Adoc, elementsToCopy, _config, (msg, current, total) =>
                    {
                        StatusMessage = $"{msg}...";
                        ProgressPercentage = (int)((double)current / total * 100);
                        if (current % 10 == 0 || current == total)
                        {
                            TransferPlus.Services.LoggerService.LogInfo($"Transfer: [{msg}] {current}/{total} elements processed ({ProgressPercentage}%)");
                        }
                    }, customNames);
                }
            }

            TransferPlus.Services.LoggerService.LogInfo($"Transfer: Completed successfully. Transferred to {transferTargetCount} destination models.");
            TaskDialog.Show("TransferPlus", "Transfer complete!");
        }
        catch (Exception ex)
        {
            TransferPlus.Services.LoggerService.LogError("Transfer", ex);
        }
        finally
        {
            IsBusy = false;
            StatusMessage = "Ready";
            ProgressPercentage = 0;
        }
    }

    private void CollectCheckedItems(IEnumerable<TreeItemViewModel> nodes, List<Elemento> list)
    {
        foreach (var node in nodes)
        {
            if (node.Item != null && node.IsChecked == true)
            {
                list.Add(node.Item);
            }
            CollectCheckedItems(node.Children, list);
        }
    }

    private bool HasCheckedElements()
    {
        return CheckedElementsCount > 0;
    }

    private void UpdateCheckedCount()
    {
        var checkedItems = new List<Elemento>();
        CollectCheckedItems(RootNodes, checkedItems);
        CheckedElementsCount = checkedItems.Count;
        
        TransferCommand.NotifyCanExecuteChanged();
        OpenRenamePanelCommand.NotifyCanExecuteChanged();
        ClearFilterCommand.NotifyCanExecuteChanged();
        
        // Sincronización dinámica con la paleta si está abierta o hay datos
        if (IsRenamePanelOpen || RenamePreviewItems.Any())
        {
            var currentPreviewIds = RenamePreviewItems.Select(x => x.SourceId).ToHashSet();
            var newCheckedIds = checkedItems.Select(x => x.eID).ToHashSet();

            // Eliminar los que ya no están seleccionados
            for (int i = RenamePreviewItems.Count - 1; i >= 0; i--)
            {
                if (!newCheckedIds.Contains(RenamePreviewItems[i].SourceId))
                {
                    RenamePreviewItems[i].PropertyChanged -= PreviewItem_PropertyChanged;
                    RenamePreviewItems.RemoveAt(i);
                }
            }

            // Añadir los nuevos seleccionados
            foreach (var item in checkedItems)
            {
                if (!currentPreviewIds.Contains(item.eID))
                {
                    var pItem = new RenamePreviewItem(item.eID, item.Nombre);
                    pItem.PropertyChanged += PreviewItem_PropertyChanged;
                    RenamePreviewItems.Add(pItem);
                }
            }

            // Recalcular SelectAllRenameItems
            _isUpdatingSelectAll = true;
            try
            {
                SelectAllRenameItems = RenamePreviewItems.All(x => x.IsSelected);
            }
            finally
            {
                _isUpdatingSelectAll = false;
            }

            UpdateRenamePreviews();
        }
    }

    // PowerRename Properties and Commands
    [ObservableProperty]
    private bool _isRenamePanelOpen;

    [ObservableProperty]
    private string _renameSearchText = string.Empty;

    [ObservableProperty]
    private string _renameReplaceText = string.Empty;

    [ObservableProperty]
    private bool _renameUseRegex;

    [ObservableProperty]
    private bool _renameMatchCase;

    [ObservableProperty]
    private bool _renameMatchAllOccurrences = true;

    [ObservableProperty]
    private bool _renameEnumerateItems;

    [ObservableProperty]
    private bool _renameRandomizeItems;

    [ObservableProperty]
    private bool _isFormatLowercase;

    [ObservableProperty]
    private bool _isFormatUppercase;

    [ObservableProperty]
    private bool _isFormatTitleCase;

    [ObservableProperty]
    private bool _isFormatCapitalizeEach;

    [ObservableProperty]
    private bool _renameApplyAll = true;

    [ObservableProperty]
    private bool _renameApplyOnlyFiltered;

    // Active Numbering Sequence Settings
    [ObservableProperty]
    private bool _numTypeNumeric = true;

    [ObservableProperty]
    private bool _numTypeAlphanumeric;

    [ObservableProperty]
    private bool _numOrderAscending = true;

    [ObservableProperty]
    private bool _numOrderDescending;

    [ObservableProperty]
    private string _numMinDigits = "3";

    [ObservableProperty]
    private string _numStartNumber = "1";

    [ObservableProperty]
    private string _numStartLetter = "A";

    [ObservableProperty]
    private string _numPrefix = "-";

    [ObservableProperty]
    private string _numSuffix = string.Empty;

    [ObservableProperty]
    private bool _numLocationBeginning;

    [ObservableProperty]
    private bool _numLocationEnd = true;

    [ObservableProperty]
    private string _numCustomSequence = string.Empty;

    // Editing Numbering Sequence Settings
    [ObservableProperty]
    private bool _editNumTypeNumeric;

    [ObservableProperty]
    private bool _editNumTypeAlphanumeric;

    [ObservableProperty]
    private bool _editNumOrderAscending;

    [ObservableProperty]
    private bool _editNumOrderDescending;

    [ObservableProperty]
    private string _editNumMinDigits = string.Empty;

    [ObservableProperty]
    private string _editNumStartNumber = string.Empty;

    [ObservableProperty]
    private string _editNumStartLetter = string.Empty;

    [ObservableProperty]
    private string _editNumPrefix = string.Empty;

    [ObservableProperty]
    private string _editNumSuffix = string.Empty;

    [ObservableProperty]
    private bool _editNumLocationBeginning;

    [ObservableProperty]
    private bool _editNumLocationEnd;

    [ObservableProperty]
    private string _editNumCustomSequence = string.Empty;

    [ObservableProperty]
    private bool _selectAllRenameItems = true;

    private bool _isUpdatingSelectAll;

    partial void OnSelectAllRenameItemsChanged(bool value)
    {
        if (_isUpdatingSelectAll) return;
        _isUpdatingSelectAll = true;
        try
        {
            foreach (var item in RenamePreviewItems)
            {
                item.IsSelected = value;
            }
        }
        finally
        {
            _isUpdatingSelectAll = false;
        }
        UpdateRenamePreviews();
    }

    private void PreviewItem_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(RenamePreviewItem.IsSelected))
        {
            if (_isUpdatingSelectAll) return;
            _isUpdatingSelectAll = true;
            try
            {
                SelectAllRenameItems = RenamePreviewItems.All(x => x.IsSelected);
            }
            finally
            {
                _isUpdatingSelectAll = false;
            }
            UpdateRenamePreviews();
        }
    }

    public ObservableCollection<RenamePreviewItem> RenamePreviewItems { get; } = new();

    partial void OnRenameSearchTextChanged(string value) => UpdateRenamePreviews();
    partial void OnRenameReplaceTextChanged(string value) => UpdateRenamePreviews();
    partial void OnRenameUseRegexChanged(bool value) => UpdateRenamePreviews();
    partial void OnRenameMatchCaseChanged(bool value) => UpdateRenamePreviews();
    partial void OnRenameMatchAllOccurrencesChanged(bool value) => UpdateRenamePreviews();
    partial void OnRenameEnumerateItemsChanged(bool value) => UpdateRenamePreviews();
    partial void OnRenameRandomizeItemsChanged(bool value) => UpdateRenamePreviews();
    partial void OnRenameApplyAllChanged(bool value) => UpdateRenamePreviews();
    partial void OnRenameApplyOnlyFilteredChanged(bool value) => UpdateRenamePreviews();

    partial void OnIsFormatLowercaseChanged(bool value)
    {
        if (value) { IsFormatUppercase = false; IsFormatTitleCase = false; IsFormatCapitalizeEach = false; }
        UpdateRenamePreviews();
    }
    partial void OnIsFormatUppercaseChanged(bool value)
    {
        if (value) { IsFormatLowercase = false; IsFormatTitleCase = false; IsFormatCapitalizeEach = false; }
        UpdateRenamePreviews();
    }
    partial void OnIsFormatTitleCaseChanged(bool value)
    {
        if (value) { IsFormatLowercase = false; IsFormatUppercase = false; IsFormatCapitalizeEach = false; }
        UpdateRenamePreviews();
    }
    partial void OnIsFormatCapitalizeEachChanged(bool value)
    {
        if (value) { IsFormatLowercase = false; IsFormatUppercase = false; IsFormatTitleCase = false; }
        UpdateRenamePreviews();
    }

    [RelayCommand(CanExecute = nameof(HasCheckedElements))]
    private void OpenRenamePanel()
    {
        if (SelectedSourceDocument == null) return;

        var checkedItems = new List<Elemento>();
        CollectCheckedItems(RootNodes, checkedItems);

        if (!checkedItems.Any())
        {
            TaskDialog.Show("TransferPlus", "No elements checked for renaming.");
            return;
        }

        RenamePreviewItems.Clear();
        foreach (var item in checkedItems)
        {
            var pItem = new RenamePreviewItem(item.eID, item.Nombre);
            pItem.PropertyChanged += PreviewItem_PropertyChanged;
            RenamePreviewItems.Add(pItem);
        }
        SelectAllRenameItems = true;

        IsRenamePanelOpen = true;
        UpdateRenamePreviews();
    }

    [RelayCommand]
    private void CloseRenamePanel()
    {
        IsRenamePanelOpen = false;
        RenameSearchText = string.Empty;
        RenameReplaceText = string.Empty;
        RenamePreviewItems.Clear();
    }

    [RelayCommand]
    private void InsertRegexHelper(string snippet)
    {
        RenameSearchText += snippet;
    }

    [RelayCommand]
    private void InsertDateHelper(string snippet)
    {
        RenameReplaceText += snippet;
    }

    private void UpdateRenamePreviews()
    {
        if (string.IsNullOrEmpty(RenameSearchText))
        {
            foreach (var item in RenamePreviewItems)
            {
                item.IsMatchingFilter = false;
                // Keep original name; formatting may be applied later based on flags.
                item.NewName = item.OriginalName;
            }
            // Do not return; continue to apply formatting based on ApplyAll flag.
        }
        else
        {
            // Search text is provided; further processing will handle matching.
        }

        RegexOptions options = RenameMatchCase ? RegexOptions.None : RegexOptions.IgnoreCase;
        Regex? regex = null;

        if (RenameUseRegex)
        {
            try
            {
                regex = new Regex(RenameSearchText, options, TimeSpan.FromMilliseconds(500));
            }
            catch
            {
                // Incomplete regex, do not apply changes yet
                return;
            }
        }

        int selectedItemIndex = 0;
        foreach (var item in RenamePreviewItems)
        {
            // First, calculate if it matches the Find text (regardless of IsSelected)
            bool isMatch = false;
            if (!string.IsNullOrEmpty(RenameSearchText))
            {
                if (RenameUseRegex && regex != null)
                {
                    try
                    {
                        isMatch = regex.IsMatch(item.OriginalName);
                    }
                    catch { }
                }
                else
                {
                    string literalPattern = Regex.Escape(RenameSearchText);
                    var re = new Regex(literalPattern, options, TimeSpan.FromMilliseconds(500));
                    isMatch = re.IsMatch(item.OriginalName);
                }
            }
            item.IsMatchingFilter = isMatch;

            // If the item is unchecked, revert to original name and do not apply any rename logic
            if (!item.IsSelected)
            {
                item.NewName = item.OriginalName;
                continue;
            }

            // Determine if we should apply formatting to this item
            bool shouldFormat = RenameApplyAll || (RenameApplyOnlyFiltered && isMatch);

            // Evaluate the replacement template per selected item index
            string evaluatedReplaceText = EvaluateReplacementTemplate(RenameReplaceText, selectedItemIndex);

            string newName = item.OriginalName;
            if (isMatch)
            {
                if (RenameUseRegex && regex != null)
                {
                    try
                    {
                        newName = RenameMatchAllOccurrences ? regex.Replace(item.OriginalName, evaluatedReplaceText) : regex.Replace(item.OriginalName, evaluatedReplaceText, 1);
                    }
                    catch { }
                }
                else
                {
                    string literalPattern = Regex.Escape(RenameSearchText);
                    var re = new Regex(literalPattern, options, TimeSpan.FromMilliseconds(500));
                    newName = RenameMatchAllOccurrences ? re.Replace(item.OriginalName, evaluatedReplaceText) : re.Replace(item.OriginalName, evaluatedReplaceText, 1);
                }
            }

            // Apply casing only if shouldFormat is true
            if (shouldFormat)
            {
                if (IsFormatLowercase) newName = newName.ToLower();
                else if (IsFormatUppercase) newName = newName.ToUpper();
                else if (IsFormatTitleCase && newName.Length > 0) newName = char.ToUpper(newName[0]) + newName.Substring(1).ToLower();
                else if (IsFormatCapitalizeEach) newName = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(newName.ToLower());
            }

            item.NewName = newName;
            selectedItemIndex++;
        }

        // Collect items that will actually be formatted
        var itemsToFormat = new List<RenamePreviewItem>();
        foreach (var item in RenamePreviewItems)
        {
            if (item.IsSelected)
            {
                bool shouldFormat = RenameApplyAll || (RenameApplyOnlyFiltered && item.IsMatchingFilter);
                if (shouldFormat)
                {
                    itemsToFormat.Add(item);
                }
            }
        }
        int N = itemsToFormat.Count;

        // Apply enumeration and randomizing
        if (RenameEnumerateItems && N > 0)
        {
            var customVals = new List<string>();
            if (!string.IsNullOrWhiteSpace(NumCustomSequence))
            {
                customVals = NumCustomSequence.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                             .Select(s => s.Trim())
                                             .ToList();
            }

            bool useCustom = customVals.Any();

            if (useCustom)
            {
                for (int i = 0; i < N; i++)
                {
                    string baseVal = customVals[i % customVals.Count];
                    string seqString = (NumPrefix ?? string.Empty) + baseVal + (NumSuffix ?? string.Empty);
                    
                    if (NumLocationBeginning)
                        itemsToFormat[i].NewName = seqString + itemsToFormat[i].NewName;
                    else
                        itemsToFormat[i].NewName += seqString;
                }
            }
            else
            {
                int.TryParse(NumMinDigits, out int minDigits);
                if (minDigits <= 0) minDigits = 1;

                if (NumTypeNumeric)
                {
                    bool hasStartNum = !string.IsNullOrWhiteSpace(NumStartNumber);
                    int startVal = 1;
                    if (hasStartNum && int.TryParse(NumStartNumber, out int parsed))
                        startVal = parsed;
                    if (startVal < 0) startVal = 1;

                    for (int i = 0; i < N; i++)
                    {
                        int currentVal;
                        if (NumOrderAscending)
                        {
                            currentVal = startVal + i;
                        }
                        else
                        {
                            if (hasStartNum)
                                currentVal = startVal - i;
                            else
                                currentVal = N - i;
                        }

                        if (currentVal < 0) currentVal = 0;

                        string baseVal = currentVal.ToString().PadLeft(minDigits, '0');
                        string seqString = (NumPrefix ?? string.Empty) + baseVal + (NumSuffix ?? string.Empty);
                        
                        if (NumLocationBeginning)
                            itemsToFormat[i].NewName = seqString + itemsToFormat[i].NewName;
                        else
                            itemsToFormat[i].NewName += seqString;
                    }
                }
                else // NumTypeAlphanumeric
                {
                    bool hasStartLetter = !string.IsNullOrWhiteSpace(NumStartLetter);
                    int startIndex = 0;

                    if (hasStartLetter)
                    {
                        string letter = NumStartLetter.Trim().ToUpperInvariant();
                        if (letter.Length < minDigits)
                        {
                            char padChar = NumOrderAscending ? 'A' : 'Z';
                            letter = letter.PadRight(minDigits, padChar);
                        }
                        startIndex = ParseFixedBase26(letter, minDigits);
                    }
                    else
                    {
                        startIndex = 0;
                    }

                    for (int i = 0; i < N; i++)
                    {
                        int currentIndex;
                        if (NumOrderAscending)
                        {
                            currentIndex = startIndex + i;
                        }
                        else
                        {
                            if (hasStartLetter)
                                currentIndex = startIndex - i;
                            else
                                currentIndex = (N - 1) - i;
                        }
                        
                        string baseVal = IndexToFixedBase26(currentIndex, minDigits);
                        string seqString = (NumPrefix ?? string.Empty) + baseVal + (NumSuffix ?? string.Empty);
                        
                        if (NumLocationBeginning)
                            itemsToFormat[i].NewName = seqString + itemsToFormat[i].NewName;
                        else
                            itemsToFormat[i].NewName += seqString;
                    }
                }
            }
        }

        if (RenameRandomizeItems && N > 0)
        {
            var rnd = new Random();
            int.TryParse(NumMinDigits, out int minDigits);
            if (minDigits <= 0) minDigits = 1;

            for (int i = 0; i < N; i++)
            {
                string baseVal = NumTypeNumeric ? GenerateRandomNumeric(minDigits, rnd) : GenerateRandomAlphanumeric(minDigits, rnd);
                string seqString = (NumPrefix ?? string.Empty) + baseVal + (NumSuffix ?? string.Empty);
                
                if (NumLocationBeginning)
                    itemsToFormat[i].NewName = seqString + itemsToFormat[i].NewName;
                else
                    itemsToFormat[i].NewName += seqString;
            }
        }
    }

    private int ParseFixedBase26(string letter, int length)
    {
        if (string.IsNullOrWhiteSpace(letter)) return 0;
        string clean = letter.Trim().ToUpperInvariant();
        int val = 0;
        foreach (char c in clean)
        {
            if (c >= 'A' && c <= 'Z')
            {
                val = val * 26 + (c - 'A');
            }
        }
        return val;
    }

    private string IndexToFixedBase26(int value, int length)
    {
        if (length <= 0) length = 1;
        long baseVal = 1;
        for (int i = 0; i < length; i++) baseVal *= 26;
        
        long longVal = value;
        if (longVal < 0)
        {
            longVal = baseVal + (longVal % baseVal);
        }
        longVal = longVal % baseVal;

        char[] chars = new char[length];
        for (int i = length - 1; i >= 0; i--)
        {
            int digit = (int)(longVal % 26);
            chars[i] = (char)('A' + digit);
            longVal /= 26;
        }
        return new string(chars);
    }

    private string GenerateRandomNumeric(int length, Random rnd)
    {
        if (length <= 0) length = 1;
        char[] chars = new char[length];
        for (int i = 0; i < length; i++)
        {
            chars[i] = (char)('0' + rnd.Next(0, 10));
        }
        return new string(chars);
    }

    private string GenerateRandomAlphanumeric(int length, Random rnd)
    {
        if (length <= 0) length = 1;
        char[] chars = new char[length];
        for (int i = 0; i < length; i++)
        {
            chars[i] = (char)('A' + rnd.Next(0, 26));
        }
        return new string(chars);
    }

    private string EvaluateReplacementTemplate(string template, int itemIndex)
    {
        if (string.IsNullOrEmpty(template)) return template;

        string result = template;
        DateTime now = DateTime.Now;

        // 1. Evaluate Date/Time
        // Replace in order from longest token to shortest to avoid nested replacement issues
        var dateReplacements = new (string Token, string Format)[]
        {
            ("$YYYY", "yyyy"), ("$MMMM", "MMMM"), ("$DDDD", "dddd"),
            ("$MMM", "MMM"), ("$DDD", "ddd"), ("$fff", "fff"),
            ("$YY", "yy"), ("$MM", "MM"), ("$DD", "dd"),
            ("$HH", "HH"), ("$hh", "hh"), ("$mm", "mm"), ("$ss", "ss"),
            ("$ff", "ff"), ("$TT", "tt"), ("$tt", "tt"),
            ("$Y", "y"), ("$M", "M"), ("$D", "d"),
            ("$H", "H"), ("$h", "h"), ("$m", "m"), ("$s", "s"),
            ("$f", "f")
        };

        foreach (var pair in dateReplacements)
        {
            if (result.Contains(pair.Token))
            {
                result = result.Replace(pair.Token, now.ToString(pair.Format));
            }
        }

        // 2. Evaluate Counters and Random variables: ${...}
        var counterRegex = new Regex(@"\$\{(.*?)\}");
        result = counterRegex.Replace(result, match =>
        {
            string content = match.Groups[1].Value.Trim();
            
            // Check for UUID or Random strings
            if (content.Equals("ruuidv4", StringComparison.OrdinalIgnoreCase))
            {
                return Guid.NewGuid().ToString();
            }
            else if (content.StartsWith("rstringalpha=", StringComparison.OrdinalIgnoreCase))
            {
                if (int.TryParse(content.Substring("rstringalpha=".Length), out int len))
                    return GenerateRandomString(len, true, false);
                return match.Value;
            }
            else if (content.StartsWith("rstringalphanum=", StringComparison.OrdinalIgnoreCase))
            {
                if (int.TryParse(content.Substring("rstringalphanum=".Length), out int len))
                    return GenerateRandomString(len, true, true);
                return match.Value;
            }
            else if (content.StartsWith("rstringdigit=", StringComparison.OrdinalIgnoreCase))
            {
                if (int.TryParse(content.Substring("rstringdigit=".Length), out int len))
                    return GenerateRandomString(len, false, true);
                return match.Value;
            }

            // Default to counter parsing
            int start = 1;
            int increment = 1;
            int padding = 0;

            if (!string.IsNullOrEmpty(content))
            {
                var parts = content.Split(',');
                foreach (var part in parts)
                {
                    var kvp = part.Split('=');
                    if (kvp.Length == 2)
                    {
                        string key = kvp[0].Trim().ToLower();
                        string valStr = kvp[1].Trim();
                        if (int.TryParse(valStr, out int val))
                        {
                            if (key == "start") start = val;
                            else if (key == "increment") increment = val;
                            else if (key == "padding") padding = Math.Min(Math.Max(0, val), 100);
                        }
                    }
                }
            }

            int currentValue = start + itemIndex * increment;
            return currentValue.ToString().PadLeft(padding, '0');
        });

        return result;
    }

    private string GenerateRandomString(int length, bool includeLetters, bool includeDigits)
    {
        length = Math.Min(Math.Max(0, length), 100); // Clamp to prevent OutOfMemoryException
        const string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string digits = "0123456789";
        string pool = "";
        if (includeLetters) pool += letters;
        if (includeDigits) pool += digits;

        if (string.IsNullOrEmpty(pool)) return "";

        var rnd = new Random();
        var chars = new char[length];
        for (int i = 0; i < length; i++)
        {
            chars[i] = pool[rnd.Next(pool.Length)];
        }
        return new string(chars);
    }

    [RelayCommand]
    private void DeleteElements()
    {
        if (SelectedSourceDocument == null) return;

        var checkedItems = new List<Elemento>();
        CollectCheckedItems(RootNodes, checkedItems);

        if (!checkedItems.Any())
        {
            TaskDialog.Show("TransferPlus", "No elements checked for deletion.");
            return;
        }

        Document document = SelectedSourceDocument.Adoc;
        if (document.IsLinked)
        {
            TaskDialog.Show("TransferPlus", "Cannot delete elements from a linked document.");
            return;
        }

        var result = TaskDialog.Show("TransferPlus", $"Are you sure you want to delete {checkedItems.Count} elements from the source document?", TaskDialogCommonButtons.Yes | TaskDialogCommonButtons.No);
        if (result != TaskDialogResult.Yes) return;

        int deletedCount = 0;

        using (Transaction transaction = new Transaction(document, "TransferPlus: Delete Elements"))
        {
            transaction.Start();
            WarningSwallower.AttachToTransaction(transaction);

            foreach (var item in checkedItems)
            {
                try
                {
                    document.Delete(item.eID);
                    deletedCount++;
                }
                catch { }
            }
            transaction.Commit();
        }

        TaskDialog.Show("TransferPlus", $"Deleted {deletedCount} elements.");
        LoadSourceItems(document);
    }

    [RelayCommand]
    private void OpenConfiguration()
    {
        var configView = new ConfigurationView();
        configView.ShowDialog();
    }

    [RelayCommand]
    private void OpenNumberingSettings()
    {
        try
        {
            TransferPlus.Services.LoggerService.LogInfo("OpenNumberingSettings: Initializing configurations copy...");
            // Copy active to editing
            EditNumTypeNumeric = NumTypeNumeric;
            EditNumTypeAlphanumeric = NumTypeAlphanumeric;
            EditNumOrderAscending = NumOrderAscending;
            EditNumOrderDescending = NumOrderDescending;
            EditNumMinDigits = NumMinDigits;
            EditNumStartNumber = NumStartNumber;
            EditNumStartLetter = NumStartLetter;
            EditNumPrefix = NumPrefix;
            EditNumSuffix = NumSuffix;
            EditNumLocationBeginning = NumLocationBeginning;
            EditNumLocationEnd = NumLocationEnd;
            EditNumCustomSequence = NumCustomSequence;

            TransferPlus.Services.LoggerService.LogInfo("OpenNumberingSettings: Instantiating NumberingSettingsView...");
            // Open Dialog
            var view = new NumberingSettingsView(this);
            TransferPlus.Services.LoggerService.LogInfo("OpenNumberingSettings: Showing NumberingSettingsView Dialog...");
            bool? result = view.ShowDialog();
            TransferPlus.Services.LoggerService.LogInfo($"OpenNumberingSettings: DialogResult is {result}");
            if (result == true)
            {
                // Copy editing back to active
                NumTypeNumeric = EditNumTypeNumeric;
                NumTypeAlphanumeric = EditNumTypeAlphanumeric;
                NumOrderAscending = EditNumOrderAscending;
                NumOrderDescending = EditNumOrderDescending;
                NumMinDigits = EditNumMinDigits;
                NumStartNumber = EditNumStartNumber;
                NumStartLetter = EditNumStartLetter;
                NumPrefix = EditNumPrefix;
                NumSuffix = EditNumSuffix;
                NumLocationBeginning = EditNumLocationBeginning;
                NumLocationEnd = EditNumLocationEnd;
                NumCustomSequence = EditNumCustomSequence;

                TransferPlus.Services.LoggerService.LogInfo("OpenNumberingSettings: Committing edit changes and updating previews...");
                UpdateRenamePreviews();
            }
        }
        catch (Exception ex)
        {
            TransferPlus.Services.LoggerService.LogError("OpenNumberingSettings", ex);
        }
    }
}