// ==============================================================================
// SKILL: revit-api-geometry (Vector & Spatial Analytics)
// ANTI-PATTERN: Unfiltered ReferenceIntersector
// PURPOSE: Demonstrates why unfiltered raycasting leads to critical freezes.
// ==============================================================================

using Autodesk.Revit.DB;

namespace RevitAddinBase.Geometry
{
    public class UnfilteredRaycastingAntiPattern
    {
        public ReferenceIntersector ConfigureFatalIntersector(View3D view3D)
        {
            // FATAL: Allocating a ReferenceIntersector without Class or Category filters.
            // This forces Revit to test ray collisions against EVERY face of EVERY screw, piece of furniture,
            // or detailed object in the model, degrading compute times from milliseconds to seconds per ray.
            ReferenceIntersector intersector = new ReferenceIntersector(view3D); 
            return intersector;
        }
    }
}
