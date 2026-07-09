using Autodesk.Revit.DB;

namespace TransferPlus.Models;

public class TransferItem
{
    public ElementId ElementId { get; set; } = ElementId.InvalidElementId;
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Family { get; set; } = string.Empty;
    public string ElementType { get; set; } = string.Empty;
    public bool IsLoadable { get; set; }
    public bool IsNotTransferable { get; set; }
}
