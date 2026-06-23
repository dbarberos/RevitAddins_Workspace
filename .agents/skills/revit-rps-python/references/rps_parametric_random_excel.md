# Parametric Surfaces, Randomization, and Excel Integration

This reference guide explains how to plot mathematical surfaces (like a Mobius band), apply randomization to element heights and surfaces using `.NET` classes, and read/write values to a live Microsoft Excel session via COM Interop in **RevitPythonShell**.

---

## 1. Plotting Parametric Surfaces (e.g., Mobius Strip)

Parametric surfaces are graphed in 3D by driving $x, y, z$ coordinates using mathematical equations. Using loop steps for $u$ and $v$ ranges, you can generate reference points, draw splines, and loft them.

### Formula for Mobius Surface:
For $-\pi \le u \le \pi$ and $-1 \le v \le 1$:
*   $x = (R + v \cdot \cos(T \cdot u)) \cdot \cos(u)$
*   $y = (R + v \cdot \cos(T \cdot u)) \cdot \sin(u)$
*   $z = v \cdot \sin(T \cdot u)$

```python
import clr
import math
clr.AddReference('RevitAPI')
from Autodesk.Revit.DB import *

doc = __revit__.ActiveUIDocument.Document

t = Transaction(doc, 'Create Mobius Surface')
t.Start()

# Parameters controlling strip shape
R = 4.0
T = 0.5

# Resolution/Division counts
uDiv = 50
vDiv = 10

# Boundaries
u0, u1 = -math.pi, math.pi
v0, v1 = -1.0, 1.0

# Steps
uStep = abs(u1 - u0) / uDiv
vStep = abs(v1 - v0) / vDiv

# Collection of curves to span with the loft
refarrarr = ReferenceArrayArray()

u = u0
while u <= (u1 + uStep):
    # ReferencePoint collection for a single profile spline
    refptsarr = ReferencePointArray()
    
    v = v0
    while v <= v1:
        # Evaluate Mobius equations
        x = (R + v * math.cos(T * u)) * math.cos(u)
        y = (R + v * math.cos(T * u)) * math.sin(u)
        z = v * math.sin(T * u)
        
        # Scale coords up by 10 for visibility in Revit space
        point = XYZ(x * 10.0, y * 10.0, z * 10.0)
        refpt = doc.FamilyCreate.NewReferencePoint(point)
        refptsarr.Append(refpt)
        
        v += vStep
        
    # Generate the curve through the plotted point array
    crv = doc.FamilyCreate.NewCurveByPoints(refptsarr)
    
    # Store curve reference
    refarr = ReferenceArray()
    refarr.Append(crv.GeometryCurve.Reference)
    refarrarr.Append(refarr)
    
    u += uStep

# Generate the Mobius Strip loft form
mobius_strip = doc.FamilyCreate.NewLoftForm(True, refarrarr)

t.Commit()
```

---

## 2. Implementing Randomization

RevitPythonShell uses IronPython, allowing direct access to the `.NET` Framework. You can instantiate `.NET`'s standard pseudo-random number generator, `System.Random`.

### Instantiating System.Random
```python
import System

# Seed value can be specified to make random outputs reproducible
seed = 4
rand = System.Random(seed)

# Get float/double between 0.0 and 1.0
val_double = rand.NextDouble()

# Get integer in custom range [min, max)
val_int = rand.Next(10, 100)
```

### Script A: Random Surface Generator
Generates a highly irregular terrain-like loft surface.

```python
import clr
import System
clr.AddReference('RevitAPI')
from Autodesk.Revit.DB import *

doc = __revit__.ActiveUIDocument.Document

t = Transaction(doc, 'Create Random Surface')
t.Start()

rand = System.Random(4) # Seed = 4
refarrarr = ReferenceArrayArray()

for i in range(20):
    refptarr = ReferencePointArray()
    for j in range(20):
        x = i * 10.0
        y = j * 10.0
        # Determine random heights between 1 and 20 feet
        z = rand.Next(1, 20)
        
        myXYZ = XYZ(x, y, z)
        refPt = doc.FamilyCreate.NewReferencePoint(myXYZ)
        refptarr.Append(refPt)
        
    crv = doc.FamilyCreate.NewCurveByPoints(refptarr)
    refarr = ReferenceArray()
    refarr.Append(crv.GeometryCurve.Reference)
    refarrarr.Append(refarr)

# Generate wavy random terrain loft
terrain = doc.FamilyCreate.NewLoftForm(True, refarrarr)

t.Commit()
```

### Script B: Randomizing Parameters on Family Instances (City Skyline)
Creates a pseudo-random city context by changing the `height` parameter of existing box instances.

```python
import clr
import System
clr.AddReference('RevitAPI')
from Autodesk.Revit.DB import *

doc = __revit__.ActiveUIDocument.Document

t = Transaction(doc, 'Randomize City Heights')
t.Start()

rand = System.Random(123) # Seed

# Target family symbol/type name
target_family_name = 'BoxFamily'

# Collect family instances in the project document
collector = FilteredElementCollector(doc)
collector.OfCategory(BuiltInCategory.OST_Mass)
collector.OfClass(FamilyInstance)

for instance in collector:
    if instance.Name == target_family_name:
        # Locate the parameter to modify
        param = instance.LookupParameter('height') or instance.GetParameters('height')[0]
        if param and not param.IsReadOnly:
            # Set random height between 20 and 150 decimal feet
            random_height = rand.Next(20, 150)
            param.Set(float(random_height))

t.Commit()
```

---

## 3. Microsoft Excel COM Integration

Because RevitPythonShell runs inside a standard Windows CLR environment, you can interface with active Windows COM objects via `System.Runtime.InteropServices.Marshal.GetActiveObject`. 

> [!IMPORTANT]
> The target Microsoft Excel workbook must already be open and running on the host Windows machine for the COM interface to successfully locate the active Excel session.

### Reading Data from a Live Excel Spreadsheet
```python
import clr
import System
clr.AddReference('RevitAPI')
from Autodesk.Revit.DB import *

doc = __revit__.ActiveUIDocument.Document

# Retrieve active Excel session
excel_app = System.Runtime.InteropServices.Marshal.GetActiveObject('Excel.Application')

# Select the target worksheet index (1-based)
worksheet_idx = 1
col_idx = 1 # Column A

# Read text from cell coordinates A1 to A4
for row_idx in range(1, 5):
    cell_value = excel_app.Worksheets(worksheet_idx).Cells(row_idx, col_idx).Text
    print("Cell A{}: {}".format(row_idx, cell_value))
```

### Writing Data into a Live Excel Spreadsheet
```python
import clr
import System
clr.AddReference('RevitAPI')
from Autodesk.Revit.DB import *

doc = __revit__.ActiveUIDocument.Document

t = Transaction(doc, 'Write to Excel')
t.Start()

# Retrieve active Excel session
excel_app = System.Runtime.InteropServices.Marshal.GetActiveObject('Excel.Application')

worksheet_idx = 1
row_start = 1
col_idx = 1

current_value = 2

# Write values in a descending sequence, doubling each step
for i in range(10):
    cell = excel_app.Worksheets(worksheet_idx).Cells(row_start + i, col_idx)
    # Assign the value to the spreadsheet cell
    cell.Value = current_value
    current_value *= 2

t.Commit()
```
