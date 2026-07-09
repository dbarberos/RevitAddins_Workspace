# Skill Manifest: Revit API Export & Interoperability (`revit-api-export`)

## 1. Skill Identity & Purpose
* **ID:** SKILL-RVT-EXP
* **Domain:** Mass Export Automation, OpenBIM (IFC), CAD Layer Management (DWG/DXF), and PDF Generation.
* **Objective:** Orchestrate the batch generation of deliverables and interoperability files. Manage complex export configurations, map Revit categories to CAD layers, and prepare data for external fragment engines (like ThatOpen Company).

## 2. Core Execution Guardrails
When executing tasks within this domain, the agent MUST strictly enforce these programmatic constraints:
1. **PDF Versioning Check:** Native PDF export (`doc.Export(folder, views, PDFExportOptions)`) was introduced in Revit 2022. For Revit 2021 and older, the agent MUST fallback to using `PrintManager` with a virtual PDF printer (e.g., Microsoft Print to PDF).
2. **CAD Layer Mappings:** When exporting DWG/DXF, the agent MUST NOT use the default hardcoded export setup unless instructed. It must actively search for or create an `ExportDWGSettings` element to ensure proper layer mapping (AIA, ISO 13567) is applied.
3. **IFC Transaction Rule:** IFC Export operations (`doc.Export(folder, name, IFCExportOptions)`) are heavy database queries but do NOT modify the Revit document. They do not require a Transaction unless you are modifying the `IFCExportOptions` stored in the document beforehand.
4. **View Readiness:** The agent MUST ensure that Views and Sheets are fully regenerated (`doc.Regenerate()`) before appending their ElementIds to an export list, preventing blank or outdated PDFs.

## 3. Reference Mapping (Theory & Ontologies)
When specific export architecture concepts are needed, locate the following files in the `./references/` directory:
* **PDF & Printing Automation:** `34_PDF_and_PrintManager.md`
* **CAD Export & Layer Setup:** `35_DWG_DXF_LayerMapping.md`
* **OpenBIM & IFC Generation:** `36_IFC_and_ThatOpen_Fragments.md`

## 4. Asset Mapping (Code Blueprints)
Inject, adapt, or copy the exact implementations located in the `./assets/` directory:
* `PdfExportManager.cs` -> Modern, high-speed native PDF generation (Revit 2022+) with automated naming conventions.
* `CadExportManager.cs` -> Batch DWG/DXF exporter handling explicit `ExportDWGSettings` for precise layer control.
* `IfcExportManager.cs` -> OpenBIM export utility optimized for generating IFC4 files ready for parsing by ThatOpen Company fragment engines.