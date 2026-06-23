# Reading and Writing Text Files (CSV/TXT) in RevitPythonShell

This reference guide explains how to read and write text and CSV files inside **RevitPythonShell** to exchange parameter values and coordinates with external systems using `.NET`'s `System.IO` classes or native Python built-ins.

---

## 1. Reading Files and Parsing CSV Data

To read text files line-by-line, you can use `.NET`'s `System.IO.StreamReader` class. This is extremely useful for importing coordinate arrays or family settings.

### Method A: StreamReader with peek loops (Standard .NET CLR approach)
```python
import clr
import System
clr.AddReference('RevitAPI')
from Autodesk.Revit.DB import *

doc = __revit__.ActiveUIDocument.Document

t = Transaction(doc, 'Import coordinates from CSV')
t.Start()

filepath = 'C:/RevitData/points_import.csv'

# Instantiate StreamReader
if System.IO.File.Exists(filepath):
    filereader = System.IO.StreamReader(filepath)
    
    # Read line-by-line until Peek returns -1 (EOF)
    while filereader.Peek() > -1:
        line = filereader.ReadLine()
        
        # Parse comma-separated coordinates
        string_array = line.Split(",")
        if len(string_array) >= 3:
            # Safely parse coordinate strings to floats
            x = float(string_array[0])
            y = float(string_array[1])
            z = float(string_array[2])
            
            # Place a ReferencePoint element in Revit Conceptual Mass
            point_location = XYZ(x, y, z)
            doc.FamilyCreate.NewReferencePoint(point_location)
            
    # Always close the stream reader to release the file handle
    filereader.Close()

t.Commit()
```

### Method B: Native Python `open` statement (Alternative approach)
Since RevitPythonShell is an IronPython interpreter, standard Python I/O syntax is also fully supported.

```python
# Reading CSV using Python's native open
filepath = 'C:/RevitData/points_import.csv'

with open(filepath, 'r') as f:
    for line in f:
        parts = line.strip().split(',')
        if len(parts) >= 3:
            x, y, z = map(float, parts)
            print("X: {}, Y: {}, Z: {}".format(x, y, z))
```

---

## 2. Writing Parameter and Coordinate Data to Disk

Writing data enables exporting Revit schedules, coordinates, or element counts into text files or CSV spreadsheets.

### Method A: StreamWriter (Standard .NET CLR approach)
To write data, construct a `System.IO.StreamWriter`. It is critical to perform safety checks first to avoid locks or file overwrites.

```python
import clr
import System
clr.AddReference('RevitAPI')
from Autodesk.Revit.DB import *

doc = __revit__.ActiveUIDocument.Document

t = Transaction(doc, 'Export Mass Element Heights')
t.Start()

filepath = 'C:/RevitData/mass_heights_export.csv'

# Step A: Perform file safety checks
if System.IO.File.Exists(filepath):
    System.IO.File.Delete(filepath) # Remove existing file to prevent conflicts

# Step B: Open Stream Writer
filewriter = System.IO.StreamWriter(filepath)

# Write header row
filewriter.WriteLine("ElementID,FamilyName,Height")

# Collect all mass family instances
collector = FilteredElementCollector(doc)
collector.OfCategory(BuiltInCategory.OST_Mass)
collector.OfClass(FamilyInstance)

# Step C: Iterate and write attributes
for instance in collector:
    elem_id = instance.Id.IntegerValue
    fam_name = instance.Name
    
    height_param = instance.LookupParameter('height') or instance.GetParameters('height')[0]
    height_val = height_param.AsDouble() if height_param else 0.0
    
    # Write line
    filewriter.WriteLine("{},{},{}".format(elem_id, fam_name, height_val))

# Step D: Flush buffers and close the file stream
filewriter.Close()

t.Commit()
```

### Method B: Native Python `open` statement (Alternative approach)
```python
filepath = 'C:/RevitData/mass_heights_export.csv'

# Using Python's context manager safely manages resources and closes the stream automatically
with open(filepath, 'w') as f:
    f.write("ElementID,FamilyName,Height\n")
    f.write("12345,BoxFamily,15.5\n")
```
