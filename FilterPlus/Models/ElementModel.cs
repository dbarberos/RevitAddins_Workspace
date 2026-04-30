using Autodesk.Revit.DB;

namespace FilterPlus.Models;

public class ElementModel
{
    public ElementId Id { get; set; }
    public string CategoryName { get; set; }
    public string FamilyName { get; set; }
    public string TypeName { get; set; }
    public string LevelName { get; set; }
    public string WorksetName { get; set; }
    
    // Metadata for advanced filtering
    public bool IsModelElement { get; set; }
    public bool IsAnnotation { get; set; }
    public bool HasBoundingBox { get; set; }
    
    // Phase information
    public string PhaseName { get; set; }
    public int PhaseOrder { get; set; }
}
