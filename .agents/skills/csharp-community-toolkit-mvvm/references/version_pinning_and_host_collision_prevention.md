# Dependency Version Pinning & Cross-Addin Host Collision Prevention

* **Target Environment:** Autodesk Revit 2023–2027 (.NET Framework 4.8 & .NET 8 CoreCLR).
* **Key Library:** `CommunityToolkit.Mvvm` (Pinned to `8.2.2`).

---

## 1. The CoreCLR Shared Process Problem (Revit 2025+)

In Revit 2025, 2026, and 2027, the host runtime is **.NET 8 CoreCLR**. Unlike standalone executables, all Revit add-ins execute inside a single OS process (`Revit.exe`) and share the default assembly context (`AssemblyLoadContext.Default`).

### The Downward Binding Prohibition
CoreCLR enforces strict version binding rules:
1. **Upward Unification Permitted:** If an already-loaded assembly has version $V_{loaded}$, and an incoming request asks for $V_{requested}$ where $V_{loaded} \ge V_{requested}$, CoreCLR binds successfully.
2. **Downward Binding Prohibited:** If an already-loaded assembly has version $V_{loaded}$, and an incoming request asks for $V_{requested}$ where $V_{loaded} < V_{requested}$, CoreCLR **rejects the binding**:
   - `AssemblyResolve` and probing will return the already-loaded assembly.
   - CoreCLR determines that $V_{loaded} < V_{requested}$ and immediately throws:
     `System.IO.FileLoadException: Could not load file or assembly 'CommunityToolkit.Mvvm, Version=...'. Could not find or load a specific file. (0x80131621)`.

### Concrete Incident:
If `FilterPlus` or `TablePlus` (compiled with `8.2.2`, assembly version `8.2.0.0`) loads first when Revit starts, and the user then clicks `TransferPlus` (which was compiled with `8.4.2`, assembly version `8.4.0.0`):
* Loaded: `8.2.0.0`
* Requested: `8.4.0.0`
* Result: $8.2.0.0 < 8.4.0.0$ $\rightarrow$ **Immediate crash (0x80131621)** on command execution.

---

## 2. Invariant Rules for Developers and AI Agents

Whenever scaffolding a new add-in, updating dependencies, or evaluating library versions:

### Rule 1: Monorepo-Wide Version Pinning
All add-ins in the workspace must declare the exact same baseline version for shared libraries:
```xml
<!-- MVVM & Utilities: MANDATORY PINNED BASELINE -->
<PackageReference Include="CommunityToolkit.Mvvm" Version="8.2.2"/>
```

### Rule 2: Explicit Incompatibility Warning Gate
If a new feature, library, or requirement contemplates bumping `CommunityToolkit.Mvvm` (or any shared library such as `System.Text.Json` or `Newtonsoft.Json`) to a higher version (e.g., `8.4.x`):
* **The agent MUST HALT AND WARN THE DEVELOPER:**
  > ⚠️ **Incompatibility Warning:** Bumping `CommunityToolkit.Mvvm` to version `8.4+` in this add-in will break runtime compatibility with already-installed add-ins (`FilterPlus`, `TablePlus`, `TransferPlus`) that use `8.2.2` inside Revit 2025+. If an existing add-in is discovered or loaded first, the new add-in will fail to launch with `FileLoadException (0x80131621)`.
* **Action Required:** The upgrade must **NEVER** be done for a single add-in in isolation. It must either be:
  1. Synchronized globally across all add-ins in the monorepo in a single coordinated release, OR
  2. Maintained at the `8.2.2` baseline, which provides 100% of required MVVM features and guarantees upward compatibility.

---

## 3. Legacy Framework Compatibility (.NET Framework 4.8 / Revit 2023–2024)

`CommunityToolkit.Mvvm 8.2.2` is the Long-Term Support (LTS) release verified across .NET Standard 2.0. Higher versions (8.4+) introduce newer transitive dependencies on `System.Runtime.CompilerServices.Unsafe` and `System.Memory` that frequently collide with the fixed GAC assemblies pre-installed in Autodesk Revit 2023/2024 directories, causing silent `TypeLoadException` or `MissingMethodException` errors.

Keeping `8.2.2` ensures stable, warning-free execution across all 5 supported Revit releases (2023, 2024, 2025, 2026, and 2027).
