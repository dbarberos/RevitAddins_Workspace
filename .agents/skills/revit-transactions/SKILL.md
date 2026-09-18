---
name: revit-transactions
description: Master skill for managing Autodesk Revit Transactions in C# and Python. Enforces the strict use of `using` blocks, SubTransactions for nested contexts, and pyRevit's `revit.Transaction` wrapper to prevent database corruption.
---

# Revit Transaction Management Guide

## Purpose
Modifying the Revit model (`Document`) requires an active `Transaction`. Failing to correctly open, commit, or rollback transactions will cause critical crashes, corrupt the Revit file, and leave unmanaged C++ memory leaking. This skill ensures strict transaction discipline across the dual-stack (C# and Python).

## Mandatory Rules (Universal)
- **Modifiable Check**: Always verify if you need a transaction. Do not open a transaction if you are only *reading* data (e.g., using `FilteredElementCollector`).
- **One Context Rule**: You cannot start a `Transaction` if the document is already in a modifiable state (e.g., inside an event that already opened one). You must use `SubTransaction` instead.

## Mandatory Rules (C# Add-ins)
- **`using` Block Requirement**: You **MUST** wrap every `Transaction` or `SubTransaction` instantiation inside a `using` block to guarantee the `Dispose()` method is called even if an exception occurs.
- **Thread Context Restriction**: It is strictly forbidden to open or start a `Transaction` directly from a WPF / Modeless UI thread (e.g., inside WPF Button Click events or VM RelayCommands). You **MUST** raise an `ExternalEvent` (via `IExternalEventHandler`) to execute the database transaction safely on the main Revit API thread.


## Mandatory Rules (Python / pyRevit)
- **Context Manager Requirement**: You **MUST** use the `with` statement.
- **pyRevit API**: Use `from pyrevit import revit` and `with revit.Transaction("Name"):`. This automatically handles commit/rollback and UI refreshing.

## References
- [Transaction Architecture & Rules](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-transactions/references/transaction_rules.md): Deep dive into `using`, nested contexts, and SubTransactions.
- [Unit System & Bridge Document Copying Debugging](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-transactions/references/debugging_revit_unit_system_and_bridge_document_2026-07-17.md): Resolving read-only link transactions and unit system mismatches when copying elements with suffix.

## Assets
- [TransactionTemplates.cs](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-transactions/assets/TransactionTemplates.cs): C# Boilerplate.
- [TransactionScopeManager.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-transactions/assets/TransactionScopeManager.cs): Reusable transaction and transaction group execution scope wrapper.
- [transaction_templates.py](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-transactions/assets/transaction_templates.py): Python/pyRevit Boilerplate.
