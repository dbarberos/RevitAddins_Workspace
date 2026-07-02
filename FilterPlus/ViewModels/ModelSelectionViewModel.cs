using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FilterPlus.Models;

namespace FilterPlus.ViewModels;

public partial class ModelSelectionViewModel : ObservableObject
{
    private readonly Action<List<RevitModelRepresentation>> _onApply;
    private readonly Action _onCancel;

    [ObservableProperty] private bool _isSelectAll;
    private bool _isUpdatingAll;
    private bool _isUpdatingFromAll;

    public ObservableCollection<ModelSelectionItemViewModel> Models { get; } = new();

    public ModelSelectionViewModel(
        List<RevitModelRepresentation> allModels, 
        List<RevitModelRepresentation> currentlySelected,
        Action<List<RevitModelRepresentation>> onApply,
        Action onCancel)
    {
        _onApply = onApply;
        _onCancel = onCancel;

        foreach (var model in allModels)
        {
            bool isSelected = currentlySelected.Any(m => m.DisplayName == model.DisplayName);
            Models.Add(new ModelSelectionItemViewModel(model, isSelected, OnItemSelectionChanged));
        }

        // Set initial SelectAll state
        _isUpdatingFromAll = true;
        IsSelectAll = Models.Count > 0 && Models.All(m => m.IsSelected);
        _isUpdatingFromAll = false;
    }

    private void OnItemSelectionChanged()
    {
        if (_isUpdatingAll) return;

        _isUpdatingFromAll = true;
        IsSelectAll = Models.Count > 0 && Models.All(m => m.IsSelected);
        _isUpdatingFromAll = false;
    }

    partial void OnIsSelectAllChanged(bool value)
    {
        if (_isUpdatingFromAll) return;

        _isUpdatingAll = true;
        foreach (var model in Models)
        {
            model.IsSelected = value;
        }
        _isUpdatingAll = false;
    }

    [RelayCommand]
    private void Apply()
    {
        var selected = Models.Where(m => m.IsSelected).Select(m => m.Model).ToList();
        if (!selected.Any())
        {
            // Must select at least one model
            return;
        }
        _onApply?.Invoke(selected);
    }

    [RelayCommand]
    private void Cancel()
    {
        _onCancel?.Invoke();
    }
}

public partial class ModelSelectionItemViewModel : ObservableObject
{
    public RevitModelRepresentation Model { get; }
    private readonly Action _onSelectionChanged;
    private bool _isSelected;

    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            if (SetProperty(ref _isSelected, value))
            {
                _onSelectionChanged?.Invoke();
            }
        }
    }

    public string DisplayName => Model.DisplayName;

    public ModelSelectionItemViewModel(RevitModelRepresentation model, bool isSelected, Action onSelectionChanged)
    {
        Model = model;
        _isSelected = isSelected;
        _onSelectionChanged = onSelectionChanged;
    }
}
