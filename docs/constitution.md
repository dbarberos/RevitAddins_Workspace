# Revit Add-in Global Workspace Constitution

**Scope:** Global (`RevitAddins_Workspace`)  
**Authority:** Secondary only to [AGENTS.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/AGENTS.md)  
**Language:** English (Official Engineering Standard)  
**Last Revised:** 2026-09-22  

---

## Preamble

This Constitution establishes the non-negotiable principles, engineering standards, and architectural contracts governing the development of all Autodesk Revit Add-ins within this workspace. Every developer, custom subagent, and automated tool must strictly abide by these articles. 

Specific add-ins may define an additional local `[AddIn]/docs/constitution.md` with domain-specific rules, provided it strictly extends and never contradicts this Global Constitution.

---

## Article I: Primacy of AGENTS.md & Repository Skills

1. **Supreme Reference**: [AGENTS.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/AGENTS.md) at the workspace root constitutes the supreme technical standard of this repository. Any code pattern or proposal contradicting `AGENTS.md` is void.
2. **Prior Skill Consultation**: Before formulating any specification, architecture plan, or implementation task, developers and agents **must** inspect and adhere to the relevant skills located in `.agents/skills/`:
   - `revit-api` & `revit-api-core`: Revit DB lifecycle, ExternalCommandData, Application/Document contexts.
   - `revit-transactions`: Transaction scope, using blocks, subtransactions, and transaction groups.
   - `revit-async-operations`: Modeless WPF/WebView2 async bridge via `Revit.Async` or `IExternalEventHandler`.
   - `revit-api-resilience`: Failure API (`WarningSwallower`), Dynamic Model Update (`IUpdater`), and telemetry scrubbing.
   - `revit-addin-gui-design`: WPF virtualization, card-based theme layouts, and inline resource rules.
   - `revit-appstore-bundle`: Autoloader series formatting, multi-version compilation, and `AssemblyResolve`.
   - `security-engineer`: Zero-trust input validation, path sanitization, and DPAPI credential protection.
   - `csharp-community-toolkit-mvvm`: `[ObservableProperty]`, `[RelayCommand]`, and decoupled messaging.
3. **No Contradiction**: New specifications (`spec.md`) and technical plans (`plan.md`) must align with recorded lessons learned and skill references.

---

## Article II: Architectural Decoupling & UI System Replacement

1. **Strict Layer Separation**:
   - **Views**: XAML definitions only. Zero direct business logic in code-behind.
   - **ViewModels**: Presentation state and user interaction commands (`CommunityToolkit.Mvvm`). ViewModels must never reference Autodesk Revit API elements or transactions directly.
   - **Services**: Pure business logic and data access interfaces. Services interact with Revit API via dependency injection.
   - **Models**: Plain data transfer objects (DTOs) decoupled from native Revit memory pointers.
2. **Reference Projects Policy (`references_examples/`)**:
   - Folders under `references_examples/` serve as functional drafts and architectural guides.
   - **Strict Read-Only Access**: No file inside `references_examples/` shall ever be modified, renamed, or deleted.
   - **Mandatory UI Replacement**: When extracting functional logic from a reference draft, its legacy UI (Windows Forms, raw dialogs, outdated XAML) must be discarded. The add-in must implement our custom WPF/MVVM design system (FilterPlus modern card-based theme, dark/light adaptation, smooth micro-interactions).

---

## Article III: Revit API Transaction Safety & Resource Management

1. **Deterministic Scoping**: Every write operation to the Revit database must be wrapped in a `using (Transaction tx = new Transaction(doc, "Action Name"))` block.
2. **Zero Transactions for Reads**: Transactions must never be opened for read-only queries or `FilteredElementCollector` evaluations.
3. **Nested Contexts**: Where granular rollbacks are needed inside an active transaction, use `SubTransaction` within a `using` block.
4. **Failure Handling**: Batch or automated modifications must register a `WarningSwallower` (`IFailuresPreprocessor`) to silently dismiss benign warnings without presenting modal popups that block unattended execution. Never suppress `FailureSeverity.Error` or `FailureSeverity.DocumentCorruption`.
5. **Memory Management**: Dispose unmanaged geometry objects (e.g., `Solid`, `CurveLoop`) when generated in loops, and prevent object retention past document close events.

---

## Article IV: Threading, Asynchronous Operations & Modeless Dialogs

1. **Revit Context Protection**: The Revit API is single-threaded. Invoking Revit API methods from secondary threads, task pools, or standard async methods (`async void`, `Task.Run`) triggers fatal exceptions (`InvalidOperationException`).
2. **Modeless UI Bridging**: All interactions originating from modeless WPF windows, dockable panes, or background workers that interact with Revit must be queued onto the Revit thread using:
   - `Revit.Async` (`await RevitTask.RunAsync(...)`), or
   - Native `IExternalEventHandler` / `ExternalEventBridge`.
