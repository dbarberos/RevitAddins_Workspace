# Debugging Log: Revit CoreCLR FileLoadException (0x80131621) - CommunityToolkit.Mvvm Version Collision

* **Date:** 2026-09-25
* **Target Environment:** Autodesk Revit 2025+ (.NET 8 CoreCLR), 2023–2027 Multi-Version Add-ins.
* **Error Encountered:**
  ```text
  Fallo de comando para comando externo
  Revit no ha podido completar el comando externo. Solicite asistencia a su proveedor.
  Información proporcionada a Revit sobre su identidad: DBDev Solutions.

  Revit ha encontrado Could not load file or assembly
  'CommunityToolkit.Mvvm, Version=8.4.0.0, Culture=neutral, PublicKeyToken=4aff67a105548ee2'.
  Could not find or load a specific file. (0x80131621)
  ```

---

## 1. Root Cause Analysis

1. **Shared Process Context in .NET 8 (CoreCLR):**
   In Revit 2025, 2026, and 2027, the host runtime is .NET 8 CoreCLR. All installed add-ins share the primary `AssemblyLoadContext.Default` within the `Revit.exe` process unless isolated explicitly.

2. **CoreCLR Strict Version Binding Rules:**
   Unlike .NET Framework 4.8 (which supported automatic binding redirects and relaxed unification), CoreCLR strictly prohibits downward assembly version binding:
   * If Add-in A (e.g. `FilterPlus` or `TablePlus`) initializes first, it loads `CommunityToolkit.Mvvm, Version=8.2.0.0` into `AssemblyLoadContext.Default`.
   * When Add-in B (`TransferPlus`) is invoked, it requests `CommunityToolkit.Mvvm, Version=8.4.0.0` (compiled with NuGet package `8.4.2`).
   * CoreCLR checks the loaded assembly: $8.2.0.0 < 8.4.0.0$. CoreCLR refuses to bind downward.
   * CoreCLR invokes `AppDomain.CurrentDomain.AssemblyResolve` or probing. `Assembly.LoadFrom(...)` returns the already-loaded `8.2.0.0` instance from `AssemblyLoadContext.Default`.
   * CoreCLR detects that `8.2.0.0` does not satisfy `8.4.0.0` and immediately throws `FileLoadException (HRESULT 0x80131621)`.

3. **Why it didn't crash in Revit 2024:**
   Revit 2024 runs on .NET Framework 4.8, which handles assembly probing differently and permits side-by-side or binding redirect unification.

---

## 2. Solution: Harmonize Shared Library Dependencies Across Monorepo

To eliminate cross-addin version collisions in Revit's shared CLR process:

1. **Pin `CommunityToolkit.Mvvm` Version in `.csproj`:**
   Enforce the monorepo standard version (`8.2.2`, assembly version `8.2.0.0`) in `TransferPlus.csproj`:
   ```xml
   <!-- MVVM & Utilities -->
   <PackageReference Include="CommunityToolkit.Mvvm" Version="8.2.2"/>
   ```

2. **Why 8.2.2 is Safe for All Add-ins:**
   `8.2.0.0` is the baseline 8.x assembly version. If another add-in in the future loads a newer version (e.g. `8.3.0.0` or `8.4.0.0`), CoreCLR automatically unifies **upward** without error ($8.4.0.0 \ge 8.2.0.0$). Only requesting a higher version than what is loaded causes `0x80131621`.

3. **Multi-Version Verification:**
   Rebuilt and verified clean compilation across all target versions:
   * `Release.R23` / `Debug.R23` (.NET Framework 4.8)
   * `Release.R24` / `Debug.R24` (.NET Framework 4.8)
   * `Release.R25` / `Debug.R25` (.NET 8 Windows)
   * `Release.R26` / `Debug.R26` (.NET 8 Windows)
   * `Release.R27` / `Debug.R27` (.NET 8 Windows)
   Repackaged the complete App Store bundle via `.agents/skills/revit-appstore-bundle/scripts/build-bundle.ps1`.
