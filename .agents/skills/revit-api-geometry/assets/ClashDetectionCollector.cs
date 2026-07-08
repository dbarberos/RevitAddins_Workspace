// ==============================================================================
// SKILL: revit-api-geometry (Vector & Spatial Analytics)
// PATTERN: Bounding Box & Element Geometry Intersector
// PURPOSE: Checks hard physical clashes by combining quick and slow database filters.
// ==============================================================================

using Autodesk.Revit.DB;
using System.Collections.Generic;

namespace RevitAddinBase.Geometry
{
    public class ClashDetectionCollector
    {
        public IList<Element> FindClashes(Document doc, Element mepElement, BuiltInCategory filterCategory)
        {
            // 1. Instantiate the geometric intersection filter (Slow Filter)
            ElementIntersectsElementFilter collisionFilter = new ElementIntersectsElementFilter(mepElement);

            // 2. Combine with Quick Filters (Category/ElementType) to minimize marshalling overhead
            FilteredElementCollector collector = new FilteredElementCollector(doc)
                .OfCategory(filterCategory)
                .WhereElementIsNotElementType()
                .WherePasses(collisionFilter); // Geometric boundary checks are processed last

            return collector.ToElements();
        }
    }
}
