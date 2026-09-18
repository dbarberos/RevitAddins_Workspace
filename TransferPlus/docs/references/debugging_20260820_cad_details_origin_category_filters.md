# Debugging Log: CAD Details Origin Radio Options Fallback to Drafting Views

**Date:** 2026-08-20  
**Add-in:** TransferPlus  
**Branch:** `TransferCAD`  

### Symptom
When selecting different radio button options under **ORIGIN** inside the `Select Details/CAD` card (`Details Views / Detail Callouts`, `Details Groups`, `Details Items`), the tree explorer continued to display only Drafting Views instead of filtering and displaying the elements belonging to each category. If a category had no elements, it still showed Drafting Views.

### Root Cause
In `TransferPlusViewModel.LoadCadItemsFromSource`, only `CadOriginDraftingViews` and `CadOriginLinksAndImports` were checked explicitly; all other 3 radio states fell into an `else` branch that directly invoked `DraftingViewProvider.GetDraftingViews(sourceDoc)`:
```csharp
if (CadOriginDraftingViews)
{
    _cadItems = DraftingViewProvider.GetDraftingViews(sourceDoc);
}
else if (CadOriginLinksAndImports)
{
    _cadItems = CadInstanceProvider.GetCadInstances(sourceDoc);
}
else
{
    _cadItems = DraftingViewProvider.GetDraftingViews(sourceDoc); // BUG: Always returned Drafting Views
}
```

### Resolution
1. Created dedicated providers for each category:
   - **`CadInstanceProvider`**: `ImportInstance` (DWG links and imports).
   - **`DraftingViewProvider`**: `ViewType.DraftingView`.
   - **`DetailViewProvider`**: Detail Views & Callouts (`ViewType.Detail || v.IsCallout`).
   - **`DetailGroupProvider`**: 2D Detail Groups (`BuiltInCategory.OST_IOSDetailGroups`).
   - **`DetailItemProvider`**: 2D Detail Components (`BuiltInCategory.OST_DetailComponents`).
2. Updated `LoadCadItemsFromSource` to query each specific provider and return an empty list if no elements exist in that category.
3. Updated `CadDetailItemModel` with a dynamic `Category` property to ensure proper display categorization and grouping.
