using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FilterPlus.Models;
using FilterPlus.Services;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace FilterPlus.ViewModels;

public partial class SelectionFilterViewModel : ObservableObject
{
    private readonly RevitSelectionService _selectionService;
    private Autodesk.Revit.UI.ExternalEvent _pickElementsEvent;

    public System.Action HideWindowRequested { get; set; }
    public System.Action ShowWindowRequested { get; set; }

    // Pre-fetched data for each scope (loaded once at startup in API context)
    private List<ElementModel> _currentSelectionElements = new();
    private List<ElementModel> _elementsVisibleInViewElements = new();
    private List<ElementModel> _elementsBelongingToViewElements = new();
    private List<ElementModel> _allModelElements = new();

    // Active list displayed in the tree
    private List<ElementModel> _activeElements = new();

    public ObservableCollection<TreeItemViewModel> RootNodes { get; } = new();

    public ObservableCollection<string> Categories { get; } = new();
    public ObservableCollection<string> Families { get; } = new();
    public ObservableCollection<string> Types { get; } = new();
    public ObservableCollection<string> Levels { get; } = new();
    public ObservableCollection<string> Worksets { get; } = new();

    [ObservableProperty] private string _selectedCategory;
    [ObservableProperty] private string _selectedFamily;
    [ObservableProperty] private string _selectedType;
    [ObservableProperty] private string _selectedLevel;
    [ObservableProperty] private string _selectedWorkset;
    [ObservableProperty] private string _statusMessage;
    [ObservableProperty] private int _checkedElementsCount;
    [ObservableProperty] private string _filterText = string.Empty;
    [ObservableProperty] private bool _isBusy;
    [ObservableProperty] private bool _isOnly3DModels;
    [ObservableProperty] private bool _isOnlyAnnotation;
    [ObservableProperty] private bool _hasBoundingBox;
    [ObservableProperty] private bool _isLiveSelection;
    [ObservableProperty] private bool _sortByPhase;
    [ObservableProperty] private bool _sortByLevel;
    [ObservableProperty] private bool _sortByWorkset;
    [ObservableProperty] private bool _isUseOr;
    [ObservableProperty] private bool _isOnlyByName;
    [ObservableProperty] private bool _isUseRegex;

    // Increase Checked Options
    [ObservableProperty] private bool _increaseWhatSameCategory;
    [ObservableProperty] private bool _increaseWhatSameFamily;
    [ObservableProperty] private bool _increaseWhatSameType;
    [ObservableProperty] private bool _increaseWhatSameWorkset;
    [ObservableProperty] private bool _increaseWhatHostOfElement;
    [ObservableProperty] private bool _increaseWhatHostedElements;
    [ObservableProperty] private bool _increaseWhatNestedElements;
    [ObservableProperty] private bool _increaseWhatJoinedElements;
    [ObservableProperty] private bool _increaseWhatSupercomponent;
    [ObservableProperty] private bool _increaseWhatGroupOfAssembly;
    [ObservableProperty] private bool _increaseWhatDependent;
    [ObservableProperty] private bool _increaseWhatIntersects;
    [ObservableProperty] private bool _increaseWhatSameMEPSystem;

    [ObservableProperty] private bool _increaseWhereAllModel = true;
    [ObservableProperty] private bool _increaseWhereCurrentView;
    [ObservableProperty] private bool _increaseWhereVisibleInView;

    [ObservableProperty] private bool _increaseHowAddToCurrent = true;
    [ObservableProperty] private bool _increaseHowCreateNew;

    [ObservableProperty] private bool _increaseUnselectBelongsToGroup;
    [ObservableProperty] private bool _increaseUnselectBelongsToAssembly;
    
    private List<string> _activeGroupings = new List<string>();

    [ObservableProperty] private SelectionScope _currentScope = SelectionScope.CurrentSelection;
    private HashSet<Autodesk.Revit.DB.ElementId> _persistentCheckedIds = new(new ElementIdEqualityComparer());

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

    private int FindMaxTreeDepth(IEnumerable<TreeItemViewModel> nodes)
    {
        int max = 0;
        foreach (var node in nodes)
        {
            if (node.Level > max) max = node.Level;
            if (node.Children.Count > 0)
            {
                int childMax = FindMaxTreeDepth(node.Children);
                if (childMax > max) max = childMax;
            }
        }
        return max;
    }

    [RelayCommand]
    private void OpenConfiguration()
    {
        var configView = new Views.ConfigurationView();
        configView.ShowDialog();
    }

    private bool _isRestoringState = false;
    private bool _isInitializing = false;
    private int _lastExpandedDepth = 0;

    private void OnTreeSelectionChanged()
    {
        if (TreeItemViewModel.IsBulkUpdating) return;
        
        UpdatePersistentCheckedIdsFromTree();
        
        if (IsLiveSelection)
        {
            ApplyFilter();
        }
    }

