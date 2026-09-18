# Code Inspection Procedure and Documentation Scenarios

This document details the phases for extracting technical information directly from the source code and the agent's action procedures based on the state of the documentation in the project.

---

## 1. Automatic Inspection Phase (Truth Extraction)

Before making changes or interacting with the user, the agent must inspect the repository to collect the following objective metadata:

### A. Project Version (Monorepo Scoped):
1.  In a monorepo workspace, search for the latest git tag scoped to the target add-in:
    `git describe --tags --match "$AppName-v*" --abbrev=0`
    If not found, search legacy un-prefixed tags (`v*`).
2.  Inspect the target add-in's `.csproj` file (`$AppName/$AppName.csproj`) to extract the canonical `<Version>` XML tag.
3.  If neither exists, check `Properties/AssemblyInfo.cs` for `[assembly: AssemblyVersion("...")]`.

### B. Add-in Identity:
1.  Parse the `.addin` manifest (Revit Manifest) to retrieve the `AddInId` (GUID), `FullClassName`, and the `Text` displayed in the Revit GUI.

### C. Feature Detection:
1.  Search and analyze all classes that implement the `IExternalCommand` interface to identify available commands and deduce their actions from names and code comments.

### D. Artifact and History Review (Deep Context):
1.  Proactively locate and read the artifact `.md` files (walkthroughs, implementation plans, design guides) located in `docs/references/` or in the relevant global skills folders.
2.  Use these artifacts to extract how the add-in's options and features actually work, how they are used step-by-step, and how they have evolved from their origin to the current update. This step is mandatory to correctly document the functional changes of each version based on the previous state.

---

## 2. Scenario-Based Workflow

### Scenario A: If the Documentation Folder `/docs` does NOT exist
1.  **Creation**: Create a folder named `/docs` at the root of the project.
2.  **Base Generation**: Create the `User_Guide.md` file according to the established standard. The generated content **MUST BE ENTIRELY IN ENGLISH**.
3.  **Initial Content**: Automatically populate the document using the technical information extracted in the **Automatic Inspection Phase** and the **Artifact Review**. Make sure to explain how to use the different options and features based on the read artifacts.

### Scenario B: If the `User_Guide.md` document ALREADY exists
1.  **Version Comparison**: Compare the extracted version from Git or the code with the latest documented version in the file's history.
2.  **Holistic and Silent Update**:
    *   All new or updated content **MUST BE IN ENGLISH**.
    *   If the code version is higher, update the file header.
    *   **Main Guide Update**: Review and rewrite the usage guide for the options and functionalities to reflect the current behavior. Use the `.md` artifacts to understand what has changed since the previous version and ensure all guide points are synchronized from the origin to the latest update.
    *   **Changelog Generation**: Read the commits strictly isolated to the add-in's directory (`git log [last_tag]..HEAD --oneline -- [AppName]/`), extract details from the artifacts to group the changes made under the **Added**, **Changed**, or **Fixed** sections. Record a new entry in the version history. **CRITICAL: Do NOT delete or overwrite previous version entries in the Changelog. Append new version blocks at the top of the version history to preserve a full historical record of all changes.**
    *   **Git Tagging**: Tag the release using the scoped format: `git tag -a [AppName]-v[SemVer] -m "Release [AppName] v[SemVer]: ..."`
    *   If new command classes without documentation are detected, add them to the guide section with the tag `[PENDING: Functional Description]`.

---

## 3. Interruption Criteria (Minimal Intervention)

The agent must work 100% autonomously and silently. It will only request developer assistance in these three extreme cases:
1.  No `.csproj` file or `.addin` manifest is detected in the workspace.
2.  A new command class is detected, but there are not enough clues or comments in the code to deduce its functionality.
3.  Critical support or developer contact information is completely missing from the entire project.
