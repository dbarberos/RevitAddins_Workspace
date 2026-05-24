# Efficient Data Filtering: FilteredElementCollector Optimization

AECO models routinely contain hundreds of thousands or even millions of elements. Doing inefficient filtering will block the Revit UI, consume gigabytes of RAM, and potentially cause Revit to run out of memory.

## 1. Quick Filters vs. Slow Filters (The Golden Rule)

Revit elements live in native C++ memory. FilteredElementCollector operations are executed in C++ BEFORE the elements are marshaled into the managed C# or Python environment.
* **Quick Filters:** Filter elements in native C++ without loading their full geometry or parameters into memory.
* **Slow Filters:** Must parse the entire Revit element. This marshals them into C#/.NET/Python memory, which is extremely expensive.

**Rule: ALWAYS chain as many Quick Filters as possible before applying a Slow Filter or LINQ.**

### Quick Filters (Preferred)
* `OfClass(Type)`
* `OfCategory(BuiltInCategory)`
* `WhereElementIsNotElementType()`
* `WhereElementIsElementType()`
* `WherePasses(ElementFilter)` (if filter is quick)

### Slow Filters (Avoid when possible, apply last)
* `WherePasses(LogicalAndFilter)` (using slow sub-filters)
* Parameter filters checking specific string values.
* Custom LINQ filters checking custom element rules.

---

## 2. Prohibiting Early LINQ/Memory Conversion

**Rule: NEVER use `.ToElements()`, `.ToList()`, or conversion to Python list (`list()`) until you have fully narrowed down the elements.**

### C# High-Performance Filtering Example
```csharp
// CORRECT: High-speed native C++ filtering
var collector = new FilteredElementCollector(doc)
    .OfCategory(BuiltInCategory.OST_Walls)
    .WhereElementIsNotElementType() // Quick filter
    .OfClass(typeof(Wall));          // Quick filter

// Apply slow LINQ filter only after elements are down to a minimum
var concreteWalls = collector
    .Cast<Wall>()
    .Where(w => w.Name.Contains("Concrete")) // LINQ (In-Memory)
    .ToList();

// WRONG (Agent will be penalized): Loads thousands of elements into RAM first
var allElements = new FilteredElementCollector(doc).ToElements(); // Marshals everything!
var walls = allElements.OfType<Wall>().Where(w => w.Name.Contains("Concrete"));
```

### pyRevit Python High-Performance Filtering Example
```python
from pyrevit import revit
from Autodesk.Revit.DB import FilteredElementCollector, BuiltInCategory, Wall

doc = revit.doc

# CORRECT: Keeps execution in C++ before python parsing
collector = FilteredElementCollector(doc)\
    .OfCategory(BuiltInCategory.OST_Walls)\
    .WhereElementIsNotElementType()

# Iterate directly on the collector (does not load everything at once)
for wall in collector:
    if "Concrete" in wall.Name:
        # Action...
```
