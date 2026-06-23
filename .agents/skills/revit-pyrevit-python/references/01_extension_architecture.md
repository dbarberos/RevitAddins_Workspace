# Extension Architecture and Tool Creation in pyRevit

## 1. pyRevit Folder Hierarchy
For pyRevit to recognize a tool, the folder structure must follow a strict suffix scheme that mimics the Revit UI hierarchy.

*   **`.extension`**: The root folder of your corporate package (e.g., `MyTools.extension`).
*   **`.tab`**: Defines the tab on the top Revit ribbon (e.g., `Architecture.tab`).
*   **`.panel`**: A block or group of buttons inside the tab (e.g., `Automation.panel`).
*   **Button Types**:
    *   **`.pushbutton`**: A standard button that executes a script.
    *   **`.pulldown`**: A dropdown menu that groups several `.pushbutton` folders inside it to save space.
    *   **`.stack`**: Allows stacking small buttons vertically.
*   **`script.py`**: The mandatory Python file containing the logic of your tool. It must be named exactly like this to be recognized.

## 2. Button Configuration (`bundle.yaml` and Metadata)
Inside your button folder (e.g., `Rename.pushbutton`), it is mandatory to use a `bundle.yaml` file to define how the tool is presented to the user.

### A. `bundle.yaml` File
This file controls the title, description, and even when the button should be available:

```yaml
title: Bulk Rename
tooltip: |
  Applies renaming to selected views.
  Shift + Click: Removes the prefix instead of adding it.
author: Your Name
context: ProjectDocument
```

**The `context` Concept:**
The `context` attribute is an advanced practice that tells pyRevit when to enable or disable (gray out) the button.
*   `ProjectDocument`: Only active if a project is open (disabled in families).
*   `ZeroDoc`: The tool can be executed even if no document is open in Revit (e.g., to open web links or settings).
*   `Selection`: Requires the user to select an element in the view before running.

### B. Icons and Tooltips (Best Practices)
*   **Icon Best Practice:** Always use a file named `icon.png` with a resolution of **96x96 pixels** for the best quality. Sites like *Icons8* are ideal for maintaining visual consistency.
*   **Tooltip Best Practice:** Tooltips should clearly describe if the script requires a prior selection and warn if the action **deletes** elements from the model to avoid surprises.

## 3. Alternative Logic (The Power of "Shift + Click")
One of pyRevit's most powerful features is giving two uses to the same button. For example, a normal Click "Adds" revisions, and Shift + Click "Removes" them.

To achieve this, we import the `EXEC_PARAMS` class and read the `config_mode`:

```python
from pyrevit import EXEC_PARAMS

# Detects if the user is executing with Shift+Click
alt_mode = EXEC_PARAMS.config_mode

if alt_mode:
    print("Delete mode activated (Shift+Click)")
    action = "remove"
else:
    print("Standard mode: Add revision")
    action = "apply"
```
*Note: If you require configuration settings for the tool (e.g., remembering whether to use a cut pattern or not), pyRevit will automatically save the options in its configuration if you design your script for it.*

## 4. Code Reusability (`lib` Folders)
As the extension grows, you shouldn't repeat code (e.g., functions to delete elements or create transactions) in every script. You have two methods to standardize code:

### A. The Internal `lib` Folder
At the root of your `.extension`, create a folder named `lib` and inside it, add module folders with the mandatory `__init__.py` file. All buttons in that extension will have access to it automatically.

### B. Library Extensions (`.lib`)
For large corporations, you can create a separate extension with the `.lib` suffix (e.g., `CoreCompany.lib`). pyRevit will load this path globally and **all your different extensions** will be able to import its methods in Python (e.g., `import my_company_standards`).

## 5. Rapid Implementation and Templates
*   **EF-pyRevit StarterKit:** Instead of creating all this folder structure by hand, using the "EF-pyRevit StarterKit" is recommended. It generates the entire base extension template, including standard modules, in just 2 minutes.

## 6. Boilerplate Code Template
Every modification script must interact with the active document and handle transactions safely.

```python
# -*- coding: utf-8 -*-
"""
Purpose: Base template for operations in Revit.
"""
from Autodesk.Revit.DB import FilteredElementCollector, Transaction

# Get the application, document, and active view
doc = __revit__.ActiveUIDocument.Document
uidoc = __revit__.ActiveUIDocument
view = doc.ActiveView

# All modifications to the Revit database MUST be inside a transaction
t = Transaction(doc, "Operation Name")
t.Start()

try:
    # SCRIPT LOGIC HERE
    # E.g.: Collect elements, apply changes.
    t.Commit()
except Exception as e:
    t.RollBack()
    print("Execution error: {}".format(e))
```
