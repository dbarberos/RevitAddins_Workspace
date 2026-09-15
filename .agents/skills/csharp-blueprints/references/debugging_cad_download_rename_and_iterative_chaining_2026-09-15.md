# Debugging Log: CAD Mode Rename Chaining & Download File Renaming Integration

**Date:** 2026-09-15  
**Component:** `TransferPlus` (`TransferPlusViewModel`, `RenamePreviewItem`, `ExportOrDownloadCadItemAsync`)  
**Target Skill:** `csharp-blueprints`  

---

## 1. Symptoms

1. **Broken Iterative Renaming in Palette**: In `TransferPlus` PowerRename palette, when clicking the **"Apply"** button next to "Changed by" (`ApplyRenameReplaceCommand`) to commit a rename step, `item.WorkingName` was updated, but any subsequent search/replace or formatting operations failed to match or reverted back because the search evaluator matched strictly against `item.OriginalName`.
2. **CAD File Download Bypassed Rename Palette**: In CAD Mode, clicking the **Download** button in the "Select Details/CAD" card saved/exported files to disk (DWG, DXF, DGN, SAT, RFA) using their original names, ignoring any renamed names configured in the PowerRename palette.

---

## 2. Root Cause

1. **Iterative Matching Evaluation**: `UpdateRenamePreviews()` evaluated `regex.IsMatch(item.OriginalName)` instead of `item.WorkingName`. Once a user applied a change, `WorkingName` held the new string, but subsequent search queries targeting substrings of the new string returned false because `OriginalName` remained untouched.
2. **Download Routine Decoupled from Rename State**: `DownloadSelectedCadItemsAsync` did not query `RenamePreviewItems`. It iterated directly over `cadNodes` and called `ExportOrDownloadCadItemAsync(uiApp, cadItem, targetFolder)` without passing any custom name mapping.
3. **Hardcoded File Target Generation**: Inside `ExportOrDownloadCadItemAsync`, file paths for local copies, cloud blob downloads (Azure, AWS S3, Autodesk Docs ACC), and Revit DWG / RFA exports were strictly built using `cadItem.Name` or `fam.Name`.

---

## 3. Resolution

1. **Evaluate Dynamic Working Name in Regex Matching**:
   ```csharp
   // Evaluate match against WorkingName if modified, falling back to OriginalName
   string matchTarget = !string.IsNullOrEmpty(item.WorkingName) ? item.WorkingName : item.OriginalName;
   bool isMatch = string.IsNullOrEmpty(RenameSearchText) || regex.IsMatch(matchTarget);
   ```
   This allows consecutive replacements across different or identical elements without losing prior iterations.

2. **Query Rename Previews in `DownloadSelectedCadItemsAsync`**:
   Extract renamed names from `RenamePreviewItems` whenever the palette is open or staged items exist:
   ```csharp
   var cadRenameMap = (IsRenamePanelOpen || RenamePreviewItems.Any())
       ? RenamePreviewItems.Where(p => p.IsSelected && !string.IsNullOrWhiteSpace(p.NewName))
           .GroupBy(p => !string.IsNullOrEmpty(p.CadIdentifier) ? p.CadIdentifier : p.OriginalName)
           .ToDictionary(g => g.Key, g => g.First().NewName)
       : new Dictionary<string, string>();
   ```
   Resolve `effectiveCadName` per item using `CadIdentifier`, `ElementId`, `FilePath`, or `Name`, and compute `rfaBaseName = effectiveCadName` for detail families.

3. **Parametrize `ExportOrDownloadCadItemAsync` with `overrideFileName`**:
   ```csharp
   private async Task<bool> ExportOrDownloadCadItemAsync(
       UIApplication uiApp,
       CadDetailItemModel cadItem,
       string targetFolder,
       string? overrideFileName = null)
   {
       string baseFileName = !string.IsNullOrWhiteSpace(overrideFileName)
           ? overrideFileName
           : (!string.IsNullOrWhiteSpace(cadItem.Name) ? cadItem.Name : "CAD_Detail");

       // Apply baseFileName to all target file paths:
       // - Local copies: ResolveNonCollidingFilePath(targetFolder, baseFileName, ext)
       // - Cloud blobs (Azure/AWS/ACC): ResolveNonCollidingFilePath(targetFolder, baseFileName, ext)
       // - Revit DWG exports: sourceDoc.Export(folder, baseFileName, ...)
       // - Detail family exports: _familyRevitService.ExportSelectiveFamilyToFolder(..., baseFileName)
   }
   ```

4. **Guaranteed Discard-on-Close Safety**:
   Verified that `CloseRenamePanel()` executes `RenamePreviewItems.Clear()`. When the palette is closed, `cadRenameMap` evaluates to empty, ensuring downstream downloads or transfers immediately revert to original source names.
