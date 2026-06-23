---
name: revit-dynamo-python
description: Guides, templates, and reference materials for developing custom Python scripts inside Dynamo visual scripting nodes. Use this when writing scripts designed to run inside Dynamo workspaces.
---

# Dynamo Python Scripting

## Purpose
Optimize the authoring, execution, and organization of Python scripts targeting Autodesk Revit and Autodesk Dynamo. This skill ensures scripts comply with Revit API conventions, handle Revit's transaction lifecycle securely, and maintain high performance across multiple Revit versions.

---

## When to Use
- When writing custom Python scripts for Dynamo's Python Script node inside Dynamo workspaces.
- When converting C# Revit API element collector patterns into Dynamo visual nodes.
- When validating element parameter data inside visual scripting graphs.

## When Not to Use
- When building compile-locked production add-ins with complex custom WPF interfaces (use `csharp-blueprints` instead).
- When developing custom ribbon buttons or menus for pyRevit extensions (use `revit-pyrevit-python` instead).
- When prototyping interactive shell queries in Revit's console (use `revit-rps-python` instead).

---

## Inputs

| Input | Required | Description |
|-------|----------|-------------|
| Python Environment | Yes | IronPython (2.7) or CPython (3.x/Python 3 engine in Dynamo). |
| Revit API References | Yes | Targets `RevitAPI.dll` and `RevitAPIUI.dll`. |
| Script Scope | Yes | Revit model instance or active active view environment. |

---

## Workflow

### Step 1: Establish Script Environment
- Identify the target engine: **IronPython 2.7** (legacy Dynamo) vs. **CPython 3.x** (Dynamo 2021+ Python 3 engine).
- Initialize standard Revit API assembly imports (e.g., `clr.AddReference('RevitAPI')`).

### Step 2: Set Up Document Context
- Capture the active document context safely within Dynamo's thread manager:
  ```python
  import clr
  clr.AddReference('RevitServices')
  import RevitServices
  from RevitServices.Persistence import DocumentManager
  
  doc = DocumentManager.Instance.CurrentDBDocument
  ```

### Step 3: Transaction Management
- Wrap model modifications inside Dynamo's dedicated transaction manager block:
  ```python
  from RevitServices.Transactions import TransactionManager
  
  TransactionManager.Instance.EnsureInTransaction(doc)
  # Modify element parameters here
  TransactionManager.Instance.TransactionTaskDone()
  ```

### Step 4: Classification
- Store all incoming documentation under `references/`.
- Keep reusable boilerplate code snippets under `assets/`.
- Put executable utility scripts under `scripts/`.

---

## Validation
- [ ] Script executes successfully inside Revit/Dynamo without throwing `NameError` or `AttributeError`.
- [ ] No active transaction leaks exist (transactions are committed or rolled back).
- [ ] Script handles empty inputs gracefully without crashing the visual node execution.

---

## Common Pitfalls

| Pitfall | Solution |
|---------|----------|
| Missing `clr.AddReference` | Ensure common assemblies like `RevitAPI` and `RevitServices` are referenced at the top. |
| Type conversion mismatch | When wrapping raw Revit elements for Dynamo UI, use `Element.ToDSType(bool)` mapping. |
| Background thread locks | Never run model-modifying scripts in background asynchronous threads without Revit's `ExternalEvent` protection. |

---

## References
- *(Additional guides and references will be listed here as ingested)*
