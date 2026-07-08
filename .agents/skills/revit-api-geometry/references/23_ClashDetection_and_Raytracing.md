# Skill: Clash Detection & Raycasting

## 1. Technical Data Sheet and Metadata for the Agent
* **Skill ID:** SKILL-RVT-023
* **Technical Area:** Spatial Coordination / Clash Detection / Computational Geometry
* **API dependencies:** `Autodesk.Revit.DB.ElementIntersectsElementFilter`, `Autodesk.Revit.DB.ReferenceIntersector`, `Autodesk.Revit.DB.BoundingBoxIntersectsFilter`
* **Key Concepts:** Big-O Complexity, Raycasting, 3D View Context, Hard Clashes.
* **Operational Impact:** Critical. It is the core of BIM coordination audits, "Auto-Routing" algorithms (obstacle avoidance) and clearance checks (Clearance).

---

## 2. Intersection Strategies (The problem of complexity)

Collision detection is the most computationally heavy operation in the Revit API. If we compare each air duct against each structural element using brute force, the execution time grows at a rate of $O(N^2)$, which will freeze Revit for hours on real projects.

The software architecture requires a "Funneling" approach, using two layers of evaluation:

### Layer 1: Fast Filter (Bounding Box)
Orthogonal enveloping boxes (AABB) are evaluated. It is mathematically lightning fast ($O(1)$ per element in the C++ database), but imprecise. Discards 95% of elements that are too far away to collide.

### Layer 2: Slow Filter (Solid Intersection)
The real geometry of the three-dimensional meshes of the elements that passed Filter 1 is evaluated.

---

## 3. Pure Clash Detection Implementation

To cross two elements or an element against an entire model, the API provides the `ElementIntersectsElementFilter` (Slow Filter) supported internally by box optimizations.

### Optimized Pattern (Simple Interference Detection)

[See pattern implementation in: assets/ClashDetectionCollector.cs]


---

## 4. Lightning Release (`ReferenceIntersector`)

Sometimes we don't look for a collision, but instead need to measure the clearance to the next obstacle (for example, to calculate the length of a cable tray pendant to the ceiling above, or to avoid a beam before the conduit reaches it).

For this, `ReferenceIntersector` is used, which shoots an infinite or limited vector ray from a point `XYZ` in a specific direction.

**Required:** `ReferenceIntersector` requires **mandatory** a 3D View (`View3D`) to work, as it uses the view rendering engine to calculate exposed faces.

### Optimized Pattern (Ground/Floor Clearance Measurement)


[See pattern implementation in: assets/FloorProximityRaycaster.cs]


---

## 5. Antipattern Matrix vs Resilient Code

*Common Antipattern (Massive Extraction for Raycasting)*


[See pattern implementation in: assets/UnfilteredRaycastingAntiPattern.cs]


*Linked Models Antipattern*
The base `ReferenceIntersector` does not detect elements within linked files (e.g. Architecture model walls in a MEP file). If the agent needs to evaluate links, it must use advanced overloads or instantiate the intersector with the auxiliary property turned on to search the `RevitLinkInstances`.

---

## 6. Agent Injection Instructions (Prompting Prompt)

*When you are required to solve problems of collisions, spatial distances or search for structural supports, rigorously apply these rules of computational architecture:*

1. **Pre-Filtering Rule (Funneling):** NEVER start an `ElementIntersectsElementFilter` or `ElementIntersectsSolidFilter` without first having applied a quick logical filter to the collection, such as `.OfCategory()`, `.OfClass()`, or `BoundingBoxIntersectsFilter`.
2. **3D View Validation:** The `ReferenceIntersector` throws an exception if it is passed a plan view or a document without a valid 3D view. The agent must extract or dynamically generate a valid `View3D`, ensuring that the view does not have the `SectionBox` enabled or that its visibility filters are not hiding the target category.
3. **Management of `Proximity`:** The value returned by `ReferenceWithContext.Proximity` is a `double` structured in imperial units (Feet). The agent MUST process this value with `UnitUtils` to transform it to millimeters or meters before injecting it into parametric family parameters or exporting it to Excel.
4. **Discarding Own Element:** When casting rays or evaluating mass collisions, the beam-emitting element often auto-detects whether the point of origin (`XYZ`) is exactly on its own face. The agent must inject logic to verify that `result.GetReference().ElementId` is not equal to the ID of the element that triggers the query.