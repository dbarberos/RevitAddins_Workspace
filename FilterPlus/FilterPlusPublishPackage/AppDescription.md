# FilterPlus

**FilterPlus** is an advanced selection and filtering add-in for Autodesk Revit designed to overcome the limitations of the native project browser. It allows for the massive, asynchronous collection of elements, visualizing them in a virtualized Category/Family/Type/Instance tree, and refining selections through dynamic rules (Intersections, Group membership, View visibility) without freezing the UI.

---

## Requirements and Compatibility

* **Platform**: .NET Framework 4.8 (Revit 2023, 2024) / .NET 8 (Revit 2025, 2026, 2027).
* **Supported Revit Versions**: 2023, 2024, 2025, 2026, 2027 (Win64).

---

## Installation & Uninstallation

The installer that ran when you downloaded this plug-in from the Autodesk App Store has already installed the plug-in. You may need to restart the Autodesk product to activate the plug-in.

To uninstall this plug-in, exit the Autodesk product if you are currently running it, simply rerun the installer by downloading it again from the Autodesk App Store, and select the 'Uninstall' button, or you can uninstall it from 'Control Panel\Programs\Programs and Features' (Windows 10/11), just as you would uninstall any other application from your system.

---

## Commands and Features Guide

### Ribbon Panel Integration
The add-in creates a custom tab containing the FilterPlus panel.

| Command | Function | Technical Class |
|---------|----------|-----------------|
| **FilterPlus** | Opens the main window for hierarchical selection and filtering. | `FilterPlus.Application` |
| **(Context Menu)** | In Revit 2025+, FilterPlus integrates into the right-click menu for instant filtering. | `FilterPlus.ViewModels.SelectionFilterViewModel` |

---

## Comprehensive Usage Guide

### FilterPlus Hierarchical Explorer
The main FilterPlus application allows you to filter and navigate elements in your active selection or project. It constructs a dynamic hierarchical tree-view categorized by **Category > Family > Type > Instance (Element ID)**. Unlike standard flat selection filters, it displays element counts at each level and allows you to select, check, or uncheck elements interactively, immediately synchronizing your choices with the active Revit selection.

### Document and Linked Model Selector
At the top of the main FilterPlus interface, the document selection area allows you to choose the target model context:
- **Selected Models Display**: A read-only text box wrapped in a primary blue border displays the currently active filter scope (either the name of a single model, or a multiple model count like `"Multiple models selected (Count)"`).
- **Select Button**: Clicking the `"Select"` button opens the advanced `"Select model or models"` modal window.
- **Active Model Default**: The host Revit document on which the add-in was executed is always checked and selected by default on startup.
- **Select All Models**: A toggle switch at the top of the selection window allows you to toggle all models (host + links) at once. When checked, the filtering processes all operations across all documents combined.
- **Individual Switches**: Users can use slide switches next to each model name to check or uncheck individual models.
- **Simultaneous Cross-Document Selection**: When applying selections across multiple selected models, FilterPlus creates coordinate-transformed link references (`CreateLinkReference`). This allows Revit to highlight and select elements in both the host project and linked models simultaneously.
- **100,000 Elements Safety Threshold**: To prevent UI freezes and memory crashes when loading massive datasets, FilterPlus enforces a safety limit of **100,000 elements**. If the combined total count across all selected models exceeds this limit, an automatic fallback is triggered to Active Model Only.

### Pre-Filtering (Dropdown Filters)
Dropdown controls at the top of the interface let you pre-filter elements based on:
- **Category**
- **Family**
- **Type**
- **Level**
- **Workset**

### Dynamic Selection & Expansion
- **Select in Revit**: Pushes the currently checked tree elements into Revit's active selection set.
- **Isolate in View**: Temporarily isolates checked elements in the active Revit view.
- **Expand Selection**: Expands selection by Intersections, Group elements, Assembly members, or Host levels.

### Persistent Saved Selections
Save and recover selection sets persistently inside your Revit models:
- **Save Selection**: Save the current selection set under a custom name or overwrite an existing selection set.
- **Recover Selection**: Instantly restore saved selection sets at any point during your modeling sessions.

---

## Support and Contact

For bug reports, feature requests, or technical support, please contact:
* **Developer**: DBDev_dbarberos
* **Company**: DBDev Solutions
* **Website**: https://dbdev-dbarberos.github.io
* **Support Email**: dbarberos@outlook.com
