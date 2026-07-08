using Autodesk.Revit.DB;

namespace FilterPlus.Models;

public class RevitModelRepresentation
{
    public string DisplayName { get; }
    public RevitLinkInstance LinkInstance { get; }
    public Document Document { get; }

    public RevitModelRepresentation(string displayName, RevitLinkInstance linkInstance, Document document)
    {
        DisplayName = displayName;
        LinkInstance = linkInstance;
        Document = document;
    }
}
