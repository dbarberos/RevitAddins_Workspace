# Implementation Plan — FilterPlus: Scope Selection Stability Fix

## Background

The FilterPlus add-in allows users to filter and select Revit model elements through a hierarchical tree explorer. In the second phase of development, a new **Select** panel was introduced with three scopes:

- **Current Selection** — elements selected before launching the add-in
- **Elements in View** — all visible elements in the active Revit view
- **All Model Elements** — all non-type elements in the document

Multiple debugging cycles revealed a fundamental architectural problem: **the Revit API was being called from the WPF UI thread**, which Revit does not support and which caused Revit to close silently without any error message.

---

## Root Cause: API Thread Violations

### The Law of Revit Thread Safety

> Any call to `FilteredElementCollector`, `Document`, `UIDocument`, or any Revit DB/UI class MUST happen on Revit's API execution thread.

Valid API contexts:
| Context | Safe |
|---|---|
| `IExternalCommand.Execute()` | ✅ |
| `IExternalEventHandler.Execute(UIApplication)` | ✅ |
| `IExternalApplication.OnStartup()` | ✅ |
| `Application.Idling` event handler | ✅ |
| `Dispatcher.BeginInvoke()` / `Task.Run()` | ❌ CRASH |
| `partial void OnXxxChanged()` (CommunityToolkit MVVM) | ❌ CRASH |
| Any WPF event handler (button, RadioButton, etc.) | ❌ CRASH |

### What Was Happening

```
[BEFORE – CRASH path]
User clicks RadioButton "Elements in View"
  → WPF PropertyChanged fires
  → OnCurrentScopeChanged() runs on WPF thread
  → Dispatcher.BeginInvoke(LoadElements)
  → FilteredElementCollector(_doc, _doc.ActiveView.Id)  ← REVIT API ON WPF THREAD
  → Revit closes silently
```

### Failed Approaches Tried

1. `Dispatcher.BeginInvoke` with `DispatcherPriority.Background` → still WPF thread, still crash
2. `Dispatcher.BeginInvoke` with `DispatcherPriority.Normal` → still crashes
3. `IExternalEventHandler` + `ExternalEvent.Raise()` → naming ambiguity between `Autodesk.Revit.UI.ExternalEvent` and `Nice3point.Revit.Toolkit.External.ExternalEvent` caused build errors; execution context interference with Nice3point's ExternalCommand caused continued instability
4. `DoEvents()` (`DispatcherFrame.PushFrame`) to force UI refresh during log output → caused deadlock and Revit closure

---

## Solution: Pre-fetch at Startup (Constructor Strategy)

The only safe and simple approach: **load all Revit data in the ViewModel constructor**, which is called from `StartupCommand.Execute()` — a valid Revit API context. Subsequent scope changes only swap between pre-cached in-memory lists.

```
[AFTER – STABLE path]
StartupCommand.Execute() [API thread]
  → new SelectionFilterViewModel(service)
      → GetAvailableElements(CurrentSelection)   ✅ safe
      → GetAvailableElements(ElementsInView)     ✅ safe
      → GetAvailableElements(AllModelElements)   ✅ safe (capped at 10,000)
  → view.Show()

User clicks RadioButton "Elements in View"
  → OnCurrentScopeChanged() fires (WPF thread)
  → _activeElements = _elementsInViewElements   (just a pointer swap, no API call)
  → BuildTree()                                 (pure WPF operation)
```

---

## Proposed Changes

### RevitSelectionService
No changes. `GetAvailableElements(scope)` remains the single API entry point.

### SelectionFilterViewModel [MODIFY]

**New fields:**
```csharp
private List<ElementModel> _currentSelectionElements = new();
private List<ElementModel> _elementsInViewElements   = new();
private List<ElementModel> _allModelElements         = new();
private List<ElementModel> _activeElements           = new();
private HashSet<ElementId> _persistentCheckedIds     = new();
```

**Constructor:** pre-fetch all three scopes and build initial tree.

**`OnCurrentScopeChanged()`:** Only sets `_activeElements` and calls `BuildTree()` — **zero Revit API calls**.

**`ApplyFilter()`:** After applying the selection to Revit, update:
- `_persistentCheckedIds` = the applied ID set
- `_currentSelectionElements` = rebuilt from ALL known element pools (cross-scope lookup)

### SelectionFilterView.xaml [MODIFY]
Added a loading overlay `Grid` bound to `IsBusy` using `BooleanToVisibilityConverter`, with a rotating spinner path animation (`RotateTransform` + `DoubleAnimation`).

### StartupCommand.cs [MODIFY]
Removed `ExternalEvent` wiring — no longer needed. Only registers `LoggerService.Dispatcher` for thread-safe logging.

---

## Verification Plan

### Manual Testing Sequence
1. Open Revit 2024, select 5 elements, launch FilterPlus
2. Verify "Current Selection" shows only those 5 elements ✓
3. Switch to "Elements in View" → loading spinner appears → all view elements shown ✓
4. Check 3 additional elements, uncheck 1 original → Apply Selection
5. Switch to "Current Selection" → shows 7 elements (4 original + 3 new), all checked ✓
6. Switch to "All Model Elements" → all model elements shown, 7 remain checked ✓
7. Revit must NOT close at any point ✓

### Build Verification
```powershell
dotnet build FilterPlus/FilterPlus.csproj -c Release.R24  # exit 0 ✓
```
