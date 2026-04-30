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
    private HashSet<Autodesk.Revit.DB.ElementId> _preSearchCheckedIds = null;

    private void OnTreeSelectionChanged()
    {
        if (TreeItemViewModel.IsBulkUpdating) return;
        
        var selectedIds = new List<Autodesk.Revit.DB.ElementId>();
        foreach (var node in RootNodes) node.GetAllSelectedIds(selectedIds);
        CheckedElementsCount = selectedIds.Count;

        // Keep persistent state in sync so checked elements carry over between scope switches
        _persistentCheckedIds = new HashSet<Autodesk.Revit.DB.ElementId>(selectedIds);
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

    /// <summary>Rebuilds dropdowns and the tree from _activeElements. Safe to call from UI thread.</summary>
    private void BuildTree()
    {
        IsBusy = true;
        TreeItemViewModel.IsBulkUpdating = true;
        LoggerService.LogInfo($"BuildTree: {_activeElements.Count} elements for scope {CurrentScope}.");

        try
        {
            StatusMessage = $"Elementos encontrados: {_activeElements.Count}";
            UpdateDropdowns();
            InitializeTree();
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

    private void UpdateDropdowns()
    {
        LoggerService.LogInfo("Updating filter dropdowns...");
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

        foreach (var cat in _activeElements.Select(e => e.CategoryName).Distinct().OrderBy(x => x))
            Categories.Add(cat);
        foreach (var fam in _activeElements.Select(e => e.FamilyName).Distinct().OrderBy(x => x))
            Families.Add(fam);
        foreach (var type in _activeElements.Select(e => e.TypeName).Distinct().OrderBy(x => x))
            Types.Add(type);
        foreach (var lev in _activeElements.Select(e => e.LevelName).Distinct().OrderBy(x => x))
            Levels.Add(lev);
        foreach (var ws in _activeElements.Select(e => e.WorksetName).Distinct().OrderBy(x => x))
            Worksets.Add(ws);

        // Restore previous selection if still valid
        SelectedCategory = Categories.Contains(prevCat) ? prevCat : "Todos";
        SelectedFamily   = Families.Contains(prevFam)   ? prevFam : "Todos";
        SelectedType     = Types.Contains(prevType)     ? prevType : "Todos";
    }

    private void InitializeTree()
    {
        try 
        {
            LoggerService.LogInfo($"Building tree structure offline for {_activeElements.Count} elements...");
            var rootAll = new TreeItemViewModel("All", null, 0, OnTreeSelectionChanged);
            int totalCount = 0;

            var categories = _activeElements
                .GroupBy(e => e.CategoryName)
                .OrderBy(g => g.Key);

            int catIndex = 0;
            foreach (var catGroup in categories)
            {
                catIndex++;
                if (catIndex % 5 == 0) LoggerService.LogInfo($"Processing category {catIndex}: {catGroup.Key}");
                
                var catNode = new TreeItemViewModel(catGroup.Key, rootAll, 1, OnTreeSelectionChanged);
                rootAll.Children.Add(catNode);
                int catCount = 0;

                var families = catGroup
                    .GroupBy(e => e.FamilyName)
                    .OrderBy(g => g.Key);

                foreach (var famGroup in families)
                {
                    var famNode = new TreeItemViewModel(famGroup.Key, catNode, 2, OnTreeSelectionChanged);
                    catNode.Children.Add(famNode);
                    int famCount = 0;

                    var types = famGroup
                        .GroupBy(e => e.TypeName)
                        .OrderBy(g => g.Key);

                    foreach (var typeGroup in types)
                    {
                        var typeNode = new TreeItemViewModel(typeGroup.Key, famNode, 3, OnTreeSelectionChanged);
                        famNode.Children.Add(typeNode);
                        int strCount = 0;

                        foreach (var element in typeGroup.OrderBy(e => e.Id.ToString()))
                        {
                            var elNode = new TreeItemViewModel($"ID: {element.Id}", typeNode, 4, OnTreeSelectionChanged)
                            {
                                ElementId = element.Id,
                                Count = 1
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
                totalCount += catCount;
            }
            rootAll.Count = totalCount;

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
                LoggerService.LogInfo($"Swapping tree root directly. New total: {totalCount}");
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
            
            LoggerService.LogInfo($"Tree built and swapped. {totalCount} visible elements.");
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

            IEnumerable<Autodesk.Revit.DB.ElementId> finalIds;

            if (selectedIds.Count > 0)
            {
                finalIds = selectedIds;
                StatusMessage = $"Seleccionados (Árbol): {selectedIds.Count}";
            }
            else
            {
                // Aplicar filtros de dropdowns si no hay nada marcado en el árbol
                var filtered = _activeElements.AsEnumerable();
                if (SelectedCategory != "Todos" && !string.IsNullOrEmpty(SelectedCategory))
                    filtered = filtered.Where(e => e.CategoryName == SelectedCategory);
                if (SelectedFamily != "Todos" && !string.IsNullOrEmpty(SelectedFamily))
                    filtered = filtered.Where(e => e.FamilyName == SelectedFamily);
                if (SelectedType != "Todos" && !string.IsNullOrEmpty(SelectedType))
                    filtered = filtered.Where(e => e.TypeName == SelectedType);
                if (SelectedLevel != "Todos" && !string.IsNullOrEmpty(SelectedLevel))
                    filtered = filtered.Where(e => e.LevelName == SelectedLevel);
                if (SelectedWorkset != "Todos" && !string.IsNullOrEmpty(SelectedWorkset))
                    filtered = filtered.Where(e => e.WorksetName == SelectedWorkset);

                finalIds = filtered.Select(e => e.Id).ToList();
                StatusMessage = $"Seleccionados (Filtros): {finalIds.Count()}";
            }

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

    partial void OnFilterTextChanged(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            ApplySearchFilter("");
            if (_preSearchCheckedIds != null)
            {
                _isInitializing = true;
                foreach (var node in RootNodes) ApplyInitialSelection(node, _preSearchCheckedIds);
                _preSearchCheckedIds = null;
                _isInitializing = false;
                OnTreeSelectionChanged();
            }
            return;
        }

        if (_preSearchCheckedIds == null && !_isRestoringState)
        {
            var currentChecked = new List<Autodesk.Revit.DB.ElementId>();
            foreach (var node in RootNodes) node.GetAllSelectedIds(currentChecked);
            _preSearchCheckedIds = currentChecked.ToHashSet();
        }

        string sanitizedValue = SecurityUtils.SanitizeInput(value);
        ApplySearchFilter(sanitizedValue);
    }

    private void ApplySearchFilter(string searchText)
    {
        bool isEmpty = string.IsNullOrWhiteSpace(searchText);
        if (!isEmpty)
        {
            searchText = searchText.ToLowerInvariant();
            
            foreach (var node in RootNodes)
                node.IsChecked = false;
        }

        foreach (var node in RootNodes)
            FilterNode(node, searchText, isEmpty);
    }

    private bool FilterNode(TreeItemViewModel node, string searchText, bool isEmpty)
    {
        if (isEmpty)
        {
            node.IsVisible = true;
            foreach (var child in node.Children) FilterNode(child, searchText, isEmpty);
            return true;
        }

        bool match = node.Name.ToLowerInvariant().Contains(searchText);
        bool childMatch = false;

        foreach (var child in node.Children)
        {
            if (FilterNode(child, searchText, isEmpty))
                childMatch = true;
        }

        node.IsVisible = match || childMatch;
        
        if (childMatch && !node.IsExpanded)
            node.IsExpanded = true;

        if (match && !isEmpty)
            node.IsChecked = true;

        return node.IsVisible;
    }

    [RelayCommand]
    private void ClearSearch()
    {
        FilterText = string.Empty;
    }
}
