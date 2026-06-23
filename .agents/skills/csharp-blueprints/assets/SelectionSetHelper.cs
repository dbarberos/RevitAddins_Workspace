using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;

namespace FilterPlus.Helpers
{
    /// <summary>
    /// Reusable helper for multi-scope element ID set operations used in
    /// selection expansion and purge workflows (FilterPlus "Increase Checked").
    /// </summary>
    public static class SelectionSetHelper
    {
        /// <summary>
        /// Unifies three sources of element IDs into a single HashSet:
        /// currently checked IDs, newly matched target IDs, and IDs from other
        /// explorer scopes (persisted across scope changes).
        /// </summary>
        /// <param name="currentCheckedIds">IDs currently checked in the UI tree.</param>
        /// <param name="targetIds">IDs found by the WHAT rules in the current operation.</param>
        /// <param name="persistentCheckedIds">Global set persisted across scope switches.</param>
        /// <param name="activeElementIds">IDs present in the current active scope.</param>
        /// <param name="addToCurrent">If false, currentCheckedIds are NOT included (Replace mode).</param>
        public static HashSet<ElementId> UnifySelectionSets(
            IEnumerable<ElementId> currentCheckedIds,
            IEnumerable<ElementId> targetIds,
            IEnumerable<ElementId> persistentCheckedIds,
            IEnumerable<ElementId> activeElementIds,
            bool addToCurrent)
        {
            var activeSet = activeElementIds.ToHashSet();
            var idsFromOtherScopes = persistentCheckedIds.Where(id => !activeSet.Contains(id));

            var unified = new HashSet<ElementId>();
            if (addToCurrent)
                foreach (var id in currentCheckedIds) unified.Add(id);
            foreach (var id in targetIds) unified.Add(id);
            foreach (var id in idsFromOtherScopes) unified.Add(id);
            return unified;
        }

        /// <summary>
        /// Purges element IDs from a set if those elements belong to a Model Group
        /// and/or an Assembly Instance.
        /// Also intersects <paramref name="targetIds"/> with the purged result to
        /// prevent excluded elements from being re-injected into the explorer tree.
        /// </summary>
        /// <param name="doc">Active Revit Document.</param>
        /// <param name="finalCheckedIds">Unified set to purge (modified in-place via replacement).</param>
        /// <param name="targetIds">Newly matched IDs (synced via IntersectWith).</param>
        /// <param name="excludeGroups">Remove elements that belong to a Model Group.</param>
        /// <param name="excludeAssemblies">Remove elements that belong to an Assembly.</param>
        /// <returns>Purged HashSet (new instance).</returns>
        public static HashSet<ElementId> PurgeByMembership(
            Document doc,
            HashSet<ElementId> finalCheckedIds,
            HashSet<ElementId> targetIds,
            bool excludeGroups,
            bool excludeAssemblies)
        {
            if (!excludeGroups && !excludeAssemblies)
                return finalCheckedIds;

            var purged = new HashSet<ElementId>();
            foreach (var id in finalCheckedIds)
            {
                var el = doc.GetElement(id);
                if (el == null) continue;
                if (excludeGroups && el.GroupId != ElementId.InvalidElementId) continue;
                if (excludeAssemblies && el.AssemblyInstanceId != ElementId.InvalidElementId) continue;
                purged.Add(id);
            }

            // Sync targetIds so no excluded element gets injected into the UI tree
            targetIds.IntersectWith(purged);
            return purged;
        }

        /// <summary>
        /// Returns the appropriate FilteredElementCollector domain for the WHERE scope.
        /// </summary>
        public static List<Element> GetDomainElements(Document doc, WhereScope scope)
        {
            return scope switch
            {
                WhereScope.VisibleInCurrentView =>
                    new FilteredElementCollector(doc, doc.ActiveView.Id)
                        .WhereElementIsNotElementType().ToElements().ToList(),

                WhereScope.ElementsInView =>
                    new FilteredElementCollector(doc)
                        .WhereElementIsNotElementType().ToElements()
                        .Where(el => el.OwnerViewId == doc.ActiveView.Id
                                  || el.get_BoundingBox(doc.ActiveView) != null)
                        .ToList(),

                _ => // WhereScope.AllModel
                    new FilteredElementCollector(doc)
                        .WhereElementIsNotElementType().ToElements().ToList(),
            };
        }
    }

    /// <summary>Defines the search domain scope for the Increase Checked pipeline.</summary>
    public enum WhereScope
    {
        AllModel,
        ElementsInView,
        VisibleInCurrentView
    }
}
