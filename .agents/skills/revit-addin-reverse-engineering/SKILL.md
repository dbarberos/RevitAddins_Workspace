---
name: revit-addin-reverse-engineering
description: Reverse engineering, decompilation analysis, and clean-room reconstruction methodology for Autodesk Revit add-ins and platforms (.NET assemblies, pyRevit scripts, C++ DLLs). Use when analyzing an existing add-in binary, reference draft in references_examples/, or external bundle to extract functionality, reverse-engineer transactions, parameters, and algorithms, and reconstruct a modernized clean clone adhering to C# 12 MVVM and repository standards.
---

# Revit Add-in Reverse Engineering & Clean-Room Reconstruction Skill

This skill operationalizes the **REA (Reverse Engineer Anything)** methodology tailored specifically for the Autodesk Revit add-in ecosystem (.NET Framework 4.8, .NET 8 CoreCLR, pyRevit, and native C++ binaries).

It guides the agent when the developer provides an existing compiled add-in, a reference draft in `references_examples/`, or an external `.dll`/`.msi`/bundle to study its behavior, extract its business logic and Revit API transactions, and **reconstruct a superior, clean-room clone** adhering to the repository's C# 12, MVVM, and UI design standards.

---

## 1. When to Use This Skill
- **Reference Draft Analysis**: When the user provides a reference add-in in `references_examples/` (e.g. DiRoots, BimFM, Table/Sheet tools) or an external path to a `.dll`/`.addin`/`.bundle`.
- **Feature Reverse Engineering**: When asked to investigate: *"How does this add-in perform X?"*, *"Extract how this add-in handles parameter binding, licensing, or geometry"*, or *"Analyze this binary and create a clone with our custom changes"*.
- **Decompilation & IL Analysis**: When examining decompiled C# code, BAML/XAML resources, Extensible Storage schemas, or obfuscated symbols.
- **Clean-Room Cloning**: When creating an equivalent, modernized add-in without copying proprietary spaghetti or infringing copyright.

---

## 2. The 5-Phase Clean-Room Reconstruction Pipeline

```text
┌─────────────────────────────────────────────────────────────────────────────┐
│ 1. RECONNAISSANCE (Zero Context Overflow)                                   │
│    Inspect manifest (.addin), Ribbon layout, entry points, and dependencies. │
└──────────────────────────────────────┬──────────────────────────────────────┘
                                       │
┌──────────────────────────────────────▼──────────────────────────────────────┐
│ 2. TARGETED EVIDENCE COLLECTION                                             │
│    Decompile ONLY relevant methods (DB transactions, geometry, UI state).   │
└──────────────────────────────────────┬──────────────────────────────────────┘
                                       │
┌──────────────────────────────────────▼──────────────────────────────────────┐
│ 3. ARCHITECTURAL ABSTRACTION                                                │
│    Extract pure domain DTOs, sequence diagrams, and mathematical models.    │
└──────────────────────────────────────┬──────────────────────────────────────┘
                                       │
┌──────────────────────────────────────▼──────────────────────────────────────┐
│ 4. CLEAN-ROOM RECONSTRUCTION                                                │
│    Rewrite 100% clean C# 12 / MVVM / Nice3point code from scratch.          │
└──────────────────────────────────────┬──────────────────────────────────────┘
                                       │
┌──────────────────────────────────────▼──────────────────────────────────────┐
│ 5. DELTA ENGINEERING (Innovation & Superiority)                             │
│    Fix original flaws (memory leaks, lack of cancellation, UI freezes).     │
└─────────────────────────────────────────────────────────────────────────────┘
```

---

## 3. Strict Operating Rules

1. **Evidence-Driven Claims**: Every claim about how the reference add-in functions MUST cite hard evidence (assembly namespace, method name, or IL sequence). Never hallucinate private API behavior.
2. **References Are Strictly Read-Only**: Code in `references_examples/` or external reference paths must NEVER be modified directly.
3. **Discard Legacy UI Completely**: Never attempt to clone old WinForms or legacy WPF XAML directly. Always rebuild the UI using our repository's **FilterPlus modern card-based Fluent design system** with inline `<Window.Resources>`, dark/light adaptation, and virtualization.
4. **Clean-Room Legality**: Do not copy-paste decompiled code. Decompiled code serves only to understand the *functional specification* (idea/algorithm). The production implementation must be written completely from scratch with modern idioms (C# 12 primary constructors, pattern matching, `CommunityToolkit.Mvvm`).
5. **Architectural Hardening**: The reconstructed add-in MUST integrate repository resilience:
   - Wrap all transactions in `using var tx = new Transaction(...)` with `WarningSwallower`.
   - Modeless executions MUST dispatch via `Revit.Async` (`await RevitTask.RunAsync(...)`).
   - Prevent parameter pollution using reusable pools or Extensible Storage.

---

## 4. Technical References (`references/`)

- [references/reverse_engineering_workflow.md](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-addin-reverse-engineering/references/reverse_engineering_workflow.md): Complete phase-by-phase execution guide for analyzing and cloning add-ins.
- [references/dotnet_revit_decompilation_guide.md](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-addin-reverse-engineering/references/dotnet_revit_decompilation_guide.md): Guide on disassembling .NET Framework and .NET 8 assemblies, BAML/XAML extraction, and deobfuscation.
- [references/clean_room_cloning_and_compliance.md](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-addin-reverse-engineering/references/clean_room_cloning_and_compliance.md): Legal safeguards, clean-room boundary definitions, and anti-plagiarism guidelines.

---

## 5. Automation Scripts & Templates (`scripts/` & `assets/`)

- `scripts/inspect-revit-assembly.ps1`: Automated PowerShell utility to inspect any Revit DLL, cataloging its `IExternalCommand`, `IExternalApplication`, ribbon buttons, and Revit API calls.
- `assets/clean_room_blueprint_template.md`: Template for generating the architectural specification document before starting implementation.
