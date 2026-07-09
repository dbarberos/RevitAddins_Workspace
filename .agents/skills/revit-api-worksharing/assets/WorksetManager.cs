// ==============================================================================
// SKILL: SKILL-RVT-WS (Worksharing & Coordinates)
// PATTERN: Workset Query and Reassignment
// PURPOSE: Handles the discovery of user-created worksets and safely reassigns 
//          elements to them using the internal integer ID parameter.
// DEPENDENCIES: Autodesk.Revit.DB, System.Collections.Generic, System.Linq
// ==============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;

namespace RevitAddinBase.Worksharing
{
    /// <summary>
    /// Utility class for managing Revit Worksets.
    /// </summary>
    public static class WorksetManager
    {
        /// <summary>
        /// Retrieves a user workset by its exact string name.
        /// </summary>
        /// <param name="doc">The active workshared Document.</param>
        /// <param name="worksetName">The case-insensitive name of the workset.</param>
        /// <returns>The Workset object, or null if not found or document is not workshared.</returns>
        public static Workset GetWorksetByName(Document doc, string worksetName)
        {
            if (doc == null || !doc.IsWorkshared || string.IsNullOrWhiteSpace(worksetName)) 
                return null;

            FilteredWorksetCollector collector = new FilteredWorksetCollector(doc);
            collector.OfKind(WorksetKind.UserWorkset);

            return collector.FirstOrDefault(w => 
                w.Name.Equals(worksetName, StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// Moves an element to a specific workset.
        /// MUST be called within an active Transaction.
        /// </summary>
        /// <param name="element">The target element.</param>
        /// <param name="targetWorkset">The destination Workset.</param>
        /// <returns>True if successful, false if the parameter is locked or read-only.</returns>
        public static bool MoveElementToWorkset(Element element, Workset targetWorkset)
        {
            if (element == null || targetWorkset == null) return false;

            Parameter worksetParam = element.get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM);
            
            if (worksetParam != null && !worksetParam.IsReadOnly)
            {
                // The workset parameter expects the integer representation of the WorksetId
                return worksetParam.Set(targetWorkset.Id.IntegerValue);
            }

            return false;
        }
    }
}
