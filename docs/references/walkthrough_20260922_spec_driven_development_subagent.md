# Walkthrough: Implementation of SSD (Spec-Driven Development) System & Subagent

**Branch:** `SSD`  
**Date:** 2026-09-22  
**Scope:** Repository-wide Spec-Driven Development framework for Autodesk Revit Add-ins  
**Language:** English  

---

## 1. Summary of Changes

We implemented a comprehensive, deterministic **Spec-Driven Development (SSD / SDD)** methodology for Autodesk Revit Add-ins in the `RevitAddins_Workspace` repository. This framework establishes that all new add-ins and incremental features must be formally specified and reviewed across explicit phase gates before writing code.

---

## 2. Deliverables Created

### 1. Global Workspace Constitution
- **File:** [docs/constitution.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/docs/constitution.md)
- Establishes the 8 non-negotiable core engineering articles:
  - **Art. I**: Primacy of `AGENTS.md` and repository skills.
  - **Art. II**: Architectural decoupling & UI replacement policy for `references_examples/` drafts.
  - **Art. III**: Deterministic Revit transaction lifecycle (`using` blocks, SubTransactions, `WarningSwallower`).
  - **Art. IV**: Modeless threading context isolation (`Revit.Async` / `ExternalEventBridge`).
  - **Art. V**: WPF UI design, virtualization, and inline `<Window.Resources>` scoping.
  - **Art. VI**: Multi-version Autoloader (`SeriesMin="R202X"`), `#if REVIT2024_OR_GREATER`, and .NET 8 `AssemblyResolve`.
  - **Art. VII**: Zero-trust security, path sanitization, and DPAPI credential protection.
  - **Art. VIII**: The Golden Rule of SDD (specifications precede code).

### 2. Custom Subagent (`sdd-architect`)
- **Files:**
  - [.agents/agents/sdd-architect.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/agents/sdd-architect.md)
  - [.agents/agents/sdd-architect.agent.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/agents/sdd-architect.agent.md)
- **Features:**
  - Standard YAML frontmatter with `name`, `description`, `argument-hint`, and tools (`search`, `codebase`).
  - Structured 8-phase execution lifecycle.
  - Inquires about drafts in `references_examples/` (strictly read-only; extracts logic/API routines; replaces UI with custom FilterPlus WPF/MVVM design system).
  - Formulates up to 10 clinical questions targeting Revit API boundary conditions.
  - Enforces mandatory Phase Gates (review pauses) where the agent halts and prompts the user to inspect and validate `.md` documents before progressing.
  - Supports both new add-ins and incremental features in existing add-ins (`specs/00X-...`).

### 3. Master Skill & Standardized Markdown Templates
- **Skill:** [.agents/skills/revit-sdd/SKILL.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-sdd/SKILL.md)
- **Templates:**
  - [constitution-template.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-sdd/assets/constitution-template.md): Local add-in constitution template extending global rules.
  - [spec-template.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-sdd/assets/spec-template.md): EARS functional requirements (`RF-1..RF-n`) and Acceptance Criteria (`AC-1..AC-n`).
  - [plan-template.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-sdd/assets/plan-template.md): Technical architecture, Ribbon UI, transaction model, and decoupled contracts.
  - [tasks-template.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-sdd/assets/tasks-template.md): Atomic 20-30 minute microtasks (`T1..Tn`) with checkboxes `[ ]`.

### 4. Repository Agent Rules Registration
- **File:** [AGENTS.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/AGENTS.md)
- Registered `revit-sdd` and `revit-appstore-bundle` in the master table of available skills.

---

## 3. How to Invoke the Subagent

1. **Direct Mention in Chat**:
   ```text
   @sdd-architect I want to add an automated numbering feature to FilterPlus
   ```
   or for a new add-in:
   ```text
   @sdd-architect I want to start a new add-in called SheetPlus using the draft in references_examples/ProSheets
   ```
2. **Chat Agent Dropdown**: Select `sdd-architect` from the agent picker dropdown in the IDE chat view.
3. **Natural Conversation**: Prompt the main agent:
   ```text
   Start the SSD process for the new feature [Feature Name] in [AddInName]
   ```
