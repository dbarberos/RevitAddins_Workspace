using System;
using System.Linq;
using Autodesk.Revit.DB;

namespace RevitAddins.Geometry;

/// <summary>
/// Utility helper for computing cross-document coordinate transformation matrices (None, Link, Shared).
/// </summary>
public static class CrossDocumentTransformHelper
{
    /// <summary>
    /// Gets the transformation matrix according to the specified mode.
    /// </summary>
    /// <param name="sourceDoc">The source Revit Document containing elements to transfer.</param>
    /// <param name="targetDoc">The target Revit Document receiving elements.</param>
    /// <param name="useLinkTransform">True if the link instance's total transform should be applied.</param>
    /// <param name="useSharedCoordinates">True if shared coordinates (Survey Point offset) should be applied.</param>
    /// <returns>The calculated Transform matrix (or Transform.Identity / null if none).</returns>
    public static Transform GetTransform(
        Document sourceDoc,
        Document targetDoc,
        bool useLinkTransform,
        bool useSharedCoordinates)
    {
        if (useLinkTransform)
        {
            var linkInstance = new FilteredElementCollector(targetDoc)
                .OfClass(typeof(RevitLinkInstance))
                .Cast<RevitLinkInstance>()
                .FirstOrDefault(i => i.GetLinkDocument()?.Title?.Equals(sourceDoc.Title) == true);

            return linkInstance?.GetTotalTransform() ?? Transform.Identity;
        }

        if (useSharedCoordinates)
        {
            Transform sourceShared = sourceDoc.ActiveProjectLocation.GetTotalTransform();
            Transform targetShared = targetDoc.ActiveProjectLocation.GetTotalTransform();
            return targetShared.Multiply(sourceShared.Inverse);
        }

        return Transform.Identity;
    }
}
