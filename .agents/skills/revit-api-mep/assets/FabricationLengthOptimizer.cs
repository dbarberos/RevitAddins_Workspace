// ==============================================================================
// SKILL: revit-api-mep (Fabrication Modeling APIs)
// PATTERN: Commercial Straight Run Optimizer
// PURPOSE: Splits long fabrication straight ducts into commercial purchase lengths.
// ==============================================================================

using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Fabrication;
using System.Collections.Generic;

namespace RevitAddinBase.Mep
{
    public class FabricationLengthOptimizer
    {
        public void SegmentCommercialLengths(Document doc, ISet<ElementId> fabricationPartIds)
        {
            using (Transaction t = new Transaction(doc, "Optimize Lengths (Straights)"))
            {
                t.Start();
                // Native routine segments lengthy fabrications and inserts necessary joints
                // according to database specifications.
                FabricationPart.OptimizeLengths(doc, fabricationPartIds);
                t.Commit();
            }
        }
    }
}
