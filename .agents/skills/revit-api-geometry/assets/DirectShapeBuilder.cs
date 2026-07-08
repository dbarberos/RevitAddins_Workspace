// ==============================================================================
// SKILL: SKILL-RVT-GEO (Geometry & Spatial Analysis)
// PATTERN: DirectShape Injection & Tessellation
// PURPOSE: Safely creates "dead" geometry (DirectShapes) for visual debugging, 
//          spatial massing, or importing non-native BRep shapes.
// DEPENDENCIES: Autodesk.Revit.DB, System.Collections.Generic
// ==============================================================================

using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace RevitAddinBase.Geometry
{
    /// <summary>
    /// Utility class to construct and inject DirectShape elements.
    /// </summary>
    public static class DirectShapeBuilder
    {
        /// <summary>
        /// Creates a visual 3D box (DirectShape) representing a BoundingBoxXYZ.
        /// Extremely useful for debugging spatial intersections and Raycasting targets.
        /// MUST be called within an active Transaction.
        /// </summary>
        /// <param name="doc">The active Document.</param>
        /// <param name="box">The BoundingBox to visualize.</param>
        /// <param name="categoryId">The target category (Generic Models recommended).</param>
        /// <returns>The generated DirectShape element.</returns>
        public static DirectShape CreateDebugBox(Document doc, BoundingBoxXYZ box, BuiltInCategory categoryId = BuiltInCategory.OST_GenericModel)
        {
            if (doc == null || box == null) return null;

            // 1. Extract corners of the bounding box
            XYZ min = box.Min;
            XYZ max = box.Max;

            XYZ[] pts = new XYZ[8];
            pts[0] = new XYZ(min.X, min.Y, min.Z);
            pts[1] = new XYZ(max.X, min.Y, min.Z);
            pts[2] = new XYZ(max.X, max.Y, min.Z);
            pts[3] = new XYZ(min.X, max.Y, min.Z);
            pts[4] = new XYZ(min.X, min.Y, max.Z);
            pts[5] = new XYZ(max.X, min.Y, max.Z);
            pts[6] = new XYZ(max.X, max.Y, max.Z);
            pts[7] = new XYZ(min.X, max.Y, max.Z);

            // 2. Build the geometry using TessellatedShapeBuilder (High performance for polygons)
            TessellatedShapeBuilder builder = new TessellatedShapeBuilder();
            builder.OpenConnectedFaceSet(true);

            // Define the 6 faces (Triangulation is handled implicitly by Quad faces if planar)
            AddFace(builder, pts[0], pts[1], pts[2], pts[3]); // Bottom
            AddFace(builder, pts[7], pts[6], pts[5], pts[4]); // Top
            AddFace(builder, pts[0], pts[4], pts[5], pts[1]); // Front
            AddFace(builder, pts[1], pts[5], pts[6], pts[2]); // Right
            AddFace(builder, pts[2], pts[6], pts[7], pts[3]); // Back
            AddFace(builder, pts[3], pts[7], pts[4], pts[0]); // Left

            builder.CloseConnectedFaceSet();
            builder.Target = TessellatedShapeBuilderTarget.Solid;
            builder.Fallback = TessellatedShapeBuilderFallback.Mesh;
            builder.Build();

            TessellatedShapeBuilderResult result = builder.GetBuildResult();
            if (result.Outcome != TessellatedShapeBuilderOutcome.Solid && 
                result.Outcome != TessellatedShapeBuilderOutcome.Mesh)
            {
                return null;
            }

            // 3. Inject the constructed geometry as a DirectShape
            ElementId catId = new ElementId(categoryId);
            DirectShape ds = DirectShape.CreateElement(doc, catId);
            ds.SetShape(result.GetGeometricalObjects());
            ds.Name = "Debug_BoundingBox";

            return ds;
        }

        private static void AddFace(TessellatedShapeBuilder builder, XYZ p1, XYZ p2, XYZ p3, XYZ p4)
        {
            List<XYZ> loop = new List<XYZ> { p1, p2, p3, p4 };
            builder.AddFace(new TessellatedFace(loop, ElementId.InvalidElementId));
        }
    }
}