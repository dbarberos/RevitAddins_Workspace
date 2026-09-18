# Implementation Plan: CAD Mode Cross-Model Transfer Architecture

## Objective
Implement comprehensive, robust cross-document transfer logic for **CAD Mode** (`IsCadDetailsManagerActive`) in `TransferPlus`, handling:
1. Native Drafting Views (`ViewDrafting`).
2. Model Detail Views & Callouts (`ViewSection` of `ViewType.Detail`).
3. CAD Import and Link Instances (`ImportInstance`).
4. Detail Components (`OST_DetailComponents`).
5. Isolated 2D Annotations (`FilledRegion`, Detail `Group`, detail lines).
6. External CAD files from Local Folders, Azure Storage, AWS S3, and Autodesk Docs.

## User Decisions & Friction Resolution
- **Rule 1 (Option A)**: Dedicated `ViewDrafting` per transferred CAD instance, model detail view, and isolated annotation element.
- **Rule 2 (Option A)**: In "Sort by Sheet", create Drafting Views only for the selected child detail/CAD elements; do **NOT** create or replicate parent `ViewSheet` elements into the target document.
- **Rule 3 (Option A)**: For Detail Components (`OST_DetailComponents`), transfer the pure Family and FamilySymbol definitions into the target document via in-memory `EditFamily -> LoadFamily` without creating visible graphic instances.
- **Harmonization with Existing Logic**:
  - Full alignment with "On Duplicates" card options: `AbortTransaction` (pre-flight check), `KeepOriginal` (skip existing items), and `AppendSuffix` (append suffix and resolve collisions).
  - Explicitly bypass `IncludeSheetsWithViews` when in CAD mode.
  - Seamless integration with PowerRename overrides (`cadCustomNames` and `cadRenameMap`).

## Architecture & Code Changes
1. **`FamilyRevitService.cs`**:
   - `TransferDraftingViews`: Enhanced with `keepOriginal`, `suffix`, and unique view name resolution.
   - `TransferCadInstancesToDraftingViews`: Enhanced with duplicate handling policies.
   - `TransferExternalCadToDraftingView`: Supports duplicate handling policies for external CAD imports/links.
   - `TransferModelDetailViewsToDraftingViews`: Generates dedicated `ViewDrafting` matching source scale and copies 2D annotations via 5-parameter `CopyElements`.
   - `TransferDetailAnnotationsToDraftingViews`: Generates dedicated `ViewDrafting` for individual `FilledRegion`, detail `Group`, and lines.
   - `TransferDetailComponentFamilies`: Extracts unique `Family` instances and transfers definitions into `destDoc` via `TryTransferInMemoryFamily`.
2. **`ICadProvider.cs` and Providers**:
   - Extended `TransferCadItemAsync` signature with `bool keepOriginal = false, string? suffix = null`.
   - Updated `LocalFolderCadProvider`, `AzureStorageCadProvider`, `AwsS3StorageCadProvider`, `AutodeskDocsCadProvider`, `OpenDocumentCadProvider`, and `LinkedDocumentCadProvider`.
3. **`TransferPlusViewModel.cs`**:
   - Added Pre-Flight check for `AbortTransaction` in CAD mode.
   - Segregated checked CAD items into 5 discrete categories (`draftingViewIds`, `cadInstanceIds`, `detailViewIds`, `detailComponentIds`, `otherAnnotationIds`).
   - Wired batch transfers through `_familyRevitService` honoring `cadCustomNames`, `cadRenameMap`, `KeepOriginal`, and `AppendSuffix`.
