---
name: revit-addin-installer-manager
description: Automates the creation of professional MSI installers for multi-version Revit Add-ins (2023-2027) using WiX Toolset v3.11+. Use this when preparing a deployment package, updating installer versions, or generating WXS scripts.
---

# Skill: Revit Add-in Installer Manager (WiX Toolset Automation)

**Version:** 1.1

---

## 🟢 1. Initial Configuration Phase (User Input and Git)
When activating this skill, the Agent must collect:
1.  **Add-in Version (Git):** Run `git describe --tags --abbrev=0` to get the latest version.
    *   **Proactive Action:** If the tag exists (e.g., `v1.0.0`), the Agent must automatically update the `<Version>` tag in the project's `.csproj` file.
2.  **Target Revit Versions:** (e.g., 2023, 2024, 2025, 2026, 2027).
3.  **Commercial Name:** Add-in name for the Control Panel.
4.  **Manufacturer:** Name of the developer or company (defaults to `"DBDev_dbarberos"`).
5.  **Desired UI:** Minimal (`WixUI_Minimal`) or with path selection (`WixUI_InstallDir`)?

---

## 🛠 2. Automatic Execution Logic

### Step A: Multi-Configuration Structure Scanning
The Agent will map the project's output folders (based on the Nice3point pattern):
- Look for `bin/Release.R24/FilterPlus/`, `bin/Release.R25/FilterPlus/`, etc.
- Verify the existence of the `.addin` manifest in the project root.

### Step B: `Product.wxs` Generation (Core Logic)
The Agent will write the file with the following technical structure:

1.  **Namespaces**: Include `xmlns="http://schemas.microsoft.com/wix/2006/wi"`.
2.  **UI Variables**:
    - `<UIRef Id="WixUI_Minimal" />` or `<UIRef Id="WixUI_InstallDir" />`.
    - `<WixVariable Id="WixUILicenseRtf" Value="Resources\License.rtf" />`.
3.  **Directory Hierarchy**:
    ```xml
    <Directory Id="TARGETDIR" Name="SourceDir">
      <Directory Id="AppDataFolder">
        <Directory Id="Autodesk" Name="Autodesk">
          <Directory Id="Revit" Name="Revit">
            <Directory Id="Addins" Name="Addins">
              <Directory Id="REVIT2024" Name="2024" />
              <Directory Id="REVIT2025" Name="2025" />
              <!-- Repeat according to versions -->
            </Directory>
          </Directory>
        </Directory>
      </Directory>
    </Directory>
    ```

### Step C: Component Definition by Version
The Agent will generate a `ComponentGroup` for each Revit version, linking the specific `.addin` and the corresponding binaries folder.

---

## 🛡 3. Golden Rules for a Robust WXS (Anti-Errors)
To avoid common compilation errors in WiX (ICE64, ICE38, Duplicate Symbols), the Agent must follow these strict rules when generating the code:

### A. Unique IDs and Symbols Management
*   **Never** let WiX assign automatic IDs to files in multi-version installers.
*   **Rule**: Each file must have a unique `Id` that includes the version (e.g., `Id="F_Dll24"`, `Id="F_Dll25"`). This prevents the error *"Duplicate symbol 'File:Name.dll' found"*.

### B. Static vs Automatic GUIDs
*   **Rule**: Always use **fixed and static GUIDs** for components (`Guid="XXXX-..."`). 
*   **Why**: Using `Guid="*"` (automatic) fails if the component contains more than one element (e.g., a File + a Registry Key). Being complex multi-version installations, the fixed GUID guarantees stability.

### C. Windows Security Validation (ICE)
For installations in `AppData` (Per-User):
1.  **ICE38 (Registry KeyPath)**: Each component **must** have a `RegistryValue` in `HKCU` as `KeyPath="yes"`. Do not use the file as KeyPath.
2.  **ICE64 (Folder Cleanup)**: Each level of the directory hierarchy (`Autodesk`, `Revit`, `Addins`, `2024`, etc.) must have a `<RemoveFolder Id="..." On="uninstall"/>` instruction linked to a component.
3.  **Cleanup Component**: It is recommended to create a `ComponentGroup` named `CleanupComponents` that exclusively handles the `RemoveFolder` instructions of the upper folders.

---

## 🤖 4. Behavioral Instructions for the Agent
- **Automatic Reference**: The Agent must instruct the user to add the reference to `WixUIExtension.dll` in Visual Studio if the project is detected as new.
- **UpgradeCode**: Must be persistent to allow updates (`MajorUpgrade`).
- **Path Validation**: Always verify that the relative paths (e.g., `..\..\..\`) match the depth of the installer folder with respect to the binaries.
- **Component Structure**: Every important file (DLL, .addin) must go in its own `<Component>`.

---

## 📋 5. Agent Workflow
1.  **Version:** Get Git tag and synchronize with `.csproj`.
2.  **Preparation:** Create `Installer/` folder and `Resources/` subfolder inside the project.
3.  **Resources:** Generate basic `License.rtf`.
4.  **Writing:** Generate the complete `Product.wxs` file applying the **Golden Rules** from Section 3, ensuring that `Product/@Version` matches the Git version.
5.  **Completion:** Provide the commands to compile via console or guide in the use of the Visual Studio interface.