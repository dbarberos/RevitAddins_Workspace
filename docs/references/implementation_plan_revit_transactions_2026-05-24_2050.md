# Integration of `revit-transactions` Skill

The management of Transactions is critical in the Revit API to avoid model corruption or unhandled exceptions. To comply with your request, we will create a dedicated skill to govern transaction rules universally for both **C# (Compiled Add-ins)** and **Python (pyRevit / RPS)**.

## Proposed Changes

### `revit-transactions` Skill Folder
I will create the new directory: `b:\REVIT\C#\RevitAddins_Workspace\.agents\skills\revit-transactions\`

#### [NEW] `b:\REVIT\C#\RevitAddins_Workspace\.agents\skills\revit-transactions\SKILL.md`
The master index file. It will define the mandatory routing: "If the agent is modifying the `Document` (creating, deleting, modifying elements), it MUST consult this skill."

#### [NEW] `b:\REVIT\C#\RevitAddins_Workspace\.agents\skills\revit-transactions\references\transaction_rules.md`
A deep technical guide divided into two domains (C# and Python):

**For C# (Add-ins & ViewModels):**
- **Strict Rule:** Always use `using (Transaction tx = new Transaction(doc, "Name"))` to ensure `Dispose()` is called even if an exception occurs.
- **SubTransactions:** Explain that if a method is called from within an existing transaction context (like an External Event that already started a transaction), the code MUST use `SubTransaction` or check `doc.IsModifiable` before starting a new `Transaction`.

**For Python (pyRevit / RPS):**
- **pyRevit Wrapper:** Strongly enforce the use of pyRevit's context manager:
  ```python
  from pyrevit import revit
  with revit.Transaction("Operation Name"):
      # Logic
  ```
- **Nested Contexts (SubTransactions):** If operating inside a pyRevit script or UI button that already handles transactions globally, teach the agent how to manage `SubTransaction` to isolate rollbacks without failing the parent transaction.

#### [NEW] `b:\REVIT\C#\RevitAddins_Workspace\.agents\skills\revit-transactions\assets\TransactionTemplates.cs`
- C# boilerplate for standard `using` transactions and safe `SubTransaction` blocks.

#### [NEW] `b:\REVIT\C#\RevitAddins_Workspace\.agents\skills\revit-transactions\assets\transaction_templates.py`
- Python boilerplate for pyRevit context managers and pure IronPython `SubTransaction` handling.

## Integration
I will also inject a cross-reference in our `revit-api` and `revit-pyrevit-python` skills to explicitly point to this new centralized knowledge base.

## User Review Required
> [!IMPORTANT]
> Do you approve this architecture for the `revit-transactions` skill? Once approved, I will generate the structure in English (for token optimization) and link it across your workspace.
