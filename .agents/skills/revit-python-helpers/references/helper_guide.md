# Revit Python Helpers Reference Guide

Welcome to the comprehensive reference guide for **`revit-python-helpers`**. This skill provides an English-translated, PEP 8-compliant, and optimized catalog of reusable Revit API utility functions for **pyRevit**, **RevitPythonShell (RPS)**, and **Dynamo Python nodes**. It is designed to act as the direct Python counterpart to the `revit-addin-helpers` C# skill.

---

## 📂 Module Catalog & API Reference

All modules reside inside the `assets/` directory of the `revit-python-helpers` skill folder and can be easily imported into any Revit Python execution context.

### 1. `general.py` — Core Utilities
*   **Purpose:** Standard object unwrapping, Revit versioning, unit conversions, native transaction wrappers, and basic filtering.
*   **Key Functions:**
    *   `unwrap(element)`: Version-safe unwrapping of Dynamo elements to native Revit `Element` objects.
    *   `unwrap_list(elements)`: Mass unwrapping of a list of elements.
    *   `id_to_int(element_id)`: Converts a Revit `ElementId` to an integer in a version-safe manner (using `ElementId.Value` in Revit 2024+ or `ElementId.IntegerValue` in Revit <= 2023).
    *   `feet_to_meters(val_feet)` / `meters_to_feet(val_meters)`: Handles Revit's internal double representation mapping.
    *   `get_parameter_value(element, name)` / `set_parameter_value(element, name, val)`: Safe parameter read/write using `StorageType` resolution.
    *   `filter_by_boundingbox(bbox, category_bic, tolerance)`: Fast bounding box intersection query.

### 2. `transformations.py` — Placement & Matrix Math
*   **Purpose:** Translations, copy-paste operations, rotations, mirroring, flipping, pinning, orientation vectors, and Autodesk.Revit.DB.Transform math.
*   **Key Functions:**
    *   `move_element_m(element, dx_m, dy_m, dz_m)`: Absolute translations in metric units.
    *   `align_to_point(element, target_xyz)`: Position elements in absolute coordinates.
    *   `rotate_element_on_own_point(element, angle_degrees)`: Simple plan-view rotation of instances.
    *   `mirror_element(element, normal, origin, create_copy)`: Mirrors element in-place or copies it.
    *   `flip_facing(family_instance)` / `flip_hand(family_instance)`: Inverts direction or hand orientation.
    *   `create_axes_transform(origin, axis_x, axis_y, axis_z)`: Generates local coordinate systems for sections or Crops.

### 3. `transactions.py` — Context & SubTransactions
*   **Purpose:** Advanced transaction logic, rollback protection, execution lists inside transaction groups, subtransactions, and multi-document comparison.
*   **Key Functions:**
    *   `run_in_transaction_group(group_name, function_calls)`: Performs multiple operations in a transaction group and commits via `Assimilate` or rolls back.
    *   `run_in_native_transaction(name, fn, *args)`: Native transaction wrapper with automatic exception rollback.
    *   `run_in_subtransaction(name, fn, *args)`: Executes a nested operation using a `SubTransaction` inside an active transaction.

### 4. `selection_ui.py` — Active Document Selection UI
*   **Purpose:** Decoupled graphical picking methods.
*   **Key Functions:**
    *   `select_element(message)` / `select_multiple_elements(message)`: UI pick element prompts.
    *   `select_face(message)` / `select_edge(message)`: Pick geometry sub-objects.
    *   `select_linked_element(message)`: Pick elements nested within a `RevitLinkInstance`.
    *   `select_elements_by_rectangle(message)`: Mass drag-selection box.

### 5. `ui.py` — pyRevit and WPF Fallback UI Dialogs
*   **Purpose:** Prompts, file dialogs, progress bars, and user-choice UI.
*   **Key Functions:**
    *   `show_message(title, instruction, content)`: Informative alert dialogue.
    *   `confirm(title, instruction)`: Yes/No confirmation check.
    *   `prompt_text(title, message, default)`: Prompts the user for a text string.
    *   `select_file(title, filter)`: File picker with Forms fallback.
    *   `show_progress_bar(title)`: Context manager for pyRevit's `ProgressBar` or mockup fallback.

### 6. `families.py` — Load, Placement & Catalogs
*   **Purpose:** Safely load family assets into models, place instances, activate symbols, and inspect parameter definitions.
*   **Key Functions:**
    *   `load_family(family_path)`: Overwrites parameters automatically during loading.
    *   `place_family_instance(symbol, point, level, structural)`: Inserts active symbols.
    *   `get_family_parameters(family)`: Interrogates family definition parameter structure.

