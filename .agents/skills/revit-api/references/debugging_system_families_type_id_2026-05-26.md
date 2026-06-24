# Debugging Report: System Families & GetTypeId()

## 1. Symptom
When developing the "Same Family" and "Same Type" selection functionality in *FilterPlus*, "System Families" (Walls, Floors, Pipes, Ducts) and other base elements were not processed correctly. The algorithm was unable to identify the family and type to which these elements belonged, returning empty lists.

## 2. Root Cause
The original code attempted to access family information using strict *casting* to `Autodesk.Revit.DB.FamilyInstance` or `Autodesk.Revit.DB.HostObject` in order to read the `Symbol.FamilyName` or `Symbol.Id` properties.

```csharp
// Original defective code
if (el is Autodesk.Revit.DB.FamilyInstance fi && fi.Symbol != null)
{
    targetFamilyNames.Add(fi.Symbol.FamilyName);
}
```

However, in Revit, many base elements and system families do not derive from `FamilyInstance`. When attempting to evaluate them, the `is` casting failed and type extraction was ignored, preventing the selection by Family/Type from encompassing the entirety of the model.

## 3. Applied Solution
Instead of relying on specific classes, the base architecture of the Revit API must be leveraged. The vast majority of elements in Revit inherit the `GetTypeId()` method directly from the base `Element` class.

By obtaining the `ElementId` of the type, we can query the document and safely cast to `ElementType`, which contains the universal `FamilyName` property applicable to both loadable and system families.

```csharp
// Robust and Universal Solution
var typeId = el.GetTypeId();
if (typeId != null && typeId != Autodesk.Revit.DB.ElementId.InvalidElementId)
{
    var type = doc.GetElement(typeId) as Autodesk.Revit.DB.ElementType;
    if (type != null && !string.IsNullOrEmpty(type.FamilyName))
    {
        targetFamilyNames.Add(type.FamilyName);
    }
}
```

This refactoring solves the root problem, unifying access to Types and Families and ensuring that no object hierarchy in Revit is excluded.
