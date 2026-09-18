# Debugging Log: Suppress Revit Native Duplicate Type Dialogs & Scope View Duplication

**Date:** 2026-07-22  
**Skill:** `revit-api`  
**API Surface:** `CopyPasteOptions`, `IDuplicateTypeNamesHandler`, `Viewport.CanAddViewToSheet`  

## 1. Symptom
1. Revit pops up native modal dialog "Tipos duplicados: Los siguientes tipos ya existen..." during view element copying.
2. A single view transfer creates two views (`Name` and `Name 1`), ignoring the `Keep Original` setting.

## 2. Root Cause
1. Missing `IDuplicateTypeNamesHandler` on `CopyPasteOptions` passed to `ElementTransformUtils.CopyElements`.
2. Fallback logic in sheet viewport processing creating new plan views even when `Keep Original` was requested.

## 3. Solution Pattern
1. Always attach `IDuplicateTypeNamesHandler` returning `DuplicateTypeAction.UseDestinationTypes` to `CopyPasteOptions`:
```csharp
CopyPasteOptions options = new CopyPasteOptions();
options.SetDuplicateTypeNamesHandler(new CustomCopyHandlerOk());
```
2. Under `Keep Original`, never instantiate new views if an existing view with the same name exists in the target document.
