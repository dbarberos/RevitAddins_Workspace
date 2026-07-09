using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
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

    private bool? _isChecked = false;

    public bool? IsChecked
    {
        get => _isChecked;
        set
        {
            if (SetProperty(ref _isChecked, value))
            {
                UpdateChildrenCheckState(value);
                Parent?.UpdateParentCheckState();
            }
        }
    }

    public TransferItem? Item { get; set; }

    public ObservableCollection<TreeItemViewModel> Children { get; } = new();

    public TreeItemViewModel? Parent { get; set; }

    public TreeItemViewModel(string name, string category, TransferItem? item = null)
    {
        Name = name;
        Category = category;
        Item = item;
    }

    private void UpdateChildrenCheckState(bool? value)
    {
        if (value == null) return;

        foreach (var child in Children)
        {
            if (child._isChecked != value)
            {
                child._isChecked = value;
                child.OnPropertyChanged(nameof(IsChecked));
                child.UpdateChildrenCheckState(value);
            }
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
            _isChecked = newState;
            OnPropertyChanged(nameof(IsChecked));
            Parent?.UpdateParentCheckState();
        }
    }
}
