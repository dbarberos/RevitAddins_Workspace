using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;

namespace RevitAddin.FamilyAssets
{
    /// <summary>
    /// Utility provider to collect 2D Detail Components (Detail Items) from a Revit Document.
    /// </summary>
    public static class DetailItemProvider
    {
        public static List<FamilyInstance> GetDetailComponentInstances(Document doc)
        {
            if (doc == null || !doc.IsValidObject) return new List<FamilyInstance>();

            return new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_DetailComponents)
                .WhereElementIsNotElementType()
                .OfType<FamilyInstance>()
                .ToList();
        }
    }
}
