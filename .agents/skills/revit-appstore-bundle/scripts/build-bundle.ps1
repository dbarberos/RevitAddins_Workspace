param(
    [string]$AppName = "FilterPlus",
    [string]$Version = "",
    [string]$Author = "DBDev_dbarberos",
    [string]$Email = "dbarberos@outlook.com",
    [string[]]$TargetYears = @("2023", "2024", "2025", "2026", "2027"),
    [string]$ProjectDir = "."
)

$ErrorActionPreference = "Stop"

# Paths
$resolvedProjectDir = (Resolve-Path $ProjectDir).Path

# Dynamically resolve Version from .csproj if not provided
if ([string]::IsNullOrWhiteSpace($Version) -or $Version -eq "1.0.0") {
    $CsprojPath = Join-Path $resolvedProjectDir "$AppName.csproj"
    if (Test-Path $CsprojPath) {
        $csprojContent = Get-Content -Path $CsprojPath -Raw
        if ($csprojContent -match "<Version>(.*?)</Version>") {
            $Version = $matches[1].Trim()
        }
    }
}
if ([string]::IsNullOrWhiteSpace($Version)) {
    $Version = "1.0.0"
}

Write-Host "================================================================" -ForegroundColor Cyan
Write-Host " Building Autodesk App Store Bundle for $AppName v$Version" -ForegroundColor Cyan
Write-Host " Publisher: $Author (DBDev Solutions)" -ForegroundColor Cyan
Write-Host " Target Years: $([string]::Join(', ', $TargetYears))" -ForegroundColor Cyan
Write-Host "================================================================" -ForegroundColor Cyan

$BundleName = "$AppName.bundle"
$DeployDir = Join-Path $resolvedProjectDir "Deploy"
$PublishPackageDir = Join-Path $resolvedProjectDir "$($AppName)PublishPackage"
if (-not (Test-Path $PublishPackageDir)) {
    $PublishPackageDir = Join-Path $resolvedProjectDir "FilterPlusPublishPackage"
}
$BundlePath = Join-Path $DeployDir $BundleName
$AssetsDir = Join-Path $resolvedProjectDir "..\.agents\skills\revit-appstore-bundle\assets"

# Extract AddInId from source .addin file
$ProjectAddinPath = Join-Path $resolvedProjectDir "$AppName.addin"
$AppAddinId = "A5265BB9-214C-4109-8DDC-DF1F6E4305B9"
if (Test-Path $ProjectAddinPath) {
    try {
        [xml]$parsedAddin = Get-Content -Path $ProjectAddinPath -Raw
        $foundId = $parsedAddin.RevitAddIns.AddIn.AddInId
        if ($foundId) { $AppAddinId = $foundId }
    } catch {
        Write-Warning "Could not parse $AppName.addin. Using default ID."
    }
}
Write-Host " AddInId GUID: $AppAddinId" -ForegroundColor DarkCyan

# Prepare Deploy and Archive directories
if (-not (Test-Path $DeployDir)) { New-Item -ItemType Directory -Path $DeployDir | Out-Null }
$ArchiveDir = Join-Path $DeployDir "Archive"
if (-not (Test-Path $ArchiveDir)) { New-Item -ItemType Directory -Path $ArchiveDir | Out-Null }

# Archive older zips
$OldZips = Get-ChildItem -Path $DeployDir -Filter "*.zip"
foreach ($zip in $OldZips) {
    Move-Item -Path $zip.FullName -Destination $ArchiveDir -Force
}

# Clean temporary staging bundle folder
if (Test-Path $BundlePath) {
    Remove-Item -Path $BundlePath -Recurse -Force
}
New-Item -ItemType Directory -Path $BundlePath | Out-Null

$ContentsPath = Join-Path $BundlePath "Contents"
New-Item -ItemType Directory -Path $ContentsPath | Out-Null

# Scan for compiled versions in bin/
$BinDir = Join-Path $resolvedProjectDir "bin"
if (-not (Test-Path $BinDir)) {
    Write-Error "Bin directory not found. Please compile the project first with Release configurations."
}

