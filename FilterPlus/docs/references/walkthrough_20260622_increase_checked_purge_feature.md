# Walkthrough – FilterPlus: Increase Checked & Unselect Elements If

**Date:** 2026-06-22  
**Feature Branch:** Selection Filter – Increase Checked panel improvements  
**Files Modified:**
- `FilterPlus/ViewModels/SelectionFilterViewModel.cs`
- `FilterPlus/Views/SelectionFilterView.xaml`

---

## 1. Scope of Changes

### 1.1 Fix: "Apply" button had no effect in "Increase Checked"

**Root causes:**
- `currentCheckedIds` was empty when the Select scope showed all elements and no tree item was manually checked → early return triggered.
- Newly matched elements from WHAT rules were not injected into `_activeElements` before `BuildTree()`.
- `_persistentCheckedIds` from other scopes were not carried over when switching Select options.

**Resolution:** Refactored `ApplyIncreaseChecked()` to:
1. Gather `currentCheckedIds` from the tree.
2. Search via WHAT rules → `targetIds`.
3. Unify: `currentCheckedIds` + `targetIds` + `idsFromOtherScopes` → `finalCheckedIds`.
4. Inject missing elements into `_activeElements` from pre-fetched caches or on-the-fly Revit lookup.
5. Set `_persistentCheckedIds = finalCheckedIds` and call `BuildTree()`.

---

### 1.2 New Feature: "Visible in current view" WHERE scope

Added a third RadioButton to the "Where" group in the Increase Checked panel.

**XAML:**
```xml
<RadioButton Content="Visible in current view"
             IsChecked="{Binding IncreaseWhereVisibleInView}"
             GroupName="WhereGroup" />
```

**ViewModel property:**
```csharp
[ObservableProperty] private bool _increaseWhereVisibleInView;
```

**Collector:**
```csharp
// Two-argument overload – most performant for view visibility
var visibleCollector = new FilteredElementCollector(doc, doc.ActiveView.Id);
domainElements = visibleCollector.WhereElementIsNotElementType().ToElements().ToList();
```

---

### 1.3 Refactor: "Unselect Elements If" as a Global Purge

Changed the execution order so that the exclusion filter (Belongs to Group / Belongs to Assembly) applies **after** the full `finalCheckedIds` is assembled, not just to `targetIds`.

**Before (wrong):**
```
WHAT rules → exclude from targetIds → unify → BuildTree
```
**After (correct):**
```
WHAT rules → unify all sources → exclude from finalCheckedIds → sync targetIds → BuildTree
```

This enables using the "Unselect Elements if" checkboxes with no WHAT rules as a pure purge tool against any existing selection.

---

## 2. Debug Logging Added

Extensive `LoggerService.LogInfo()` calls added throughout `ApplyIncreaseChecked()` to allow tracing:
- ID count at each stage (WHAT rule, unification, exclusion).
- Which elements were injected on-the-fly vs found in pre-fetched cache.
- Final `_persistentCheckedIds` value.

---

## 3. Compilation

```powershell
dotnet build -c Debug.R24
# Result: 0 Errors, 70 Warnings (pre-existing nullability warnings only)
```

---

## 4. Manual Verification

| Test | Expected | Result |
|---|---|---|
| Apply with "Same Category" checked | Adds all matching elements in domain, showing in tree | ✅ |
| Apply with "Visible in current view" scope | Only searches elements visible in active view | ✅ |
| Apply with "Unselect if Belongs to Group" only (no WHAT) | Removes grouped elements from current selection | ✅ |
| Apply with "Same Category" + "Unselect if Belongs to Group" | Adds category matches AND purges grouped elements from final set | ✅ |
