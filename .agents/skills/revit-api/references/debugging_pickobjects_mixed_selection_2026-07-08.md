# Debugging Lesson: Mixed Selection References in PickObjects

**Date:** 2026-07-08
**Context:** Revit API Selection, `UIDocument.Selection.PickObjects`

## Symptom
When calling `Selection.PickObjects(ObjectType, ISelectionFilter, string, IList<Reference>)` with a pre-selected list of references, the Revit API throws an immediate `Autodesk.Revit.Exceptions.ArgumentException` with the message:
`"pPreSelected has invalid object."`

## Root Cause
The `IList<Reference>` passed as `pPreSelected` MUST strictly match the `ObjectType` parameter:
- If `ObjectType == ObjectType.Element`, all references in the list must be standard element references inside the host document.
- If `ObjectType == ObjectType.LinkedElement`, all references in the list MUST be valid link references generated via `reference.CreateLinkReference(RevitLinkInstance)`.

Mixing `ObjectType.Element` with `LinkedElement` references in the pre-selection list, or attempting to select both simultaneously in a single `PickObjects` call, is structurally impossible in the Revit API and causes the exception.

## Solution / Design Pattern
To allow users to select from both the Host Model and Linked Models in the same workflow, you must implement a **Sequential Selection Pattern**:
1. Prompt the user (e.g., using a `TaskDialog`) to clarify their intention: "Host Only", "Links Only", or "Both".
2. If "Both", execute `PickObjects(ObjectType.Element, ...)` first, ask the user to click 'Finish'.
3. Then execute `PickObjects(ObjectType.LinkedElement, ...)` sequentially.
4. Merge the resulting `IList<Reference>` collections into a single enumerable for the application logic.

*Note: See `revit-addin-helpers/assets/SequentialSelectionPattern.cs` for a reusable implementation.*
