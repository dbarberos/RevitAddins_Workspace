# User Guide: Document Structure `User_Guide.md`

This asset defines the mandatory section structure and formatting rules for the add-in's `User_Guide.md` technical manual.

---

## 1. Document Structure Template

```markdown
# [Add-in Name]

> **Current Version:** [X.X.X]  
> **Add-in ID (GUID):** `[GUID extracted from the .addin file]`  

---

## 1. General Description

[Provide an executive summary of the add-in's purpose, the problem it solves, and the main workflow.]

---

## 2. Requirements and Compatibility

> [!WARNING]
> This add-in requires **Autodesk Revit 2021** or higher on 64-bit Windows systems.

* **Platform**: .NET Framework 4.8 / .NET 8 (depending on the version).
* **Supported Revit Versions**: [E.g., 2023, 2024, 2025].

---

## 3. Installation & Uninstallation

The installer that ran when you downloaded this plug-in from the Autodesk App Store has already installed the plug-in. You may need to restart the Autodesk product to activate the plug-in.

To uninstall this plug-in, exit the Autodesk product if you are currently running it, simply rerun the installer by downloading it again from the Autodesk App Store, and select the 'Uninstall' button, or you can uninstall it from 'Control Panel\\Programs\\Programs and Features' (Windows 10/11), just as you would uninstall any other application from your system.

---

## 4. Commands and Features Guide

### 4.1. Ribbon Panel Integration
The add-in creates a custom tab containing the plugin panel.

| Command | Function | Technical Class |
|---------|----------|-----------------|
| **[App Start]** | Initializes the Ribbon panel and the application. | `{{Namespace}}.Application` |
| **[Command 1]** | [Functional description] | `{{Namespace}}.Commands.Cmd[Action]` |

---

## 5. Comprehensive Usage Guide

### Main Interface / Explorer
[Provide an overview of the main UI, the hierarchical tree, or core views.]

### Scope and Filters
[List the available scope toggles and grouping options using bullet points]
- **Filter A**: Description.
- **Filter B**: Description.

### Advanced Logic and Tools
[Explain search functionality, expansions, or specific features using clear bullet points and alerts]
* **Constraint 1**: Description.
* **Exclusion 1**: Description.
> [!TIP]
> **Pro-Tip**: Explain hidden gems or workflow optimizations.

---

## 6. Version History (Changelog)

<!-- CRITICAL: Do NOT delete previous version entries. Append new version blocks at the top of this section to maintain a complete historical record. -->

### [Version X.X.X] - [YYYY-MM-DD]

#### Added
- [New functionality 1 or injected command.]

#### Changed
- [Improvement or code refactoring.]

#### Fixed
- [Fix for thread, interface, or API error.]

---

## 7. Support and Contact

To report bugs, make suggestions, or request commercial support, please contact:
* **Developer / Company**: [Your Company / DBDev_dbarberos]
* **Support**: [Support email or Git issue channel]
```

---

## 2. Style and Formatting Rules

1.  **Technical Tables**: Use Markdown tables to organize data like version compatibilities, client IDs, or command lists.
2.  **Alert Messages**: Employ GitHub-style alert blocks (`> [!WARNING]`, `> [!NOTE]`) to highlight system prerequisites, risks to the Revit model, or irreversible transactions.
3.  **Command Links**: Revit executor classes (`FullClassName`) must always be formatted as inline code `` `Class` ``.
