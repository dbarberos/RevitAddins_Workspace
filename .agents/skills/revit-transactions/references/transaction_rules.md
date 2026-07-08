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

## 4. Grouping Transactions: `TransactionGroup`

A `TransactionGroup` allows multiple `Transaction` objects to be encapsulated under a single undo command in the Revit user interface. It is ideal for massive multi-step tools (e.g. creating levels first, then creating views on those levels). 

**Rule: Always use `using` and call `Assimilate()` to collapse sub-transactions.**
```csharp
using (TransactionGroup tg = new TransactionGroup(doc, "Process Views"))
{
    tg.Start();
    
    // Step 1: Create Levels
    using (Transaction t1 = new Transaction(doc, "Create Levels"))
    {
        t1.Start();
        // create levels...
        t1.Commit();
    }
    
    // Step 2: Create Views
    using (Transaction t2 = new Transaction(doc, "Create Views"))
    {
        t2.Start();
        // create views...
        t2.Commit();
    }
    
    // Merges t1 and t2 into a single "Process Views" undo entry
    tg.Assimilate(); 
}
```

## 5. The Synchronous Regeneration Model (`doc.Regenerate()`)

Revit evaluates the geometric model in a lazy manner. When an element is modified or created, its geometry and parameters are not instantly updated in the database.
If you create an element on Line 10, and on Line 11 you try to read its parameters or geometry (e.g., volume, surface area), it will return null or obsolete values.

**Rule: Force immediate update using `doc.Regenerate()` within the active transaction when reading modified properties.**
```csharp
using (Transaction tx = new Transaction(doc, "Create and Read Volume"))
{
    tx.Start();
    
    // 1. Create Wall
    Wall wall = Wall.Create(doc, curve, levelId, false);
    
    // 2. Force database synchronization
    doc.Regenerate(); 
    
    // 3. Post-regeneration safe reading
    Parameter volume = wall.get_Parameter(BuiltInParameter.HOST_VOLUME_COMPUTED);
    double volVal = volume.AsDouble();
    
    tx.Commit();
}
```
*Note: Regeneration is highly computationally expensive. Avoid placing `doc.Regenerate()` inside large loops; instead, run modifications in bulk first, and regenerate once outside the loop.*

## 6. Prompt Injection Rules
- **IDisposable Golden Rule**: All `Transaction`, `TransactionGroup`, and `SubTransaction` instances MUST be initialized within a `using` statement.
- **Status Check**: Before opening a transaction, verify `doc.IsReadOnly` is false.
- **Semantic Naming**: Always supply a user-visible, descriptive action name for the transaction (e.g., `"Generate Grid System"`, never `"tx"` or `"test"`).
- **Regeneration Placement**: Never insert `doc.Regenerate()` inside a bulk creation loop (e.g. inside `for` or `foreach`). Mutate all elements first, then call `doc.Regenerate()` outside the loop.

