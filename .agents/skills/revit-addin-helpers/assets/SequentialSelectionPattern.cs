using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace RevitAddinHelpers
{
    /// <summary>
    /// Demonstrates the sequential selection pattern required to safely select elements 
    /// from both the Host Document and Linked Documents without crashing PickObjects.
    /// </summary>
    public static class SequentialSelectionHelper
    {
        public static IList<Reference> PickHostAndLinkedElements(UIDocument uidoc, ISelectionFilter elementFilter, ISelectionFilter linkFilter, IList<Reference> preSelectedHostRefs, IList<Reference> preSelectedLinkRefs)
        {
            var allSelectedRefs = new List<Reference>();
            
            // Phase 1: Host Model Selection
            try
            {
                IList<Reference> hostRefs = uidoc.Selection.PickObjects(
                    ObjectType.Element,
                    elementFilter,
                    "Select elements in the Host Model only. Click Finish (top-left) when done.",
                    preSelectedHostRefs);
                    
                if (hostRefs != null && hostRefs.Any())
                {
                    allSelectedRefs.AddRange(hostRefs);
                }
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                // User cancelled the first phase
                return new List<Reference>();
            }

            // Phase 2: Linked Models Selection
            try
            {
                IList<Reference> linkRefs = uidoc.Selection.PickObjects(
                    ObjectType.LinkedElement,
                    linkFilter,
                    "Select elements in Linked Models only (use TAB to highlight). Click Finish (top-left) when done.",
                    preSelectedLinkRefs);
                    
                if (linkRefs != null && linkRefs.Any())
                {
                    allSelectedRefs.AddRange(linkRefs);
                }
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                // If user cancels the second phase, we optionally return what was selected in the first phase
                // or cancel entirely. Usually, we return what was gathered so far.
            }

            return allSelectedRefs;
        }
    }
}
