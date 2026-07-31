# Debugging: Callout Side-Effect Sibling Views (Phantom "Llamada N+1")
**Date:** 2026-07-30  
**Skill:** `revit-api-core`  
**Severity:** High — produces phantom views in target document that pollute the view tree

---

## Symptom

When transferring a view with callouts (e.g. `ECI - EST - NAVES_DBS Copia 1 1000`) using `ponCallouts` + `ponDependientes`, the target document ends up with **phantom sibling views** named `Llamada 2` and `Llamada 3`, even though the source model only has `Llamada 1`.

**Before fix — target had:**
- `ECI - EST - NAVES_DBS Copia 1 1000` ✅ (correct)
- `ECI - EST - NAVES_DBS Copia 1 1000 - Llamada 1` ✅ (correct callout)
- `ECI - EST - NAVES_DBS Copia 1 1000 - Llamada 2` ❌ (phantom side-effect)
- `ECI - EST - NAVES_DBS Copia 1 1000 - Llamada 3` ❌ (phantom autoincrement)

---

## Root Cause

### Bug #1 — Batch `CopyElements` into a `CalloutView` always creates a sibling view

When `ponDependientes` used **Strategy 1** (batch `CopyElements(vistaorigen, all2DIds, vistadestino, ...)`), Revit's internal behavior when copying 2D elements **into a Callout View** is to create a **new sibling view** (named automatically as the next available `Llamada N`) and place the copied elements there, rather than directly in the callout target.

This is a Revit API invariant for `ViewSection`-derived Callout Views: batch `CopyElements` targeting a callout triggers a **side-effect document event** that spawns the sibling.

### Bug #2 — The old `CALLOUT VIEW PRESERVATION` path made it worse

The old code detected the side-effect and tried to copy from it **back** to the callout target with a second `CopyElements`, which triggered a **second** side-effect (`Llamada 3`). The first side-effect (`Llamada 2`) was never reliably deleted because the `catch { }` block was silent.

### Bug #3 — Unsafe rename in `ponCallouts`

After `CreateCallout` produced `targetCalloutView`, the code tried to rename it to `calloutView.Name`. But since `Llamada 2` was already taken by the side-effect, Revit auto-incremented to `Llamada 3`. No log was emitted.

---

## Fix

### Fix #1 — Early Callout View bypass (in `ponDependientes`)

Added a pre-check at the top of the copy logic that detects if `vistadestino` is a `CalloutView` and jumps directly to the **element-by-element** Strategy 3, completely skipping Strategies 1 and 2:

```csharp
bool targetIsCallout = IsCalloutView(vistadestino);
if (targetIsCallout)
{
    LoggerService.LogInfo($"ponDependientes [CALLOUT DIRECT PATH]: ...");
    goto Strategy3;
}
```

Strategy 3 handles side-effects per-element: if a single element triggers a side-effect view, that view is detected and deleted immediately without cascading.

### Fix #2 — Robust cleanup with error log

Replaced `catch { }` with explicit error logging in the cleanup block:

```csharp
catch (Exception exClean)
{
    LoggerService.LogWarning($"ponDependientes [CALLOUT CLEANUP FAILED]: Could not delete side-effect view '{sideEffectView.Name}' (Id: {sideEffectView.Id.Value}): {exClean.Message}");
}
```

### Fix #3 — Safe rename with pre-check (in `ponCallouts`)

Before renaming the newly created callout view to the source name, check whether that name is already taken to avoid Revit auto-incrementing:

```csharp
bool nameAlreadyTaken = FindExistingViewByName(destino, calloutView.Name) != null;
if (!nameAlreadyTaken)
{
    targetCalloutView.Name = calloutView.Name;
    LoggerService.LogInfo($"ponCallouts [RENAME SUCCESS]: Renamed callout view to '{calloutView.Name}'.");
}
else
{
    LoggerService.LogWarning($"ponCallouts [RENAME SKIPPED]: Name '{calloutView.Name}' already exists in target...");
}
```

---

## Verified Result (After Fix)

```
[CALLOUT DIRECT PATH]: Target view '...Llamada 1' is a Callout View. 
Skipping batch strategies to prevent side-effect sibling creation.

[SUMMARY]: Successfully Copied: 4, Failed: 0, Skipped Triggers: 0.
```

Target document tree:
```
ECI - EST - NAVES_DBS Copia 1 1000
└── ECI - EST - NAVES_DBS Copia 1 1000 - Llamada 1   ← only real callout
```

---

## Key Rule

> **Never use batch `CopyElements` with a `CalloutView` as destination.**  
> Always route Callout View 2D element copies through the element-by-element strategy.  
> The `IsCalloutView(view)` check must be the first guard in `ponDependientes`.