    /// <summary>
    /// Constructor: called in Revit API context. Pre-fetches all scope data safely here.
    /// </summary>
    public SelectionFilterViewModel(RevitSelectionService selectionService)
    {
        LoggerService.LogInfo("SelectionFilterViewModel initializing...");
        _selectionService = selectionService;
        
        try 
        {
            // 1. Get initial selection IDs from Revit (safe: API context)
            _persistentCheckedIds = _selectionService.GetInitialSelectionIds();
            LoggerService.LogInfo($"Initial selection IDs count: {_persistentCheckedIds.Count}");

            // 2. Pre-fetch all scopes NOW (we are in Revit API thread)
            LoggerService.LogInfo("Pre-fetching CurrentSelection elements...");
            _currentSelectionElements = _selectionService.GetAvailableElements(SelectionScope.CurrentSelection);
            LoggerService.LogInfo($"CurrentSelection: {_currentSelectionElements.Count} elements.");

            LoggerService.LogInfo("Pre-fetching ElementsVisibleInView elements...");
            _elementsVisibleInViewElements = _selectionService.GetAvailableElements(SelectionScope.ElementsVisibleInView);
            LoggerService.LogInfo($"ElementsVisibleInView: {_elementsVisibleInViewElements.Count} elements.");

            LoggerService.LogInfo("Pre-fetching ElementsBelongingToView elements...");
            _elementsBelongingToViewElements = _selectionService.GetAvailableElements(SelectionScope.ElementsBelongingToView);
            LoggerService.LogInfo($"ElementsBelongingToView: {_elementsBelongingToViewElements.Count} elements.");

            LoggerService.LogInfo("Pre-fetching AllModelElements elements...");
            var allRaw = _selectionService.GetAvailableElements(SelectionScope.AllModelElements);
            _allModelElements = allRaw.Count > 10000 ? allRaw.Take(10000).ToList() : allRaw;
            LoggerService.LogInfo($"AllModelElements: {_allModelElements.Count} elements (raw: {allRaw.Count}).");

            // 3. Build tree for the default scope (CurrentSelection)
            _activeElements = _currentSelectionElements;
            BuildTree();
        }
        catch (Exception ex)
        {
            LoggerService.LogError("ViewModel Constructor", ex);
        }
    }

    /// <summary>
    /// Called when scope radio button changes. NO Revit API calls here – uses pre-fetched data.
    /// </summary>
    partial void OnCurrentScopeChanged(SelectionScope value)
    {
        if (TreeItemViewModel.IsBulkUpdating) return;

        try
        {
            LoggerService.LogInfo($"Scope switched to: {value}. Rebuilding tree from pre-fetched data...");

            _activeElements = value switch
            {
                SelectionScope.CurrentSelection => _currentSelectionElements,
                SelectionScope.ElementsVisibleInView => _elementsVisibleInViewElements,
                SelectionScope.ElementsBelongingToView => _elementsBelongingToViewElements,
                SelectionScope.AllModelElements => _allModelElements,
                _                               => _currentSelectionElements
            };

            LoggerService.LogInfo($"Active elements for scope {value}: {_activeElements.Count}");
            BuildTree();
        }
        catch (Exception ex)
        {
            LoggerService.LogError("OnCurrentScopeChanged", ex);
        }
    }

    partial void OnIsOnly3DModelsChanged(bool value)
    {
        if (value)
        {
            IsOnlyAnnotation = false;
            HasBoundingBox = false;
            UncheckHiddenElements(e => !e.IsModelElement);
        }
        BuildTree();
    }

    partial void OnIsOnlyAnnotationChanged(bool value)
    {
        if (value)
        {
            IsOnly3DModels = false;
            HasBoundingBox = false;
            UncheckHiddenElements(e => !e.IsAnnotation);
        }
        BuildTree();
    }

    partial void OnHasBoundingBoxChanged(bool value)
    {
        if (value)
        {
            IsOnly3DModels = false;
            IsOnlyAnnotation = false;
            UncheckHiddenElements(e => !e.HasBoundingBox);
        }
        BuildTree();
    }

    private void UncheckHiddenElements(Func<ElementModel, bool> isHiddenPredicate)
    {
        if (_activeElements == null) return;
        
        var hiddenIds = _activeElements.Where(isHiddenPredicate).Select(e => e.Id).ToList();
        bool changed = false;
        foreach (var id in hiddenIds)
        {
            if (_persistentCheckedIds.Contains(id))
            {
                _persistentCheckedIds.Remove(id);
                changed = true;
            }
        }
        if (changed) CheckedElementsCount = _persistentCheckedIds.Count;
    }

    partial void OnIsLiveSelectionChanged(bool value)
    {
        if (value)
        {
            ApplyFilter();
        }
    }

    partial void OnSortByPhaseChanged(bool value)
    {
        if (value) { if (!_activeGroupings.Contains("Phase")) _activeGroupings.Add("Phase"); }
        else _activeGroupings.Remove("Phase");
        BuildTree();
    }

    partial void OnSortByLevelChanged(bool value)
    {
        if (value) { if (!_activeGroupings.Contains("Level")) _activeGroupings.Add("Level"); }
        else _activeGroupings.Remove("Level");
        BuildTree();
    }

    partial void OnSortByWorksetChanged(bool value)
    {
        if (value) { if (!_activeGroupings.Contains("Workset")) _activeGroupings.Add("Workset"); }
        else _activeGroupings.Remove("Workset");
        BuildTree();
    }

    private IEnumerable<ElementModel> GetFilteredElements()
    {
        if (_activeElements == null) return Enumerable.Empty<ElementModel>();
        
        var filtered = _activeElements.AsEnumerable();
        
        if (IsOnly3DModels) filtered = filtered.Where(e => e.IsModelElement);
        if (IsOnlyAnnotation) filtered = filtered.Where(e => e.IsAnnotation);
        if (HasBoundingBox) filtered = filtered.Where(e => e.HasBoundingBox);
        
        return filtered;
    }

