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
    private readonly List<ElementModel> _allAvailableElements;

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
    [ObservableProperty]
    private string _filterText = string.Empty;

    [RelayCommand]
    private void OpenConfiguration()
    {
        var configView = new Views.ConfigurationView();
        configView.ShowDialog();
    }

    private Dictionary<TreeItemViewModel, bool?> _preFilterSelectionState;
    private bool _isRestoringState = false;

    private bool _isInitializing = false;

    private void OnTreeSelectionChanged()
    {
        if (_isInitializing) return;
        var selectedIds = new List<Autodesk.Revit.DB.ElementId>();
        foreach (var node in RootNodes) node.GetAllSelectedIds(selectedIds);
        CheckedElementsCount = selectedIds.Count;
    }

    public SelectionFilterViewModel(RevitSelectionService selectionService)
    {
        _selectionService = selectionService;
        _allAvailableElements = _selectionService.GetAvailableElements();
        
        StatusMessage = $"Elementos encontrados: {_allAvailableElements.Count}";
        
        UpdateDropdowns();
        InitializeTree();
        OnTreeSelectionChanged();
    }

    private void UpdateDropdowns()
    {
        // Guardar selecciones actuales
        var prevCat = SelectedCategory;
        var prevFam = SelectedFamily;
        var prevType = SelectedType;

        Categories.Clear();
        Categories.Add("Todos");
        foreach (var c in _allAvailableElements.Select(e => e.CategoryName).Distinct().OrderBy(x => x))
            Categories.Add(c);
        SelectedCategory = prevCat ?? "Todos";

        UpdateFilteredSubLists();
    }

    private void UpdateFilteredSubLists()
    {
        var filtered = _allAvailableElements.AsEnumerable();
        if (SelectedCategory != "Todos" && !string.IsNullOrEmpty(SelectedCategory))
            filtered = filtered.Where(e => e.CategoryName == SelectedCategory);

        var fams = filtered.Select(e => e.FamilyName).Distinct().OrderBy(x => x).ToList();
        Families.Clear();
        Families.Add("Todos");
        foreach (var f in fams) Families.Add(f);
        if (!Families.Contains(SelectedFamily)) SelectedFamily = "Todos";

        var types = filtered.Select(e => e.TypeName).Distinct().OrderBy(x => x).ToList();
        Types.Clear();
        Types.Add("Todos");
        foreach (var t in types) Types.Add(t);
        if (!Types.Contains(SelectedType)) SelectedType = "Todos";

        var levels = filtered.Select(e => e.LevelName).Distinct().OrderBy(x => x).ToList();
        Levels.Clear();
        Levels.Add("Todos");
        foreach (var l in levels) Levels.Add(l);

        var worksets = filtered.Select(e => e.WorksetName).Distinct().OrderBy(x => x).ToList();
        Worksets.Clear();
        Worksets.Add("Todos");
        foreach (var w in worksets) Worksets.Add(w);
    }

    partial void OnSelectedCategoryChanged(string value) => UpdateFilteredSubLists();
    partial void OnSelectedFamilyChanged(string value) => UpdateFilteredSubLists();
    partial void OnSelectedTypeChanged(string value) => UpdateFilteredSubLists();

    private void InitializeTree()
    {
        RootNodes.Clear();
        var rootAll = new TreeItemViewModel("All", null, 0, OnTreeSelectionChanged);
        RootNodes.Add(rootAll);

        int totalCount = 0;

        var categories = _allAvailableElements
            .GroupBy(e => e.CategoryName)
            .OrderBy(g => g.Key);

        foreach (var catGroup in categories)
        {
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

#if REVIT2024_OR_GREATER
                    foreach (var element in typeGroup.OrderBy(e => e.Id.Value))
                    {
                        var elNode = new TreeItemViewModel($"ID: {element.Id.Value}", typeNode, 4, OnTreeSelectionChanged)
#else
                    foreach (var element in typeGroup.OrderBy(e => e.Id.IntegerValue))
                    {
                        var elNode = new TreeItemViewModel($"ID: {element.Id.IntegerValue}", typeNode, 4, OnTreeSelectionChanged)
#endif
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

        _isInitializing = true;
        
        var selectedIds = _selectionService.GetInitialSelectionIds();
        if (selectedIds.Count > 0)
        {
            ApplyInitialSelection(rootAll, selectedIds);
        }

        rootAll.IsExpanded = true;
        
        _isInitializing = false;
        OnTreeSelectionChanged();
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
            {
                hasCheckedChildren = true;
            }
        }

        if (hasCheckedChildren) node.IsExpanded = true;
        return hasCheckedChildren;
    }

    [RelayCommand]
    private void ApplyFilter()
    {
        try
        {
            var selectedIds = new List<Autodesk.Revit.DB.ElementId>();
            foreach (var node in RootNodes) node.GetAllSelectedIds(selectedIds);

            if (selectedIds.Count > 0)
            {
                _selectionService.SetSelection(selectedIds);
                StatusMessage = $"Seleccionados (Árbol): {selectedIds.Count}";
            }
            else
            {
                var filtered = _allAvailableElements.AsEnumerable();
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

                var filteredList = filtered.ToList();
                _selectionService.SetSelection(filteredList.Select(e => e.Id));
                StatusMessage = $"Seleccionados (Filtros): {filteredList.Count}";
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

    partial void OnFilterTextChanged(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            ApplySearchFilter("");
            RestoreSelectionState();
            return;
        }

        // Si es la primera vez que se filtra en esta sesión, guardamos el estado
        if (_preFilterSelectionState == null && !_isRestoringState)
        {
            _preFilterSelectionState = new Dictionary<TreeItemViewModel, bool?>();
            SaveSelectionState(RootNodes, _preFilterSelectionState);
        }

        // Security Hardening: Sanitize filter text
        string sanitizedValue = SecurityUtils.SanitizeInput(value);
        ApplySearchFilter(sanitizedValue);
    }

    private void SaveSelectionState(IEnumerable<TreeItemViewModel> nodes, Dictionary<TreeItemViewModel, bool?> state)
    {
        foreach (var node in nodes)
        {
            state[node] = node.IsChecked;
            SaveSelectionState(node.Children, state);
        }
    }

    private void RestoreSelectionState()
    {
        if (_preFilterSelectionState == null) return;
        
        _isRestoringState = true;
        // Restaurar estado sin disparar eventos innecesarios si es posible, pero IsChecked ya se encarga
        foreach (var kvp in _preFilterSelectionState)
        {
            kvp.Key.IsChecked = kvp.Value;
        }
        _preFilterSelectionState = null;
        _isRestoringState = false;
    }

    private void ApplySearchFilter(string searchText)
    {
        bool isEmpty = string.IsNullOrWhiteSpace(searchText);
        if (!isEmpty)
        {
            searchText = searchText.ToLowerInvariant();
            
            // Desmarcar todo antes de aplicar la nueva selección basada en el filtro
            foreach (var node in RootNodes)
            {
                node.IsChecked = false;
            }
        }

        foreach (var node in RootNodes)
        {
            FilterNode(node, searchText, isEmpty);
        }
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
            {
                childMatch = true;
            }
        }

        node.IsVisible = match || childMatch;
        
        if (childMatch && !node.IsExpanded)
        {
            node.IsExpanded = true;
        }

        if (match && !isEmpty)
        {
            node.IsChecked = true;
        }

        return node.IsVisible;
    }

    [RelayCommand]
    private void ClearSearch()
    {
        // Esto desencadenará OnFilterTextChanged("") que limpiará el filtro de visibilidad
        FilterText = string.Empty;
        RestoreSelectionState();
    }
}
