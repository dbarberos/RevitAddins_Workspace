// ==============================================================================
// SKILL: revit-api-mep (MEP Systems and Routing)
// PATTERN: Document Regeneration Fitting Pipeline
// PURPOSE: Forces Revit geometry compiler to rebuild curves before requesting connectors.
// ==============================================================================

using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;

namespace RevitAddinBase.Mep
{
    public class MepRegenerationFittingPipeline
    {
        public void DrawPipeNetwork(Document doc, ElementId sysId, ElementId typeId, ElementId lvlId, XYZ p0, XYZ p1, XYZ p2)
        {
            using (Transaction t = new Transaction(doc, "Auto MEP Trace"))
            {
                t.Start();
                
                // 1. Create linear pipe segments
                Pipe pipe1 = Pipe.Create(doc, sysId, typeId, lvlId, p0, p1);
                Pipe pipe2 = Pipe.Create(doc, sysId, typeId, lvlId, p1, p2);
                
                // 2. MANDATORY REGENERATION (Forces compiler to build geometry for pipe1 and pipe2)
                doc.Regenerate(); 
                
                // 3. Connectors are now populated and active in the database; fittings can be placed.
                Connector conn1 = GetConnectorAtPoint(pipe1, p1);
                Connector conn2 = GetConnectorAtPoint(pipe2, p1);
                doc.Create.NewElbowFitting(conn1, conn2);
                
                t.Commit();
            }
        }

        private Connector GetConnectorAtPoint(Pipe pipe, XYZ point)
        {
            // Utility placeholder for connector retrieval
            return null;
        }
    }
}
