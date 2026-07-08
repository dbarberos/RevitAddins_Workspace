// ==============================================================================
// SKILL: SKILL-RVT-GEO (Geometry & Spatial Analysis)
// PATTERN: Vector Math & XYZ Safeties
// PURPOSE: Extension methods for safe geometric calculations, XYZ normalization, 
//          and robust vector transformations, preventing divide-by-zero crashes.
// DEPENDENCIES: Autodesk.Revit.DB, System
// ==============================================================================

using System;
using Autodesk.Revit.DB;

namespace RevitAddinBase.Geometry
{
    /// <summary>
    /// Core utility class for robust XYZ operations and vector mathematics.
    /// </summary>
    public static class VectorMathExtensions
    {
        /// <summary>
        /// Safely normalizes a vector. If the vector has zero length, it returns null 
        /// instead of throwing a fatal exception.
        /// </summary>
        public static XYZ NormalizeSafe(this XYZ vector)
        {
            if (vector == null || vector.IsZeroLength()) return null;
            return vector.Normalize();
        }

        /// <summary>
        /// Calculates the angle between two vectors on a specific 2D plane (usually XY).
        /// Crucial for determining rotation angles of FamilyInstances.
        /// </summary>
        /// <param name="v1">The source vector.</param>
        /// <param name="v2">The target vector.</param>
        /// <returns>Angle in radians.</returns>
        public static double AngleOnXYPlane(this XYZ v1, XYZ v2)
        {
            // Flatten vectors to 2D
            XYZ flatV1 = new XYZ(v1.X, v1.Y, 0).NormalizeSafe();
            XYZ flatV2 = new XYZ(v2.X, v2.Y, 0).NormalizeSafe();

            if (flatV1 == null || flatV2 == null) return 0.0;

            // Dot product for the angle magnitude
            double dot = flatV1.DotProduct(flatV2);
            // Clamp to [-1, 1] to avoid NaN from floating point precision issues
            dot = Math.Max(-1.0, Math.Min(1.0, dot));
            double angle = Math.Acos(dot);

            // Cross product to determine the sign (Clockwise vs Counter-Clockwise)
            XYZ cross = flatV1.CrossProduct(flatV2);
            if (cross.Z < 0)
            {
                angle = 2 * Math.PI - angle;
            }

            return angle;
        }

        /// <summary>
        /// Translates a point from the global coordinate system to the local 
        /// coordinate system of a FamilyInstance.
        /// </summary>
        public static XYZ TransformToLocal(this XYZ globalPoint, FamilyInstance instance)
        {
            if (globalPoint == null || instance == null) return null;
            
            Transform instanceTransform = instance.GetTransform();
            // Inverse transform converts World coordinates back to Local
            return instanceTransform.Inverse.OfPoint(globalPoint);
        }
    }
}