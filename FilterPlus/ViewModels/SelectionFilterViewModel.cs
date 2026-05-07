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
    [ObservableProperty] private bool _isUseOr;
    [ObservableProperty] private bool _isOnlyByName;
    [ObservableProperty] private bool _isUseRegex;

    [ObservableProperty] private SelectionScope _currentScope = SelectionScope.CurrentSelection;
    private HashSet<Autodesk.Revit.DB.ElementId> _persistentCheckedIds = new();

    [RelayCommand]
    private void OpenConfiguration()
    {
        var configView = new Views.ConfigurationView();
        configView.ShowDialog();
    }

    private bool _isRestoringState = false;
    private bool _isInitializing = false;

    private void OnTreeSelectionChanged()
    {
        if (TreeItemViewModel.IsBulkUpdating) return;
        
        var selectedIds = new List<Autodesk.Revit.DB.ElementId>();
        foreach (var node in RootNodes) node.GetAllSelectedIds(selectedIds);
        CheckedElementsCount = selectedIds.Count;

        // Keep persistent state in sync so checked elements carry over between scope switches
        _persistentCheckedIds = new HashSet<Autodesk.Revit.DB.ElementId>(selectedIds);

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
            var filtered = GetFilteredElements().ToList();
            StatusMessage = $"Elementos encontrados: {filtered.Count}";
            UpdateDropdowns(filtered);
            InitializeTree(filtered);
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

    private void InitializeTree(IEnumerable<ElementModel> filteredElements)
    {
        try 
        {
            var elements = filteredElements.ToList();
            LoggerService.LogInfo($"Building tree structure offline for {elements.Count} elements...");
            var rootAll = new TreeItemViewModel("All", null, 0, OnTreeSelectionChanged);
            
            if (SortByPhase)
            {
                var phases = elements
                    .GroupBy(e => new { e.PhaseName, e.PhaseOrder })
                    .OrderBy(g => g.Key.PhaseOrder);

                foreach (var phaseGroup in phases)
                {
                    var phaseNode = new TreeItemViewModel(phaseGroup.Key.PhaseName, rootAll, 1, OnTreeSelectionChanged);
                    rootAll.Children.Add(phaseNode);

                    var catGroups = phaseGroup
                        .GroupBy(e => e.CategoryName)
                        .OrderBy(g => g.Key);

                    foreach (var catGroup in catGroups)
                    {
                        var catNode = new TreeItemViewModel(catGroup.Key, phaseNode, 2, OnTreeSelectionChanged);
                        phaseNode.Children.Add(catNode);
                        BuildCategorySubTree(catGroup, catNode);
                    }
                    phaseNode.Count = phaseNode.Children.Sum(c => c.Count);
                }
            }
            else
            {
                var categories = elements
                    .GroupBy(e => e.CategoryName)
                    .OrderBy(g => g.Key);

                foreach (var catGroup in categories)
                {
                    var catNode = new TreeItemViewModel(catGroup.Key, rootAll, 1, OnTreeSelectionChanged);
                    rootAll.Children.Add(catNode);
                    BuildCategorySubTree(catGroup, catNode);
                }
            }

            rootAll.Count = rootAll.Children.Sum(c => c.Count);

            if (_persistentCheckedIds.Count > 0)
            {
                LoggerService.LogInfo($"Applying selection state for {_persistentCheckedIds.Count} checked elements...");
                ApplyInitialSelection(rootAll, _persistentCheckedIds);
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

    private bool ApplyInitialSelection(TreeItemViewModel node, HashSet<Autodesk.Revit.DB.ElementId> selectedIds)
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
            if (ApplyInitialSelection(child, selectedIds))
                hasCheckedChildren = true;
        }

        if (hasCheckedChildren) node.IsExpanded = true;
        return hasCheckedChildren;
    }

    [RelayCommand]
    private void ApplyFilter()
    {
        try
        {
            // ── 1. Obtener los IDs marcados en el árbol activo ──────────────────────
            var selectedIds = new List<Autodesk.Revit.DB.ElementId>();
            foreach (var node in RootNodes) node.GetAllSelectedIds(selectedIds);

            var finalIds = selectedIds;
            StatusMessage = $"Seleccionados: {selectedIds.Count}";

            // ── 2. Aplicar la selección en Revit ───────────────────────────────────
            _selectionService.SetSelection(finalIds);

            // ── 3. Actualizar el estado persistente de IDs marcados ────────────────
            // Unión de los IDs ya persistidos (de otros scopes) con los del scope actual
            var finalIdSet = finalIds.ToHashSet();
            _persistentCheckedIds = finalIdSet;

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
