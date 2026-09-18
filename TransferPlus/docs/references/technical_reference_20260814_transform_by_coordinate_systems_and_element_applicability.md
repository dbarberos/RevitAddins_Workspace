# Technical Reference: Coordinate Transformations ("Transform By") & Element Applicability in Cross-Document Transfers

## 1. Overview & Architectural Context

When transferring elements between Autodesk Revit documents via the Revit API (`ElementTransformUtils.CopyElements`), Revit requires a mathematical `Transform` matrix defining rotation and translation in 3D Euclidean space.

In add-ins like **TransferPlus**, the **"Transform By"** settings determine how source elements are mapped into the destination document coordinate space.

---

## 2. The Three Transformation Modes

| Mode | API Transformation Formula | Description & Target Coordinates | Best For / Use Case |
| :--- | :--- | :--- | :--- |
| **None** | `Transform.Identity` | Strictly aligns the $(0,0,0)$ **Internal Origin** of the source document with the $(0,0,0)$ Internal Origin of the target document. Completely ignores any visual placement, translation, or rotation of the link instance in the host project. | When both models are authored strictly **Origin-to-Origin** without coordinate shifts or rotations. |
| **Link** *(Recommended Default)* | `linkInstance.GetTotalTransform()` | Queries the active host document for the `RevitLinkInstance` corresponding to the source document and retrieves its cumulative transformation matrix (`GetTotalTransform()`). Elements arrive in the exact visual location on screen (**WYSIWYG**). | **Standard day-to-day workflow.** Guarantees copied elements land exactly where the user visually observes the link in Revit's canvas. |
| **Shared** | `targetDoc.ActiveProjectLocation.GetTotalTransform().Multiply(sourceDoc.ActiveProjectLocation.GetTotalTransform().Inverse)` | Computes the differential coordinate transformation between the source document's active `ProjectLocation` and the target document's active `ProjectLocation`, referencing the **Survey Point** and published/acquired Shared Coordinates. | Master plans, campus developments, hospitals, or civil infrastructure projects where buildings are modeled in local orthogonal coordinates but positioned globally via Shared Coordinates. |

---

## 3. Element Applicability Matrix

### A. Elements Subject to Transformation (Geometry & Spatial Coordinates)

1. **3D Physical & Model Elements:**
   - Walls, Floors, Roofs, Structural Columns, Framing, Doors, Windows, Generic Models, MEP components (Ducts, Pipes, Cable Trays).
   - Transferred directly with `ElementTransformUtils.CopyElements(..., transform, ...)`.
2. **Model Views & Bounding Boxes (`CropBox`):**
   - Floor Plans, Ceiling Plans, Structural Plans, 3D Views, Sections, Elevations.
   - When a view is created in the target document, its `CropBox` element is translated and rotated by the transformation matrix so that the view frame accurately encloses the transferred model area.
3. **Elevation & Section Markers (`ElevationMarker`, `ViewSection`):**
   - The host marker element and direction vectors are positioned and rotated according to the computed transform.
4. **Callouts (`ponCallouts`):**
   - The boundary geometry and crop box of view callouts are re-projected to match the transformed parent view coordinate frame.
5. **View-Level 2D Detail Annotations (Transferred into Transformed Model Views):**
   - 2D detail lines, detail components, and annotations copied into model views are translated/rotated in accordance with the host view's spatial adjustment.

---

### B. Elements NOT Subject to Transformation (Non-Spatial / Paper Space)

- **Project Standards & Settings:** Materials, Object Styles, Line Styles, Fill Patterns, View Filters, Project Parameters.
- **View Templates:** Abstract display configurations with no 3D spatial properties.
- **Loadable Family Definitions (`.rfa` in Project Browser):** Loading family symbols into the document library does not require coordinate transformation (transformation applies only to placed family instances).
- **Schedules (`ViewSchedule`) & Legends (`ViewType.Legend`):** Tabular data and drafting legends independent of building coordinates.
- **Sheets (`ViewSheet`):** 2D paper canvas with sheet-space layout.

---

## 4. UI Specification & English Tooltips

### A. Title Tooltip: `Transform By:`
```text
Transfer Coordinate System

Defines the coordinate system and transformation matrix applied when transferring 3D model elements, view crop boxes, sections, elevations, and callouts.

(Does not affect project standards, family definitions in browser, or schedules).
```

### B. Option 1 Tooltip: `None`
```text
Internal Origin (0, 0, 0)

• Applies to: 3D Elements, View Crop Boxes, Sections, Elevations, and Callouts.
• Behavior: Strictly aligns the source Internal Origin (0,0,0) with the active model's Internal Origin, ignoring any visual link movement or rotation.
• Recommended: When both models share the exact same Origin-to-Origin insertion point.
```

### C. Option 2 Tooltip: `Link` (Default)
```text
Link Instance Transform (Default / WYSIWYG)

• Applies to: 3D Elements, View Crop Boxes, Sections, Elevations, and Callouts.
• Behavior: Honors the current position and rotation of the link instance on screen. Transferred elements will land exactly where you visually see them in the model view.
• Recommended: Standard choice for transfers from loaded Revit links.
```

### D. Option 3 Tooltip: `Shared`
```text
Shared Coordinates (Survey Point)

• Applies to: 3D Elements, View Crop Boxes, Sections, Elevations, and Callouts.
• Behavior: Calculates position and rotation using the published Shared Coordinate system and Survey Point offset between both project files.
• Recommended: For master plans, infrastructure, or projects where buildings use localized axes linked via shared geographical coordinates.
```
