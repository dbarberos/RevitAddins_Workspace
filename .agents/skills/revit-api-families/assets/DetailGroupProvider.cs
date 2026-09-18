using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;

namespace RevitAddin.FamilyAssets
{
    /// <summary>
    /// Utility provider to collect 2D Detail Groups (Instances and Types) from a Revit Document.
    /// </summary>
    public static class DetailGroupProvider
    {
        public static List<Group> GetDetailGroupInstances(Document doc)
        {
            if (doc == null || !doc.IsValidObject) return new List<Group>();

            return new FilteredElementCollector(doc)
                .OfClass(typeof(Group))
                .WhereElementIsNotElementType()
                .Cast<Group>()
                .Where(g => (g.GroupType?.Category?.Id?.Value == (int)BuiltInCategory.OST_IOSDetailGroups) ||
                            (g.Category?.Id?.Value == (int)BuiltInCategory.OST_IOSDetailGroups))
                .ToList();
        }

        public static List<GroupType> GetDetailGroupTypes(Document doc)
        {
            if (doc == null || !doc.IsValidObject) return new List<GroupType>();

            return new FilteredElementCollector(doc)
                .OfClass(typeof(GroupType))
                .Cast<GroupType>()
                .Where(gt => gt.Category?.Id?.Value == (int)BuiltInCategory.OST_IOSDetailGroups)
                .OrderBy(gt => gt.Name)
                .ToList();
        }
    }
}
