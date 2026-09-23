# ==============================================================================
# PURPOSE: Local Pipeline Orchestrator for TablePlus (AI Agent & Developer).
#          Handles Clean, Restore, Multi-Version Compilation, and Packaging.
# ==============================================================================

Param(
    [string]$SolutionName = "TablePlus.csproj",
    [string]$OutputZipPath = ".\Deploy",
    [string]$Configuration = "" # If empty, prompt interactively
)

$ErrorActionPreference = "Stop"
Write-Host "[TablePlus Pipeline] Initializing compilation and automated packaging..." -ForegroundColor Cyan

# Interactive prompt if Configuration is not provided
if ([string]::IsNullOrWhiteSpace($Configuration)) {
    Write-Host "--------------------------------------------------------" -ForegroundColor Yellow
    Write-Host "Select Compilation & Anti-Tampering Configuration:" -ForegroundColor Yellow
    Write-Host "1) Production [Release + Obfuscar Anti-Tampering]" -ForegroundColor Green
    Write-Host "2) Development [Debug + Full PDB Symbols (Debugging & Logs)]" -ForegroundColor Green
    Write-Host "--------------------------------------------------------" -ForegroundColor Yellow
    $choice = Read-Host "Enter option (1 or 2)"
    if ($choice -eq "2") {
        $Configuration = "Debug.R24"
    } else {
        $Configuration = "Release.R24"
    }
}

Write-Host "[TablePlus Pipeline] Configuration selected: $Configuration" -ForegroundColor Cyan

# 1. Clean previous build outputs
if (Test-Path .\bin) { Remove-Item -Recurse -Force .\bin }
if (Test-Path .\obj) { Remove-Item -Recurse -Force .\obj }

# 2. Restore third-party packages from NuGet
Write-Host "[TablePlus Pipeline] Restoring NuGet packages..." -ForegroundColor Green
dotnet restore $SolutionName

# 3. Compile solution with selected configuration
Write-Host "[TablePlus Pipeline] Compiling solution in ($Configuration)..." -ForegroundColor Green
dotnet build $SolutionName --configuration $Configuration --no-restore

# 4. Packaging or local deployment
Write-Host "[TablePlus Pipeline] Preparing final output directory..." -ForegroundColor Green
if (!(Test-Path $OutputZipPath)) { New-Item -ItemType Directory -Path $OutputZipPath | Out-Null }

Write-Host "[TablePlus Pipeline] Process completed! Add-in is compiled in $Configuration mode." -ForegroundColor Green
