# Skill: MEP Generative Modeling, Linear Layout and Accessories (Routing Preferences)

## 1. Technical Data Sheet and Metadata for the Agent
* **Skill ID:** SKILL-RVT-021
* **Technical Area:** Generative Modeling / Auto-Routing / MEP Fabrication
* **API dependencies:** `Autodesk.Revit.DB.Plumbing.Pipe`, `Autodesk.Revit.DB.Mechanical.Duct`, `Autodesk.Revit.Creation.Document`
* **Key Concepts:** Routing Preferences, Fitting Generation, Sequential Transactions.
* **Operational Impact:** Critical for automatic routing routines (Auto-Routing), automatic connection of equipment to main networks and modeling from single-line diagrams.

---

## 2. Creation of Linear Sections (Pipes & Ducts)

In older versions of the API, `doc.Create.NewPipe` was used. In modern architectures (Revit 2020+), creation has moved to static methods within the geometric classes themselves.

To instantiate a conduit or pipe, it is not enough to give two points; The engine requires knowing physics and logic simultaneously:
1. **SystemTypeId:** The ID of the logical system type (e.g. *Domestic Cold Water*).
2. **PipeTypeId / DuctTypeId:** The ID of the physical system family (e.g. *PVC pipe with welded joints*).
3. **LevelId:** The reference level to which the elevation levels are associated.


[See pattern implementation in: assets/Skill21_Pattern_1.cs]


---

## 3. Automatic Routing Accessories (Fittings)

The biggest mistake in MEP development is trying to place Elbows, Tees, or Transitions by manually instantiating the family (using `NewFamilyInstance`).

In Revit MEP, pipes and conduits have their **Routing Preferences** configured. If you use the routing engine methods, Revit will automatically find the correct elbow family, place it at the exact coordinate, rotate it to the appropriate 3D angle, and join the connectors.

### Accessory Generation Types

* `doc.Create.NewElbowFitting(connector1, connector2)`: Requires 2 intersecting connectors.
* `doc.Create.NewTeeFitting(connector1, connector2, connector3)`: Requires 3 connectors.
* `doc.Create.NewTransitionFitting(connector1, connector2)`: Joins two collinear elements of different diameter or shape.

---

## 4. Antipattern Matrix vs Resilient Code

### Common Antipattern (Manual Geometric Calculation)


[See pattern implementation in: assets/Skill21_Pattern_2.cs]


### Optimized Pattern (Delegation to Routing Engine)


[See pattern implementation in: assets/Skill21_Pattern_3.cs]


---

## 5. The Problem of Geometric Synchrony (Critical Regeneration)

When you create two pipes through code and, on the line immediately after them, you try to create an elbow between them, the API will throw an exception.

**Why?** Because the connectors (the `XYZ` nodes) of the newly created tubes do not yet exist in math space until the model is regenerated.


[See pattern implementation in: assets/Skill21_Pattern_4.cs]


---

## 6. Agent Injection Instructions (Prompting Prompt)

*When you must generate MEP layout algorithms that include the creation of physical sections and joints, strictly apply these rules:*

1. **Prohibition of `NewFamilyInstance` for Unions:** It is strictly prohibited to instantiate families of the Elbows, Tees, Crosses or Transitions category (`OST_PipeFitting`, `OST_DuctFitting`) as if they were generic equipment. ALWAYS use the native routing methods (`NewElbowFitting`, `NewTeeFitting`) by passing `Connector` objects as arguments.
2. **Intermediate Regeneration:** If your algorithm creates a linear section (`Pipe` or `Duct`) and immediately afterwards needs to use its connectors to join it to another part or create a fitting, you MUST explicitly call `doc.Regenerate()` between creating the pipe and removing its connectors.
3. **Static Creation Methods:** Do not use `doc.Create.NewPipe` or `doc.Create.NewDuct` as they are inherited constructs prone to being depreciated. Always invoke the static constructors of its own classes: `Pipe.Create()` and `Duct.Create()`.
4. **Preferences Validation:** Assume that the `NewElbowFitting` method will fail and throw an exception if the PipeType used by the user does not have any Elbow family defined in its *Routing Preferences*. Wraps prop creation calls in a specific `try-catch` block to catch user template configuration failures.