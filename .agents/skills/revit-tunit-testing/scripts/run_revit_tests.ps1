<#
.SYNOPSIS
    Automated execution runner for Nice3point.TUnit.Revit test projects.

.PARAMETER ProjectPath
    Path to the test .csproj file.

.PARAMETER RevitVersion
    Target Revit release: R24, R25, R26, or R27 (default: R26).

.PARAMETER Configuration
    Build configuration: Release or Debug (default: Release).

.EXAMPLE
    .\run_revit_tests.ps1 -ProjectPath "TransferPlus.Tests\TransferPlus.Tests.csproj" -RevitVersion "R26"
#>

[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [string]$ProjectPath,

    [Parameter(Mandatory = $false)]
    [ValidateSet("R24", "R25", "R26", "R27")]
    [string]$RevitVersion = "R26",

    [Parameter(Mandatory = $false)]
    [ValidateSet("Release", "Debug")]
    [string]$Configuration = "Release"
)

$targetConfig = "$Configuration.$RevitVersion"
Write-Host "==========================================================" -ForegroundColor Cyan
Write-Host "  Launching Revit In-Process Tests (Nice3point.TUnit.Revit)" -ForegroundColor Cyan
Write-Host "  Target Configuration: $targetConfig" -ForegroundColor Yellow
Write-Host "  Test Project:        $ProjectPath" -ForegroundColor Yellow
Write-Host "==========================================================" -ForegroundColor Cyan

if (-not (Test-Path $ProjectPath)) {
    Write-Error "Test project not found at path: $ProjectPath"
    exit 1
}

# Execute using dotnet run (Microsoft.Testing.Platform runner)
$command = "dotnet run --project `"$ProjectPath`" -c `"$targetConfig`""
Write-Host "Executing: $command" -ForegroundColor Gray

Invoke-Expression $command
$exitCode = $LASTEXITCODE

if ($exitCode -eq 0) {
    Write-Host "`n✅ All in-process Revit tests passed successfully ($targetConfig)!" -ForegroundColor Green
} else {
    Write-Host "`n❌ In-process Revit tests failed with exit code $exitCode ($targetConfig)." -ForegroundColor Red
}

exit $exitCode
