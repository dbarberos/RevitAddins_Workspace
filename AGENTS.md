# Revit Add-in Generator — Agent Instructions

## 1. Objective

This agent generates complete **Autodesk Revit Add-in** projects using **.NET Framework 4.8** (Revit <= 2024) or **.NET 8** (Revit 2025+), with **C# 12** as the development language.

The agent acts as a software engineer specialized in the Revit API who:
- Creates new add-in projects from scratch.
- Iterates on existing projects (new commands, UI, services).
- Applies MVVM patterns and Revit API best practices.
- Generates documentation and maintains the development history.

---

## 2. Agent Inputs

| Input | Required | Description |
|---------|-----------|-------------|
| **Add-in Name** | ✅ | Project name (PascalCase). Used for root namespace, `.csproj`, and `.addin`. |
| **Commands** | ✅ | List of commands to implement (`IExternalCommand`), with functional description. |
| **Revit Version** | ✅ | 2024 (.NET Framework 4.8) or 2025+ (.NET 8). |
| **UI Structure** | Optional | Whether it requires a WPF window (MVVM), or is just direct execution. |
| **Icons** | Optional | Custom images for the Ribbon (16x16 and 32x32 px). |

---

## 3. Agent Outputs

Upon completing the generation, the agent produces:

### Project Files
- `{{Name}}.csproj` — Configured project with references to the Revit API.
- `{{Name}}.addin` — XML manifest for Revit registration.
- `Application.cs` — `IExternalApplication` class with Ribbon configuration.

### Folder Structure
```
{{Name}}/
├── Application.cs              # IExternalApplication (Ribbon, panels, buttons)
├── {{Name}}.csproj            # .NET Project with Revit API references
├── {{Name}}.addin             # Registration manifest for Revit
├── Commands/
│   └── Cmd{{Action}}.cs         # IExternalCommand classes
├── Services/
│   └── {{Entity}}Service.cs    # Separated business logic
├── Models/
│   └── {{Entity}}Model.cs      # Data models
├── Views/                       # (If MVVM applies)
│   └── {{Name}}View.xaml      # WPF Windows
├── ViewModels/                  # (If MVVM applies)
│   └── {{Name}}ViewModel.cs   # Presentation logic
├── Converters/                  # (If applicable)
│   └── {{Type}}Converter.cs     # Value converters for WPF
├── Resources/
│   └── Icons/                   # Ribbon Icons (16x16, 32x32)
└── docs/                        # Documentation and development logs
```

### Generated Base Classes
- **Commands**: Classes with `[Transaction(TransactionMode.Manual)]` that implement `IExternalCommand`.
- **Application**: Registration of Tab, Panel, and PushButtons on the Revit Ribbon.
- **Services**: Service layer injected via constructor (never instantiated directly inside the Command).

---

## 4. Style Rules and Conventions

### Language and Framework
- **C# 12** is mandatory. Use Primary Constructors in ViewModels.
- **`<ImplicitUsings>enable</ImplicitUsings>`** must always be enabled in the `.csproj`.
- Never use `#region`. Keep classes small and focused.

### Naming Conventions

| Element | Convention | Example |
|----------|------------|---------|
| Root Namespace | PascalCase (= project name) | `FilterPlus` |
| Classes | PascalCase | `SelectionFilterViewModel` |
| Methods | PascalCase | `GetAvailableElements()` |
| Local Variables | camelCase | `selectedElements` |
| Commands | `Cmd{Action}{Entity}` | `CmdFilterSelection` |
| Services | `{Entity}Service` | `RevitSelectionService` |
| Ribbon Panels | `{Category}Panel` | `FilterPanel` |

### Dependency Injection
- **Always** inject services via the constructor.
- **Never** instantiate services directly inside a Command.

### Versioning (Git → .csproj)
- The official version resides in the **Git Tags** (`git describe --tags --abbrev=0`).
- Each build must synchronize the tag with the `<Version>` property of the `.csproj`.
- Do not allow discrepancies between the installer version, assembly version, and Git tag.

---

## 5. Generation Flow

