# Skill: Generation of Documentation and Planimetry (Views, Sheets & Viewports)

## 1. Technical Data Sheet and Metadata for the Agent
* **Skill ID:** SKILL-RVT-009
* **Technical Area:** Plan Automation / Documentation / View Management
* **API dependencies:** `Autodesk.Revit.DB.ViewSheet`, `Autodesk.Revit.DB.View`, `Autodesk.Revit.DB.Viewport`, `Autodesk.Revit.DB.ViewFamilyType`
* **Key Concepts:** ViewFamilyType (Base Templates), TitleBlocks (Boxes), Spatial Coordination of Viewports.
* **Operational Impact:** Critical (Allows packaged delivery of projects, massive generation of layout plans and standardization of deliverables).

---

## 2. Documentation Ontology in Revit API

The agent must understand that a "Plan" printed in Revit is the result of assembling three distinct and independent entities in the database:

1. **The View (`View`):** The projected representation of the model (Plan, Section, 3D). It has scale, view range and visibility filters.
2. **The Plane (`ViewSheet`):** The virtual "paper" canvas. It is linked to a title block family (`TitleBlock`).
3. **The Graphics Window (`Viewport`):** The bridge or bidirectional link. It is the object that cuts the view and projects it in specific 2D coordinates on the plane (`ViewSheet`).

---

## 3. Safe View Creation (`ViewPlan.Create`)

To create a new view (e.g. a Plant), a class is not instantiated, but a static method is invoked. This requires first knowing the `ViewFamilyType` (the view system type, such as "Floor Plan" or "Ceiling Plan") and the associated `Level`.

### Optimized Pattern (Extraction and Creation)
```csharp
// 1. Get the correct view type using a quick LINQ filter
ViewFamilyTypePlantType = new FilteredElementCollector(doc)
    .OfClass(typeof(ViewFamilyType))
    .Cast<ViewFamilyType>()
    .FirstOrDefault(v => v.ViewFamily == ViewFamily.FloorPlan);

if (plantType != null)
{
    // 2. Creation within an active transaction
    ViewPlan newView = ViewPlan.Create(doc, plantType.Id, levelId);
    newView.Name = "Relay Plant - Level 1"; 
    // Note: The Revit engine will throw exception if the name already exists.
}
4. Assembly of Plans and Viewports
The process of creating a plan requires having a TitleBlock symbol loaded and activated. The placement of the view on the plane using a Viewport is done using 2D spatial coordinates (with origin in the lower left corner of the box).
Antipattern Matrix vs Robust Code
Common Antipattern (Risk of Duplicate View Exception)
C#
// FATAL: Assume that any view can be placed on a plane.
Viewport.Create(doc, mySheet.Id, myView.Id, new XYZ(0,0,0)); 
// Fails if the view is already on ANOTHER plane (except legend or detail views).
Optimized Pattern (Prior Verification and Coordination)
C#
// 1. Recover Box Symbol
FamilySymbol titleBlock = GetTitleBlock(doc, "A1 metric");

if (titleBlock != null)
{
    // 2. Create Sheet
    ViewSheet newPlane = ViewSheet.Create(doc, titleBlock.Id);
    newPlan.Name = "Architecture - Ground Floor";
    newSheet.SheetNumber = "ARQ-100";

    // 3. Validate if the view is eligible to be placed
    if (Viewport.CanAddViewToSheet(doc, newPlane.Id, planview.Id))
    {
        // 4. Place at the geometric center (Initial approach at point 0,0,0 of the plane)
        // Coordinates on sheets are measured in feet internally.
        XYZplanecenter = new XYZ(1.5, 1.0, 0); 
        Viewport newViewport = Viewport.Create(doc, newPlane.Id, planView.Id, plancenter);
    }
}
5. Agent Injection Instructions (Prompting Prompt)
To guarantee stability in automatic documentation processes, the following directives must be applied:
Name Uniqueness Validation: Before assigning a name to a sheet (SheetNumber or Name) or a view, you MUST verify that it does not already exist in the database using a FilteredElementCollector. If you assign a duplicate name, the API will throw a validation fatal exception.
View Exclusivity Rule: Model views (Plans, Sections, Elevations, 3D) can only exist in one (1) single ViewSheet simultaneously. Always use the static Viewport.CanAddViewToSheet() method before calling Viewport.Create().
ViewFamilyType Rigid Search: To locate view types, filter using the native ViewFamily enumerator (e.g. ViewFamily.FloorPlan, ViewFamily.Section), never depend on the type name (string), since the names vary if the user uses Revit in Spanish, English or French.
Default Title Blocks: If an algorithm does not provide a valid TitleBlock ID (e.g. ElementId.InvalidElementId), the ViewSheet.Create method will use a "blank" sheet or the system's generic title block. Always avoid this by solving the Corporate Box Symbol beforehand.