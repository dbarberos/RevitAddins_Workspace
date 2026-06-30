using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FilterPlus.Models;

public partial class PreSelectionRuleSet : ObservableObject, IPreselRuleNode
{
    private IEnumerable<ElementModel> _allElements;

    public PreSelectionRuleSet Parent { get; }

    [ObservableProperty] private string _logicalOperator;
    [ObservableProperty] private bool _isRoot;

    public ObservableCollection<IPreselRuleNode> Children { get; } = new();

    public List<string> LogicalOperators { get; } = new()
    {
        "AND (All rules must be true)",
        "OR (Any rule may be true)"
    };

    public PreSelectionRuleSet(PreSelectionRuleSet parent, bool isRoot, IEnumerable<ElementModel> allElements)
    {
        Parent = parent;
        IsRoot = isRoot;
        _allElements = allElements;
        LogicalOperator = LogicalOperators.FirstOrDefault();
    }

    public void UpdateElements(IEnumerable<ElementModel> elements)
    {
        _allElements = elements;
        foreach (var child in Children)
        {
            child.UpdateElements(elements);
        }
    }

    public void AddNode(IPreselRuleNode node)
    {
        if (node == null) return;

        if (node is PreSelectionRule rule)
        {
            int index = Children.Count(c => c is PreSelectionRule);
            Children.Insert(index, rule);
        }
        else if (node is PreSelectionRuleSet set)
        {
            Children.Add(set);
        }
    }

    [RelayCommand]
    private void AddRule()
    {
        var rule = new PreSelectionRule(this, _allElements);
        AddNode(rule);
    }

    [RelayCommand]
    private void AddSet()
    {
        var set = new PreSelectionRuleSet(this, false, _allElements);
        
        // Add a default rule inside the new set to make it immediately usable
        var defaultRule = new PreSelectionRule(set, _allElements);
        set.AddNode(defaultRule);

        AddNode(set);
    }
}
