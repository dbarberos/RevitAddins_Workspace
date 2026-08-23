# Lesson Learned: Collecting 2D Views, Annotations, and CAD Imports from Linked Revit Models (RevitLinkInstance)

**Date:** 2026-08-21  
**Category:** Revit API / Linked Documents / Element Collection & Transfer  
**Tags:** `RevitLinkInstance`, `linkDoc`, `ViewDrafting`, `ImportInstance`, `FilteredElementCollector`, `ReadOnlyDocument`

---

## 1. Context & Architectural Reality

Developers often assume that Revit links (`RevitLinkInstance`) only provide access to 3D physical model elements because 2D views and annotations are not rendered in the host model's view canvas.

**Key Rule:** `linkInstance.GetLinkDocument()` returns the full in-memory `Autodesk.Revit.DB.Document` of the linked `.rvt`. All 2D Drafting Views (`ViewDrafting`), CAD drawings (`ImportInstance`), Detail Sections (`ViewSection`), Detail Groups (`Group`), and Detail Components (`OST_DetailComponents`, `FilledRegion`) reside in this database and can be queried and copied to other project models via `ElementTransformUtils.CopyElements`.

---

## 2. Common Failure Modes & Best Practices

### A. LINQ Predicate Exceptions on Internal Views
**Bad Pattern:**
```csharp
// Crashes if any internal view in linkDoc throws on .ViewType or .IsTemplate
var draftingViews = new FilteredElementCollector(linkDoc)
    .OfClass(typeof(View))
    .Cast<View>()
    .Where(v => v.ViewType == ViewType.DraftingView && !v.IsTemplate)
    .ToList();
```

**Good Pattern:**
```csharp
// Use direct ViewDrafting class collector + safe per-element iteration
var draftingViews = new FilteredElementCollector(linkDoc)
    .OfClass(typeof(ViewDrafting))
    .WhereElementIsNotElementType()
    .Cast<ViewDrafting>()
    .ToList();

var validViews = new List<ViewDrafting>();
foreach (var dv in draftingViews)
{
    try
    {
        if (dv.IsValidObject && !dv.IsTemplate)
        {
            validViews.Add(dv);
        }
    }
    catch { }
}
```

### B. Read-Only Document Transaction Safety
**Bad Pattern:**
```csharp
// Throws InvalidOperationException if doc is a linked model (doc.IsLinked == true)
using (var tx = new Transaction(doc, "Temp Preview"))
{
    tx.Start();
    var tempView = ViewDrafting.Create(doc, typeId); // FAILS ON LINKED DOCS
    ...
}
```

**Good Pattern:**
```csharp
// Linked models are read-only; use non-transactional methods or host model
if (doc.IsLinked || doc.IsReadOnly)
{
    if (ownerViewId != null && ownerViewId != ElementId.InvalidElementId)
    {
        return GenerateViewPreview(doc, ownerViewId); // doc.ExportImage works on links without tx
    }
    doc = ActiveWritableHostDocument; // Redirect to host model for temporary scratch views
}
```

### C. Comprehensive Detail Item Collection
In addition to `FamilyInstance` of category `OST_DetailComponents`, query `FilledRegion` (filled & masking regions) and `FamilySymbol` types so that unplaced detail families can also be discovered and transferred.
