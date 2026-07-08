// ==============================================================================
// SKILL: SKILL-RVT-FAM (Families & Documentation)
// PATTERN: Family API Content Creation
// PURPOSE: Boilerplate for generating parametric content inside the Family Editor (.rfa).
//          Enforces the strict rule of verifying doc.IsFamilyDocument before execution.
// DEPENDENCIES: Autodesk.Revit.DB
// ==============================================================================

using System;
using Autodesk.Revit.DB;

namespace RevitAddinBase.Families
{
    /// <summary>
    /// Utility class for parametric modeling inside the Revit Family environment.
    /// Methods here will fatally crash if executed in a standard Project (.rvt).
    /// </summary>
    public static class FamilyDocumentBuilder
    {
        /// <summary>
        /// Creates a Reference Plane in the family document, which acts as the skeleton 
        /// for constraining 3D geometry.
        /// Requires an active Transaction.
        /// </summary>
        /// <param name="familyDoc">The active Family Document (.rfa).</param>
        /// <param name="bubbleEnd">Start point of the plane line.</param>
        /// <param name="freeEnd">End point of the plane line.</param>
        /// <param name="cutVector">Vector defining the 3D plane's normal direction.</param>
        /// <param name="name">Name of the reference plane.</param>
        /// <returns>The created ReferencePlane, or null if invalid context.</returns>
        public static ReferencePlane CreateReferencePlane(Document familyDoc, XYZ bubbleEnd, XYZ freeEnd, XYZ cutVector, string name)
        {
            if (familyDoc == null || !familyDoc.IsFamilyDocument)
            {
                System.Diagnostics.Debug.WriteLine("[FamilyAPI] Fatal: Attempted to draw a Reference Plane outside a Family Document.");
                return null;
            }

            try
            {
                // FamilyCreate is the equivalent of 'Create' but restricted to the .rfa environment
                ReferencePlane refPlane = familyDoc.FamilyCreate.NewReferencePlane(bubbleEnd, freeEnd, cutVector, familyDoc.ActiveView);
                
                if (refPlane != null && !string.IsNullOrWhiteSpace(name))
                {
                    refPlane.Name = name;
                }
                
                return refPlane;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[FamilyAPI] Failed to create Reference Plane: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Creates a basic solid extrusion based on a 2D profile.
        /// Requires an active Transaction.
        /// </summary>
        /// <param name="familyDoc">The active Family Document (.rfa).</param>
        /// <param name="profile">The continuous 2D closed loop (CurveArrArray).</param>
        /// <param name="sketchPlane">The geometric plane to draw the profile on.</param>
        /// <param name="extrusionEnd">The height/thickness of the extrusion.</param>
        /// <returns>The generated Extrusion element.</returns>
        public static Extrusion CreateExtrusion(Document familyDoc, CurveArrArray profile, SketchPlane sketchPlane, double extrusionEnd)
        {
            if (familyDoc == null || !familyDoc.IsFamilyDocument) return null;

            try
            {
                // Ensure it draws as a solid, not a void
                bool isSolid = true;
                
                return familyDoc.FamilyCreate.NewExtrusion(isSolid, profile, sketchPlane, extrusionEnd);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[FamilyAPI] Failed to create Extrusion: {ex.Message}");
                return null;
            }
        }
    }
}