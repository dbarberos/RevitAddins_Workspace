---
name: revit-api-data
description: Parameters, Units, Extensible Storage, Materials, and Schedules API.
---

# Skill Manifest: Revit API Data & Information (`revit-api-data`)

## 1. Skill Identity & Purpose
* **ID:** SKILL-RVT-DATA
* **Domain:** Parameter Management, Extensible Storage, Material PBR Assets, and Schedule (BOQ) Extraction.
* **Objective:** Orchestrate the safe reading, writing, and extraction of metadata within the Revit database. Handle internal unit conversions, hidden schema injections, and batch data harvesting for external ERP/PowerBI integrations.

---

## 2. Core Execution Guardrails
When executing tasks within this domain, the agent MUST strictly enforce these programmatic constraints:
1. **Internal Units Rule:** Revit stores all measurements in Imperial units (Feet, Decimal Degrees) internally. Never use `.Set(10.5)` expecting meters. Always use `UnitUtils.ConvertToInternalUnits()` before writing, and `ConvertFromInternalUnits()` after reading.
2. **BuiltInParameter Priority:** Never retrieve parameters by string name (e.g., `LookupParameter("Length")`) unless it is a custom Shared Parameter. Always use `get_Parameter(BuiltInParameter.XXX)` to guarantee cross-language compatibility (English/Spanish/German).
3. **Appearance Asset Protection:** Modifying a Material's visual texture requires opening an `AppearanceAssetEditScope`. Never attempt to mutate an `AssetProperty` outside of this tunnel, and always duplicate shared assets if you only want to affect one material.
4. **Schedule Data Integrity:** When extracting Bill of Quantities (BOQ), do not iterate physical elements. Traverse the `ViewSchedule` using `GetCellText()` to ensure you capture the exact rounding, formulas, and grouping configured by the BIM Manager.

---

## 3. Reference Mapping (Theory & Ontologies)
When specific data architecture concepts are needed, locate the following files in the references folder:

* **Metadata & Conversions:** [05_Parameters_and_Units.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-data/references/05_Parameters_and_Units.md)
  * *Use cases:* Safe extraction of strings/doubles, UnitTypeId conversions, and Type vs. Instance parameter logic.
* **Hidden Database Injection:** 
  * [12_ExtensibleStorage.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-data/references/12_ExtensibleStorage.md): Creating DataStorage elements, Schemas, and injecting invisible dictionaries.
  * [guia_extensible_storage_json.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-data/references/guia_extensible_storage_json.md): Optimal pattern for serializing complex objects to JSON inside `ProjectInformation` across sessions.
* **PBR & LCA Data:** [26_MaterialAPI_and_Assets.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-data/references/26_MaterialAPI_and_Assets.md)
  * *Use cases:* Creating materials, modifying albedo/color in the Protein render engine, and Data Painting faces.
* **BOQ & Reporting:** [28_Schedules_and_TableData.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-data/references/28_Schedules_and_TableData.md)
  * *Use cases:* Reading grid cells (`TableData`), creating audit schedules programmatically, and understanding `IsItemized`.

---

## 4. Asset Mapping (Code Blueprints)
Do not reinvent data pipelines. Inject, adapt, or copy the exact implementations located in the assets folder:

* [ParameterHandler.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-data/assets/ParameterHandler.cs): Bulletproof utility for reading and writing parameters safely with native unit conversions.
* [ExtensibleStorageManager.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-data/assets/ExtensibleStorageManager.cs): CRUD operations for invisible schemas (JSON stringification) attached to the Project Information.
* [MaterialAssetModifier.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-data/assets/MaterialAssetModifier.cs): Engine to safely duplicate and mutate PBR colors/textures using the Protein EditScope.
* [ScheduleExporter.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-data/assets/ScheduleExporter.cs): Data harvesting algorithm that reads ViewSchedule grids and outputs clean 2D string arrays (ready for CSV/JSON).

---

## 5. Agent Processing Instructions (RAG & Chain-of-Thought)
1. **Analyze Prompt:** Identify if the user needs to write data (e.g., "number these doors"), hide data ("save this config inside the RVT"), or extract data ("export the wall schedule").
2. **Consult Reference:** Review the matching domain in the references folder to ensure units or edit scopes are correctly applied.
3. **Consume Asset:** Open the target `.cs` asset from the assets folder. Use its methods to bypass common pitfalls like read-only parameters or null values.
4. **Output Format:** Provide the optimized solution, utilizing `TransactionScopeManager` (from `revit-transactions`) if any database modification is required.
