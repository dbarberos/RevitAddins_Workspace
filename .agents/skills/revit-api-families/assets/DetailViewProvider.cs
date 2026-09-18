using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;

namespace RevitAddin.FamilyAssets
{
    /// <summary>
    /// Utility provider to collect Detail Views and Callouts from a Revit Document.
    /// </summary>
    public static class DetailViewProvider
    {
        public static List<View> GetDetailViewsAndCallouts(Document doc)
        {
            if (doc == null || !doc.IsValidObject) return new List<View>();

            return new FilteredElementCollector(doc)
                .OfClass(typeof(View))
                .Cast<View>()
                .Where(v => !v.IsTemplate && (v.ViewType == ViewType.Detail || v.IsCallout))
                .OrderBy(v => v.Name)
                .ToList();
        }
    }
}
