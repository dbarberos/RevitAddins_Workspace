using TablePlus.Models;

namespace TablePlus.Models;

/// <summary>
/// Selectable source item in the initial "Select Source" dropdown dialog.
/// </summary>
public class TableSourcePickerItem
{
    public string DisplayName { get; set; } = string.Empty;
    public TableSourceItemModel? SourceModel { get; set; }
    public bool IsLocalDefault => SourceModel == null;
    public ExternalTableSourceType? SourceType => SourceModel?.SourceType;

    public override string ToString() => DisplayName;
}
