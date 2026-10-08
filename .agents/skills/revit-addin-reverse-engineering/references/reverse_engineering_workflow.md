# Reverse Engineering & Clean-Room Reconstruction Workflow

This guide details the operational execution pipeline for inspecting an existing Revit add-in or platform binary, extracting its architectural and business rules, and building a clean, modern clone tailored with custom improvements.

---

## 1. Pipeline Overview

```text
  [ Target Binary / Draft ]
             │
             ▼
    ┌─────────────────┐
    │ 1. RECON        │ ──▶ Parse Manifest (.addin), Entry points (IExternalApplication, IExternalCommand)
    └────────┬────────┘
             │
             ▼
    ┌─────────────────┐
    │ 2. EVIDENCE     │ ──▶ Targeted Decompilation: DB transactions, Schema GUIDs, Geometry math
    └────────┬────────┘     (Zero-bloat: query only relevant execution branches)
             │
             ▼
    ┌─────────────────┐
    │ 3. ABSTRACTION  │ ──▶ Convert proprietary code to pure Functional Specification & DTOs
    └────────┬────────┘     (Clean-room boundary: functional intent without code reproduction)
             │
             ▼
    ┌─────────────────┐
    │ 4. REBUILD      │ ──▶ Clean C# 12 / MVVM / Nice3point project from scratch
    └────────┬────────┘     (Modern FilterPlus Fluent UI, inline resources, Virtualization)
             │
             ▼
    ┌─────────────────┐
    │ 5. DELTA ENG.   │ ──▶ Inject custom enhancements, fix bugs, optimize performance
    └─────────────────┘
```

---

## 2. Phase 1: Reconnaissance (Zero-Bloat Discovery)

Never dump entire assemblies or directories into the agent context. Start with high-level structural discovery:

### A. Manifest Inspection (`.addin` or `PackageContents.xml`)
- Locate entry points: `<AddIn Type="Application">` or `<AddIn Type="Command">`.
- Identify Assembly paths, VendorId, AddInId (GUIDs), and full type names.
- Verify supported Revit versions (e.g., .NET 4.8 vs .NET 8 CoreCLR).

### B. Ribbon & Startup Inspection (`IExternalApplication`)
- Inspect `OnStartup(UIControlledApplication app)`:
  - Ribbon tab and panel names created.
  - Buttons (`PushButtonData`), split buttons, pulldowns, comboboxes.
  - Command bindings: which button calls which `IExternalCommand`.
  - Event subscriptions: `DocumentOpened`, `DocumentChanged`, `ApplicationInitialized`, `Idling`.
  - Dockable pane registration (`RegisterDockablePane`).
  - DMU Updater registration (`UpdaterRegistry.RegisterUpdater`).

### C. Entry Point Cataloging (`IExternalCommand`)
- Catalog each command class:
  - TransactionMode: `TransactionMode.Manual` vs `TransactionMode.ReadOnly`.
  - RegenerationOption: `RegenerationOption.Manual`.
  - Execute signature and parameters received.
  - Modal vs Modeless launch: Does it open a modal WPF dialog (`ShowDialog()`), a modeless floating window (`Show()`), or execute headless?

---

## 3. Phase 2: Targeted Evidence Extraction

Query specific functional slices without reading irrelevant boilerplate or third-party libraries (e.g. Newtonsoft, RestSharp, ExcelDataReader).

### A. Transaction & DB Operations Tracing
- Identify all write operations:
  ```csharp
  using (Transaction tx = new Transaction(doc, "..."))
  ```
- Check failure handling: Did the original code use an `IFailuresPreprocessor` or let modal Revit popups crash batch workflows?
- Note SubTransactions and nested groups (`TransactionGroup.Assimilate()`).

### B. Extensible Storage & Parameter Mapping
- Search for `Schema.Lookup` or `SchemaBuilder`:
  - Note the Schema GUID, VendorId, and field definitions.
  - Determine whether data is stored per-element, per-document (`DataStorage`), or in Project Information.
- Search for Parameter usage:
  - Hardcoded parameter names vs `BuiltInParameter` vs Shared Parameter GUIDs.
  - Check how shared parameters were bound (Instance vs Type, Categories bound).

