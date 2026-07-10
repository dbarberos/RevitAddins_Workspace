// ==============================================================================
// SKILL: SKILL-RVT-WS (Worksharing & Coordinates)
// PATTERN: Base Point & Coordinate Translation
// PURPOSE: Safely queries and modifies the Project Base Point and Survey Point, 
//          handling their default Pinned state to prevent runtime exceptions.
// DEPENDENCIES: Autodesk.Revit.DB, System.Linq
// ==============================================================================

using System;
using System.Linq;
using Autodesk.Revit.DB;

namespace RevitAddinBase.Worksharing
{
    /// <summary>
    /// Utility class to manipulate Shared Coordinates and Georeferencing points.
    /// </summary>
    public static class CoordinateSystemManager
    {
        /// <summary>
        /// Retrieves the Project Base Point or the Survey Point from the document.
        /// </summary>
        /// <param name="doc">The active Document.</param>
        /// <param name="getSurveyPoint">True to get the Survey Point; False for the Project Base Point.</param>
        /// <returns>The requested BasePoint element.</returns>
        public static BasePoint GetBasePoint(Document doc, bool getSurveyPoint)
        {
            if (doc == null) return null;

            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfClass(typeof(BasePoint));

            // BasePoints are distinguished by the IsShared parameter. 
            // IsShared = true -> Survey Point
            // IsShared = false -> Project Base Point
            return collector.Cast<BasePoint>().FirstOrDefault(bp => bp.IsShared == getSurveyPoint);
        }

        /// <summary>
        /// Safely translates the Project Base Point to a new internal location.
        /// MUST be called within an active Transaction.
        /// </summary>
        /// <param name="doc">The active Document.</param>
        /// <param name="translationVector">The XYZ vector representing the movement distance (Internal Units).</param>
        /// <returns>True if moved successfully.</returns>
        public static bool MoveProjectBasePoint(Document doc, XYZ translationVector)
        {
            BasePoint projectBasePoint = GetBasePoint(doc, false);
            if (projectBasePoint == null || translationVector == null || translationVector.IsZeroLength()) 
                return false;

            bool wasPinned = projectBasePoint.Pinned;

            try
            {
                // 1. MUST unpin the element before moving
                if (wasPinned) projectBasePoint.Pinned = false;

                // 2. Perform the translation
                ElementTransformUtils.MoveElement(doc, projectBasePoint.Id, translationVector);

                // 3. Restore the pinned state
                if (wasPinned) projectBasePoint.Pinned = true;

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[CoordinatesAPI] Failed to move Base Point: {ex.Message}");
                // Attempt to restore pin state in case of failure
                if (wasPinned) projectBasePoint.Pinned = true;
                return false;
            }
        }
    }
}