    /// <summary>Rebuilds dropdowns and the tree from _activeElements. Safe to call from UI thread.</summary>
    private void BuildTree()
    {
        IsBusy = true;
        TreeItemViewModel.IsBulkUpdating = true;
        LoggerService.LogInfo($"BuildTree: {_activeElements.Count} elements for scope {CurrentScope}.");

        try
        {
            int semanticExpansionLevel = 0; // Default semantic depth
            bool hasPreviousState = false;

            if (RootNodes != null && RootNodes.Any())
            {
                hasPreviousState = true;
                int oldMaxDepth = FindMaxTreeDepth(RootNodes);
                int oldG = oldMaxDepth - 4; // Base elements start at Level 4 with 0 groupings
                if (oldG < 0) oldG = 0;

                int lowestUnexpanded = FindLowestUnexpandedLevel(RootNodes);
                int oldExpandedLevel = (lowestUnexpanded != int.MaxValue) ? lowestUnexpanded - 1 : FindHighestExpandedLevel(RootNodes);
                
                semanticExpansionLevel = oldExpandedLevel - oldG;
            }

            var filtered = GetFilteredElements().ToList();
            StatusMessage = $"Elementos encontrados: {filtered.Count}";
            UpdateDropdowns(filtered);
            InitializeTree(filtered, !hasPreviousState);

            // Restore the semantic expansion depth
            if (hasPreviousState && RootNodes != null)
            {
                int newG = _activeGroupings.Count;
                int newExpandedLevel = newG + semanticExpansionLevel;

                for (int i = 0; i <= newExpandedLevel; i++)
                {
                    SetExpandedStateAtLevel(RootNodes, i, true);
                }
            }
        }
        catch (Exception ex)
        {
            LoggerService.LogError("BuildTree", ex);
        }
        finally
        {
            foreach (var node in RootNodes) node.RefreshState();
            TreeItemViewModel.IsBulkUpdating = false;
            OnTreeSelectionChanged();
            IsBusy = false;
            LoggerService.LogInfo("BuildTree completed.");
        }
    }

    private void UpdateDropdowns(IEnumerable<ElementModel> filteredElements)
    {
        LoggerService.LogInfo("Updating filter dropdowns...");
        var elements = filteredElements.ToList();
        // Guardar selecciones actuales
        var prevCat = SelectedCategory;
        var prevFam = SelectedFamily;
        var prevType = SelectedType;

        Categories.Clear();
        Families.Clear();
        Types.Clear();
        Levels.Clear();
        Worksets.Clear();

        Categories.Add("Todos");
        Families.Add("Todos");
        Types.Add("Todos");
        Levels.Add("Todos");
        Worksets.Add("Todos");

        foreach (var cat in elements.Select(e => e.CategoryName).Distinct().OrderBy(x => x))
            Categories.Add(cat);
        foreach (var fam in elements.Select(e => e.FamilyName).Distinct().OrderBy(x => x))
            Families.Add(fam);
        foreach (var type in elements.Select(e => e.TypeName).Distinct().OrderBy(x => x))
            Types.Add(type);
        foreach (var lev in elements.Select(e => e.LevelName).Distinct().OrderBy(x => x))
            Levels.Add(lev);
        foreach (var ws in elements.Select(e => e.WorksetName).Distinct().OrderBy(x => x))
            Worksets.Add(ws);

        // Restore previous selection if still valid
        SelectedCategory = Categories.Contains(prevCat) ? prevCat : "Todos";
        SelectedFamily   = Families.Contains(prevFam)   ? prevFam : "Todos";
        SelectedType     = Types.Contains(prevType)     ? prevType : "Todos";
    }

    private void BuildCategorySubTree(IEnumerable<ElementModel> elementsInCategory, TreeItemViewModel catNode)
    {
        int catCount = 0;
        var families = elementsInCategory.GroupBy(e => e.FamilyName).OrderBy(g => g.Key);

        foreach (var famGroup in families)
        {
            var famNode = new TreeItemViewModel(famGroup.Key, catNode, catNode.Level + 1, OnTreeSelectionChanged);
            catNode.Children.Add(famNode);
            int famCount = 0;

            var types = famGroup.GroupBy(e => e.TypeName).OrderBy(g => g.Key);

            foreach (var typeGroup in types)
            {
                var typeNode = new TreeItemViewModel(typeGroup.Key, famNode, famNode.Level + 1, OnTreeSelectionChanged);
                famNode.Children.Add(typeNode);
                int strCount = 0;

                foreach (var element in typeGroup.OrderBy(e => e.Id.ToString()))
                {
                    var elNode = new TreeItemViewModel(element.Id.ToString(), typeNode, typeNode.Level + 1, OnTreeSelectionChanged)
                    {
                        ElementId = element.Id,
                        SearchableMetadata = element.SearchableMetadata
                    };
                    typeNode.Children.Add(elNode);
                    strCount++;
                }
                typeNode.Count = strCount;
                famCount += strCount;
            }
            famNode.Count = famCount;
            catCount += famCount;
        }
        catNode.Count = catCount;
    }

    private void BuildGroupedTree(IEnumerable<ElementModel> elements, TreeItemViewModel parentNode, int groupingIndex)
    {
        if (groupingIndex >= _activeGroupings.Count)
        {
            var categories = elements.GroupBy(e => e.CategoryName).OrderBy(g => g.Key);
            foreach (var catGroup in categories)
            {
                var catNode = new TreeItemViewModel(catGroup.Key, parentNode, parentNode.Level + 1, OnTreeSelectionChanged);
                parentNode.Children.Add(catNode);
                BuildCategorySubTree(catGroup, catNode);
            }
            parentNode.Count = parentNode.Children.Sum(c => c.Count);
            return;
        }

        string groupingType = _activeGroupings[groupingIndex];
        if (groupingType == "Phase")
        {
            var phases = elements.GroupBy(e => new { e.PhaseName, e.PhaseOrder }).OrderBy(g => g.Key.PhaseOrder);
            foreach (var phaseGroup in phases)
            {
                var phaseNode = new TreeItemViewModel(phaseGroup.Key.PhaseName, parentNode, parentNode.Level + 1, OnTreeSelectionChanged);
                parentNode.Children.Add(phaseNode);
                BuildGroupedTree(phaseGroup, phaseNode, groupingIndex + 1);
            }
            parentNode.Count = parentNode.Children.Sum(c => c.Count);
        }
        else if (groupingType == "Level")
        {
            var levels = elements.GroupBy(e => string.IsNullOrEmpty(e.LevelName) ? "None" : e.LevelName).OrderBy(g => g.Key);
            foreach (var levelGroup in levels)
            {
                var levelNode = new TreeItemViewModel(levelGroup.Key, parentNode, parentNode.Level + 1, OnTreeSelectionChanged);
                parentNode.Children.Add(levelNode);
                BuildGroupedTree(levelGroup, levelNode, groupingIndex + 1);
            }
            parentNode.Count = parentNode.Children.Sum(c => c.Count);
        }
        else if (groupingType == "Workset")
        {
            var worksets = elements.GroupBy(e => string.IsNullOrEmpty(e.WorksetName) ? "None" : e.WorksetName).OrderBy(g => g.Key);
            foreach (var wsGroup in worksets)
            {
                var wsNode = new TreeItemViewModel(wsGroup.Key, parentNode, parentNode.Level + 1, OnTreeSelectionChanged);
                parentNode.Children.Add(wsNode);
                BuildGroupedTree(wsGroup, wsNode, groupingIndex + 1);
            }
            parentNode.Count = parentNode.Children.Sum(c => c.Count);
        }
    }

