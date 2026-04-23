using Autodesk.Revit.DB;

namespace AiRenderLocal.Models;

public class ElementModel
{
    public ElementId Id { get; set; }
    public string CategoryName { get; set; }
    public string FamilyName { get; set; }
    public string TypeName { get; set; }
    public string LevelName { get; set; }
    public string WorksetName { get; set; }
}
