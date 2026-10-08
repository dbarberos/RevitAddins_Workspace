# Implementation Plan: Revit Add-in Reverse Engineering & Clean-Room Cloning Skill

> **Date:** 2026-10-08  
> **Target Skill:** `.agents/skills/revit-addin-reverse-engineering/`  
> **Inspiration:** REA (Reverse Engineer Anything - https://github.com/morluto/rea)  
> **Status:** Completed & Validated

---

## 1. Goal & Architectural Purpose

Transfer the core reverse engineering intelligence of the **REA** project into a specialized, production-ready skill for the Autodesk Revit ecosystem. 

Enable AI agents to inspect compiled add-in binaries (`.dll`, `.addin`, `.msi`), pyRevit extensions, or decompiled reference drafts (e.g. in `references_examples/`), extract their business logic and Revit database operations through targeted evidence collection, and reconstruct superior **clean-room clones** adhering strictly to C# 12, MVVM, and the repository's FilterPlus design system without violating copyright or copying legacy anti-patterns.

---

## 2. Core Methodological Requirements

1. **Zero Context Bloat (Targeted Evidence):**
   - Never dump entire decompiled assemblies into LLM context.
   - Use targeted queries: catalog entry points (`IExternalApplication`, `IExternalCommand`), then query only specific transaction methods, Extensible Storage schemas, or geometric algorithms.

2. **Clean-Room Boundary:**
   - Reference code is strictly read-only.
   - Separate the extraction of *ideas/procedures* (functional specification) from *expression* (syntax).
   - Decompiled code produces an architectural blueprint (`clean_room_blueprint_template.md`), never copied lines.

3. **Modernization & Superiority (Delta Engineering):**
   - Discard legacy WinForms or archaic WPF code-behinds.
   - Rebuild views using FilterPlus modern card-based Fluent design system with inline resources.
   - Inject repository resilience: `WarningSwallower` (`IFailuresPreprocessor`), `Revit.Async` modeless dispatch, and parameter pool management.

4. **Self-Sufficient Inspection Tooling:**
   - Implement an automated PowerShell inspection utility (`inspect-revit-assembly.ps1`) that reads assembly metadata and PE string heaps without locking DLLs on disk and without failing due to missing native Revit C++ dependencies.

---

## 3. Atomic Breakdown & Deliverables

| Deliverable | Location | Purpose |
|---|---|---|
| **Semantic Index** | `SKILL.md` | Skill metadata, 5-phase pipeline diagram, and operating rules. |
| **Workflow Guide** | `references/reverse_engineering_workflow.md` | Detailed step-by-step procedure across Reconnaissance, Evidence, Abstraction, Rebuild, and Delta Engineering. |
| **Decompilation Guide** | `references/dotnet_revit_decompilation_guide.md` | Technical procedures for .NET 4.8 / .NET 8, BAML recovery, Extensible Storage schemas, and deobfuscation. |
| **Legal & Compliance Guide** | `references/clean_room_cloning_and_compliance.md` | Legal boundary (Idea vs Expression, Directive 2009/24/EC, Fair Use), DRM prohibition, and anti-plagiarism gates. |
| **Blueprint Template** | `assets/clean_room_blueprint_template.md` | Standardized markdown template for Phase 3 architectural specification. |
| **Assembly Inspector** | `scripts/inspect-revit-assembly.ps1` | Resilient PowerShell script to catalog Revit commands, applications, references, and resources. |
| **Agent Gate & Index** | `AGENTS.md` | Clean-room reverse engineering gate added to Section 6.1 and registered in Section 6 skills table. |

---

## 4. Verification & Testing

- [x] Run `inspect-revit-assembly.ps1` on `TablePlus.dll` (Release.R24):
  - Verified detection of `TablePlus.Application`.
  - Verified detection of `CmdImportTable` and `CmdAddTableDirect`.
  - Verified detection of embedded `TablePlus.g.resources`.
  - Verified non-locking byte-array memory loading.
- [x] Test `-OutputJson` switch for structured automated consumption.
- [x] Validate against repository skill frontmatter and structure standards.
