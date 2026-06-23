---
name: revit-rps-python
description: Guides, startup templates, and quick scripts for prototyping C# code inside Revit's interactive python shell console. Use this when testing Revit API commands in real-time or setting up RevitPythonShell environments.
---

# RevitPythonShell Scripting

## Purpose
Optimize the interactive prototyping and real-time execution of Revit API code using the **RevitPythonShell (RPS)** console. This skill focuses on rapid, step-by-step element querying, parameter updates, assembly references, and creating automated startup configuration scripts (`startup.py`).

---

## When to Use
- When testing Revit API classes, methods, or queries interactively using a command-line REPL inside Revit.
- When prototyping database operations before compiling them into a final C# add-in.
- When configuring custom startup imports and environment variables via the `startup.py` file.
- When running raw, uncompiled scripts that bypass standard Ribbon panels for fast internal automation.

## When Not to Use
- When writing structured buttons or extensions meant for end-user distribution inside a ribbon (use `revit-pyrevit-python` instead).
- When developing graphical nodes inside Dynamo workspace graphs (use `revit-dynamo-python` instead).

---

## Inputs

| Input | Required | Description |
|-------|----------|-------------|
| RPS Console | Yes | Active RevitPythonShell interactive or non-interactive environment. |
| Target Assemblies | Recommended | Reference assemblies like `RevitAPI.dll` or custom compiled add-in DLLs. |

---

## Workflow

### Step 1: Initialize RPS Namespace Imports
- RPS automatically exposes `__revit__` as the main entry point. Utilize the standard headers:
  ```python
  import clr
  clr.AddReference('RevitAPI')
  clr.AddReference('RevitAPIUI')
  from Autodesk.Revit.DB import *
  from Autodesk.Revit.UI import *

  # Setup standard active document handles
  uidoc = __revit__.ActiveUIDocument
  doc = uidoc.Document
  ```

### Step 2: Establish Interactive Context
- Use Python's dynamic typing to inspect Revit elements on the fly:
  ```python
  # Get selected elements directly in the shell
  selection = [doc.GetElement(id) for id in uidoc.Selection.GetElementIds()]
  ```

### Step 3: Run Database Transactions
- To commit changes to the model, always run a standard transaction:
  ```python
  t = Transaction(doc, "RPS Test Command")
  t.Start()
  # Modify element parameters here
  t.Commit()
  ```

### Step 4: Save & Archive Prototypes
- Place rapid prototype scripts under `scripts/`.
- Save reusable RPS startup profiles under `assets/`.

---

## Validation
- [ ] Console statements print results instantly in the RevitPythonShell interactive prompt.
- [ ] Elements reflect modifications in the active Revit window after the transaction commits.
- [ ] Code is free of syntax errors and successfully translates to C# logic if compile-readiness is desired.

---

## Common Pitfalls

| Pitfall | Solution |
|---------|----------|
| `__revit__` NameError | Make sure the code is run inside the RevitPythonShell shell or standard macro environment where `__revit__` is initialized automatically. |
| Transaction remains uncommitted | Ensure `t.Commit()` or `t.RollBack()` is always invoked at the end of the transaction block. |
| Blocked UI interaction | Avoid long loop iterations that block the main thread without updating the console output stream regularly. |

---

## References
- [Environment Setup & Transaction Lifecycles](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-rps-python/references/rps_environment_setup.md)
- [Reference Points, Vectors, and Curves](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-rps-python/references/rps_geometry_creation.md)
- [Solid Extrusions, Revolves, and Divided Surfaces](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-rps-python/references/rps_forms_and_surfaces.md)
- [Family Manager and Adaptive Components](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-rps-python/references/rps_families_and_adaptive.md)
- [Parametrics, System.Random, and Microsoft Excel COM](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-rps-python/references/rps_parametric_random_excel.md)
- [Custom Form Classes & Execution Boilerplates](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-rps-python/references/rps_oop_custom_classes.md)
- [Reading and Writing Text Files (Stream I/O)](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-rps-python/references/rps_text_files_io.md)
- [Curated RPS Sample Scripts Library Index](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-rps-python/assets/rps_sample_scripts_index.md)

