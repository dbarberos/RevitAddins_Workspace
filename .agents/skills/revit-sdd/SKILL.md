---
name: revit-sdd
description: Spec-Driven Development (SSD/SDD) methodology for Autodesk Revit Add-ins. Enforces constitution, EARS specifications, clinical Revit API QA, technical architecture plans, atomic task breakdowns, and phase-gate reviews.
---

# Revit Spec-Driven Development (SSD) Master Skill

This skill defines the standardized Spec-Driven Development (SSD) workflow for creating new Autodesk Revit add-ins and implementing new features within existing add-ins.

---

## 1. Core Principles

1. **Specification Precedes Code**: Never write production code, UI dialogs, or Revit API commands without an approved `spec.md`, `plan.md`, and `tasks.md`.
2. **Repository Bible (`AGENTS.md`)**: All technical constraints in [AGENTS.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/AGENTS.md) and [docs/constitution.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/docs/constitution.md) take precedence.
3. **Reference Projects Policy (`references_examples/`)**:
   - Working code in `references_examples/` is strictly **read-only**.
   - Use it to extract functional patterns, filters, and transaction models.
   - **Discard legacy UI**: Always replace draft interfaces with our project's custom WPF/MVVM design system (FilterPlus modern card-based theme, dark/light theme adaptation, inline resources, UI virtualization).
4. **Mandatory Phase Gates**: Stop and request user review of each generated markdown document before advancing to the subsequent phase.
5. **The Golden Rule**: When requirements change, update `spec.md` and `plan.md` first before modifying any source code.

---

## 2. Directory Hierarchy

```text
[AddInName]/
├── docs/
│   └── constitution.md              # Domain-specific constitution extending global rules
├── specs/
│   └── 001-[feature-name]/
│       ├── spec.md                  # WHAT & WHY (EARS functional requirements RF-1..RF-n)
│       ├── plan.md                  # HOW (Architecture, Ribbon, Transactions, MVVM)
│       └── tasks.md                 # STEP-BY-STEP (Atomic microtasks T1..Tn with [ ])
├── src/                             # Production source code
└── tests/                           # Decoupled unit tests
```

---

## 3. Workflow Phases & Assets

### Phase 1: Local Constitution
- Create `[AddInName]/docs/constitution.md` using [constitution-template.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-sdd/assets/constitution-template.md).
- Tailor rules to the add-in's domain and draft patterns identified in `references_examples/`.
- 🛑 **Phase Gate 1**: Pause and obtain user validation.

### Phase 2: Clinical Boundary Questionnaire (Up to 10 Questions)
Formulate up to 10 clinical questions covering:
- Element parameter existence (BuiltInParameter vs Shared).
- Document read-only or family document mode (`doc.IsFamilyDocument`).
- Worksharing and element borrowing (`WorksharingUtils.CheckoutElements`).
- Selection scope (active view, selection set, entire model, linked models).
- Coordinate systems and link transformations (`CreateLinkReference`).
- Internal imperial units vs ForgeTypeId metric units.
- Non-fatal warning suppression (`WarningSwallower`).
- Modeless async coordination (`Revit.Async` / `ExternalEventBridge`).
- Transaction rollback and undo granularity (`TransactionGroup`).
- Cancellation handling in batch operations.

### Phase 3: EARS Specification
- Create `specs/00X-[feature-name]/spec.md` using [spec-template.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-sdd/assets/spec-template.md).
- Use EARS syntax (Ubiquitous, Event-driven, State-driven, Unwanted behavior, Optional).
- Define Acceptance Criteria (AC-1..AC-n) mapped 1:1 to Functional Requirements (RF-1..RF-n).
- 🛑 **Phase Gate 2**: Pause and obtain user validation.

### Phase 4: Revit API QA Review
- Audit `spec.md` as a senior Revit API QA engineer.
- Ensure unmanaged geometry is disposed, transactions are scoped, and no modal dialogs are called from background tasks.

### Phase 5: Technical Architecture Plan
- Create `specs/00X-[feature-name]/plan.md` using [plan-template.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-sdd/assets/plan-template.md).
- Detail `IExternalCommand`, Ribbon UI placement, `Transaction` scope, decoupled `Services` & `Models`, and WPF MVVM architecture.
- 🛑 **Phase Gate 3**: Pause and obtain user validation.

### Phase 6: Atomic Tasks Breakdown
- Create `specs/00X-[feature-name]/tasks.md` using [tasks-template.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-sdd/assets/tasks-template.md).
- Deconstruct the technical plan into 20–30 minute microtasks (T1..Tn) with checkboxes `[ ]` tied to requirements.
- 🛑 **Phase Gate 4**: Pause and obtain user validation.

### Phase 7: Controlled Implementation
- Execute one task at a time.
- Verify task completion and mark checkbox `[x]`.
- Verify all Acceptance Criteria against `spec.md`.

---

## 4. Templates Reference

- [constitution-template.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-sdd/assets/constitution-template.md)
- [spec-template.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-sdd/assets/spec-template.md)
- [plan-template.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-sdd/assets/plan-template.md)
- [tasks-template.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-sdd/assets/tasks-template.md)

---

## 5. Artifact Archiving & Continuous Traceability (`docs/references/`)

In strict accordance with Section 7.A of [AGENTS.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/AGENTS.md):
1. **Milestone Snapshots**: Whenever a major logical milestone or task block is completed (e.g., Backend Engine completed, ViewModel & UI completed, or upon user request), the agent MUST export/snapshot the active session's `walkthrough.md` and/or `implementation_plan.md` into the target add-in's `docs/references/` folder.
2. **Naming Convention**: `[AddIn]/docs/references/[artifact_type]_[YYYYMMDD]_[spec_id]_[description].md`
   - Example: `TablePlus/docs/references/implementation_plan_20260922_001_excel_vector_import.md`
   - Example: `TablePlus/docs/references/walkthrough_20260923_001_excel_vector_import_t1_t5.md`
3. **Phase 8 Final Archiving**: Upon completing all tasks (`T1..Tn`) and validating all Acceptance Criteria (`AC-1..AC-n`), the final complete `walkthrough_[YYYYMMDD]_[spec_id].md` and `implementation_plan_[YYYYMMDD]_[spec_id].md` MUST be archived in `[AddIn]/docs/references/` and committed to Git before closing the feature.
