# Debugging Log: Revit Link Visibility Checkbox Sync via API

**Date:** 2026-07-22  
**Skill:** `revit-api`  
**API Surface:** `RevitLinkInstance` / `Element.IsHidden` / `View.HideElements`  

## 1. Symptom
When transferring visibility settings between views or templates, the checkbox states in the "Revit Links" tab of the Visibility/Graphics dialog are lost.

## 2. Root Cause
The check/uncheck status of a specific Revit link instance is not stored in `RevitLinkGraphicsSettings`. Instead, Revit treats checking/unchecking the link as hiding/showing the `RevitLinkInstance` element inside the view context.

## 3. Solution Pattern
Query `Element.IsHidden(View)` on the source link instance and apply `HideElements` / `UnhideElements` on the target view:
```csharp
bool isHidden = srcLink.IsHidden(srcView);
bool isTargetHidden = targetLink.IsHidden(targetView);
if (isHidden && !isTargetHidden)
{
    targetView.HideElements(new List<ElementId> { targetLink.Id });
}
else if (!isHidden && isTargetHidden)
{
    targetView.UnhideElements(new List<ElementId> { targetLink.Id });
}
```
*Note: Ensure `targetView` is the View Template if a template is applied.*
