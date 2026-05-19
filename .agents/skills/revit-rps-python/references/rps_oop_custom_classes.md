# Object-Oriented Programming and Custom Classes in RevitPythonShell

This reference guide explains how to leverage Object-Oriented Programming (OOP) patterns in IronPython to write cleaner, reusable, and modular automation tools inside **RevitPythonShell**. It demonstrates class definitions, instance properties, main execution guards, and geometric wrappers.

---

## 1. Clean Script Boilerplate with Main Execution Guards

In modular scripting, wrapping script logic inside a `main()` function with a namespace guard (`if __name__ == '__main__':`) prevents execution errors when script files are imported by other modules.

```python
import clr
clr.AddReference('RevitAPI')
from Autodesk.Revit.DB import *

# Global Document references
doc = __revit__.ActiveUIDocument.Document

# ----------------- CLASS DEFINITIONS -----------------
class RevitMathHelper(object):
    """Simple helper class demonstrating OOP structure."""
    
    def __init__(self):
        # Instance properties
        self.run_count = 0
        
    def add_numbers(self, a, b):
        """Method to sum coordinates or measurements."""
        self.run_count += 1
        return a + b

# ----------------- MAIN SCRIPT ENTRY -----------------
def main():
    t = Transaction(doc, 'Boilerplate execution')
    t.Start()
    
    # Instantiate custom class
    helper = RevitMathHelper()
    result = helper.add_numbers(15.0, 35.5)
    
    # Print results to the console
    print("Result: {}".format(result))
    print("Helper run count: {}".format(helper.run_count))
    
    t.Commit()

# Guard block
if __name__ == '__main__':
    main()
```

---

## 2. Reusable Geometric Wrapper Class (`FormCreate`)

As scripts become complex, encapsulating geometric calculations inside helper classes abstracts low-level Revit API calls (`NewReferencePoint`, `NewCurveByPoints`, `NewLoftForm`) into clean, single-line commands in your main code block.

### Reusable Class Definition
```python
import clr
clr.AddReference('RevitAPI')
from Autodesk.Revit.DB import *

class FormCreate(object):
    """
    A geometric utility class that handles solid surface generation
    from discrete point arrays and boundary vertices.
    """
    
    def __init__(self, revit_doc):
        # Reference to the active Revit document context
        self.doc = revit_doc
        
    def surface_from_corners(self, c1, c2, c3, c4):
        """
        Creates a solid surface lofted between four boundary corner coordinates.
        c1, c2, c3, c4 must be Autodesk.Revit.DB.XYZ objects.
        """
        ref_curves = ReferenceArrayArray()
        
        # Profile Curve 1 (c1 -> c2)
        pts1 = ReferencePointArray()
        pts1.Append(self.doc.FamilyCreate.NewReferencePoint(c1))
        pts1.Append(self.doc.FamilyCreate.NewReferencePoint(c2))
        crv1 = self.doc.FamilyCreate.NewCurveByPoints(pts1)
        
        ref_arr1 = ReferenceArray()
        ref_arr1.Append(crv1.GeometryCurve.Reference)
        ref_curves.Append(ref_arr1)
        
        # Profile Curve 2 (c4 -> c3)
        pts2 = ReferencePointArray()
        pts2.Append(self.doc.FamilyCreate.NewReferencePoint(c4))
        pts2.Append(self.doc.FamilyCreate.NewReferencePoint(c3))
        crv2 = self.doc.FamilyCreate.NewCurveByPoints(pts2)
        
        ref_arr2 = ReferenceArray()
        ref_arr2.Append(crv2.GeometryCurve.Reference)
        ref_curves.Append(ref_arr2)
        
        # Loft between boundary profiles
        return self.doc.FamilyCreate.NewLoftForm(True, ref_curves)
        
    def surface_from_point_grid(self, points_list, u_count, v_count):
        """
        Creates a solid loft surface from a flat list of coordinates representing a U x V grid.
        points_list: flat list of Autodesk.Revit.DB.XYZ objects
        u_count: Int representing number of columns
        v_count: Int representing number of rows
        """
        ref_curves = ReferenceArrayArray()
        index = 0
        
        # Group coordinates into profiles along U axis
        for i in range(u_count):
            row_points = ReferencePointArray()
            
            # Loop through V rows
            for j in range(v_count):
                current_xyz = points_list[index]
                row_points.Append(self.doc.FamilyCreate.NewReferencePoint(current_xyz))
                index += 1
                
            # Draw spline through row vertices
            row_spline = self.doc.FamilyCreate.NewCurveByPoints(row_points)
            
            # Store spline geometry reference
            ref_array = ReferenceArray()
            ref_array.Append(row_spline.GeometryCurve.Reference)
            ref_curves.Append(ref_array)
            
        # Draw loft across all generated row splines
        return self.doc.FamilyCreate.NewLoftForm(True, ref_curves)
```

### Implementing `FormCreate` in Main Code
```python
import math

def main():
    doc = __revit__.ActiveUIDocument.Document
    t = Transaction(doc, 'Generate math grid surface')
    t.Start()
    
    # Define flat point array representing a wave grid
    grid_points = []
    u = 20
    v = 20
    
    for i in range(u):
        for j in range(v):
            x = i * 10.0
            y = j * 10.0
            z = (10.0 * math.cos(i)) + (10.0 * math.sin(j))
            grid_points.append(XYZ(x, y, z))
            
    # Instantiate helper utility
    creator = FormCreate(doc)
    
    # 1. Generate surface from the complex mathematical grid
    grid_surface = creator.surface_from_point_grid(grid_points, u, v)
    
    # 2. Generate surface from boundary corners
    corner_surface = creator.surface_from_corners(
        XYZ(0, 0, 0),
        XYZ(50, 0, 20),
        XYZ(50, 50, 0),
        XYZ(0, 50, 20)
    )
    
    t.Commit()

if __name__ == '__main__':
    main()
```
