# Walkthrough: TablePlus Custom Icons Integration

**Date:** 2026-09-23  
**Status:** COMPLETED  
**Skill:** `revit-addin-icon-manager` (v2.0)  

---

## 1. Objective

Integrate the official custom icon set for **TablePlus** across all resolutions (16x16, 32x32, 120x120), ensuring they appear:
1. On the Revit Ribbon (`Application.cs`).
2. On all WPF Windows (`TableImportView.xaml` and `TableImportView.xaml.cs`) via absolute pack URIs to prevent external host (`Revit.exe`) icon fallbacks.
3. In the compiled assembly resources (`TablePlus.csproj`).
4. In the Autodesk App Store bundle (`TablePlus.bundle`).

---

## 2. Changes Applied

### A. Resource File Organization (`TablePlus/Resources/Icons/`)
- Mapped source icons to canonical naming:
  - `TablePlus16x16.png` (16x16 px)
  - `TablePlus32x32.png` (32x32 px)
  - `TablePlus120x120.png` (120x120 px)
  - `RibbonIcon16.png` (16x16 px)
  - `RibbonIcon32.png` (32x32 px)
- Updated root icons:
  - `TablePlus/Resources/Icon16.png`
  - `TablePlus/Resources/Icon32.png`

### B. Project Configuration (`TablePlus/TablePlus.csproj`)
- Declared all icon variations as WPF `<Resource Include="..." />` elements in `.csproj`:
  ```xml
  <ItemGroup>
      <Resource Include="Resources\Icons\TablePlus16x16.png"/>
      <Resource Include="Resources\Icons\TablePlus32x32.png"/>
      <Resource Include="Resources\Icons\TablePlus120x120.png"/>
      <Resource Include="Resources\Icons\RibbonIcon16.png"/>
      <Resource Include="Resources\Icons\RibbonIcon32.png"/>
      <Content Include="Resources\**\*" Exclude="Resources\**\*.xaml">
          <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
      </Content>
  </ItemGroup>
  ```

### C. Ribbon Registration (`TablePlus/Application.cs`)
- Set explicit pack URIs for the ribbon PushButton:
  ```csharp
  button.SetImage("/TablePlus;component/Resources/Icons/TablePlus16x16.png");
  button.SetLargeImage("/TablePlus;component/Resources/Icons/TablePlus32x32.png");
  ```
- Wired contextual F1 help directly to `Resources/help.html`.

### D. WPF Window Icon (`TableImportView.xaml` & `TableImportView.xaml.cs`)
- In `TableImportView.xaml`:
  ```xml
  Icon="pack://application:,,,/TablePlus;component/Resources/Icons/TablePlus32x32.png"
  ```
- In `TableImportView.xaml.cs` (Programmatic fallback preventing `Revit.exe` icon fallback):
  ```csharp
  try
  {
      Icon = new System.Windows.Media.Imaging.BitmapImage(
          new Uri("pack://application:,,,/TablePlus;component/Resources/Icons/TablePlus32x32.png", UriKind.Absolute));
  }
  catch
  {
      // Silently continue with XAML declaration
  }
  ```

### E. App Store Bundle Re-Packaging
- Re-executed `build-bundle.ps1` targeting Revit 2024, 2025, 2026, and 2027.
- Verified that all version folders in `TablePlus.bundle` contain the updated icons in `Contents/Resources/` and `Contents/[Year]/Resources/`.

---

## 3. Verification

| Check | Target | Result |
|---|---|---|
| **Compilation R24** (.NET 4.8) | `Release.R24` | **PASSED** (0 errors, 0 warnings) |
| **Compilation R25** (.NET 8.0) | `Release.R25` | **PASSED** (0 errors, 0 warnings) |
| **Compilation R26** (.NET 8.0) | `Release.R26` | **PASSED** (0 errors, 0 warnings) |
| **Compilation R27** (.NET 9.0) | `Release.R27` | **PASSED** (0 errors, 0 warnings) |
| **Ribbon Icon Resolution** | `Application.cs` | **PASSED** (Pack URIs verified) |
| **WPF Window Icon** | `TableImportView` | **PASSED** (XAML + Code-Behind) |
| **Bundle Staging** | `Deploy/` & `TablePlusPublishPackage/` | **PASSED** (12.7 MB archives generated) |
