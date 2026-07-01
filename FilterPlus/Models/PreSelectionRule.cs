using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using FilterPlus.Services;

namespace FilterPlus.Models;

public partial class PreSelectionRule : ObservableObject, IPreselRuleNode
{
    private IEnumerable<ElementModel> _allElements;
    private bool _isUpdatingAvailableValues;
    private bool _isUpdatingProperties;

    public PreSelectionRuleSet Parent { get; }

    [ObservableProperty] private string _selectedProperty;
    [ObservableProperty] private string _selectedValue;

    public ObservableCollection<string> Properties { get; } = new();
    public ObservableCollection<string> AvailableValues { get; } = new();

    private string Id => $"Rule #{GetHashCode() % 1000:D3}";

    public PreSelectionRule(PreSelectionRuleSet parent, IEnumerable<ElementModel> allElements)
    {
        Parent = parent;
        _allElements = allElements;
        LoggerService.LogInfo($"[{Id}] Constructor called.");
        RefreshPropertiesList();
        SelectedProperty = Properties.FirstOrDefault();
    }

    public void UpdateElements(IEnumerable<ElementModel> elements)
    {
        var previousValue = SelectedValue;
        LoggerService.LogInfo($"[{Id}] UpdateElements called. previousValue = '{previousValue}'");
        _allElements = elements;
        UpdateAvailableValues();
        
        if (AvailableValues.Contains(previousValue))
        {
            SelectedValue = previousValue;
        }
        else
        {
            SelectedValue = AvailableValues.FirstOrDefault();
        }
        LoggerService.LogInfo($"[{Id}] UpdateElements complete. SelectedValue is '{SelectedValue}'");
    }

    public void RefreshPropertiesList()
    {
        if (_isUpdatingProperties) return;
        
        var currentSelection = SelectedProperty;
        
        try
        {
            bool hasCategorySibling = false;
            bool hasFamilySibling = false;

            if (Parent != null)
            {
                foreach (var sibling in Parent.Children)
                {
                    if (sibling is PreSelectionRule rule && rule != this)
                    {
                        if (rule.SelectedProperty == "Categorías")
                            hasCategorySibling = true;
                        if (rule.SelectedProperty == "Familias")
                            hasFamilySibling = true;
                    }
                }
            }

            bool showFamilias = hasCategorySibling;
            bool showTipos = hasFamilySibling;

            LoggerService.LogInfo($"[{Id}] RefreshPropertiesList: showFamilias={showFamilias}, showTipos={showTipos}, currentSelection='{currentSelection}'");

            var newPropertiesList = new List<string> { "Categorías" };
            if (showFamilias) newPropertiesList.Add("Familias");
            if (showTipos) newPropertiesList.Add("Tipos");
            newPropertiesList.AddRange(new[] { "Niveles", "Sistemas", "Zonas", "Worksets", "Fases", "System Classification", "MEP Domain" });

            if (Properties.SequenceEqual(newPropertiesList))
            {
                LoggerService.LogInfo($"[{Id}] RefreshPropertiesList: properties list is identical. Returning early.");
                return;
            }

            _isUpdatingProperties = true;
            LoggerService.LogInfo($"[{Id}] RefreshPropertiesList: properties changed. Clearing and rebuilding properties list.");
            Properties.Clear();
            foreach (var p in newPropertiesList) Properties.Add(p);

            // If the previous selection is still valid, restore it while the guard is active
            // so we don't trigger unnecessary updates.
            if (currentSelection != null && Properties.Contains(currentSelection))
            {
                SelectedProperty = currentSelection;
            }
        }
        finally
        {
            _isUpdatingProperties = false;
        }

        // If we lost our selection (or it's the first time), set it now.
        // This is outside the guard, so it WILL trigger OnSelectedPropertyChanged!
        if (SelectedProperty == null || !Properties.Contains(SelectedProperty))
        {
            SelectedProperty = Properties.FirstOrDefault();
            LoggerService.LogInfo($"[{Id}] RefreshPropertiesList complete. SelectedProperty changed to default '{SelectedProperty}'");
        }
        else
        {
            LoggerService.LogInfo($"[{Id}] RefreshPropertiesList complete. SelectedProperty restored to '{SelectedProperty}'");
        }
    }

    public void RefreshValuesList()
    {
        var prevValue = SelectedValue;
        LoggerService.LogInfo($"[{Id}] RefreshValuesList called. prevValue = '{prevValue}'");
        UpdateAvailableValues();
        
        if (!string.IsNullOrEmpty(prevValue) && AvailableValues.Contains(prevValue))
        {
            SelectedValue = prevValue;
        }
        else
        {
            SelectedValue = AvailableValues.FirstOrDefault();
        }
        LoggerService.LogInfo($"[{Id}] RefreshValuesList: SelectedValue set/restored to '{SelectedValue}' (was '{prevValue}')");
    }

