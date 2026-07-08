// ==============================================================================
// SKILL: SKILL-RVT-FAM (Families & Documentation)
// PATTERN: Intelligent Annotation Engine
// PURPOSE: Handles the programmatic placement of Tags and Dimensions by safely 
//          extracting the underlying topological References required by the API.
// DEPENDENCIES: Autodesk.Revit.DB
// ==============================================================================

using System;
using System.Linq;
using Autodesk.Revit.DB;

namespace RevitAddinBase.Families
{
    /// <summary>
    /// Utility class to generate annotations, tags, and dimensions.
    /// </summary>
    public static class AnnotationBuilder
    {
        /// <summary>
        /// Places an IndependentTag on a specific element in a specific view.
        /// Requires an active Transaction.
        /// </summary>
        /// <param name="doc">The active Document.</param>
        /// <param name="view">The view where the tag will be drawn.</param>
        /// <param name="elementToTag">The element being tagged.</param>
        /// <param name="headPosition">XYZ location for the tag head.</param>
        /// <param name="hasLeader">True to draw a leader line.</param>
        /// <returns>The generated IndependentTag.</returns>
        public static IndependentTag CreateTag(Document doc, View view, Element elementToTag, XYZ headPosition, bool hasLeader = true)
        {
            if (doc == null || view == null || elementToTag == null) return null;

            // Generate a Reference to the element's core
            Reference elemRef = new Reference(elementToTag);

            try
            {
                IndependentTag tag = IndependentTag.Create(
                    doc, 
                    view.Id, 
                    elemRef, 
                    hasLeader, 
                    TagMode.TM_ADDBY_CATEGORY, 
                    TagOrientation.Horizontal, 
                    headPosition);
                    
                return tag;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[AnnotationAPI] Failed to create tag: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Extracts geometric face references from two elements to create a linear dimension.
        /// This is a complex geometric operation requiring geometry extraction.
        /// </summary>
        /// <param name="view">The view to base the geometry extraction on.</param>
        /// <param name="elementA">First element to dimension.</param>
        /// <param name="elementB">Second element to dimension.</param>
        /// <returns>A ReferenceArray containing valid topological references for dimensioning, or null.</returns>
        public static ReferenceArray GetDimensionReferences(View view, Element elementA, Element elementB)
        {
            ReferenceArray refArray = new ReferenceArray();

            // CRITICAL: ComputeReferences must be TRUE, otherwise the API cannot attach the dimension.
            Options geomOptions = new Options { ComputeReferences = true, View = view };

            Reference refA = GetFirstPlanarFaceReference(elementA, geomOptions);
            Reference refB = GetFirstPlanarFaceReference(elementB, geomOptions);

            if (refA != null && refB != null)
            {
                refArray.Append(refA);
                refArray.Append(refB);
                return refArray;
            }

            return null;
        }

        private static Reference GetFirstPlanarFaceReference(Element element, Options options)
        {
            GeometryElement geomElem = element.get_Geometry(options);
            if (geomElem == null) return null;

            foreach (GeometryObject geomObj in geomElem)
            {
                if (geomObj is Solid solid && solid.Faces.Size > 0)
                {
                    foreach (Face face in solid.Faces)
                    {
                        if (face is PlanarFace planarFace)
                        {
                            return planarFace.Reference;
                        }
                    }
                }
                // Handle Instances (which wrap solids)
                else if (geomObj is GeometryInstance geomInst)
                {
                    GeometryElement instGeom = geomInst.GetInstanceGeometry();
                    foreach (GeometryObject instObj in instGeom)
                    {
                         if (instObj is Solid instSolid && instSolid.Faces.Size > 0)
                         {
                             foreach (Face face in instSolid.Faces)
                             {
                                 if (face is PlanarFace planarFace) return planarFace.Reference;
                             }
                         }
                    }
                }
            }
            return null;
        }
    }
}