### C. Geometry & Computational Core
- Separate Revit API geometry calls from mathematical algorithms:
  - Vector transformations, bounding boxes, tessellation, intersections.
  - Solid Boolean operations (`BooleanOperationsUtils`).
  - Reference point mapping across linked models (`CreateLinkReference`).

---

## 4. Phase 3: Architectural Abstraction (The Clean-Room Boundary)

Before writing any new code, produce the **Architectural Blueprint** (using `assets/clean_room_blueprint_template.md`).

### A. Isolate Pure Domain Models
- Strip all Revit DB dependencies (`Element`, `Document`, `XYZ`) from domain models wherever possible.
- Define pure POCO/DTO records:
  ```csharp
  public record TableCellDto(int Row, int Col, string Text, bool IsHeader);
  public record TableSyncConfig(string FilePath, string SheetName, TableOriginType Origin);
  ```

### B. Formalize the Functional Contract
- Describe the algorithm in plain technical language, pseudocode, or sequence diagrams:
  - Input: What the user provides or what the document contains.
  - Transformation: Step-by-step logic.
  - Output: What Revit elements or view representations are created.

### C. Identify Architectural Anti-Patterns to Eliminate
Commercial add-ins often contain severe legacy flaws that our clone must NOT replicate:
1. **Thread Freezes**: Modeless WPF buttons calling Revit API on background threads without `Revit.Async`.
2. **Parameter Clutter**: Creating dozens of unmanaged shared parameters instead of reusable pools or Extensible Storage.
3. **Popup Dialog Lockups**: Batch operations failing because a Revit duplicate-type warning blocks the UI thread.
4. **Hardcoded UI**: Fixed-size non-responsive windows with archaic WinForms styling.
5. **No Virtualization**: DataGrids loading 10,000 rows freezing Revit due to missing WPF virtualization.

---

## 5. Phase 4: Clean-Room Reconstruction

Rebuild the add-in completely from scratch using the repository's production standards:

### A. Project Scaffolding
- Use Nice3point templates targeting multi-version Revit (.NET 4.8 / .NET 8).
- Configure `<ImplicitUsings>enable</ImplicitUsings>` and `<LangVersion>12.0</LangVersion>`.
- Pin shared NuGet packages: `CommunityToolkit.Mvvm` 8.2.2 (avoiding CoreCLR load conflicts in Revit 2025+).

### B. Clean MVVM Architecture
- **Views**: Modern WPF Window declared with inline `<Window.Resources>` (FilterPlus card-based design system).
  - Never import external ResourceDictionaries via `pack://application:,,,/` in `Window.Resources` (prevents Revit unmanaged host `XamlParseException`).
  - Enable virtualization on all lists/grids: `VirtualizingStackPanel.IsVirtualizing="True"`.
- **ViewModels**: C# 12 primary constructors with `[ObservableProperty]` and `[RelayCommand]`.
- **Services**: Clean interfaces injected via constructor (`ITableSyncService`, `IParameterPoolService`).
- **Commands**: Thin `IExternalCommand` wrappers that resolve dependencies and show views or dispatch actions.

### C. Resilience Injection
- Inject `WarningSwallower` (`IFailuresPreprocessor`) to silently dismiss non-fatal warnings during batch transactions.
- Modeless actions wrapped in `await RevitTask.RunAsync(...)` via `Revit.Async`.

---

## 6. Phase 5: Delta Engineering (Custom Improvements)

Once the core clone functional parity is achieved, apply the developer's requested modifications:

1. **Performance Improvements**: Replace slow element iterations with filtered collectors and quick filters (`ElementMulticlassFilter`, `BoundingBoxIntersectsFilter`).
2. **Modern UX**: Introduce search filtering, regex matching, dark mode support, and progress indicators.
3. **Feature Extensions**: Add batch export, multi-sheet processing, or bidirectional synchronization requested by the developer.
4. **Autonomous Testing**: Implement in-process integration tests using `Nice3point.TUnit.Revit` to ensure all commands and transactions pass under real Revit engines.
