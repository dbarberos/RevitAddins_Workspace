# Skill: Transition to LOD 400, Manufacturing Parts and Supports (Fabrication API)

## 1. Technical Data Sheet and Metadata for the Agent
* **Skill ID:** SKILL-RVT-024
* **Technical Area:** LOD 400 / CAM Export / MEP Detailing / Spooling
* **API dependencies:** `Autodesk.Revit.DB.Fabrication`
* **Key Concepts:** Design Intent vs Fabrication, ITM Parts, Fabrication Configuration, Hangers.
* **Operational Impact:** Critical for contractors and installers. It allows you to automate the conversion of engineering models to construction models, automatic disassembly and generation of workshop drawings (Spools).

---

## 2. Dual Ontology: Design Intent vs Fabrication Part

In Revit there are two MEP universes that cannot be freely mixed:
1. **Design Intent (LOD 300):** Pipes (`Pipe`) and Ducts (`Duct`). They stretch infinitely, the elbows generate themselves and represent an engineering concept.
2. **Fabrication Part (LOD 400):** All belong to the `FabricationPart` class. They have fixed commercial length, specific mechanical joints (Victaulic, Flanges, Welds) and are derived from an external Autodesk CAMduct/ESTmep database (MAJ/ITM files).

**Architectural Rule:** You cannot use `doc.Create.NewElbowFitting` on fabrication parts, nor can you connect a regular `Pipe` directly to a `FabricationPart` without a transition element.

---

## 3. Automated Conversion (Design to Fabrication)

The most common corporate workflow is not to draw manufacturing parts from scratch, but to model in LOD 300 and run an algorithm that translates that network to LOD 400 based on an active manufacturing service.

This is done using the `DesignToFabricationConverter` class.


[See pattern implementation in: assets/DesignToFabricationConverter.cs]


---

## 4. Antipattern Matrix vs Resilient Code

### Common Antipattern (Length Manipulation)


[See pattern implementation in: assets/FabricationPartModificationAntiPattern.cs]


### Optimized Pattern (Section Optimization)

To adjust lengths of manufacturing parts, native stretch and justification methods must be used that respect the limits of the ITM catalog.
If a pipe is longer than the commercial length, native optimization must be used to segment it.


[See pattern implementation in: assets/FabricationLengthOptimizer.cs]


---

## 5. Automatic Support (Hangers)

The workshop model requires modeling the supports. The `FabricationPart` class has a highly specialized static method for "hanging" supports anchored to the conduit/pipe and projected against the upper structural element (internal Ray Launch).


[See pattern implementation in: assets/FabricationHangerManager.cs]


---

## 6. Agent Injection Instructions (Prompting Prompt)

*When processing requirements for MEP contractors or LOD 300 to LOD 400 transition scripts, strictly apply these guidelines:*

1. **Class Isolation:** NEVER combine logic from the `Pipe` class with the `FabricationPart` class. The Manufacturing API methods are exclusive. If the user asks to audit "Pipes", the agent must explicitly ask if they are referring to *Design Intent* (LOD 300) or *Fabrication Parts* (LOD 400), since the extraction code is completely different.
2. **Manufacturing Database Validation:** Before running any command from the `Autodesk.Revit.DB.Fabrication` namespace, inject an initial condition that evaluates whether `FabricationConfiguration.GetFabricationConfiguration(doc) != null`. Trying to use these APIs in an architectural project without MEP configuration loaded will throw a fatal exception.
3. **Direct Parametric Editing Prohibition:** Do not use `Parameter.Set()` to alter the width, height or diameter of a `FabricationPart`. These dimensions are locked by the ITM catalog. To resize a manufacturing network, always use the manufacturing service's native routing and recalculation methods.
4. **Exclusive Use of MAJ/ITM Codes:** When a specific manufacturing part is required to be instantiated (e.g. a real valve), its commercial name is not searched. You must navigate through the `FabricationConfiguration` folders and obtain the internal ID of the service button (Button/Item) to pass it to `FabricationPart.Create()`.