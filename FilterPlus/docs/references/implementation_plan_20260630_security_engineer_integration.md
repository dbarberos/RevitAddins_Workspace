# Integration of Security Engineer Skill in Global Agent Instructions

This plan integrates the `security-engineer` skill into the core agent instructions (`AGENTS.md`) as a **Final Quality Gate**. This ensures that security audits, input validation, encryption of secrets, and secure transactions are reviewed right after compilation/reloading, before completing any development task.

## Analysis of the Approach

Structuring the security checks as a **Final Quality Gate** is highly effective because:
1. **Focus & Speed:** It allows the agent to focus first on implementing business logic and satisfying functional requirements without overhead.
2. **Holistic View:** It runs audits over the complete, unified diff of changes, making it easier to spot security loopholes (e.g. data flows from WPF to DB, unencrypted settings, transaction wrapping) that might be missed during partial edits.
3. **Formal Validation:** It establishes a clear, mandatory check before the agent finishes its work, preventing features from being delivered without security hardening.

## Proposed Changes

### Component: Meta-Instructions (RevitAddins Workspace)

---

#### [MODIFY] [AGENTS.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/AGENTS.md)

1. **Section 5 (Generation Flows)**:
   - Update the ASCII flow diagram to show both Flow A (C#) and Flow B (Python) converging into a final step: **6. SECURITY AUDIT & HARDENING**.
   - Add a detailed explanation of **Step 6** below the diagram, specifying the key checkpoints from the `security-engineer` skill:
     - Zero-Trust file and data access checks.
     - Secrets/config DPAPI encryption.
     - Input validation and exception leakage prevention.
     - Revit transaction safety.
2. **Section 6 (Available Skills)**:
   - Add the `security-engineer` skill pointing to `.agents/skills/security-engineer/` to the table of available skills.

## Verification Plan

### Manual Verification
1. Verify `AGENTS.md` is successfully modified.
2. Confirm the ASCII diagram is correctly aligned and formatted.
3. Validate that the security-engineer skill reference points to the correct local skill directory.
