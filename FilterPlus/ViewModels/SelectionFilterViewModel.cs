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
    public RevitSelectionService SelectionService => _selectionService;
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
    [ObservableProperty] private bool _sortByModel;
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
    private HashSet<ElementSelectionKey> _persistentCheckedIds = new();
    private HashSet<ElementSelectionKey> _lastAppliedCheckedIds = new();
    [ObservableProperty] private bool _isSelectionDirty;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsSavedSelectionSelected))]
    private SavedSelection _selectedSavedSelection;

    public bool IsSavedSelectionSelected => SelectedSavedSelection != null && !string.IsNullOrEmpty(SelectedSavedSelection.Name);

    public ObservableCollection<SavedSelection> SavedSelections { get; } = new();

    [ObservableProperty] private ObservableCollection<RevitModelRepresentation> _availableModels = new();
    public List<RevitModelRepresentation> SelectedModels { get; private set; } = new();
    [ObservableProperty] private string _selectedModelsText;

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

    public List<ElementModel> AllModelElements => _allModelElements;
    public List<ElementModel> ElementsVisibleInView => _elementsVisibleInViewElements;
    public List<ElementModel> ElementsBelongingToView => _elementsBelongingToViewElements;

    public List<ElementModel> GetAllElementsCombined()
    {
        return _allModelElements
            .Concat(_elementsVisibleInViewElements)
            .Concat(_elementsBelongingToViewElements)
            .Concat(_currentSelectionElements)
            .GroupBy(e => new ElementSelectionKey(e.Id, e.LinkInstanceId))
            .Select(g => g.First())
            .ToList();
    }

    [RelayCommand]
    private void OpenPreSelection()
    {
        try
        {
            LoggerService.LogInfo("Opening Pre-Selection window...");
            Views.PreSelectionView preSelView = null;
            var viewModel = new PreSelectionViewModel(this, () => preSelView?.Close());
            
            preSelView = new Views.PreSelectionView(viewModel);
            
            if (System.Windows.Application.Current != null)
            {
                var owner = System.Windows.Application.Current.Windows
                    .OfType<System.Windows.Window>()
                    .FirstOrDefault(w => w is Views.SelectionFilterView);
                if (owner != null)
                {
                    preSelView.Owner = owner;
                }
            }
            
            LoggerService.LogInfo("Showing Pre-Selection dialog...");
            preSelView.ShowDialog();
        }
        catch (Exception ex)
        {
            LoggerService.LogError("OpenPreSelection Command Error", ex);
        }
    }

    public void ApplyPreSelection(HashSet<ElementSelectionKey> matchingKeys, SelectionScope targetScope)
    {
        try
        {
            LoggerService.LogInfo($"[ApplyPreSelection] Applying matching keys: {matchingKeys.Count} on scope: {targetScope}. IsBulkUpdating: {TreeItemViewModel.IsBulkUpdating}");

            _persistentCheckedIds = matchingKeys;
            CheckedElementsCount = _persistentCheckedIds.Count;

            if (CurrentScope == targetScope)
            {
                BuildTree();
            }
            else
            {
                CurrentScope = targetScope;
            }
            LoggerService.LogInfo($"[ApplyPreSelection] Complete. Checked count is now {CheckedElementsCount}");
        }
        catch (Exception ex)
        {
            LoggerService.LogError("ApplyPreSelection", ex);
        }
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
        else
        {
            UpdateIsSelectionDirty();
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
            // Populate AvailableModels (in Revit API Context)
            var hostDoc = _selectionService.Document;
            AvailableModels.Add(new RevitModelRepresentation("Active Model: " + hostDoc.Title, null, hostDoc));

            var linkCollector = new Autodesk.Revit.DB.FilteredElementCollector(hostDoc)
                .OfClass(typeof(Autodesk.Revit.DB.RevitLinkInstance));

            foreach (var el in linkCollector)
            {
                if (el is Autodesk.Revit.DB.RevitLinkInstance linkInst)
                {
                    var linkedDoc = linkInst.GetLinkDocument();
                    if (linkedDoc != null)
                    {
                        AvailableModels.Add(new RevitModelRepresentation($"Link: {linkInst.Name}", linkInst, linkedDoc));
                    }
                }
            }

            // Default selection: Active Model
            var initialModel = AvailableModels.FirstOrDefault();
            if (initialModel != null)
            {
                SelectedModels.Add(initialModel);
                SelectedModelsText = initialModel.DisplayName;
            }

            // 1. Get initial selection IDs from Revit (safe: API context)
            var hostInitialIds = _selectionService.GetInitialSelectionIds();
            _persistentCheckedIds = hostInitialIds.Select(id => new ElementSelectionKey(id, ElementId.InvalidElementId)).ToHashSet();
            _lastAppliedCheckedIds = new HashSet<ElementSelectionKey>(_persistentCheckedIds);
            IsSelectionDirty = false;
            LoggerService.LogInfo($"Initial selection IDs count: {_persistentCheckedIds.Count}");

            // 2. Pre-fetch all scopes NOW (we are in Revit API thread)
            LoggerService.LogInfo("Pre-fetching CurrentSelection elements...");
            _currentSelectionElements = _selectionService.GetAvailableElements(SelectionScope.CurrentSelection, SelectedModels);
            LoggerService.LogInfo($"CurrentSelection: {_currentSelectionElements.Count} elements.");

            // Add check to ensure we don't get null reference
            _elementsVisibleInViewElements = _selectionService.GetAvailableElements(SelectionScope.ElementsVisibleInView, SelectedModels);
            LoggerService.LogInfo($"ElementsVisibleInView: {_elementsVisibleInViewElements.Count} elements.");

            _elementsBelongingToViewElements = _selectionService.GetAvailableElements(SelectionScope.ElementsBelongingToView, SelectedModels);
            LoggerService.LogInfo($"ElementsBelongingToView: {_elementsBelongingToViewElements.Count} elements.");

            var allRaw = _selectionService.GetAvailableElements(SelectionScope.AllModelElements, SelectedModels);
            _allModelElements = allRaw.Count > 100000 ? allRaw.Take(100000).ToList() : allRaw;
            LoggerService.LogInfo($"AllModelElements: {_allModelElements.Count} elements (raw: {allRaw.Count}).");

            // 3. Build tree for the default scope (CurrentSelection)
            _activeElements = _currentSelectionElements;
            BuildTree();

            // Load saved selections from extensible storage
            LoadSelectionsFromDocument();
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

    [RelayCommand]
    private void OpenModelSelection()
    {
        try
        {
            LoggerService.LogInfo("Opening Model Selection window...");
            Views.ModelSelectionView view = null;
            var viewModel = new ModelSelectionViewModel(AvailableModels.ToList(), SelectedModels, (selected) => 
            {
                ApplySelectedModels(selected);
                view?.Close();
            }, () => view?.Close());
            
            view = new Views.ModelSelectionView(viewModel);
            
            if (System.Windows.Application.Current != null)
            {
                var owner = System.Windows.Application.Current.Windows
                    .OfType<System.Windows.Window>()
                    .FirstOrDefault(w => w is Views.SelectionFilterView);
                if (owner != null)
                {
                    view.Owner = owner;
                }
            }
            
            LoggerService.LogInfo("Showing Model Selection dialog...");
            view.ShowDialog();
        }
        catch (Exception ex)
        {
            LoggerService.LogError("OpenModelSelection Command Error", ex);
        }
    }

    public void ApplySelectedModels(List<RevitModelRepresentation> selected)
    {
        if (selected == null || !selected.Any()) return;
        if (_actionHandler == null || _actionExternalEvent == null) return;

        // Save selected models list
        SelectedModels.Clear();
        SelectedModels.AddRange(selected);

        // Update display text
        if (SelectedModels.Count == 1)
        {
            SelectedModelsText = SelectedModels.First().DisplayName;
        }
        else
        {
            SelectedModelsText = $"Multiple models selected ({SelectedModels.Count})";
        }

        LoggerService.LogInfo($"[ApplySelectedModels] Switching context to: {SelectedModelsText}");
        StatusMessage = "Switching model context...";
        IsBusy = true;

        System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke(
            System.Windows.Threading.DispatcherPriority.Background,
            new Action(delegate { }));

        _actionHandler.Raise(() =>
        {
            try
            {
                // Clear selection state
                _persistentCheckedIds.Clear();
                _lastAppliedCheckedIds.Clear();
                
                // Pre-fetch all scopes for the selected models combined
                _currentSelectionElements = _selectionService.GetAvailableElements(SelectionScope.CurrentSelection, SelectedModels);
                _elementsVisibleInViewElements = _selectionService.GetAvailableElements(SelectionScope.ElementsVisibleInView, SelectedModels);
                _elementsBelongingToViewElements = _selectionService.GetAvailableElements(SelectionScope.ElementsBelongingToView, SelectedModels);
                
                var allRaw = _selectionService.GetAvailableElements(SelectionScope.AllModelElements, SelectedModels);
                _allModelElements = allRaw.Count > 100000 ? allRaw.Take(100000).ToList() : allRaw;

                // Sync active elements based on current scope
                _activeElements = CurrentScope switch
                {
                    SelectionScope.CurrentSelection => _currentSelectionElements,
                    SelectionScope.ElementsVisibleInView => _elementsVisibleInViewElements,
                    SelectionScope.ElementsBelongingToView => _elementsBelongingToViewElements,
                    SelectionScope.AllModelElements => _allModelElements,
                    _                               => _currentSelectionElements
                };

                // Rebuild the TreeView
                BuildTree();
                IsSelectionDirty = false;
                StatusMessage = $"Ready ({SelectedModelsText})";
            }
            catch (Exception ex)
            {
                LoggerService.LogError("Switching Model Context Error", ex);
                StatusMessage = "Error switching model.";
            }
            finally
            {
                IsBusy = false;
            }
        }, _actionExternalEvent);
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
        
        var hiddenKeys = _activeElements.Where(isHiddenPredicate).Select(e => new ElementSelectionKey(e.Id, e.LinkInstanceId)).ToList();
        bool changed = false;
        foreach (var key in hiddenKeys)
        {
            if (_persistentCheckedIds.Contains(key))
            {
                _persistentCheckedIds.Remove(key);
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

    partial void OnSortByModelChanged(bool value)
    {
        if (value) { if (!_activeGroupings.Contains("Model")) _activeGroupings.Add("Model"); }
        else _activeGroupings.Remove("Model");
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
        StatusMessage = "Rebuilding tree explorer...";
        IsBusy = true;
        System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke(
            System.Windows.Threading.DispatcherPriority.Background,
            new Action(delegate { }));

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
                        LinkInstanceId = element.LinkInstanceId,
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
        else if (groupingType == "Model")
        {
            var models = elements.GroupBy(e => GetModelDisplayName(e.LinkInstanceId)).OrderBy(g => g.Key);
            foreach (var modelGroup in models)
            {
                var modelNode = new TreeItemViewModel(modelGroup.Key, parentNode, parentNode.Level + 1, OnTreeSelectionChanged);
                parentNode.Children.Add(modelNode);
                BuildGroupedTree(modelGroup, modelNode, groupingIndex + 1);
            }
            parentNode.Count = parentNode.Children.Sum(c => c.Count);
        }
    }

    private string GetModelDisplayName(ElementId linkInstanceId)
    {
        if (linkInstanceId == null || linkInstanceId == ElementId.InvalidElementId)
        {
            var hostModel = AvailableModels.FirstOrDefault(m => m.LinkInstance == null);
            return hostModel?.DisplayName ?? "Active Model";
        }
        else
        {
            var linkModel = AvailableModels.FirstOrDefault(m => m.LinkInstance != null && m.LinkInstance.Id == linkInstanceId);
            return linkModel?.DisplayName ?? $"Link: {linkInstanceId}";
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

    private bool ApplyInitialSelection(TreeItemViewModel node, HashSet<ElementSelectionKey> selectedKeys, bool forceExpand)
    {
        if (node.Children.Count == 0)
        {
            if (node.ElementId != null && selectedKeys.Contains(new ElementSelectionKey(node.ElementId, node.LinkInstanceId)))
            {
                node.IsChecked = true;
                return true;
            }
            return false;
        }

        bool hasCheckedChildren = false;
        foreach (var child in node.Children)
        {
            if (ApplyInitialSelection(child, selectedKeys, forceExpand))
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
     public void OnPickElementsFinished(List<ElementSelectionKey> newKeys, List<ElementModel> newModels)
    {
        var dispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
        dispatcher.InvokeAsync(() =>
        {
            if (newKeys != null && newKeys.Count > 0)
            {
                // Add new IDs to the persistent selection
                foreach (var key in newKeys)
                {
                    _persistentCheckedIds.Add(key);
                }

                // Ensure newly picked elements are injected into the active elements so they show up in the tree!
                if (newModels != null)
                {
                    foreach (var model in newModels)
                    {
                        // Add to _allModelElements if not present so it can be resolved/grouped
                        if (!_allModelElements.Any(e => e.Id == model.Id && e.LinkInstanceId == model.LinkInstanceId))
                        {
                            _allModelElements.Add(model);
                        }

                        // Add to _activeElements if not present so it shows up in tree
                        if (_activeElements != null && !_activeElements.Any(e => e.Id == model.Id && e.LinkInstanceId == model.LinkInstanceId))
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
        var selectedKeysInTree = new List<ElementSelectionKey>();
        foreach (var node in RootNodes) node.GetAllSelectedKeys(selectedKeysInTree);

        var activeKeys = _activeElements?.Select(e => new ElementSelectionKey(e.Id, e.LinkInstanceId)).ToHashSet() 
            ?? new HashSet<ElementSelectionKey>();
        
        var keysFromOtherScopes = _persistentCheckedIds.Where(k => !activeKeys.Contains(k));
        
        _persistentCheckedIds = selectedKeysInTree.Concat(keysFromOtherScopes).ToHashSet();
        CheckedElementsCount = _persistentCheckedIds.Count;
    }

    private void UpdateIsSelectionDirty()
    {
        if (_persistentCheckedIds.Count != _lastAppliedCheckedIds.Count)
        {
            IsSelectionDirty = true;
            return;
        }

        foreach (var key in _persistentCheckedIds)
        {
            if (!_lastAppliedCheckedIds.Contains(key))
            {
                IsSelectionDirty = true;
                return;
            }
        }

        IsSelectionDirty = false;
    }

    [RelayCommand]
    private void ApplyFilter()
    {
        try
        {
            // ── 1. Actualizar el estado persistente de IDs marcados ────────────────
            UpdatePersistentCheckedIdsFromTree();

            var finalKeys = _persistentCheckedIds.ToList();
            StatusMessage = $"Seleccionados: {finalKeys.Count}";

            // ── 2. Aplicar la selección en Revit ───────────────────────────────────
            _selectionService.SetSelection(finalKeys);

            // ── 4. Reconstruir _currentSelectionElements desde TODOS los scopes ────
            // Buscamos el ElementModel de cada ID seleccionado en el pool completo,
            // así no se pierden elementos que no estuvieran en el scope activo actual.
            var allKnownByKey = _currentSelectionElements
                .Concat(_elementsVisibleInViewElements)
                .Concat(_elementsBelongingToViewElements)
                .Concat(_allModelElements)
                .GroupBy(e => new ElementSelectionKey(e.Id, e.LinkInstanceId))
                .Select(g => g.First())
                .ToDictionary(e => new ElementSelectionKey(e.Id, e.LinkInstanceId));

            _currentSelectionElements = _persistentCheckedIds
                .Where(key => allKnownByKey.ContainsKey(key))
                .Select(key => allKnownByKey[key])
                .ToList();

            LoggerService.LogInfo(
                $"Apply Selection: {_persistentCheckedIds.Count} elements applied. " +
                $"CurrentSelection updated to {_currentSelectionElements.Count} elements.");

            _lastAppliedCheckedIds = new HashSet<ElementSelectionKey>(_persistentCheckedIds);
            IsSelectionDirty = false;

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

        TreeItemViewModel.IsBulkUpdating = true;
        foreach (var node in RootNodes) node.SetCheckedState(false);
        TreeItemViewModel.IsBulkUpdating = false;

        _persistentCheckedIds.Clear();
        CheckedElementsCount = 0;

        if (IsLiveSelection)
        {
            ApplyFilter();
        }
        else
        {
            UpdateIsSelectionDirty();
        }
    }

    [RelayCommand]
    private void ApplySearch()
    {
        string searchText = FilterText;
        if (string.IsNullOrWhiteSpace(searchText)) return;

        StatusMessage = "Applying search filter...";
        IsBusy = true;
        System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke(
            System.Windows.Threading.DispatcherPriority.Background,
            new Action(delegate { }));

        try
        {
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
        finally
        {
            IsBusy = false;
        }
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
        IsBusy = true;

        System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke(
            System.Windows.Threading.DispatcherPriority.Background,
            new Action(delegate { }));
        
        _actionHandler.Raise(() =>
        {
            try
            {
                TreeItemViewModel.IsBulkUpdating = true;
            
            // 1. Get currently checked ElementKeys from the tree
            var currentCheckedKeys = new List<ElementSelectionKey>();
            foreach (var node in RootNodes)
                node.GetAllSelectedKeys(currentCheckedKeys);
                
            LoggerService.LogInfo($"[ApplyIncreaseChecked] Checked elements in explorer tree: {currentCheckedKeys.Count}.");

            if (currentCheckedKeys.Count == 0)
            {
                TreeItemViewModel.IsBulkUpdating = false;
                StatusMessage = "No elements selected in the tree to expand.";
                return;
            }

            var doc = _selectionService.Document;

            var targets = new HashSet<ElementSelectionKey>();
            
            // Get all active documents we want to expand selection in
            var docsToProcess = new List<(Document Document, RevitLinkInstance LinkInstance, ElementId LinkInstanceId)>();
            foreach (var model in SelectedModels)
            {
                var targetDoc = model.Document ?? doc;
                var targetLink = model.LinkInstance;
                docsToProcess.Add((targetDoc, targetLink, targetLink?.Id ?? ElementId.InvalidElementId));
            }

            foreach (var docCtx in docsToProcess)
            {
                var keysForDoc = currentCheckedKeys.Where(k => k.LinkInstanceId == docCtx.LinkInstanceId).ToList();
                if (keysForDoc.Count == 0) continue;

                var sourceElements = new List<Element>();
                foreach (var key in keysForDoc)
                {
                    var el = docCtx.Document.GetElement(key.ElementId);
                    if (el != null) sourceElements.Add(el);
                }

                if (sourceElements.Count == 0) continue;

                // 2. Define search domain for this document
                List<Element> domainElements;
                if (IncreaseWhereVisibleInView)
                {
                    if (docCtx.LinkInstance == null)
                    {
                        var visibleCollector = new FilteredElementCollector(docCtx.Document, docCtx.Document.ActiveView.Id);
                        domainElements = visibleCollector.WhereElementIsNotElementType().ToElements().ToList();
                    }
                    else
                    {
                        var allCollector = new FilteredElementCollector(docCtx.Document);
                        var rawElements = allCollector.WhereElementIsNotElementType().ToElements();
                        domainElements = new List<Element>();
                        Outline hostViewOutline = null;
                        var activeView = doc.ActiveView;
                        if (activeView != null)
                        {
                            try
                            {
                                if (activeView.CropBoxActive)
                                {
                                    var cropBox = activeView.CropBox;
                                    hostViewOutline = new Outline(cropBox.Min, cropBox.Max);
                                }
                                else
                                {
                                    var viewOutline = activeView.get_BoundingBox(null);
                                    if (viewOutline != null)
                                    {
                                        hostViewOutline = new Outline(viewOutline.Min, viewOutline.Max);
                                    }
                                }
                            }
                            catch {}
                        }
                        var totalTransform = docCtx.LinkInstance.GetTotalTransform();
                        foreach (var el in rawElements)
                        {
                            var localBox = el.get_BoundingBox(null);
                            if (localBox == null) continue;
                            if (hostViewOutline != null && totalTransform != null)
                            {
                                XYZ minHost = totalTransform.OfPoint(localBox.Min);
                                XYZ maxHost = totalTransform.OfPoint(localBox.Max);
                                double minX = Math.Min(minHost.X, maxHost.X);
                                double minY = Math.Min(minHost.Y, maxHost.Y);
                                double minZ = Math.Min(minHost.Z, maxHost.Z);
                                double maxX = Math.Max(minHost.X, maxHost.X);
                                double maxY = Math.Max(minHost.Y, maxHost.Y);
                                double maxZ = Math.Max(minHost.Z, maxHost.Z);
                                var elOutline = new Outline(new XYZ(minX, minY, minZ), new XYZ(maxX, maxY, maxZ));
                                if (hostViewOutline.Intersects(elOutline, 0.001))
                                {
                                    domainElements.Add(el);
                                }
                            }
                            else
                            {
                                domainElements.Add(el);
                            }
                        }
                    }
                }
                else if (IncreaseWhereCurrentView)
                {
                    if (docCtx.LinkInstance == null)
                    {
                        var viewCollector = new FilteredElementCollector(docCtx.Document);
                        domainElements = viewCollector.WhereElementIsNotElementType().ToElements()
                            .Where(el => el.OwnerViewId == docCtx.Document.ActiveView.Id || el.get_BoundingBox(docCtx.Document.ActiveView) != null)
                            .ToList();
                    }
                    else
                    {
                        var allCollector = new FilteredElementCollector(docCtx.Document);
                        var rawElements = allCollector.WhereElementIsNotElementType().ToElements();
                        domainElements = new List<Element>();
                        Outline hostViewOutline = null;
                        var activeView = doc.ActiveView;
                        if (activeView != null)
                        {
                            try
                            {
                                if (activeView.CropBoxActive)
                                {
                                    var cropBox = activeView.CropBox;
                                    hostViewOutline = new Outline(cropBox.Min, cropBox.Max);
                                }
                                else
                                {
                                    var viewOutline = activeView.get_BoundingBox(null);
                                    if (viewOutline != null)
                                    {
                                        hostViewOutline = new Outline(viewOutline.Min, viewOutline.Max);
                                    }
                                }
                            }
                            catch {}
                        }
                        var totalTransform = docCtx.LinkInstance.GetTotalTransform();
                        foreach (var el in rawElements)
                        {
                            var localBox = el.get_BoundingBox(null);
                            if (localBox == null) continue;
                            if (hostViewOutline != null && totalTransform != null)
                            {
                                XYZ minHost = totalTransform.OfPoint(localBox.Min);
                                XYZ maxHost = totalTransform.OfPoint(localBox.Max);
                                double minX = Math.Min(minHost.X, maxHost.X);
                                double minY = Math.Min(minHost.Y, maxHost.Y);
                                double minZ = Math.Min(minHost.Z, maxHost.Z);
                                double maxX = Math.Max(minHost.X, maxHost.X);
                                double maxY = Math.Max(minHost.Y, maxHost.Y);
                                double maxZ = Math.Max(minHost.Z, maxHost.Z);
                                var elOutline = new Outline(new XYZ(minX, minY, minZ), new XYZ(maxX, maxY, maxZ));
                                if (hostViewOutline.Intersects(elOutline, 0.001))
                                {
                                    domainElements.Add(el);
                                }
                            }
                            else
                            {
                                domainElements.Add(el);
                            }
                        }
                    }
                }
                else
                {
                    var modelCollector = new FilteredElementCollector(docCtx.Document);
                    domainElements = modelCollector.WhereElementIsNotElementType().ToElements().ToList();
                }

                var docTargetIds = new HashSet<ElementId>();

                // 3. Apply WHAT rules
                if (IncreaseWhatSameCategory)
                {
                    var targetCatIds = new HashSet<ElementId>(
                        sourceElements.Select(e => e.Category?.Id).Where(id => id != null)
                    );
                    foreach (var el in domainElements)
                    {
                        if (el.Category != null && targetCatIds.Contains(el.Category.Id))
                            docTargetIds.Add(el.Id);
                    }
                    LoggerService.LogInfo($"[ApplyIncreaseChecked] Checked 'Same Category' for {docCtx.Document.Title}. Targets: {docTargetIds.Count}.");
                }
                if (IncreaseWhatSameFamily || IncreaseWhatSameType)
                {
                    var targetFamilyNames = new HashSet<string>();
                    var targetTypeIds = new HashSet<ElementId>();
                    
                    foreach (var el in sourceElements)
                    {
                        var typeId = el.GetTypeId();
                        if (typeId != null && typeId != ElementId.InvalidElementId)
                        {
                            targetTypeIds.Add(typeId);
                            var type = docCtx.Document.GetElement(typeId) as ElementType;
                            if (type != null && !string.IsNullOrEmpty(type.FamilyName))
                            {
                                targetFamilyNames.Add(type.FamilyName);
                            }
                        }
                    }
                    
                    foreach (var el in domainElements)
                    {
                        var typeId = el.GetTypeId();
                        if (typeId == null || typeId == ElementId.InvalidElementId) continue;

                        if (IncreaseWhatSameType)
                        {
                            if (targetTypeIds.Contains(typeId))
                                docTargetIds.Add(el.Id);
                        }
                        else if (IncreaseWhatSameFamily)
                        {
                            var type = docCtx.Document.GetElement(typeId) as ElementType;
                            if (type != null && !string.IsNullOrEmpty(type.FamilyName) && targetFamilyNames.Contains(type.FamilyName))
                            {
                                docTargetIds.Add(el.Id);
                            }
                        }
                    }
                    LoggerService.LogInfo($"[ApplyIncreaseChecked] Checked 'Same Family/Type' for {docCtx.Document.Title}. Targets: {docTargetIds.Count}.");
                }
                if (IncreaseWhatSameWorkset && docCtx.Document.IsWorkshared)
                {
                    var targetWorksetIds = sourceElements.Select(e => e.WorksetId).Where(id => id != WorksetId.InvalidWorksetId).ToHashSet();
                    foreach (var el in domainElements)
                    {
                        if (targetWorksetIds.Contains(el.WorksetId))
                            docTargetIds.Add(el.Id);
                    }
                    LoggerService.LogInfo($"[ApplyIncreaseChecked] Checked 'Same Workset' for {docCtx.Document.Title}. Targets: {docTargetIds.Count}.");
                }
                if (IncreaseWhatHostOfElement)
                {
                    foreach (var el in sourceElements)
                    {
                        if (el is FamilyInstance fi && fi.Host != null)
                            docTargetIds.Add(fi.Host.Id);
                    }
                    LoggerService.LogInfo($"[ApplyIncreaseChecked] Checked 'Host of Element' for {docCtx.Document.Title}. Targets: {docTargetIds.Count}.");
                }
                if (IncreaseWhatHostedElements)
                {
                    var sourceIdsHash = sourceElements.Select(e => e.Id).ToHashSet();
                    foreach (var el in domainElements)
                    {
                        if (el is FamilyInstance fi && fi.Host != null && sourceIdsHash.Contains(fi.Host.Id))
                            docTargetIds.Add(el.Id);
                    }
                    LoggerService.LogInfo($"[ApplyIncreaseChecked] Checked 'Hosted Elements' for {docCtx.Document.Title}. Targets: {docTargetIds.Count}.");
                }
                if (IncreaseWhatNestedElements)
                {
                    foreach (var el in sourceElements)
                    {
                        if (el is FamilyInstance fi)
                        {
                            var subComponents = fi.GetSubComponentIds();
                            foreach (var subId in subComponents) docTargetIds.Add(subId);
                        }
                    }
                    LoggerService.LogInfo($"[ApplyIncreaseChecked] Checked 'Nested Elements' for {docCtx.Document.Title}. Targets: {docTargetIds.Count}.");
                }
                if (IncreaseWhatJoinedElements)
                {
                    foreach (var el in sourceElements)
                    {
                        try {
                            var joined = JoinGeometryUtils.GetJoinedElements(docCtx.Document, el);
                            foreach (var jId in joined) docTargetIds.Add(jId);
                        } catch {}
                    }
                    LoggerService.LogInfo($"[ApplyIncreaseChecked] Checked 'Joined Elements' for {docCtx.Document.Title}. Targets: {docTargetIds.Count}.");
                }
                if (IncreaseWhatSupercomponent)
                {
                    foreach (var el in sourceElements)
                    {
                        if (el is FamilyInstance fi && fi.SuperComponent != null)
                        {
                            docTargetIds.Add(fi.SuperComponent.Id);
                        }
                    }
                    LoggerService.LogInfo($"[ApplyIncreaseChecked] Checked 'Supercomponent' for {docCtx.Document.Title}. Targets: {docTargetIds.Count}.");
                }
                if (IncreaseWhatGroupOfAssembly)
                {
                    foreach (var el in sourceElements)
                    {
                        if (el.GroupId != ElementId.InvalidElementId)
                        {
                            var group = docCtx.Document.GetElement(el.GroupId) as Group;
                            if (group != null)
                            {
                                foreach (var memberId in group.GetMemberIds()) docTargetIds.Add(memberId);
                            }
                        }
                        if (el.AssemblyInstanceId != ElementId.InvalidElementId)
                        {
                            var assembly = docCtx.Document.GetElement(el.AssemblyInstanceId) as AssemblyInstance;
                            if (assembly != null)
                            {
                                foreach (var memberId in assembly.GetMemberIds()) docTargetIds.Add(memberId);
                            }
                        }
                    }
                    LoggerService.LogInfo($"[ApplyIncreaseChecked] Checked 'Group or Assembly' for {docCtx.Document.Title}. Targets: {docTargetIds.Count}.");
                }
                if (IncreaseWhatDependent)
                {
                    foreach (var el in sourceElements)
                    {
                        try
                        {
                            var dependentIds = el.GetDependentElements(null);
                            foreach (var depId in dependentIds) docTargetIds.Add(depId);
                        } catch {}
                    }
                    LoggerService.LogInfo($"[ApplyIncreaseChecked] Checked 'Dependent Elements' for {docCtx.Document.Title}. Targets: {docTargetIds.Count}.");
                }
                if (IncreaseWhatIntersects && domainElements.Count > 0)
                {
                    var domainIds = domainElements.Select(e => e.Id).ToList();
                    foreach (var el in sourceElements)
                    {
                        try
                        {
                            var intersects = new FilteredElementCollector(docCtx.Document, domainIds)
                                .WherePasses(new ElementIntersectsElementFilter(el))
                                .ToElementIds();
                            foreach (var id in intersects) docTargetIds.Add(id);
                        }
                        catch { }
                    }
                    LoggerService.LogInfo($"[ApplyIncreaseChecked] Checked 'Intersects' for {docCtx.Document.Title}. Targets: {docTargetIds.Count}.");
                }
                if (IncreaseWhatSameMEPSystem)
                {
                    foreach (var el in sourceElements)
                    {
                        ConnectorManager cm = null;
                        if (el is FamilyInstance fi && fi.MEPModel != null)
                            cm = fi.MEPModel.ConnectorManager;
                        else if (el is MEPCurve mepCurve)
                            cm = mepCurve.ConnectorManager;
                        
                        if (cm != null)
                        {
                            foreach (Connector conn in cm.Connectors)
                            {
                                var mepSystem = conn.MEPSystem;
                                if (mepSystem != null)
                                {
                                    foreach (Element sysEl in mepSystem.Elements)
                                        docTargetIds.Add(sysEl.Id);
                                }
                            }
                        }
                    }
                    LoggerService.LogInfo($"[ApplyIncreaseChecked] Checked 'MEP System' for {docCtx.Document.Title}. Targets: {docTargetIds.Count}.");
                }

                // 5. Exclusions
                if (IncreaseUnselectBelongsToGroup || IncreaseUnselectBelongsToAssembly)
                {
                    var purgedCheckedIds = new HashSet<ElementId>();
                    foreach (var id in docTargetIds)
                    {
                        var el = docCtx.Document.GetElement(id);
                        if (el == null) continue;
                        
                        if (IncreaseUnselectBelongsToGroup && el.GroupId != ElementId.InvalidElementId)
                            continue;
                        if (IncreaseUnselectBelongsToAssembly && el.AssemblyInstanceId != ElementId.InvalidElementId)
                            continue;
                            
                        purgedCheckedIds.Add(id);
                    }
                    docTargetIds = purgedCheckedIds;
                    LoggerService.LogInfo($"[ApplyIncreaseChecked] Purged exclusions for {docCtx.Document.Title}. Post-purged targets: {docTargetIds.Count}.");
                }

                // Convert docTargetIds to ElementSelectionKeys and add to targets
                foreach (var id in docTargetIds)
                {
                    targets.Add(new ElementSelectionKey(id, docCtx.LinkInstanceId));
                }
            }

            // 4. Unify with current and other scopes
            var activeKeys = _activeElements?.Select(e => new ElementSelectionKey(e.Id, e.LinkInstanceId)).ToHashSet() ?? new HashSet<ElementSelectionKey>();
            var keysFromOtherScopes = _persistentCheckedIds.Where(k => !activeKeys.Contains(k)).ToList();

            var finalCheckedKeys = new HashSet<ElementSelectionKey>();
            if (IncreaseHowAddToCurrent)
            {
                foreach (var k in currentCheckedKeys) finalCheckedKeys.Add(k);
            }
            foreach (var k in targets) finalCheckedKeys.Add(k);
            foreach (var k in keysFromOtherScopes) finalCheckedKeys.Add(k);

            // 6. Inject newly matched elements into _activeElements (if they aren't already in it)
            var allKnownByKey = _allModelElements
                .Concat(_elementsVisibleInViewElements)
                .Concat(_elementsBelongingToViewElements)
                .Concat(_currentSelectionElements)
                .GroupBy(e => new ElementSelectionKey(e.Id, e.LinkInstanceId))
                .Select(g => g.First())
                .ToDictionary(e => new ElementSelectionKey(e.Id, e.LinkInstanceId));
                
            var elementsToInject = new List<ElementModel>();
            foreach (var key in targets)
            {
                if (activeKeys.Contains(key)) continue;
                
                if (allKnownByKey.TryGetValue(key, out var existingModel))
                {
                    elementsToInject.Add(existingModel);
                }
                else
                {
                    Document targetDoc = doc;
                    if (key.LinkInstanceId != ElementId.InvalidElementId)
                    {
                        var linkInst = doc.GetElement(key.LinkInstanceId) as RevitLinkInstance;
                        targetDoc = linkInst?.GetLinkDocument() ?? doc;
                    }
                    var el = targetDoc.GetElement(key.ElementId);
                    if (el != null && el.Category != null)
                    {
                        var newModel = _selectionService.MapToElementModel(el);
                        if (newModel != null)
                        {
                            newModel.LinkInstanceId = key.LinkInstanceId;
                            elementsToInject.Add(newModel);
                        }
                    }
                }
            }
                
            if (elementsToInject.Count > 0)
            {
                _activeElements.AddRange(elementsToInject);
            }

            // 7. Update persistent checked IDs
            _persistentCheckedIds = finalCheckedKeys;
            
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
            IsBusy = false;
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

    private void LoadSelectionsFromDocument()
    {
        try
        {
            LoggerService.LogInfo("LoadSelectionsFromDocument: Reading saved selections from document...");
            var uiDispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
            var hostDoc = _selectionService.Document;
            var loaded = SavedSelectionsService.LoadSavedSelections(hostDoc);
            
            uiDispatcher.BeginInvoke(new Action(() =>
            {
                try
                {
                    SavedSelections.Clear();
                    // Placeholder selection as first element
                    SavedSelections.Add(new SavedSelection { Name = string.Empty });
                    foreach (var sel in loaded)
                    {
                        SavedSelections.Add(sel);
                    }
                    SelectedSavedSelection = SavedSelections.FirstOrDefault();
                    LoggerService.LogInfo($"LoadSelectionsFromDocument: UI dropdown list updated with {loaded.Count} selections.");
                }
                catch (Exception ex)
                {
                    LoggerService.LogError("LoadSelectionsFromDocument UI Update Error", ex);
                }
            }));
        }
        catch (Exception ex)
        {
            LoggerService.LogError("LoadSelectionsFromDocument Error", ex);
        }
    }

    [RelayCommand]
    private void OpenSaveSelectionDialog()
    {
        try
        {
            UpdatePersistentCheckedIdsFromTree();
            LoggerService.LogInfo($"Opening Save Selection dialog. Active checked elements to save: {CheckedElementsCount}.");
            
            // Get all selections excluding the placeholder
            var existingList = SavedSelections.Where(s => !string.IsNullOrEmpty(s.Name)).ToList();
            
            Action<string> onSaveNew = (newName) =>
            {
                SaveCurrentSelection(newName);
            };
            
            Action<SavedSelection> onOverwrite = (targetSel) =>
            {
                SaveCurrentSelection(targetSel.Name);
            };
            
            var vm = new SaveSelectionViewModel(existingList, onSaveNew, onOverwrite, null);
            var view = new Views.SaveSelectionView(vm);
            
            if (System.Windows.Application.Current != null)
            {
                var owner = System.Windows.Application.Current.Windows
                    .OfType<System.Windows.Window>()
                    .FirstOrDefault(w => w is Views.SelectionFilterView && w.IsVisible);
                    
                if (owner == null)
                {
                    owner = System.Windows.Application.Current.Windows
                        .OfType<System.Windows.Window>()
                        .FirstOrDefault(x => x.IsActive);
                }
                
                if (owner != null)
                {
                    view.Owner = owner;
                    view.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                }
                else
                {
                    view.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                    view.Topmost = true;
                }
            }
            else
            {
                view.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                view.Topmost = true;
            }
            
            LoggerService.LogInfo("Showing SaveSelectionView dialog (modal)...");
            view.ShowDialog();
            LoggerService.LogInfo("SaveSelectionView dialog closed.");
        }
        catch (Exception ex)
        {
            LoggerService.LogError("OpenSaveSelectionDialog Command Error", ex);
        }
    }

    private void SaveCurrentSelection(string name)
    {
        try
        {
            LoggerService.LogInfo($"SaveCurrentSelection initiated for name: '{name}'");

            if (_actionHandler == null || _actionExternalEvent == null)
            {
                LoggerService.LogError("SaveCurrentSelection", new InvalidOperationException("ActionEventHandler or ExternalEvent is null."));
                StatusMessage = "Error: API connection lost.";
                return;
            }

            // Step 1: Gather tree data (MUST be done on WPF UI thread)
            UpdatePersistentCheckedIdsFromTree();
            var elementKeys = _persistentCheckedIds.Select(k => new SavedElementKey
            {
                ElementIdValue = (int)k.ElementId.Value,
                LinkInstanceIdValue = k.LinkInstanceId != ElementId.InvalidElementId ? (int)k.LinkInstanceId.Value : -1
            }).ToList();
            
            var modelNames = SelectedModels.Select(m => m.DisplayName).ToList();
            
            var allSelections = SavedSelections.Where(s => !string.IsNullOrEmpty(s.Name)).ToList();
            
            // Check if already exists to overwrite
            var existing = allSelections.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (existing != null)
            {
                existing.Elements = elementKeys;
                existing.ActiveModelInstanceNames = modelNames;
                LoggerService.LogInfo($"Overwriting existing selection '{name}' with {elementKeys.Count} elements.");
            }
            else
            {
                allSelections.Add(new SavedSelection
                {
                    Name = name,
                    Elements = elementKeys,
                    ActiveModelInstanceNames = modelNames
                });
                LoggerService.LogInfo($"Creating new selection '{name}' with {elementKeys.Count} elements.");
            }

            // Show processing UI state on WPF UI thread
            StatusMessage = "Saving selection...";
            IsBusy = true;
            
            // Capture the UI thread dispatcher so we can reliably marshal back
            var uiDispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;

            // Step 2: Raise Revit API External Event to write to Extensible Storage (runs on Revit API thread)
            _actionHandler.Raise(() =>
            {
                try
                {
                    var hostDoc = _selectionService.Document;
                    LoggerService.LogInfo($"Writing {allSelections.Count} selections to Extensible Storage on Revit API thread...");
                    
                    bool success = SavedSelectionsService.SaveSavedSelections(hostDoc, allSelections);
                    
                    if (success)
                    {
                        // Read updated selections from Extensible Storage on the Revit API thread context
                        LoggerService.LogInfo("SaveCurrentSelection: Reading back selections from document on Revit API thread...");
                        var loaded = SavedSelectionsService.LoadSavedSelections(hostDoc);
                        LoggerService.LogInfo($"SaveCurrentSelection: Read {loaded.Count} updated selections successfully.");

                        // Step 3: Refresh UI list (MUST be dispatched back asynchronously to WPF UI thread)
                        uiDispatcher.BeginInvoke(new Action(() =>
                        {
                            try
                            {
                                SavedSelections.Clear();
                                // Placeholder selection as first element
                                SavedSelections.Add(new SavedSelection { Name = string.Empty });
                                foreach (var sel in loaded)
                                {
                                    SavedSelections.Add(sel);
                                }
                                
                                // Select the saved selection in the main dropdown
                                var newlySaved = SavedSelections.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                                if (newlySaved != null)
                                {
                                    SelectedSavedSelection = newlySaved;
                                }
                                StatusMessage = $"Selection '{name}' saved successfully.";
                                LoggerService.LogInfo($"Selection '{name}' saved successfully and UI updated.");
                            }
                            catch (Exception ex)
                            {
                                LoggerService.LogError("SaveCurrentSelection UI Refresh Callback Error", ex);
                            }
                            finally
                            {
                                IsBusy = false;
                            }
                        }));
                    }
                    else
                    {
                        uiDispatcher.BeginInvoke(new Action(() =>
                        {
                            StatusMessage = "Failed to save selection to document.";
                            IsBusy = false;
                        }));
                        LoggerService.LogError("SaveCurrentSelection", new InvalidOperationException("SavedSelectionsService.SaveSavedSelections returned false."));
                    }
                }
                catch (Exception ex)
                {
                    LoggerService.LogError("Revit API context execution failed inside SaveCurrentSelection", ex);
                    uiDispatcher.BeginInvoke(new Action(() =>
                    {
                        StatusMessage = "Error saving selection.";
                        IsBusy = false;
                    }));
                }
            }, _actionExternalEvent);
        }
        catch (Exception ex)
        {
            LoggerService.LogError($"SaveCurrentSelection '{name}' outer error", ex);
            StatusMessage = "Error gathering selection data.";
            IsBusy = false;
        }
    }

    [RelayCommand]
    private void RecoverSavedSelection()
    {
        if (SelectedSavedSelection == null || string.IsNullOrEmpty(SelectedSavedSelection.Name))
        {
            LoggerService.LogInfo("WARNING: RecoverSavedSelection canceled: no selection selected or name is empty.");
            return;
        }
        if (_actionHandler == null || _actionExternalEvent == null)
        {
            LoggerService.LogError("RecoverSavedSelection", new InvalidOperationException("ActionEventHandler or ExternalEvent is null."));
            StatusMessage = "Error: Recover failed (API connection lost).";
            return;
        }
        
        var targetSelection = SelectedSavedSelection;
        LoggerService.LogInfo($"RecoverSavedSelection initiated for '{targetSelection.Name}' (contains {targetSelection.Elements.Count} elements, {targetSelection.ActiveModelInstanceNames.Count} active models).");
        
        StatusMessage = $"Recovering selection '{targetSelection.Name}'...";
        IsBusy = true;
        
        // Capture the UI thread dispatcher
        var uiDispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
            
        _actionHandler.Raise(() =>
        {
            try
            {
                // 1. Sync Document selection context
                var availableModelsByName = AvailableModels.ToDictionary(m => m.DisplayName);
                var targetModelNames = targetSelection.ActiveModelInstanceNames;
                
                LoggerService.LogInfo($"Syncing active models: {string.Join(", ", targetModelNames)}");
                var modelsToSelect = new List<RevitModelRepresentation>();
                foreach (var name in targetModelNames)
                {
                    if (availableModelsByName.TryGetValue(name, out var modelRep))
                    {
                        modelsToSelect.Add(modelRep);
                    }
                    else
                    {
                        LoggerService.LogInfo($"WARNING: Saved active model name '{name}' not found in current AvailableModels.");
                    }
                }

                // Resolve the ElementModel objects for the saved selection keys in the Revit API thread
                var doc = _selectionService.Document;
                var recoveredModels = new List<ElementModel>();
                if (doc != null)
                {
                    foreach (var savedKey in targetSelection.Elements)
                    {
                        ElementId elId = new ElementId((long)savedKey.ElementIdValue);
                        if (savedKey.LinkInstanceIdValue == -1)
                        {
                            Element el = doc.GetElement(elId);
                            if (el != null)
                            {
                                var model = _selectionService.MapToElementModel(el);
                                if (model != null)
                                {
                                    model.LinkInstanceId = ElementId.InvalidElementId;
                                    recoveredModels.Add(model);
                                }
                            }
                        }
                        else
                        {
                            ElementId linkInstanceId = new ElementId((long)savedKey.LinkInstanceIdValue);
                            var linkInstance = doc.GetElement(linkInstanceId) as RevitLinkInstance;
                            if (linkInstance != null)
                            {
                                var linkedDoc = linkInstance.GetLinkDocument();
                                if (linkedDoc != null)
                                {
                                    Element el = linkedDoc.GetElement(elId);
                                    if (el != null)
                                    {
                                        var model = _selectionService.MapToElementModel(el);
                                        if (model != null)
                                        {
                                            model.LinkInstanceId = linkInstanceId;
                                            recoveredModels.Add(model);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                LoggerService.LogInfo($"RecoverSavedSelection Revit Thread: Resolved {recoveredModels.Count} elements from active RVT context.");
                
                uiDispatcher.BeginInvoke(new Action(() =>
                {
                    try
                    {
                        if (modelsToSelect.Any())
                        {
                            SelectedModels.Clear();
                            SelectedModels.AddRange(modelsToSelect);
                            
                            // Update display text
                            if (SelectedModels.Count == 1)
                            {
                                SelectedModelsText = SelectedModels.First().DisplayName;
                            }
                            else
                            {
                                SelectedModelsText = $"Multiple models selected ({SelectedModels.Count})";
                            }
                            
                            LoggerService.LogInfo($"[RecoverSavedSelection] Restored selection scope context to: {SelectedModelsText}");
                            
                            // Populate current selection with ONLY the resolved recovered elements
                            _currentSelectionElements = recoveredModels;

                            // Pre-fetch all other scopes for the selected models combined
                            LoggerService.LogInfo("Re-fetching other element scopes for the recovered model context...");
                            _elementsVisibleInViewElements = _selectionService.GetAvailableElements(SelectionScope.ElementsVisibleInView, SelectedModels);
                            _elementsBelongingToViewElements = _selectionService.GetAvailableElements(SelectionScope.ElementsBelongingToView, SelectedModels);
                            
                            var allRaw = _selectionService.GetAvailableElements(SelectionScope.AllModelElements, SelectedModels);
                            _allModelElements = allRaw.Count > 100000 ? allRaw.Take(100000).ToList() : allRaw;
                            
                            LoggerService.LogInfo($"Scopes fetched: CurrentSelection={_currentSelectionElements.Count}, VisibleInView={_elementsVisibleInViewElements.Count}, BelongingToView={_elementsBelongingToViewElements.Count}, AllModelElements={_allModelElements.Count}");
                        }
                        else
                        {
                            _currentSelectionElements = recoveredModels;
                        }
                        
                        // 2. Clear current tree checking and restore the keys
                        LoggerService.LogInfo($"Restoring selection keys: {_persistentCheckedIds.Count} existing keys cleared.");
                        _persistentCheckedIds.Clear();
                        _lastAppliedCheckedIds.Clear();
                        
                        foreach (var savedKey in targetSelection.Elements)
                        {
                            ElementId elId = new ElementId((long)savedKey.ElementIdValue);
                            ElementId linkId = savedKey.LinkInstanceIdValue != -1 ? new ElementId((long)savedKey.LinkInstanceIdValue) : ElementId.InvalidElementId;
                            _persistentCheckedIds.Add(new ElementSelectionKey(elId, linkId));
                        }
                        
                        LoggerService.LogInfo($"Restored {_persistentCheckedIds.Count} element selection keys in ViewModel.");
                        
                        // Set active elements to CurrentSelection scope containing only the recovered elements
                        CurrentScope = SelectionScope.CurrentSelection;
                        _activeElements = _currentSelectionElements;
                        
                        // Rebuild the TreeView
                        LoggerService.LogInfo("Rebuilding tree explorer with restored elements (Current Selection)...");
                        BuildTree();
                        
                        // Apply selection highlights in Revit viewport
                        LoggerService.LogInfo("Applying restored selection in Revit viewport...");
                        ApplyFilter();
                        
                        IsSelectionDirty = false;
                        SelectedSavedSelection = SavedSelections.FirstOrDefault();
                        StatusMessage = $"Selection '{targetSelection.Name}' recovered.";
                        LoggerService.LogInfo($"RecoverSavedSelection completed successfully for '{targetSelection.Name}'.");
                    }
                    catch (Exception exInner)
                    {
                        LoggerService.LogError("RecoverSavedSelection UI Callback Error", exInner);
                        StatusMessage = "Error recovering selection.";
                    }
                    finally
                    {
                        IsBusy = false;
                    }
                }));
            }
            catch (Exception ex)
            {
                LoggerService.LogError("RecoverSavedSelection Revit API Thread Error", ex);
                uiDispatcher.BeginInvoke(new Action(() =>
                {
                    StatusMessage = "Error recovering selection.";
                    IsBusy = false;
                }));
            }
        }, _actionExternalEvent);
    }

    [RelayCommand]
    private void DeleteSavedSelection(object windowObj)
    {
        if (SelectedSavedSelection == null || string.IsNullOrEmpty(SelectedSavedSelection.Name))
        {
            LoggerService.LogInfo("WARNING: DeleteSavedSelection canceled: no selection selected or name is empty.");
            return;
        }

        var targetSelection = SelectedSavedSelection;
        
        // Resolve parent window for modal
        System.Windows.Window ownerWin = windowObj as System.Windows.Window;
        if (ownerWin == null && System.Windows.Application.Current != null)
        {
            ownerWin = System.Windows.Application.Current.Windows
                .OfType<System.Windows.Window>()
                .FirstOrDefault(w => w is Views.SelectionFilterView && w.IsVisible);
            
            if (ownerWin == null)
            {
                ownerWin = System.Windows.Application.Current.Windows
                    .OfType<System.Windows.Window>()
                    .FirstOrDefault(x => x.IsActive);
            }
        }

        var result = System.Windows.MessageBox.Show(
            ownerWin,
            $"Are you sure you want to delete the saved selection '{targetSelection.Name}'?",
            "Delete Saved Selection",
            System.Windows.MessageBoxButton.YesNo,
            System.Windows.MessageBoxImage.Warning);

        if (result != System.Windows.MessageBoxResult.Yes)
        {
            LoggerService.LogInfo($"DeleteSavedSelection canceled by user for '{targetSelection.Name}'.");
            return;
        }

        LoggerService.LogInfo($"DeleteSavedSelection confirmed for '{targetSelection.Name}'. Starting removal...");
        StatusMessage = $"Deleting selection '{targetSelection.Name}'...";
        IsBusy = true;

        if (_actionHandler == null || _actionExternalEvent == null)
        {
            LoggerService.LogError("DeleteSavedSelection", new InvalidOperationException("ActionEventHandler or ExternalEvent is null."));
            StatusMessage = "Error: Delete failed (API connection lost).";
            IsBusy = false;
            return;
        }

        var uiDispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;

        _actionHandler.Raise(() =>
        {
            try
            {
                var doc = _selectionService.Document;
                if (doc == null)
                {
                    throw new InvalidOperationException("Revit Document is null.");
                }

                // 1. Load current list
                var selections = SavedSelectionsService.LoadSavedSelections(doc);
                
                // 2. Remove the target
                int removedCount = selections.RemoveAll(s => s.Name.Equals(targetSelection.Name, StringComparison.OrdinalIgnoreCase));
                LoggerService.LogInfo($"DeleteSavedSelection: Removed {removedCount} entries with name '{targetSelection.Name}' from temp list.");

                // 3. Save back to Extensible Storage
                bool success = SavedSelectionsService.SaveSavedSelections(doc, selections);

                if (success)
                {
                    LoggerService.LogInfo("DeleteSavedSelection: Extensible Storage write success.");
                    
                    // Reload selections from document inside the Revit thread, and push UI updates asynchronously
                    var updatedSelections = SavedSelectionsService.LoadSavedSelections(doc);

                    uiDispatcher.BeginInvoke(new Action(() =>
                    {
                        try
                        {
                            SavedSelections.Clear();
                            SavedSelections.Add(new SavedSelection { Name = string.Empty });
                            foreach (var s in updatedSelections)
                            {
                                SavedSelections.Add(s);
                            }
                            
                            SelectedSavedSelection = SavedSelections.FirstOrDefault();
                            IsSelectionDirty = false;
                            StatusMessage = $"Selection '{targetSelection.Name}' deleted.";
                            LoggerService.LogInfo($"DeleteSavedSelection UI update completed successfully.");
                        }
                        catch (Exception exInner)
                        {
                            LoggerService.LogError("DeleteSavedSelection UI Callback Error", exInner);
                            StatusMessage = "Error updating UI after deletion.";
                        }
                        finally
                        {
                            IsBusy = false;
                        }
                    }));
                }
                else
                {
                    uiDispatcher.BeginInvoke(new Action(() =>
                    {
                        StatusMessage = "Failed to delete selection from document.";
                        IsBusy = false;
                    }));
                    LoggerService.LogError("DeleteSavedSelection", new InvalidOperationException("SavedSelectionsService.SaveSavedSelections returned false."));
                }
            }
            catch (Exception ex)
            {
                LoggerService.LogError("Revit API thread execution failed inside DeleteSavedSelection", ex);
                uiDispatcher.BeginInvoke(new Action(() =>
                {
                    StatusMessage = "Error deleting selection.";
                    IsBusy = false;
                }));
            }
        }, _actionExternalEvent);
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