    private void InitializeTree(IEnumerable<ElementModel> filteredElements, bool forceExpand)
    {
        try 
        {
            var elements = filteredElements.ToList();
            LoggerService.LogInfo($"Building tree structure offline for {elements.Count} elements...");
            var rootAll = new TreeItemViewModel("All", null, 0, OnTreeSelectionChanged);
            
            BuildGroupedTree(elements, rootAll, 0);

            rootAll.Count = rootAll.Children.Sum(c => c.Count);

            if (_persistentCheckedIds.Count > 0)
            {
                LoggerService.LogInfo($"Applying selection state for {_persistentCheckedIds.Count} checked elements...");
                ApplyInitialSelection(rootAll, _persistentCheckedIds, forceExpand);
            }

            rootAll.IsExpanded = true;

            // Swap RootNodes on UI thread
            var uiDispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
            if (uiDispatcher.CheckAccess())
            {
                LoggerService.LogInfo($"Swapping tree root directly. New total: {rootAll.Count}");
                RootNodes.Clear();
                RootNodes.Add(rootAll);
            }
            else
            {
                uiDispatcher.Invoke(() => {
                    RootNodes.Clear();
                    RootNodes.Add(rootAll);
                });
            }
            
            LoggerService.LogInfo($"Tree built and swapped. {rootAll.Count} visible elements.");
        }
        catch (Exception ex)
        {
            LoggerService.LogError("InitializeTree", ex);
        }
    }

    private bool ApplyInitialSelection(TreeItemViewModel node, HashSet<Autodesk.Revit.DB.ElementId> selectedIds, bool forceExpand)
    {
        if (node.Children.Count == 0)
        {
            if (node.ElementId != null && selectedIds.Contains(node.ElementId))
            {
                node.IsChecked = true;
                return true;
            }
            return false;
        }

        bool hasCheckedChildren = false;
        foreach (var child in node.Children)
        {
            if (ApplyInitialSelection(child, selectedIds, forceExpand))
                hasCheckedChildren = true;
        }

        if (hasCheckedChildren && forceExpand) node.IsExpanded = true;
        return hasCheckedChildren;
    }

    public void SetExternalEvent(Autodesk.Revit.UI.ExternalEvent externalEvent)
    {
        _pickElementsEvent = externalEvent;
    }

    public void SetActionEventHandler(FilterPlus.Services.ActionEventHandler handler, Autodesk.Revit.UI.ExternalEvent externalEvent)
    {
        _actionHandler = handler;
        _actionExternalEvent = externalEvent;
    }

    [RelayCommand]
    private void PickElements()
    {
        // 1. Apply current selection so it's visible in Revit
        ApplyFilter();

        // 2. Hide the addin window
        HideWindowRequested?.Invoke();

        // 3. Trigger the external event for PickObjects
        _pickElementsEvent?.Raise();
    }

    public void OnPickElementsFinished(List<Autodesk.Revit.DB.ElementId> newIds)
    {
        var dispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
        dispatcher.InvokeAsync(() =>
        {
            if (newIds != null && newIds.Count > 0)
            {
                // Add new IDs to the persistent selection
                foreach (var id in newIds)
                {
                    _persistentCheckedIds.Add(id);
                }

                // Ensure newly picked elements are injected into the active elements so they show up in the tree!
                var allKnownById = _allModelElements.ToDictionary(e => e.Id);
                foreach (var id in newIds)
                {
                    if (allKnownById.TryGetValue(id, out var model))
                    {
                        if (_activeElements != null && !_activeElements.Any(e => e.Id == id))
                        {
                            _activeElements.Add(model);
                        }
                    }
                }

                // Force a tree refresh so the newly selected items are checked
                BuildTree();
            }

            // Restore the window
            ShowWindowRequested?.Invoke();
        });
    }

    private void UpdatePersistentCheckedIdsFromTree()
    {
        var selectedIdsInTree = new List<Autodesk.Revit.DB.ElementId>();
        foreach (var node in RootNodes) node.GetAllSelectedIds(selectedIdsInTree);

        var activeElementIds = _activeElements?.Select(e => e.Id).ToHashSet() ?? new HashSet<Autodesk.Revit.DB.ElementId>();
        
        // Mantener los IDs que estaban checkeados pero que no pertenecen al scope/filtro actual
        var idsFromOtherScopes = _persistentCheckedIds.Where(id => !activeElementIds.Contains(id));
        
        _persistentCheckedIds = selectedIdsInTree.Concat(idsFromOtherScopes).ToHashSet();
        CheckedElementsCount = _persistentCheckedIds.Count;
    }

