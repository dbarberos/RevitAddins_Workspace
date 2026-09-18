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
* **Native View Image Export & UI Previews**: [revit_native_view_image_export_and_preview_guide.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/references/revit_native_view_image_export_and_preview_guide.md)
* **Isolated 2D Element Previews (Scratch View & Rollback)**: [isolated_2d_element_preview_rendering_guide.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/references/isolated_2d_element_preview_rendering_guide.md)
* **Debugging Log (ZoomFitType Enum)**: [debugging_image_export_options_zoom_fit_type_2026-08-20.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/references/debugging_image_export_options_zoom_fit_type_2026-08-20.md)
* **Debugging Log (2D Detail Items Thumbnails)**: [debugging_detail_items_empty_thumbnails_2026-08-20.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/references/debugging_detail_items_empty_thumbnails_2026-08-20.md)
* **Debugging Log (TitleBlocks & Family View Previews)**: [debugging_titleblock_and_family_preview_rendering_2026-08-20.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/references/debugging_titleblock_and_family_preview_rendering_2026-08-20.md)
* **Debugging Log (Small Elements & Tags Zoom Extents)**: [debugging_small_elements_and_tags_thumbnail_zoom_extents_2026-08-21.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/references/debugging_small_elements_and_tags_thumbnail_zoom_extents_2026-08-21.md)
* **Debugging Log (CAD Link/Import Options & Multi-Format Signatures)**: [debugging_cad_import_vs_link_and_multiformat_geometry_2026-08-21.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/references/debugging_cad_import_vs_link_and_multiformat_geometry_2026-08-21.md)
* **Debugging Log (Cloud CAD Previews & File Extension Sanitization)**: [debugging_cloud_cad_previews_and_file_extension_sanitization_2026-08-21.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/references/debugging_cloud_cad_previews_and_file_extension_sanitization_2026-08-21.md)

## 4. Asset Mapping
* [PdfExportManager.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/assets/PdfExportManager.cs) -> Native PDF generation wrapper (Revit 2022+).
* [CadExportManager.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/assets/CadExportManager.cs) -> Batch DWG/DXF exporter handling explicit `ExportDWGSettings` layer standards.
* [CadDraftingViewTransferHelper.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/assets/CadDraftingViewTransferHelper.cs) -> Reusable helper for programmatic creation of Drafting Views and importing or linking multi-format CAD/3D geometries (.dwg, .dxf, .sat, .dgn, .skp).
* [CadCloudCacheAndPreviewManager.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/assets/CadCloudCacheAndPreviewManager.cs) -> Standalone utility for secure caching and in-memory temporary drafting view rendering of external/cloud CAD files.
* [IfcExportManager.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/assets/IfcExportManager.cs) -> OpenBIM export utility optimized for web parsers.
* [RevitViewPreviewExporter.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/assets/RevitViewPreviewExporter.cs) -> Standalone utility to render and export lightweight view thumbnail PNGs and isolated 2D element vector previews.
* [FamilyPreviewRenderer.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-api-export/assets/FamilyPreviewRenderer.cs) -> Dynamic 2D/3D preview generator for in-memory and disk families via EditFamily and ViewSheet hosting.
