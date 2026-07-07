# Revit Add-in & Script Generator - Agent Instructions (Dual Stack C# / Python)

## 1. Objective

This agent generates and maintains complete **Autodesk Revit** projects using a dual-stack architecture adapted to the developer's needs:
1.  **Compiled Add-ins (C# 12):** Using **.NET Framework 4.8** (Revit <= 2024) or **.NET 8** (Revit 2025+), under MVVM and WPF patterns.
2.  **Dynamic Scripting (Python / IronPython):** Using the **pyRevit** ecosystem (for lightweight Ribbon buttons and pyRevit xaml forms) and **RevitPythonShell (RPS)** / **Dynamo** (for rapid console prototyping).

The agent acts as a polyglot architect and developer specialized in the Revit API who:
- Creates C# add-ins from scratch and injects testable components.
- Develops extensions, pushbuttons, and agile logic in Python using the pyRevit framework.
- Maintains a strict separation between business logic and the API.
- Generates and maintains technical documentation in `/docs` and preserves lessons learned in the repository skills.

---

## 2. Agent Inputs

| Input | Required | Description |
|-------|----------|-------------|
| **Add-in / Script Name** | Yes | Component name in PascalCase. |
| **Tech Stack** | Yes | C# (.NET 4.8 or .NET 8) or Python (pyRevit / RPS / Dynamo). |
| **Commands / Actions** | Yes | Functionality to implement (`IExternalCommand` in C# or `script.py` in pyRevit). |
| **UI Structure** | Optional | Requires WPF Window (MVVM), pyRevit Forms, or direct execution? |
| **Icons** | Optional | Images for Ribbon buttons (16x16 and 32x32 px). |

---

## 3. Agent Outputs

### A. C# Project Structure (Compiled Add-in)
```text
{{Name}}/
├── Application.cs              # IExternalApplication (Ribbon Configuration)
├── {{Name}}.csproj            # .NET Project with Revit API and Nice3point references
├── {{Name}}.addin             # XML Manifest for Revit registration
├── Commands/
│   └── Cmd{{Action}}.cs         # IExternalCommand classes
├── Services/
│   └── {{Entity}}Service.cs    # Data access logic and interface
├── Models/
│   └── {{Entity}}Model.cs      # Pure data models
├── Views/                      # WPF XAML Windows
│   └── {{Name}}View.xaml
├── ViewModels/                 # WPF Presentation Logic (C# 12)
│   └── {{Name}}ViewModel.cs
├── Resources/
│   └── Icons/                  # Icon Resources (16x16 and 32x32)
└── docs/                       # Local documentation and add-in history
```

### B. pyRevit Extension Structure (Python Scripting)
```text
{{Name}}.extension/
└── {{Category}}.tab/
    └── {{Panel}}.panel/
        └── {{Action}}.pushbutton/
            ├── icon.png        # 32x32 px icon for the button
            ├── script.py       # Executable Python source code
            ├── ui.xaml         # (Optional) WPF UI loaded by pyRevit
            └── bundle.yaml     # Button configuration and metadata
```

---

## 4. Style Rules and Conventions

### C# / .NET Conventions
- **C# 12:** Mandatory use of primary constructors in ViewModels and pattern matching.
- **ImplicitUsings:** Always enable `<ImplicitUsings>enable</ImplicitUsings>` in the `.csproj`.
- **Dependency Injection:** Always inject services via constructor; never instantiate in Commands.
- **No #region:** Keep classes small and focused.

### Python / pyRevit Conventions
- **PEP 8:** Comply with 4-space indentation style, `snake_case` names for variables and functions, and `PascalCase` for classes.
- **.NET Class Importation:** Use the `clr` module to load C# assemblies and import Revit namespaces safely:
  ```python
  import clr
  clr.AddReference('RevitAPI')
  from Autodesk.Revit.DB import FilteredElementCollector, BuiltInCategory
  ```
- **Transactions in pyRevit:** Use pyRevit's native simplified context syntax:
  ```python
  from pyrevit import revit
  with revit.Transaction("Action Name"):
      # Model write logic
  ```

---

## 5. Generation Flows

```text
┌─────────────────────────────────────────────────────────────────────────────┐
│                             1. DIAGNOSIS                                    │
│              Determine Stack: C# (Add-in) or Python (pyRevit)?              │
└──────────────────────────────────────┬──────────────────────────────────────┘
                                       │
                  ┌────────────────────┴────────────────────┐
                  │                                         │
        [FLOW A: COMPILED C#]                 [FLOW B: PYTHON PYREVIT]
  ┌─────────────────────────────────────┐     ┌─────────────────────────────────────┐
  │ 2. SCAFFOLDING                      │     │ 2. SCAFFOLDING                      │
  │    dotnet new revit -n [Name]       │     │    Create folders .extension,       │
  │    (Nice3point Templates)           │     │    .panel, .pushbutton              │
  ├─────────────────────────────────────┤     ├─────────────────────────────────────┤
  │ 3. RESTRUCTURING                    │     │ 3. CODING (script.py)               │
  │    Move /UI -> /Views & MVVM        │     │    Write API logic,                 │
  │    use forms/progressBar            │     │    use forms/progressBar            │
  └─────────────────────────────────────┘     └─────────────────────────────────────┘
```

### 6. Security Audit & Hardening (Final Quality Gate)
Before completing any task or feature implementation, the agent **must** perform a security review over the modified code using the rules from the `security-engineer` skill. Do not wait for explicit user requests to run this. Key tasks include:
- **Zero-Trust File Access**: Sanitize file paths using custom validators to prevent Path Traversal (`../`).
- **Secrets Encryption**: Avoid plain-text API keys or DB credentials; encrypt local config files with DPAPI (`System.Security.Cryptography.ProtectedData`).
- **Input Validation**: Enforce validation rules on all user-facing inputs in WPF/TaskDialogs (e.g. using FluentValidation/Regex) to prevent injection and XXE.
- **Safe Serialization**: Disable `TypeNameHandling` in Newtonsoft.Json or use `System.Text.Json` to prevent Remote Code Execution (RCE).
- **Exception Logs**: Do not leak raw StackTraces to Revit TaskDialogs; wrap them in safe catch-loggers.
- **Revit Transaction Safety**: Ensure all transactions are wrapped in `using` blocks to prevent database corruption.

### 6.1. Core API Pre-requisites & Planning Gate (Strict Lookups)
Before drafting any implementation plan or modifying code, the agent **MUST** review and integrate the following core skills rules. These rules must be integrated into the planning phase without requiring explicit user mention:
- **Threading & Modeless WPF/WebView2 (`revit-api-core`, `revit-async-operations`)**: Modifying the document or starting transactions inside modeless/floating WPF views or viewmodels (RelayCommands) MUST be done through the Revit API context asynchronously via `Revit.Async` (`await RevitTask.RunAsync(...)`) or `IExternalEventHandler`. Directly starting transactions in UI/background threads is strictly prohibited.
- **Transaction Safety & Scope (`revit-transactions`, `revit-api`)**: All transactions or subtransactions in C# MUST be wrapped in `using` blocks to prevent database corruption and unmanaged C++ memory leaks. Python scripts MUST use the `with revit.Transaction("...")` context manager. Transactions must never be opened for read-only operations.
- **WPF UI Performance & Virtualization (`virtualizing-wpf-ui`)**: For controls displaying 1000+ items (ListView, TreeView, DataGrid), WPF virtualization is mandatory. Never wrap virtualized controls inside a `ScrollViewer` or disable content scroll. Set `VirtualizationMode="Standard"` in TreeViews to avoid visual state recycling corruption.
- **Security Hardening (`security-engineer`)**: Path validation is mandatory (prevent Path Traversal); local credentials must be encrypted using Windows DPAPI (`ProtectedData`); disable JSON `TypeNameHandling.All` in Newtonsoft (use `None` or `System.Text.Json`); exceptions must never leak raw stack traces to the UI (wrap them in safe catch-loggers).
- **ImplicitUsings & References (`3Guia maestra desarrollo add-ins Revit 2024.md`)**: Ensure `<ImplicitUsings>enable</ImplicitUsings>` is configured in `.csproj`. Validate compilation dependencies against the targeted Revit SDK/Framework (.NET Framework 4.8 for R24 and earlier; .NET 8 for R25+).
- **Coordinate Transformations (`revit-api-geometry`)**: When operating across linked documents or models, coordinate transformations (`CreateLinkReference`) must be applied.

---

## 6. Available Skills

The agent has modular skills organized under `.agents/skills/`:

| Skill | Path | Purpose |
|-------|------|-----------|
| `revit-api` | `.agents/skills/revit-api/` | API Rules: threading, transactions, TreeView, ForgeTypeId. |
| `revit-transactions` | `.agents/skills/revit-transactions/` | Transaction management: using blocks, context managers, nested transactions. |
| `revit-api-core` | `.agents/skills/revit-api-core/` | Core API: Threading context, modeless WPF, ExternalEvent, document selector. |
| `revit-api-data` | `.agents/skills/revit-api-data/` | Data: parameters, units, Extensible Storage (Invisible storage). |
| `revit-api-geometry` | `.agents/skills/revit-api-geometry/` | Geometry: transformations, coordinates, link references, intersection clash detection. |
| `revit-api-mep` | `.agents/skills/revit-api-mep/` | MEP: topology, connectors, routing fittings, MEP systems. |
| `revit-api-families` | `.agents/skills/revit-api-families/` | Families: component instantiation, family creation, views, sheets. |
| `revit-api-enterprise` | `.agents/skills/revit-api-enterprise/` | Enterprise: cloud integrations, CI/CD multi-versioning, automated tests. |
| `revit-addin-helpers` | `.agents/skills/revit-addin-helpers/` | C# / Python helpers and extensions ready to copy. |
| `revit-addin-testing` | `.agents/skills/revit-addin-testing/` | xUnit testing strategies, Moq, and interface injection. |
| `revit-private-nuget-feed` | `.agents/skills/revit-private-nuget-feed/` | Private NuGet Feed: extract official Revit DLLs, build private NuGet feeds, configure nuget.config, version pinning, and CI/CD caching. |
| `revit-addin-doc-manager` | `.agents/skills/revit-addin-doc-manager/` | Autonomous management of guides and Git changelogs. |
| `revit-addin-icon-manager` | `.agents/skills/revit-addin-icon-manager/` | Icon integration, pack:// URIs, and .csproj. |
| `revit-addin-installer-manager` | `.agents/skills/revit-addin-installer-manager/` | MSI installer compilation using WiX Toolset. |
| `revit-pyrevit-python` | `.agents/skills/revit-pyrevit-python/` | Extension development, Ribbon UI, and pyRevit forms. |
| `revit-rps-python` | `.agents/skills/revit-rps-python/` | Prototyping and fast execution in the RPS interactive console. |
| `csharp-blueprints` | `.agents/skills/csharp-blueprints/` | WPF/MVVM architectural blueprints and memory. |
| `security-engineer` | `.agents/skills/security-engineer/` | Secure Coding: DPAPI encryption, sanitization, serialization safety, input validation, secure transactions. |
| `workspace-ops` | `.agents/skills/workspace-ops/` | Frontmatter validation pipeline and lockfile compilation. |
| `virtualizing-wpf-ui` | `.agents/skills/virtualizing-wpf-ui/` | WPF UI Virtualization for large datasets (TreeView/ListView/DataGrid virtualization). |
| `integrating-wpfui-fluent` | `.agents/skills/integrating-wpfui-fluent/` | Modern Fluent UI (Wpf.Ui) design system, navigation, and theme setup. |
| `revit-async-operations` | `.agents/skills/revit-async-operations/` | Async modeless coordination via Revit.Async (Kennan Chen). |

---

## 7. Artifact Backup and Knowledge Updating

When the developer validates that the solutions work, fixes compilation errors, or adds infrastructure support, **the agent must mandatory save the knowledge under this modular standard**:

### A. For Project Documentation (local `docs/` folder):
Classify in specific folders of the project under development:
- `docs/references/`: `walkthrough.md`, `implementation_plan.md` files, and resolved error reports.
- `docs/assets/`: Base templates or generated configurations.
- `docs/scripts/`: Local automation scripts.

*Naming Pattern:* `[artifact_type]_[YYYYMMDD]_[brief_description].md` (e.g. `walkthrough_20260529_my_new_feature.md`)

### B. For Global Skills Repository (`.agents/skills/` folder):
Never bloat the main `SKILL.md` file (which acts only as an index). Distribute the knowledge as follows:
1.  **`assets/` (Reusable Code):** Save code snippets, wrappers, and utility classes in their corresponding native extensions (e.g., `Helper.cs` for C#, `script.py` for pyRevit, `installer.wxs` for XML). **Never inject massive code blocks into Markdown files**.
2.  **`references/` (Rules and Debugging):**
    *   Design guides and API explanations go in specific `.md` files.
    *   **Debugging Log (Lesson Learned):** If you solve a complex Revit, C#, or Python bug, write a quick report at the path `.agents/skills/[skill-name]/references/debugging_[problem]_[YYYY-MM-DD].md` detailing the failure, the root cause, and the code snippet that solved it.
3.  **`scripts/` (Operational Scripts):** Executable automation scripts in PowerShell or Python.
