using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace FilterPlus.Models;

public partial class PreSelectionRule : ObservableObject, IPreselRuleNode
{
    private IEnumerable<ElementModel> _allElements;

    public PreSelectionRuleSet Parent { get; }

    [ObservableProperty] private string _selectedProperty;
    [ObservableProperty] private string _selectedValue;

    public List<string> Properties { get; } = new()
    {
        "Categorías",
        "Niveles",
        "Sistemas",
        "Zonas",
        "Worksets",
        "Fases",
        "System Classification",
        "MEP Domain"
    };

    public ObservableCollection<string> AvailableValues { get; } = new();

    public PreSelectionRule(PreSelectionRuleSet parent, IEnumerable<ElementModel> allElements)
    {
        Parent = parent;
        _allElements = allElements;
        SelectedProperty = Properties.FirstOrDefault();
    }

    public void UpdateElements(IEnumerable<ElementModel> elements)
    {
        var previousValue = SelectedValue;
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
    }

    partial void OnSelectedPropertyChanged(string value)
    {
        UpdateAvailableValues();
        SelectedValue = AvailableValues.FirstOrDefault();
    }

    private void UpdateAvailableValues()
    {
        AvailableValues.Clear();
        if (_allElements == null) return;

        IEnumerable<string> values = SelectedProperty switch
        {
            "Categorías" => _allElements.Select(e => e.CategoryName).Distinct(),
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

        foreach (var val in sortedValues)
        {
            AvailableValues.Add(val);
        }
    }
}
