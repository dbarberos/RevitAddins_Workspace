# 🛡️ pre-commit Hook — Validación Automatizada de Calidad (PowerShell / Windows)
# Este script comprueba la consistencia de directorios de IA, el formato C# y compila el add-in antes de confirmar un commit.

$RepoRoot = Split-Path $PSScriptRoot -Parent
Set-Location -Path $RepoRoot

Write-Host "=== Iniciando validaciones pre-commit ===" -ForegroundColor Cyan

# -----------------------------------------------------------------------------
# 🧠 Paso 1: Validar consistencia física de directorios de IA
# -----------------------------------------------------------------------------
Write-Host "`n[1/3] Comprobando consistencia del Cerebro de IA (.agents/)..." -ForegroundColor Yellow
$IAFolder = Join-Path $RepoRoot ".agents"
$Instructions = Join-Path $RepoRoot "AI_INSTRUCTIONS.md"

if (-not (Test-Path $IAFolder)) {
    Write-Error "❌ Error Crítico: La carpeta '.agents/' no existe en la raíz."
    exit 1
}

if (-not (Test-Path $Instructions)) {
    Write-Error "❌ Error Crítico: El mapa de instrucciones de IA 'AI_INSTRUCTIONS.md' no existe en el root."
    exit 1
}

$SkillsDir = Join-Path $IAFolder "skills"
if (Test-Path $SkillsDir) {
    $MonolithicSkills = Get-ChildItem -Path $SkillsDir -Filter "SKILL.md" -Recurse
    foreach ($skill in $MonolithicSkills) {
        $skillContent = Get-Content -Path $skill.FullName -Raw
        # Advertir si un skill principal contiene bloques de código extensos inline
        if ($skillContent -match "class\s+\w+" -or $skillContent -match "public\s+void") {
            Write-Warning "⚠️ Advertencia: El archivo '$($skill.Name)' contiene bloques C# embebidos inline. Recuerda moverlos a la carpeta 'assets/'."
        }
    }
}
Write-Host "  OK: Estructura del cerebro de IA validada." -ForegroundColor Green

# -----------------------------------------------------------------------------
# 🎨 Paso 2: Ejecutar formateador automático de C#
# -----------------------------------------------------------------------------
Write-Host "`n[2/3] Formateando código C# con dotnet format..." -ForegroundColor Yellow
try {
    dotnet format
    Write-Host "  OK: Código formateado con éxito." -ForegroundColor Green
} catch {
    Write-Warning "⚠️ Advertencia: Ocurrió un error al formatear el código (asegúrate de tener instalado el SDK de .NET)."
}

# -----------------------------------------------------------------------------
# 💻 Paso 3: Ejecutar compilación de seguridad (dotnet build)
# -----------------------------------------------------------------------------
Write-Host "`n[3/3] Ejecutando compilación de prueba (dotnet build)..." -ForegroundColor Yellow
$CsprojFiles = Get-ChildItem -Path $RepoRoot -Filter "*.csproj" -Recurse | Where-Object { $_.FullName -notmatch "Tests" }

if ($CsprojFiles.Count -eq 0) {
    Write-Host "  Información: No se detectaron proyectos de C# compilables directos." -ForegroundColor Gray
} else {
    foreach ($csproj in $CsprojFiles) {
        Write-Host "  Compilando: $($csproj.Name)..." -ForegroundColor Gray
        $buildOutput = dotnet build $csproj.FullName --configuration Release 2>&1
        if ($LASTEXITCODE -ne 0) {
            Write-Error "❌ Error Crítico: La compilación del proyecto '$($csproj.Name)' falló."
            Write-Host $buildOutput -ForegroundColor Red
            exit 1
        }
    }
    Write-Host "  OK: Todos los proyectos compilan sin errores." -ForegroundColor Green
}

Write-Host "`n=== Todas las comprobaciones de calidad han pasado con éxito. ¡Commit permitido! ===" -ForegroundColor Green
exit 0
