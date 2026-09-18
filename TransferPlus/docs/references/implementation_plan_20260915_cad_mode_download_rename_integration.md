# Implementation Plan: PowerRename Palette Verification & CAD Download Integration

## 1. Verification of Rename Palette Features in CAD Mode

### A. Feature Parity with Family Mode
* **Search & Replace**: Available and fully functional for CAD items.
* **Regex, Case Sensitivity, Whole Occurrences**: Operates across the `RenamePreviewItems` collection identically to Family Mode.
* **Helper Tokens & Dynamic Counters**: Date/Time stamps (`$YYYY`, `$MM`, etc.), Random strings, and sequential counters (`${}`, `${start=10,increment=5}`) evaluate dynamically for each selected CAD item.
* **Text Formatting**: Uppercase (`AA`), Lowercase (`aa`), Title Case (`Aa`), and Capitalize Each Word (`Aa Aa`) apply correctly.
* **Enumeration & Numbering Sequence**: Prefixes, suffixes, ascending/descending numeric and alphanumeric sequence generators format CAD preview names properly.
* **Item Selection**: Individual checkboxes and "Select All" header toggle in the preview DataGrid work identically.

### B. Iterative Renaming via Palette "Apply" Button (`ApplyRenameReplace`)
* When the user clicks the "Apply" button inside the palette (`ApplyRenameReplaceCommand` next to "Changed by"):
  * For all checked items in the DataGrid, `item.WorkingName` is updated with `item.NewName`.
  * The search and replace input fields are reset to empty.
  * To ensure the user can **chain multiple renaming operations** (e.g. rename some items, click Apply, then rename other items or further refine the current items):
    - `UpdateRenamePreviews()` will be updated to check matches against `item.WorkingName` (the current cumulative working name) instead of strictly `item.OriginalName`.
    - This allows consecutive search/replace operations without losing previous modifications.

### C. Palette Closure & Reversion Behavior (`CloseRenamePanel`)
* When the user clicks **"Close Rename"** (or switches manager modes):
  * `CloseRenamePanel()` executes:
    - Sets `IsRenamePanelOpen = false` (animates the panel closed).
    - Resets search and replace inputs.
    - **Calls `RenamePreviewItems.Clear()`**: All staged rename changes in memory are completely discarded.
  * When the palette is closed, subsequent **Transfer** or **Download** operations detect that `RenamePreviewItems` is empty, ensuring that all elements/files are transferred or downloaded strictly with their **original names**.
  * If the user later re-opens the palette by clicking "Apply" on the "Rename:" card, `OpenRenamePanel()` re-reads the elements fresh from the source document, completely resetting the preview items to their original names.

---

## 2. Proposed Changes for CAD Download Integration

### Component: [TransferPlusViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/ViewModels/TransferPlusViewModel.cs)

#### 1. Iterative "Apply" Enhancement in `UpdateRenamePreviews`
* Change `regex.IsMatch(item.OriginalName)` / `re.IsMatch(item.OriginalName)` to match against `item.WorkingName`.
* This enables chaining multiple "Apply" steps across different or identical elements before transferring or downloading.

#### 2. Read `RenamePreviewItems` in `DownloadSelectedCadItemsAsync`
* Extract `cadRenameMap` and `cadCustomNames` from `RenamePreviewItems` when `IsRenamePanelOpen || RenamePreviewItems.Any()`.
* For each CAD item in the download loop, resolve `effectiveCadName` using:
  1. `pItem.CadIdentifier` (deterministic match with TreeView node)
  2. `cadItem.ElementId`
  3. `cadItem.FilePath`
  4. `cadItem.Name` / `cadItem.ViewName`
* If the item is a Detail Component family (`family != null`), resolve `rfaBaseName` using `effectiveCadName` so exported `.rfa` files use the renamed name.
* Pass `effectiveCadName` to `ExportOrDownloadCadItemAsync(uiApp, cadItem, targetSubFolder, effectiveCadName)`.

#### 3. Support `overrideFileName` in `ExportOrDownloadCadItemAsync`
* Add parameter `string? overrideFileName = null`.
* Set `baseFileName = !string.IsNullOrWhiteSpace(overrideFileName) ? overrideFileName : (!string.IsNullOrWhiteSpace(cadItem.Name) ? cadItem.Name : "CAD_Detail")`.
* In all export/download branches, use `baseFileName`:
  - **Local DWG/DXF/DGN/SAT files**: `ResolveNonCollidingFilePath(targetFolder, baseFileName, ext)`.
  - **Cloud storage (Azure, AWS S3, Autodesk Docs ACC)**: `ResolveNonCollidingFilePath(targetFolder, baseFileName, ext)`.
  - **Revit Drafting Views / Detail Views exported to DWG**: `sourceDoc.Export(folder, baseFileName, ...)`.
  - **CAD Import Instances / Groups exported to DWG**: `sourceDoc.Export(folder, baseFileName, ...)`.
  - **Detail Component Families exported to .rfa**: `_familyRevitService.ExportSelectiveFamilyToFolder(..., baseFileName)`.

---

## 3. Verification Plan

### Automated Verification
* `dotnet build TransferPlus/TransferPlus.csproj -c Debug.R24 /p:DeployAddin=true`
* `dotnet build TransferPlus/TransferPlus.csproj -c Release.R24`, `Release.R25`, `Release.R26`, `Release.R27`
* Run `build-bundle.ps1` to package App Store bundles.

### Manual Verification Steps
1. **Iterative Renaming**:
   - Open TransferPlus in CAD Mode and select CAD elements.
   - Click "Apply" on the Rename card to open the palette.
   - Select element 1, replace a term, click "Apply" inside the palette.
   - Select element 2, replace a different term, click "Apply" inside the palette.
   - Verify that element 1 and element 2 both retain their modified names in the DataGrid.
2. **Discard on Close**:
   - With modified names in the palette, click "Close Rename".
   - Click "Download" -> Verify files are downloaded with their **original names**.
   - Re-open the palette -> Verify all items show their **original names** afresh.
3. **Download with Renamed Names**:
   - Open palette, rename CAD items.
   - With the palette open, click "Download" on the "Select Details/CAD:" card.
   - Choose a target folder -> Verify that the downloaded/exported files (DWG/RFA) use the **renamed names**.
