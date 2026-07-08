# Walkthrough: Security Engineer Integration as Final Quality Gate

I have integrated the `security-engineer` skill into the global agent instructions (`AGENTS.md`) as a mandatory **Final Quality Gate** for both C# compiled add-ins and Python scripting flows.

## Changes Made

### 1. Global Agent Rules (`AGENTS.md`)
- **[AGENTS.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/AGENTS.md)**:
  - Updated the ASCII flow diagram under **5. Generation Flows** to show both C# compiled and Python scripting flows converging into a final step: **6. SECURITY AUDIT & HARDENING**.
  - Added a detailed description of **Step 6** detailing the mandatory security reviews from the `security-engineer` skill, including:
    - **Zero-Trust File Access**: Enforcing input sanitization to prevent Path Traversal.
    - **Vault Encryption**: Using DPAPI (`ProtectedData`) to encrypt configs and secrets.
    - **Input Validation**: Sanitizing WPF/TaskDialog textbox inputs to block injection/XXE.
    - **Safe Serialization**: Using `System.Text.Json` or disabling `TypeNameHandling` in Newtonsoft.Json.
    - **Secure Exception Logging**: Preventing raw StackTrace leakage in UI dialogs.
    - **Transaction Safety**: Ensuring all Revit API transactions use `using` blocks.
  - Cataloged the `security-engineer` skill under the **6. Available Skills** table.

---

## Verification & Testing
- Checked that `AGENTS.md` is well-formatted and all links to `.agents/skills/security-engineer/` are functional.
- This integration makes the security checks a native, automated part of the development cycle, ensuring future changes are audited by default.
