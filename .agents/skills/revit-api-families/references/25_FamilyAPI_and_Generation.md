# Skill: Parametric Generation and Family Editing (Family API & Geometry Creation)

## 1. Technical Data Sheet and Metadata for the Agent
* **Skill ID:** SKILL-RVT-025
* **Technical Area:** Parametric Modeling / Generative Design / Family Document
* **API dependencies:** `Autodesk.Revit.DB.FamilyManager`, `Autodesk.Revit.DB.FamilyItemFactory`, `Autodesk.Revit.DB.ReferencePlane`
* **Key Concepts:** FamilyDocument, Extrusion/Sweep/Blend, Dimension Alignment, Formulas.
* **Operational Impact:** Expert Level. It allows you to build product configurators (CPQ), automate the creation of massive catalogs and translate CAD/Rhino models to native Revit parametric elements.

---

## 2. The Family Document Paradigm (`FamilyDocument`)

The first architectural barrier is that **code that works in a Project (`.rvt`) often fails in a Family (`.rfa`)**. 

The agent must evaluate the runtime environment using the `doc.IsFamilyDocument` property. If `true`, the document has no levels, rooms, or plan views in use. Additionally, the object used to create items is no longer `doc.Create`, but `doc.FamilyCreate` (which returns a `FamilyItemFactory`).


[See pattern implementation in: assets/FamilyDocumentContextValidator.cs]


---

## 3. Parametric Skeleton: Reference Planes and Dimensions

A robust family is not based on drawing rigid geometry (fixed cubes). It is based on drawing a geometry anchored to an invisible skeleton of **Reference Planes (`ReferencePlane`)**, which are controlled by parameters.

### Optimized Pattern (Skeleton Creation)


[See pattern implementation in: assets/ParametricReferencePlaneBuilder.cs]


---

## 4. The Family Manager (`FamilyManager`)

Adding parameters (Width, Height, Material) and creating Types (Symbols) within the `.rfa` file is done through the `FamilyManager` class.

**Critical Operations:**

* `AddParameter()`: Create a new parameter.
* `NewType()`: Create a variation of the family (e.g. "80x80 table").
* `Set()` / `SetFormula()`: Assigns values ​​or mathematical formulas to parameters.


[See pattern implementation in: assets/FamilyParameterTypeBuilder.cs]


---

## 5. Antipattern Matrix vs Resilient Code

### Common Antipattern (Orphan Geometry)


[See pattern implementation in: assets/StaticExtrusionAntiPattern.cs]


### Optimized Pattern (Alignment and Constraint)

For the extrusion to be parametric, the code must create a dimension (`Dimension`) between the reference planes, assign a `FamilyParameter` to that dimension (Labeling) and then align/lock (`NewAlignment`) the edges of the geometry against those planes.

*(Agent Note: This process requires extracting the `Reference` from the edge of the generated solid and crossing it with the `Reference` of the plane using `doc.FamilyCreate.NewAlignment`).*

---

## 6. Agent Injection Instructions (Prompting Prompt)

*When asked to generate or modify the internal content of a Revit family (.rfa), strictly apply these architectural rules:*

1. **Environment Validation (`IsFamilyDocument`):** Any command designed for the Family API MUST begin by verifying that the `IsFamilyDocument` property is true. If false, the command must abort silently or return a structured warning.
2. **Exclusive Use of `doc.FamilyCreate`:** It is strictly prohibited to use `doc.Create` to generate reference planes, extrusions, sweeps or dimensions within a family. The agent should always inject `doc.FamilyCreate`.
3. **Skeleton Priority (Reference Planes):** When requesting the creation of a parametric shape, the agent should NEVER generate the three-dimensional geometry first. The strict algorithmic sequence is: 1) Create `ReferencePlanes`, 2) Create `FamilyParameters`, 3) Dimension and Parameterize (Label) the planes, 4) Create Geometry, 5) Align and Lock geometric edges to the planes.
4. **Mutation via the `FamilyManager`:** Do not try to change the value of a parameter in a family by reading the element's `Parameter` and using `.Set()`. In the family editor, global values ​​and formulas are mandatory injected using the `.Set()` and `.SetFormula()` methods of the `FamilyManager` object.

```

***

### Route Analysis (Next Step)

With the addition of the **Family API (SKILL 25)**, the architecture manual covers essentially the entirety of Revit's native operational domains (Modeling, Information, Coordination, UI, Manufacturing, Cloud and Families).