    [RelayCommand]
    private void ApplyFilter()
    {
        try
        {
            // ── 1. Actualizar el estado persistente de IDs marcados ────────────────
            UpdatePersistentCheckedIdsFromTree();

            var finalIds = _persistentCheckedIds.ToList();
            StatusMessage = $"Seleccionados: {finalIds.Count}";

            // ── 2. Aplicar la selección en Revit ───────────────────────────────────
            _selectionService.SetSelection(finalIds);

            // ── 4. Reconstruir _currentSelectionElements desde TODOS los scopes ────
            // Buscamos el ElementModel de cada ID seleccionado en el pool completo,
            // así no se pierden elementos que no estuvieran en el scope activo actual.
            var allKnownById = _currentSelectionElements
                .Concat(_elementsVisibleInViewElements)
                .Concat(_elementsBelongingToViewElements)
                .Concat(_allModelElements)
                .GroupBy(e => e.Id)
                .Select(g => g.First())
                .ToDictionary(e => e.Id);

            _currentSelectionElements = _persistentCheckedIds
                .Where(id => allKnownById.ContainsKey(id))
                .Select(id => allKnownById[id])
                .ToList();

            LoggerService.LogInfo(
                $"Apply Selection: {_persistentCheckedIds.Count} IDs applied. " +
                $"CurrentSelection updated to {_currentSelectionElements.Count} elements.");

            // Clear search text if it exists, without reverting the selection in the UI
            if (!string.IsNullOrEmpty(FilterText))
            {
                var dispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
                dispatcher.InvokeAsync(() =>
                {
                    FilterText = string.Empty;
                });
            }
        }
        catch (Exception ex)
        {
            LoggerService.LogError("Applying Filter", ex);
        }
    }

    [RelayCommand]
    private void ClearFilters()
    {
        SelectedCategory = "Todos";
        SelectedFamily = "Todos";
        SelectedType = "Todos";
        SelectedLevel = "Todos";
        SelectedWorkset = "Todos";
        foreach(var node in RootNodes) node.IsChecked = false;
        ApplyFilter();
    }

    [RelayCommand]
    private void ApplySearch()
    {
        string searchText = FilterText;
        if (string.IsNullOrWhiteSpace(searchText)) return;

        System.Text.RegularExpressions.Regex searchRegex = null;

        if (IsUseRegex)
        {
            try
            {
                // Compile regex with a 2-second timeout to prevent ReDoS (Regular Expression Denial of Service) attacks
                searchRegex = new System.Text.RegularExpressions.Regex(
                    searchText, 
                    System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Compiled,
                    TimeSpan.FromSeconds(2));
            }
            catch (Exception ex)
            {
                // Invalid regex syntax or other parsing error
                LoggerService.LogInfo("Invalid regex pattern: " + ex.Message);
                StatusMessage = "Invalid Regex Pattern";
                return; // Stop the search safely
            }
        }
        else
        {
            // Only sanitize input if we are NOT using Regex, otherwise we strip valid regex tokens
            searchText = SecurityUtils.SanitizeInput(searchText).ToLowerInvariant();
        }

        TreeItemViewModel.IsBulkUpdating = true;

        // If Use OR is OFF, the new search replaces the current selection.
        if (!IsUseOr)
        {
            foreach (var node in RootNodes) node.SetCheckedState(false);
        }

        // Apply the current search matches
        foreach (var node in RootNodes)
            FilterNode(node, searchText, searchRegex, false);

        // Ensure parent nodes reflect child states properly
        foreach (var node in RootNodes) node.RefreshState();

        TreeItemViewModel.IsBulkUpdating = false;
        OnTreeSelectionChanged();

        // Clear the text box after applying
        FilterText = string.Empty;
    }

    private FilterPlus.Services.ActionEventHandler _actionHandler;
    private Autodesk.Revit.UI.ExternalEvent _actionExternalEvent;

