// ==============================================================================
// SKILL: SKILL-RVT-DATA (Data & Information)
// PATTERN: Parameter Read/Write Wrapper
// PURPOSE: Provides fail-safe methods to read and write parameters using 
//          BuiltInParameters, gracefully handling Unit conversions (Metric/Imperial)
//          and avoiding crashes from Read-Only states.
// DEPENDENCIES: Autodesk.Revit.DB, System
// ==============================================================================

using System;
using Autodesk.Revit.DB;

namespace RevitAddinBase.Data
{
    /// <summary>
    /// Utility class for safe and standardized parameter manipulation.
    /// </summary>
    public static class ParameterHandler
    {
        /// <summary>
        /// Safely writes a string value to a BuiltInParameter.
        /// </summary>
        /// <param name="element">The target element.</param>
        /// <param name="bip">The BuiltInParameter to target.</param>
        /// <param name="value">The string value to inject.</param>
        /// <returns>True if successfully written; false if read-only or not found.</returns>
        public static bool SetParameterString(this Element element, BuiltInParameter bip, string value)
        {
            if (element == null) return false;

            Parameter param = element.get_Parameter(bip);
            if (param != null && !param.IsReadOnly && param.StorageType == StorageType.String)
            {
                return param.Set(value ?? string.Empty);
            }
            
            return false;
        }

        /// <summary>
        /// Safely writes a double value, automatically converting from user metrics to internal Imperial units.
        /// </summary>
        /// <param name="element">The target element.</param>
        /// <param name="bip">The BuiltInParameter to target.</param>
        /// <param name="valueInUserUnits">The numeric value in the specified user unit (e.g., 1500 for Millimeters).</param>
        /// <param name="unitType">The target UnitTypeId (e.g., UnitTypeId.Millimeters).</param>
        /// <returns>True if successfully written.</returns>
        public static bool SetParameterDoubleWithUnits(this Element element, BuiltInParameter bip, double valueInUserUnits, ForgeTypeId unitType)
        {
            if (element == null || unitType == null) return false;

            Parameter param = element.get_Parameter(bip);
            if (param != null && !param.IsReadOnly && param.StorageType == StorageType.Double)
            {
                // Revit expects internal units (Feet). Convert from user metric to internal.
                double internalValue = UnitUtils.ConvertToInternalUnits(valueInUserUnits, unitType);
                return param.Set(internalValue);
            }

            return false;
        }

        /// <summary>
        /// Extracts a string representation of any parameter, regardless of its underlying StorageType.
        /// Useful for UI display, reporting, or exporting to CSV.
        /// </summary>
        /// <param name="element">The target element.</param>
        /// <param name="bip">The BuiltInParameter to read.</param>
        /// <returns>The formatted string value, or an empty string if null/invalid.</returns>
        public static string GetParameterValueAsDisplayString(this Element element, BuiltInParameter bip)
        {
            if (element == null) return string.Empty;

            Parameter param = element.get_Parameter(bip);
            if (param == null || !param.HasValue) return string.Empty;

            switch (param.StorageType)
            {
                case StorageType.String:
                    return param.AsString();
                case StorageType.Double:
                    // AsValueString() applies the document's project units and rounding settings automatically
                    return param.AsValueString();
                case StorageType.Integer:
                    // Handles Yes/No parameters mapped as 1/0
                    if (param.Definition.GetDataType() == SpecTypeId.Boolean.YesNo)
                    {
                        return param.AsInteger() == 1 ? "Yes" : "No";
                    }
                    return param.AsInteger().ToString();
                case StorageType.ElementId:
                    Element linkedElem = element.Document.GetElement(param.AsElementId());
                    return linkedElem?.Name ?? string.Empty;
                default:
                    return string.Empty;
            }
        }
    }
}