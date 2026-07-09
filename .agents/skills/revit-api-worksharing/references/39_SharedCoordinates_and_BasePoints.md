# Skill Reference: Shared Coordinates & Base Points

## 1. Project Base Point vs Survey Point
In Revit, georeferencing is represented by two physical elements subclassed as `BasePoint`:
1.  **Project Base Point**: Defines the origin (0,0,0) of the project coordinate system. Identified via `IsShared = false`.
2.  **Survey Point**: Represents a real-world geodetic point (like a benchmark coordinate). Identified via `IsShared = true`.

## 2. Pinning Constraints
To prevent accidental shifts of georeferencing coordinates, both `BasePoint` elements are Pinned (`Pinned = true`) by default in Revit.

> [!IMPORTANT]
> **Pin Verification**: The agent MUST check and unpin a base point (`Pinned = false`) before calling any translation methods (e.g. `ElementTransformUtils.MoveElement`). Attempting to translate a pinned coordinate point will throw a fatal `Autodesk.Revit.Exceptions.InvalidOperationException` and terminate the transaction.
> 
> Restore the pinned state (`Pinned = true`) immediately after the translation is completed.

## 3. Geometric Translation (Code Blueprint)
```csharp
BasePoint projectBasePoint = new FilteredElementCollector(doc)
    .OfClass(typeof(BasePoint))
    .Cast<BasePoint>()
    .FirstOrDefault(bp => bp.IsShared == false);

if (projectBasePoint != null)
{
    bool wasPinned = projectBasePoint.Pinned;
    
    using (Transaction t = new Transaction(doc, "Shift Origin"))
    {
        t.Start();
        
        // 1. Unpin
        if (wasPinned) projectBasePoint.Pinned = false;
        
        // 2. Translate geometry (internal units are always Feet)
        XYZ translation = new XYZ(10.0, 0.0, 0.0); // Shift 10 feet East
        ElementTransformUtils.MoveElement(doc, projectBasePoint.Id, translation);
        
        // 3. Repin
        if (wasPinned) projectBasePoint.Pinned = true;
        
        t.Commit();
    }
}
```
