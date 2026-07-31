# Technical Debugging & Resolution: Callout View Transfer & Callout Bubble Placement

**Date:** 2026-07-30  
**Add-in:** TransferPlus  
**Subsystem:** `TransferOrchestrator.cs` (`ponCallouts` & `ponDependientes`)

---

## Executive Summary

During view transfer operations involving Callout Views (e.g. `ECI - EST - NAVES_DBS Copia 1 1000` containing `Llamada 1`), three distinct Revit API anomalies were discovered and resolved:
1. **Phantom Sibling Views ("Llamada 2", "Llamada 3")**: Target document received phantom sibling views due to batch `CopyElements` targeting a `CalloutView`.
2. **2D Plane Alignment Error**: Using `CropBox.Transform.Origin` created a 2D offset error equal to crop center differences. Resolved by anchoring projection directly to `view.Origin`.
3. **Invisible Callout Bubble (Elevation Offsets & Scale Filters)**: Callout bubble was hidden on target views due to:
   - **Z-Depth Cut Plane Disconnect**: Callout box Z-depth did not reach target view's Cut Plane across Level elevation deltas (`DeltaZ`).
   - **Scale Threshold Filter**: Parent view scale (e.g. 1:1000) was coarser than callout's "Hide at scales coarser than" parameter threshold (1:100).

---

## Bug #1: Phantom Sibling Views (Batch `CopyElements` on Callout Views)

### Symptom
When transferring a view containing callouts, the target model ended up with unwanted sibling views named `Llamada 2` and `Llamada 3`, even though the source model only possessed `Llamada 1`.

### Root Cause
When `ponDependientes` executed Strategy 1 (batch `CopyElements(vistaorigen, all2DIds, vistadestino, ...)`), Revit's internal view engine automatically spawned a new sibling callout view on `vistadestino` whenever 2D elements were copied into a `ViewSection`-derived Callout View.

### Resolution
- **Early Callout Detection**: In `ponDependientes`, added an early pre-check `IsCalloutView(vistadestino)`. If true, the code immediately bypasses batch Strategies 1 & 2 via `goto Strategy3;` (element-by-element copy with instant per-element side-effect cleanup).
- **Safe Rename Pre-Check**: In `ponCallouts`, added `FindExistingViewByName(destino, calloutView.Name)` before renaming target callouts to prevent Revit auto-incrementing view names.

---

## Bug #2: Callout Bubble Alignment (View Plane vs Crop Box Origin Misalignment)

### Symptom
The callout bubble on the target parent view appeared shifted or misaligned relative to the transferred 2D annotation elements.

### Root Cause
`CopyElements` maps 2D elements relative to the **fixed View Plane origin** (`view.Origin`), NOT the `view.CropBox.Transform.Origin` (which shifts whenever the crop box rectangle is resized or regenerated).
Using `CropBox.Transform.Origin` created a 2D offset error equal to $(X_{crop2} - X_{crop1}, Y_{crop2} - Y_{crop1})$ between source and destination parent views.

### Resolution: 2D View Plane Origin Alignment
Implemented exact 8-corner 3D basis projection anchored directly to `view.Origin`:
```csharp
Transform srcParentTf = Transform.Identity;
srcParentTf.Origin = vistaorigen.Origin;
srcParentTf.BasisX = vistaorigen.RightDirection;
srcParentTf.BasisY = vistaorigen.UpDirection;
srcParentTf.BasisZ = vistaorigen.ViewDirection;

Transform tgtParentTf = Transform.Identity;
tgtParentTf.Origin = vistadestino.Origin;
tgtParentTf.BasisX = vistadestino.RightDirection;
tgtParentTf.BasisY = vistadestino.UpDirection;
tgtParentTf.BasisZ = vistadestino.ViewDirection;
```

---

## Bug #3: Invisible Callout Bubble (Cut Plane Disconnect & Scale Threshold)

### Symptom
Even after coordinate calculation, the callout bubble was not rendered by Revit on the target view `ECI - EST - NAVES_DBS Copia 1 1000`.

### Root Cause
1. **Cut Plane Disconnect Across Level Elevation Offsets (`DeltaZ`)**:
   Revit's graphics engine ONLY renders a callout bubble on a parent view if the 3D section box of the callout physically **intersects the parent view's Cut Plane**. When source level ($Z = 0.0$ ft) and target level ($Z = -5.906$ ft) differed, a shallow callout box did not reach the Cut Plane at the target level.
2. **Scale Filter Threshold (`SECTION_COARSER_SCALE_PULLDOWN`)**:
   Revit automatically suppresses callout bubbles if the parent view scale (e.g. 1:1000) is coarser than the callout's "Hide at scales coarser than" parameter threshold (default 1:100).

### Resolution
1. **Z-Depth Expansion**: Centered 3D callout box at $zCenter = (minZ + maxZ) * 0.5$ and expanded half-depth to at least $10.0$ ft ($pMin.Z = zCenter - 10.0$, $pMax.Z = zCenter + 10.0$). This guarantees 3D intersection with the target view's Cut Plane.
2. **Scale Threshold Unlocking**: Dynamically updated the callout's hide-coarser-than parameter to match or exceed `vistadestino.Scale` (1:1000):
   ```csharp
   if (currentHideScale < parentScale && currentHideScale > 0)
   {
       hideParam.Set(parentScale);
   }
   ```
3. **Category Unhiding**: Enforced `vistadestino.SetCategoryHidden(OST_Viewers, false)` and `SetCategoryHidden(OST_CalloutBoundary, false)`.

---

## Verification

- **Build Output**: `0 Errores` (Published cleanly to Revit Addins folder).
- **Target ViewPlans Count**: Exactly 10 ViewPlans (8 base + 1 parent + 1 `Llamada 1`).
- **Callout Bubble Position**: Overlaps 100% accurately with transferred 2D elements and renders visibly on 1:1000 views.