$ComponentsXml = ""

foreach ($Year in $TargetYears) {
    $ShortYear = $Year.Substring(2) # "24", "25", etc.
    $ConfigName = "Release.R$ShortYear"
    # Prioritize Release candidates strictly over Debug
    $ReleaseCandidates = @(
        (Join-Path $BinDir "$ConfigName\publish\$AppName"),
        (Join-Path $BinDir "$ConfigName\publish"),
        (Join-Path $BinDir "$ConfigName")
    )
    $DebugCandidates = @(
        (Join-Path $BinDir "Debug.R$ShortYear\publish\$AppName"),
        (Join-Path $BinDir "Debug.R$ShortYear\publish"),
        (Join-Path $BinDir "Debug.R$ShortYear")
    )

    $Candidates = @()
    $ReleaseFound = $false
    foreach ($cand in $ReleaseCandidates) {
        if ((Test-Path $cand) -and (Test-Path (Join-Path $cand "$AppName.dll"))) {
            $Candidates += $cand
            $ReleaseFound = $true
        }
    }
    if (-not $ReleaseFound) {
        $Candidates = $DebugCandidates
    }


    $PublishDir = $null
    $FoundDlls = @()
    foreach ($cand in $Candidates) {
        $candidateDll = Join-Path $cand "$AppName.dll"
        if ((Test-Path $cand) -and (Test-Path $candidateDll)) {
            $FoundDlls += (Get-Item $candidateDll)
        }
    }

    if ($FoundDlls.Count -gt 0) {
        $PublishDir = ($FoundDlls | Sort-Object LastWriteTime -Descending | Select-Object -First 1).DirectoryName
    }

    if (-not $PublishDir) {
        Write-Warning "Publish directory not found for Revit $Year ($ConfigName). Attempting compilation..."
        $Csproj = Join-Path $resolvedProjectDir "$AppName.csproj"
        try {
            dotnet publish $Csproj -c $ConfigName /p:DeployAddin=false
        } catch {
            Write-Warning "Compilation failed for $ConfigName. Skipping $Year."
        }
        $FoundDlls = @()
        foreach ($cand in $Candidates) {
            $candidateDll = Join-Path $cand "$AppName.dll"
            if ((Test-Path $cand) -and (Test-Path $candidateDll)) {
                $FoundDlls += (Get-Item $candidateDll)
            }
        }
        if ($FoundDlls.Count -gt 0) {
            $PublishDir = ($FoundDlls | Sort-Object LastWriteTime -Descending | Select-Object -First 1).DirectoryName
        }
    }

    if (-not $PublishDir) {
        Write-Warning "Skipping Revit $($Year): Compiled output not available"
        continue
    }

    Write-Host "Packing Revit $Year from $PublishDir..." -ForegroundColor Green
    
    # Create Contents/202X folder
    $TargetVersionDir = Join-Path $ContentsPath $Year
    New-Item -ItemType Directory -Path $TargetVersionDir -Force | Out-Null
    
    # 1. Copy ALL binaries and dependency DLLs (Nice3point, CommunityToolkit, System.*, etc.)
    $CopiedFiles = Copy-Item -Path "$PublishDir\*" -Destination $TargetVersionDir -Recurse -Force -PassThru
    Write-Host "  -> Copied $($CopiedFiles.Count) binaries/resources for $Year" -ForegroundColor Gray

    # Guarantee that version-specific Resources folder and help.html are always present
    $VerResourcesDir = Join-Path $TargetVersionDir "Resources"
    if (-not (Test-Path $VerResourcesDir)) {
        New-Item -ItemType Directory -Path $VerResourcesDir -Force | Out-Null
    }
    $ProjectResources = Join-Path $resolvedProjectDir "Resources"
    if (Test-Path $ProjectResources) {
        Copy-Item -Path "$ProjectResources\*" -Destination $VerResourcesDir -Recurse -Force
    }
    $ProjectHelp = Join-Path $resolvedProjectDir "Resources\help.html"
    if (Test-Path $ProjectHelp) {
        Copy-Item -Path $ProjectHelp -Destination (Join-Path $VerResourcesDir "help.html") -Force
        Copy-Item -Path $ProjectHelp -Destination (Join-Path $VerResourcesDir "Help.html") -Force
    }
    # Extra compatibility alias for "Resource" singular
    $VerResourceDirSingular = Join-Path $TargetVersionDir "Resource"
    if (-not (Test-Path $VerResourceDirSingular)) {
        New-Item -ItemType Directory -Path $VerResourceDirSingular -Force | Out-Null
    }
    if (Test-Path $ProjectResources) {
        Copy-Item -Path "$ProjectResources\*" -Destination $VerResourceDirSingular -Recurse -Force
    }
    if (Test-Path $ProjectHelp) {
        Copy-Item -Path $ProjectHelp -Destination (Join-Path $VerResourceDirSingular "help.html") -Force
        Copy-Item -Path $ProjectHelp -Destination (Join-Path $VerResourceDirSingular "Help.html") -Force
    }

    # 2. Generate standardized .addin manifest with DBDev Solutions identity and correct GUID
    $AddinContent = @"
<RevitAddIns>
    <AddIn Type="Application">
        <Name>$AppName</Name>
        <Assembly>$AppName.dll</Assembly>
        <AddInId>$AppAddinId</AddInId>
        <FullClassName>$AppName.Application</FullClassName>
        <VendorId>$Author</VendorId>
        <VendorDescription>DBDev Solutions</VendorDescription>
        <VendorEmail>$Email</VendorEmail>
        <ContextName>$AppName</ContextName>
    </AddIn>
</RevitAddIns>
"@
    $TargetAddinPath = Join-Path $TargetVersionDir "$AppName.addin"
    [System.IO.File]::WriteAllText($TargetAddinPath, $AddinContent, [System.Text.Encoding]::UTF8)

    # 3. Add Component Entry to PackageContents XML
    $ComponentsXml += @"
  <Components Description="$AppName Add-in for Revit $Year">
    <RuntimeRequirements OS="Win64" Platform="Revit" SeriesMin="$Year" SeriesMax="$Year" />
    <ComponentEntry AppName="$AppName" Version="$Version" ModuleName="./Contents/$Year/$AppName.addin" AppDescription="DBDev Solutions" LoadOnRevitStartup="True" />
  </Components>
"@ + "`r`n"
}

