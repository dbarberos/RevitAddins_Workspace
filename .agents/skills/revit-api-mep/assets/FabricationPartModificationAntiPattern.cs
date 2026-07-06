// ==============================================================================
// SKILL: revit-api-mep (Fabrication Modeling APIs)
// ANTI-PATTERN: Location Curve Modification on Fabrication Parts
// PURPOSE: Explains why stretching fabrication parts like system pipes corrupts models.
// ==============================================================================

using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Fabrication;

namespace RevitAddinBase.Mep
{
    public class FabricationPartModificationAntiPattern
    {
        public void MutateCurveError(Document doc, ElementId partId, Curve newCurve)
        {
            // FATAL: Attempting to stretch fabrication parts by updating location curves.
            // Fabrication Parts rely on fabrication database catalogs; altering curves
            // beyond catalog constraints leads to immediate file corruption or parameter errors.
            FabricationPart part = doc.GetElement(partId) as FabricationPart;
            (part.Location as LocationCurve).Curve = newCurve; // CRITICAL DATABASE ERROR
        }
    }
}
