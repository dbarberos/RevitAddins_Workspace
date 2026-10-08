# Walkthrough: Revit Add-in Reverse Engineering & Clean-Room Reconstruction Skill

> **Date:** 2026-10-08  
> **Component:** `.agents/skills/revit-addin-reverse-engineering/`  
> **Status:** Deployed & Verified

---

## 1. Summary of Changes

A new specialized skill, `revit-addin-reverse-engineering`, was engineered and integrated into the repository to adapt the methodology of **REA (Reverse Engineer Anything)** for Revit add-ins.

This skill equips agents with a systematic 5-phase clean-room protocol whenever the developer supplies a compiled binary (`.dll`, `.addin`, `.msi`), a reference draft in `references_examples/`, or an external bundle to create a modern clone or extract specific functionality.

---

## 2. Implemented Assets & Documentation

### A. Core Skill Definition
- [SKILL.md](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-addin-reverse-engineering/SKILL.md): Master semantic index declaring the 5-phase pipeline, activation triggers, and strict operational constraints.

### B. Technical Guides (`references/`)
- [reverse_engineering_workflow.md](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-addin-reverse-engineering/references/reverse_engineering_workflow.md): Deep-dive into each phase:
  1. *Reconnaissance*: Manifest parsing, entry point cataloging.
  2. *Targeted Evidence*: Querying only write transactions, schemas, and math without context bloat.
  3. *Architectural Abstraction*: Creating pure domain DTOs and sequence diagrams.
  4. *Clean-Room Reconstruction*: Authoring C# 12 / MVVM code from scratch using FilterPlus Fluent cards.
  5. *Delta Engineering*: Injecting resilience (`WarningSwallower`, `Revit.Async`) and custom feature enhancements.
- [dotnet_revit_decompilation_guide.md](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-addin-reverse-engineering/references/dotnet_revit_decompilation_guide.md): Reference manual on .NET 4.8 vs .NET 8 decompilation, BAML extraction from `.g.resources`, Extensible Storage schema reconstruction, parameter mapping, and deobfuscation.
- [clean_room_cloning_and_compliance.md](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-addin-reverse-engineering/references/clean_room_cloning_and_compliance.md): Legal boundaries protecting the clean-room process (Directive 2009/24/EC, US Fair Use, idea vs expression dichotomy), DRM anti-circumvention rules, and modernization principles.

### C. Assets & Templates (`assets/`)
- [clean_room_blueprint_template.md](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-addin-reverse-engineering/assets/clean_room_blueprint_template.md): Standardized blueprint document filled in during Phase 3 before writing code.

### D. Operational Tooling (`scripts/`)
- [inspect-revit-assembly.ps1](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-addin-reverse-engineering/scripts/inspect-revit-assembly.ps1): PowerShell script that inspects any Revit DLL in memory (by byte-array reading to prevent file locks) and extracts:
  - Assembly Identity, Version, Target Framework.
  - Referenced Revit API assemblies and versions.
  - Application entry points (`IExternalApplication`, `ExternalApplication`).
  - Command entry points (`IExternalCommand`, `Cmd*`, `ExternalCommand`).
  - Modeless event handlers (`IExternalEventHandler`) and updaters (`IUpdater`).
  - Embedded BAML and image resources.
  - Formats output in human-readable console tables or structured JSON (`-OutputJson`).

### E. Global Rule Integration
- Registered in [AGENTS.md](file:///b:/REVIT/C%23/RevitAddins_Workspace/AGENTS.md):
  - Added clean-room reverse engineering gate to Section 6.1.
  - Registered `revit-addin-reverse-engineering` in Section 6 Available Skills table.

---

## 3. Verification & Test Execution

The inspection script was executed against the production build of `TablePlus.dll`:

```powershell
powershell -ExecutionPolicy Bypass -File ".agents\skills\revit-addin-reverse-engineering\scripts\inspect-revit-assembly.ps1" -AssemblyPath "TablePlus\bin\Release.R24\TablePlus.dll"
```

**Results:**
- Correctly parsed target framework: `.NETFramework,Version=v4.8`.
- Detected 428 types and Revit API references (`RevitAPI 24.3.60.0`, `RevitAPIUI 24.3.60.0`).
- Successfully identified entry application: `TablePlus.Application`.
- Successfully identified commands: `TablePlus.CmdImportTable`, `TablePlus.CmdAddTableDirect`.
- Discovered embedded resource: `TablePlus.g.resources`.
- Executed cleanly in < 3 seconds without file locks or unmanaged module crashes.
