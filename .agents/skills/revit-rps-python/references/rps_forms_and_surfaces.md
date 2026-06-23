# Conceptual Massing Forms and Divided Surfaces in RevitPythonShell

This reference guide explains how to generate solid mass forms (extrusions, lofts, revolves, caps) and apply parametric divided surfaces and paneling patterns to model geometry faces in Revit using **RevitPythonShell**.

---

## 1. Creating Solid & Void Forms

Forms are created inside the Family Editor environment through the methods exposed in `FamilyCreate`.

### Method A: Extrusion Box (`NewExtrusionForm`)
Extrusions require a closed profile `ReferenceArray` and a translation direction vector (`XYZ`).

```python
import clr
clr.AddReference('RevitAPI')
from Autodesk.Revit.DB import *

doc = __revit__.ActiveUIDocument.Document
app = __revit__.Application

t = Transaction(doc, 'Create Box Extrusion')
t.Start()

# Setup host SketchPlane
origin = XYZ.Zero
normal = XYZ.BasisZ
plane = app.Create.NewPlane(normal, origin)
skplane = doc.FamilyCreate.NewSketchPlane(plane)

# Define closed-loop vertices
pts = [
    XYZ(0, 0, 0),
    XYZ(10, 0, 0),
    XYZ(10, 10, 0),
    XYZ(0, 10, 0),
    XYZ(0, 0, 0) # Close loop
]

# Generate model curves and store their references in a ReferenceArray
refarr = ReferenceArray()
for i in range(len(pts) - 1):
    ptA = pts[i]
    ptB = pts[i+1]
    line = app.Create.NewLine(ptA, ptB, True)
    crv = doc.FamilyCreate.NewModelCurve(line, skplane)
    refarr.Append(crv.GeometryCurve.Reference)

# Extrusion direction vector (Z axis, height = 10)
dir_vector = XYZ(0, 0, 10)

# Create solid extrusion
extrude = doc.FamilyCreate.NewExtrusionForm(True, refarr, dir_vector)

t.Commit()
```

### Method B: Loft Surfaces (`NewLoftForm`)
Lofts generate surfaces or solids by stretching a form across multiple boundary profile curves. It requires a `ReferenceArrayArray` (an array of curve reference arrays).

```python
import clr
import math
clr.AddReference('RevitAPI')
from Autodesk.Revit.DB import *

doc = __revit__.ActiveUIDocument.Document
app = __revit__.Application

t = Transaction(doc, 'Create Loft Surface')
t.Start()

refarrarr = ReferenceArrayArray()

# Generate a series of 20 wavy profile splines along the Y-axis
for i in range(0, 20):
    refptarr = ReferencePointArray()
    for j in range(0, 20):
        x = i * 10.0
        y = j * 10.0
        # Determine 3D waves using trigonometric formulas
        z = (10.0 * math.cos(i)) + (10.0 * math.sin(j))
        
        myXYZ = XYZ(x, y, z)
        refPoint = doc.FamilyCreate.NewReferencePoint(myXYZ)
        refptarr.Append(refPoint)
        
    # Draw spline through the points
    crv = doc.FamilyCreate.NewCurveByPoints(refptarr)
    
    # Store reference
    refarr = ReferenceArray()
    refarr.Append(crv.GeometryCurve.Reference)
    refarrarr.Append(refarr)

# Create solid loft form spanning all profiles
loft = doc.FamilyCreate.NewLoftForm(True, refarrarr)

t.Commit()
```

### Method C: Revolve Shells (`NewRevolveForms`)
Revolves sweep a profile curve around a central axis line. It requires:
*   A profile curve reference.
*   An axis line model curve reference.
*   Start and End sweep angles (radians).

