using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PrimeraPrueba.Models;
using PrimeraPrueba.Services;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
namespace PrimeraPrueba.ViewModels;

public partial class SelectionFilterViewModel : ObservableObject
{
    private readonly RevitSelectionService _selectionService;
    private readonly List<ElementModel> _allAvailableElements;

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

    public SelectionFilterViewModel(RevitSelectionService selectionService)
    {
        _selectionService = selectionService;
        _allAvailableElements = _selectionService.GetAvailableElements();
        
        StatusMessage = $"Elementos encontrados: {_allAvailableElements.Count}";
        
        InitializeLists();
    }

    private void InitializeLists()
    {
        Categories.Add("Todos");
        Families.Add("Todos");
        Types.Add("Todos");
        Levels.Add("Todos");
        Worksets.Add("Todos");

        foreach (var c in _allAvailableElements.Select(e => e.CategoryName).Distinct().OrderBy(x => x))
            Categories.Add(c);
            
        foreach (var f in _allAvailableElements.Select(e => e.FamilyName).Distinct().OrderBy(x => x))
            Families.Add(f);
            
        foreach (var t in _allAvailableElements.Select(e => e.TypeName).Distinct().OrderBy(x => x))
            Types.Add(t);
            
        foreach (var l in _allAvailableElements.Select(e => e.LevelName).Distinct().OrderBy(x => x))
            Levels.Add(l);
            
        foreach (var w in _allAvailableElements.Select(e => e.WorksetName).Distinct().OrderBy(x => x))
            Worksets.Add(w);

        SelectedCategory = "Todos";
        SelectedFamily = "Todos";
        SelectedType = "Todos";
        SelectedLevel = "Todos";
        SelectedWorkset = "Todos";
    }

    [RelayCommand]
    private void ApplyFilter()
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
        
        StatusMessage = $"Elementos seleccionados: {filteredList.Count}";
    }

    [RelayCommand]
    private void ClearFilters()
    {
        SelectedCategory = "Todos";
        SelectedFamily = "Todos";
        SelectedType = "Todos";
        SelectedLevel = "Todos";
        SelectedWorkset = "Todos";
        ApplyFilter();
    }
}
