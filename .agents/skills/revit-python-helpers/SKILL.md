---
name: revit-python-helpers
description: Catalog of reusable Python helper modules and common utilities for Revit Python scripting (pyRevit, RevitPythonShell, and Dynamo Python nodes). Use when writing custom Python macros, selecting objects, executing transactions, managing coordinates, or parsing link geometries.
---

# Revit Python Helpers — Reusable API Scripts

Provide a consolidated, fully English-translated, and PEP 8-compliant catalog of reusable Revit API Python modules. This acts as the direct Python counterpart to the `revit-addin-helpers` C# skill, allowing the agent to inject high-performance Python utilities into pyRevit pushbuttons, RevitPythonShell scripts, or Dynamo nodes.

## 📚 Technical References (Knowledge Base)
Refer to the following guides in the `references/` folder for in-depth documentation and code integration patterns:

*   [references/helper_guide.md](references/helper_guide.md): The master index of all 17 helper modules, their exported APIs, and concrete quick-start scripts.
*   [references/debugging_download_timeout_2026-05-29.md](references/debugging_download_timeout_2026-05-29.md): Debugging report detailing socket timeout management in automated network request downloaders.

## 📦 Assets (Reusable Modules)
All modular helpers reside inside the `assets/` folder, ready to be referenced or copied:

*   [assets/general.py](assets/general.py): Unwrapping, transactions, unit conversions, and filters.
*   [assets/transformations.py](assets/transformations.py): Translations, rotations, mirroring, flipping, and Transform math.
*   [assets/transactions.py](assets/transactions.py): TransactionGroups, native transactions, and subtransactions.
*   [assets/selection_ui.py](assets/selection_ui.py): Decoupled picking elements, faces, edges, and links.
*   [assets/ui.py](assets/ui.py): WPF dialog wrappers, prompts, file picking, and progress bars.
*   [assets/families.py](assets/families.py): Safe family loading and placement.
*   [assets/cad.py](assets/cad.py): DWG/DXF links layer parsing and curve harvesting.
*   [assets/excel.py](assets/excel.py): Local Excel file COM integrations.
*   [assets/databases.py](assets/databases.py): JSON serialization and element parameters bulk CSV exports.
*   [assets/collaborative.py](assets/collaborative.py): Sync with central, worksharing setup, and worksets.
*   [assets/coordination.py](assets/coordination.py): Levels generation, warning counts, and link documents.
*   [assets/architecture.py](assets/architecture.py): Room boundary extraction and interior floors/ceilings.
*   [assets/mep.py](assets/mep.py): Duct, pipe, conduit connectivity and system queries.
*   [assets/structure.py](assets/structure.py): Framing, foundation, column placing, and reinforcement tools.
*   [assets/geometry.py](assets/geometry.py): Curve loop generators, direct shapes, and grid offsets.
*   [assets/views.py](assets/views.py): Plan, section, 3D view creation, title block sheets, and overrides.
*   [assets/scientific.py](assets/scientific.py): CPython 3 scientific analytics package queries.

