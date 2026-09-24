# Debugging Report: Autodesk App Store Custom Tab Rejection & Stale Binaries Packaging

**Date:** 2026-09-24  
**Severity:** Critical (Store Submission Rejection)  
**Target Add-in:** FilterPlus (and all multi-version App Store bundles)  
**Related Skills:** `revit-appstore-bundle`, `apply-skillopt`

---

## 1. Symptom

During review on Autodesk App Store for submission across Revit 2023–2027, the Autodesk reviewer rejected the application with the following finding and screenshots:
> *"1. Application Still Loading Under Custom Tab in Autodesk Revit 2025 and 2026.*  
> *During the latest testing in Autodesk Revit 2025 and 2026, I observed that the application is still loading under a custom ribbon tab [DBDev].*  
> *As previously requested, please update the application so that the command loads under the appropriate Add-Ins tab instead of creating a separate custom tab.*  
> *Please resolve this issue in Autodesk Revit 2025 and 2026 before resubmitting the application."*

In Revit 2023 and 2024, the add-in loaded properly under Add-Ins, but in Revit 2025 and 2026 it spawned a custom tab named `DBDev`.

---

## 2. Root Cause Analysis

Binary inspection using string extraction revealed:
- `Contents/2023/FilterPlus.dll`: `IsDBDevSelected` = `False` (Updated code).
- `Contents/2024/FilterPlus.dll`: `IsDBDevSelected` = `False` (Updated code).
- `Contents/2025/FilterPlus.dll`: `IsDBDevSelected` = `True` (**Stale binary from May 10, 2026**).
- `Contents/2026/FilterPlus.dll`: `IsDBDevSelected` = `True` (**Stale binary from May 10, 2026**).
- `Contents/2027/FilterPlus.dll`: `IsDBDevSelected` = `False` (Updated code).

### Why were stale binaries packed into the bundle?
1. **Packaging Script Flaw (`build-bundle.ps1`)**:
   `build-bundle.ps1` previously searched for existing candidate folders (`bin/Release.R25/publish`, `bin/Release.R26/publish`). Because those folders already existed on disk from an earlier build months ago, the script skipped compilation and directly copied the May 2026 DLLs into `Contents/2025/` and `Contents/2026/`.
2. **Revit App Store Invariant**:
   Autodesk App Store strictly prohibits single-command add-ins from creating custom ribbon tabs (such as `DBDev`). They must load under Revit's native **Add-Ins (Complementos)** tab by default.

---

## 3. Resolution & Permanent Safeguards

### Safeguard A: Mandatory Default Ribbon Location on Add-Ins Tab
In `Application.cs`, the default panel creation must call `CreatePanel` without custom tab parameters:
```csharp
// Native Add-Ins tab (Complementos):
panel = Application.CreatePanel("FilterPlus");
```
If custom tabs are supported as optional user preferences, always verify tab existence or handle exceptions safely without impacting the default:
```csharp
if (!tabName.Equals("Modify", StringComparison.OrdinalIgnoreCase) &&
    !tabName.Equals("Add-Ins", StringComparison.OrdinalIgnoreCase) &&
    !tabName.Equals("AddIns", StringComparison.OrdinalIgnoreCase) &&
    !tabName.Equals("Manage", StringComparison.OrdinalIgnoreCase))
{
    try { Application.CreateRibbonTab(tabName); } catch { /* Tab already exists */ }
}
panel = Application.CreatePanel(appName, tabName);
```

### Safeguard B: Forced Clean Recompilation in `build-bundle.ps1` (`-Rebuild`)
`build-bundle.ps1` was updated with a mandatory `-Rebuild` flag (enabled by default) that cleans intermediate configuration folders and recompiles every single target year with `/p:DeployAddin=false`:
```powershell
if ($Rebuild) {
    Write-Host "Compiling fresh $ConfigName for Revit $Year..." -ForegroundColor Cyan
    $ConfigBinDir = Join-Path $BinDir $ConfigName
    if (Test-Path $ConfigBinDir) { Remove-Item -Path $ConfigBinDir -Recurse -Force -ErrorAction SilentlyContinue }
    dotnet publish $Csproj -c $ConfigName /p:DeployAddin=false --verbosity minimal
}
```
Using `/p:DeployAddin=false` also prevents MSBuild file-lock errors (`MSB3021` / `MSB3027`) when an active Revit session has add-in DLLs locked in `%AppData%`.

---

## 4. Verification

After running the updated `build-bundle.ps1 -Rebuild`:
- All 5 version DLLs (`2023`, `2024`, `2025`, `2026`, `2027`) showed `IsDBDevSelected: False`.
- All DLL timestamps matched the exact execution time.
- `FilterPlus.bundle.zip` contains 100% fresh binaries placing the ribbon panel on the native **Add-Ins** tab.
