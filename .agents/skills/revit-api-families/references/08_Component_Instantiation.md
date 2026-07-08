# Skill: Component Instantiation, Symbol Activation and Family Loading

## 1. Technical Data Sheet and Metadata for the Agent
* **Skill ID:** SKILL-RVT-008
* **Technical Area:** Component Instantiation / Asset Deployment
* **API dependencies:** `Autodesk.Revit.DB.FamilySymbol`, `Autodesk.Revit.DB.FamilyInstance`, `Autodesk.Revit.Creation.ItemFactoryBase`
* **Design Patterns:** Factory Pattern (Creation delegated to `doc.Create`)
* **Operational Impact:** Critical (Basis for generative design routines, automatic staking and algorithmic furnishing).

---

## 2. Ontological Hierarchy: Family > Symbol > Instance



To inject an element into the model, the agent must understand the three-level inheritance structure that Revit imposes:

1. **`Family` (The RFA File):** It is the global container. It has no tangible geometry in the project space, it only defines parametric logic.
2. **`FamilySymbol` (The Type):** Represents a specific "Type" within the family (e.g. *800x2000mm door*). Contains the static values ​​of the type parameters. **It is the element that is actually used to create the geometry.**
3. **`FamilyInstance` (The Physical Object):** It is the physical manifestation of the `FamilySymbol` on the canvas, with specific `XYZ` coordinates and unique instance parameters.

---

## 3. The Activation State (`IsActive`)

For RAM optimization reasons, Revit does not load the 3D geometry of all Types in a family when you open the project. Only activate those that already have modeled instances.

**Architectural Rule:** If you try to instantiate a `FamilySymbol` whose `.IsActive` property is `false`, Revit will throw a fatal exception of type `Autodesk.Revit.Exceptions.ArgumentException`.

### Code Comparison Matrix and Antipatterns

*Common Antipattern (Crash Risk)*
```csharp
// FATAL: Assume that finding the Symbol in the database is enough to use it.
FamilySymbol doorsymbol = GetSymbol(doc, "Simple Door", "800x2000mm");

// If this type has never been used in the current project, the following line fails
FamilyInstance newDoor = doc.Create.NewFamilyInstance(coordinate, doorSymbol, level, StructuralType.NonStructural);
Optimized Pattern (Secure and Transactional Activation)
C#
FamilySymbol doorsymbol = GetSymbol(doc, "Simple Door", "800x2000mm");

if (doorsymbol != null)
{
    // Activation mutates the internal state of the document, MUST be in a Transaction
    if (!doorsymbol.IsActive)
    {
        doorSymbol.Activate();
        doc.Regenerate(); // Required to ensure that Revit compiles the geometry in memory
    }

    // Secure Instantiation using the native Factory pattern
    FamilyInstance newDoor = doc.Create.NewFamilyInstance(
        coordinate, 
        symbolDoor, 
        level, 
        StructuralType.NonStructural
    );
}
4. Loading Strategies (LoadFamily)
If the family does not exist in the project, it must be loaded from the hard drive (.rfa). This also requires an active transaction. The doc.LoadFamily method has an overload that allows you to implement the IFamilyLoadOptions interface, crucial for silently handling conflicts (e.g. when the family already exists and you need to overwrite its parameters without triggering the native Revit pop-up).
C#
public class SilentLoadRoutine : IFamilyLoadOptions
{
    public bool OnFamilyFound(bool familyInUse, out bool overwriteParameterValues)
    {
        overwriteParameterValues = true; // Force silent overwrite
        return true;                     // Continue loading
    }

    public bool OnSharedFamilyFound(Family sharedFamily, bool familyInUse, out FamilySource source, out bool overwriteParameterValues)
    {
        source = FamilySource.Family;
        overwriteParameterValues ​​= true;
        return true;
    }
}
5. Agent Injection Instructions (Prompting Prompt)
When you are ordered to create family instantiation or placement routines, you must strictly adhere to these directives:
Mandatory Activation Check: Before invoking doc.Create.NewFamilyInstance, you must explicitly evaluate FamilySymbol.IsActive. If false, calls .Activate() followed by doc.Regenerate() inside the transactional block.
Name Ambiguity Resolution: Never assume that a Symbol name is unique in the entire project. Searches for the FamilySymbol by crossing both its name (Symbol.Name) and the name of its containing Family (Symbol.FamilyName), using LINQ on a FilteredElementCollector pre-filtered by the FamilySymbol class.
Correct Use of the Constructor (Factory): The NewFamilyInstance method is highly overloaded. Select the correct signature based on whether the family is level-hosted (requires XYZ and Level), face-based (requires Reference, XYZ, and Address XYZ), or wall/host-based (requires Element host and XYZ).
Dialog Suppression (IFamilyLoadOptions): If you build a bulk family loading tool, always inject a class that implements IFamilyLoadOptions to prevent execution from stopping waiting for manual user confirmation in the event of overwrites.

***

### How to proceed?

This module ensures that automated layout routines are robust and do not break due to latent memory states.