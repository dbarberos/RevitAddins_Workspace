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

        /// <summary>
        /// Resilient two-tier copy engine for transferring 2D elements between views (e.g. from Detail Views to Drafting Views).
        /// Executes an initial batch copy, falling back to element-by-element copy if 3D-dependent dimensions or tags fail.
        /// </summary>
        /// <param name="sourceView">Source view containing 2D elements.</param>
        /// <param name="targetView">Target 2D Drafting view in the destination document.</param>
        /// <param name="copyOptions">Revit copy/paste options.</param>
        /// <param name="hadSkippedElements">Outputs true if any incompatible elements (e.g., 3D-dependent dimensions) were skipped.</param>
        /// <returns>Number of successfully copied elements.</returns>
        public static int Copy2DElementsWithFallback(
            View sourceView,
            View targetView,
            CopyPasteOptions copyOptions,
            out bool hadSkippedElements)
        {
            hadSkippedElements = false;
            if (sourceView == null || targetView == null) return 0;

            Document sourceDoc = sourceView.Document;
            Document targetDoc = targetView.Document;

            targetDoc.Regenerate();

            var childElements = new FilteredElementCollector(sourceDoc, sourceView.Id)
                .WhereElementIsNotElementType()
                .Where(e => e.ViewSpecific && e is not Viewport && e is not Level && e is not SketchPlane)
                .Where(e => !e.Name.StartsWith("ViewCrop", StringComparison.OrdinalIgnoreCase) &&
                            !e.Name.StartsWith("extentElem", StringComparison.OrdinalIgnoreCase) &&
                            !e.GetType().Name.Equals("ViewCrop", StringComparison.OrdinalIgnoreCase) &&
                            !e.GetType().Name.Equals("ExtentElem", StringComparison.OrdinalIgnoreCase))
                .Select(e => e.Id)
                .ToList();

            if (!childElements.Any()) return 0;

            copyOptions ??= new CopyPasteOptions();
            int copiedCount = 0;

            try
            {
                // Tier 1: Fast batch copy
                var copiedIds = ElementTransformUtils.CopyElements(sourceView, childElements, targetView, Transform.Identity, copyOptions);
                copiedCount = copiedIds.Count;
            }
            catch
            {
                // Tier 2: Element-by-element fallback (isolates 3D-referenced dimensions/tags)
                foreach (var cid in childElements)
                {
                    try
                    {
                        var singleCopied = ElementTransformUtils.CopyElements(sourceView, new List<ElementId> { cid }, targetView, Transform.Identity, copyOptions);
                        copiedCount += singleCopied.Count;
                    }
                    catch
                    {
                        hadSkippedElements = true;
                    }
                }
            }

            return copiedCount;
        }
    }
}