    partial void OnSelectedPropertyChanged(string value)
    {
        if (_isUpdatingProperties)
        {
            LoggerService.LogInfo($"[{Id}] OnSelectedPropertyChanged: Ignored change to '{value}' because _isUpdatingProperties is true.");
            return;
        }

        LoggerService.LogInfo($"[{Id}] OnSelectedPropertyChanged: Property changed to '{value}'");
        UpdateAvailableValues();
        SelectedValue = AvailableValues.FirstOrDefault();
        LoggerService.LogInfo($"[{Id}] OnSelectedPropertyChanged: SelectedValue initialized to default '{SelectedValue}'");
        
        // Cascading deletion check: if Categorías or Familias changes, prune invalid children
        LoggerService.LogInfo($"[{Id}] OnSelectedPropertyChanged: Triggering Parent.PruneDependentRules()");
        Parent?.PruneDependentRules();
        
        // Notify parent to refresh property lists and value lists of siblings
        LoggerService.LogInfo($"[{Id}] OnSelectedPropertyChanged: Notifying parent properties/values changed");
        Parent?.NotifyRulePropertiesChanged();
        Parent?.NotifyRuleValuesChanged();
    }

    partial void OnSelectedValueChanged(string value)
    {
        LoggerService.LogInfo($"[{Id}] OnSelectedValueChanged: Value changed to '{value}'. _isUpdatingAvailableValues={_isUpdatingAvailableValues}");
        if (_isUpdatingAvailableValues) return;
        
        LoggerService.LogInfo($"[{Id}] OnSelectedValueChanged: Notifying parent values changed.");
        Parent?.NotifyRuleValuesChanged();
    }

    private void UpdateAvailableValues()
    {
        if (_allElements == null)
        {
            LoggerService.LogInfo($"[{Id}] UpdateAvailableValues: _allElements is null. Returning.");
            return;
        }

        LoggerService.LogInfo($"[{Id}] UpdateAvailableValues: Calculating values for '{SelectedProperty}'");
        IEnumerable<string> values = SelectedProperty switch
        {
            "Categorías" => _allElements.Select(e => e.CategoryName).Distinct(),
            "Familias" => GetFamiliesFilteredBySiblings(),
            "Tipos" => GetTypesFilteredBySiblings(),
            "Niveles" => _allElements.Select(e => e.LevelName).Distinct(),
            "Sistemas" => _allElements.Select(e => e.SystemName).Distinct(),
            "Zonas" => _allElements.Select(e => e.ZoneName).Distinct(),
            "Worksets" => _allElements.Select(e => e.WorksetName).Distinct(),
            "Fases" => _allElements.Select(e => e.PhaseName).Distinct(),
            "System Classification" => _allElements.Select(e => e.SystemClassification).Distinct(),
            "MEP Domain" => _allElements.Select(e => e.MepDomain).Distinct(),
            _ => Enumerable.Empty<string>()
        };

        var sortedValues = values
            .Where(v => !string.IsNullOrEmpty(v) && v != "N/A")
            .OrderBy(x => x)
            .ToList();

        if (AvailableValues.SequenceEqual(sortedValues))
        {
            LoggerService.LogInfo($"[{Id}] UpdateAvailableValues: values list is identical. Returning early.");
            return;
        }

        LoggerService.LogInfo($"[{Id}] UpdateAvailableValues: values changed. Clearing and adding {sortedValues.Count} items.");
        _isUpdatingAvailableValues = true;
        try
        {
            AvailableValues.Clear();
            foreach (var val in sortedValues)
            {
                AvailableValues.Add(val);
            }
        }
        finally
        {
            _isUpdatingAvailableValues = false;
        }
        LoggerService.LogInfo($"[{Id}] UpdateAvailableValues complete.");
    }

    private IEnumerable<string> GetFamiliesFilteredBySiblings()
    {
        if (Parent == null) return _allElements.Select(e => e.FamilyName).Distinct();

        var selectedCategoryNames = Parent.Children
            .OfType<PreSelectionRule>()
            .Where(r => r != this && r.SelectedProperty == "Categorías" && !string.IsNullOrEmpty(r.SelectedValue))
            .Select(r => r.SelectedValue)
            .ToHashSet();

        LoggerService.LogInfo($"[{Id}] GetFamiliesFilteredBySiblings: Sibling Category filter count: {selectedCategoryNames.Count}");
        if (selectedCategoryNames.Count > 0)
        {
            return _allElements
                .Where(e => selectedCategoryNames.Contains(e.CategoryName))
                .Select(e => e.FamilyName)
                .Distinct();
        }

        return _allElements.Select(e => e.FamilyName).Distinct();
    }

    private IEnumerable<string> GetTypesFilteredBySiblings()
    {
        if (Parent == null) return _allElements.Select(e => e.TypeName).Distinct();

        var selectedFamilyNames = Parent.Children
            .OfType<PreSelectionRule>()
            .Where(r => r != this && r.SelectedProperty == "Familias" && !string.IsNullOrEmpty(r.SelectedValue))
            .Select(r => r.SelectedValue)
            .ToHashSet();

        LoggerService.LogInfo($"[{Id}] GetTypesFilteredBySiblings: Sibling Family filter count: {selectedFamilyNames.Count}");
        if (selectedFamilyNames.Count > 0)
        {
            return _allElements
                .Where(e => selectedFamilyNames.Contains(e.FamilyName))
                .Select(e => e.TypeName)
                .Distinct();
        }

        return Enumerable.Empty<string>(); // Types strictly require a sibling Family rule
    }
}
