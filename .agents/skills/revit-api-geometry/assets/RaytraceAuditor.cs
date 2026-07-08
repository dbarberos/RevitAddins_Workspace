// ==============================================================================
// SKILL: SKILL-RVT-GEO (Geometry & Spatial Analysis)
// PATTERN: Raycasting & Clash Detection
// PURPOSE: Wraps the ReferenceIntersector engine to shoot mathematical rays 
//          through the model. Used for collision detection, finding host faces, 
//          and calculating real vertical distances (e.g., clearance to floor).
// DEPENDENCIES: Autodesk.Revit.DB, System.Collections.Generic, System.Linq
// ==============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;

namespace RevitAddinBase.Geometry
{
    /// <summary>
    /// Utility class for firing spatial rays and evaluating geometric intersections.
    /// </summary>
    public static class RaytraceAuditor
    {
        /// <summary>
        /// Fires a ray vertically downwards to find the exact distance to the nearest physical floor.
        /// Requires a valid 3D View to operate (Revit processes visibility for raycasting).
        /// </summary>
        /// <param name="doc">The active Document.</param>
        /// <param name="view3D">A 3D View (Must not be a ViewTemplate).</param>
        /// <param name="origin">The XYZ coordinate to shoot from.</param>
        /// <returns>The distance in internal units (Feet), or null if no floor is hit.</returns>
        public static double? GetDistanceToNearestFloorBelow(Document doc, View3D view3D, XYZ origin)
        {
            if (doc == null || view3D == null || view3D.IsTemplate) return null;

            // Target only structural and architectural floors
            ElementCategoryFilter floorFilter = new ElementCategoryFilter(BuiltInCategory.OST_Floors);
            
            // Configure the radar engine
            ReferenceIntersector intersector = new ReferenceIntersector(floorFilter, FindReferenceTarget.Face, view3D)
            {
                FindSpatialElementFromBoundingBox = false
            };

            // Shoot the ray straight down (0, 0, -1)
            XYZ directionDown = new XYZ(0, 0, -1);
            ReferenceWithContext hit = intersector.FindNearest(origin, directionDown);

            if (hit != null && hit.Proximity > 0)
            {
                return hit.Proximity;
            }

            return null;
        }

        /// <summary>
        /// Checks if a direct line of sight exists between two points without hitting 
        /// elements of a specific category (e.g., checking if a camera can see a door).
        /// </summary>
        public static bool IsLineOfSightClear(View3D view3D, XYZ pointA, XYZ pointB, BuiltInCategory obstacleCategory)
        {
            if (view3D == null || pointA.IsAlmostEqualTo(pointB)) return false;

            XYZ direction = (pointB - pointA).NormalizeSafe();
            double totalDistance = pointA.DistanceTo(pointB);

            ElementCategoryFilter obstacleFilter = new ElementCategoryFilter(obstacleCategory);
            ReferenceIntersector intersector = new ReferenceIntersector(obstacleFilter, FindReferenceTarget.Face, view3D);

            ReferenceWithContext hit = intersector.FindNearest(pointA, direction);

            // If we hit something AND the hit is closer than our target pointB, the line of sight is blocked
            if (hit != null && hit.Proximity < totalDistance)
            {
                return false;
            }

            return true;
        }
    }
}