# Technical Reference: Cross-Document Coordinate Transformations & Element Applicability

## 1. Mathematical Formulas & Transformation Modes

When copying elements between Revit documents using `ElementTransformUtils.CopyElements`, the target position is governed by a 3D `Transform` matrix.

```csharp
// 1. None (Internal Origin to Internal Origin)
Transform transformNone = Transform.Identity;

// 2. Link Instance Transform (WYSIWYG Screen Placement)
RevitLinkInstance link = new FilteredElementCollector(targetDoc)
    .OfClass(typeof(RevitLinkInstance))
    .Cast<RevitLinkInstance>()
    .FirstOrDefault(i => i.GetLinkDocument()?.Title?.Equals(sourceDoc.Title) == true);

Transform transformLink = link?.GetTotalTransform() ?? Transform.Identity;

// 3. Shared Coordinates (Survey Point Differential Matrix)
Transform sourceShared = sourceDoc.ActiveProjectLocation.GetTotalTransform();
Transform targetShared = targetDoc.ActiveProjectLocation.GetTotalTransform();
Transform transformShared = targetShared.Multiply(sourceShared.Inverse);
```

---

## 2. Element Applicability Rules

### Spatial / Geometrical Elements (Transform Applied)
- **Physical Model Elements (3D):** Walls, columns, beams, generic models, MEP components (`ElementTransformUtils.CopyElements(sourceDoc, ids, targetDoc, transform, options)`).
- **View CropBoxes:** Translated (`transform.Origin`) and rotated along the rotation axis derived from the transform basis vectors.
- **Elevation & Section Markers:** Position and normal vectors updated to preserve geometric spatial alignment.
- **Callout Boundaries:** 8-corner boundary box projected through the parent view transformation.

### Non-Spatial Elements (Transform Ignored)
- **Project Standards:** Materials, Object Styles, Line Patterns, Fill Styles, View Filters.
- **View Templates & Schedules:** Abstract and tabular definitions without 3D spatial points.
- **Family Definitions in Project Browser:** Symbol/type library definitions (transforms apply only to placed physical instances).
- **ViewSheets:** 2D paper layout coordinates.
