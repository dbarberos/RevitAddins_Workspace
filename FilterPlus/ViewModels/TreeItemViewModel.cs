using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;

namespace FilterPlus.ViewModels;

public partial class TreeItemViewModel : ObservableObject
{
    private bool? _isChecked = false;
    private TreeItemViewModel _parent;
    
    public static bool IsBulkUpdating { get; set; }

    public string Name { get; set; }
    public ElementId ElementId { get; set; }
    public string SearchableMetadata { get; set; } = string.Empty;
    public ObservableCollection<TreeItemViewModel> Children { get; } = new();

    private bool _isUpdatingState;

    public bool? IsChecked
    {
        get => _isChecked;
        set
        {
            // Interceptar el clic del usuario (intentando pasar de True a Null) y forzar a False.
            if (!_isUpdatingState && value == null)
            {
                value = false;
            }

            if (_isChecked != value)
            {
                _isChecked = value;
                OnPropertyChanged(nameof(IsChecked));

                if (!_isUpdatingState && !IsBulkUpdating)
                {
                    if (value.HasValue)
                    {
                        UpdateChildren(value.Value);
                    }
                    _parent?.ReevaluateState();
                    SelectionChangedCallback?.Invoke();
                }
            }
        }
    }

    [ObservableProperty] private bool _isExpanded;
    [ObservableProperty] private int _count;
    [ObservableProperty] private bool _isVisible = true;

    public int Level { get; set; }
    public System.Windows.Thickness IndentMargin => new System.Windows.Thickness(Level * 15, 0, 0, 0);

    public System.Action SelectionChangedCallback { get; set; }

    public TreeItemViewModel(string name, TreeItemViewModel parent = null, int level = 0, System.Action selectionChangedCallback = null)
    {
        Name = name;
        _parent = parent;
        Level = level;
        SelectionChangedCallback = selectionChangedCallback;
    }

    private void UpdateChildren(bool value)
    {
        foreach (var child in Children)
        {
            child._isUpdatingState = true;
            child.IsChecked = value;
            child._isUpdatingState = false;
            child.UpdateChildren(value);
        }
    }

    public void ReevaluateState()
    {
        if (Children.Count == 0) return;

        bool allChecked = Children.All(c => c.IsChecked == true);
        bool allUnchecked = Children.All(c => c.IsChecked == false);

        bool? newState;
        if (allChecked) newState = true;
        else if (allUnchecked) newState = false;
        else newState = null; // Indeterminate

        if (_isChecked != newState)
        {
            _isUpdatingState = true;
            IsChecked = newState;
            _isUpdatingState = false;
            _parent?.ReevaluateState();
        }
    }

    public void GetAllSelectedIds(List<ElementId> ids)
    {
        if (ElementId != null && IsChecked == true)
        {
            ids.Add(ElementId);
        }

        foreach (var child in Children)
        {
            child.GetAllSelectedIds(ids);
        }
    }
    public void RefreshState()
    {
        foreach (var child in Children)
        {
            child.RefreshState();
        }
        
        if (Children.Count > 0)
        {
            bool allChecked = Children.All(c => c.IsChecked == true);
            bool allUnchecked = Children.All(c => c.IsChecked == false);

            bool? newState;
            if (allChecked) newState = true;
            else if (allUnchecked) newState = false;
            else newState = null; 

            if (_isChecked != newState)
            {
                _isUpdatingState = true;
                IsChecked = newState;
                _isUpdatingState = false;
            }
        }
    }

    public void SetCheckedState(bool value)
    {
        _isUpdatingState = true;
        IsChecked = value;
        foreach (var child in Children)
        {
            child.SetCheckedState(value);
        }
        _isUpdatingState = false;
    }
}
