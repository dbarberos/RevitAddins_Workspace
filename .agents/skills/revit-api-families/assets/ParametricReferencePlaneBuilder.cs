// ==============================================================================
// SKILL: revit-api-families (Family API & Document Creation)
// PATTERN: Parametric Reference Plane Creator
// PURPOSE: Creates reference planes and updates their strength parameters in families.
// ==============================================================================

using Autodesk.Revit.DB;

namespace RevitAddinBase.Families
{
    public class ParametricReferencePlaneBuilder
    {
        public ReferencePlane CreateParametricReferencePlane(Document doc, XYZ point, XYZ normal, XYZ direction, string name)
        {
            // 1. Create the reference plane using FamilyCreate (FamilyItemFactory)
            ReferencePlane refPlane = doc.FamilyCreate.NewReferencePlane(point, direction, normal, doc.ActiveView);
            refPlane.Name = name;
            
            // 2. Set reference behavior (origin or active dimension host)
            // Note: IsReference cannot be set directly; it must be updated via its internal parameter.
            Parameter paramIsRef = refPlane.get_Parameter(BuiltInParameter.EXTENT_ELEM_IS_REFERENCE);
            if (paramIsRef != null && !paramIsRef.IsReadOnly)
            {
                paramIsRef.Set(1); // 1 = Strong Reference, 0 = Not a Reference
            }
            
            return refPlane;
        }
    }
}
