# Design Pattern: Unified Selection Purge for "Unselect Elements If" Feature

**Date:** 2026-06-22  
**Skill Target:** `csharp-blueprints`  
**Add-in:** FilterPlus

---

## Problem Statement

The "Unselect Elements if" checkboxes (Belongs to Group / Belongs to Assembly) were originally applied only to the **newly matched** `targetIds` from the "WHAT" rules, ignoring any elements already present in the user's selection from previous interactions.

This meant a user could not use "Unselect Elements if" as a standalone **purge tool** against their current selection without also specifying "WHAT" criteria.

---

## Desired Behaviour (Option B — Purge Mode)

The feature must act as a **global purge** at the end of the pipeline:

1. Evaluate WHAT rules → gather `targetIds`
2. Unify `targetIds` + existing `currentCheckedIds` + `idsFromOtherScopes` → `finalCheckedIds`
3. Apply exclusion filter over **all of `finalCheckedIds`** (not just `targetIds`)
4. Sync `targetIds` with the purged result (prevent re-injection of excluded elements)
5. Update `_persistentCheckedIds` and rebuild tree

This allows calling Apply with **no WHAT checkboxes** to purely purge the existing selection.

---

## Implementation Pattern

```csharp
// STEP 4 — Unify previous + new + other scopes
var activeElementIds = _activeElements?.Select(e => e.Id).ToHashSet() ?? new HashSet<ElementId>();
var idsFromOtherScopes = _persistentCheckedIds.Where(id => !activeElementIds.Contains(id)).ToList();

var finalCheckedIds = new HashSet<ElementId>();
if (IncreaseHowAddToCurrent)
    foreach (var id in currentCheckedIds) finalCheckedIds.Add(id);
foreach (var id in targetIds) finalCheckedIds.Add(id);
foreach (var id in idsFromOtherScopes) finalCheckedIds.Add(id);

// STEP 5 — Purge: apply exclusions AFTER unification
if (IncreaseUnselectBelongsToGroup || IncreaseUnselectBelongsToAssembly)
{
    var purgedCheckedIds = new HashSet<ElementId>();
    foreach (var id in finalCheckedIds)
    {
        var el = doc.GetElement(id);
        if (el == null) continue;
        if (IncreaseUnselectBelongsToGroup && el.GroupId != ElementId.InvalidElementId) continue;
        if (IncreaseUnselectBelongsToAssembly && el.AssemblyInstanceId != ElementId.InvalidElementId) continue;
        purgedCheckedIds.Add(id);
    }

    // Keep targetIds consistent so we don't inject excluded elements
    targetIds.IntersectWith(purgedCheckedIds);
    finalCheckedIds = purgedCheckedIds;
}

// STEP 6 — Inject new elements not yet in _activeElements
// STEP 7 — _persistentCheckedIds = finalCheckedIds
// STEP 8 — BuildTree()
```

---

## Critical Rule

> **Always apply exclusion/purge logic AFTER the unification of all selection sources. Applying it only to newly matched IDs leaves stale elements in the user's selection, making the purge feature unreliable.**

---

## Checking Group/Assembly Membership
```csharp
// Belongs to a Model Group?
bool isGrouped = el.GroupId != ElementId.InvalidElementId;

// Belongs to an Assembly Instance?
bool isAssembled = el.AssemblyInstanceId != ElementId.InvalidElementId;
```
Both properties are available on any `Element` object without additional collectors. They are zero-cost lookups.
