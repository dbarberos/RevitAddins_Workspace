# [AddInName] — Constitution & Inviolable Architectural Principles

**Scope:** Add-in Local (`[AddInName]`)  
**Parent Constitution:** [Global Constitution](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/docs/constitution.md)  
**Authority:** Subordinate to [AGENTS.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/AGENTS.md) and the Global Constitution  
**Language:** English  

---

## 1. Domain Objective & Scope

[Describe the specific purpose of this add-in, the target Revit categories/elements it interacts with, and the core problem it solves.]

---

## 2. Inviolable Architectural Principles

### 2.1. Reference Draft Policy (`references_examples/`)
- Reference draft examined: `references_examples/[DraftFolderName]/`
- **Read-Only Constraint**: Files inside `references_examples/` must never be modified.
- **UI Decoupling**: Any user interface found in the draft project must be discarded. The UI for `[AddInName]` must be built using the project's WPF/MVVM design system (card-based theme, dark/light theme adaptation, inline styles in `Window.Resources`, virtualized controls).
- **Logic Extraction**: Extract only pure algorithmic routines, Revit API collector strategies, and transaction workflows, refactoring them into testable services.

### 2.2. Transaction & Database Invariants
- Every write action must be executed inside a scoped `using (Transaction tx = new Transaction(doc, "[Action]"))` block.
- Read operations must never open a transaction.
- Non-fatal warnings must be suppressed via `WarningSwallower` (`IFailuresPreprocessor`).
- Transaction groups must be used when coordinating multi-step transactions to maintain single-click Undo in Revit.

### 2.3. Threading & Modeless Execution
- If using modeless WPF windows or dockable panels, Revit API mutations must be dispatched via `Revit.Async` (`RevitTask.RunAsync`) or `ExternalEventBridge`.
- Never access `Autodesk.Revit.DB` objects from asynchronous background threads without dispatching to the main thread.

### 2.4. WPF UI & Performance Guardrails
- Declare all styles, templates, brushes, and converters inline within `<Window.Resources>`. Never use external `pack://application:,,,/` resource dictionaries.
- Enforce collection virtualization (`VirtualizingStackPanel.IsVirtualizing="True"`) on all element lists.
- Enforce safety limit check (e.g., 100,000 elements) to prevent UI thread lockups.

### 2.5. Multi-Version & Autoloader Compliance
- `PackageContents.xml` must strictly format `SeriesMin` and `SeriesMax` with the `"R"` prefix (e.g., `SeriesMin="R2023"`, `SeriesMax="R2027"`).
- Multi-version `ElementId` handling:
  ```csharp
  #if REVIT2024_OR_GREATER
      long id = elementId.Value;
  #else
      long id = elementId.IntegerValue;
  #endif
  ```
- Register `AppDomain.CurrentDomain.AssemblyResolve` in `OnStartup()` for .NET 8 / Revit 2025+ support.

---

## 3. Prohibited Patterns (Anti-Patterns)
- ❌ Do NOT store raw Revit `Element` instances in ViewModel properties. Store plain DTOs or `ElementId`.
- ❌ Do NOT modify code in `references_examples/`.
- ❌ Do NOT write code without approved `spec.md`, `plan.md`, and `tasks.md`.
- ❌ Do NOT open transactions for read-only element collection.
