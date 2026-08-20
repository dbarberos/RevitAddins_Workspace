---
name: revit-api-families
description: Component Instantiation, Family API parametric creation, Views, and Sheets.
---

# Skill Manifest: Revit API Families & Documentation (`revit-api-families`)

## 1. Skill Identity & Purpose
* **ID:** SKILL-RVT-FAM
* **Domain:** Component Instantiation, View & Sheet Generation, Dimensioning, and Family API (Parametric Content Creation).
* **Objective:** Orchestrate the automated generation of 2D deliverables (Sheets, Views, Tags) within project environments, and manage the programmatic creation of parametric `.rfa` content using the Family API.

---

## 2. Core Execution Guardrails
When executing tasks within this domain, the agent MUST strictly enforce these programmatic constraints:
1. **The Context Boundary (RVT vs RFA):** The agent MUST verify `Document.IsFamilyDocument` before invoking any `FamilyManager` methods. Project documents (.rvt) do not have a FamilyManager and will crash if accessed.
2. **Type Activation:** Before placing a `FamilyInstance`, the agent MUST check if the `FamilySymbol` (Type) is active (`symbol.IsActive`). If false, it must call `symbol.Activate()` and regenerate the document before placement.
3. **Dimensioning Geometry:** Dimensions require exact topological `Reference` objects (Faces/Edges), not ElementIds. The agent MUST extract these references using `Options { ComputeReferences = true }` within the context of the target View.
4. **Viewport Overlaps:** When creating Sheets, `Viewport.Create()` will fail if the View is already placed on another Sheet (unless it's a Legend or Schedule). The agent MUST check if a view is already placed before attempting to sheet it.

---

## 3. Reference Mapping (Theory & Ontologies)
When specific creation concepts are needed, locate the following files in the references folder:

* **Instantiation & Placement:** [08_Component_Instantiation.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-families/references/08_Component_Instantiation.md)
  * *Use cases:* Placing point-based components, line-based components, face-based hosting, and Type activation.
* **Views, Sheets & Annotation:** [09_Documentation_and_Views.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-families/references/09_Documentation_and_Views.md)
  * *Use cases:* Creating ViewPlans, generating TitleBlocks, placing Viewports, Tagging, and Dimensioning.
* **Debugging ViewSheet TitleBlock & 2D Elements Copy:** [debugging_viewsheet_titleblock_2d_elements_copy_2026-07-20.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-families/references/debugging_viewsheet_titleblock_2d_elements_copy_2026-07-20.md)
* **Parametric Content Creation:** [25_FamilyAPI_and_Generation.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS\ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-families/references/25_FamilyAPI_and_Generation.md)
  * *Use cases:* Opening family templates, drawing Reference Planes, creating Extrusions, and binding FamilyParameters.
* **Family Download & Export Options:** [family_download_subfolders_3d_preview_saveas_options_2026-08-13.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-families/references/family_download_subfolders_3d_preview_saveas_options_2026-08-13.md)
  * *Use cases:* Organizing exported families into category subfolders, configuring SaveAs 3D Preview views, and audit log generation.
* **Drafting Views & CAD Details Transfer:** [drafting_views_and_cad_instances_transfer_guide.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-families/references/drafting_views_and_cad_instances_transfer_guide.md)
  * *Use cases:* Inter-document copying of 2D drafting views and generating drafting view containers for CAD instances.
* **Detail Views, Detail Groups & Detail Items Collection:** [detail_views_groups_and_items_collection_guide.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-families/references/detail_views_groups_and_items_collection_guide.md)
  * *Use cases:* Querying and segregating 2D documentation elements into discrete categories for UI selection and transfer.
* **Debugging Category Filters (Radio Fallback):** [debugging_cad_details_origin_category_filters_2026-08-20.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-families/references/debugging_cad_details_origin_category_filters_2026-08-20.md)

---

## 4. Asset Mapping (Code Blueprints)
Do not reinvent placement algorithms. Inject, adapt, or copy the exact implementations located in the assets folder:

* [FamilyInstantiator.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-families/assets/FamilyInstantiator.cs): Safe loading of .rfa files, symbol activation, and batch placement of instances on levels or faces.
* [FamilyExportPreviewHelper.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-families/assets/FamilyExportPreviewHelper.cs): Path sanitization and SaveAs 3D Preview view configuration helper.
* [DraftingViewProvider.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-families/assets/DraftingViewProvider.cs): Collector utility for Drafting Views in Revit documents.
* [DetailViewProvider.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-families/assets/DetailViewProvider.cs): Collector utility for Detail Views and Callouts.
* [DetailGroupProvider.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-families/assets/DetailGroupProvider.cs): Collector utility for 2D Detail Groups (Instances and Types).
* [DetailItemProvider.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-families/assets/DetailItemProvider.cs): Collector utility for 2D Detail Components (Detail Items).
* [ViewSheetManager.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-families/assets/ViewSheetManager.cs): Automated creation of Sheets, dynamic titleblock retrieval, and automated viewport alignment.
* [AnnotationBuilder.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-families/assets/AnnotationBuilder.cs): Utilities to extract geometric references and place linear dimensions and independent tags securely.
* [FamilyDocumentBuilder.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-families/assets/FamilyDocumentBuilder.cs): Boilerplate for the Family API: drawing reference planes, generating solids, and creating parametric constraints.
* [FamilyDocumentContextValidator.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-families/assets/FamilyDocumentContextValidator.cs) to [StaticExtrusionAntiPattern.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-families/assets/StaticExtrusionAntiPattern.cs): Parameter creations and constraint binding inside the Family Document context.

---

## 5. Agent Processing Instructions (RAG & Chain-of-Thought)
1. **Analyze Prompt:** Identify if the operation happens in a Project (instancing, sheets, tags) or inside a Family Editor (extrusions, reference planes).
2. **Consult Reference:** Review the matching domain in the references folder to ensure topological references or hosting rules are followed.
3. **Consume Asset:** Open the target `.cs` asset from the assets folder. Rely on its safety checks (like `symbol.IsActive`) to prevent runtime exceptions.
4. **Output Format:** Provide the optimized solution. Ensure all creation methods (`NewFamilyInstance`, `Viewport.Create`) are wrapped in a Transaction from `revit-transactions` (or using `TransactionScopeManager` from `revit-transactions`).
