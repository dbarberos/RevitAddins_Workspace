# Debugging & Pattern: Callout Bubble Visibility & Scale Threshold Filter
**Date:** 2026-07-30  
**Skill:** `revit-api-core`  
**Domain:** Callout Symbol Rendering, Cut Plane Intersections & Scale Filters

---

## Symptom

When programmatically transferring or creating Callout Views in Revit (using `ViewSection.CreateCallout`), the callout view is created in the Project Browser, but its graphical bubble/symbol is **invisible** on the parent plan or section view.

---

## Root Causes

1. **Cut Plane Disconnect Across Level Elevation Offsets (`DeltaZ`)**:
   Revit ONLY renders a callout bubble on a parent view if the 3D bounding box of the callout physically **intersects the parent view's Cut Plane**. When source and target levels have different elevations ($Z_{src} \neq Z_{tgt}$), a shallow 3D box ($zHalfDepth < 1.0$ ft) fails to reach the Cut Plane at the target level.
2. **Scale Filter Threshold (`SECTION_COARSER_SCALE_PULLDOWN`)**:
   Revit automatically suppresses callout bubbles if the parent view scale (e.g. 1:1000) is coarser than the callout's "Hide at scales coarser than" parameter threshold (default 1:100).
3. **Category Visibility**:
   Categories `BuiltInCategory.OST_Viewers` (Vistas) or `BuiltInCategory.OST_CalloutBoundary` (Líneas de llamada) are hidden in the target parent view.

---

## Solutions & Implementation Pattern

### 1. Z-Depth Expansion for Cut Plane Intersection
When building `pMin` and `pMax` for `ViewSection.CreateCallout`, ensure the Z half-depth is expanded to at least 10 feet ($\pm 10.0$ ft) centered on the target level:

```csharp
double zCenter = (minZ + maxZ) * 0.5;
double zHalfDepth = Math.Max((maxZ - minZ) * 0.5, 10.0);

XYZ pMin = new XYZ(minX, minY, zCenter - zHalfDepth);
XYZ pMax = new XYZ(maxX, maxY, zCenter + zHalfDepth);

ViewSection callout = ViewSection.CreateCallout(doc, parentView.Id, vftId, pMin, pMax);
```

### 2. Scale Threshold Unlocking
Locate the "Hide at scales coarser than" parameter on the new callout view and update it to match or exceed the parent view's scale:

```csharp
Parameter hideParam = targetCalloutView.Parameters.Cast<Parameter>().FirstOrDefault(p => p != null && p.Definition != null && (
                        p.Definition.Name.IndexOf("coarser", StringComparison.OrdinalIgnoreCase) >= 0 ||
                        p.Definition.Name.IndexOf("escala", StringComparison.OrdinalIgnoreCase) >= 0 ||
                        p.Definition.Name.IndexOf("ocultar", StringComparison.OrdinalIgnoreCase) >= 0));

if (hideParam != null && !hideParam.IsReadOnly)
{
    int parentScale = targetParentView.Scale;
    int currentHideScale = hideParam.AsInteger();
    if (currentHideScale < parentScale && currentHideScale > 0)
    {
        hideParam.Set(parentScale);
    }
}
```

### 3. Category Unhiding
Ensure viewer categories are visible on the target parent view:

```csharp
if (targetParentView.CanCategoryBeHidden(new ElementId(BuiltInCategory.OST_Viewers)))
    targetParentView.SetCategoryHidden(new ElementId(BuiltInCategory.OST_Viewers), false);
if (targetParentView.CanCategoryBeHidden(new ElementId(BuiltInCategory.OST_CalloutBoundary)))
    targetParentView.SetCategoryHidden(new ElementId(BuiltInCategory.OST_CalloutBoundary), false);
```

---

## Key Takeaway

> To guarantee callout bubble visibility on transferred views:
> 1. Always expand $pMin.Z$ / $pMax.Z$ half-depth to $\ge 10.0$ ft centered on target level.
> 2. Unlock the hide-coarser-than scale parameter to match parent view scale.
> 3. Unhide `OST_Viewers` and `OST_CalloutBoundary` on the parent view.
