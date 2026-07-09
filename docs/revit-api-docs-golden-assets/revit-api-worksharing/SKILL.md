# Skill Manifest: Revit API Worksharing & Coordinates (`revit-api-worksharing`)

## 1. Skill Identity & Purpose
* **ID:** SKILL-RVT-WS
* **Domain:** Central Models, Worksets, Element Borrowing, and Shared Coordinates.
* **Objective:** Orchestrate safe modifications in multi-user collaborative environments. Manage element checkout statuses, reassign elements across worksets, and programmatically manipulate the Project Base Point and Survey Point without corrupting shared site coordinates.

## 2. Core Execution Guardrails
When executing tasks within this domain, the agent MUST strictly enforce these programmatic constraints:
1. **Workshared Context Verification:** Before invoking any `WorksharingUtils` methods, the agent MUST verify that the document is collaborative by checking `doc.IsWorkshared`. Executing worksharing methods on a local, non-shared document will throw fatal exceptions.
2. **Checkout Before Modification:** In a Central Model, the agent MUST NOT attempt to modify an element without first verifying its `CheckoutStatus`. If the element is owned by another user (`CheckoutStatus.OwnedByOtherUser`), the agent must gracefully skip it or log an error, NEVER attempt to force a transaction.
3. **Coordinate Unpinning:** The Project Base Point and Survey Point are `BasePoint` elements that are pinned by default. The agent MUST unpin them (`Pinned = false`) before attempting to translate their geometry or alter their parameters, and repin them immediately after.
4. **Workset Parameter Typo:** To change an element's workset, the agent MUST write the Workset's integer ID to `BuiltInParameter.ELEM_PARTITION_PARAM`. Never attempt to set it by passing the string name of the workset.

## 3. Reference Mapping (Theory & Ontologies)
When specific collaborative architecture concepts are needed, locate the following files in the `./references/` directory:
* **Worksharing & Borrowing:** `37_Worksets_and_CheckoutStatus.md`
* **Central Model Syncing:** `38_Synchronize_and_Relinquish.md`
* **Georeferencing & Base Points:** `39_SharedCoordinates_and_BasePoints.md`

## 4. Asset Mapping (Code Blueprints)
Inject, adapt, or copy the exact implementations located in the `./assets/` directory:
* `WorksetManager.cs` -> Utilities for querying active worksets and reassigning elements safely.
* `ElementCheckoutHandler.cs` -> Engine to evaluate ownership, programmatically checkout elements, and relinquish them.
* `CoordinateSystemManager.cs` -> Precision methods to locate, unpin, and translate the Project Base Point and Survey Point.