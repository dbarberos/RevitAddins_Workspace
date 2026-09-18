# Debugging Report: ViewSheet TitleBlock vs 2D View Elements Copying Logic

## Info
* **Date:** 2026-07-20
* **Component:** `TransferOrchestrator.cs`
* **Skill Target:** `revit-api-families`
* **Technology:** Revit API / `ViewSheet` / `BuiltInCategory.OST_TitleBlocks` / `config.cf_chk_ViewElements`

---

## 1. Requirement & Business Logic Hierarchy
When transferring a `ViewSheet` (`Sheet`) across Revit documents, the transfer options behave as follows:

1. **TitleBlock (`OST_TitleBlocks`)**:
   * The TitleBlock family instance is the sheet boundary/frame itself.
   * **ALWAYS** copied when a Sheet is transferred so the target sheet is created with its frame.

2. **2D Sheet Annotations & Detail Elements** (TextNotes, DetailCurves, FilledRegions, RevisionClouds, GenericAnnotations, Dimensions, etc.):
   * Conditioned on **`config.cf_chk_ViewElements` ("Transfer View Elements")**.
   * If `config.cf_chk_ViewElements` is `true`: Included and copied to the target sheet.
   * If `config.cf_chk_ViewElements` is `false`: Omitted from sheet copying.

3. **Placed Model Views & Viewports**:
   * Conditioned on **`config.cf_chk_SheetWithViews` ("Transfer Sheet with Views")**.

4. **Default Unchecked Behavior**:
   * If ALL options ("Transfer Sheet with Views", "Transfer View Elements", Legends, Schedules, Callouts) are UNCHECKED, the add-in creates the target sheet with ONLY its **TitleBlock**.

---

## 2. Implementation Code Pattern

In `TransferOrchestrator.cs`:

```csharp
if (sourceView is ViewSheet sourceSheet && targetView is ViewSheet targetSheet)
{
    LoggerService.LogInfo($"SheetTransfer: Processing Sheet '{sourceSheet.SheetNumber} - {sourceSheet.Name}' (Id: {sourceSheet.Id.Value}) -> Target Sheet '{targetSheet.SheetNumber} - {targetSheet.Name}'");

    try
    {
        var allSheetElements = new FilteredElementCollector(sourceDoc, sourceSheet.Id)
            .WhereElementIsNotElementType()
            .Where(e => e is not Viewport && e is not View && e is not SunAndShadowSettings && e is not Level && e is not SketchPlane)
            .ToList();

        var titleBlockIds = allSheetElements
            .Where(e => e.Category != null && e.Category.Id.Value == (long)BuiltInCategory.OST_TitleBlocks)
            .Select(e => e.Id)
            .ToList();

        var detailElementIds = allSheetElements
            .Where(e => e.Category == null || e.Category.Id.Value != (long)BuiltInCategory.OST_TitleBlocks)
            .Select(e => e.Id)
            .ToList();

        var sheetElementsToCopy = new List<ElementId>();

        // TitleBlocks are ALWAYS copied for the sheet
        sheetElementsToCopy.AddRange(titleBlockIds);
        LoggerService.LogInfo($"SheetTransfer: Found {titleBlockIds.Count} TitleBlocks on source sheet '{sourceSheet.SheetNumber}'.");

        // Other 2D annotation/detail elements on the sheet are included ONLY IF config.cf_chk_ViewElements is enabled
        if (config.cf_chk_ViewElements && detailElementIds.Any())
        {
            sheetElementsToCopy.AddRange(detailElementIds);
            LoggerService.LogInfo($"SheetTransfer: 'Transfer View Elements' is enabled. Including {detailElementIds.Count} 2D detail/annotation elements from sheet '{sourceSheet.SheetNumber}'.");
        }
        else if (detailElementIds.Any())
        {
            LoggerService.LogInfo($"SheetTransfer: 'Transfer View Elements' is disabled. Omitting {detailElementIds.Count} 2D detail/annotation elements from sheet '{sourceSheet.SheetNumber}'.");
        }

        if (sheetElementsToCopy.Any())
        {
            var copiedSheetElements = ElementTransformUtils.CopyElements(sourceSheet, sheetElementsToCopy, targetSheet, Transform.Identity, options);
            LoggerService.LogInfo($"SheetTransfer: Successfully copied {copiedSheetElements.Count} elements (TitleBlocks & 2D) to target sheet '{targetSheet.SheetNumber}'.");
        }
    }
    catch (Exception exSheetElements)
    {
        LoggerService.LogError($"SheetTransfer: Failed copying TitleBlock/2D elements for sheet '{sourceSheet.SheetNumber}'", exSheetElements);
    }
}
```
