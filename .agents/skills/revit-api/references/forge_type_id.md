## ✅ ForgeTypeId — Modern Units (Revit 2022+)

Since Revit 2022, integer-based unit types (`DisplayUnitType`, `UnitType`) are **obsolete**. Always use `ForgeTypeId`:

### Unit Conversion

```csharp
// ✅ CORRECT (Revit 2022+): ForgeTypeId
double meters = UnitUtils.ConvertFromInternalUnits(feetValue, UnitTypeId.Meters);
double feet = UnitUtils.ConvertToInternalUnits(metersValue, UnitTypeId.Meters);

// ❌ OBSOLETE (pre-2022): DisplayUnitType
double meters = UnitUtils.ConvertFromInternalUnits(feetValue, DisplayUnitType.DUT_METERS); // CS0618
```

### Reading parameters with specification type

```csharp
// ✅ CORRECT: Verify parameter type with SpecTypeId
Parameter param = element.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH);
if (param != null && param.Definition.GetDataType() == SpecTypeId.Length)
{
    double lengthInMeters = UnitUtils.ConvertFromInternalUnits(param.AsDouble(), UnitTypeId.Meters);
}
```

### Table of most common ForgeTypeIds

| Concept | Class | Examples |
|----------|-------|----------|
| **What is measured** (specification) | `SpecTypeId` | `.Length`, `.Area`, `.Volume`, `.Angle`, `.Mass` |
| **In what unit** (unit) | `UnitTypeId` | `.Meters`, `.Millimeters`, `.Feet`, `.Degrees`, `.SquareMeters` |
| **Parameter data type** | `ParameterTypeId` | `.Text`, `.Integer`, `.YesNo`, `.Material` |

---
