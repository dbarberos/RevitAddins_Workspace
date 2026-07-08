# FilterPlus

> **Current Version:** v1.6.0  
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

### Document and Linked Model Selector
At the top of the main FilterPlus interface, the document selection area allows you to choose the target model context:
- **Selected Models Display**: A read-only text box wrapped in a primary blue (`#007ACC`) border displays the currently active filter scope (either the name of a single model, or a multiple model count like `"Multiple models selected (Count)"`).
- **Select Button**: Clicking the `"Select"` button next to the display box opens the advanced `"Select model or models"` modal window.
- **Active Model Default**: The host Revit document on which the add-in was executed is always checked and selected by default on startup.
- **Select All Models**: A circular checkbox at the top of the selection window allows you to toggle all models (host + links) at once. When checked, the filtering processes all operations across all documents combined (same behavior as the previous `"All Models"` dropdown context).
- **Individual Switches**: Users can use slide switches next to each model name to check or uncheck individual models. Unchecking any model deselects the "Select all models" option, and manually checking all models automatically checks the "Select all models" option.
- **Simultaneous Cross-Document Selection**: When applying selections or rule matches across multiple selected models, FilterPlus creates appropriate coordinate-transformed link references (`CreateLinkReference`). This allows Revit to highlight and select elements in both the host project and linked models at the same time in the viewport.

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
- **Scope Selection**: Toggle between **All Model Elements** or **Elements in View** using round **RadioButtons** indicating visual mutual exclusivity.
- **Rule Hierarchy & Constraints**: The dynamic dropdown parameters are subject to logical dependencies. "Familias" is only enabled and populated if a sibling "Categorías" rule is defined. "Tipos" is strictly enabled and populated if a sibling "Familias" rule is defined. The selectable values are dynamically filtered based on sibling selections.
- **Cascading Deletion**: Modifying a parent rule's type or deleting it automatically prunes any dependent child rules (e.g., removing a Category rule automatically removes any associated Family/Type rules, and removing a Family rule automatically removes any associated Type rules).
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

### Persistent Saved Selections
FilterPlus allows you to save and recover element selections persistently across sessions inside your Revit project.
- **Dropdown List**: Displays already saved selections. The first element is a blank placeholder representing "no selection active".
- **Recover Button**: Relocates your selection context to the saved active models, checks the saved elements inside the explorer tree, and highlights/selects them in Revit. This button is only enabled when a valid selection set is chosen.
- **Save Button**: Opens a separate modal window (`Save Selection`) offering two actions:
  - **Save New (Row 1)**: Type a new name in the TextBox to save the current selection context. The button activates only after text is input.
  - **Overwrite Existing (Row 2)**: Select an existing selection from the ComboBox to replace its contents. The button activates only after a selection is picked.
  - Both operations require confirmation via a native Revit message box before saving.

---

## 6. Version History (Changelog)

### v1.6.0

#### Added
- **Persistent Saved Selections**: Save and recover selection sets persistently within active Revit projects.
- **Save Selection Window**: A dedicated window to save new selections or overwrite existing ones.
- **Save Selection UI Polish**: Standardized button widths and increased bottom spacing for improved visual alignment.
- **Dropdown Auto-Reset**: Dropdowns reset to their default empty states and action buttons automatically disable after recovering or deleting selections.
- **WPF Window Custom Icons**: Added custom title bar icons to all WPF windows.
- **Sort by Model Grouping**: Group elements in the explorer tree by their host or link models, respecting the active grouping hierarchy.

### v1.5.0

#### Added
- **Multi-Document Selection Dialog**: A new selection modal window to manage host and link instance checkboxes individually or in bulk.
- **Unified Button Corners**: Standardized button corner roundness across all windows and controls.

### v1.4.0

#### Added
- **Multi-Model Support**: Query, select, and highlight elements across host and linked models simultaneously.
- **Improved Loading Feedback**: The loading spinner overlay now updates responsively when building trees or running operations.
- **Right Column Layout**: Added scroll support and positioned the scrollbar on the left side of the card area for a clean layout separator.
- **Simplified Header**: Reorganized the top row header context layout to fit cleanly into the window background.

### v1.3.1

#### Added
- **Scope RadioButtons**: Replaced checkboxes with RadioButtons for clearer mutual exclusivity.
- **Cascading Rule Pruning**: Prunes child family or type rules dynamically when parent rules are updated.
- **Rule Activity Logging**: Enabled internal tracing for rule configurations and states.

### v1.3.0

#### Added
- **Pre-Selection Logic**: An advanced query builder to construct logical selection rules.
- **Dynamic Family and Type Rules**: Selectable family and type dropdown values are filtered dynamically based on parent category constraints.
- **Pre-Selection Scope Exclusions**: Mutual exclusion toggles between active view elements and entire model elements.
- **Pre-Selection Scope Synchronization**: Selected rule scope is automatically synchronized with the main interface.

#### Changed
- **Dynamic Action Button Color**: The apply selection button dynamically highlights blue when selection adjustments exist.
- **Clear Selection Flow**: The clear button unchecks selection trees and requests confirmation via the apply button.

#### Fixed
- **Tree Explorer Rebuild**: Resolved visual sync bugs during scope changes.
- **Rule Value Persistence**: Fixed dropdown value resets and dependent rule handling.

### v1.2.0

#### Added
- **Active View Visible Scope**: Added a filter to target strictly visible elements in the current active view.
- **Installer Integration**: Setup MSI installer support for Revit 2023-2027 deployments.

#### Changed
- **Exclusion Filters Scope**: The unselection exclusions now act on the entire unified selection scope.
- **Selection State Persistence**: Selection lists are correctly preserved when changing active scopes.

#### Fixed
- **Empty Initial Expansion**: Fixed a failure when triggering element expansions from an empty selection.
- **Visual Node Injections**: Newly added expansion elements are immediately displayed in the tree explorer.
- **Tree Sync Loop Fix**: Suspends selection triggers during bulk additions to avoid UI lags.

---

## 7. Support and Contact

For bug reports, feature requests, or commercial support, please contact:
* **Developer / Company**: DBDev_dbarberos / DBDev Solutions
* **Support**: dbarberos@outlook.com
