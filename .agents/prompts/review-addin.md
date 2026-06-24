# Prompt: Revit Add-in Code Audit

This prompt standardizes the review flow to evaluate whether a code snippet (C# or Python pyRevit) complies with the repository rules.

---

## 🎯 Task Objective
Exhaustively audit a proposed code file or command to identify potential memory leaks, bad transaction practices, threading issues, or deprecated APIs.

---

## 📋 Audit Checklist

### 1. Transaction Management (Transactions)
*   **C# Rule:** Every model modification must be encapsulated in a `using (Transaction tx = new Transaction(doc, "Name"))` block. The block must contain `tx.Start()` and `tx.Commit()` (or `tx.RollBack()` in case of exception).
*   **Python (pyRevit) Rule:** The native context manager `with revit.Transaction("Name"):` must be used.
*   **Filter:** Pure data queries (read-only FilteredElementCollector) **must not** be wrapped in transactions to avoid unnecessary locks on the model.

### 2. Thread Safety
*   **Golden Rule:** The Revit API **is not thread-safe**. All element queries or modifications must be performed within the main Revit execution thread (called by external commands or applications).
*   **Filter:** If you detect asynchronous calls (`async/await`, `Task.Run`, or `Thread.Start`) interacting directly with Revit objects (`Element`, `Document`), raise a critical alert immediately and suggest the use of `ExternalEvent`.

### 3. Collector Performance
*   **Fast Filter:** Always prioritize fast filters (`OfClass()`, `OfCategory()`) before applying slow filters or in-memory LINQ queries.
*   **Filter:** Always verify that the collector calls `WhereElementIsNotElementType()` unless explicitly looking for family types.

### 4. Resource and ElementIds Cleanup (Revit 2024+)
*   **ElementId as Int64:** Ensure that `ElementId.IntegerValue` is not called. Instead, use `ElementId.Value` (returns a `long` type).
*   **Topography:** Verify that `TopographySurface` is not used. Instead, the modern `Toposolid` class must be used.
*   **Units:** Validate that enumerations of type `DisplayUnitType` are not used. Instead, use `ForgeTypeId` with the `UnitUtils` utility class.

---

## 🚀 Instructions for Generating the Audit Report

At the end of your review, provide the structured findings under the following output template:

1.  **General Diagnosis:** A one-paragraph summary indicating whether the code is suitable or requires modifications.
2.  **Critical Alerts (Blocking):** Threading issues, unclosed transactions, or memory leaks.
3.  **Warnings (Improvements):** Collector optimization, use of deprecated APIs, or style formatting (C# 12 / PEP 8).
4.  **Corrected Code Proposal:** Complete code snippet applying the proposed corrections.
