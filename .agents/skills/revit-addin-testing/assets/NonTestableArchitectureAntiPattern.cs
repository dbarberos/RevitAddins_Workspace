// ==============================================================================
// SKILL: revit-addin-testing (Testing and TDD)
// ANTI-PATTERN: Coupled Business Logic with Revit Database Queries
// PURPOSE: Demonstrates code that is impossible to unit test without Revit running.
// ==============================================================================

using Autodesk.Revit.DB;
using System.Collections.Generic;

namespace RevitAddinBase.Testing
{
    public class NonTestableArchitectureAntiPattern
    {
        // ANTI-PATTERN: Calculation logic is mixed with Revit database queries.
        public double CalculateTotalCost(Document doc, IList<Element> walls)
        {
            double totalCost = 0;
            foreach (var wall in walls)
            {
                // Impossible to unit test without an active Revit application instance
                Parameter pArea = wall.get_Parameter(BuiltInParameter.HOST_AREA_COMPUTED); 
                totalCost += pArea.AsDouble() * 15.5;
            }
            return totalCost;
        }
    }
}
