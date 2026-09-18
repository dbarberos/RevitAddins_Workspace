# Walkthrough: XML Settings Startup Error Resolution and Auto-Upgrade

## Context & Issue
Upon starting Revit after deploying the updated FilterPlus add-in, a modal dialog interrupted application startup:
`"FilterPlus Error: An error occurred in Loading Settings: Error en el documento XML (3, 54). Check Debug Log for details."`

## Root Cause Analysis
1. **`[Obsolete]` Exclusion in `XmlSerializer`**:
   In `FilterPlusSettings.cs`, `DBDevDefault` was flagged with `[Obsolete("Use AddInsDefaultTab instead.")]`. In .NET Framework 4.8, `XmlReflectionImporter` ignores enum members decorated with `[Obsolete]`.
   When deserializing the user's existing `settings.xml` file containing `<SelectedTabOption>DBDevDefault</SelectedTabOption>`, `XmlSerializer` threw an `InvalidOperationException: 'DBDevDefault' is not a valid value for TabOption`.
2. **Blocking Modal Dialog in `SettingsService.Load()`**:
   When deserialization threw an exception, `SettingsService.Load()` called `LoggerService.LogError("Loading Settings", ex)`, which called `MessageBox.Show()`, freezing Revit's startup until dismissed.

## Changes Implemented

### 1. `FilterPlus/Models/FilterPlusSettings.cs`
- Removed `[Obsolete]` from `DBDevDefault` so `XmlSerializer` successfully maps existing user configurations.
- Preserved both `AddInsDefaultTab` and legacy `DBDevDefault` in the enum schema.

### 2. `FilterPlus/Services/SettingsService.cs`
- Refactored `Load()` to decouple file reading from migration writing (preventing file lock conflicts).
- Added automatic migration: when `DBDevDefault` is detected on load, it is upgraded in-memory to `AddInsDefaultTab` and immediately persisted back to `settings.xml`.
- Replaced blocking modal error logging with non-blocking `LoggerService.LogWarning()`. Corrupted or missing settings seamlessly fall back to safe default settings.
- Made `Save()` non-blocking, logging warnings instead of throwing popups.

### 3. `FilterPlus/Services/LoggerService.cs`
- Added `LogWarning(string message)` for resilient diagnostic logging without UI popups.
- Added optional `showDialog = true` parameter to `LogError()` to allow callers to suppress modal dialogs where appropriate.

## Build and Packaging Verification
1. **Local Revit Add-In (Debug)**:
   - Recompiled `Debug.R24` and `Debug.R23` with `/p:DeployAddin=true`.
   - Verified that both `%APPDATA%\Autodesk\Revit\Addins\2024\FilterPlus\FilterPlus.dll` and `2023\FilterPlus\FilterPlus.dll` are deployed with the latest code.
   - Verified in-process via reflection that `SettingsService.Load()` loads the configuration with `SelectedTabOption = AddInsDefaultTab` and automatically upgrades `settings.xml` on disk.
2. **Autodesk App Store Bundle (Release)**:
   - Compiled `Release.R23`, `Release.R24`, `Release.R25`, `Release.R26`, and `Release.R27` (0 Errors).
   - Ran `build-bundle.ps1` to produce:
     - `FilterPlus\Deploy\FilterPlus_v1.0.0.zip`
     - `FilterPlus\FilterPlusPublishPackage\FilterPlus.bundle.zip`
