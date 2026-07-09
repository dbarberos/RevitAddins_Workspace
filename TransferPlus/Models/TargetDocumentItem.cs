using Autodesk.Revit.DB;

namespace TransferPlus.Models;

public class TargetDocumentItem
{
    public Document Document { get; set; } = null!;
    public string Title { get; set; } = string.Empty;
    public bool IsLink { get; set; }
    public bool IsChecked { get; set; }
}
