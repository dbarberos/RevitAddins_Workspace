# Golden Rules for a Robust WXS in Windows Installer Environments

This document details the mandatory technical directives when structuring installers with **WiX Toolset v3.11+**, specifically designed to avoid Windows Installer validation errors (ICE) and ensure clean uninstallations in user `AppData` directories.

---

## 1. Management of IDs and Unique Symbols
*   **Rule**: Never allow WiX to assign automatic identifiers to files in multi-version installers.
*   **Execution**: Each packaged file must have an explicit and unique `Id` that includes the suffix of its Revit version (e.g., `Id="F_Dll24"`, `Id="F_Dll25"`). 
*   **Reason**: Avoids the WiX compilation error *"Duplicate symbol 'File:YourAddin.dll' found"* when compiling multiple DLLs with the same physical name but located in different version subfolders.

---

## 2. Static vs Automatic GUIDs
*   **Rule**: Always use explicit and fixed GUIDs in each `<Component>` (`Guid="NEW_GUID_HERE-..."`). Avoid using the automatic generation asterisk (`Guid="*"`).
*   **Reason**: The WiX automatic wildcard fails when compiling complex components that group multiple files or registry keys. A static GUID guarantees the stability of the component ID in the Windows registry and avoids problems in future updates (*MajorUpgrade*).

---

## 3. Windows Security Validation (ICE Rules)

When installing files in `AppDataFolder` (per-user installation, without elevated administrator privileges):

### A. ICE38 (Registry KeyPath in HKCU)
*   **Rule**: Each component that installs files in the user's Revit folder **must** have a `RegistryValue` in `HKCU` defined as its main KeyPath (`KeyPath="yes"`). Do not use the `.dll` or `.addin` file directly as KeyPath.
*   **Example**:
    ```xml
    <Component Id="C_Dll24" Guid="[STATIC-GUID]" Directory="REVIT2024">
      <RegistryValue Root="HKCU" Key="Software\DBDev_dbarberos\FilterPlus\2024" Name="installed" Type="integer" Value="1" KeyPath="yes" />
      <File Id="F_Dll24" Name="FilterPlus.dll" Source="bin\Release.R24\FilterPlus\FilterPlus.dll" />
    </Component>
    ```

### B. ICE64 (Folder Removal on Uninstallation)
*   **Rule**: Each directory in the user installation hierarchy (`Autodesk`, `Revit`, `Addins`, `2024`, etc.) must include a removal instruction `<RemoveFolder Id="..." On="uninstall"/>` linked to an installer component.
*   **Reason**: Guarantees that the Windows uninstaller cleans up the add-in folders if they are left empty, avoiding security warnings and orphaned directories.

### C. Centralized Cleanup Component
*   **Recommended Strategy**: Define a `ComponentGroup` named `CleanupComponents` that exclusively groups the `<RemoveFolder>` removal instructions of the common upper Revit directories, preventing ICE64 validation warnings in the version components.
