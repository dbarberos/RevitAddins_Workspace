# 📘 Blueprint: SelectionFilterViewModel

## Purpose
This ViewModel is the core of the FilterPlus element explorer. It manages a 5-level (or 6-level if filtering by phases) tree structure with offline filtering capabilities and real-time synchronization with Revit.

---

## 🏗️ Tree Structure (Hierarchy)
The tree is dynamically built in `InitializeTree` and can toggle between two structures:

1. **Standard**: All > Category > Family > Type > Instance (ID).
2. **By Phase**: All > **Phase** > Category > Family > Type > Instance (ID).

### Construction Rules:
- **Offline First**: The tree is built using a pre-loaded list of `ElementModel`. The Revit API is NEVER called during tree construction to avoid UI thread crashes.
- **Bulk Updating**: The `TreeItemViewModel.IsBulkUpdating` flag is used to silence UI events while rebuilding the tree or performing searches.

---

## 🔍 Filtering Logic (Offline Logic)
The `GetFilteredElements()` method centralizes filters without calling Revit:

| Filter | Internal Logic |
|---|---|
| **Only 3D model objects** | `CategoryType == Model` + `HasBoundingBox` |
| **Only Annotations** | `CategoryType == Annotation` |
| **Has Bounding Box** | `BoundingBox != null` (Excludes materials, cameras, etc.) |

**Mutual Exclusion**: Geometry filters are mutually exclusive. Activating one clears the others and removes hidden elements from the active selection.

---

## ⚡ Live Synchronization (Live Selection)
- **Property**: `IsLiveSelection`
- **Behavior**: If active, the `OnTreeSelectionChanged` method calls `ApplyFilter()` after each click.
- **Safety**: Only triggers the command if `IsBulkUpdating` is false.

---

## 🔍 Search and Additive Selection Logic
The filter acts purely on selection and uses a **Manual (Stateless)** system to avoid state inconsistencies.

### Search Rules:
1. **Manual (On-Demand)**: Instead of searching while typing (Debounce), a click on the "Apply" button is required. This allows the user to configure switches ("Use OR", "Only by name") calmly before executing.
2. **"Only by name" Filter**: 
   - **ON**: Only searches for matches in `node.Name`.
   - **OFF**: Searches in both `node.Name` and the numerical **Element ID**.
3. **"Use OR" Logic (Stateless)**:
   - **OFF**: The command unchecks the entire tree and then checks matches (Replacement search).
   - **ON**: The command does not uncheck anything, it simply adds checks to matches (Additive search).
4. **Auto-Clear**: After successfully applying the search, the text field is cleared to indicate that the action is completed.

### Tree State Management (Lessons Learned):
- **Stateless vs Stateful**: Keeping previous states (`_preSearchCheckedIds`) while the user types generates visual bugs if switches change mid-process. The manual architecture (reading switch states on the button click) is much more robust for complex selection logic.
- **Bottom-Up Refresh**: After a massive check operation, call `node.RefreshState()` from the root.
- **Dispatcher.InvokeAsync**: Use this to clear text fields from commands interacting with heavy Revit processes, ensuring that WPF processes the visual update.
- **Grouped Toggles (Left Alignment)**: To avoid overlap when resizing the window, group switches in horizontal `StackPanel`s with `HorizontalAlignment="Left"` instead of spreading them across grid columns with `*`.
- **Safe Parameter Extraction**: Avoid iterating through `el.Parameters` in massive collections of unknown elements. This can cause an `AccessViolationException`. It is preferable to use `get_Parameter(BuiltInParameter...)` to capture specific fields (Mark, Comments, etc.) and wrap the extraction in a `try-catch` block.
- **Safe UI Dispatcher**: In an Add-in environment, `System.Windows.Application.Current` is usually `null` since Revit is not a pure native WPF application. For asynchronous UI updates, always use `System.Windows.Threading.Dispatcher.CurrentDispatcher.InvokeAsync` instead of `Application.Current.Dispatcher`.
- **ReDoS Protection (Regex)**: When allowing searches by Regular Expressions, always use a timeout `TimeSpan` (e.g., 2 seconds) in the `Regex` constructor to avoid exponential backtracking denial of service attacks. Always catch `RegexMatchTimeoutException`.
- **Modeless Revit API Interaction**: To interact with interactive selection tools (`PickObjects`) from Modeless WPF windows, you must use `IExternalEventHandler`. To provide visual feedback, pass the current selection as an `IList<Reference>` to the selection tool so Revit maintains the blue highlight.
- **Multi-Scope State Synchronization**: When managing multiple views or filters over a dataset (e.g., a tree explorer with active filters), the persistent selection state MUST NOT be overwritten solely with the current visible elements. A "Smart Union" must be performed (retaining IDs from the persistent state that are not part of the current scope + checked elements in the current scope) to prevent silent selection losses when changing views or applying searches.
- **Dynamic Hierarchy (Recursive Building)**: To support multiple levels of grouping (e.g., by Phase, Level, Workset) where the nesting order depends on the user, avoid nested `if-else` structures. Implement a recursive method that consumes a stack or list of active groupers. This allows infinite scaling of organization levels without increasing code complexity.

---

## ⚠️ Threading Considerations
1. **Constructor**: The only place where it is 100% safe to collect Revit data directly (it runs on the command thread).
2. **Dispatcher**: Any modification to the `RootNodes` collection that is notified to the UI must occur via `uiDispatcher.Invoke` or `BeginInvoke`.
3. **Persistence**: Selected IDs are saved in `_persistentCheckedIds` (HashSet) so selection survives scope changes or tree reconstructions.
4. **Bulk Updating**: The use of `TreeItemViewModel.IsBulkUpdating` is critical during searches to prevent every single checkbox change from triggering heavy synchronization events with Revit.
