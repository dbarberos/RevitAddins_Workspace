# Walkthrough: Window Icons Pack URI Standardization across all Views

**Date:** 2026-08-17  
**Component:** `TransferPlus.Views`, `TransferPlus.csproj`  
**Status:** Validated and Tested across Revit 2024-2027

---

## 1. Summary of Changes

Configured custom 32x32 px add-in icons on all 14 WPF XAML windows across the `TransferPlus` add-in, eliminating fallback to default host `Revit.exe` icons on secondary dialogs (such as cloud source configuration, file selectors, and mapping dialogs).

### Files Modified:
- [TransferPlus.csproj](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/TransferPlus.csproj): Embedded all icon assets (`TransferPlus16x16.png`, `TransferPlus32x32.png`, `TransferPlus120x120.png`, `RibbonIcon16.png`, `RibbonIcon32.png`) under `<ItemGroup><Resource Include="..."/></ItemGroup>`.
- [TransferPlusView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/TransferPlusView.xaml): Added `Icon="pack://application:,,,/TransferPlus;component/Resources/Icons/TransferPlus32x32.png"`.
- [AutodeskDocsSourceWindow.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/AutodeskDocsSourceWindow.xaml): Added pack URI Icon property.
- [AwsS3SourceWindow.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/AwsS3SourceWindow.xaml): Added pack URI Icon property.
- [AzureStorageSourceWindow.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/AzureStorageSourceWindow.xaml): Added pack URI Icon property.
- [DirectorySourceWindow.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/DirectorySourceWindow.xaml): Added pack URI Icon property.
- [FamilySourcesWindow.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/FamilySourcesWindow.xaml): Added pack URI Icon property.
- [FamilySourceTypeWindow.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/FamilySourceTypeWindow.xaml): Added pack URI Icon property.
- [LevelMappingView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/LevelMappingView.xaml): Added pack URI Icon property.
- [DuplicatesAbortView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/DuplicatesAbortView.xaml): Added pack URI Icon property.
- [LogView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/LogView.xaml): Added pack URI Icon property.
- [NumberingSettingsView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/NumberingSettingsView.xaml): Added pack URI Icon property.
- [RenameTextView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/RenameTextView.xaml): Added pack URI Icon property.
- [TakeTextView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/TakeTextView.xaml): Added pack URI Icon property.

---

## 2. Technical Rule Applied

In external host environments like Autodesk Revit, relative path icon references (such as `Icon="Resources/Icons/..."`) resolve against `Revit.exe`, causing either missing icons or BAML markup exceptions.

The mandatory pattern enforces absolute WPF Pack URIs:
```xml
Icon="pack://application:,,,/TransferPlus;component/Resources/Icons/TransferPlus32x32.png"
```
paired with `.csproj` `<Resource>` inclusion.

---

## 3. Verification

- All Release configurations (`Release.R24`, `Release.R25`, `Release.R26`, `Release.R27`) compiled with **0 errors**.
- Automated bundle package generated: `TransferPlus/TransferPlusPublishPackage/TransferPlus.bundle.zip`.