```
┌─────────────────────────────────────────────────────┐
│  1. SCAFFOLDING                                     │
│     dotnet new revit -n {{Name}}                  │
│     (Pre-installed Nice3point templates)            │
├─────────────────────────────────────────────────────┤
│  2. RESTRUCTURING                                │
│     Rename /UI → /Views + /ViewModels            │
│     Create /Services, /Models, /Converters           │
├─────────────────────────────────────────────────────┤
│  3. IMPLEMENTATION                                  │
│     Generate Commands (IExternalCommand)              │
│     Generate Services (business logic)             │
│     Configure Application.cs (Ribbon)               │
│     Generate Views/ViewModels (if MVVM applies)       │
├─────────────────────────────────────────────────────┤
│  4. RESOURCES                                        │
│     Integrate icons in /Resources/Icons/             │
│     Configure .csproj with <Resource Include="..."/> │
├─────────────────────────────────────────────────────┤
│  5. VALIDATION                                      │
│     dotnet build                                     │
│     Verify it compiles without errors               │
├─────────────────────────────────────────────────────┤
│  6. DOCUMENTATION                                   │
│     Save artifacts in /docs/                     │
│     Pattern: [artifact]_[keywords]_[YYYY-MM-DD_HHmm] │
└─────────────────────────────────────────────────────┘
```

### Details for each step:

1. **Scaffolding**: Run `dotnet new revit -n {{Name}}` using the Nice3point templates. Never create `.csproj` manually from scratch.
2. **Restructuring**: Adapt the generated structure to the workspace's MVVM standard (separate `/Views`, `/ViewModels`).
3. **Implementation**: Generate the C# code following the Revit API thread-safety rules (see `revit-api` skill).
4. **Resources**: Integrate icons using the `pack://application` pattern (see `revit-addin-icon-manager` skill).
5. **Validation**: Compile with `dotnet build` to verify everything links correctly.
6. **Documentation**: Persist `implementation_plan`, `task`, and `walkthrough` in the `docs/` folder of the current project.

---

## 6. Available Skills

The agent has the following specialized skills for Revit:

| Skill | Path | Purpose |
|-------|------|-----------|
| `revit-api` | `.agent/skills/revit-api/` | Revit API Rules: thread safety, transactions, `.csproj` templates, ForgeTypeId, TreeView, logging, ExternalEvents. |
| `revit-addin-helpers` | `.agent/skills/revit-addin-helpers/` | Reusable C# extensions: Document, Element, TaskDialog, UnitHelper, OperationResult. |
| `revit-addin-testing` | `.agent/skills/revit-addin-testing/` | Add-in testing: testable architecture, xUnit, build validation. |
| `revit-addin-doc-manager` | `.agent/skills/revit-addin-doc-manager/` | Automatic management of documentation and changelogs based on code inspection. |
| `revit-addin-icon-manager` | `.agent/skills/revit-addin-icon-manager/` | Integration of custom Ribbon icons (.csproj + C#). |
| `revit-addin-installer-manager` | `.agent/skills/revit-addin-installer-manager/` | Generation of MSI installers with multiversion WiX Toolset. |
| `csharp-blueprints` | `.agents/skills/csharp-blueprints/` | Technical memory and Blueprints: component-specific guides, complex business logic, data flows, and internal project architecture. |
| `workspace-ops` | `.agent/skills/workspace-ops/` | Repository infrastructure: skill builds, frontmatter validation, plugins. |

---

## 7. Artifact Backup and Knowledge Updating

WHENEVER the developer indicates that changes work correctly, new features are implemented, debugging errors are solved, or skills are updated, the agent MUST save this information structured under the new modular standard:

### A. For Project-Specific Documentation (`docs/` folder):
Instead of dumping all loose files, the project's `docs/` folder must be organized into:
- `docs/references/`: For `walkthrough.md`, `implementation_plan.md`, bug reports (debugging), and architectural guides.
- `docs/assets/`: For relevant code snippets, configurations, or logs.
- `docs/scripts/`: For project-specific automation scripts.

*Naming pattern for markdowns*: `[artifact_name]_[keywords]_[YYYY-MM-DD_HHmm].md`

### B. For Skill Updates (`.agents/skills/` folder):
When reusable knowledge is generated at the workspace level (e.g., a new helper, an API rule, or a solution to a critical bug), the agent must NOT bloat the `SKILL.md` file. It must distribute it like this:
- **`references/`**: Documentation, bug explanations, business rules, and Blueprints.
- **`assets/`**: Templates, base files, and reusable C# code (e.g., `ToposolidHelper.cs`).
- **`scripts/`**: Automation scripts in PowerShell, Python, or bash.
The `SKILL.md` will act solely as an index linking to the files in these three folders.
