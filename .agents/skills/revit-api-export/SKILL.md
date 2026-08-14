---
name: revit-api-export
description: Mass Export, Batch PDF generation, IFC OpenBIM configurations, and CAD layer settings.
---

# Skill Manifest: Revit API Export & Interoperability (`revit-api-export`)

## 1. Skill Identity & Purpose
* **ID:** SKILL-RVT-EXP
* **Domain:** Mass Export Automation, OpenBIM (IFC), CAD Layer Management (DWG/DXF), and PDF Generation.
* **Objective:** Orchestrate the batch generation of deliverables and interoperability files, handling complex export configurations and preparing data for external fragment engines.

## 2. Core Execution Guardrails
1. **PDF Versioning Check**: Native PDF export (`doc.Export(folder, views, PDFExportOptions)`) is Revit 2022+. For Revit 2021 and older, fallback to `PrintManager` with a virtual printer driver.
2. **CAD Layer Mappings**: Do not use default CAD setups. Retrieve a named `ExportDWGSettings` element from the database to enforce layer mappings (e.g. ISO 13567).
3. **IFC Transaction Rule**: Exporter operations do not modify the database. They do not require a Transaction unless you edit the options in the document.
4. **View Readiness**: Always call `doc.Regenerate()` before appending views/sheets to the export list to prevent empty layouts.

## 3. Reference Mapping
* **PDF & Printing Automation**: [34_PDF_and_PrintManager.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/references/34_PDF_and_PrintManager.md)
* **CAD Export & Layer Setup**: [35_DWG_DXF_LayerMapping.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/references/35_DWG_DXF_LayerMapping.md)
* **OpenBIM & IFC Generation**: [36_IFC_and_ThatOpen_Fragments.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/references/36_IFC_and_ThatOpen_Fragments.md)
* **Family Export Logging & Dual Renaming**: [export_logger_and_family_type_renaming_guide.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/references/export_logger_and_family_type_renaming_guide.md)

## 4. Asset Mapping
* [PdfExportManager.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/assets/PdfExportManager.cs) -> Native PDF generation wrapper (Revit 2022+).
* [CadExportManager.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/assets/CadExportManager.cs) -> Batch DWG/DXF exporter handling explicit `ExportDWGSettings` layer standards.
* [IfcExportManager.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/assets/IfcExportManager.cs) -> OpenBIM export utility optimized for web parsers.
