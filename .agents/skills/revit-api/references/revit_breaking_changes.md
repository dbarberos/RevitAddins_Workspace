# Revit API Compatibility & Breaking Changes

Autodesk Revit updates its API frequently, sometimes deprecating and removing critical classes or methods. The most significant historical change is in the unit systems.

## 1. The Units System Overhaul (Revit 2021/2022+)

Historically, Revit used the `DisplayUnitType` enum to represent unit displays. From Revit 2021/2022 onwards, this has been fully deprecated and replaced by `ForgeTypeId`.

### The Core Replacements
* Use `ForgeTypeId` instead of `DisplayUnitType`.
* Use `UnitUtils` or `LabelUtils` with `ForgeTypeId` for string formatting and conversions.

| Obsolete API (Pre-2021) | Modern API (2021+) |
|---|---|
| `DisplayUnitType` | `ForgeTypeId` (e.g. `UnitTypeId.Millimeters`, `UnitTypeId.Feet`) |
| `Parameter.DisplayUnitType` | `Parameter.GetUnitTypeId()` |
| `UnitUtils.ConvertFromInternalUnits()` | `UnitUtils.ConvertFromInternalUnits(val, forgeTypeId)` |
| `UnitUtils.ConvertToInternalUnits()` | `UnitUtils.ConvertToInternalUnits(val, forgeTypeId)` |

### Modern C# Unit Conversion Example (Revit 2022+)
```csharp
// Converting Revit internal units (always Feet) to Millimeters
double internalValue = parameter.AsDouble();
double mmValue = UnitUtils.ConvertFromInternalUnits(internalValue, UnitTypeId.Millimeters);

// Getting parameter's unit type dynamically
ForgeTypeId paramUnitType = parameter.GetUnitTypeId();
```

---

## 2. API Deprecations Reference Table

Keep this in mind when developing multi-version add-ins:

| Obsolete Element | Replacement | Since Version | Reason / Impact |
|---|---|---|---|
| `Parameter.Definition.UnitType` | `Parameter.Definition.GetDataType()` | Revit 2022 | Structural parameter changes |
| `doc.Create.NewFamilyInstance()` | Use specific overloads or `FamilyInstanceCreationData` | Revit 2023+ | Direct creation methods deprecated |
| `DisplayUnitType` | `ForgeTypeId` | Revit 2022 | Fully removed in 2022. Will crash compile. |
| `ParameterType` | `ForgeTypeId` | Revit 2022 | Deprecated. Use `SpecTypeId` instead. |

---

## 3. Python (pyRevit) Backward Compatibility

In Python scripts, resolving `ForgeTypeId` requires importing the correct namespaces safely using `clr`.

```python
import clr
clr.AddReference('RevitAPI')
from Autodesk.Revit.DB import UnitTypeId, UnitUtils

# Convert internal feet value to millimeters
mm_value = UnitUtils.ConvertFromInternalUnits(value, UnitTypeId.Millimeters)
```
