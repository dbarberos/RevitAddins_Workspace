// ==============================================================================
// SKILL: revit-api-core (Database Control and UI)
// PATTERN: Runtime Native UI Selection Filtering
// PURPOSE: Enforces selection rules dynamically inside the Revit viewport.
// ==============================================================================

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;

namespace RevitAddinBase.Core
{
    public class StructuralWallSelectionFilter : ISelectionFilter
    {
        // Evaluated as the cursor hovers over element geometry
        public bool AllowElement(Element elem)
        {
            // 1. Verify class type is Wall
            if (elem is Wall wall)
            {
                // 2. Apply business rules (only Structural/Load-Bearing walls)
                return wall.StructuralUsage != Autodesk.Revit.DB.Structure.StructuralWallUsage.NonBearing;
            }
            return false;
        }

        // Evaluated for face/edge sub-component selection
        public bool AllowReference(Reference reference, XYZ position)
        {
            return true;
        }
    }

    public class SelectionExecutionService
    {
        public Result ExecuteSafeSelection(UIDocument uiDoc)
        {
            Document doc = uiDoc.Document;
            
            try
            {
                ISelectionFilter wallFilter = new StructuralWallSelectionFilter();
                
                // Revit natively blocks selection of any object not satisfying the filter
                Reference refWall = uiDoc.Selection.PickObject(
                    ObjectType.Element, 
                    wallFilter, 
                    "Select a structural wall in the viewport"
                );
                
                Wall selectedWall = doc.GetElement(refWall.ElementId) as Wall;
                return Result.Succeeded;
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                // Correct: Catch escape key cancels to terminate command cleanly without errors
                return Result.Cancelled;
            }
        }
    }
}
