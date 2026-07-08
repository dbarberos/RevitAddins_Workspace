<#
.SYNOPSIS
    PowerShell script to extract and pack Revit DLLs into a custom NuGet package.
.DESCRIPTION
    This script automates copying Revit core DLLs (RevitAPI.dll, RevitAPIUI.dll, AdWindows.dll) 
    from a specified Revit folder, staging them in lib/net48 or lib/net8.0 folders, 
    and packing them using nuget.exe.
.PARAMETER RevitInstallPath
    Absolute path to Autodesk Revit installation folder (e.g. "C:\Program Files\Autodesk\Revit 2024").
.PARAMETER TargetFramework
    The .NET target framework ("net48" or "net8.0").
.PARAMETER PackageVersion
    Target version of the NuGet package (e.g. "2024.2.0").
.PARAMETER OutputDir
    Directory where the compiled NuGet package (.nupkg) will be saved.
.EXAMPLE
    .\pack_revit_api.ps1 -RevitInstallPath "C:\Program Files\Autodesk\Revit 2024" -TargetFramework "net48" -PackageVersion "2024.2.0" -OutputDir "..\ThirdParty\Packages"
#>
param(
    [Parameter(Mandatory=$true)]
    [string]$RevitInstallPath,

    [Parameter(Mandatory=$true)]
    [ValidateSet("net48", "net8.0")]
    [string]$TargetFramework,

    [Parameter(Mandatory=$true)]
    [string]$PackageVersion,

    [Parameter(Mandatory=$true)]
    [string]$OutputDir
)

# 1. Validate Revit Path
if (-not (Test-Path $RevitInstallPath)) {
    Write-Error "Revit installation directory not found at: $RevitInstallPath"
    exit 1
}

# 2. Setup Staging Directory
$StagingDir = Join-Path $PSScriptRoot "TempStaging"
$LibDir = Join-Path $StagingDir "lib\$TargetFramework"
if (Test-Path $StagingDir) { Remove-Item $StagingDir -Recurse -Force }
$null = New-Item -ItemType Directory -Path $LibDir -Force

# 3. Copy official DLLs
$DllNames = @("RevitAPI.dll", "RevitAPIUI.dll", "AdWindows.dll")
foreach ($DllName in $DllNames) {
    $SrcFile = Join-Path $RevitInstallPath $DllName
    if (-not (Test-Path $SrcFile)) {
        Write-Warning "Optional DLL $DllName not found in Revit directory. Skipping..."
        continue
    }
    Copy-Item $SrcFile -Destination $LibDir -Force
    Write-Host "Copied $DllName to stage."
}

# 4. Stage nuspec
$NuspecTemplatePath = Join-Path $PSScriptRoot "..\assets\RevitAPI.nuspec"
$TargetNuspecPath = Join-Path $StagingDir "RevitAPI.nuspec"

if (-not (Test-Path $NuspecTemplatePath)) {
    Write-Error "nuspec template not found in assets."
    exit 1
}

# Copy and modify version in nuspec dynamically
$NuspecContent = Get-Content $NuspecTemplatePath -Raw
$NuspecContent = $NuspecContent -replace '<version>.*?</version>', "<version>$PackageVersion</version>"
Set-Content -Path $TargetNuspecPath -Value $NuspecContent -Force

# 5. Fetch nuget.exe if not present in path
$NugetPath = "nuget"
$NugetTest = Get-Command nuget -ErrorAction SilentlyContinue
if (-not $NugetTest) {
    Write-Host "nuget.exe not found in PATH. Downloading temporary nuget.exe..."
    $NugetExePath = Join-Path $StagingDir "nuget.exe"
    Invoke-WebRequest -Uri "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe" -OutFile $NugetExePath -UseBasicParsing
    $NugetPath = $NugetExePath
}

# 6. Run nuget pack
$null = New-Item -ItemType Directory -Path $OutputDir -Force
$AbsoluteOutputDir = (Resolve-Path $OutputDir).Path

Write-Host "Packing Revit API NuGet package (Version: $PackageVersion)..."
Push-Location $StagingDir
try {
    & $NugetPath pack "RevitAPI.nuspec" -OutputDirectory $AbsoluteOutputDir -Properties Configuration=Release
    Write-Host "Package compiled successfully in: $AbsoluteOutputDir"
}
catch {
    Write-Error "Failed to compile package: $_"
}
finally {
    Pop-Location
    # Clean staging directory
    Remove-Item $StagingDir -Recurse -Force
}