    [RelayCommand]
    private void ApplyIncreaseChecked()
    {
        if (_actionHandler == null || _actionExternalEvent == null)
        {
            LoggerService.LogError("ApplyIncreaseChecked", new System.InvalidOperationException("ActionEventHandler not initialized."));
            return;
        }

        LoggerService.LogInfo($"[ApplyIncreaseChecked] START. Current Scope in Select: {CurrentScope}. _activeElements count: {(_activeElements?.Count ?? 0)}.");
        StatusMessage = "Processing...";
        
        _actionHandler.Raise(() =>
        {
            try
            {
                TreeItemViewModel.IsBulkUpdating = true;
            
            // 1. Get currently checked ElementIds from the tree
            var currentCheckedIds = new List<Autodesk.Revit.DB.ElementId>();
            foreach (var node in RootNodes)
                node.GetAllSelectedIds(currentCheckedIds);
                
            LoggerService.LogInfo($"[ApplyIncreaseChecked] Checked elements in explorer tree: {currentCheckedIds.Count}. IDs: {string.Join(", ", currentCheckedIds)}");

            if (currentCheckedIds.Count == 0)
            {
                TreeItemViewModel.IsBulkUpdating = false;
                StatusMessage = "No elements selected in the tree to expand.";
                return;
            }

            var doc = _selectionService.Document;
            var sourceElements = currentCheckedIds.Select(id => doc.GetElement(id)).Where(e => e != null).ToList();

            // 2. Define search domain based on WHERE
            // Query Revit database directly to avoid any 10,000 pre-fetch limit during selection expansion
            List<Autodesk.Revit.DB.Element> domainElements;
            if (IncreaseWhereVisibleInView)
            {
                // Match "Elements Visible" (SelectionScope.ElementsVisibleInView)
                var visibleCollector = new Autodesk.Revit.DB.FilteredElementCollector(doc, doc.ActiveView.Id);
                domainElements = visibleCollector.WhereElementIsNotElementType().ToElements().ToList();
                LoggerService.LogInfo($"[ApplyIncreaseChecked] Domain: Visible in current view. Collector count: {domainElements.Count}.");
            }
            else if (IncreaseWhereCurrentView)
            {
                // Match "Elements in View" (SelectionScope.ElementsBelongingToView)
                var viewCollector = new Autodesk.Revit.DB.FilteredElementCollector(doc);
                domainElements = viewCollector.WhereElementIsNotElementType().ToElements()
                    .Where(el => el.OwnerViewId == doc.ActiveView.Id || el.get_BoundingBox(doc.ActiveView) != null)
                    .ToList();
                LoggerService.LogInfo($"[ApplyIncreaseChecked] Domain: Current View. Collector count: {domainElements.Count}.");
            }
            else
            {
                var modelCollector = new Autodesk.Revit.DB.FilteredElementCollector(doc);
                domainElements = modelCollector.WhereElementIsNotElementType().ToElements().ToList();
                LoggerService.LogInfo($"[ApplyIncreaseChecked] Domain: All Model. Collector count: {domainElements.Count}.");
            }
            
            var targetIds = new HashSet<Autodesk.Revit.DB.ElementId>(new ElementIdEqualityComparer());
            
            // 3. Apply WHAT rules
            if (IncreaseWhatSameCategory)
            {
                var targetCatIds = new HashSet<Autodesk.Revit.DB.ElementId>(
                    sourceElements.Select(e => e.Category?.Id).Where(id => id != null),
                    new ElementIdEqualityComparer()
                );
                foreach (var el in domainElements)
                {
                    if (el.Category != null && targetCatIds.Contains(el.Category.Id))
                        targetIds.Add(el.Id);
                }
                LoggerService.LogInfo($"[ApplyIncreaseChecked] Checked 'Same Category'. Accumulative targets: {targetIds.Count}.");
            }
            if (IncreaseWhatSameFamily || IncreaseWhatSameType)
            {
                var targetFamilyNames = new HashSet<string>();
                var targetTypeIds = new HashSet<Autodesk.Revit.DB.ElementId>(new ElementIdEqualityComparer());
                
                foreach (var el in sourceElements)
                {
                    var typeId = el.GetTypeId();
                    if (typeId != null && typeId != Autodesk.Revit.DB.ElementId.InvalidElementId)
                    {
                        targetTypeIds.Add(typeId);
                        var type = doc.GetElement(typeId) as Autodesk.Revit.DB.ElementType;
                        if (type != null && !string.IsNullOrEmpty(type.FamilyName))
                        {
                            targetFamilyNames.Add(type.FamilyName);
                        }
                    }
                }
                
                foreach (var el in domainElements)
                {
                    var typeId = el.GetTypeId();
                    if (typeId == null || typeId == Autodesk.Revit.DB.ElementId.InvalidElementId) continue;

                    if (IncreaseWhatSameType)
                    {
                        if (targetTypeIds.Contains(typeId))
                            targetIds.Add(el.Id);
                    }
                    else if (IncreaseWhatSameFamily)
                    {
                        var type = doc.GetElement(typeId) as Autodesk.Revit.DB.ElementType;
                        if (type != null && !string.IsNullOrEmpty(type.FamilyName) && targetFamilyNames.Contains(type.FamilyName))
                        {
                            targetIds.Add(el.Id);
                        }
                    }
                }
                LoggerService.LogInfo($"[ApplyIncreaseChecked] Checked 'Same Family/Type'. Accumulative targets: {targetIds.Count}.");
            }
            if (IncreaseWhatSameWorkset && doc.IsWorkshared)
            {
                var targetWorksetIds = sourceElements.Select(e => e.WorksetId).Where(id => id != Autodesk.Revit.DB.WorksetId.InvalidWorksetId).ToHashSet();
                foreach (var el in domainElements)
                {
                    if (targetWorksetIds.Contains(el.WorksetId))
                        targetIds.Add(el.Id);
                }
                LoggerService.LogInfo($"[ApplyIncreaseChecked] Checked 'Same Workset'. Accumulative targets: {targetIds.Count}.");
            }
            if (IncreaseWhatHostOfElement)
            {
                foreach (var el in sourceElements)
                {
                    if (el is Autodesk.Revit.DB.FamilyInstance fi && fi.Host != null)
                        targetIds.Add(fi.Host.Id);
                }
                LoggerService.LogInfo($"[ApplyIncreaseChecked] Checked 'Host of Element'. Accumulative targets: {targetIds.Count}.");
            }
            if (IncreaseWhatHostedElements)
            {
                var sourceIdsHash = sourceElements.Select(e => e.Id).ToHashSet();
                foreach (var el in domainElements)
                {
                    if (el is Autodesk.Revit.DB.FamilyInstance fi && fi.Host != null && sourceIdsHash.Contains(fi.Host.Id))
                        targetIds.Add(el.Id);
                }
                LoggerService.LogInfo($"[ApplyIncreaseChecked] Checked 'Hosted Elements'. Accumulative targets: {targetIds.Count}.");
            }
            if (IncreaseWhatNestedElements)
            {
                foreach (var el in sourceElements)
                {
                    if (el is Autodesk.Revit.DB.FamilyInstance fi)
                    {
                        var subComponents = fi.GetSubComponentIds();
                        foreach (var subId in subComponents) targetIds.Add(subId);
                    }
                }
                LoggerService.LogInfo($"[ApplyIncreaseChecked] Checked 'Nested Elements'. Accumulative targets: {targetIds.Count}.");
            }
            if (IncreaseWhatJoinedElements)
            {
                foreach (var el in sourceElements)
                {
                    try {
                        var joined = Autodesk.Revit.DB.JoinGeometryUtils.GetJoinedElements(doc, el);
                        foreach (var jId in joined) targetIds.Add(jId);
                    } catch {} // Fails for elements that cannot be joined
                }
                LoggerService.LogInfo($"[ApplyIncreaseChecked] Checked 'Joined Elements'. Accumulative targets: {targetIds.Count}.");
            }
            if (IncreaseWhatSupercomponent)
            {
                foreach (var el in sourceElements)
                {
                    if (el is Autodesk.Revit.DB.FamilyInstance fi && fi.SuperComponent != null)
                    {
                        targetIds.Add(fi.SuperComponent.Id);
                    }
                }
                LoggerService.LogInfo($"[ApplyIncreaseChecked] Checked 'Supercomponent'. Accumulative targets: {targetIds.Count}.");
            }
            if (IncreaseWhatGroupOfAssembly)
            {
                foreach (var el in sourceElements)
                {
                    if (el.GroupId != Autodesk.Revit.DB.ElementId.InvalidElementId)
                    {
                        var group = doc.GetElement(el.GroupId) as Autodesk.Revit.DB.Group;
                        if (group != null)
                        {
                            foreach (var memberId in group.GetMemberIds()) targetIds.Add(memberId);
                        }
                    }
                    if (el.AssemblyInstanceId != Autodesk.Revit.DB.ElementId.InvalidElementId)
                    {
                        var assembly = doc.GetElement(el.AssemblyInstanceId) as Autodesk.Revit.DB.AssemblyInstance;
                        if (assembly != null)
                        {
                            foreach (var memberId in assembly.GetMemberIds()) targetIds.Add(memberId);
                        }
                    }
                }
                LoggerService.LogInfo($"[ApplyIncreaseChecked] Checked 'Group or Assembly'. Accumulative targets: {targetIds.Count}.");
            }
            if (IncreaseWhatDependent)
            {
                foreach (var el in sourceElements)
                {
                    try
                    {
                        var dependentIds = el.GetDependentElements(null);
                        foreach (var depId in dependentIds) targetIds.Add(depId);
                    } catch {}
                }
                LoggerService.LogInfo($"[ApplyIncreaseChecked] Checked 'Dependent Elements'. Accumulative targets: {targetIds.Count}.");
            }
            if (IncreaseWhatIntersects && domainElements.Count > 0)
            {
                var domainIds = domainElements.Select(e => e.Id).ToList();
                foreach (var el in sourceElements)
                {
                    try
                    {
                        var intersects = new Autodesk.Revit.DB.FilteredElementCollector(doc, domainIds)
                            .WherePasses(new Autodesk.Revit.DB.ElementIntersectsElementFilter(el))
                            .ToElementIds();
                        foreach (var id in intersects) targetIds.Add(id);
                    }
                    catch { } // Some elements cannot be used in intersection filters
                }
                LoggerService.LogInfo($"[ApplyIncreaseChecked] Checked 'Intersects'. Accumulative targets: {targetIds.Count}.");
            }
            if (IncreaseWhatSameMEPSystem)
            {
                foreach (var el in sourceElements)
                {
                    Autodesk.Revit.DB.ConnectorManager cm = null;
                    if (el is Autodesk.Revit.DB.FamilyInstance fi && fi.MEPModel != null)
                        cm = fi.MEPModel.ConnectorManager;
                    else if (el is Autodesk.Revit.DB.MEPCurve mepCurve)
                        cm = mepCurve.ConnectorManager;
                    
                    if (cm != null)
                    {
                        foreach (Autodesk.Revit.DB.Connector conn in cm.Connectors)
                        {
                            var mepSystem = conn.MEPSystem;
                            if (mepSystem != null)
                            {
                                foreach (Autodesk.Revit.DB.Element sysEl in mepSystem.Elements)
                                    targetIds.Add(sysEl.Id);
                            }
                        }
                    }
                }
                LoggerService.LogInfo($"[ApplyIncreaseChecked] Checked 'MEP System'. Accumulative targets: {targetIds.Count}.");
            }
            
            // 4. Unify with current and other scopes
            var activeElementIds = new HashSet<Autodesk.Revit.DB.ElementId>(
                _activeElements?.Select(e => e.Id) ?? System.Linq.Enumerable.Empty<Autodesk.Revit.DB.ElementId>(),
                new ElementIdEqualityComparer()
            );
            var idsFromOtherScopes = _persistentCheckedIds.Where(id => !activeElementIds.Contains(id)).ToList();

            var finalCheckedIds = new HashSet<Autodesk.Revit.DB.ElementId>(new ElementIdEqualityComparer());
            if (IncreaseHowAddToCurrent)
            {
                foreach (var id in currentCheckedIds) finalCheckedIds.Add(id);
            }
            foreach (var id in targetIds)
            {
                finalCheckedIds.Add(id);
            }
            foreach (var id in idsFromOtherScopes)
            {
                finalCheckedIds.Add(id);
            }

            // 5. Exclusions (UNSELECT ELEMENTS IF) - applies to the unified finalCheckedIds to purge the selection
            if (IncreaseUnselectBelongsToGroup || IncreaseUnselectBelongsToAssembly)
            {
                var purgedCheckedIds = new HashSet<Autodesk.Revit.DB.ElementId>(new ElementIdEqualityComparer());
                foreach (var id in finalCheckedIds)
                {
                    var el = doc.GetElement(id);
                    if (el == null) continue;
                    
                    if (IncreaseUnselectBelongsToGroup && el.GroupId != Autodesk.Revit.DB.ElementId.InvalidElementId)
                        continue;
                    if (IncreaseUnselectBelongsToAssembly && el.AssemblyInstanceId != Autodesk.Revit.DB.ElementId.InvalidElementId)
                        continue;
                        
                    purgedCheckedIds.Add(id);
                }
                
                // Keep targetIds in sync so we don't inject excluded elements
                targetIds.IntersectWith(purgedCheckedIds);
                
                finalCheckedIds = purgedCheckedIds;
                LoggerService.LogInfo($"[ApplyIncreaseChecked] Checked exclusions. Final targets after purging: {finalCheckedIds.Count}.");
            }
            
            LoggerService.LogInfo($"[ApplyIncreaseChecked] Final checked IDs unified (including other scopes): {finalCheckedIds.Count}. IDs: {string.Join(", ", finalCheckedIds)}");

            // 6. Inject newly matched elements into _activeElements (if they aren't already in it)
            var activeIds = new HashSet<Autodesk.Revit.DB.ElementId>(
                _activeElements.Select(e => e.Id),
                new ElementIdEqualityComparer()
            );
            LoggerService.LogInfo($"[ApplyIncreaseChecked] Explorer tree currently has {activeIds.Count} active IDs.");
            
            // Build a unified dictionary of all pre-fetched element models for O(1) reuse
            var allKnownById = _allModelElements
                .Concat(_elementsVisibleInViewElements)
                .Concat(_elementsBelongingToViewElements)
                .Concat(_currentSelectionElements)
                .GroupBy(e => e.Id)
                .Select(g => g.First())
                .ToDictionary(e => e.Id, new ElementIdEqualityComparer());
                
            LoggerService.LogInfo($"[ApplyIncreaseChecked] Pre-fetched scopes unified cache has {allKnownById.Count} elements.");

            var elementsToInject = new List<ElementModel>();
            foreach (var id in targetIds)
            {
                if (activeIds.Contains(id))
                {
                    LoggerService.LogInfo($"[ApplyIncreaseChecked] Element {id} is already in activeIds, skipping injection.");
                    continue;
                }
                
                if (allKnownById.TryGetValue(id, out var existingModel))
                {
                    LoggerService.LogInfo($"[ApplyIncreaseChecked] Element {id} found in pre-fetched cache. Injecting model.");
                    elementsToInject.Add(existingModel);
                }
                else
                {
                    // Map on the fly from Revit Element if not pre-fetched
                    var el = doc.GetElement(id);
                    if (el != null && el.Category != null)
                    {
                        var newModel = _selectionService.MapToElementModel(el);
                        if (newModel != null)
                        {
                            LoggerService.LogInfo($"[ApplyIncreaseChecked] Element {id} ({el.Name}) NOT in pre-fetched cache. Mapped on-the-fly and injecting.");
                            elementsToInject.Add(newModel);
                        }
                        else
                        {
                            LoggerService.LogInfo($"[ApplyIncreaseChecked] Element {id} failed to map to ElementModel.");
                        }
                    }
                    else
                    {
                        LoggerService.LogInfo($"[ApplyIncreaseChecked] Element {id} not found in doc, or has null Category.");
                    }
                }
            }
                
            if (elementsToInject.Count > 0)
            {
                LoggerService.LogInfo($"[ApplyIncreaseChecked] Injecting {elementsToInject.Count} elements into active elements list.");
                _activeElements.AddRange(elementsToInject);
            }
            else
            {
                LoggerService.LogInfo($"[ApplyIncreaseChecked] No new elements needed to be injected.");
            }

            // 7. Update persistent checked IDs
            _persistentCheckedIds = finalCheckedIds;
            LoggerService.LogInfo($"[ApplyIncreaseChecked] Updating _persistentCheckedIds to: {string.Join(", ", _persistentCheckedIds)}");
            
            // 8. Rebuild tree to show newly injected elements and apply check states
            LoggerService.LogInfo($"[ApplyIncreaseChecked] Invoking BuildTree() now...");
            BuildTree();
            
            StatusMessage = $"Increase applied. Total checked: {CheckedElementsCount}";
            LoggerService.LogInfo($"[ApplyIncreaseChecked] COMPLETE. Status: {StatusMessage}. CheckedElementsCount: {CheckedElementsCount}.");
        }
        catch (System.Exception ex)
        {
            LoggerService.LogError("[ApplyIncreaseChecked] EXCEPTION", ex);
            StatusMessage = "Error al expandir selección.";
        }
        finally
        {
            TreeItemViewModel.IsBulkUpdating = false;
        }
    }, _actionExternalEvent);
}

