# sync-version.ps1
# Automates synchronization of compilation and installer versions based on documentation.

$scriptPath = Split-Path -Parent $MyInvocation.MyCommand.Definition
$docPath = Join-Path $scriptPath "..\docs\User_Guide.md"
$csprojPath = Join-Path $scriptPath "..\FilterPlus.csproj"
$wxsPath = Join-Path $scriptPath "Product.wxs"

if (-not (Test-Path $docPath)) {
    Write-Error "user_guide.md not found at expected path: $docPath"
    exit 1
}

# 1. Parse Version from documentation
$docContent = Get-Content -Path $docPath -Raw
if ($docContent -match '\*\*Current Version:\*\*\s*v?([0-9.]+)') {
    $version = $Matches[1]
    Write-Host "Detected Documentation Version: $version"
} else {
    Write-Error "Could not parse '**Current Version:** v?X.X.X' from User_Guide.md"
    exit 1
}

# 2. Update FilterPlus.csproj
if (Test-Path $csprojPath) {
    $csprojContent = Get-Content -Path $csprojPath -Raw
    if ($csprojContent -match '<Version>[0-9.]+</Version>') {
        $csprojContent = $csprojContent -replace '<Version>[0-9.]+</Version>', "<Version>$version</Version>"
    } else {
        # Inject <Version> inside the first <PropertyGroup>
        $csprojContent = $csprojContent -replace '(?s)(<PropertyGroup>.*?)(</PropertyGroup>)', "`$1    <Version>$version</Version>`r`n`$2"
    }
    Set-Content -Path $csprojPath -Value $csprojContent -NoNewline
    Write-Host "Updated FilterPlus.csproj to version $version"
}

# 3. Update Product.wxs
if (Test-Path $wxsPath) {
    $wxsContent = Get-Content -Path $wxsPath -Raw
    # Use .NET Lookbehind (?<=...) to match only the version string inside the <Product> element
    if ($wxsContent -match '(?<=<Product[^>]*\s+Version=")[0-9.]+') {
        $wxsContent = $wxsContent -replace '(?<=<Product[^>]*\s+Version=")[0-9.]+', $version
        Set-Content -Path $wxsPath -Value $wxsContent -NoNewline
        Write-Host "Updated Product.wxs to version $version"
    } else {
        Write-Error "Could not locate '<Product ... Version=\"X.X.X\"' inside Product.wxs"
    }
}

# 4. Update PackageContents.xml
$xmlPath = Join-Path $scriptPath "..\FilterPlusPublishPackage\FilterPlus.bundle\PackageContents.xml"
if (Test-Path $xmlPath) {
    $xmlContent = Get-Content -Path $xmlPath -Raw
    # Update AppVersion in ApplicationPackage element
    $xmlContent = $xmlContent -replace '(?<=<ApplicationPackage[^>]*\s+AppVersion=")[0-9.]+', $version
    # Update Version in ComponentEntry elements
    $xmlContent = $xmlContent -replace '(?<=Version=")[0-9.]+', $version
    Set-Content -Path $xmlPath -Value $xmlContent -NoNewline
    Write-Host "Updated PackageContents.xml to version $version"
}
