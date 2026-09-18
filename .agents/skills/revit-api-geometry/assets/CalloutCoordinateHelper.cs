using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;

namespace RevitAddin.Helpers
{
    /// <summary>
    /// Utility helper for mapping callout view crop box coordinates across documents with differing coordinate systems and level elevations.
    /// </summary>
    public static class CalloutCoordinateHelper
    {
        /// <summary>
        /// Computes normalized target world coordinates (pMin, pMax) for ViewSection.CreateCallout
        /// by projecting the callout crop box into relative parent view space anchored at view.Origin,
        /// and enforcing sufficient Z-depth so the 3D box intersects the target parent view's cut plane across level elevation offsets.
        /// </summary>
        public static (XYZ pMin, XYZ pMax) ComputeTargetCalloutBoundingBox(View calloutView, View srcParentView, View tgtParentView)
        {
            BoundingBoxXYZ cropBox = calloutView.CropBox;
            if (cropBox == null)
                throw new ArgumentNullException(nameof(calloutView), "Callout view must have a valid CropBox.");

            Transform calloutTf = cropBox.Transform ?? Transform.Identity;
            Transform srcParentTf = GetViewTransform(srcParentView);
            Transform tgtParentTf = GetViewTransform(tgtParentView);

            XYZ cMin = cropBox.Min;
            XYZ cMax = cropBox.Max;
            XYZ[] localCorners = new XYZ[]
            {
                new XYZ(cMin.X, cMin.Y, cMin.Z), new XYZ(cMax.X, cMin.Y, cMin.Z),
                new XYZ(cMin.X, cMax.Y, cMin.Z), new XYZ(cMax.X, cMax.Y, cMin.Z),
                new XYZ(cMin.X, cMin.Y, cMax.Z), new XYZ(cMax.X, cMin.Y, cMax.Z),
                new XYZ(cMin.X, cMax.Y, cMax.Z), new XYZ(cMax.X, cMax.Y, cMax.Z)
            };

            List<XYZ> targetWorldCorners = new List<XYZ>();

            foreach (XYZ corner in localCorners)
            {
                XYZ srcWorldPt = calloutTf.OfPoint(corner);
                XYZ deltaSrc = srcWorldPt - srcParentTf.Origin;
                double u = deltaSrc.DotProduct(srcParentTf.BasisX);
                double v = deltaSrc.DotProduct(srcParentTf.BasisY);
                double w = deltaSrc.DotProduct(srcParentTf.BasisZ);

                XYZ tgtWorldPt = tgtParentTf.Origin + u * tgtParentTf.BasisX + v * tgtParentTf.BasisY + w * tgtParentTf.BasisZ;
                targetWorldCorners.Add(tgtWorldPt);
            }

            double minX = targetWorldCorners.Min(p => p.X);
            double minY = targetWorldCorners.Min(p => p.Y);
            double minZ = targetWorldCorners.Min(p => p.Z);
            double maxX = targetWorldCorners.Max(p => p.X);
            double maxY = targetWorldCorners.Max(p => p.Y);
            double maxZ = targetWorldCorners.Max(p => p.Z);

            // Ensure Z half-depth >= 10.0 ft so the 3D callout box intersects the target view's cut plane
            double zCenter = (minZ + maxZ) * 0.5;
            double zHalfDepth = Math.Max((maxZ - minZ) * 0.5, 10.0);

            XYZ pMin = new XYZ(minX, minY, zCenter - zHalfDepth);
            XYZ pMax = new XYZ(maxX, maxY, zCenter + zHalfDepth);

            return (pMin, pMax);
        }

        private static Transform GetViewTransform(View view)
        {
            Transform t = Transform.Identity;
            t.Origin = view.Origin;
            t.BasisX = view.RightDirection;
            t.BasisY = view.UpDirection;
            t.BasisZ = view.ViewDirection;
            return t;
        }
    }
}
