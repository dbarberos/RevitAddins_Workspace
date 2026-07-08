// ==============================================================================
// SKILL: revit-api-geometry (Vector & Spatial Analytics)
// PATTERN: Proximity Raycasting via ReferenceIntersector
// PURPOSE: Calculates vertical clearance distances to the nearest floor.
// ==============================================================================

using Autodesk.Revit.DB;

namespace RevitAddinBase.Geometry
{
    public class FloorProximityRaycaster
    {
        public double CalculateDistanceToFloor(Document doc, View3D view3D, XYZ originPoint)
        {
            // 1. Configure the class filter to isolate floors only
            ElementClassFilter floorFilter = new ElementClassFilter(typeof(Floor));
            
            // Set up intersector to return target faces on the nearest elements
            ReferenceIntersector intersector = new ReferenceIntersector(floorFilter, FindReferenceTarget.Face, view3D)
            {
                FindSpatialElementFromBoundingBox = false
            };

            // 2. Shoot ray vertically downwards (-Z vector)
            XYZ rayDirection = new XYZ(0, 0, -1);
            ReferenceWithContext result = intersector.FindNearest(originPoint, rayDirection);

            if (result != null)
            {
                // 3. Proximity proximity is returned in Revit's internal units (Feet)
                double distance = result.Proximity;
                return distance;
            }

            return double.PositiveInfinity; // No floors located below the origin
        }
    }
}
