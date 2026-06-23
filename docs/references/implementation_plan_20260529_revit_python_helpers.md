# Implementation Plan: Revit Python Helpers Skill Integration

We propose the creation of a new, highly cohesive and modular skill under the name **`revit-python-helpers`**. This skill will serve as the Python counterpart to the existing `revit-addin-helpers` C# skill, providing a unified, fully English-translated, and optimized catalog of reusable Revit API utility functions for **pyRevit**, **RevitPythonShell (RPS)**, and **Dynamo Python nodes**.

---

## User Review Required

Please review the following key decisions and design choices:

> [!IMPORTANT]
> **Unified Skill Strategy (Recommended):** Instead of creating 17 separate skill folders under `.agents/skills/` (which would clutter the workspace and degrade context window efficiency), we propose creating a single premium skill folder called `revit-python-helpers`.
> Inside it, we will keep the exact structure of the library by placing the translated modules as individual files in `assets/` and providing a comprehensive guide in `references/`.

> [!NOTE]
> **English Translation:** All functions, comments, docstrings, and documentation will be translated from Spanish to high-quality English to conform with standard repository conventions.

Please let us know if you agree with this unified approach or have any adjustments!

---

## Proposed Changes

We will create a new skill directory `.agents/skills/revit-python-helpers/` containing the following structure:

### 1. Skill Index & Directory Layout

#### [NEW] [SKILL.md](../../.agents/skills/revit-python-helpers/SKILL.md)
*   The entry point index containing the YAML metadata, description, and list of available Python assets and guides.

### 2. Python Helper Assets (`assets/`)
Each file will contain fully translated, pep8-compliant, and well-documented Python helper functions:

#### [NEW] [general.py](../../.agents/skills/revit-python-helpers/assets/general.py)
*   *Based on `lib_general.py`*. Unwrap utilities, unit conversions, bounding box filters, element deletion, groups, assemblies, reference planes, and grid generation.

#### [NEW] [transformations.py](../../.agents/skills/revit-python-helpers/assets/transformations.py)
*   *Based on `lib_transformaciones.py`*. Element translation, copying, rotation, mirroring, hand/facing flips, pinning/unpinning, and Autodesk.Revit.DB.Transform math wrappers.

#### [NEW] [coordination.py](../../.agents/skills/revit-python-helpers/assets/coordination.py)
*   *Based on `lib_coordinacion.py`*. Level creation, warnings audit, workset assignment and default visibility, link element collection, coordinates acquisition, and host-link comparison.

#### [NEW] [architecture.py](../../.agents/skills/revit-python-helpers/assets/architecture.py)
*   *Based on `lib_arquitectura.py`*. Room boundary extraction, wall utilities, floor generation, ceiling/roof creation, railing generation, and area management.

#### [NEW] [mep.py](../../.agents/skills/revit-python-helpers/assets/mep.py)
*   *Based on `lib_instalaciones.py`*. Duct, pipe, conduit, and cable tray creation, MEP systems connectivity, fittings insertion, and lighting/equipment placement.

#### [NEW] [structure.py](../../.agents/skills/revit-python-helpers/assets/structure.py)
*   *Based on `lib_estructura.py`*. Structural columns, beams, framing, foundation, slab, rebar layout, and structural load definition.

#### [NEW] [geometry.py](../../.agents/skills/revit-python-helpers/assets/geometry.py)
*   *Based on `lib_geometria.py`*. Curve loops, solid Boolean operations, DirectShape creation, coordinate projection, and A* pathfinding.

#### [NEW] [views.py](../../.agents/skills/revit-python-helpers/assets/views.py)
*   *Based on `lib_vistas.py`*. Plan/3D/section view creation, title block sheets, graphic overrides, and image export.

#### [NEW] [families.py](../../.agents/skills/revit-python-helpers/assets/families.py)
*   *Based on `lib_familias.py`*. Safe family loading, instance placing, type catalog parsing, and family parameter management.

#### [NEW] [cad.py](../../.agents/skills/revit-python-helpers/assets/cad.py)
*   *Based on `lib_cad.py`*. DWG/DXF link import, layer visibility analysis, curve retrieval, and block instance extraction.

#### [NEW] [excel.py](../../.agents/skills/revit-python-helpers/assets/excel.py)
*   *Based on `lib_excel.py`*. Excel reading/writing via COM Interop / OpenXML, and pandas DataFrame integration.

#### [NEW] [databases.py](../../.agents/skills/revit-python-helpers/assets/databases.py)
*   *Based on `lib_bases_datos.py`*. JSON/CSV exports, IFC exporting, scheduling, and GUID mapping.

#### [NEW] [collaborative.py](../../.agents/skills/revit-python-helpers/assets/collaborative.py)
*   *Based on `lib_colaborativo.py`*. Cloud and local worksharing setup, sync with central, and workset management.

#### [NEW] [transactions.py](../../.agents/skills/revit-python-helpers/assets/transactions.py)
*   *Based on `lib_transacciones.py`*. Transaction groups, native Revit transactions, and subtransactions.

#### [NEW] [selection_ui.py](../../.agents/skills/revit-python-helpers/assets/selection_ui.py)
*   *Based on `lib_seleccion_ui.py`*. Element, face, edge, point, window/rectangle selection, and link elements interactive picker.

#### [NEW] [scientific.py](../../.agents/skills/revit-python-helpers/assets/scientific.py)
*   *Based on `lib_scientific.py`*. Math integrations utilizing scipy, numpy, matplotlib, shapely, and networkx with Revit API.

#### [NEW] [ui.py](../../.agents/skills/revit-python-helpers/assets/ui.py)
*   *Based on `lib_ui.py`*. WPF non-modal forms: text/numeric/choice dialogs, file pickers, progress trackers, and table displayers.

### 3. Reference Documentation (`references/`)

#### [NEW] [helper_guide.md](../../.agents/skills/revit-python-helpers/references/helper_guide.md)

*   A comprehensive, searchable index listing every function, its module, parameter types, return values, and concrete pyRevit/Dynamo examples.

---

## Verification Plan

### Automated Tests & Checks
1.  **Syntax Verification:** We will run `python -m py_compile` on each of the created assets to verify they are syntax-error-free.
2.  **Metadata Compliance:** We will check that `SKILL.md` contains the mandatory frontmatter and matches the standard index format.

### Manual Verification
1.  **Code Quality Review:** Check variable naming conventions (`snake_case`), type annotations, and descriptive docstrings.
