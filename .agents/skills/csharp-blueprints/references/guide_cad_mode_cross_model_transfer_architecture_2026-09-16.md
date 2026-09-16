# Technical Reference: CAD Mode Cross-Model Transfer Architecture

## Overview & Problem Statement

In Autodesk Revit add-ins such as **TransferPlus**, transferring 2D CAD instances (`ImportInstance`), drafting views (`ViewDrafting`), model detail views (`ViewSection` of `ViewType.Detail`), and detail components (`OST_DetailComponents`) from a source document (`sourceDoc`) to one or more destination documents (`destDoc`) presents unique API challenges:

1. **Model Detail Views vs. 3D Hosts**: Attempting to copy a model detail view directly via `ElementTransformUtils.CopyElements(sourceDoc, viewIds, destDoc)` fails when the destination model lacks the identical 3D model geometry (walls, floors, beams) that the detail view cuts or references.
2. **View-Specific Elements**: View-specific elements (e.g. `FilledRegion`, `Dimension`, detail lines, `Group` of detail type) cannot exist in Revit without an owner view (`OwnerViewId`). Directly copying their IDs to another document without specifying a target view throws an `ArgumentException`.
3. **Detail Components (`OST_DetailComponents`)**: Detail components are 2D family instances. Transferring them into another document does not require placing dummy instances on a view; rather, the user requires the Family and Type definitions to be loaded and ready for insertion.
4. **Hierarchical Sheets**: When sorting by sheet, copying the parent `ViewSheet` in CAD mode violates the principle that CAD mode transfers only the selected details, not sheet layouts.
5. **View Name Uniqueness**: In the Revit DB, `View.Name` must be globally unique across all views. Name collisions throw native Revit exceptions and abort transactions if not handled beforehand.

---

## The 5-Category Item Segregation Pattern

To achieve robust cross-document transfer without corrupting destination models, elements selected in CAD Mode are segregated into 5 discrete categories:

```
                                  Selected CAD Items
                                          │
    ┌────────────────┬────────────────────┼───────────────────┬───────────────────┐
    ▼                ▼                    ▼                   ▼                   ▼
1. ViewDrafting   2. Detail Views     3. ImportInstance   4. Detail Comps     5. Annotations
(Native Drafting) (Model Details)     (DWG / DXF links)   (OST_DetailComps)   (FilledRegions, Groups)
    │                │                    │                   │                   │
    │ Direct copy    │ Convert 2D to      │ Create Drafting   │ In-memory Load    │ Create Drafting
    │ of view        │ ViewDrafting       │ View + copy       │ Family & Types    │ View + copy
    ▼                ▼                    ▼                   ▼                   ▼
Destination       Destination          Destination         Destination         Destination
ViewDrafting      ViewDrafting         ViewDrafting        Families/Symbols    ViewDrafting
```

### 1. Native Drafting Views (`ViewDrafting`)
- Direct transfer using `ElementTransformUtils.CopyElements(sourceDoc, draftingViewIds, destDoc)`.
- Destination view names resolved against `existingViewNames` with optional renaming (`cadCustomNames`) and duplicate suffixes.

### 2. Model Detail Views & Callouts (`ViewSection`, `ViewType.Detail`)
- Instead of copying the 3D-dependent view itself, create a dedicated `ViewDrafting` in `destDoc` matching the source view's scale.
- Collect all 2D annotations (detail lines, text notes, dimensions, filled regions, independent tags) in the source detail view.
- Copy them into the new `ViewDrafting` using:
  ```csharp
  ElementTransformUtils.CopyElements(sourceView, annotationIds, newDraftingView, Transform.Identity, copyOptions);
  ```

### 3. CAD Import & Link Instances (`ImportInstance`)
- Create a dedicated `ViewDrafting` in `destDoc` for each CAD instance.
- Copy the `ImportInstance` into the new drafting view.

### 4. Detail Components (`OST_DetailComponents`)
- Extract underlying `Family` references from selected `FamilyInstance` or `FamilySymbol` elements.
- Transfer each family into `destDoc` using the in-memory `EditFamily -> LoadFamily` pattern (`TryTransferInMemoryFamily` / `CadCrossModelTransferHelper`).
- No visible graphical instances are placed in model views, keeping the destination model clean.

### 5. Independent 2D Annotations (`FilledRegion`, Detail `Group`, Lines)
- Create a dedicated `ViewDrafting` per selected element.
- Copy the element into the new drafting view using its `OwnerView` as the source view context.

---

## Architectural Decision Rules

| Decision Point | Selected Option | Rationale |
|----------------|-----------------|-----------|
| **Rule 1: Placement of CAD instances & annotations** | **Option A**: Dedicated `ViewDrafting` per element | Eliminates cross-view pollution, allows independent naming, and prevents placing 2D annotations in mismatched 3D model views. |
| **Rule 2: "Sort by Sheet" hierarchy** | **Option A**: Transfer only child details into Drafting Views (Bypass `ViewSheet`) | In CAD Mode, the user's intent is to migrate CAD and drafting content. Sheet replication is strictly reserved for standard project mode. |
| **Rule 3: Detail Components (`OST_DetailComponents`)** | **Option A**: Load Family and Types only (no graphical instances) | Detail components are parametric symbols. Loading their definitions empowers BIM modelers to place them where needed without creating orphan geometry. |

---

## "On Duplicates" Resolution Matrix

The duplicate policy configured in the add-in UI is uniformly enforced across all transfer paths:

1. **`AbortTransaction` (Pre-Flight Gate)**:
   - Before opening any write transaction on `destDoc`, evaluate expected view names and family names against existing elements.
   - If any collision is detected, abort immediately and notify the user via `TaskDialog` detailing the exact conflicting item and model.
2. **`KeepOriginal`**:
   - If an element with the target name already exists in `destDoc`, skip the transfer of that specific element without failing the batch.
3. **`AppendSuffix`**:
   - If an element with the target name already exists, append the user-defined suffix (e.g., `_Copy`).
   - If `Name + Suffix` also exists, automatically increment (`Name_Copy_1`, `Name_Copy_2`) until a unique name is obtained.
