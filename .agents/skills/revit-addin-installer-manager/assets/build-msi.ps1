# build-msi.ps1
# Automates compiling the WiX installer, renaming the output with the version, and archiving old versions.

param(
    [string]$AppName = "FilterPlus",
    [string]$ProjectDir = "..",
    [string]$WixBinDir = "C:\Program Files (x86)\WiX Toolset v3.14\bin"
)

$ErrorActionPreference = "Stop"

# Paths relative to the script directory
$scriptPath = Split-Path -Parent $MyInvocation.MyCommand.Definition
$resolvedProjectDir = Resolve-Path (Join-Path $scriptPath $ProjectDir)
$resolvedWixBinDir = Resolve-Path $WixBinDir

$InstallerDir = Join-Path $resolvedProjectDir "Installer"
$DeployDir = Join-Path $resolvedProjectDir "Deploy"
$ArchiveDir = Join-Path $DeployDir "Archive"
$DocPath = Join-Path $resolvedProjectDir "docs\User_Guide.md"

# 1. Ensure directories exist
if (-not (Test-Path $DeployDir)) {
    New-Item -ItemType Directory -Path $DeployDir | Out-Null
}
if (-not (Test-Path $ArchiveDir)) {
    New-Item -ItemType Directory -Path $ArchiveDir | Out-Null
}

# 2. Sync version first
$SyncScript = Join-Path $InstallerDir "sync-version.ps1"
if (Test-Path $SyncScript) {
    Write-Host "Synchronizing version using sync-version.ps1..."
    & powershell -ExecutionPolicy Bypass -File $SyncScript
}

# 3. Read version from User_Guide.md
$DocContent = Get-Content -Path $DocPath -Raw
if ($DocContent -match '\*\*Current Version:\*\*\s*v?([0-9.]+)') {
    $Version = $Matches[1]
    Write-Host "Detected Version: $Version"
} else {
    Write-Error "Could not parse version from User_Guide.md"
}

# 4. Archive old MSI files
$OldMsis = Get-ChildItem -Path $DeployDir -Filter "$AppName`_v*.msi"
foreach ($msi in $OldMsis) {
    Write-Host "Archiving old installer: $($msi.Name)"
    Move-Item -Path $msi.FullName -Destination $ArchiveDir -Force
}

# Also check Installer folder for raw/old MSI files and archive them
$OldRawMsis = Get-ChildItem -Path $InstallerDir -Filter "*.msi"
foreach ($msi in $OldRawMsis) {
    Write-Host "Archiving old installer from Installer folder: $($msi.Name)"
    Move-Item -Path $msi.FullName -Destination $ArchiveDir -Force
}

# 5. Compile Product.wxs to Product.wixobj
$WxsFile = Join-Path $InstallerDir "Product.wxs"
$WixObj = Join-Path $InstallerDir "Product.wixobj"
$CandleExe = Join-Path $resolvedWixBinDir "candle.exe"

if (-not (Test-Path $CandleExe)) {
    Write-Error "WiX Toolset candle.exe not found at $CandleExe"
}

Write-Host "Compiling installer source code using candle..."
& "$CandleExe" -out "$WixObj" "$WxsFile"

# 6. Link Product.wixobj to output MSI
$LightExe = Join-Path $resolvedWixBinDir "light.exe"
$OutputMsiName = "$AppName`_v$Version.msi"
$OutputMsiPath = Join-Path $DeployDir $OutputMsiName

Write-Host "Linking object files to generate $OutputMsiName using light..."
& "$LightExe" "$WixObj" -ext WixUIExtension -out "$OutputMsiPath"

# 7. Cleanup temp files
if (Test-Path $WixObj) { Remove-Item $WixObj -Force }
$WixPdb = Join-Path $InstallerDir "Product.wixpdb"
if (Test-Path $WixPdb) { Remove-Item $WixPdb -Force }
$LocalWixPdb = Join-Path $InstallerDir "$AppName.wixpdb"
if (Test-Path $LocalWixPdb) { Remove-Item $LocalWixPdb -Force }

Write-Host "MSI Installer generated at: $OutputMsiPath"
Write-Host "Done!"