    private void FilterNode(TreeItemViewModel node, string searchText, System.Text.RegularExpressions.Regex searchRegex, bool isEmpty)
    {
        if (isEmpty) return;

        bool match = false;
        if (node.Level > 0)
        {
            try
            {
                if (searchRegex != null)
                {
                    // Regex Mode
                    match = searchRegex.IsMatch(node.Name);

                    // If "Only by name" is OFF, also allow searching by ElementId and Metadata
                    if (!match && !IsOnlyByName)
                    {
                        if (node.ElementId != null)
                        {
                            match = searchRegex.IsMatch(node.ElementId.ToString());
                        }
                        
                        if (!match && !string.IsNullOrEmpty(node.SearchableMetadata))
                        {
                            match = searchRegex.IsMatch(node.SearchableMetadata);
                        }
                    }
                }
                else
                {
                    // Standard Text Mode
                    // Search by Name (Category, Family, Type, or Element Name)
                    match = node.Name.ToLowerInvariant().Contains(searchText);

                    // If "Only by name" is OFF, also allow searching by ElementId and Metadata
                    if (!match && !IsOnlyByName)
                    {
                        if (node.ElementId != null)
                        {
                            match = node.ElementId.ToString().Contains(searchText);
                        }
                        
                        if (!match && !string.IsNullOrEmpty(node.SearchableMetadata))
                        {
                            match = node.SearchableMetadata.Contains(searchText);
                        }
                    }
                }
            }
            catch (System.Text.RegularExpressions.RegexMatchTimeoutException)
            {
                LoggerService.LogInfo("Regex match timed out. Possible ReDoS pattern.");
                StatusMessage = "Regex Timeout Error";
            }
        }

        if (match)
        {
            node.SetCheckedState(true);
        }

        foreach (var child in node.Children)
        {
            FilterNode(child, searchText, searchRegex, isEmpty);
        }
    }
}

/// <summary>
/// Custom equality comparer for ElementId to prevent reference-equality issues in Revit API.
/// </summary>
public class ElementIdEqualityComparer : IEqualityComparer<Autodesk.Revit.DB.ElementId>
{
    public bool Equals(Autodesk.Revit.DB.ElementId x, Autodesk.Revit.DB.ElementId y)
    {
        if (x == null && y == null) return true;
        if (x == null || y == null) return false;
        return x.Value == y.Value;
    }

    public int GetHashCode(Autodesk.Revit.DB.ElementId obj)
    {
        if (obj == null) return 0;
        return obj.Value.GetHashCode();
    }
}
