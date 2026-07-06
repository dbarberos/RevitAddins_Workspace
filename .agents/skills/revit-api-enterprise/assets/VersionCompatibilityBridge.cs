// ==============================================================================
// SKILL: SKILL-RVT-ENT (Enterprise & Cloud Ecosystem)
// PATTERN: Multi-Version Preprocessor Bridge
// PURPOSE: Abstracts API breaking changes across different Revit years.
//          Allows a single codebase to compile for Revit 2021 through 2025.
// DEPENDENCIES: Autodesk.Revit.DB
// ==============================================================================

using System;
using Autodesk.Revit.DB;

namespace RevitAddinBase.Enterprise
{
    /// <summary>
    /// Compatibility wrapper handling deprecated methods and API shifts.
    /// Requires MSBuild conditional compilation symbols (e.g., REVIT2022, REVIT2024).
    /// </summary>
    public static class VersionCompatibilityBridge
    {
        /// <summary>
        /// Safely retrieves the internal name of a parameter definition, 
        /// bridging the gap between the old API and the modern ForgeTypeId API.
        /// </summary>
        public static string GetParameterNameSafe(Parameter parameter)
        {
            if (parameter == null) return string.Empty;

#if REVIT2024_OR_GREATER
            // In Revit 2024+, GetDataType() returns a ForgeTypeId
            return parameter.Definition.GetDataType().TypeId;
#else
            // In Revit 2023 and older, the Name property or UnitType was used
            return parameter.Definition.Name;
#endif
        }

        /// <summary>
        /// Converts a standard metric value to Revit's internal Imperial units (Feet),
        /// adapting to the deprecation of DisplayUnitType.
        /// </summary>
        public static double ConvertToInternalMeters(double valueInMeters)
        {
#if REVIT2022_OR_GREATER
            // ForgeTypeId system (Revit 2022+)
            return UnitUtils.ConvertToInternalUnits(valueInMeters, UnitTypeId.Meters);
#else
            // Legacy DisplayUnitType system (Revit 2021 and older)
            // Note: DisplayUnitType.DUT_METERS is casted dynamically to compile in older environments
            return UnitUtils.ConvertToInternalUnits(valueInMeters, (DisplayUnitType)DUT_METERS_INT); 
#endif
        }
    }
}