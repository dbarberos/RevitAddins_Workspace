---
name: revit-api-geometry
description: Vectors, Solids, Clash Detection, Raytracing, DirectShapes, and Point Clouds.
---

# Skill Manifest: Revit API Geometry & Spatial Analysis (`revit-api-geometry`)

## 1. Skill Identity & Purpose
* **ID:** SKILL-RVT-GEO
* **Domain:** Vector Mathematics, BRep (Boundary Representation), Raycasting, DirectShape, and Point Cloud Processing.
* **Objective:** Orchestrate the safe manipulation and extraction of raw 3D geometry. Handle spatial queries, vector normalization, interference detection, and the injection of non-native tessellated shapes into the Revit database.

---

## 2. Core Execution Guardrails
When executing tasks within this domain, the agent MUST strictly enforce these programmatic constraints:
1. **XYZ Normalization:** Before performing Cross Products or calculating angles between vectors (`XYZ`), the agent MUST ensure both vectors are normalized (`.Normalize()`). Failure to do so will result in invalid geometric transformations.
2. **Raycasting Context:** The `ReferenceIntersector` class requires a 3D View (`View3D`) to function. The agent MUST verify that the provided view is a 3D view and that its `IsTemplate` property is false before casting rays.
3. **DirectShape Restrictions:** `DirectShape` elements are "dead" geometry. The agent MUST NOT use `DirectShape` to generate native parametric elements (like Walls or Doors). It is strictly reserved for LOD 100 massing, clash spheres, or importing external BRep geometry (e.g., Rhino/IFC).
4. **Point Cloud Chunking (Big Data):** Never extract points from a `PointCloudInstance` using an unbounded spatial filter or `int.MaxValue`. The agent MUST use `PointCloudFilter` with strict maximum return limits (e.g., 50,000 points per batch) to prevent memory overflow crashes.

---

## 3. Reference Mapping (Theory & Ontologies)
When specific spatial analysis concepts are needed, locate the following files in the references folder:

* **Vector Math & Solids:** [06_Vectors_and_Solids.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-geometry/references/06_Vectors_and_Solids.md)
  * *Use cases:* Dot/Cross products, Transforms, Solid extraction from `GeometryElement`, and Face/Edge iteration.
* **Spatial Queries & Clashes:** [23_ClashDetection_and_Raytracing.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-geometry/references/23_ClashDetection_and_Raytracing.md)
  * *Use cases:* Finding intersections between elements, shooting rays to find ceilings/floors, and using `BoundingBoxIntersectsFilter`.
* **External Geometry Injection:** [27_DirectShape_and_Tessellation.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-geometry/references/27_DirectShape_and_Tessellation.md)
  * *Use cases:* Creating visual debug spheres, `BRepBuilder`, and handling `TessellatedShapeBuilder`.
* **Reverse Engineering (Scan-to-BIM):** [30_PointClouds_and_ScanToBIM.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-geometry/references/30_PointClouds_and_ScanToBIM.md)
  * *Use cases:* Voxelization, spatial boundaries, and reading `.rcp` files safely.

---

## 4. Asset Mapping (Code Blueprints)
Do not reinvent vector mathematics. Inject, adapt, or copy the exact implementations located in the assets folder:

* [VectorMathExtensions.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-geometry/assets/VectorMathExtensions.cs): Core extension methods for XYZ manipulation, safe normalization, and coordinate translations.
* [RaytraceAuditor.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-geometry/assets/RaytraceAuditor.cs): Wrapper for `ReferenceIntersector` to shoot rays (e.g., find the nearest floor below an element) and perform hard clash detection.
* [DirectShapeBuilder.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-geometry/assets/DirectShapeBuilder.cs): Utilities to quickly inject colored spheres, lines, or imported solids into the model for visual debugging or placeholder generation.
* [PointCloudProcessor.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-geometry/assets/PointCloudProcessor.cs): Safe extraction engine for point clouds, implementing spatial chunking and filtering to avoid RAM saturation.
* [ClashDetectionCollector.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-geometry/assets/ClashDetectionCollector.cs) to [UnfilteredRaycastingAntiPattern.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-geometry/assets/UnfilteredRaycastingAntiPattern.cs): Solid geometry intersection and Raycasting implementation templates.

---

## 5. Agent Processing Instructions (RAG & Chain-of-Thought)
1. **Analyze Prompt:** Identify if the user needs mathematical calculation (distances, angles), spatial analysis (clashes, raycasting), or geometry creation (DirectShape/solids).
2. **Consult Reference:** Review the matching domain in the references folder to ensure units (always internal Feet for XYZ) and mathematical principles are correct.
3. **Consume Asset:** Open the target `.cs` asset from the assets folder. Rely on its predefined methods to bypass common Revit API exceptions (like zero-length vectors or invalid bounding boxes).
4. **Output Format:** Provide the optimized solution. If the output generates physical geometry (DirectShape), wrap it in a Transaction using `TransactionScopeManager` (from `revit-transactions`).
