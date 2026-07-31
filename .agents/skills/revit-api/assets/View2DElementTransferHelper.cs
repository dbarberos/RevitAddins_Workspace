using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;

namespace RevitApiHelpers
{
    /// <summary>
    /// Utility class for transferring 2D view-specific elements (detail lines, text, annotations)
    /// across Revit documents and view plans with cross-level view consolidation.
    /// </summary>
    public static class View2DElementTransferHelper
    {
        /// <summary>
        /// Ensures a View object does not have an invalid SketchPlane assigned if it is a ViewPlan.
        /// </summary>
        public static void EnsureSafeViewWorkplane(View targetView)
        {
            if (targetView == null || targetView.Document == null || !targetView.IsValidObject) return;

            // ViewPlan views cannot have an explicitly assigned SketchPlane in Revit API.
            if (targetView is ViewPlan) return;

            Document doc = targetView.Document;
            if (targetView.SketchPlane == null || !targetView.SketchPlane.IsValidObject)
            {
                doc.Regenerate();
                if (targetView.GenLevel != null && targetView.GenLevel.IsValidObject)
                {
                    Plane plane = Plane.CreateByNormalAndOrigin(XYZ.BasisZ, new XYZ(0, 0, targetView.GenLevel.Elevation));
                    SketchPlane sk = SketchPlane.Create(doc, plane);
                    if (sk != null)
                    {
                        try { targetView.SketchPlane = sk; } catch { }
                    }
                }
            }
        }

        /// <summary>
        /// Transfers 2D view-specific elements from source view to target view using batch copying
        /// and side-effect view consolidation to prevent duplicate suffixed views.
        /// </summary>
        public static View Transfer2DElementsWithConsolidation(
            Document origen,
            View vistaorigen,
            View vistadestino,
            CopyPasteOptions copyOptions)
        {
            if (vistaorigen == null || vistadestino == null) return vistadestino;

            if (copyOptions == null) copyOptions = new CopyPasteOptions();

            var viewElements = new FilteredElementCollector(origen, vistaorigen.Id)
                .WhereElementIsNotElementType()
                .Where(e => e != null && e.IsValidObject && e.ViewSpecific &&
                            e is not View &&
                            e is not Viewport &&
                            e is not SunAndShadowSettings &&
                            e is not Level &&
                            e is not SketchPlane &&
                            e is not ElevationMarker &&
                            e.GetType().Name != "ReferenceViewer" &&
                            e.Name != "extentElem" &&
                            e.GetType().Name != "ViewCrop" &&
                            e.GetType().Name != "ExtentElem" &&
                            (e.Category == null || (
                                e.Category.Id.Value != (long)BuiltInCategory.OST_Viewers &&
                                e.Category.Id.Value != (long)BuiltInCategory.OST_ReferenceViewer &&
                                e.Category.Id.Value != (long)BuiltInCategory.OST_CalloutBoundary &&
                                e.Category.Id.Value != (long)BuiltInCategory.OST_Elev
                            )))
                .ToList();

            if (!viewElements.Any()) return vistadestino;

            Document destino = vistadestino.Document;

            var all2DIds = viewElements.Select(e => e.Id).ToList();

            var existingViewIdsBeforeCopy = new HashSet<ElementId>(
                new FilteredElementCollector(destino)
                    .OfClass(typeof(View))
                    .WhereElementIsNotElementType()
                    .Select(v => v.Id)
            );
            int viewsBefore = existingViewIdsBeforeCopy.Count;

            try
            {
                var copiedBatchIds = ElementTransformUtils.CopyElements(vistaorigen, all2DIds, vistadestino, Transform.Identity, copyOptions);
                int viewsAfter = new FilteredElementCollector(destino).OfClass(typeof(View)).WhereElementIsNotElementType().Count();

                if (viewsAfter > viewsBefore)
                {
                    var newlyCreatedViews = new FilteredElementCollector(destino)
                        .OfClass(typeof(View))
                        .WhereElementIsNotElementType()
                        .Cast<View>()
                        .Where(v => !existingViewIdsBeforeCopy.Contains(v.Id) && v.Id != vistadestino.Id)
                        .ToList();

                    View sideEffectView = newlyCreatedViews.FirstOrDefault();
                    if (sideEffectView != null && sideEffectView.IsValidObject)
                    {
                        string targetName = vistadestino.Name;
                        ElementId emptyViewId = vistadestino.Id;

                        try { destino.Delete(emptyViewId); } catch { }
                        try { sideEffectView.Name = targetName; } catch { }

                        return sideEffectView;
                    }
                }
            }
            catch
            {
                // Fallback handling can be implemented here
            }

            return vistadestino;
        }
    }
}
