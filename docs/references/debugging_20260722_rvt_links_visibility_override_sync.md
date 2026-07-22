# Debugging Log: Revit Link Visibility Override Sync in View Templates

**Date:** 2026-07-22  
**Add-in:** TransferPlus  
**Component:** `TransferOrchestrator.cs`  

## 1. Problem
When transferring a View Template (planilla de vista), visibility overrides for RVT Links (Vínculos de Revit) were lost or not applied. Specifically, checking/unchecking linked files in the "Revit Links" tab did not translate.

## 2. Root Cause Analysis
1. **Link Overrides vs. Element Visibility**:
   In Revit API, checking/unchecking the checkbox next to a Revit Link Instance on the "Revit Links" tab controls the visibility of the link element in that view/template.
   This state is represented by `Element.IsHidden(View)` and modified via `View.HideElements` / `View.UnhideElements`. It is NOT stored inside the `RevitLinkGraphicsSettings` class.
2. **Missing Visibility Sync**:
   The transfer logic was only copying `RevitLinkGraphicsSettings` (custom settings like "By Link View"), but was not checking or synchronizing the element-hidden status of the link instances themselves.

## 3. Solution
Synchronize the `IsHidden` visibility state of each `RevitLinkInstance` between the source and target views (including templates):
```csharp
bool isHidden = srcLink.IsHidden(srcView);
bool isTargetHidden = targetLink.IsHidden(targetGraphicsView);
if (isHidden && !isTargetHidden)
{
    targetGraphicsView.HideElements(new List<ElementId> { targetLink.Id });
}
else if (!isHidden && isTargetHidden)
{
    targetGraphicsView.UnhideElements(new List<ElementId> { targetLink.Id });
}
```

## 4. Verification
- Compiled successfully with 0 errors.
