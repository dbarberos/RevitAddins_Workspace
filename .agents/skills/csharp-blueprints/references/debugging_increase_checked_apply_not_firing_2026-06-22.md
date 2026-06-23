# Debugging Report: "Apply" in "Increase Checked" Panel Not Firing

**Date:** 2026-06-22  
**Skill Target:** `csharp-blueprints`  
**Add-in:** FilterPlus  
**File:** `FilterPlus/ViewModels/SelectionFilterViewModel.cs`

---

## Symptom

Clicking the **Apply** button inside the "Increase Checked" panel produced no visible effect and no log output. No elements were added, no tree refresh occurred.

## Root Causes Found (Multiple)

### Root Cause 1 – Early Return Guard on Empty Selection
The method `ApplyIncreaseChecked()` contained an early-return guard:
```csharp
if (currentCheckedIds.Count == 0)
{
    StatusMessage = "No elements selected...";
    return;
}
```
When the explorer was showing **all model elements** (scope = "All Model") and the user had not manually selected anything via checkboxes in the tree, `currentCheckedIds` was always empty, causing immediate exit.

**Fix:** This guard is correct but the user needs at least one element checked in the tree before applying Increase rules. The UX was later clarified.

---

### Root Cause 2 – `_persistentCheckedIds` Not Unified Across Scopes
When the user switched the **Select** dropdown (e.g., from "Elements in View" to "All Model"), the checked IDs from the previous scope were stored in `_persistentCheckedIds` but were **not carried over** to the new scope's tree. As a result, the Increase engine searched relative to an empty "current" selection.

**Fix:** The unification step was introduced:
```csharp
var activeElementIds = _activeElements?.Select(e => e.Id).ToHashSet() ?? new HashSet<ElementId>();
var idsFromOtherScopes = _persistentCheckedIds.Where(id => !activeElementIds.Contains(id)).ToList();

var finalCheckedIds = new HashSet<ElementId>();
if (IncreaseHowAddToCurrent)
    foreach (var id in currentCheckedIds) finalCheckedIds.Add(id);
foreach (var id in targetIds) finalCheckedIds.Add(id);
foreach (var id in idsFromOtherScopes) finalCheckedIds.Add(id);
```

---

### Root Cause 3 – Newly Matched Elements Not Injected into `_activeElements`
Elements found by the "WHAT" rules (e.g., SameCategory) that did not exist in the current `_activeElements` list were not injected before `BuildTree()` was called. The tree was rebuilt without those elements present.

**Fix:** An injection step was added before `BuildTree()`:
```csharp
var elementsToInject = new List<ElementModel>();
foreach (var id in targetIds)
{
    if (activeIds.Contains(id)) continue;
    if (allKnownById.TryGetValue(id, out var existingModel))
        elementsToInject.Add(existingModel);
    else
    {
        var el = doc.GetElement(id);
        if (el != null && el.Category != null)
        {
            var newModel = _selectionService.MapToElementModel(el);
            if (newModel != null) elementsToInject.Add(newModel);
        }
    }
}
if (elementsToInject.Count > 0)
    _activeElements.AddRange(elementsToInject);
```

---

## Key Lesson

> **In WPF/MVVM ViewModels that manage a virtualized tree backed by multiple pre-fetched scopes, always unify all scope caches before computing diffs. Never assume the "current" explorer state is complete.**

---

## Verification

- Logs from `LoggerService.LogInfo` confirmed accumulation of IDs at each stage.
- After the fix, logs showed correct non-zero counts and elements appeared in the Revit explorer tree with checkmarks applied.
