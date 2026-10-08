<#
.SYNOPSIS
    Inspects a compiled Revit add-in assembly (.dll) and catalogs its entry points,
    references, and resources without locking the target file on disk.

.DESCRIPTION
    Loads the target DLL into memory via byte-array reflection. Catalogs:
    - Target Framework & Assembly identity
    - Referenced assemblies (identifying Revit API versions and external dependencies)
    - Revit Entry Points: IExternalCommand, IExternalApplication, IExternalEventHandler, IUpdater
    - Embedded resources (BAML, icons, configuration files)

.PARAMETER AssemblyPath
    Path to the compiled .NET assembly (.dll).

.PARAMETER OutputJson
    Optional switch to output raw JSON instead of human-readable console tables.

.EXAMPLE
    .\inspect-revit-assembly.ps1 -AssemblyPath "B:\Reference\MyAddin.dll"
#>

[CmdletBinding()]
param (
    [Parameter(Mandatory = $true, Position = 0)]
    [string]$AssemblyPath,

    [switch]$OutputJson
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

if (-not (Test-Path $AssemblyPath)) {
    Write-Error "Assembly file not found at: $AssemblyPath"
    exit 1
}

$fullPath = (Resolve-Path $AssemblyPath).Path
Write-Verbose "Inspecting assembly: $fullPath"

try {
    # Read bytes to avoid file-locking the binary on disk
    $bytes = [System.IO.File]::ReadAllBytes($fullPath)
    $assembly = [System.Reflection.Assembly]::Load($bytes)
}
catch {
    Write-Error "Failed to load assembly into memory: $_"
    exit 1
}

# 1. Identity & Framework
$targetFrameworkAttr = $assembly.GetCustomAttributes([System.Runtime.Versioning.TargetFrameworkAttribute], $false)
$targetFramework = if ($targetFrameworkAttr) { $targetFrameworkAttr[0].FrameworkName } else { "Unknown" }

# 2. Referenced Assemblies
$refs = $assembly.GetReferencedAssemblies() | ForEach-Object {
    [PSCustomObject]@{
        Name    = $_.Name
        Version = $_.Version.ToString()
        IsRevit = $_.Name -match "^RevitAPI"
    }
}

# 3. Exported Types & Interfaces (Catch Loader Exceptions Safely)
$types = @()
$unloadedTypeNames = @()

try {
    $types = $assembly.GetTypes()
}
catch {
    $ex = $_.Exception
    $rtEx = $null
    if ($ex.InnerException -and $ex.InnerException -is [System.Reflection.ReflectionTypeLoadException]) {
        $rtEx = $ex.InnerException
    }
    elseif ($ex -is [System.Reflection.ReflectionTypeLoadException]) {
        $rtEx = $ex
    }

    if ($rtEx) {
        $types = $rtEx.Types | Where-Object { $null -ne $_ }
        foreach ($loaderEx in $rtEx.LoaderExceptions) {
            $name = $null
            if ($loaderEx -is [System.TypeLoadException]) {
                $name = $loaderEx.TypeName
            }
            elseif ($loaderEx.Message -match "type '([^']+)'") {
                $name = $matches[1]
            }

            if ($name -and $unloadedTypeNames -notcontains $name) {
                $unloadedTypeNames += $name
            }
        }
    }
}

$commands = @()
$applications = @()
$eventHandlers = @()
$updaters = @()

foreach ($t in $types) {
    if ($null -eq $t) { continue }

    $isCommand = $false
    $isApp = $false
    $isEvent = $false
    $isUpdater = $false

    # Interface check
    try {
        $interfaces = $t.GetInterfaces() | ForEach-Object { $_.Name }
        if ($interfaces -contains "IExternalCommand") { $isCommand = $true }
        if ($interfaces -contains "IExternalApplication") { $isApp = $true }
        if ($interfaces -contains "IExternalEventHandler") { $isEvent = $true }
        if ($interfaces -contains "IUpdater") { $isUpdater = $true }
    } catch { }

    # Base type hierarchy check (e.g. Nice3point ExternalApplication, ExternalCommand)
    try {
        $currBase = $t.BaseType
        while ($currBase -ne $null) {
            if ($currBase.Name -match "ExternalCommand|^Command$" -or $currBase.FullName -match "IExternalCommand") { $isCommand = $true }
            if ($currBase.Name -match "ExternalApplication|^Application$" -or $currBase.FullName -match "IExternalApplication") { $isApp = $true }
            $currBase = $currBase.BaseType
        }
    } catch { }

    # Pattern heuristics if reflection failed on missing assemblies
    if (-not $isCommand -and -not $isApp) {
        if ($t.FullName -match "\.Commands?\.[a-zA-Z0-9]+Command$" -or $t.Name -match "^Cmd[A-Z]" -or ($t.Name -match "Command$" -and $t.Name -notmatch "Relay|AsyncRelay|<")) {
            $isCommand = $true
        }
        if ($t.FullName -match "\.(App|Application)$" -and $t.Name -notmatch "<|DisplayClass") {
            $isApp = $true
        }
        if ($t.Name -match "Updater$" -and $t.Namespace -match "Updater") {
            $isUpdater = $true
        }
    }

    if ($isCommand) {
        $commands += [PSCustomObject]@{
            FullName  = $t.FullName
            Namespace = $t.Namespace
            Name      = $t.Name
            IsPublic  = $t.IsPublic
        }
    }

    if ($isApp) {
        $applications += [PSCustomObject]@{
            FullName  = $t.FullName
            Namespace = $t.Namespace
            Name      = $t.Name
            IsPublic  = $t.IsPublic
        }
    }

    if ($isEvent) {
        $eventHandlers += [PSCustomObject]@{
            FullName  = $t.FullName
            Namespace = $t.Namespace
            Name      = $t.Name
        }
    }

    if ($isUpdater) {
        $updaters += [PSCustomObject]@{
            FullName  = $t.FullName
            Namespace = $t.Namespace
            Name      = $t.Name
        }
    }
}

# Process types that could not be loaded due to external Revit/Toolkit dependencies
foreach ($uName in $unloadedTypeNames) {
    if ($uName -match "<|DisplayClass") { continue }

    $parts = $uName.Split('.')
    $shortName = $parts[-1]
    $ns = if ($parts.Length -gt 1) { ($parts[0..($parts.Length-2)]) -join '.' } else { "" }

    if ($uName -match "\.Commands?\.[a-zA-Z0-9]+Command$" -or $shortName -match "^Cmd[A-Z]" -or ($shortName -match "Command$" -and $shortName -notmatch "Relay|AsyncRelay")) {
        if (-not ($commands | Where-Object { $_.FullName -eq $uName })) {
            $commands += [PSCustomObject]@{
                FullName  = $uName
                Namespace = $ns
                Name      = $shortName
                IsPublic  = $true
            }
        }
    }
    elseif ($uName -match "\.(App|Application)$") {
        if (-not ($applications | Where-Object { $_.FullName -eq $uName })) {
            $applications += [PSCustomObject]@{
                FullName  = $uName
                Namespace = $ns
                Name      = $shortName
                IsPublic  = $true
            }
        }
    }
    elseif ($shortName -match "Updater$") {
        if (-not ($updaters | Where-Object { $_.FullName -eq $uName })) {
            $updaters += [PSCustomObject]@{
                FullName  = $uName
                Namespace = $ns
                Name      = $shortName
            }
        }
    }
    elseif ($shortName -match "Handler$|EventHandler$") {
        if (-not ($eventHandlers | Where-Object { $_.FullName -eq $uName })) {
            $eventHandlers += [PSCustomObject]@{
                FullName  = $uName
                Namespace = $ns
                Name      = $shortName
            }
        }
    }
}

# If no commands or applications were detected via reflection (e.g. unmanaged RevitAPI dependencies),
# scan the binary PE strings heap for command classes and entry points.
if ($commands.Count -eq 0 -or $applications.Count -eq 0) {
    $rawText = [System.Text.Encoding]::UTF8.GetString($bytes)
    
    # Match Cmd* or *Command patterns
    $cmdMatches = [regex]::Matches($rawText, '\b(Cmd[A-Za-z0-9_]+|[A-Za-z0-9_]+Command)\b') |
        ForEach-Object { $_.Value } | Select-Object -Unique |
        Where-Object { $_ -notmatch '^(System|Microsoft|Windows|get_|set_|Relay|AsyncRelay|ICommand|ExternalCommand|TablePlusRibbonCommand)' }

    # Filter down to probable Revit commands
    $revitCmds = $cmdMatches | Where-Object { $_ -match "^Cmd[A-Z]" -or $_ -match "RevitCommand$" }
    if (-not $revitCmds -and $cmdMatches) {
        $revitCmds = $cmdMatches | Where-Object { $_ -match "Command$" -and $_ -notmatch "ViewModel" }
    }

    foreach ($cmdName in $revitCmds) {
        if (-not ($commands | Where-Object { $_.Name -eq $cmdName })) {
            $commands += [PSCustomObject]@{
                FullName  = "$($assembly.GetName().Name).$cmdName"
                Namespace = $assembly.GetName().Name
                Name      = $cmdName
                IsPublic  = $true
            }
        }
    }

    if ($applications.Count -eq 0) {
        if ($rawText -match '\b([A-Za-z0-9_]+\.Application)\b' -or $rawText -match '\bExternalApplication\b' -or $rawText -match '\bIExternalApplication\b') {
            $appName = "$($assembly.GetName().Name).Application"
            $applications += [PSCustomObject]@{
                FullName  = $appName
                Namespace = $assembly.GetName().Name
                Name      = "Application"
                IsPublic  = $true
            }
        }
    }
}

# 4. Embedded Resources
$resources = $assembly.GetManifestResourceNames()

$result = [PSCustomObject]@{
    AssemblyFile      = [System.IO.Path]::GetFileName($fullPath)
    AssemblyName      = $assembly.GetName().Name
    AssemblyVersion   = $assembly.GetName().Version.ToString()
    TargetFramework   = $targetFramework
    RevitCommands     = $commands
    RevitApplications = $applications
    ExternalEvents    = $eventHandlers
    Updaters          = $updaters
    RevitReferences   = ($refs | Where-Object { $_.IsRevit })
    TotalTypes        = $types.Count
    EmbeddedResources = $resources
}

if ($OutputJson) {
    $result | ConvertTo-Json -Depth 5
}
else {
    Write-Host "`n========================================================" -ForegroundColor Cyan
    Write-Host "   REVIT ADD-IN ASSEMBLY INSPECTION REPORT" -ForegroundColor Cyan
    Write-Host "========================================================`n" -ForegroundColor Cyan
    
    Write-Host "File:             $($result.AssemblyFile)"
    Write-Host "Assembly:         $($result.AssemblyName) (v$($result.AssemblyVersion))"
    Write-Host "Framework:        $($result.TargetFramework)"
    Write-Host "Total Types:      $($result.TotalTypes)"
    
    Write-Host "`n--- Revit API References ---" -ForegroundColor Yellow
    if ($result.RevitReferences.Count -gt 0) {
        $result.RevitReferences | Format-Table -AutoSize
    } else {
        Write-Host "  (No direct RevitAPI references found in metadata)" -ForegroundColor Gray
    }

    Write-Host "--- IExternalApplication (Ribbon/Startup) [Count: $($result.RevitApplications.Count)] ---" -ForegroundColor Green
    if ($result.RevitApplications.Count -gt 0) {
        $result.RevitApplications | Format-Table -AutoSize
    } else {
        Write-Host "  (None found)" -ForegroundColor Gray
    }

    Write-Host "--- IExternalCommand (Buttons/Commands) [Count: $($result.RevitCommands.Count)] ---" -ForegroundColor Green
    if ($result.RevitCommands.Count -gt 0) {
        $result.RevitCommands | Format-Table -AutoSize
    } else {
        Write-Host "  (None found)" -ForegroundColor Gray
    }

    if ($result.ExternalEvents.Count -gt 0) {
        Write-Host "--- IExternalEventHandler (Modeless Handlers) [Count: $($result.ExternalEvents.Count)] ---" -ForegroundColor Magenta
        $result.ExternalEvents | Format-Table -AutoSize
    }

    if ($result.Updaters.Count -gt 0) {
        Write-Host "--- IUpdater (Dynamic Model Updaters) [Count: $($result.Updaters.Count)] ---" -ForegroundColor Magenta
        $result.Updaters | Format-Table -AutoSize
    }

    Write-Host "--- Embedded Resources [Count: $($result.EmbeddedResources.Count)] ---" -ForegroundColor Yellow
    $result.EmbeddedResources | ForEach-Object { Write-Host "  * $_" }
    Write-Host ""
}
