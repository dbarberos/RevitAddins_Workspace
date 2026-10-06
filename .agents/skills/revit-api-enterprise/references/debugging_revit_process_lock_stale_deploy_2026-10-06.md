# Debugging: Revit Process File Lock, Deployment Bypass, and Stale Binaries

## Problem Summary
During the development and testing of Revit add-in features (such as adding the 4 table import modes in `TablePlus`), a build was triggered while Autodesk Revit was running in the background. The build reported `Build succeeded`, but upon opening Revit and launching the add-in UI, none of the newly developed features, controls, or converters appeared. Revit loaded an outdated version of the add-in from days prior.

## Root Cause Analysis
1. **Windows Module Lock on Loaded Assemblies**:
   When Autodesk Revit starts and initializes an add-in declared in `%AppData%\Autodesk\Revit\Addins\<Year>\<AddinName>.addin`, the Windows kernel creates an exclusive memory-mapped file lock on `TablePlus.dll`.
2. **Nice3point SDK Auto-Deployment Target (`DeployAddin`)**:
   In `Nice3point.Revit.Sdk`, when `<DeployAddin>true</DeployAddin>` is enabled, the post-compilation MSBuild target copies output binaries to `%AppData%\Autodesk\Revit\Addins\<Year>\<AddinName>\`. If Revit is actively running, MSBuild encounters file access denial:
   ```text
   MSB3026: Could not copy "bin\Debug.R25\TablePlus.dll" to "...\AppData\Roaming\Autodesk\Revit\Addins\2025\TablePlus\TablePlus.dll".
   The file is locked by: "Autodesk Revit"
   ```
3. **The Stale Binary Anti-Pattern (`/p:DeployAddin=false`)**:
   Attempting to bypass the file lock error by compiling with `/p:DeployAddin=false` or using space-separated configuration names (`Debug R25` instead of `Debug.R25`) allows the build to generate new binaries in `bin\Debug.R25\`, but **completely halts updating the deployed folder in AppData**.
   Because Revit's `.addin` manifest points to `%AppData%\Autodesk\Revit\Addins\<Year>\<AddinName>\TablePlus.dll`, Revit silently executes the old, stale assembly, leading developers and agents to waste hours diagnosing phantom UI/binding issues.

## Resolution & Protocol

### 1. Mandatory Pre-Compilation Revit Process Check
Before executing any build intended for testing or deployment, the agent or build pipeline MUST verify whether `Revit.exe` is currently running:
```powershell
$revit = Get-Process -Name "revit" -ErrorAction SilentlyContinue
if ($revit) {
    Write-Warning "Autodesk Revit is running (PID: $($revit.Id)). Binaries in AppData are locked."
}
```

### 2. User Communication Protocol
If Revit is running, the agent **MUST NOT** silently bypass the lock with `/p:DeployAddin=false`. Instead, the agent **MUST** inform the user immediately:
> *"Autodesk Revit is currently running (PID: {id}). Because Revit locks add-in DLLs in `%AppData%\Autodesk\Revit\Addins\<Year>\`, building now will fail to deploy updated binaries. Please save your work and close Revit so the build can deploy cleanly."*

### 3. Strict Configuration Naming Discipline
In Nice3point SDK projects, configurations are declared with dot notation (`Debug.R24`, `Debug.R25`, `Release.R25`). Using spaces (e.g. `Debug R25`) causes MSBuild condition mismatches and fails to route target properties correctly.

### 4. Verification of Deployed Timestamp
After compilation, always verify that the deployed binary timestamp matches the local build timestamp:
```powershell
Get-Item "$env:APPDATA\Autodesk\Revit\Addins\2025\TablePlus\TablePlus.dll" | Select-Object LastWriteTime, Length
```

## Outcome
- Prevents deceptive "green" builds that leave stale binaries in Revit.
- Eliminates false-positive UI/binding bug investigations.
- Ensures 100% synchronization between developer source code and Revit runtime execution.
