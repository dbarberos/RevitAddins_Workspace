# Skill: Data Extraction and Mutation (Parameter Management & Storage Types)

## 1. Technical Data Sheet and Metadata for the Agent
* **Skill ID:** SKILL-RVT-005
* **Technical Area:** Data Engineering / BIM Information Management
* **API dependencies:** `Autodesk.Revit.DB.Parameter`, `Autodesk.Revit.DB.BuiltInParameter`
* **Key Concepts:** StorageType, UnitUtils (Unit Conversion), Shared Parameters (GUID)
* **Operational Impact:** Critical (Basis for model audits, export to external databases and automation of measurements).

---

## 2. Architecture of the Parameter System in Revit



In the Revit API, data are not simple properties of a class (e.g. there is no such thing as `wall.Height`). The information is managed through the `Parameter` class, which acts as a container attached to each `Element`.

There are three main ways to access a parameter, ordered from most to least efficient and secure:

1. **BuiltInParameter (Native):** A C++ enumerator that guarantees O(1) access. It is immutable and does not depend on the Revit interface language. It is the gold standard for software engineering in Revit.
2. **Shared Parameter (GUID):** Accessed using a universally unique identifier (GUID). Secure and consistent across multiple projects and families.
3. **By Name (String):** The slowest and most error-prone method. It depends on the user not renaming the parameter and fails if the model is opened in Revit with a different language (e.g. "Width" vs "Width").

---

## 3. Code Comparison Matrix and Antipatterns

### Common Antipattern (Fragility and Slowness)
```csharp
// FATAL: Searching by string degrades performance and breaks code in multi-language environments.
Parameter paramVolume = wall.LookupParameter("Volume");

if (paramVolume != null)
{
    // FATAL: Assume the data type and do not manage the conversion of internal units (Cubic Feet)
    double volume = paramVolume.AsDouble(); 
}
Optimized Pattern (Robustness and Strong Typing)
C#
// CORRECT: Direct access to the C++ core via BuiltInParameter.
Parameter paramVolume = wall.get_Parameter(BuiltInParameter.HOST_VOLUME_COMPUTED);

if (paramVolume != null && paramVolume.HasValue)
{
    // OK: Storage type check before extraction.
    if (paramVolume.StorageType == StorageType.Double)
    {
        double internalVolume = paramVolume.AsDouble();
        
        // Explicit conversion from imperial units (internal Revit) to metric (International System)
        // Note: UnitUtils changed significantly starting with Revit 2021/2022 (ForgeTypeId)
        doubleMetricVolume = UnitUtils.ConvertFromInternalUnits(internalVolume, UnitTypeId.CubicMeters);
    }
}
4. Parameter Mutation (Writing)
To write data, the .Set() method is used. This operation is a mutation of the database and requires necessarily being involved in an active transaction (See SKILL_03).
The .Set() method is overloaded to accept different types of data. The agent must inject the correct type based on the StorageType parameter:
StorageType.Double -> .Set(double) (Attention to reverse conversion to internal units).
StorageType.Integer -> .Set(int) (Also used for Yes/No parameters, where 1=Yes, 0=No).
StorageType.String -> .Set(string).
StorageType.ElementId -> .Set(ElementId) (Used to assign materials or change family types).
C#
//Safe mutation example
Parameter paramComments = wall.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);

if (paramComments != null && !paramComments.IsReadOnly)
{
    paramComments.Set("BIM Audit Completed");
}
5. Agent Injection Instructions (Prompting Prompt)
To ensure the creation of clean, fault-tolerant code aligned with high-level .NET development standards, apply these rules:
Zero Local Strings: The use of LookupParameter("ParameterName") for native Revit parameters is strictly prohibited. The agent should always look for its equivalent in the BuiltInParameter enumerator.
Pre-Check (Defensive Programming): Before calling .AsDouble(), .AsString(), etc., always evaluate whether the parameter exists (!= null) and whether it contains valid information by checking the param.HasValue property.
Read Only Control: Before trying to mutate a parameter with .Set(), always check the param.IsReadOnly property. Trying to write to a locked parameter (e.g. calculated by a formula) will throw a fatal exception.
Unit Isolation: Encapsulates the unit conversion logic of UnitUtils in extension methods or static helper classes (Helpers). Keep the main methods (Execute) clean of conversion arithmetic operations.

***

With this module, the agent's knowledge repository already covers the complete life cycle of an Add-in: UI Initialization, Command Injection, DB Filtering, Transactional Mutation and Metadata Management. All of this forms a robust architectural base, ideal for facing technical tests or structuring complex projects.