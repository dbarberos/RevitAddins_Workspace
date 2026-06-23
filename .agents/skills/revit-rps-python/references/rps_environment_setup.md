# RevitPythonShell Environment Setup and Boilerplate

This reference guide explains how to set up your environment, manage the active document context, use Revit's transaction API, and control the interactive script execution windows inside **RevitPythonShell**.

---

## 1. Imports and Reference Loading
To interact with Revit's database, your IronPython environment needs to load the standard Revit C# assemblies via `clr` (Common Language Runtime).

**Standard Loader Block:**
```python
import clr
import math

# Reference Revit C# DLLs
clr.AddReference('RevitAPI')
clr.AddReference('RevitAPIUI')

# Import core namespaces
from Autodesk.Revit.DB import *
from Autodesk.Revit.UI import *
```

---

## 2. Document Context Mapping
RevitPythonShell provides automatic environment variables when executed inside an active session:
*   `__revit__`: The `UIApplication` entry point.
*   `__window__`: The active console window UI object.

**Fetching Active Handles:**
```python
# Reference the application handle
app = __revit__.Application

# Reference the active UI document and DB document
uidoc = __revit__.ActiveUIDocument
doc = uidoc.Document
```

---

## 3. Revit Transactions in Python
All changes to the Revit database (creation, deletion, parameter modification) must occur inside an active **Transaction** block.

**Code Example:**
```python
# Initialize transaction with the active document and a descriptive title
t = Transaction(doc, 'RPS Transaction Name')

# Start transaction
t.Start()

# ... Perform database modifications here ...

# Commit transaction to save changes
t.Commit()
```

---

## 4. Closing the Scripting Window
After executing a non-interactive macro or automated execution, you can tell the shell window to close itself automatically.

**Code Example:**
```python
# Closes the RevitPythonShell execution popup automatically
__window__.Close()
```

---

## 5. Standard RPS Boilerplate Template
This is the recommended boilerplate starting point for writing any RevitPythonShell prototype script.

```python
# ==========================================
#  RevitPythonShell - Standard Boilerplate
# ==========================================
import clr
import math

# Load Revit Assemblies
clr.AddReference('RevitAPI')
clr.AddReference('RevitAPIUI')

# Import Namespaces
from Autodesk.Revit.DB import *
from Autodesk.Revit.UI import *

# Initialize Active Context
app = __revit__.Application
uidoc = __revit__.ActiveUIDocument
doc = uidoc.Document

# Define Transaction
t = Transaction(doc, 'My Prototype Action')
t.Start()

try:
    # -------------------------------------
    # Write custom execution logic here
    # -------------------------------------
    pass
    t.Commit()
except Exception as e:
    t.RollBack()
    print("Error occurred: {}".format(e))
finally:
    # Optional: Automatically close shell window
    # __window__.Close()
    pass
```
