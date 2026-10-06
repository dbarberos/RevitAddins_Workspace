<#
.SYNOPSIS
    Guards Revit Add-in builds by checking if Revit.exe is actively running and locking deployment assemblies.

.DESCRIPTION
    Checks for running Revit processes before running dotnet build or dotnet publish.
    Emits warnings with PID details and provides an option to prompt or exit before MSBuild fails on locked DLLs.

.PARAMETER ThrowOnError
    If true, exits with non-zero exit code (1) when Revit is running. Default is false (returns boolean).

.EXAMPLE
    pwsh CheckRevitRunningGuard.ps1 -ThrowOnError $true
#>
[CmdletBinding()]
param(
    [switch]$ThrowOnError
)

$revitProcesses = Get-Process -Name "revit" -ErrorAction SilentlyContinue

if ($revitProcesses) {
    $pids = ($revitProcesses | ForEach-Object { "$($_.ProcessName) (PID: $($_.Id))" }) -join ", "
    Write-Host "=====================================================================" -ForegroundColor Yellow
    Write-Host "[WARNING] Autodesk Revit is currently running: $pids" -ForegroundColor Yellow
    Write-Host "[WARNING] DLLs deployed to %AppData%\Autodesk\Revit\Addins\ are locked." -ForegroundColor Yellow
    Write-Host "[WARNING] Close Revit before compiling to ensure new binaries are deployed." -ForegroundColor Yellow
    Write-Host "=====================================================================" -ForegroundColor Yellow

    if ($ThrowOnError) {
        exit 1
    }
    return $false
} else {
    Write-Host "[INFO] No active Revit process detected. Safe to compile and deploy add-in." -ForegroundColor Green
    return $true
}
