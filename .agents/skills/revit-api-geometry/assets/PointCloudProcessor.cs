// ==============================================================================
// SKILL: SKILL-RVT-GEO (Geometry & Spatial Analysis)
// PATTERN: Point Cloud Spatial Chunking
// PURPOSE: Safely extracts points from a PointCloudInstance (.rcp) by enforcing 
//          strict volumetric boundaries and maximum return limits, protecting 
//          the host application from out-of-memory exceptions.
// DEPENDENCIES: Autodesk.Revit.DB, Autodesk.Revit.DB.PointClouds, System.Collections.Generic
// ==============================================================================

using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.PointClouds;

namespace RevitAddinBase.Geometry
{
    /// <summary>
    /// Utility class for safely extracting and processing massive point cloud datasets.
    /// </summary>
    public static class PointCloudProcessor
    {
        // Absolute maximum limit for a single extraction query to prevent crashing
        private const int MaxPointsPerQuery = 100_000;

        /// <summary>
        /// Extracts a limited chunk of points falling inside a specific geometric BoundingBox.
        /// Handles the coordinate transformations required between ReCap (Local) and Revit (Global).
        /// </summary>
        /// <param name="cloudInstance">The linked PointCloudInstance.</param>
        /// <param name="searchBox">The spatial box (in Revit World Coordinates) to analyze.</param>
        /// <param name="averageDistance">Resolution (in Feet). Smaller = denser points. E.g., 0.05 for fine detail.</param>
        /// <returns>A collection of converted XYZ points (in Revit World Coordinates).</returns>
        public static List<XYZ> GetPointsInBoundingBox(PointCloudInstance cloudInstance, BoundingBoxXYZ searchBox, double averageDistance = 0.05)
        {
            List<XYZ> extractedWorldPoints = new List<XYZ>();
            if (cloudInstance == null || searchBox == null) return extractedWorldPoints;

            // 1. Transform the World search box into the Point Cloud's Local coordinate system
            Transform cloudTransform = cloudInstance.GetTransform();
            Transform inverseTransform = cloudTransform.Inverse;

            XYZ localMin = inverseTransform.OfPoint(searchBox.Min);
            XYZ localMax = inverseTransform.OfPoint(searchBox.Max);

            // 2. Build the exact planar boundaries for the filter
            List<Plane> filterPlanes = BuildBoxPlanes(localMin, localMax);
            PointCloudFilter spatialFilter = PointCloudFilterFactory.CreateMultiPlaneFilter(filterPlanes);

            // 3. Execute the extraction with a hard limit
            PointCollection rawPoints = cloudInstance.GetPoints(spatialFilter, averageDistance, MaxPointsPerQuery);

            // 4. Convert the local ReCap points back to Revit World Coordinates for analysis
            foreach (CloudPoint rawPoint in rawPoints)
            {
                XYZ localPoint = new XYZ(rawPoint.X, rawPoint.Y, rawPoint.Z);
                XYZ worldPoint = cloudTransform.OfPoint(localPoint);
                extractedWorldPoints.Add(worldPoint);
            }

            return extractedWorldPoints;
        }

        private static List<Plane> BuildBoxPlanes(XYZ min, XYZ max)
        {
            List<Plane> planes = new List<Plane>();
            
            // X Boundaries
            planes.Add(Plane.CreateByNormalAndOrigin(new XYZ(1, 0, 0), min));
            planes.Add(Plane.CreateByNormalAndOrigin(new XYZ(-1, 0, 0), max));
            
            // Y Boundaries
            planes.Add(Plane.CreateByNormalAndOrigin(new XYZ(0, 1, 0), min));
            planes.Add(Plane.CreateByNormalAndOrigin(new XYZ(0, -1, 0), max));
            
            // Z Boundaries
            planes.Add(Plane.CreateByNormalAndOrigin(new XYZ(0, 0, 1), min));
            planes.Add(Plane.CreateByNormalAndOrigin(new XYZ(0, 0, -1), max));

            return planes;
        }
    }
}