```python
import clr
import math
clr.AddReference('RevitAPI')
from Autodesk.Revit.DB import *

doc = __revit__.ActiveUIDocument.Document
app = __revit__.Application

t = Transaction(doc, 'Create Revolve shell')
t.Start()

# Setup sketch plane
origin = XYZ.Zero
normal = XYZ.BasisZ
plane = app.Create.NewPlane(normal, origin)
skplane = doc.FamilyCreate.NewSketchPlane(plane)

# Create central axis model line
lnStart = XYZ(0, 0, 0)
lnEnd = XYZ(0, 50, 0)
line = app.Create.NewLine(lnStart, lnEnd, True)
axis = doc.FamilyCreate.NewModelCurve(line, skplane)
axisRef = axis.GeometryCurve.Reference

# Define profile coordinates
pts = [
    XYZ(-20, 0, 0),
    XYZ(-30, 25, 0),
    XYZ(-20, 50, 0),
    XYZ(-30, 75, 0),
    XYZ(-20, 100, 0)
]

# Generate spline curve profile through reference points
refptarr = ReferencePointArray()
for pt in pts:
    refpt = doc.FamilyCreate.NewReferencePoint(pt)
    refptarr.Append(refpt)
    
profile = doc.FamilyCreate.NewCurveByPoints(refptarr)
profileRefArr = ReferenceArray()
profileRefArr.Append(profile.GeometryCurve.Reference)

# Define sweep range (full circle 360 degrees)
startAngle = 0.0
endAngle = 2 * math.pi

revolve = doc.FamilyCreate.NewRevolveForms(True, profileRefArr, axisRef, startAngle, endAngle)

t.Commit()
```

---

## 2. Divided Surfaces and Panel Systems

Once a form has been created inside the Massing environment, you can dynamically retrieve its faces, divide them into a UV grid pattern, and swap the tile patterns.

### Step 1: Divide Face of Form Geometry
```python
import clr
clr.AddReference('RevitAPI')
from Autodesk.Revit.DB import *

doc = __revit__.ActiveUIDocument.Document
app = __revit__.Application

t = Transaction(doc, 'Divide Form Surfaces')
t.Start()

# Collect all mass forms in the active mass family document
collector = FilteredElementCollector(doc)
collector.OfCategory(BuiltInCategory.OST_MassForm)

for item in collector:
    # Fetch Revit Geometry objects
    geOptions = app.Create.NewGeometryOptions()
    geOptions.ComputeReferences = True
    geoElem = item.get_Geometry(geOptions)
    
    for geObj in geoElem.Objects:
        # Loop through geometric faces
        for face in geObj.Faces:
            # Divide surface based on face reference
            divSrf = doc.FamilyCreate.NewDividedSurface(face.Reference)
            
            # Setup fixed grid counts (20 x 20)
            srfU = divSrf.USpacingRule
            srfU.SetLayoutFixedNumber(20, SpacingRuleJustification.Center, 0.0, 0.0)
            
            srfV = divSrf.VSpacingRule
            srfV.SetLayoutFixedNumber(20, SpacingRuleJustification.Center, 0.0, 0.0)

t.Commit()
```

### Step 2: Assign Patterns to Divided Surfaces
To swap panel configurations, retrieve the `TilePatterns` collection from Revit Settings and assign a built-in type to the divided surface.

```python
import clr
clr.AddReference('RevitAPI')
from Autodesk.Revit.DB import *

doc = __revit__.ActiveUIDocument.Document
t = Transaction(doc, 'Assign Triangular Pattern')
t.Start()

# Retrieve standard tile patterns from the document settings
patterns = doc.Settings.TilePatterns
target_pattern_id = patterns.GetTilePattern(TilePatternsBuiltIn.TriangleCheckerboard_Flat).Id

# Collect mass forms
collector = FilteredElementCollector(doc)
collector.OfCategory(BuiltInCategory.OST_MassForm)

for srfObj in collector:
    # Obtain the DividedSurfaceData associated with this mass form
    divSrfData = srfObj.GetDividedSurfaceData()
    if divSrfData:
        # Swap patterns for all divided surface references
        for ref in divSrfData.GetReferencesWithDividedSurfaces():
            divSrf = divSrfData.GetDividedSurfaceForReference(ref)
            divSrf.ChangeTypeId(target_pattern_id)

t.Commit()
```