### 7. `cad.py` — DWG/DXF Link Interop
*   **Purpose:** Querying linked and imported CAD elements, extracting layers, and harvesting geometric vectors.
*   **Key Functions:**
    *   `classify_cad_links()`: Separates linked dwg files from imports.
    *   `get_cad_layer_names(import_instance)`: Harvests active layers.
    *   `get_curves_by_layer(import_instance, layer_name)`: Harvests vectors from a specific layer to generate Revit elements.

### 8. `excel.py` — Excel COM & OpenXML
*   **Purpose:** Local data harvesting and spreadsheet generation.
*   **Key Functions:**
    *   `read_excel_com(path, sheet)` / `write_excel_com(path, data, sheet)`: Excel reading/writing via local COM Interop.

### 9. `databases.py` — Serialization & CSV
*   **Purpose:** Flat file databases, parameter harvesting exports, and bulk imports.
*   **Key Functions:**
    *   `read_json(path)` / `write_json(path, data)`: Serializes dictionaries.
    *   `export_element_parameters(category_bic, param_names, csv_path)`: Bulk dumps instance parameters to a CSV file.
    *   `import_parameters_from_json(json_path)`: Mass updates Revit elements by GUID/UniqueId map.

### 10. `collaborative.py` — Worksharing & Models
*   **Purpose:** Multi-user BIM collaboration, default worksets, synchronizing, and ownership management.
*   **Key Functions:**
    *   `enable_worksharing(default_workset)`: Enables worksharing on local files.
    *   `sync_with_central(comment)`: Synchronizes with the central file and relinquishes ownerships.

### 11. `coordination.py` — Coordination & Warnings
*   **Purpose:** Auditing model warnings, creating levels, and query coordination links.
*   **Key Functions:**
    *   `create_levels_in_batch(elevations, names)`: Generates multiple elevations.
    *   `analyze_warnings_by_type()`: Extracts active warnings grouped by description.
    *   `get_linked_elements(link_instance, category_bic)`: Interrogates Linked Document contents.

### 12. `architecture.py` — Room Boundaries & Interiors
*   **Purpose:** Extracting room geometry loops, generating interior floors/ceilings, and placing furniture bounds.
*   **Key Functions:**
    *   `get_rooms()`: Returns valid spatial elements.
    *   `get_room_boundary_curves(room)`: CurveLoop builder from room segments.
    *   `create_floor_from_room(room, floor_type, level)`: Automatically creates structural or architectural floors tracing room boundaries.

### 13. `scientific.py` — Advanced Analytics
*   **Purpose:** Bridging data science libraries (`numpy`, `pandas`, `shapely`, `networkx`) with the Revit API inside CPython 3 environments.
*   **Key Functions:**
    *   `check_dependencies_status()`: Validates available libraries.

---

## 🚀 Quick Start & Integration Guides

### Integration in pyRevit Pushbuttons
To load the helper modules inside a pyRevit pushbutton (`script.py`), append the skill assets path to `sys.path`:

```python
# -*- coding: utf-8 -*-
import sys
import os

# Append the revit-python-helpers skill path dynamically
sys.path.append(r".agents/skills/revit-python-helpers")

from assets.general import feet_to_meters, get_parameter_value, unwrap
from assets.selection_ui import select_multiple_elements
from assets.ui import show_message

# Select elements and read metric dimensions
elems = select_multiple_elements("Select windows to extract heights")
data = []
for e in elems:
    h_feet = get_parameter_value(e, "Height")
    if h_feet:
        h_meters = feet_to_meters(h_feet)
        data.append("ID {}: {:.2f} m".format(e.Id.Value, h_meters))

show_message("Window Heights", "Extracted dimensions:", "\\n".join(data))
```

### Integration in Dynamo Python Nodes
In Dynamo, ensure the target elements are unwrapped before processing through the API wrappers:

```python
import sys
import clr
clr.AddReference("RevitServices")
from RevitServices.Persistence import DocumentManager

# Append path
sys.path.append(r".agents/skills/revit-python-helpers")
from assets.general import unwrap_list, feet_to_meters, get_parameter_value

doc = DocumentManager.Instance.CurrentDBDocument

# Input elements from Dynamo
dynamo_elements = IN[0]
param_name = IN[1]

# Unwrap to native Revit elements
revit_elements = unwrap_list(dynamo_elements)

output_values = []
for el in revit_elements:
    val = get_parameter_value(el, param_name)
    output_values.append(val)

OUT = output_values
```
