# FilterPlus

> **Current Version:** v1.3.0  
> **Add-in ID (GUID):** `A5265BB9-214C-4109-8DDC-DF1F6E4305B9`  

---

## 1. Overview

**FilterPlus** is an advanced selection and filtering add-in for Autodesk Revit designed to overcome the limitations of the native project browser. It allows for the massive, asynchronous collection of elements, visualizing them in a virtualized Category/Family/Type/Instance tree, and refining selections through dynamic rules (Intersections, Group membership, View visibility) without freezing the UI.

---

## 2. Requirements and Compatibility

> [!WARNING]
> This add-in is compiled for multiple versions using the `Debug.R[XX]` and `Release.R[XX]` configurations.

* **Platform**: .NET Framework 4.8 (Revit 2023, 2024) / .NET 8 (Revit 2025+).
* **Supported Revit Versions**: 2023, 2024, 2025, 2026, 2027.

---

## 3. Installation & Uninstallation

The installer that ran when you downloaded this plug-in from the Autodesk App Store has already installed the plug-in. You may need to restart the Autodesk product to activate the plug-in.

To uninstall this plug-in, exit the Autodesk product if you are currently running it, simply rerun the installer by downloading it again from the Autodesk App Store, and select the 'Uninstall' button, or you can uninstall it from 'Control Panel\Programs\Programs and Features' (Windows 10/11), just as you would uninstall any other application from your system.

---

## 4. Commands and Features Guide

### 4.1. Ribbon Panel Integration
The add-in creates a custom tab containing the FilterPlus panel.

| Command | Function | Technical Class |
|---------|----------|-----------------|
| **FilterPlus** | Opens the main window for hierarchical selection and filtering. | `FilterPlus.Application` |
| **(Context Menu)** | In Revit 2025+, FilterPlus integrates into the right-click menu for instant filtering. | `FilterPlus.ViewModels.SelectionFilterViewModel` |

---

## 5. Comprehensive Usage Guide

### FilterPlus Hierarchical Explorer
The main FilterPlus application allows you to filter and navigate elements in your active selection or project. It constructs a dynamic hierarchical tree-view categorized by **Category > Family > Type > Instance (Element ID)**. Unlike standard flat selection filters, it displays element counts at each level and allows you to select, check, or uncheck elements interactively, immediately synchronizing your choices with the active Revit selection.

### Pre-Filtering (Dropdown Filters)
Filter and narrow down elements before selecting or displaying them. Dropdown controls at the top of the interface let you pre-filter elements based on:
- **Category**
- **Family**
- **Type**
- **Level**
- **Workset**

By default, selecting "Todos" (All) displays all elements, while choosing a specific value isolates those elements within the tree structure.

### Pre-Selection Rules Filter (Rules & Sets)
Filter elements dynamically using logical operators (AND/OR). Click the **Pre-Selection** icon to open the advanced query window:
- **Scope Selection**: Toggle between **All Model Elements** or **Elements in View** (mutually exclusive) to define the selection source.
- **Tree Logic (Sets & Rules)**: Add nested sets (logical operators) and rules to form complex queries (e.g., `(Category = Walls AND Level = Level 1) OR (Category = Doors)`).
- **Supported Parameters**: Filter by Category, Level, MEP System, Zone, Workset, Phase, System Classification, and MEP Domain.
- **Application**: Click **Apply** to run the query. The window will close, the selected scope will be checked in the main "Select" card, and the matching elements will be checked in the explorer tree.

### Semantic Grouping & Sorting
You can dynamically restructure the explorer's hierarchy by grouping elements semantically. Toggle the grouping options on/off to sort elements by:
- **Phase**
- **Level**
- **Workset**

When active, the tree view introduces corresponding parent nodes (e.g., Level name or Phase name) above the Category nodes, rendering complex structural and architectural models highly readable.

### Element Scope Filters
Toggles at the top let you filter the active scope on the fly (Mutual exclusion logic):
- **3D Model Elements only**: Hides 2D views, annotations, and system elements.
- **Annotation Elements only**: Isolates text, dimensions, and detail items.
- **Has Bounding Box only**: Filters elements to show only those possessing valid geometric boundaries.

