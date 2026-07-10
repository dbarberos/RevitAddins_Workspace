# ==============================================================================
# PURPOSE: Local Pipeline Orchestrator for AI Agent execution.
#          Handles Clean, Restore, Multi-Version Compilation, and Packaging.
# ==============================================================================

Param(
    [string]$SolutionName = "TuSolucionRevit.sln",
    [string]$OutputZipPath = ".\Distributables",
    [string]$Configuration = "" # If empty, prompt interactively
)

$ErrorActionPreference = "Stop"
Write-Host "[Pipeline] Inicializando compilación y protección desatendida..." -ForegroundColor Cyan

# Interactive prompt if Configuration is not provided
if ([string]::IsNullOrWhiteSpace($Configuration)) {
    Write-Host "--------------------------------------------------------" -ForegroundColor Yellow
    Write-Host "Select Compilation & Anti-Tampering Configuration:" -ForegroundColor Yellow
    Write-Host "1) Production [Release + Obfuscar Anti-Tampering]" -ForegroundColor Green
    Write-Host "2) Development [Debug + Full PDB Symbols (Debugging & Logs)]" -ForegroundColor Green
    Write-Host "--------------------------------------------------------" -ForegroundColor Yellow
    $choice = Read-Host "Enter option (1 or 2)"
    if ($choice -eq "2") {
        $Configuration = "Debug"
    } else {
        $Configuration = "Release"
    }
}

Write-Host "[Pipeline] Configuration selected: $Configuration" -ForegroundColor Cyan

# 1. Clean previous build outputs
if (Test-Path .\*.bin) { Remove-Item -Recurse -Force .\*.bin }
if (Test-Path .\*.obj) { Remove-Item -Recurse -Force .\*.obj }

# 2. Restore third-party packages from NuGet
Write-Host "[Pipeline] Restaurando paquetes NuGet..." -ForegroundColor Green
dotnet restore $SolutionName

# 3. Compile solution with selected configuration
Write-Host "[Pipeline] Compilando solución en modo ($Configuration)..." -ForegroundColor Green
# If Release mode, Obfuscar.targets will run automatically post-build
dotnet build $SolutionName --configuration $Configuration --no-restore

# 4. Packaging or local deployment
Write-Host "[Pipeline] Preparando archivos finales para empaquetado..." -ForegroundColor Green
if (!(Test-Path $OutputZipPath)) { New-Item -ItemType Directory -Path $OutputZipPath | Out-Null }

Write-Host "[Pipeline] ¡Proceso completado! El add-in está compilado en modo $Configuration." -ForegroundColor Green
