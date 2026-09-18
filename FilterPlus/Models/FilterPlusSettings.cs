using System;
using System.Xml.Serialization;

namespace FilterPlus.Models;

public enum TabOption
{
    [XmlEnum("AddInsDefaultTab")]
    AddInsDefaultTab,

    [XmlEnum("DBDevDefault")]
    DBDevDefault,

    [XmlEnum("RevitDefault")]
    RevitDefault,

    [XmlEnum("Custom")]
    Custom
}

public class FilterPlusSettings
{
    public TabOption SelectedTabOption { get; set; } = TabOption.AddInsDefaultTab;
    public string CustomTabName { get; set; } = "My Custom Tab";
    public bool UseAsContextualFilter { get; set; } = false;
}