### Text Search & Regex System
Locate elements quickly by typing keywords in the search bar. You must click **Apply** to execute the search, which allows you to set the parameters calmly:
- **Search only by name**: Limits matches strictly to element name strings.
- **Use Regex**: Enables advanced Regular Expression pattern matching.
- **Use OR Logic**: If active, new search matches are appended to the currently checked elements. If inactive (default), a new search resets the checks to only matching items.

### Increase Checked (Expand Selection)
Expand your current selection based on advanced relational and geometric rules. You can toggle checkboxes under the "Increase Checked" section to find:
- **Same Category / Same Family / Same Type / Same Workset / Same MEP System**
- **Host of Element / Hosted Elements** (identifies hosts or elements hosted by the current selection)
- **Nested Elements / Supercomponents** (extracts nested family items or their host supercomponents)
- **Joined Elements / Intersecting Elements** (finds elements joined to or physically intersecting the checked items)
- **Group of Assembly** (finds elements belonging to the same Revit Group or Assembly)
- **Dependent Elements** (finds dependent elements linked via Revit's API dependency rules)

#### Expansion Constraints:
* **Search Range (WHERE)**: Limit expansion to the **Entire Model**, the **Current View** (includes non-visible elements bounded to the view), or **Visible in current view** (strictly visible objects).
* **Result Output (HOW)**: Choose to either **Add to Current Selection** or **Select Only New Elements**.
* **Exclusions (Unselect Elements If)**: Automatically unselect/exclude elements that belong to Groups or Assemblies to prevent editing locked objects. 
> [!TIP]
> **Standalone Purge Mode:** You do not need to check any "WHAT" rules to use the exclusion tool. If you want to clean your current selection to remove grouped items, simply check "Belongs to Group" and hit Apply. The system performs a global purge.

### Interactive Element Picking (Pick in Revit)
Click the Pick Elements button to temporarily hide the FilterPlus window and select objects directly in the Revit viewport. Once selection is complete, the window automatically reappears, and the new elements are loaded into the tree view and checked.

---

## 6. Version History (Changelog)

### v1.3.0 - 2026-06-30

#### Added
- **Pre-Selection Rules & Scope Builder**: A complete advanced query builder allowing users to define rules and nested sets using logical operators (AND/OR) to check elements in the tree explorer.
- **Scope Exclusions in Pre-Selection**: Mutual exclusion logic for "All Model Elements" and "Elements in View" scope selectors inside the Pre-Selection window.
- **Scope Syncing**: The chosen scope in the Pre-Selection window is automatically synchronized and checked in the main "Select" card when the filter is applied.

#### Changed
- **Apply Selection Button Visual Feedback**: The "Apply Selection" button now dynamically changes to Blue (`#007ACC`) when tree checkboxes are modified (by manual check/uncheck, Search filters, Pre-Selection, or "Increase Checked"), and resets to default gray once applied to Revit.
- **Clear Button Flow**: The "Clear" button now unchecks all checkboxes and turns the "Apply Selection" button Blue, requiring a click on "Apply Selection" to commit the cleared selection to Revit (unless **On Live Selection** is active).

#### Fixed
- **Tree Explorer Rebuild on Scope Change**: Fixed a bug where switching scopes during pre-selection was blocked by the `IsBulkUpdating` flag, causing the elements tree to not update.

### v1.2.0 - 2026-06-23

#### Added
- **"Visible in current view"** scope in the WHERE section, providing an optimized filter for strictly visible items.
- Full support for WiX MSIs configured for Revit 2023–2027 under `DBDev_dbarberos`.

#### Changed
- **Global Purge System:** The "Unselect Elements If" exclusions now act upon the entire unified selection (previous selection + new matches + out-of-scope checked items). This unlocks the ability to use "Apply" as a standalone purge tool without any WHAT rules.
- Persistent selections (`_persistentCheckedIds`) are now safely merged and carried over when switching viewing scopes.

#### Fixed
- Fixed the silent failure of the **Apply** button when triggering "Increase Checked" on "All Model" with an empty initial selection.
- New elements identified by the expansion logic are now correctly injected and immediately displayed in the UI tree.
- Resolved a critical UI freeze and infinite recursion issue during massive tree updates by properly suspending tree selection events (`IsBulkUpdating`) when applying expansion rules.

---

## 7. Support and Contact

For bug reports, feature requests, or commercial support, please contact:
* **Developer / Company**: DBDev_dbarberos / DBDev Solutions
* **Support**: dbarberos@outlook.com
