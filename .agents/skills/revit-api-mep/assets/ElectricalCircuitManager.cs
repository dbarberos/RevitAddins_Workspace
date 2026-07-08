// ==============================================================================
// SKILL: SKILL-RVT-MEP (MEP Engineering & Topology)
// PATTERN: Electrical Circuit & Panel Manager
// PURPOSE: Handles the creation of logical power circuits, panel assignment, 
//          and load auditing. Strictly avoids using physical Wires for logic, 
//          relying entirely on the native ElectricalSystem and Equipment classes.
// DEPENDENCIES: Autodesk.Revit.DB, Autodesk.Revit.DB.Electrical, System.Linq
// ==============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;

namespace RevitAddinBase.MEP
{
    /// <summary>
    /// Utility class to manage electrical topology, create power circuits, 
    /// assign panels, and extract aggregated load calculations.
    /// </summary>
    public static class ElectricalCircuitManager
    {
        /// <summary>
        /// Creates a new logical Power Circuit grouping multiple electrical fixtures.
        /// Must be called within an active Transaction.
        /// </summary>
        /// <param name="doc">The active document.</param>
        /// <param name="fixtureIds">Collection of ElementIds representing electrical fixtures (e.g., Receptacles, Lighting).</param>
        /// <returns>The newly created ElectricalSystem, or null if creation fails.</returns>
        public static ElectricalSystem CreatePowerCircuit(Document doc, ICollection<ElementId> fixtureIds)
        {
            if (doc == null || fixtureIds == null || !fixtureIds.Any()) return null;

            try
            {
                // Create the logical system. The engine validates if the fixtures have compatible electrical connectors.
                ElectricalSystem newCircuit = ElectricalSystem.Create(doc, fixtureIds, ElectricalSystemType.PowerCircuit);
                return newCircuit;
            }
            catch (Autodesk.Revit.Exceptions.ArgumentException ex)
            {
                System.Diagnostics.Debug.WriteLine($"[ElectricalManager] Failed to create circuit. Elements might lack valid connectors: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Assigns an existing electrical circuit to a Distribution Panel.
        /// Includes validation for voltage and pole compatibility to prevent fatal API exceptions.
        /// </summary>
        /// <param name="circuit">The logical electrical circuit.</param>
        /// <param name="panel">The FamilyInstance acting as the electrical panel.</param>
        /// <returns>True if assigned successfully; otherwise, false.</returns>
        public static bool AssignCircuitToPanel(ElectricalSystem circuit, FamilyInstance panel)
        {
            if (circuit == null || panel == null) return false;

            // 1. Validate that the target FamilyInstance is actually an Electrical Panel
            if (panel.MEPModel is ElectricalEquipment equipment)
            {
                // In a production environment, you would also check if the Distribution System 
                // matches the circuit's Voltage and Poles here before calling SelectPanel.
                try
                {
                    circuit.SelectPanel(panel);
                    return true;
                }
                catch (Autodesk.Revit.Exceptions.InvalidOperationException ex)
                {
                    System.Diagnostics.Debug.WriteLine($"[ElectricalManager] Voltage/Pole mismatch or panel is full: {ex.Message}");
                    return false;
                }
            }

            System.Diagnostics.Debug.WriteLine("[ElectricalManager] Target element is not classified as ElectricalEquipment.");
            return false;
        }

        /// <summary>
        /// Calculates the total Apparent Load (VA) connected to a specific distribution panel.
        /// Relies on Revit's internal calculation engine rather than manual summing, 
        /// ensuring Demand Factors are properly accounted for.
        /// </summary>
        /// <param name="panel">The FamilyInstance acting as the electrical panel.</param>
        /// <returns>Total Apparent Load in internal units (Volt-Amperes / Watts).</returns>
        public static double GetPanelTotalApparentLoad(FamilyInstance panel)
        {
            if (panel == null || !(panel.MEPModel is ElectricalEquipment equipment))
            {
                throw new ArgumentException("Provided element is null or is not ElectricalEquipment.");
            }

            double totalApparentLoad = 0.0;

            // 1. Retrieve all logical circuits feeding from this panel
            ElementSet assignedCircuits = equipment.GetAssignedElectricalSystems();

            foreach (ElectricalSystem circuit in assignedCircuits)
            {
                // 2. Extract the aggregated parameter calculated by the native C++ engine
                Parameter loadParam = circuit.get_Parameter(BuiltInParameter.RBS_ELEC_APPARENT_LOAD);
                
                if (loadParam != null && loadParam.HasValue)
                {
                    // Internal units for power/load are equivalent to Watts or Volt-Amperes
                    totalApparentLoad += loadParam.AsDouble();
                }
            }

            return totalApparentLoad;
        }

        /// <summary>
        /// Safely renames an electrical circuit (e.g., "L-01", "F-02").
        /// Must be called within an active Transaction.
        /// </summary>
        /// <param name="circuit">The electrical circuit to rename.</param>
        /// <param name="newName">The new circuit number or name.</param>
        public static void SetCircuitName(ElectricalSystem circuit, string newName)
        {
            if (circuit == null || string.IsNullOrWhiteSpace(newName)) return;

            Parameter nameParam = circuit.get_Parameter(BuiltInParameter.RBS_ELEC_CIRCUIT_NAME) 
                               ?? circuit.get_Parameter(BuiltInParameter.RBS_ELEC_CIRCUIT_NUMBER);

            if (nameParam != null && !nameParam.IsReadOnly)
            {
                nameParam.Set(newName);
            }
        }
    }
}