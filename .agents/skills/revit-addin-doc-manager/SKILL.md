---
name: revit-addin-doc-manager
description: Autonomous management of documentation and versioning for Revit Add-ins through technical file inspection. Use this when generating a user guide, creating a changelog, or updating project documentation based on git tags and source code.
---

# Revit Add-in Documentation Skill (Autonomous Version)

## Objective
This skill allows the agent to manage the lifecycle of the Add-in documentation with minimal human intervention. The agent must act as a technical documenter that extracts the truth directly from the code and project configuration files.

## 1. Automatic Inspection Phase (Data Extraction)
Before performing any action or asking the user, the agent MUST try to extract the following data:

* **Project Version:** 
    1. Run `git describe --tags --abbrev=0` to get the official version.
    2. If it fails, look in `Properties/AssemblyInfo.cs` for the `[assembly: AssemblyVersion("...")]` attribute.
    3. If it doesn't exist, look in the `.csproj` file for the `<Version>` or `<AssemblyVersion>` tag.
* **Add-in Identity:** 1. Read the `.addin` file (Revit Manifest) to get the `AddInId`, `FullClassName`, and `Text`.
* **Feature Detection:** 1. Analyze classes inheriting from `IExternalCommand` to identify new commands.

## 2. Operation Instructions

### Scenario A: If the documentation folder does not exist
1.  **Creation:** Create a folder named `/docs` in the project root.
2.  **Base Generation:** Create the `User_Guide.md` file following Autodesk's technical structure (Reference: AppID 4005291581487532621).
3.  **Initial Content:** Automatically fill it with the data extracted in Phase 1.

### Scenario B: If the document already exists
1.  **Version Comparison:** Compare the version extracted from the code with the latest version recorded in the guide.
2.  **Silent Update:** 
    * If the code version is higher, update the guide's header.
    * **Changelog Generation:** Run `git log [last_tag]..HEAD --oneline` to extract the changes made since the last version.
    * Add a new entry in the `# Changelog` section with the current date, the new version, and the commit summary (categorized as Added, Changed, or Fixed).
    * If new command classes are detected, add "Usage" sections for those commands with the placeholder `[PENDING: Functional description]`.

## 3. User Interaction (Minimal Required)
The agent will only interrupt the user if:
1.  No `.csproj` or `.addin` file is found in the directory.
2.  The agent detects a new feature but cannot deduce its purpose through the class name or code comments.
3.  Contact or support information is missing and not found in the code.

## 4. Required Document Structure (`User_Guide.md`)
The generated document must strictly follow this order:

1.  **Add-in Title:** (Extracted from the .addin file).
2.  **Current Version:** (Extracted from AssemblyInfo or .csproj).
3.  **General Description:** Purpose of the Add-in.
4.  **Installation Instructions:** Based on the location of the `.bundle` or `.msi` files.
5.  **Command Guide:**
    * List of buttons on the Revit Ribbon.
    * Technical explanation of each command (`FullClassName`).
6.  **Version History (Changelog):**
    * `## [Version X.X.X] - YYYY-MM-DD`
    * Automatic list of: **Added**, **Changed**, or **Fixed**.

## 5. Formatting Rules
* Use professional Markdown.
* Use tables for technical data (Client ID, Supported Revit Versions).
* Use warning blocks for system requirements (e.g. "Requires Revit 2021 or higher").