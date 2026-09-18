# Lesson Learned: RevitApp Initialization & External Family Symbol Extraction

## Date: 2026-08-06
## Module: TransferPlus (Revit Add-in, C# / .NET 4.8 / Revit API 2024)

---

## 1. Issue Summary
When scanning external family files (.rfa from local folders, Azure Storage, or ACC Cloud), a dummy symbol matching the family name (e.g., `KRN_PUE_Ext_PC06`) was created alongside the real family types (`Puerta 90cm`, `Puerta 110cm`), resulting in redundant suffixed types (`KRN_PUE_Ext_PC06_Copy`) in target models.

---

## 2. Technical Cause
- `_familyRevitService.RevitApp` was `null` during ViewModel construction when initial family scanning occurred.
- `RfaMetadataExtractor.ExtractCategoryAndSymbols` requires a non-null `Autodesk.Revit.ApplicationServices.Application` to open `.rfa` files in memory via `app.OpenDocumentFile(rfaPath)` and read `familyDoc.FamilyManager.Types`.
- Because `RevitApp` was `null`, the `OpenDocumentFile` step was skipped, causing `symbols` to be empty and triggering the fallback `symbols.Add(new FamilySymbolItemModel { Name = familyName })`.

---

## 3. Solution
- Explicitly assign `_familyRevitService = new FamilyRevitService { RevitApp = app?.Application };` in `TransferPlusViewModel` constructor.
- Ensures all external family scans open the `.rfa` in memory and populate `Symbols` strictly from existing `FamilyType` items in `FamilyManager.Types`.
