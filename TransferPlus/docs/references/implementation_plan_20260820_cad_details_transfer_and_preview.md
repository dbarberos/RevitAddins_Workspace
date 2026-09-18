# Implementation Plan: CAD Details & Drafting Views Transfer with Native Revit Preview

**Date:** August 20, 2026  
**Status:** Completed & Verified  

---

## 1. Architectural Strategy

1. **Decoupled Data Modeling**: Model CAD instances and Drafting views independently of Revit UI via `CadDetailItemModel`.
2. **Provider Separation**:
   - `DraftingViewProvider`: Queries `ViewType.DraftingView` and matches sheet viewports.
   - `CadInstanceProvider`: Queries `ImportInstance` and resolves owner views and link states.
3. **Transaction Resilience**:
   - Wrap view and CAD copying inside silent transactions with `WarningSwallower` and rollback capability.
4. **Native Image Exporting without External Libraries**:
   - Utilize `ImageExportOptions` on the host view to produce lightweight 512px PNG previews.
5. **Cross-Thread UI Safety**:
   - Enforce `BitmapImage.Freeze()` to allow WPF asynchronous consumption without thread access exceptions.

---

## 2. Component Deliverables

- `TransferPlus/Models/CadDetailItemModel.cs`
- `TransferPlus/Services/Providers/DraftingViewProvider.cs`
- `TransferPlus/Services/Providers/CadInstanceProvider.cs`
- `TransferPlus/Services/CadThumbnailService.cs`
- `TransferPlus/Services/FamilyRevitService.cs` (`TransferDraftingViews`, `TransferCadInstancesToDraftingViews`, `GenerateViewPreview`)
- `TransferPlus/ViewModels/TransferPlusViewModel.cs` (Tree construction, sorting, selection sync, thumbnail loaders)
- `TransferPlus/Views/TransferPlusView.xaml` (2-column layout, FilterPlus typography, 200x200 preview box)
