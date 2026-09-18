using System;
using Autodesk.Revit.DB;

namespace TransferPlus.Services
{
    public static class FamilyHostTypeHelper
    {
        /// <summary>
        /// Determines the English host type description for a Revit Family.
        /// Returns designations such as: Face-based, Level-based, Work Plane-based, Wall-hosted, Floor-hosted, Ceiling-hosted, Roof-hosted, or Stand-alone.
        /// </summary>
        public static string DetermineHostTypeDescription(Family? family)
        {
            if (family == null || !family.IsValidObject) return "Stand-alone";

            try
            {
                // 1. Check BuiltInParameter FAMILY_HOSTING_BEHAVIOR
                Parameter pHost = family.get_Parameter(BuiltInParameter.FAMILY_HOSTING_BEHAVIOR);
                if (pHost != null && pHost.HasValue)
                {
                    int hostVal = pHost.AsInteger();
                    switch (hostVal)
                    {
                        case 1: return "Wall-hosted";
                        case 2: return "Floor-hosted";
                        case 3: return "Ceiling-hosted";
                        case 4: return "Roof-hosted";
                        case 5: return "Face-based";
                        case 6: return "Work Plane-based";
                        case 0: return "Stand-alone";
                    }
                }

                // 2. Check FamilyPlacementType
                switch (family.FamilyPlacementType)
                {
                    case FamilyPlacementType.OneLevelBased: return "Level-based";
                    case FamilyPlacementType.OneLevelBasedHosted: return "Hosted";
                    case FamilyPlacementType.TwoLevelsBased: return "Two Levels-based";
                    case FamilyPlacementType.WorkPlaneBased: return "Work Plane-based";
                    case FamilyPlacementType.ViewBased: return "View-based";
                    case FamilyPlacementType.CurveBased: return "Curve-based";
                    case FamilyPlacementType.CurveBasedDetail: return "Curve-based Detail";
                    case FamilyPlacementType.Invalid: return "Stand-alone";
                }
            }
            catch
            {
                // Catch invalid handle / unmanaged object exceptions
            }

            return "Stand-alone";
        }
    }
}
