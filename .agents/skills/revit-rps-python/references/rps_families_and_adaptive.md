# Families, Instances, and Adaptive Components in RevitPythonShell

This reference guide explains how to manage family parameters (reading, setting, incrementing), place standard family instances, and programmatically instantiate and orient multi-point **Adaptive Components** inside Revit using **RevitPythonShell**.

---

## 1. Managing Family Parameters

When editing a family document (`.rfa`), parameters are managed through `FamilyManager`. Most operations involve iterating over parameters and matching their names.

### Reading Family Parameters
To extract the numerical value of a family parameter, query the `FamilyManager.CurrentType` as a specific type (e.g., `AsDouble`, `AsInteger`, or `AsString`).

```python
import clr
clr.AddReference('RevitAPI')
from Autodesk.Revit.DB import *

doc = __revit__.ActiveUIDocument.Document

t = Transaction(doc, 'Get family parameters')
t.Start()

# Safely extract specific parameters by name matching
height_param = [p for p in doc.FamilyManager.Parameters if p.Definition.Name == 'height'][0]
length_param = [p for p in doc.FamilyManager.Parameters if p.Definition.Name == 'length'][0]

# Retrieve values for the current active type
height_val = doc.FamilyManager.CurrentType.AsDouble(height_param)
length_val = doc.FamilyManager.CurrentType.AsDouble(length_param)

print("Height: {}, Length: {}".format(height_val, length_val))

t.Commit()
```

### Writing/Setting Family Parameters
To modify a parameter across active types, use the `FamilyManager.Set()` method.

```python
import clr
clr.AddReference('RevitAPI')
from Autodesk.Revit.DB import *

doc = __revit__.ActiveUIDocument.Document

t = Transaction(doc, 'Set family parameters')
t.Start()

# Match the target parameter definitions
width_param = [p for p in doc.FamilyManager.Parameters if p.Definition.Name == 'width'][0]

# Set the parameter values directly (Revit uses decimal feet internally)
doc.FamilyManager.Set(width_param, 10.0) # Sets width to 10 feet

t.Commit()
```

---

## 2. Placing Standard Family Instances

Standard family instances are placed in the document database using `FamilyCreate.NewFamilyInstance()`. You must first filter for the loaded `FamilySymbol` inside the active document.

```python
import clr
clr.AddReference('RevitAPI')
from Autodesk.Revit.DB import *

doc = __revit__.ActiveUIDocument.Document

t = Transaction(doc, 'Place multiple family instances')
t.Start()

target_symbol_name = 'BoxFamily'

# Initialize a collector for Mass symbols
collector = FilteredElementCollector(doc)
collector.OfCategory(BuiltInCategory.OST_Mass)
collector.OfClass(FamilySymbol)

# Find the target FamilySymbol by name
family_symbol = None
for symbol in collector:
    if symbol.Family.Name == target_symbol_name:
        family_symbol = symbol
        break

# If found, place a 10x10 grid of family instances
if family_symbol:
    # Ensure symbol is active before placing instances
    if not family_symbol.IsActive:
        family_symbol.Activate()
        
    for i in range(10):
        for j in range(10):
            # Define coordinates (spacing elements by 70 feet)
            location = XYZ(i * 70.0, j * 70.0, 0.0)
            
            # Place instance
            instance = doc.FamilyCreate.NewFamilyInstance(
                location, 
                family_symbol, 
                Structure.StructuralType.NonStructural
            )

t.Commit()
```

---

## 3. Working with Adaptive Components

Adaptive Components are parametric elements anchored to multiple independent insertion nodes (adaptive points) instead of a single insertion point.

### Workflow for Placing and Orienting Adaptive Components:
1.  **Retrieve Symbol**: Collect the target adaptive `FamilySymbol` from the database.
2.  **Instantiate**: Place a raw instance using `AdaptiveComponentInstanceUtils.CreateAdaptiveComponentInstance()`.
3.  **Retrieve Nodes**: Obtain references to the physical adaptive points inside the instance using `AdaptiveComponentInstanceUtils.GetInstancePlacementPointElementRefIds()`.
4.  **Translate/Move**: Reposition each point using `ElementTransformUtils.MoveElement()`.

```python
import clr
clr.AddReference('RevitAPI')
from Autodesk.Revit.DB import *

doc = __revit__.ActiveUIDocument.Document

t = Transaction(doc, 'Place and Orient Adaptive Component')
t.Start()

target_adapt_name = 'AdaptiveComponentTest'

# Collect Adaptive Family Symbols (typically Generic Models category)
collector = FilteredElementCollector(doc)
collector.OfCategory(BuiltInCategory.OST_GenericModel)
collector.OfClass(FamilySymbol)

target_symbol = None
for symbol in collector:
    if symbol.Family.Name == target_adapt_name:
        target_symbol = symbol
        break

if target_symbol:
    # Ensure symbol is active
    if not target_symbol.IsActive:
        target_symbol.Activate()

    # Step A: Instantiate the adaptive component in the active document
    adapt_instance = AdaptiveComponentInstanceUtils.CreateAdaptiveComponentInstance(doc, target_symbol)

    # Step B: Get the Element IDs of the placement nodes
    placement_points = AdaptiveComponentInstanceUtils.GetInstancePlacementPointElementRefIds(adapt_instance)

    # Step C: Retrieve current physical points
    pt_nodes = [doc.GetElement(point_id) for point_id in placement_points]

    # Step D: Define target 3D locations for 4 corners of adaptive component
    target_locations = [
        XYZ(0.0, 0.0, 0.0),
        XYZ(0.0, 40.0, 20.0),
        XYZ(40.0, 40.0, 0.0),
        XYZ(40.0, 0.0, 20.0)
    ]

    # Step E: Move each point to its target location using translation vectors
    for i in range(len(pt_nodes)):
        current_node = pt_nodes[i]
        target_location = target_locations[i]
        
        # Calculate vector displacement
        translation_vector = target_location.Subtract(current_node.Position)
        
        # Shift the node
        ElementTransformUtils.MoveElement(doc, placement_points[i], translation_vector)

t.Commit()
```
