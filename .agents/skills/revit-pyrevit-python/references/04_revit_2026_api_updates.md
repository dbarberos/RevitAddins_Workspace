# Updates and Deprecations in the Revit 2026 API

## 1. Introduction
Revit 2026 brings new features and changes that affect the functioning of the API, making it crucial to know what has been removed, what has changed, and what new features are available so that scripts continue to run smoothly. As a Senior developer, you must always verify the compatibility of methods according to the version of Revit in which the script will operate.

## 2. Critical Changes and ElementId
The handling of element identifiers has undergone major data type modifications in recent versions, consolidating in 2026:
* **ElementId to 64 bits:** The `Autodesk.Revit.DB.ElementId` constructor has been internally modified to use 64-bit integers (`integer 64`) instead of 32-bit (`integer 32`).
* **Getting the numerical value:** The old `IntegerValue` property has been completely removed from the API. It must now be strictly replaced by the `Value` property.

## 3. Frequent Removals and Replacements
Many common methods and properties have been replaced or renamed. When programming, make sure to use the current versions:
* **Slab Shape Editor (Floors and Roofs):** For the `Floor` and `RoofBase` classes, the `SlabShapeEditor` property has been removed; instead, the `GetSlabShapeEditor()` method must be called.
* **Drawing in Slab Shape Editor:** The `DrawPoint` and `DrawSplitLine` methods have been replaced by `AddPoint` and `AddSplitLine` respectively.
* **Viscosity in MEP:** Properties like air and duct viscosity have been renamed to include the word "Dynamic" (e.g., `DynamicViscosity`).
* **Phases:** The `NumberofPhases` property changed its name to `PhasesNumber`.
* **Arrays:** Methods related to radial and linear arrays were removed and replaced by checks like `IsValidNumberOfMembers`.
* **Curves:** The `IsCurveLoopValid` method was removed and replaced by `IsOuterControlValid`.
* **PDF Import:** The `IsPdfImportAvailable` method was removed as it always returned true.

## 4. Structural and Geometry Changes
The API for structures, especially rebars, has received massive modifications in Revit 2026.
* **Compound Structures:** Core layers are no longer strictly required, which facilitates the programmatic creation of walls and enclosures.
* **View Positioning:** The new `ViewPosition` class was introduced to handle the automated positioning of views within sheets.
* **Toposolids:** New methods like `CreateSubdivision` and cut stability tools (`CutVoidStability`) were added.
* **CEF:** The Chromium Embedded Framework (CEF) was removed from the API.
* **Closing Events:** The `DocumentClosing` and `DocumentClosed` events will no longer be invoked if Revit closes due to corruption or process cancellation.

## 5. Warning about Official 2026 Documentation
When looking for class references in the official Revit 2026 API documentation, you will notice that much vital information, such as detailed descriptions, `remarks`, and code examples, has been omitted.
* **Debugging Strategy:** If you need to deeply understand a class or method in 2026, it is highly recommended to consult the 2025 version documentation to get context and additional examples.
