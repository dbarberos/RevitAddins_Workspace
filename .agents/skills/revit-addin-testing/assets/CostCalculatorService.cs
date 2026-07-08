// ==============================================================================
// SKILL: revit-addin-testing (Testing and TDD)
// PATTERN: Testable Business Logic Service
// PURPOSE: Operates strictly over abstractions, requiring no Autodesk.Revit.DB dependency.
// ==============================================================================

using System.Collections.Generic;

namespace RevitAddinBase.Testing
{
    public class CostCalculatorService
    {
        public double CalculateTotalCost(IEnumerable<IWallDataRepresentation> wallDataCollection)
        {
            double totalCost = 0;
            foreach (var wall in wallDataCollection)
            {
                totalCost += wall.GetMetricArea() * 15.5; // Decoupled mathematical logic
            }
            return totalCost;
        }
    }
}
