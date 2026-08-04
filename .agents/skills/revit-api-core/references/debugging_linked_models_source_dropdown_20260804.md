# Debugging Log: Revit Link Instances Missing from Session Document Collector

**Date**: 2026-08-04  
**Skill Target**: `revit-api-core` / `revit-api`  
**Components**: `TransferPlusViewModel.cs` (`LoadDocuments`), `DocumentCollector.cs`

---

## 1. Symptom

In a Revit session with active linked models (*.rvt links loaded inside the main project), selecting source models in dropdown menus failed to list the linked models. Only top-level open project UI windows appeared.

---

## 2. Root Cause

- `Autodesk.Revit.ApplicationServices.Application.Documents` returns ONLY top-level project documents opened in the Revit UI workspace.
- Loaded linked models (`RevitLinkInstance`) reside as elements inside the host `Document` (`_targetDoc`) and are NOT returned by `Application.Documents`.

---

## 3. Solution

Implement a two-pass document collector:
1. Iterate `_app.Application.Documents` for top-level open session documents.
2. Query `FilteredElementCollector(_targetDoc).OfClass(typeof(RevitLinkInstance))` to collect loaded link instances.
3. For each valid `linkInst.GetLinkDocument()`, wrap the document in a source model descriptor (`EsVinculo = true`).

```csharp
// 1. Open UI Documents
foreach (Document doc in _app.Application.Documents)
{
    if (doc.IsFamilyDocument) continue;
    var arch = new Archivo(doc);
    if (doc.IsLinked) arch.EsVinculo = true;
    arch.Nombre = GetDocumentDisplayName(doc);
    SourceDocuments.Add(arch);
    if (!string.IsNullOrEmpty(doc.PathName)) addedDocPaths.Add(doc.PathName);
}

// 2. RevitLinkInstance Linked Documents
if (_targetDoc != null)
{
    var linkInstances = new FilteredElementCollector(_targetDoc)
        .OfClass(typeof(RevitLinkInstance))
        .WhereElementIsNotElementType()
        .Cast<RevitLinkInstance>();

    foreach (var linkInst in linkInstances)
    {
        if (linkInst.IsValidObject)
        {
            Document linkDoc = linkInst.GetLinkDocument();
            if (linkDoc != null && (string.IsNullOrEmpty(linkDoc.PathName) || addedDocPaths.Add(linkDoc.PathName)))
            {
                var arch = new Archivo(linkDoc)
                {
                    EsVinculo = true,
                    Nombre = GetDocumentDisplayName(linkDoc)
                };
                SourceDocuments.Add(arch);
            }
        }
    }
}
```
