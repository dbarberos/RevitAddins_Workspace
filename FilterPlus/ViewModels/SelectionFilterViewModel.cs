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
    private readonly List<ElementModel> _allAvailableElements = new();

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

    private void OnTreeSelectionChanged()
    {
        if (TreeItemViewModel.IsBulkUpdating) return;
        
        var selectedIds = new List<Autodesk.Revit.DB.ElementId>();
        foreach (var node in RootNodes) node.GetAllSelectedIds(selectedIds);
        CheckedElementsCount = selectedIds.Count;

        // Mantener sincronizado el estado persistente para que se herede entre alcances (scopes)
        _persistentCheckedIds = new HashSet<Autodesk.Revit.DB.ElementId>(selectedIds);
    }

    public SelectionFilterViewModel(RevitSelectionService selectionService)
    {
        LoggerService.LogInfo("SelectionFilterViewModel initializing...");
        _selectionService = selectionService;
        
        try 
        {
            _persistentCheckedIds = _selectionService.GetInitialSelectionIds();
            LoggerService.LogInfo($"Initial persistent IDs count: {_persistentCheckedIds.Count}");
            if (_persistentCheckedIds.Count > 0)
            {
                LoggerService.LogInfo($"Initial Selection IDs: {string.Join(", ", _persistentCheckedIds.Take(20).Select(id => id.ToString()))}{( _persistentCheckedIds.Count > 20 ? "..." : "" )}");
            }
            LoadElements(CurrentScope);
        }
        catch (Exception ex)
        {
            LoggerService.LogError("ViewModel Constructor", ex);
        }
    }

    private void LoadElements(SelectionScope scope)
    {
        IsBusy = true;
        LoggerService.LogInfo($"Loading elements for scope: {scope}");
        TreeItemViewModel.IsBulkUpdating = true;
        
        try 
        {
            _allAvailableElements.Clear();
            _allAvailableElements.AddRange(_selectionService.GetAvailableElements(scope));
            LoggerService.LogInfo($"_allAvailableElements updated. Count: {_allAvailableElements.Count}");
            
            if (_allAvailableElements.Count > 0)
            {
                LoggerService.LogInfo($"Sample element IDs: {string.Join(", ", _allAvailableElements.Take(5).Select(e => e.Id.ToString()))}");
            }
            
            if (_allAvailableElements.Count > 10000)
            {
                LoggerService.LogInfo($"WARNING: Too many elements ({_allAvailableElements.Count}). Limiting to 10000 for stability.");
                var limited = _allAvailableElements.Take(10000).ToList();
                _allAvailableElements.Clear();
                _allAvailableElements.AddRange(limited);
            }
            
            StatusMessage = $"Elementos encontrados: {_allAvailableElements.Count}";
            
            UpdateDropdowns();
            InitializeTree();
        }
        finally
        {
            LoggerService.LogInfo("Post-load cleanup starting...");
            foreach (var node in RootNodes) node.RefreshState();
            TreeItemViewModel.IsBulkUpdating = false;
            OnTreeSelectionChanged();
            IsBusy = false;
            LoggerService.LogInfo("LoadElements completed successfully.");
        }
    }

    partial void OnCurrentScopeChanged(SelectionScope value)
    {
        try 
        {
            if (TreeItemViewModel.IsBulkUpdating) return;

            LoggerService.LogInfo($"Scope changed to: {value}. Requesting UI update...");
            
            // Mostrar indicador de carga inmediatamente
            IsBusy = true;

            // Usamos el dispatcher del hilo actual con prioridad Normal para asegurar ejecución inmediata tras el evento de UI
            System.Windows.Threading.Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() => {
                try 
                {
                    LoggerService.LogInfo($"--- STARTING DEFERRED LOAD for {value} ---");
                    LoadElements(value);
                    LoggerService.LogInfo($"--- DEFERRED LOAD FINISHED for {value} ---");
                }
                catch (Exception ex)
                {
                    LoggerService.LogError("OnCurrentScopeChanged Deferred Action", ex);
                }
            }), System.Windows.Threading.DispatcherPriority.Normal);
        }
        catch (Exception ex)
        {
            LoggerService.LogError("OnCurrentScopeChanged Outer", ex);
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
        try 
        {
            LoggerService.LogInfo($"Building tree structure offline for {_allAvailableElements.Count} elements...");
            var rootAll = new TreeItemViewModel("All", null, 0, OnTreeSelectionChanged);
            int totalCount = 0;

            var categories = _allAvailableElements
                .GroupBy(e => e.CategoryName)
                .OrderBy(g => g.Key);

            int catIndex = 0;
            foreach (var catGroup in categories)
            {
                catIndex++;
                if (catIndex % 5 == 0) LoggerService.LogInfo($"Processing category {catIndex}/{categories.Count()}: {catGroup.Key}");
                
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
                LoggerService.LogInfo($"Applying initial selection state to the tree for {_persistentCheckedIds.Count} elements...");
                ApplyInitialSelection(rootAll, _persistentCheckedIds);
            }

            rootAll.IsExpanded = true;

            // Swapping RootNodes on UI thread
            var uiDispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
            if (uiDispatcher.CheckAccess())
            {
                LoggerService.LogInfo($"Swapping tree root directly. Previous count: {RootNodes.Count}");
                RootNodes.Clear();
                RootNodes.Add(rootAll);
            }
            else
            {
                uiDispatcher.Invoke(() => {
                    LoggerService.LogInfo($"Swapping tree root via Invoke. Previous count: {RootNodes.Count}");
                    RootNodes.Clear();
                    RootNodes.Add(rootAll);
                });
            }
            
            LoggerService.LogInfo($"Tree root swapped. New count: {RootNodes.Count}");
            LoggerService.LogInfo("Tree built and swapped successfully.");
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
                // LoggerService.LogInfo($"Auto-checking element: {node.ElementId}"); // Too noisy for 1000s of items
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

    private HashSet<Autodesk.Revit.DB.ElementId> _preSearchCheckedIds = null;

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
        FilterText = string.Empty;
        // No restauramos el estado aquí porque ya se maneja en OnFilterTextChanged si es necesario
        // pero podemos forzar una actualización
    }
}
