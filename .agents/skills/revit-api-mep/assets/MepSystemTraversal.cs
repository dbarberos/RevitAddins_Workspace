// ==============================================================================
// SKILL: SKILL-RVT-MEP (MEP Engineering & Topology)
// PATTERN: Logical System Extractor
// PURPOSE: Safely navigates the duality of physical elements (Pipes/Ducts) to 
//          extract their underlying logical networks (MEPSystem) and thermodynamic 
//          properties. Handles multi-domain equipment (e.g., Chillers).
// DEPENDENCIES: Autodesk.Revit.DB, Autodesk.Revit.DB.Plumbing, Autodesk.Revit.DB.Mechanical
// ==============================================================================

using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Mechanical;

namespace RevitAddinBase.MEP
{
    /// <summary>
    /// Utility class to extract logical MEP Systems and their thermodynamic 
    /// properties from physical elements.
    /// </summary>
    public static class MepSystemTraversal
    {
        /// <summary>
        /// Safely retrieves all logical MEP Systems connected to a physical element.
        /// Resolves the discrepancy between MEPCurves and multi-system FamilyInstances.
        /// </summary>
        /// <param name="element">The physical element (Pipe, Duct, or Equipment).</param>
        /// <param name="domainFilter">Optional: Filter to only return Piping, HVAC, or Electrical systems.</param>
        /// <returns>A collection of logical systems connected to the element.</returns>
        public static IEnumerable<MEPSystem> GetConnectedSystems(this Element element, Domain? domainFilter = null)
        {
            if (element == null) yield break;

            MEPModel mepModel = null;

            // Extract the MEPModel based on the element's base class
            if (element is MEPCurve mepCurve)
            {
                mepModel = mepCurve.MEPModel;
            }
            else if (element is FamilyInstance fi && fi.MEPModel != null)
            {
                mepModel = fi.MEPModel;
            }

            if (mepModel == null) yield break;

            // Iterate through the connected systems
            ISet<ElementId> systemIds = mepModel.GetSystems();
            if (systemIds == null) yield break;

            foreach (ElementId sysId in systemIds)
            {
                if (element.Document.GetElement(sysId) is MEPSystem system)
                {
                    // Apply domain funneling if requested (e.g., ignore electrical systems on a pump)
                    if (domainFilter.HasValue)
                    {
                        if (system is PipingSystem && domainFilter.Value != Domain.DomainPiping) continue;
                        if (system is MechanicalSystem && domainFilter.Value != Domain.DomainHvac) continue;
                        if (system is ElectricalSystem && domainFilter.Value != Domain.DomainElectrical) continue;
                    }

                    yield return system;
                }
            }
        }

        /// <summary>
        /// Extracts the global fluid temperature of a piping system.
        /// Automatically converts from Revit's internal Kelvin units to Celsius.
        /// </summary>
        /// <param name="pipingSystem">The logical Piping System.</param>
        /// <returns>Temperature in degrees Celsius, or null if not defined.</returns>
        public static double? GetSystemTemperatureCelsius(this PipingSystem pipingSystem)
        {
            if (pipingSystem == null) return null;

            Document doc = pipingSystem.Document;
            ElementId typeId = pipingSystem.GetTypeId();
            
            if (doc.GetElement(typeId) is PipingSystemType systemType)
            {
                Parameter tempParam = systemType.get_Parameter(BuiltInParameter.RBS_PIPING_SYS_TEMPERATURE_PARAM);
                
                if (tempParam != null && tempParam.HasValue)
                {
                    double tempKelvin = tempParam.AsDouble();
                    // Conversion logic: Kelvin to Celsius
                    return UnitUtils.ConvertFromInternalUnits(tempKelvin, UnitTypeId.Celsius);
                }
            }
            return null;
        }
    }
}