# Copy root Resources (Icons, Help, Images, Styles)
$ResourcesDest = Join-Path $ContentsPath "Resources"
New-Item -ItemType Directory -Path $ResourcesDest -Force | Out-Null

$ProjectResourcesRoot = Join-Path $resolvedProjectDir "Resources"
if (Test-Path $ProjectResourcesRoot) {
    Copy-Item -Path "$ProjectResourcesRoot\*" -Destination $ResourcesDest -Recurse -Force
}

$HelpSrc = Join-Path $resolvedProjectDir "Resources\help.html"
if (Test-Path $HelpSrc) {
    Copy-Item -Path $HelpSrc -Destination (Join-Path $ResourcesDest "help.html") -Force
    Copy-Item -Path $HelpSrc -Destination (Join-Path $ResourcesDest "Help.html") -Force
}

$IconsSrc = Join-Path $resolvedProjectDir "Resources\Icons"
if (Test-Path $IconsSrc) {
    $IconsDest = Join-Path $ResourcesDest "Icons"
    New-Item -ItemType Directory -Path $IconsDest -Force | Out-Null
    Copy-Item -Path "$IconsSrc\*" -Destination $IconsDest -Recurse -Force
    
    # Also copy standard icon names to root of Resources
    if (Test-Path (Join-Path $IconsSrc "RibbonIcon16.png")) {
        Copy-Item -Path (Join-Path $IconsSrc "RibbonIcon16.png") -Destination (Join-Path $ResourcesDest "Icon16.png") -Force
    } elseif (Test-Path (Join-Path $IconsSrc "$($AppName)16x16.png")) {
        Copy-Item -Path (Join-Path $IconsSrc "$($AppName)16x16.png") -Destination (Join-Path $ResourcesDest "Icon16.png") -Force
    }

    if (Test-Path (Join-Path $IconsSrc "RibbonIcon32.png")) {
        Copy-Item -Path (Join-Path $IconsSrc "RibbonIcon32.png") -Destination (Join-Path $ResourcesDest "Icon32.png") -Force
    } elseif (Test-Path (Join-Path $IconsSrc "$($AppName)32x32.png")) {
        Copy-Item -Path (Join-Path $IconsSrc "$($AppName)32x32.png") -Destination (Join-Path $ResourcesDest "Icon32.png") -Force
    }
}

