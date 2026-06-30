using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FilterPlus.Models;
using FilterPlus.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FilterPlus.ViewModels;

public partial class PreSelectionViewModel : ObservableObject
{
    private readonly SelectionFilterViewModel _mainViewModel;
    private readonly Action _closeAction;
    private List<ElementModel> _elements;

    [ObservableProperty] private PreSelectionRuleSet _rootSet;
    [ObservableProperty] private bool _isAllModelElements = true;
    [ObservableProperty] private bool _isElementsInView = false;

    private bool _isUpdatingScope;

    public PreSelectionViewModel(SelectionFilterViewModel mainViewModel, Action closeAction)
    {
        _mainViewModel = mainViewModel;
        _closeAction = closeAction;
        _elements = mainViewModel.AllModelElements;
        
        RootSet = new PreSelectionRuleSet(null, true, _elements);
        
        // Start with one rule in the root set
        var defaultRule = new PreSelectionRule(RootSet, _elements);
        RootSet.AddNode(defaultRule);
    }

    [RelayCommand]
    private void RemoveRule(PreSelectionRule rule)
    {
        if (rule == null) return;
        rule.Parent?.Children.Remove(rule);
    }

    [RelayCommand]
    private void RemoveSet(PreSelectionRuleSet set)
    {
        if (set == null) return;
        set.Parent?.Children.Remove(set);
    }

    partial void OnIsAllModelElementsChanged(bool value)
    {
        if (_isUpdatingScope) return;
        _isUpdatingScope = true;
        try
        {
            if (value)
            {
                IsElementsInView = false;
                UpdateElementScope();
            }
            else
            {
                if (!IsElementsInView)
                {
                    IsAllModelElements = true;
                }
            }
        }
        finally
        {
            _isUpdatingScope = false;
        }
    }

    partial void OnIsElementsInViewChanged(bool value)
    {
        if (_isUpdatingScope) return;
        _isUpdatingScope = true;
        try
        {
            if (value)
            {
                IsAllModelElements = false;
                UpdateElementScope();
            }
            else
            {
                if (!IsAllModelElements)
                {
                    IsElementsInView = true;
                }
            }
        }
        finally
        {
            _isUpdatingScope = false;
        }
    }

    private void UpdateElementScope()
    {
        _elements = IsAllModelElements 
            ? _mainViewModel.AllModelElements 
            : _mainViewModel.ElementsBelongingToView;

        RootSet?.UpdateElements(_elements);
    }

    [RelayCommand]
    private void Apply()
    {
        var matchingIds = new HashSet<Autodesk.Revit.DB.ElementId>(new ElementIdEqualityComparer());

        foreach (var el in _elements)
        {
            if (el.Id == null) continue;

            if (MatchesSet(el, RootSet))
            {
                matchingIds.Add(el.Id);
            }
        }

        var targetScope = IsAllModelElements 
            ? SelectionScope.AllModelElements 
            : SelectionScope.ElementsBelongingToView;

        _mainViewModel.ApplyPreSelection(matchingIds, targetScope);
        _closeAction?.Invoke();
    }

    [RelayCommand]
    private void Cancel()
    {
        _closeAction?.Invoke();
    }

    private bool MatchesSet(ElementModel element, PreSelectionRuleSet set)
    {
        if (set == null || !set.Children.Any()) return true;

        bool isAnd = set.LogicalOperator.StartsWith("AND", StringComparison.OrdinalIgnoreCase);

        if (isAnd)
        {
            foreach (var child in set.Children)
            {
                if (!MatchesNode(element, child))
                    return false;
            }
            return true;
        }
        else // OR
        {
            foreach (var child in set.Children)
            {
                if (MatchesNode(element, child))
                    return true;
            }
            return false;
        }
    }

    private bool MatchesNode(ElementModel element, IPreselRuleNode node)
    {
        if (node is PreSelectionRule rule)
        {
            return MatchesSingleRule(element, rule);
        }
        else if (node is PreSelectionRuleSet set)
        {
            return MatchesSet(element, set);
        }
        return false;
    }

    private bool MatchesSingleRule(ElementModel element, PreSelectionRule rule)
    {
        if (element == null || rule == null) return false;

        string propertyValue = rule.SelectedProperty switch
        {
            "Categorías" => element.CategoryName,
            "Niveles" => element.LevelName,
            "Sistemas" => element.SystemName,
            "Zonas" => element.ZoneName,
            "Worksets" => element.WorksetName,
            "Fases" => element.PhaseName,
            "System Classification" => element.SystemClassification,
            "MEP Domain" => element.MepDomain,
            _ => null
        };

        if (propertyValue == null || propertyValue == "N/A") return false;

        string target = rule.SelectedValue ?? string.Empty;
        return string.Equals(propertyValue, target, StringComparison.OrdinalIgnoreCase);
    }
}
