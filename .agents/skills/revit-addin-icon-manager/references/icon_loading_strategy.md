# Revit Icon Loading and Integration Strategy

This document describes the technical specifications for integrating custom images into the ribbon panels of Autodesk Revit, covering theme compatibility and WPF resource compilation configurations.

---

## 1. Active Diagnosis Phase

The agent must automatically determine the following before modifying any file:
1.  **Project Path**: Search for the `IExternalApplication` class (e.g. `App.cs` or `Application.cs`) and the `.csproj` file.
2.  **Revit Version**: Extract the target version to correctly apply Dark Theme support (available starting from Revit 2024+).
3.  **Icon Sources**: Detect existing `/Icons` or `/Resources` folders in the project.
4.  **Existing Buttons**: Inspect the application's Ribbon configuration to list the buttons that require icons.

---

## 2. Technical Execution Procedure

### Step A: Image File Management and Organization
*   **Standard Path**: Copy the images into the `Resources/Icons/` subfolder of the project.
*   **Resolution Mapping**:
    *   **32x32 px** image (or named with "32") -> Assigned to the `LargeImage` property of the button.
    *   **16x16 px** image (or named with "16") -> Assigned to the `Image` property of the button.
*   **Substitution**: It is preferable to keep the template name (e.g., `RibbonIcon32.png`) to minimize modifications in the initialization code, unless the developer requests custom names.

### Step B: Project Modification (.csproj)
Revit icons **must** be compiled as a **Resource** so they are available in the assembly via WPF's `pack://application` scheme:

```xml
<ItemGroup>
  <Resource Include="Resources\Icons\YourIcon32.png" />
  <Resource Include="Resources\Icons\YourIcon16.png" />
</ItemGroup>
```

---

## 3. Screen and Theme Considerations (DPI and Dark Theme)

*   **Dark Theme (Revit 2024+)**: If the add-in supports Revit 2024+, it is recommended to use vector formats (.svg or high-resolution icons with transparent backgrounds) to avoid gray or white backgrounds that break the dark theme aesthetics in the Revit interface.
*   **Use of pack://application**: This resource URI is vital in Revit add-ins, as it ensures that WPF can load the image directly from the application's assembly memory, avoiding dependencies on absolute physical paths that would fail when installing the add-in on client computers.
