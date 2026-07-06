---
name: revit-api-mep
description: MEP Systems topology, Connectors, Routing Fittings, Electrical Circuits, and Fabrication.
---

# Skill Manifest: Revit API MEP Engineering (`revit-api-mep`)

## 1. Skill Identity & Purpose
* **ID:** SKILL-RVT-MEP
* **Domain:** Mechanical, Electrical, Plumbing (MEP) Topology, Routing, and LOD 400 Fabrication.
* **Objective:** Orchestrate the creation, traversal, and coordination of logical systems (fluids/power) and their physical counterparts (pipes, ducts, conduits, and fabrication parts) using native engineering paradigms.

---

## 2. Core Execution Guardrails
When executing tasks within this domain, the agent MUST strictly enforce these programmatic constraints:
1. **The Physical-Logical Duality:** Never attempt to read thermodynamic properties (Temperature, Viscosity, Load) from physical elements like `Pipe` or `Duct`. The agent MUST traverse to the `MEPSystem` and extract data from the `MEPSystemType` or the aggregated system parameters.
2. **Routing Exclusivity:** NEVER use `doc.Create.NewFamilyInstance` to place Elbows, Tees, or Transitions. The agent MUST delegate this to the internal routing engine via `doc.Create.NewElbowFitting(Connector, Connector)` to respect the BIM Manager's Routing Preferences.
3. **Regeneration Sync:** When generating a linear segment (`Pipe.Create`) and immediately connecting it to a fitting or equipment, the agent MUST invoke `doc.Regenerate()` between both actions to materialize the mathematical `Connector` nodes in space.
4. **Electrical Paradigm:** Electrical calculations and load balancing MUST be performed by iterating through `ElectricalSystem` elements. Never rely on physical `Wire` geometry for power or connectivity logic.
5. **Fabrication Isolation:** `Pipe` (LOD 300) and `FabricationPart` (LOD 400) APIs are completely mutually exclusive. Never attempt to stretch a Fabrication Part using LocationCurves or connect them using standard Pipe APIs.

---

## 3. Reference Mapping (Theory & Ontologies)
When specific MEP engineering concepts are needed, locate the following files in the references folder:

* **Logical Thermodynamics:** [19_MEPSystems_Topology.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-mep/references/19_MEPSystems_Topology.md)
  * *Use cases:* Extracting fluid temperatures, calculating total airflow, differentiating `PipingSystemType` from physical containment.
* **Graph Topology & Nodal Networks:** [20_Connectors_and_Routing.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-mep/references/20_Connectors_and_Routing.md)
  * *Use cases:* Extracting `ConnectorManager` dynamically based on element class, checking `IsConnected`, and mapping `AllRefs`.
* **Generative Physical Routing:** [21_LinearRouting_and_Fittings.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-mep/references/21_LinearRouting_and_Fittings.md)
  * *Use cases:* Creating pipes/ducts dynamically, enforcing system IDs, and triggering automated Tees/Elbows.
* **Power Distribution:** [22_ElectricalSystems_and_Panels.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-mep/references/22_ElectricalSystems_and_Panels.md)
  * *Use cases:* Grouping fixtures into power circuits, assigning loads to electrical panels (`SelectPanel`), and reading apparent power (VA).
* **LOD 400 CAM Detailing:** [24_FabricationParts_and_Hangers.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-mep/references/24_FabricationParts_and_Hangers.md)
  * *Use cases:* Using `DesignToFabricationConverter`, snapping hangers to structural slabs, and interacting with MAJ/ITM databases.

---

## 4. Asset Mapping (Code Blueprints)
Do not reinvent MEP algorithms. Inject, adapt, or copy the exact implementations located in the assets folder:

* [MepSystemTraversal.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-mep/assets/MepSystemTraversal.cs): Robust extraction of logical fluid/power systems from physical instances without failing on multi-domain equipment.
* [ConnectorGraphAuditor.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-mep/assets/ConnectorGraphAuditor.cs): Utility to find free connectors, map connected elements, and evaluate domains (Piping/HVAC/Electrical) safely.
* [AutoRoutingBuilder.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-mep/assets/AutoRoutingBuilder.cs): Generative algorithm for drawing Pipes/Ducts between XYZ points and injecting auto-calculated native fittings.
* [ElectricalCircuitManager.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-mep/assets/ElectricalCircuitManager.cs): Safe creation of `ElectricalSystem` groups and panel assignment with voltage compatibility checks.
* [FabricationConverter.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-mep/assets/FabricationConverter.cs): Batch conversion of LOD 300 Design Intent to LOD 400 Fabrication Parts and automated hanger placement.
* [Skill21_Pattern_1.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-mep/assets/Skill21_Pattern_1.cs) to [Skill21_Pattern_4.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-mep/assets/Skill21_Pattern_4.cs): Programmatic fitting generators, elbows, tees, and cross connectors.
* [Skill24_Pattern_1.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-mep/assets/Skill24_Pattern_1.cs) to [Skill24_Pattern_4.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-mep/assets/Skill24_Pattern_4.cs): LOD 400 fabrication part conversions and hanger placing templates.

---

## 5. Agent Processing Instructions (RAG & Chain-of-Thought)
1. **Analyze Prompt:** Identify if the user needs logical extraction (e.g., "Find total chilled water flow") or physical generation (e.g., "Draw a pipe with elbows").
2. **Consult Reference:** Review the matching domain in the references folder to ensure no thermodynamic or routing rules are violated.
3. **Consume Asset:** Open the target `.cs` asset from the assets folder. Use its connector-finding logic, unit conversions, and routing methods.
4. **Output Format:** Provide the optimized solution, ensuring that any geometry creation is wrapped securely in a Transaction scope (imported from `revit-transactions`).
