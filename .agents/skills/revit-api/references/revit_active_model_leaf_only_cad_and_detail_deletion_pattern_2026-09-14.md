# Technical Reference: Leaf-Only CAD & Detail Elements Deletion Pattern in Revit API

**Date:** 2026-09-14  
**Target Skills:** `revit-api`, `revit-transactions`, `revit-addin-gui-design`  
**Domain:** Revit API / Active Model Element Deletion / Container Preservation (Sheets & Views) / Cascade Deletion Prevention  

---

## 📌 Problem Overview & Revit API Mechanics

In Autodesk Revit, the element deletion API (`Document.Delete(ElementId)` / `Document.Delete(ICollection<ElementId>)`) operates on relational ownership:

1. **Cascade Deletion Danger**:
   * If an add-in passes a `ViewSheet.Id` to `doc.Delete()`, Revit permanently deletes the entire sheet, its title block instance, and all placed `Viewport` elements.
   * If a `View.Id` is passed to `doc.Delete()`, Revit deletes the view and destroys all annotations, dimensions, detail items, and CAD imports placed inside that view.
2. **The Explorer Dilemma**:
   When tree explorers allow users to group items by `Sheet` or `View` (e.g., `Sheet -> View -> CAD Imports`), intermediate tree nodes often hold references to the container element IDs. If UI checkboxes or selection routines bubble up or collect nodes without filtering, container IDs are passed to `doc.Delete()`, causing catastrophic loss of project documentation.

---

## 🛡️ Core Rules & Invariant Guardrails

1. **Strict Type Whitelist / Blacklist Guard**:
   Before passing any `ElementId` to `doc.Delete()` in a detail-deletion routine, verify that the element is **NOT** a container:
   ```csharp
   Element elem = doc.GetElement(id);
   if (elem is ViewSheet || elem is View)
   {
       throw new InvalidOperationException($"Attempted to delete container {elem.GetType().Name} ({elem.Id}). Deletion aborted.");
   }
   ```
2. **Preserve Hierarchical Containers**:
   Sheets (`ViewSheet`) and Views (`View`) must remain intact in the project model so that BIM coordinators and engineers can reuse them by placing new drawings or details.
3. **Atomic Single-Transaction Scope**:
   Always batch the leaf element IDs into a single `ICollection<ElementId>` and delete them inside a single `Transaction` wrapped in a `using` block:
   ```csharp
   using (var trans = new Transaction(doc, "Delete Selected CAD Details"))
   {
       trans.Start();
       doc.Delete(validLeafIds);
       trans.Commit();
   }
   ```

---

## 🛠️ Implementation Architecture

### 1. Leaf Collection Filter in ViewModels / Services
```csharp
public static List<ElementId> ExtractLeafElementIds(IEnumerable<CadTreeNode> allNodes, Document doc)
{
    var leafIds = new List<ElementId>();

    foreach (var node in allNodes)
    {
        // 1. Structural Filter: Skip non-leaf or container category nodes
        if (node.Children != null && node.Children.Count > 0) continue;
        if (node.Category == "Sheet" || node.Category == "View" || node.Category == "Root") continue;

        if (node.IsChecked == true && node.Item?.ElementId != null)
        {
            var id = node.Item.ElementId;
            var element = doc.GetElement(id);

            // 2. Database Type Filter: Strictly disallow Views and ViewSheets
            if (element != null && !(element is ViewSheet) && !(element is View))
            {
                leafIds.Add(id);
            }
        }
    }

    return leafIds;
}
```

### 2. Multi-Version ID Handling
Always support both legacy and modern Revit API builds:
* For Revit <= 2023: `id.IntegerValue`
* For Revit >= 2024: `id.Value` (`long`)
```csharp
public static long GetRawId(ElementId id)
{
#if REVIT2024_OR_GREATER
    return id.Value;
#else
    return id.IntegerValue;
#endif
}
```
