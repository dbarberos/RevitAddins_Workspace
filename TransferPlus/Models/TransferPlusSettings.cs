namespace TransferPlus.Models;

public enum TabOption
{
    DBDevDefault,
    RevitDefault,
    Custom
}

public class TransferPlusSettings
{
    public TabOption SelectedTabOption { get; set; } = TabOption.DBDevDefault;
    public string CustomTabName { get; set; } = "My Custom Tab";
    public bool UseAsContextualFilter { get; set; } = false;
}
