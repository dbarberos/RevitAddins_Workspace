# Skill: Materials Management, Thermal/Physical Assets and Appearance (Material API)

## 1. Technical Data Sheet and Metadata for the Agent
* **Skill ID:** SKILL-RVT-026
* **Technical Area:** Data Containers / Rendering (PBR) / Life Cycle Assessment (LCA)
* **API dependencies:** `Autodesk.Revit.DB.Material`, `Autodesk.Revit.DB.PropertySetElement`, `Autodesk.Revit.DB.Visual.AppearanceAssetEditScope`
* **Key Concepts:** Asset Sharing, EditScope, PBR Materials, Face Painting.
* **Operational Impact:** Allows you to standardize material database nomenclatures, automate the assignment of properties for energy simulations and generate real-time data visualization tools (Data Painting).

---

## 2. Material Ontology: The Container and Assets

In the Revit API, the `Material` class acts only as a "shell" or container for basic metadata (Name, Class, Notes, Plane Hatch Patterns). 

Complex properties are stored in three separate entities called **Assets**, to which the material points via its `ElementId`. This means that multiple materials can share the same Asset (e.g. *HA-25 Concrete* and *HA-30 Concrete* can share the same gray texture Visual Asset, but have different Structural Assets).

1. **Appearance Asset (`AppearanceAssetElement`):** Contains the rendering information (Bitmaps, reflectivity, roughness). Namespace: `Autodesk.Revit.DB.Visual`.
2. **Structural Asset (`PropertySetElement`):** Contains the physics (Density, Yield Strength, Young's Modulus).
3. **Thermal Asset (`PropertySetElement`):** Contains thermodynamics (Specific heat, Conductivity, Porosity).

---

## 3. Safe Material Creation and Search

Revit requires that material names be unique in the document. Trying to create a material with an existing name will throw an exception.

### Optimized Pattern (Transactional Extract and Create)
```csharp
public Material GetOrCreateMaterial(Document doc, string targetName)
{
    // 1. Quick search using LINQ and FilteredElementCollector
    Material materialExisting = new FilteredElementCollector(doc)
        .OfClass(typeof(Material))
        .Cast<Material>()
        .FirstOrDefault(m => m.Name.Equals(targetName, StringComparison.InvariantCultureIgnoreCase));

    if (existingMaterial != null) return existingMaterial;

    // 2. Creation if it does not exist (Requires active transaction at the top level)
    ElementId newMatId = Material.Create(doc, targetName);
    Material newMaterial = doc.GetElement(newMatId) as Material;
    
    // Basic configuration
    newMaterial.MaterialClass = "Concrete";
    newMaterial.Color = new Color(128, 128, 128); // Standard gray for shaded views
    
    return newMaterial;
}
4. Advanced Mutation: The AppearanceAssetEditScope
Modifying the texture or color of a render is not done with a simple .Set(). Due to the memory architecture of the render engine (Protein), a special "Edit Tunnel" called AppearanceAssetEditScope must be opened.
If a shared AppearanceAssetElement is modified, all materials pointing to it will change. If the goal is to alter only one material, the agent must duplicate the Asset first.
Optimized Pattern (PBR Color Modification)
C#
using Autodesk.Revit.DB.Visual;

public void ModifyAppearanceColor(Document doc, Material material, Color newColor)
{
    ElementId assetId = material.AppearanceAssetId;
    if (assetId == ElementId.InvalidElementId) return; // The material does not have a render appearance

    AppearanceAssetElement asset = doc.GetElement(assetId) as AppearanceAssetElement;

    using (Transaction t = new Transaction(doc, "Modify Visual Asset"))
    {
        t.Start();
        
        // 1. Open the graphics memory editing tunnel
        using (AppearanceAssetEditScope editScope = new AppearanceAssetEditScope(doc))
{
            // 2. Extract editable properties
            Asset editableAsset = editScope.Start(asset.Id);
            
            // 3. Navigate to the generic color property (Diffuse/Albedo)
            AssetPropertyDoubleArray4d colorProp = editableAsset.FindByName("generic_diffuse") as AssetPropertyDoubleArray4d;
            
            if (colorProp != null)
            {
                // The render engine uses normalized values (0.0 to 1.0) with Alpha channel
                colorProp.SetValueAsColor(new ColorWithTransparency(newColor.Red, newColor.Green, newColor.Blue, 0));
            }
            
            // 4. Close the tunnel and apply changes to the database
            editScope.Commit(true);
        }
        
        t.Commit();
    }
}
5. Data Visualization (Data Painting)
Instead of altering the structural parameter of the wall, a very powerful technique for creating visual Dashboards in Revit is to "paint" the faces of elements temporarily to represent states (e.g. Green = Approved, Red = Rejected).
The doc.Paint() method is used.
C#
public void PaintElementByState(Document doc, Element element, Material materialState)
{
    using (Transaction t = new Transaction(doc, "Data Painting"))
    {
        t.Start();
        
        // Extract the geometry (SKILL 6) to iterate over its solid faces
        Options opt = new Options();
        GeometryElement geomElem = element.get_Geometry(opt);
        
        foreach (GeometryObject geomObj in geomElem)
        {
            if (geomObj is Solid solid && solid.Volume > 0)
            {
                foreach (Face face in solid.Faces)
                {
                    // Paint the specific face with the state material ID
                    doc.Paint(element.Id, face, materialState.Id);
                }
            }
        }
        t.Commit();
    }
}
6. Agent Injection Instructions (Prompting Prompt)
When processing code that alters, creates, or audits the model's materials library, strictly apply these engineering guidelines:
Uniqueness Validation: Before invoking Material.Create(), it is mandatory to search the document if the name already exists using a FilteredElementCollector. If it exists, return the existing material; otherwise Revit will throw a fatal exception.
Protection of Shared Assets: If a request is made to modify the physics or texture of a material, the agent MUST first check whether the AppearanceAssetElement or PropertySetElement is being used by other materials (by indirectly evaluating how many materials point to that ID). If it is shared and a global override is not desired, call AppearanceAssetElement.Duplicate() before applying the overrides.
Using the EditScope: It is strictly prohibited to attempt to extract or modify properties of the Asset class outside of a using (AppearanceAssetEditScope) block. The Autodesk Protein engine will invalidate memory pointers immediately.
RemovePaint: When developing Data Painting algorithms for data visualization, always inject a cleanup routine (doc.RemovePaint(elementId, face)) that runs before applying new layers or at the end of the analysis cycle, to avoid contaminating the user's finished area measurements.

***