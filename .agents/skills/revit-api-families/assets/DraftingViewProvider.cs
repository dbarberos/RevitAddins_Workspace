using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;

namespace RevitAddin.FamilyAssets
{
    /// <summary>
    /// Utility provider to collect Drafting Views from a Revit Document and map sheet placements.
    /// </summary>
    public static class DraftingViewProvider
    {
        public static List<ViewDrafting> GetDraftingViews(Document doc)
        {
            if (doc == null || !doc.IsValidObject) return new List<ViewDrafting>();

            return new FilteredElementCollector(doc)
                .OfClass(typeof(View))
                .Cast<View>()
                .Where(v => v.ViewType == ViewType.DraftingView && !v.IsTemplate)
                .Cast<ViewDrafting>()
                .OrderBy(v => v.Name)
                .ToList();
        }
    }
}
