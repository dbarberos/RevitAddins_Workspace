# TransferPlus

> **Current Version:** v1.6.0  
> **Add-in ID (GUID):** `D1981E8C-1951-45C0-B24C-CA821B7288D2`  

---

## 1. General Description

TransferPlus is an advanced Autodesk Revit Add-in designed to selectively transfer, filter, and rename elements between project documents and linked models. It provides a robust MVVM-based UI for mass-renaming elements using regular expressions, custom sequences, and advanced text manipulation tools.

---

## 2. Requirements and Compatibility

> [!WARNING]
> This add-in requires **Autodesk Revit 2021** or higher on 64-bit Windows systems.

* **Platform**: .NET Framework 4.8 / .NET 8 (depending on the version).
* **Supported Revit Versions**: 2023, 2024, 2025.

---

## 3. Installation & Uninstallation

The installer that ran when you downloaded this plug-in from the Autodesk App Store has already installed the plug-in. You may need to restart the Autodesk product to activate the plug-in.

To uninstall this plug-in, exit the Autodesk product if you are currently running it, simply rerun the installer by downloading it again from the Autodesk App Store, and select the 'Uninstall' button, or you can uninstall it from 'Control Panel\Programs\Programs and Features' (Windows 10/11), just as you would uninstall any other application from your system.

---

## 4. Commands and Features Guide

### 4.1. Ribbon Panel Integration
The add-in creates a custom tab containing the plugin panel.

| Command | Function | Technical Class |
|---------|----------|-----------------|
| **TransferPlus** | Initializes the Ribbon panel and the application. | `TransferPlus.Application` |
| **Manage Checked** | Opens the main UI to manage, filter, and rename elements. | `TransferPlus.Commands.TransferPlusCommand` |

---

## 5. Comprehensive Usage Guide

### Main Interface / Explorer
The application provides a main WPF Window (`TransferPlusView`) where users can manage selected items:
- A tree-view or list of the currently checked elements.
- Collapsible sub-panels for **Rename** and **Selection** operations.

### Scope and Filters
- **Rename Search**: Allows searching for specific text patterns or using Regular Expressions (Regex) within the names of the selected items.
- **Regex Assistance**: A floating contextual window (`RegexAssistView`) allows users to quickly inject standard regex tokens, variables (like Dates, Counters), or capture groups into the search/replace strings.

### Advanced Logic and Tools
* **Uppercase / Lowercase / Titlecase**: Instantly apply text casing to the selected elements.
* **Sequential Numbering**: Apply numeric or alphanumeric sequences to elements.
  - **Location**: Sequence can be placed at the *Beginning* or *End* of the element's name.
  - **Descending Sequences**: Accurately counts backwards. If an initial letter is given (e.g. 'P' with 2 digits), it calculates the full padded prefix ('PZ') and counts downwards.
* **Global Applying**: You can check "Apply to all selected" to bypass the Search matching and apply text casing or numbering to all loaded elements.
* **Safe Linking**: TransferPlus inherently protects against illegal modifications by restricting delete and rename transactions if the elements belong to a linked (Read-Only) document.

> [!TIP]
> **Pro-Tip**: You can define the minimum number of padding digits and custom prefixes/suffixes for sequence generation by clicking on the settings gear icon in the numbering panel.

---

## 6. Version History (Changelog)

<!-- CRITICAL: Do NOT delete previous version entries. Append new version blocks at the top of this section to maintain a complete historical record. -->

### v1.6.0 - 2026-07-16

#### Added
- Implemented a "Location" configuration in the Numbering Settings, allowing sequences to be prepended or appended.
- English contextual placeholder in the Numbering Settings to clarify comma-separated values.

#### Changed
- Removed the early-return block in `UpdateRenamePreviews` so that global formatting (e.g. uppercase, sequences) applies correctly even when the "Find" search text box is empty, provided "Apply to all selected" is checked.
- Overhauled the descending alphanumeric sequencing algorithm to correctly process starting letters and automatic backwards counting.
- Improved UI spacing and margins in `NumberingSettingsView`.
- Refactored `TransferPlusViewModel` to cleanly map editing sequence properties to active view models.

#### Fixed
- Fixed a bug where elements couldn't be universally formatted without triggering a search event.
- Fixed a rendering issue where the placeholder text in the "Custom sequence" textbox was vertically misaligned.

---

## 7. Support and Contact

To report bugs, make suggestions, or request commercial support, please contact:
* **Developer / Company**: DBDev_dbarberos / DBDev Solutions
* **Support**: support@dbdevsolutions.com
