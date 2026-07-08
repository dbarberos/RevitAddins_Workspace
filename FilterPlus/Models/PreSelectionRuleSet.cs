using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FilterPlus.Services;

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

    private bool _isPruning;
    private string Id => $"RuleSet #{GetHashCode() % 1000:D3}";

    public void PruneDependentRules()
    {
        if (_isPruning) return;
        _isPruning = true;
        try
        {
            bool hasCategory = Children.OfType<PreSelectionRule>().Any(r => r.SelectedProperty == "Categorías");
            bool hasFamily = Children.OfType<PreSelectionRule>().Any(r => r.SelectedProperty == "Familias");
            LoggerService.LogInfo($"[{Id}] PruneDependentRules check: hasCategory={hasCategory}, hasFamily={hasFamily}");

            var toRemove = new List<PreSelectionRule>();

            foreach (var child in Children.OfType<PreSelectionRule>())
            {
                if (child.SelectedProperty == "Familias" && !hasCategory)
                {
                    toRemove.Add(child);
                }
                else if (child.SelectedProperty == "Tipos" && (!hasCategory || !hasFamily))
                {
                    toRemove.Add(child);
                }
            }

            foreach (var rule in toRemove)
            {
                LoggerService.LogInfo($"[{Id}] PruneDependentRules: Removing invalid dependent rule (SelectedProperty={rule.SelectedProperty})");
                Children.Remove(rule);
            }

            if (toRemove.Count > 0)
            {
                _isPruning = false;
                PruneDependentRules();
            }
        }
        finally
        {
            _isPruning = false;
        }
    }

    private bool _isUpdatingProperties;
    public void NotifyRulePropertiesChanged()
    {
        if (_isUpdatingProperties) return;
        _isUpdatingProperties = true;
        try
        {
            LoggerService.LogInfo($"[{Id}] NotifyRulePropertiesChanged: Refreshing properties lists for all child rules.");
            foreach (var child in Children)
            {
                if (child is PreSelectionRule rule)
                {
                    rule.RefreshPropertiesList();
                }
            }
        }
        finally
        {
            _isUpdatingProperties = false;
        }
    }

    private bool _isUpdatingValues;
    public void NotifyRuleValuesChanged()
    {
        if (_isUpdatingValues) return;
        _isUpdatingValues = true;
        try
        {
            LoggerService.LogInfo($"[{Id}] NotifyRuleValuesChanged: Refreshing value lists for all child rules.");
            foreach (var child in Children)
            {
                if (child is PreSelectionRule rule)
                {
                    rule.RefreshValuesList();
                }
            }
        }
        finally
        {
            _isUpdatingValues = false;
        }
    }

    [RelayCommand]
    private void AddRule()
    {
        LoggerService.LogInfo($"[{Id}] AddRule command triggered.");
        var rule = new PreSelectionRule(this, _allElements);
        AddNode(rule);
        NotifyRulePropertiesChanged();
        NotifyRuleValuesChanged();
    }

    [RelayCommand]
    private void AddSet()
    {
        LoggerService.LogInfo($"[{Id}] AddSet command triggered.");
        var set = new PreSelectionRuleSet(this, false, _allElements);
        
        // Add a default rule inside the new set to make it immediately usable
        var defaultRule = new PreSelectionRule(set, _allElements);
        set.AddNode(defaultRule);

        AddNode(set);
    }
}
