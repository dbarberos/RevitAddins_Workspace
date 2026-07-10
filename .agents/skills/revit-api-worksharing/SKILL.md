---
name: revit-api-worksharing
description: Worksharing & Coordinates: Worksets, Element Borrowing, Checkout/Relinquish, Shared Coordinates, and Base/Survey Point translations.
---

# Skill Manifest: Revit API Worksharing & Coordinates (`revit-api-worksharing`)

## 1. Skill Identity & Purpose
* **ID:** SKILL-RVT-WS
* **Domain:** Central Models, Worksets, Element Borrowing, and Shared Coordinates.
* **Objective:** Orchestrate safe modifications in multi-user collaborative environments. Manage element checkout statuses, reassign elements across worksets, and programmatically manipulate Project Base Points and Survey Points.

## 2. Core Execution Guardrails
1. **Workshared Context Verification**: Always check `doc.IsWorkshared` before invoking any `WorksharingUtils` methods.
2. **Checkout Before Modification**: In a Central Model, check `GetCheckoutStatus()` before modification. Discard elements owned by others (`OwnedByOther`).
3. **Coordinate Unpinning**: Project Base Point and Survey Point elements are pinned by default. Unpin them (`Pinned = false`) before translations, and repin them immediately after.
4. **Workset Parameter Typo**: Muta worksets using the integer ID representation in `BuiltInParameter.ELEM_PARTITION_PARAM`. Never use string names.

## 3. Reference Mapping
* **Worksharing & Borrowing**: [37_Worksets_and_CheckoutStatus.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-worksharing/references/37_Worksets_and_CheckoutStatus.md)
* **Central Model Syncing**: [38_Synchronize_and_Relinquish.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-worksharing/references/38_Synchronize_and_Relinquish.md)
* **Georeferencing & Base Points**: [39_SharedCoordinates_and_BasePoints.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-worksharing/references/39_SharedCoordinates_and_BasePoints.md)

## 4. Asset Mapping
* [WorksetManager.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-worksharing/assets/WorksetManager.cs) -> Querying active worksets and reassigning elements safely.
* [ElementCheckoutHandler.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-worksharing/assets/ElementCheckoutHandler.cs) -> Ownership checks, checkout elements, and relinquishing.
* [CoordinateSystemManager.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-worksharing/assets/CoordinateSystemManager.cs) -> Unpinning, translating, and repinning Survey and Project Base Points.
