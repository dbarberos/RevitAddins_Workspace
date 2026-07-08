// ==============================================================================
// SKILL: revit-api-mep (MEP Systems and Routing)
// PATTERN: Programmatic Pipe Creator with Internal Units Diameter
// PURPOSE: Generates linear pipe segments and updates nominal diameters.
// ==============================================================================

using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;

namespace RevitAddinBase.Mep
{
    public class MepPipeGeometryBuilder
    {
        public Pipe CreatePipeSegment(Document doc, ElementId systemTypeId, ElementId pipeTypeId, ElementId levelId, XYZ startPoint, XYZ endPoint)
        {
            // Modifying MEP model databases requires active write transactions
            Pipe pipe = Pipe.Create(doc, systemTypeId, pipeTypeId, levelId, startPoint, endPoint);
            
            // Newly created pipes default to catalog minima. Diameter parameter must be set.
            Parameter diameterParam = pipe.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM);
            
            if (diameterParam != null && !diameterParam.IsReadOnly)
            {
                // Revit requires double values in internal units (Feet). Conversion from Inches is required.
                double inchesVal = 2.0; 
                double internalVal = UnitUtils.ConvertToInternalUnits(inchesVal, UnitTypeId.Inches);
                diameterParam.Set(internalVal);
            }
            
            return pipe;
        }
    }
}
