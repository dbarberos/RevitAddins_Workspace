# Autonomous Testing Guidelines — Continuous Validation & Self-Healing Loop

## 1. Core Principle

When working on any Revit add-in in this workspace, the agent acts as an autonomous engineer. Writing code without validating it against the runtime is considered incomplete. The agent must enforce the **Continuous Validation Loop** via `Nice3point.TUnit.Revit`.

---

## 2. The Autonomous Validation Workflow

Whenever the user requests a feature, fix, or architectural change:

```text
┌────────────────────────────────────────────────────────────────────────┐
│ 1. IMPLEMENT CODE                                                      │
│    Write service, model, provider, or UI command                       │
└───────────────────────────────────┬────────────────────────────────────┘
                                    │
                                    ▼
┌────────────────────────────────────────────────────────────────────────┐
│ 2. WRITE / UPDATE TEST                                                 │
│    Create test class inheriting from RevitApiTest                      │
│    Apply [Test] and [TestExecutor<RevitThreadExecutor>]                │
└───────────────────────────────────┬────────────────────────────────────┘
                                    │
                                    ▼
┌────────────────────────────────────────────────────────────────────────┐
│ 3. RUN TEST IN TERMINAL                                                │
│    dotnet run --project ... -c "Release.R2X"                           │
└───────────────────────────────────┬────────────────────────────────────┘
                                    │
                  ┌─────────────────┴─────────────────┐
                  ▼                                   ▼
             [TEST PASSES]                      [TEST FAILS]
                  │                                   │
                  ▼                                   ▼
┌──────────────────────────────────┐ ┌──────────────────────────────────┐
│ 4. FINALIZE & NOTIFY             │ │ 4. SELF-HEALING LOOP             │
│    Report clean verified results │ │    - Read stack trace from logs  │
│    to the user                   │ │    - Diagnose root cause         │
└──────────────────────────────────┘ │    - Fix code / transaction      │
                                     │    - Re-run test (Back to Step 3)│
                                     └──────────────────────────────────┘
```

---

## 3. The Self-Healing Diagnostic Matrix

When a test fails during the automated run, the agent **must not stop or ask the user what to do**. It must inspect the console output and apply the corresponding fix:

| Symptom / Error in Console | Root Cause | Automated Resolution |
| :--- | :--- | :--- |
| `Autodesk.Revit.Exceptions.InvalidOperationException: Starting a transaction from an external application...` | Method executed outside Revit's STA UI thread. | Ensure `[TestExecutor<RevitThreadExecutor>]` is placed on the test method and `[HookExecutor<RevitThreadExecutor>]` on hooks. |
| Revit modal dialog freezes or warning aborts test (`Duplicate types`, `Unresolved references`) | Unhandled non-fatal warning popped up in Revit UI. | Register a `WarningSwallower` (`IFailuresPreprocessor`) on `Transaction.GetFailureHandlingOptions()`. |
| `NullReferenceException` accessing `ActiveUIDocument` or `Document` | No active document open in Revit instance during test. | Use the clean document isolation pattern (`Application.Application.NewProjectDocument(UnitSystem.Metric)` in `[Before(Test)]`). |
| `ModificationForbiddenException` | Writing to document outside an active `Transaction`. | Wrap mutation logic inside `using (var trans = new Transaction(doc, "...")) { trans.Start(); ... trans.Commit(); }`. |
| `FileLoadException` / `AssemblyLoadException` | Assembly version mismatch under .NET 8 (CoreCLR). | Pin NuGet versions to repository standards (`CommunityToolkit.Mvvm 8.2.2`). |

---

## 4. Completion Gate

A task is only marked as finished when:
1. The source code compiles with 0 errors and 0 warnings.
2. The associated tests pass with 100% green status.
3. Relevant architectural lessons or bug fixes are preserved in `references/` or `docs/`.
