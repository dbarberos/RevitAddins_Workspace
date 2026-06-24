# Debugging Report: "Apply" in "Increase Checked" Panel Freezing the UI (Infinite Recursion)

**Date:** 2026-06-24  
**Skill Target:** `csharp-blueprints`  
**Add-in:** FilterPlus  
**File:** `FilterPlus/ViewModels/SelectionFilterViewModel.cs`

---

## Symptom

When the user clicked the **Apply** button inside the "Increase Checked" panel, the Revit UI froze completely and appeared unresponsive ("congelado"). No exceptions were visible on screen, and no elements were added to the tree. 

## Root Cause (Infinite UI Event Cascade)

The method `ApplyIncreaseChecked()` was wrapped inside `_actionHandler.Raise(() => { ... }, _actionExternalEvent)` to ensure execution happened safely on the Revit API thread using `IExternalEventHandler`. 

However, during this architectural restructuring, the bulk updating suspension flag (`TreeItemViewModel.IsBulkUpdating = true;`) was accidentally removed from the execution block. 

### What happened technically?
1. The injection phase successfully found missing elements via `doc.GetElement(id)` and added them to `_activeElements`.
2. The logic then triggered `BuildTree()`, which invokes `InitializeTree()` to rebuild `RootNodes` based on the newly injected `_activeElements`.
3. During `InitializeTree()`, the method iterates through `_persistentCheckedIds` and restores the "checkbox" states by setting `node.IsChecked = true`.
4. Because `IsBulkUpdating` was `false`, the property setter for `IsChecked` immediately fired the `OnTreeSelectionChanged()` callback.
5. `OnTreeSelectionChanged()` observed that `IsLiveSelection` was active and immediately invoked `ApplyFilter()`, which in turn invoked `BuildTree()` again.
6. This resulted in an **infinite recursion** (or an exponential cascade) of tree rebuilds for every single element checked in the tree, deadlocking the UI thread instantly.

## Code Resolution

The fix was simple but structurally critical. The `TreeItemViewModel.IsBulkUpdating = true;` flag must be set at the very beginning of the `try` block before any heavy UI processing or data injection occurs, and reliably reset in a `finally` block.

```csharp
    [RelayCommand]
    private void ApplyIncreaseChecked()
    {
        if (_actionHandler == null || _actionExternalEvent == null) return;
        
        _actionHandler.Raise(() =>
        {
            try
            {
                // CRITICAL FIX: Suspend UI events BEFORE processing checkmarks or injecting elements
                TreeItemViewModel.IsBulkUpdating = true;
                
                // ... Injection phase ...
                // ... BuildTree() execution ...
            }
            catch (Exception ex)
            {
                LoggerService.LogError("[ApplyIncreaseChecked] EXCEPTION", ex);
            }
            finally
            {
                // Restore UI event triggering
                TreeItemViewModel.IsBulkUpdating = false;
            }
        }, _actionExternalEvent);
    }
```

---

## Key Lesson

> **In WPF/MVVM virtualized trees, when restoring state or dynamically injecting nodes from a background/external event context, always wrap the bulk operation inside an `IsBulkUpdating = true` flag. Failure to suspend selection-changed callbacks during mass instantiation will trigger recursive tree rebuilds, instantly freezing the host application.**