3. **Modal vs. Modeless Discipline**: Modal dialogs (`ShowDialog()`) run within the invoking `IExternalCommand` execution context and can commit transactions directly; modeless dialogs (`Show()`) must never attempt direct transactions.

---

## Article V: WPF UI Design, Virtualization & Resource Scoping

1. **Inline Window Resources (FilterPlus Pattern)**:
   - All converters, brushes, control templates, and style resources must be declared inline within `<Window.Resources>` in the view's XAML.
   - **Never** import external resource dictionaries via `pack://application:,,,/` in `ResourceDictionary.Source`. Autodesk Revit does not supply a standard WPF Application lifecycle (`Application.Current`), which triggers fatal `XamlParseException` on load.
2. **Mandatory UI Virtualization**:
   - Any collection control (`ListView`, `TreeView`, `DataGrid`) displaying lists of elements must enable WPF virtualization (`VirtualizingStackPanel.IsVirtualizing="True"`).
   - Never wrap virtualized controls inside an unconstrained `ScrollViewer`.
3. **Large Dataset Safety Guard**:
   - When inspecting or presenting elements from active or linked models, enforce an element safety ceiling (e.g., 100,000 items) to prevent UI freezes.
4. **Theme Adaptation**:
   - Honor Revit 2024+ light and dark theme switching. Never hardcode foreground or background colors to literal white or black.

---

## Article VI: Multi-Version Support, Autoloader & CI/CD Packaging

1. **PackageContents.xml Series Naming**:
   - In all Autoloader manifests (`PackageContents.xml`), the attributes `SeriesMin` and `SeriesMax` **must strictly include the `"R"` prefix** (e.g., `SeriesMin="R2023"`, `SeriesMax="R2027"`). Omitting the `"R"` causes Revit's Autoloader to evaluate string comparison (`"R202X" <= "202X"`) as false, silently discarding the add-in at startup.
2. **ElementId Multi-Version Unification**:
   - Across codebases supporting Revit 2023 (.NET Framework 4.8) alongside Revit 2024+ (.NET 8):
     ```csharp
     #if REVIT2024_OR_GREATER
         long idVal = elementId.Value;
     #else
         long idVal = elementId.IntegerValue;
     #endif
     ```
3. **CoreCLR Assembly Resolution (.NET 8 / Revit 2025+)**:
   - Entry points (`IExternalApplication`) must register `AppDomain.CurrentDomain.AssemblyResolve` in `OnStartup()` to dynamically resolve co-located secondary assemblies (`Nice3point.Revit.Toolkit.dll`, `CommunityToolkit.Mvvm.dll`) loaded from bundle directories.
4. **Production Build Obfuscation**:
   - Release pipelines must run Obfuscar (`Obfuscar.targets`) with entry-point and UI exclusions (`[Obfuscation(Exclude = true)]`).

---

## Article VII: Zero-Trust Security & Resilient Engineering

1. **Path Traversal Prevention**:
   - Every file path received from user input, configuration files, or external payloads must be strictly sanitized using path normalization and directory boundary validation before disk access.
2. **Credential Protection**:
   - API keys, database connection strings, and user tokens must never be committed as plain text. Protect local secrets using Windows DPAPI (`ProtectedData.Protect`).
3. **Secure Serialization**:
   - Disable `TypeNameHandling.All` in Newtonsoft.Json (use `TypeNameHandling.None` or `System.Text.Json`) to eliminate Remote Code Execution (RCE) vectors.
4. **Telemetry & Exception Hygiene**:
   - User machine paths, usernames, and raw stack traces must be sanitized in logs (`TelemetryLogger`) and never displayed raw to end-users via `TaskDialog`.

---

## Article VIII: The Golden Rule of Spec-Driven Development (SSD)

1. **Specification Precedes Code**:
   - Under no circumstances shall production code or commands be drafted before `spec.md`, `plan.md`, and `tasks.md` have been generated and approved.
2. **Sequential Numbering**:
   - Every feature or revision is assigned an incremental three-digit identifier under `specs/` (e.g., `specs/001-element-export/`, `specs/002-sheet-duplication/`).
3. **Mandatory Phase-Gate Reviews**:
   - Progression through SSD phases requires explicit user review pauses. The developer or agent must not advance to the next phase without confirming user alignment.
4. **Change Management**:
   - When requirements change during or after development, the change must be made first in `spec.md` and `plan.md`. Only then may code modifications take place.
