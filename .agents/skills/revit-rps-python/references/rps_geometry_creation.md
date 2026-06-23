# Geometry Creation in RevitPythonShell (Massing Environment)

This reference guide explains how to dynamically create points, planes, sketch planes, model curves, and splines within Revit's Conceptual Massing environment using **RevitPythonShell**.

---

## 1. Creating Reference Points

In Revit's Massing environment, reference points are crucial nodes that can be placed in space to act as vertices for lines, splines, or surfaces.

*   `XYZ`: Revit's raw geometry class for 3D coordinates.
*   `ReferencePoint`: The actual model element placed in the family database via `FamilyCreate.NewReferencePoint()`.

### Single Reference Point
```python
import clr
clr.AddReference('RevitAPI')
from Autodesk.Revit.DB import *

doc = __revit__.ActiveUIDocument.Document

t = Transaction(doc, 'Create single reference point')
t.Start()

x, y, z = 10.0, 10.0, 0.0
myXYZ = XYZ(x, y, z)

# Place the reference point element
refPoint = doc.FamilyCreate.NewReferencePoint(myXYZ)

t.Commit()
```

### Grids of Reference Points
You can use nested `for` loops combined with mathematical expressions (like `math.sin` / `math.cos`) to create complex grids and wave patterns.

```python
import clr
import math
clr.AddReference('RevitAPI')
from Autodesk.Revit.DB import *

doc = __revit__.ActiveUIDocument.Document

t = Transaction(doc, 'Create sine wave points')
t.Start()

for i in range(0, 30):
    for j in range(0, 30):
        x = i * 10.0
        y = j * 10.0
        # Determine height via trigonometric waves
        z = (10.0 * math.cos(i)) + (10.0 * math.sin(j))
        
        myXYZ = XYZ(x, y, z)
        refPoint = doc.FamilyCreate.NewReferencePoint(myXYZ)

t.Commit()
```

---

## 2. Planes and Sketch Planes

Planes (`Plane`) and Sketch Planes (`SketchPlane`) act as the host workspaces required to sketch model curves (lines, arcs, circles).

### Method A: Plane by Origin and Normal
```python
import clr
clr.AddReference('RevitAPI')
from Autodesk.Revit.DB import *

doc = __revit__.ActiveUIDocument.Document
app = __revit__.Application

t = Transaction(doc, 'Create SketchPlane by World XYZ')
t.Start()

# Define normal pointing straight up (Z basis) at the coordinate origin
origin = XYZ.Zero
normal = XYZ.BasisZ

# Create plane
plane = app.Create.NewPlane(normal, origin)

# Create host SketchPlane
skplane = doc.FamilyCreate.NewSketchPlane(plane)

t.Commit()
```

### Method B: Plane by 3 Points (Custom Orientation)
```python
import clr
clr.AddReference('RevitAPI')
from Autodesk.Revit.DB import *

doc = __revit__.ActiveUIDocument.Document
app = __revit__.Application

t = Transaction(doc, 'Create Plane by 3 Points')
t.Start()

# Define three points in space
p1 = XYZ(0, 0, 0)
p2 = XYZ(10, 0, 0)
p3 = XYZ(0, 10, 0)

# Create boundary lines
pline1 = app.Create.NewLine(p1, p2, True)
pline2 = app.Create.NewLine(p2, p3, True)

# Build a CurveArray
parray = CurveArray()
parray.Append(pline1)
parray.Append(pline2)

# Generate plane and sketch plane
plane = app.Create.NewPlane(parray)
skplane = doc.FamilyCreate.NewSketchPlane(plane)

t.Commit()
```

---

## 3. Creating Model Curves

Model curves represent lines or curves placed inside a Revit family. They require a geometric curve representation and a target host `SketchPlane`.

### Drawing a Straight Line
```python
import clr
clr.AddReference('RevitAPI')
from Autodesk.Revit.DB import *

doc = __revit__.ActiveUIDocument.Document
app = __revit__.Application

t = Transaction(doc, 'Create Line')
t.Start()

# Setup host SketchPlane on World origin
origin = XYZ.Zero
normal = XYZ.BasisZ
plane = app.Create.NewPlane(normal, origin)
skplane = doc.FamilyCreate.NewSketchPlane(plane)

# Define curve geometry (start/end)
lnStart = XYZ(0, 0, 0)
lnEnd = XYZ(20, 20, 0)
line = app.Create.NewLine(lnStart, lnEnd, True)

# Instantiate the model curve
crv = doc.FamilyCreate.NewModelCurve(line, skplane)

t.Commit()
```

### Drawing an Arc
```python
import clr
import math
clr.AddReference('RevitAPI')
from Autodesk.Revit.DB import *

doc = __revit__.ActiveUIDocument.Document
app = __revit__.Application

t = Transaction(doc, 'Create Arc')
t.Start()

# Create sketch plane
origin = XYZ.Zero
normal = XYZ.BasisZ
plane = app.Create.NewPlane(normal, origin)
skplane = doc.FamilyCreate.NewSketchPlane(plane)

# Define arc radius and sweep angles
radius = 10.0
startAngle = 0.0
endAngle = 0.5 * math.pi # 90-degree sweep

# Create arc geometry
arc = app.Create.NewArc(plane, radius, startAngle, endAngle)

# Instantiate model curve
crv = doc.FamilyCreate.NewModelCurve(arc, skplane)

t.Commit()
```

---

## 4. Creating Splines via Reference Points

Unlike standard lines which use geometric curves on a sketch plane, splines (curves through points) utilize an array of physical `ReferencePoint` elements inside the massing environment.

### Creating a Wave Spline
```python
import clr
import math
clr.AddReference('RevitAPI')
from Autodesk.Revit.DB import *

doc = __revit__.ActiveUIDocument.Document

t = Transaction(doc, 'Create Spline Curve')
t.Start()

refptarr = ReferencePointArray()

# Place a series of wave points and track them in the array
for i in range(0, 20):
    x = i * 2.0
    y = i * 2.0
    z = math.sin(i) * 2.0
    
    myXYZ = XYZ(x, y, z)
    refPt = doc.FamilyCreate.NewReferencePoint(myXYZ)
    refptarr.Append(refPt)

# Draw the Spline connecting all reference points
crv = doc.FamilyCreate.NewCurveByPoints(refptarr)

t.Commit()
```
