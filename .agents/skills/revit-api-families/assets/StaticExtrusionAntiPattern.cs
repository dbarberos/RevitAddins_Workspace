// ==============================================================================
// SKILL: revit-api-families (Family API & Document Creation)
// ANTI-PATTERN: Unbound Static Extrusion
// PURPOSE: Demonstrates why static coordinates without plane bindings fail in family parameters.
// ==============================================================================

using Autodesk.Revit.DB;

namespace RevitAddinBase.Families
{
    public class StaticExtrusionAntiPattern
    {
        public Extrusion CreateStaticExtrusion(Document doc, CurveArrArray openProfile, SketchPlane sketchPlane)
        {
            // FATAL: Drawing solid geometry with static values.
            // When the user modifies family parameters in the project, the solid geometry will not adjust
            // because its sketch lines are not aligned and locked to reference planes.
            Extrusion solidBox = doc.FamilyCreate.NewExtrusion(openProfile, sketchPlane, 2.0);
            return solidBox;
        }
    }
}
