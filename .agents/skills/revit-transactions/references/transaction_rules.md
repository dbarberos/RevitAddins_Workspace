# Transaction Architecture and Rules

## 1. C# Architecture: The `using` Paradigm

The `Transaction`, `SubTransaction`, and `TransactionGroup` classes in the Revit API are wrappers around native C++ objects. If an exception is thrown before `Commit()` or `RollBack()` is called, the Revit database remains locked in a modifiable state, causing a fatal crash.

**Rule: You MUST use `using`.**
```csharp
// CORRECT
using (Transaction tx = new Transaction(doc, "Create Wall"))
{
    tx.Start();
    // Logic...
    tx.Commit();
}

// WRONG (Agent will be penalized for this)
Transaction tx = new Transaction(doc, "Create Wall");
tx.Start();
// Logic that might throw an exception
tx.Commit();
```

## 2. Nested Contexts: The `SubTransaction`

Often, a utility method or a pyRevit script is executed in a context where a parent transaction is already active (Clean Transactions). Attempting to open a `new Transaction()` when `doc.IsModifiable == true` will throw an exception.

**Rule: Use `SubTransaction` to isolate logic within an existing transaction.**
A `SubTransaction` allows you to roll back a specific chunk of work without rolling back the entire parent transaction.

```csharp
if (doc.IsModifiable)
{
    // Parent transaction exists, use SubTransaction
    using (SubTransaction subTx = new SubTransaction(doc))
    {
        subTx.Start();
        try 
        {
            // Sub logic...
            subTx.Commit();
        } 
        catch 
        {
            subTx.RollBack(); 
        }
    }
}
else
{
    // No parent transaction, use normal Transaction
    using (Transaction tx = new Transaction(doc, "Action"))
    {
        tx.Start();
        tx.Commit();
    }
}
```

## 3. Python (pyRevit) Context Managers

In pyRevit, the `pyrevit.revit` module provides a powerful `Transaction` context manager that handles everything (Start, Commit, Rollback on exception, and UI redraws).

**Rule: Always use `with revit.Transaction("Name"):`**
```python
from pyrevit import revit

with revit.Transaction("Update Parameters"):
    # Logic...
```

If you are writing a complex script and need to handle a partial failure inside that pyRevit transaction, you must fall back to the native `SubTransaction` using the `clr` imported Revit API.

```python
from Autodesk.Revit.DB import SubTransaction

with revit.Transaction("Main Operation"):
    # Parent work
    sub_tx = SubTransaction(doc)
    sub_tx.Start()
    try:
        # Risky work
        sub_tx.Commit()
    except Exception as e:
        sub_tx.RollBack()
```
