# User Guide - FilterPlus

**Current Version:** 1.6.0  
**Developer:** DBDev_dbarberos  
**Publisher Website:** [Autodesk App Store Profile](https://apps.autodesk.com/en/Publisher/PublisherHomepage) *(Publisher profile URL)*  
**Privacy Policy:** [https://dbdev-dbarberos.github.io/PrivacyPolicy/](https://dbdev-dbarberos.github.io/PrivacyPolicy/)  

---

## 1. General Description & App Compatibility
**FilterPlus** is an advanced, high-performance add-in exclusively designed for **Autodesk Revit** *(Please note: The application supports only Autodesk Revit and does not support Autodesk Advance Steel)*. It fundamentally transforms how BIM professionals interact with model elements by providing an advanced hierarchical tree-view explorer that categorizes elements by Category, Family, Type, and Instance.

Unlike Revit's native selection tools which are flat and limited in scope, FilterPlus offers unparalleled depth and flexibility for navigating complex BIM models. Users can dynamically filter elements in real-time using text searches, regular expressions (Regex), and logical operators (AND/OR). It supports semantic grouping by Workset, Phase, and Level, ensuring that large-scale architectural, structural, and MEP models remain entirely navigable and manageable from a single interface.

FilterPlus introduces advanced boolean selection operations that drastically reduce the time spent on mundane tasks. The 'Increase Checked' feature empowers users to expand their current selection based on complex geometric and relational rules. Users can instantly select elements of the same Category, Family, Type, or Workset. It also allows selection based on element hosting relationships (identifying host elements or all elements hosted by the current selection), nested component extraction, and joined geometries. Users can define exactly where to search (the entire model versus the current view) and how to merge the results (adding to the current selection or creating a completely new set). Exclusions can also be dynamically applied to ignore elements belonging to specific Groups or Assemblies.

By centralizing all these operations into a single, responsive, non-modal interface, FilterPlus allows users to keep the tool open while they work, applying filters and selections iteratively. It is fully compatible with Revit 2023, 2024, 2025, 2026, and 2027, featuring native UI integration, including context menu support for newer versions. FilterPlus is the definitive selection utility for BIM Coordinators, Architects, and Engineers looking to optimize their daily workflows, ensure model accuracy, and save hours of manual selection effort in Autodesk Revit.

---

## 2. Privacy Policy & Data Handling
FilterPlus respects user privacy. The application operates entirely locally within the user's desktop environment and Revit instance.
- **Data Collection & Usage:** The App does not collect, transmit, or share any personal data, telemetry, or model information with the Publisher or any third parties. All processing is done locally on the user's machine.
- **Third-Party Sharing:** Since no data is collected, no data is shared with third-party analytics tools, advertising networks, third-party SDKs, or legal affiliates.
- **Data Retention & Deletion:** All user settings and configurations are stored locally on the user's machine (`%AppData%\FilterPlus`). There is no cloud data retention. Users can request deletion of their data by simply uninstalling the application and manually deleting the local `%AppData%\FilterPlus` folder.
- **Consent Revocation:** Users retain full control over their local data and can revoke consent by uninstalling the application.

---

## 3. Installation & Uninstallation
The installer that ran when you downloaded this plug-in from the Autodesk App Store has already installed the plug-in. You may need to restart the Autodesk product to activate the plug-in. 

To uninstall this plug-in, exit the Autodesk product if you are currently running it, simply rerun the installer by downloading it again from the Autodesk App Store, and select the 'Uninstall' button, or you can uninstall it from 'Control Panel\Programs\Programs and Features' (Windows 10/11), just as you would uninstall any other application from your system.

**Justification for Custom Installer (If using MSI):**
A custom installer is strictly necessary because FilterPlus requires installation across multiple locations to support multiple Revit versions simultaneously (2023, 2024, 2025, 2026, and 2027). The installer must dynamically detect which versions of Revit are present on the user's system and place the appropriate `Addins` manifest and `.dll` payloads into their respective `%AppData%\Autodesk\Revit\Addins\[Version]` directories. Furthermore, the custom installer seamlessly handles the automatic uninstallation of older versions prior to installing new updates, ensuring clean registries and preventing duplicate ribbon icons or API conflicts. 

1.  Close all open Revit sessions.
2.  Run the `FilterPlus.msi` installer. (Requires administration rights to install across all required Revit directories).
3.  Follow the steps in the setup wizard.
4.  Upon opening Revit, if a security prompt appears, select **"Always Load"**.

> [!NOTE]
> Uninstallation completely removes all application files and settings from the system. When a new version is installed, the installer will automatically remove the older version first.

---

## 4. Usage Instructions

### FilterPlus Hierarchical Explorer
The main FilterPlus application allows you to filter and navigate elements in your active selection or project. It constructs a dynamic hierarchical tree-view categorized by **Category > Family > Type > Instance** (Element ID). Unlike standard flat selection filters, it displays element counts at each level and allows you to select, check, or uncheck elements interactively, immediately synchronizing your choices with the active Revit selection.

### Pre-Filtering (Dropdown Filters)
Filter and narrow down elements before selecting or displaying them. Dropdown controls at the top of the interface let you pre-filter elements based on:
- **Category**
- **Family**
- **Type**
- **Level**
- **Workset**

By default, selecting "Todos" (All) displays all elements, while choosing a specific value isolates those elements within the tree structure.

### Semantic Grouping & Sorting
You can dynamically restructure the explorer's hierarchy by grouping elements semantically. Toggle the grouping options on/off to sort elements by:
- **Phase**
- **Level**
- **Workset**

When active, the tree view introduces corresponding parent nodes (e.g., Level name or Phase name) above the Category nodes, rendering complex structural and architectural models highly readable.

### Element Scope Filters
Toggles at the top let you filter the active scope on the fly:
- **3D Model Elements only:** Hides 2D views, annotations, and system elements.
- **Annotation Elements only:** Isolates text, dimensions, and detail items.
- **Has Bounding Box only:** Filters elements to show only those possessing valid geometric boundaries.

### Text Search & Regex System
Locate elements quickly by typing keywords in the search bar. You can control the search behavior using the following options:
- **Search only by name:** Limits matches strictly to element name strings.
- **Use Regex:** Enables advanced Regular Expression pattern matching.
- **Use OR Logic:** If active, new search matches are appended to the currently checked elements. If inactive (default), a new search resets the checks to only matching items.

### Increase Checked (Expand Selection)
Expand your current selection based on advanced relational and geometric rules. You can toggle checkboxes under the "Increase Checked" section to find:
- **Same Category / Same Family / Same Type / Same Workset / Same MEP System**
- **Host of Element / Hosted Elements** (identifies hosts or elements hosted by the current selection)
- **Nested Elements / Supercomponents** (extracts nested family items or their host supercomponents)
- **Joined Elements / Intersecting Elements** (finds elements joined to or physically intersecting the checked items)
- **Group of Assembly** (finds elements belonging to the same Revit Group or Assembly)
- **Dependent Elements** (finds dependent elements linked via Revit's API dependency rules)

**Expansion Constraints:**
- **Search Range:** Limit expansion to either the **Entire Model** or the **Current View**.
- **Result Output:** Choose to either **Add to Current Selection** or **Create a New Selection** set.
- **Exclusions:** Automatically unselect/exclude elements that belong to **Groups** or **Assemblies** to prevent editing locked objects.

### Interactive Element Picking (Pick in Revit)
Click the **Pick Elements** button to temporarily hide the FilterPlus window and select objects directly in the Revit viewport. Once selection is complete, the window automatically reappears, and the new elements are loaded into the tree view and checked.

### Persistent Saved Selections
FilterPlus allows you to save and recover element selections persistently across sessions inside your Revit project.
- **Dropdown List**: Displays already saved selections. The first element is a blank placeholder representing "no selection active".
- **Recover Button**: Relocates your selection context to the saved active models, checks the saved elements inside the explorer tree, and highlights/selects them in Revit. This button is only enabled when a valid selection set is chosen.
- **Save Button**: Opens a separate modal window (`Save Selection`) offering two actions:
  - **Save New (Row 1)**: Type a new name in the TextBox to save the current selection context. The button activates only after text is input.
  - **Overwrite Existing (Row 2)**: Select an existing selection from the ComboBox to replace its contents. The button activates only after a selection is picked.
  - Both operations require confirmation via a native Revit message box before saving.

---

## 5. Commands and Features Guide

### 5.1. Ribbon Panel
The add-in creates a custom tab named **"DBDev"** (configurable) containing the **FilterPlus** panel.

| Command | Function | Technical Class |
| :--- | :--- | :--- |
| **FilterPlus** | Opens the main window for hierarchical selection and filtering. | `FilterPlus.Commands.StartupCommand` |

### 5.2. Context Menu Integration (Revit 2025+)
In Revit 2025 and higher, FilterPlus integrates into the right-click context menu when elements are selected, allowing you to instantly filter the current selection.

---

## 6. System Requirements

| Requirement | Detail |
| :--- | :--- |
| **Supported Revit Versions** | 2023, 2024, 2025, 2026, 2027 |
| **Operating System** | Windows 10 / 11 (64-bit) |
| **Framework** | .NET Framework 4.8 / .NET 8.0 (depending on Revit version) |

> [!WARNING]
> For Revit 2025 and higher, the add-in requires the host environment to have the .NET 8 runtime installed.

---

## 7. Version History (Changelog)

### [1.6.0] - 2026-07-07
#### Added
- **Persistent Saved Selections**: Save/Recover selection sets inside the active Revit document via Extensible Storage.
- **Save Selection Window**: Separate dialog featuring conditional styling triggers and native confirmation prompts to save new or overwrite existing selections.
- **Dynamic Recover Styling**: Main Recover button is conditionally highlighted only when a saved selection is active.
- **NuGet Dependency**: Integrated `System.Text.Json` to handle cross-version element serialization for both .NET Framework 4.8 and .NET 8.

### [1.0.0] - 2026-04-29
#### Added
- **MSI Installer**: Automated multi-version support (Revit 2023-2027).
- **Security Hardening**: Protection against XXE attacks in XML parser and path traversal protection for settings.
- **Error Logging**: Centralized error logging system (`LoggerService`) for ease of tech support.
- **Context Menu**: Contextual right-click integration for Revit 2025+.

#### Fixed
- User settings loading stability.
- Exception management at the add-in startup entry point.

---
*For technical support, contact: dbarberos@outlook.com*
