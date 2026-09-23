# Walkthrough: TablePlus Ribbon Relocation to Native Add-Ins (Complementos) Tab

This walkthrough documents the ribbon relocation implemented for **TablePlus v1.0.0**, matching Autodesk App Store developer guidelines and mirroring the solution previously applied to **FilterPlus** and **TransferPlus**.

---

## 1. Problem Statement & Background

Autodesk App Store submission requirements specify that single-command plugins or tools from individual publishers must not register a new custom tab in the Revit ribbon unless they group multiple related suites or tools under a registered company branding. Specifically:
> *"The app currently loads under a custom ribbon tab. Please note that custom tabs are generally permitted only when:
> - An app contains multiple commands that need to be grouped together, or
> - A publisher has multiple applications and wants to group them under a single company-branded tab.
> In your case, the app contains only a single command, and the custom tab is named after the application rather than your company. Please move the command to the Add-Ins tab."*

In **TablePlus**, `Application.cs` was previously creating a custom ribbon panel under the `"DBDev Tools"` tab via `Application.CreatePanel("Tables", "DBDev Tools")`. 

---

## 2. Changes Made

### 2.1. C# Ribbon Entry Point (`TablePlus/Application.cs`)
- Modified `CreateRibbon()`:
  - Removed custom tab creation (`"DBDev Tools"`).
  - Configured default placement on the native **Add-Ins** (`Complementos` in Spanish) ribbon tab via `Application.CreatePanel("TablePlus")`.
  - Panel title standardizes to `"TablePlus"`, containing the `"Import\nExcel"` PushButton with custom 16x16 and 32x32 px icons.

```csharp
private void CreateRibbon()
{
    RibbonPanel? panel = null;

    try
    {
        // By default, place panel on Revit's standard Add-Ins (Complementos) tab,
        // complying with Autodesk App Store single-command add-in requirements.
        panel = Application.CreatePanel("TablePlus");
    }
    catch (Exception ex)
    {
        System.Diagnostics.Debug.WriteLine($"TablePlus Ribbon Panel Creation Error: {ex.Message}");
    }

    if (panel != null)
    {
        var button = panel.AddPushButton<CmdImportTable>("Import\nExcel");
        button.SetImage("/TablePlus;component/Resources/Icons/TablePlus16x16.png");
        button.SetLargeImage("/TablePlus;component/Resources/Icons/TablePlus32x32.png");
        button.ToolTip = "TablePlus — Import Excel Spreadsheet";
        button.LongDescription = "Import Excel spreadsheets (.xlsx, .xls, .csv) into native Revit Drafting Views or Legend Views as editable 2D vector tables with cell fills, borders, and text formatting.";
        // ... F1 Contextual Help setup ...
    }
}
```

### 2.2. Documentation & Help Assets Alignment
- **[User_Guide.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TablePlus/docs/User_Guide.md)**:
  - Updated Ribbon Hierarchy and commands guide to specify the standard **Add-Ins / Complementos** tab.
- **[help.html](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TablePlus/Resources/help.html)**:
  - Updated section 4.1 to reflect integration in the standard **Add-Ins / Complementos** tab.
- **[AppDescription.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TablePlus/TablePlusPublishPackage/AppDescription.md)**:
  - Updated Ribbon integration description to indicate the **Add-Ins / Complementos** tab.
- **[Steps.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TablePlus/TablePlusPublishPackage/Steps.md)**:
  - Updated sanity check instructions to verify the **TablePlus** panel in the **Add-Ins / Complementos** ribbon tab.
- **[constitution.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TablePlus/docs/constitution.md)**:
  - Updated Section 4.4 specifying default registration on the native **Add-Ins** tab.

---

## 3. Verification & Build Results

| Verification Step | Target / Command | Result | Details |
|---|---|---|---|
| **Compilation 2024** | `dotnet build TablePlus.csproj -c Release.R24` | **PASSED** | 0 Warnings, 0 Errors (.NET 4.8) |
| **Compilation 2025** | `dotnet build TablePlus.csproj -c Release.R25` | **PASSED** | 0 Warnings, 0 Errors (.NET 8.0) |
| **Compilation 2026** | `dotnet build TablePlus.csproj -c Release.R26` | **PASSED** | 0 Warnings, 0 Errors (.NET 8.0) |
| **Compilation 2027** | `dotnet build TablePlus.csproj -c Release.R27` | **PASSED** | 0 Warnings, 0 Errors (.NET 8.0) |
| **Compilation Debug** | `dotnet build TablePlus.csproj -c Debug.R24` | **PASSED** | 0 Warnings, 0 Errors |
| **App Store Bundle Packaging** | `build-bundle.ps1` targeting 2024–2027 | **PASSED** | Generated `TablePlus_v1.0.0.zip` and `TablePlus.bundle.zip` in `Deploy/` & `TablePlusPublishPackage/` |

---

## 4. Summary

TablePlus now defaults directly to the native **Add-Ins** (`Complementos`) ribbon tab across all supported Revit versions (2024, 2025, 2026, 2027), fully adhering to Autodesk App Store guidelines and establishing behavioral parity with FilterPlus and TransferPlus.
