using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using TransferPlus.Models;

namespace TransferPlus.ViewModels;

public partial class TreeItemViewModel : ObservableObject
{
    [ObservableProperty]
    private string _name = string.Empty;

    [ObservableProperty]
    private string _category = string.Empty;

    [ObservableProperty]
    private bool _isExpanded = true;

    [ObservableProperty]
    private int _count;

    [ObservableProperty]
    private string _numText = string.Empty;

    [ObservableProperty]
    private bool _isVisible = true;

    public int Level { get; set; }
    public System.Windows.Thickness IndentMargin => new System.Windows.Thickness(Level * 15, 0, 0, 0);

    public static bool IsBulkUpdating { get; set; }

    private bool? _isChecked = false;
    private bool _isUpdatingState;

    public bool? IsChecked
    {
        get => _isChecked;
        set
        {
            // Intercept user click (attempting to go to null) and force to false.
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
                    _isUpdatingState = true;
                    if (value.HasValue)
                    {
                        UpdateChildrenCheckState(value.Value);
                    }
                    Parent?.UpdateParentCheckState();
                    _isUpdatingState = false;
                    CommunityToolkit.Mvvm.Messaging.WeakReferenceMessenger.Default.Send(new CheckedItemsChangedMessage());
                }
            }
        }
    }

    public Elemento? Item { get; set; }

    public ObservableCollection<TreeItemViewModel> Children { get; } = new();

    public TreeItemViewModel? Parent { get; set; }

    public TreeItemViewModel(string name, string category, Elemento? item = null, TreeItemViewModel? parent = null, int level = 0)
    {
        Name = name;
        Category = category;
        Item = item;
        Parent = parent;
        Level = level;
    }

    private void UpdateChildrenCheckState(bool value)
    {
        foreach (var child in Children)
        {
            child._isUpdatingState = true;
            child.IsChecked = value;
            child._isUpdatingState = false;
            child.UpdateChildrenCheckState(value);
        }
    }

    private void UpdateParentCheckState()
    {
        if (!Children.Any()) return;

        bool allChecked = Children.All(c => c.IsChecked == true);
        bool allUnchecked = Children.All(c => c.IsChecked == false);

        bool? newState = null;
        if (allChecked) newState = true;
        else if (allUnchecked) newState = false;

        if (_isChecked != newState)
        {
            _isUpdatingState = true;
            IsChecked = newState;
            _isUpdatingState = false;
            Parent?.UpdateParentCheckState();
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

            bool? newState = null;
            if (allChecked) newState = true;
            else if (allUnchecked) newState = false;

            if (_isChecked != newState)
            {
                _isUpdatingState = true;
                IsChecked = newState;
                _isUpdatingState = false;
            }
        }
    }
}

public class CheckedItemsChangedMessage { }
