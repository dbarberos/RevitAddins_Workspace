# Debugging & Pattern: Cross-Document Callout Coordinate Projection
**Date:** 2026-07-30  
**Skill:** `revit-api-geometry`  
**Domain:** View Section / Plan Callout BoundingBox Transformation

---

## Symptom

When creating callout views using `ViewSection.CreateCallout(Document doc, ElementId parentViewId, ElementId viewFamilyTypeId, XYZ pMin, XYZ pMax)` across models, passing raw source world points or using `CropBox.Transform.Origin` results in callout bubbles being shifted away from transferred 2D annotation elements.

---

## Root Cause

1. `ViewSection.CreateCallout` expects `pMin` and `pMax` expressed in the **Target Document's World Coordinate System**.
2. Revit's `CopyElements` maps 2D elements relative to `view.Origin` (the fixed 2D view plane origin), NOT `view.CropBox.Transform.Origin` (which moves whenever crop bounds are adjusted). Using `CropBox.Transform.Origin` creates a 2D offset error equal to the difference between parent view crop centers.

---

## Solution: View-Plane Anchored 8-Corner Projection

Map the callout's 3D bounding box corners from `calloutView`'s local space into `vistaorigen`'s fixed 2D view plane coordinate system $(u, v, w)$ anchored at `vistaorigen.Origin`, and then re-project $(u, v, w)$ onto `vistadestino`'s view coordinate system anchored at `vistadestino.Origin`:

```csharp
Transform calloutTf = cropBox.Transform ?? Transform.Identity;

// 1. Get Parent View Plane Transforms (anchored to view.Origin)
Transform srcParentTf = GetViewTransform(vistaorigen);
Transform tgtParentTf = GetViewTransform(vistadestino);

// 2. Local Callout Corners (8 points)
XYZ cMin = cropBox.Min;
XYZ cMax = cropBox.Max;
XYZ[] localCorners = new XYZ[]
{
    new XYZ(cMin.X, cMin.Y, cMin.Z), new XYZ(cMax.X, cMin.Y, cMin.Z),
    new XYZ(cMin.X, cMax.Y, cMin.Z), new XYZ(cMax.X, cMax.Y, cMin.Z),
    new XYZ(cMin.X, cMin.Y, cMax.Z), new XYZ(cMax.X, cMin.Y, cMax.Z),
    new XYZ(cMin.X, cMax.Y, cMax.Z), new XYZ(cMax.X, cMax.Y, cMax.Z)
};

List<XYZ> targetWorldCorners = new List<XYZ>();

foreach (XYZ corner in localCorners)
{
    // Local callout -> Source World
    XYZ srcWorldPt = calloutTf.OfPoint(corner);

    // Source World -> Parent View Plane Local (u, v, w) anchored at view.Origin
    XYZ deltaSrc = srcWorldPt - srcParentTf.Origin;
    double u = deltaSrc.DotProduct(srcParentTf.BasisX);
    double v = deltaSrc.DotProduct(srcParentTf.BasisY);
    double w = deltaSrc.DotProduct(srcParentTf.BasisZ);

    // (u, v, w) -> Target World anchored at vistadestino.Origin
    XYZ tgtWorldPt = tgtParentTf.Origin + u * tgtParentTf.BasisX + v * tgtParentTf.BasisY + w * tgtParentTf.BasisZ;
    targetWorldCorners.Add(tgtWorldPt);
}

// 3. Compute Normalized pMin and pMax for CreateCallout
XYZ pMin = new XYZ(targetWorldCorners.Min(p => p.X), targetWorldCorners.Min(p => p.Y), targetWorldCorners.Min(p => p.Z));
XYZ pMax = new XYZ(targetWorldCorners.Max(p => p.X), targetWorldCorners.Max(p => p.Y), targetWorldCorners.Max(p => p.Z));

ViewSection targetCallout = ViewSection.CreateCallout(destinoDoc, vistadestino.Id, targetVftId, pMin, pMax);
```

```csharp
private static Transform GetViewTransform(View view)
{
    Transform t = Transform.Identity;
    t.Origin = view.Origin;
    t.BasisX = view.RightDirection;
    t.BasisY = view.UpDirection;
    t.BasisZ = view.ViewDirection;
    return t;
}
```

---

## Key Takeaway

> Always anchor cross-document 2D/callout coordinate projections to `view.Origin` (the fixed view plane origin) rather than `CropBox.Transform.Origin`. This ensures 100% perfect alignment with 2D elements copied via `ElementTransformUtils.CopyElements`.
