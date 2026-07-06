// ==============================================================================
// SKILL: revit-api-mep (MEP Systems and Routing)
// ANTI-PATTERN: Manual Family Instance Placement for Fittings
// PURPOSE: Explains why custom vector math placements fail to hook up routing correctly.
// ==============================================================================

using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;

namespace RevitAddinBase.Mep
{
    public class ManualFittingPlacementAntiPattern
    {
        public FamilyInstance PlaceManualElbow(Document doc, XYZ intersectionPoint, FamilySymbol elbowSymbol)
        {
            // FATAL: Attempting to insert an elbow fitting manually using point-based instances.
            // This ignores routing preferences, violates connectivity rules, and leaves pipe ends open (unconnected).
            FamilyInstance manualElbow = doc.Create.NewFamilyInstance(intersectionPoint, elbowSymbol, StructuralType.NonStructural);
            return manualElbow;
        }
    }
}
