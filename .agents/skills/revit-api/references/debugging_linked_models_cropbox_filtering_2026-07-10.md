# Debugging Report: Linked Model Element Visibility Spatial Filter Failure in Cropped Views

## Symptom
When the element explorer scope is switched to `Elements Visible` or `Elements in View`, all elements from linked models are filtered out and disappear from the tree. In some cases, linked models disappear from the explorer completely, even when elements from those models are visible in the active viewport. This issue persists regardless of the "Has Bounding Box" toggle state in the "Select" card.

---

## Root Cause
To determine if elements from a linked model are visible in the host view, the `GetAvailableElementsForDoc` method in `RevitSelectionService.cs` performs a manual spatial intersection test in C#. It queries the active view's boundary coordinates and compares them against each linked element's bounding box.

This check failed due to two major flaws in the spatial bounds calculation:

1. **Incorrect Local View Coordinates Comparison:**
   When `activeView.CropBoxActive` is `true`, the code retrieves `activeView.CropBox`. The coordinates of `cropBox.Min` and `cropBox.Max` are relative to the **local view coordinate system** (centered on the camera), not the global project coordinate system. The code compared these local coordinates directly to the project coordinates of the linked elements. Because they never intersected, 100% of the elements were filtered out.
2. **Incorrect Fallback Bounding Box in Non-Cropped Views:**
   When `activeView.CropBoxActive` is `false` (meaning the view is NOT cropped and spatial filtering should not apply), the code fell back to checking intersections against `activeView.get_BoundingBox(null)`. For rotated views or 3D viewports, this box is often offset, causing the intersection check to fail and discard all elements.

---

## Resolution

1. **Coordinate System Transformation:**
   When `activeView.CropBoxActive` is `true`, transform the 8 corners of the `CropBox` into project coordinates using `cropBox.Transform.OfPoint(pt)`. Then calculate the axis-aligned bounding box (AABB) of those transformed points to form the `hostViewOutline`.
2. **Skip Filtering in Non-Cropped Views:**
   If `activeView.CropBoxActive` is `false`, do not fall back to `get_BoundingBox(null)`. Leave `hostViewOutline` as `null` so that spatial filtering is completely skipped, ensuring all elements remain visible.

### Corrected Implementation:
```csharp
Outline hostViewOutline = null;
if (linkInstance != null && (scope == SelectionScope.ElementsVisibleInView || scope == SelectionScope.ElementsBelongingToView))
{
    var activeView = _doc.ActiveView;
    if (activeView != null)
    {
        try
        {
            if (activeView.CropBoxActive)
            {
                var cropBox = activeView.CropBox;
                var transform = cropBox.Transform;
                
                // Transform the 8 corners of the CropBox from local view coordinates to project coordinates
                var corners = new List<XYZ>
                {
                    transform.OfPoint(new XYZ(cropBox.Min.X, cropBox.Min.Y, cropBox.Min.Z)),
                    transform.OfPoint(new XYZ(cropBox.Max.X, cropBox.Min.Y, cropBox.Min.Z)),
                    transform.OfPoint(new XYZ(cropBox.Min.X, cropBox.Max.Y, cropBox.Min.Z)),
                    transform.OfPoint(new XYZ(cropBox.Max.X, cropBox.Max.Y, cropBox.Min.Z)),
                    transform.OfPoint(new XYZ(cropBox.Min.X, cropBox.Min.Y, cropBox.Max.Z)),
                    transform.OfPoint(new XYZ(cropBox.Max.X, cropBox.Min.Y, cropBox.Max.Z)),
                    transform.OfPoint(new XYZ(cropBox.Min.X, cropBox.Max.Y, cropBox.Max.Z)),
                    transform.OfPoint(new XYZ(cropBox.Max.X, cropBox.Max.Y, cropBox.Max.Z))
                };

                double minX = corners.Min(pt => pt.X);
                double minY = corners.Min(pt => pt.Y);
                double minZ = corners.Min(pt => pt.Z);
                double maxX = corners.Max(pt => pt.X);
                double maxY = corners.Max(pt => pt.Y);
                double maxZ = corners.Max(pt => pt.Z);

                hostViewOutline = new Outline(new XYZ(minX, minY, minZ), new XYZ(maxX, maxY, maxZ));
            }
        }
        catch
        {
            // Fallback to null (skips spatial filtering)
        }
    }
}
```

This ensures that linked elements are only spatially filtered when the crop box is active, using correct project-space coordinates.
