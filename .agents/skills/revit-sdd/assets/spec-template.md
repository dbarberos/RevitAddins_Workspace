# Specification: [Feature Name]

**Spec ID:** `[00X]`  
**Target Add-in:** `[AddInName]`  
**Feature Branch:** `[branch-name]`  
**Author / Architect:** SDD Architect  
**Status:** DRAFT | APPROVED | IMPLEMENTED  
**Date:** `[YYYY-MM-DD]`  

---

## 1. Context & Business Value

[Provide a high-level overview of what this feature does, why it is needed, and the value it delivers to the BIM manager / Revit user.]

---

## 2. Reference Project Findings (`references_examples/`)

- **Reference Analyzed:** `references_examples/[DraftFolderName]/`
- **Reused Logic & Patterns:** [Describe the specific collector routines, math calculations, or Revit API methods identified.]
- **Discarded / Replaced Components:** [List any legacy UI dialogs, obsolete libraries, or deprecated API calls being replaced.]

---

## 3. Clinical Boundary Questionnaire Resolutions

[Record the answers to the clinical questions formulated during Phase 2 to eliminate edge cases:]

1. **Parameter Existence:** [Behavior when elements lack required parameters.]
2. **Document State:** [Behavior when document is Read-Only or Family Document.]
3. **Worksharing & Borrowing:** [Checkout / Borrowing strategy in workshared models.]
4. **Target Scope:** [Active view only, user pre-selection, entire model, or linked documents.]
5. **Coordinate Systems:** [Handling of survey/base points or linked coordinates.]
6. **Units & Precision:** [Internal imperial vs localized metric unit conversion.]
7. **Failure Preprocessing:** [Benign warning suppression via WarningSwallower.]
8. **UI Modality & Threading:** [Modal ShowDialog() vs Modeless Revit.Async.]
9. **Transaction Granularity:** [Single transaction, subtransactions, or transaction group.]
10. **Cancellation & Rollback:** [User cancellation behavior and state cleanup.]

---

## 4. Functional Requirements (EARS Notation)

Requirements must use EARS (Easy Approach to Requirements Syntax):

- **RF-1 (Ubiquitous):** The add-in shall [action].
- **RF-2 (Event-driven):** When [user clicks button / event fires], the add-in shall [action].
- **RF-3 (State-driven):** While [window is open / selection exists], the add-in shall [action].
- **RF-4 (Unwanted behavior):** If [invalid input / missing parameter], then the add-in shall [safe fallback / log message].
- **RF-5 (Optional):** Where [advanced checkbox is checked], the add-in shall [action].

---

## 5. Acceptance Criteria (AC)

- [ ] **AC-1 (matches RF-1):** [Verifiable condition with expected result].
- [ ] **AC-2 (matches RF-2):** [Verifiable condition with expected result].
- [ ] **AC-3 (matches RF-3):** [Verifiable condition with expected result].
- [ ] **AC-4 (matches RF-4):** [Verifiable condition with expected result].
- [ ] **AC-5 (matches RF-5):** [Verifiable condition with expected result].

---

## 6. Out of Scope (Non-Goals)

- [Explicitly list features, edge cases, or platforms not covered in this specification.]
