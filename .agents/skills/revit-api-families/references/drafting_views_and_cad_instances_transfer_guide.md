# Drafting Views & CAD Details Inter-Document Transfer Guide

## 1. Transferring Drafting Views
To transfer 2D drafting views (annotations, lines, text, embedded details) across open Revit documents:
- Retrieve `ViewType.DraftingView` elements from the source document.
- Use `ElementTransformUtils.CopyElements(sourceDoc, viewIds, targetDoc, Transform.Identity, new CopyPasteOptions())`.
- Wrap in a silent Transaction with `WarningSwallower` to suppress non-fatal warnings.

## 2. Transferring CAD Links & Imports to Target Drafting Views
When transferring `ImportInstance` elements placed in 2D or 3D views:
1. Locate or create a `ViewDrafting` in the target document using the document's `ViewFamily.Drafting` `ViewFamilyType`.
2. Generate a unique name for the new drafting view (e.g. `CAD - [Name] ([SourceView])`).
3. For view-specific CAD instances, copy from the owner view:
   ```csharp
   ElementTransformUtils.CopyElements(
       sourceOwnerView,
       new List<ElementId> { cadInstanceId },
       targetDraftingView,
       Transform.Identity,
       new CopyPasteOptions());
   ```
4. For model-wide instances, copy directly with `sourceDoc` as the source parameter.
