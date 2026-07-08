# Debugging: WiX Toolset Command PATH Resolution

## Symptom
Running `candle` or `light` commands directly from the terminal or scripts fails with command-not-found exceptions:
```
candle : El término 'candle' no se reconoce como nombre de un cmdlet, función...
```

## Root Cause
The WiX Toolset installer does not automatically register its executable directory in the Windows system environment PATH variable. Therefore, calling `candle` or `light` works within Visual Studio's MSBuild-context (where paths are resolved by extensions) but fails in clean PowerShell or CMD terminal prompts.

## Solution
Instead of relying on the system PATH, target the standard absolute installation paths for WiX Toolset v3 executables. 

1.  **Locate standard paths**:
    *   WiX v3.11: `C:\Program Files (x86)\WiX Toolset v3.11\bin\`
    *   WiX v3.14: `C:\Program Files (x86)\WiX Toolset v3.14\bin\`
2.  **Invoke explicitly in scripts**:
    Use a default parameter `WixBinDir` in compilation scripts to verify and resolve the executable:
    ```powershell
    param(
        [string]$WixBinDir = "C:\Program Files (x86)\WiX Toolset v3.14\bin"
    )

    $CandleExe = Join-Path $WixBinDir "candle.exe"
    $LightExe = Join-Path $WixBinDir "light.exe"

    if (-not (Test-Path $CandleExe)) {
        Write-Error "WiX Toolset candle.exe not found at $CandleExe"
    }

    # Execute compiling
    & "$CandleExe" -out "$WixObj" "$WxsFile"
    ```