# Generate ProductCode GUID
$ProductCode = [guid]::NewGuid().ToString().ToUpper()

# Process PackageContents.xml Template
$XmlTemplatePath = Join-Path $AssetsDir "PackageContents.xml"
$XmlContent = Get-Content -Path $XmlTemplatePath -Raw
$XmlContent = $XmlContent -replace "\{\{Version\}\}", $Version
$XmlContent = $XmlContent -replace "\{\{AppName\}\}", $AppName
$XmlContent = $XmlContent -replace "\{\{Author\}\}", $Author
$XmlContent = $XmlContent -replace "\{\{Email\}\}", $Email
$XmlContent = $XmlContent -replace "\{\{ProductCode\}\}", $ProductCode
$XmlContent = $XmlContent -replace "\{\{Components\}\}", $ComponentsXml

$XmlTargetPath = Join-Path $BundlePath "PackageContents.xml"
[System.IO.File]::WriteAllText($XmlTargetPath, $XmlContent, [System.Text.Encoding]::UTF8)

Write-Host "Bundle folder generated at: $BundlePath" -ForegroundColor Green

# Compress to ZIP with root .bundle directory
$ZipPath = Join-Path $DeployDir "$AppName`_v$Version.zip"
if (Test-Path $ZipPath) { Remove-Item $ZipPath -Force }

Write-Host "Archiving bundle to $ZipPath..." -ForegroundColor Gray
Add-Type -AssemblyName System.IO.Compression.FileSystem
try {
    [System.IO.Compression.ZipFile]::CreateFromDirectory($BundlePath, $ZipPath, [System.IO.Compression.CompressionLevel]::Optimal, $true)
} catch {
    Write-Warning "ZipFile failed: $_. Falling back to Compress-Archive..."
    Compress-Archive -Path $BundlePath -DestinationPath $ZipPath -Force
}

# If PublishPackage folder exists, update it as well
if (Test-Path $PublishPackageDir) {
    Write-Host "Syncing package to $PublishPackageDir..." -ForegroundColor Cyan
    $PkgBundle = Join-Path $PublishPackageDir $BundleName
    if (Test-Path $PkgBundle) { Remove-Item -Path $PkgBundle -Recurse -Force }
    Copy-Item -Path $BundlePath -Destination $PublishPackageDir -Recurse -Force
    
    $PkgZip = Join-Path $PublishPackageDir "$AppName.bundle.zip"
    if (Test-Path $PkgZip) { Remove-Item -Path $PkgZip -Force }
    Copy-Item -Path $ZipPath -Destination $PkgZip -Force
}

Write-Host "================================================================" -ForegroundColor Green
Write-Host " SUCCESS: Autodesk App Store Bundle ready at:" -ForegroundColor Green
Write-Host " -> $ZipPath" -ForegroundColor Yellow
if (Test-Path $PublishPackageDir) {
    Write-Host " -> $(Join-Path $PublishPackageDir "$AppName.bundle.zip")" -ForegroundColor Yellow
}
Write-Host "================================================================" -ForegroundColor Green
