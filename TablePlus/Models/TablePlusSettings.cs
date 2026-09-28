using System;
using System.Xml.Serialization;

namespace TablePlus.Models;

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

public class TablePlusSettings
{
    public TabOption SelectedTabOption { get; set; } = TabOption.AddInsDefaultTab;
    public string CustomTabName { get; set; } = "TablePlus";
    public bool UseAsContextualFilter { get; set; } = false;
}
