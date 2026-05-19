---
name: revit-pyrevit-python
description: Technical blueprints, guides, and script templates for developing custom pyRevit pushbuttons, tools, extensions, and WPF forms in Python. Use this when writing scripts designed to run as pyRevit macro extension buttons.
---

# pyRevit Python Scripting

## Purpose
Streamline and standardize the development of custom **pyRevit** tools, extensions, and user interfaces inside Autodesk Revit. This skill focuses on utilizing pyRevit's built-in framework modules (forms, scripting, execution, telemetry) to deliver highly interactive, responsive macros without the overhead of heavy C# WPF compilation.

---

## When to Use
- When writing custom `.pushbutton`, `.pullbutton`, or `.stack` commands for a pyRevit extension tab.
- When utilizing pyRevit's native forms UI library (`pyrevit.forms`) for element selection, input boxes, or progress bars.
- When creating non-modal or modal custom WPF interfaces in Python using pyRevit's xaml loader.
- When interacting with pyRevit's configuration files, session state data, or telemetry tracking features.

## When Not to Use
- When coding standalone interactive Python console commands or rapid prototyping scripts (use `revit-rps-python` instead).
- When writing scripts within Dynamo visual nodes (use `revit-dynamo-python` instead).

---

## Inputs

| Input | Required | Description |
|-------|----------|-------------|
| pyRevit Environment | Yes | pyRevit execution environment (typically utilizing IronPython 2.7 or pyRevit's Python 3 engine). |
| Extension Layout | Yes | Configured directory structure (e.g., `Tab.extension > Panel.panel > Button.pushbutton`). |
| Script File | Yes | Main execution logic stored in a file named `script.py`. |

---

## Workflow

### Step 1: Initialize pyRevit Environment
- Import pyRevit's built-in helper framework modules:
  ```python
  from pyrevit import revit, DB, UI
  from pyrevit import forms
  from pyrevit import script
  ```

### Step 2: Establish Context & Element Selection
- Fetch the active document safely:
  ```python
  doc = revit.doc
  uidoc = revit.uidoc
  ```
- Use pyRevit's `forms.select_elements()` or `forms.SelectFromList` for standard UI element selections.

### Step 3: Transaction Management
- Always wrap write operations using pyRevit's simplified transaction class:
  ```python
  with revit.Transaction("pyRevit Command Title"):
      # Modify model elements here
  ```

### Step 4: UI and Progress Tracking
- Use `forms.ProgressBar` to keep users engaged during heavy iterations:
  ```python
  with forms.ProgressBar(title="Processing...") as pb:
      for i, item in enumerate(items):
          # Long task
          pb.update_progress(i, len(items))
  ```

---

## Validation
- [ ] The command button loads cleanly in the Revit Ribbon interface under the correct custom tab.
- [ ] No transaction leaks occur (all write blocks are enclosed within a `with revit.Transaction` structure).
- [ ] Executable outputs are redirected properly through the pyRevit output window (`script.get_output()`).

---

## Common Pitfalls

| Pitfall | Solution |
|---------|----------|
| UI freezing during iterations | Use pyRevit's built-in asynchronous forms or wrap loop updates in a progress bar context. |
| Hardcoded resource paths | Use pyRevit's relative pathing helpers (e.g., `script.get_button_path()`). |
| Broken ironpython references | Explicitly load namespaces using `import clr` when interacting with complex C# types. |

---

## References
- *(Additional guides and references will be listed here as ingested)*
