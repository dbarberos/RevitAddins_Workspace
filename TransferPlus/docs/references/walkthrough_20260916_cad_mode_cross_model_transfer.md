# Walkthrough: CAD Mode Cross-Model Transfer Architecture & Duplicate Handling

## Summary of Changes

We implemented and validated the complete cross-model transfer logic for **CAD Mode** (`IsCadDetailsManagerActive`) in `TransferPlus`. This handles both internal model elements (drafting views, model detail views, CAD imports/links, detail components, and annotations) and external CAD files from cloud and local providers.

---

## Key Achievements

### 1. Discrete 5-Category Item Segregation
Elements selected in CAD mode are categorized cleanly into 5 buckets:
- **`draftingViewIds`**: Native `ViewDrafting` copied directly across models.
- **`detailViewIds`**: Model detail views (`ViewSection`, `ViewType.Detail`) converted into dedicated `ViewDrafting` in the target document, matching source scale and copying all 2D annotations (detail lines, text, dimensions, filled regions, tags).
- **`cadInstanceIds`**: CAD `ImportInstance` elements placed into dedicated individual `ViewDrafting` views in the target model.
- **`detailComponentIds`**: 2D Detail Components (`OST_DetailComponents`) whose Family and Type definitions are loaded via in-memory `EditFamily -> LoadFamily` without creating visible graphic instances.
- **`otherAnnotationIds`**: Isolated 2D annotations (`FilledRegion`, `Group` of detail type) placed into dedicated individual `ViewDrafting` views using their owner view context.

### 2. Architectural Decisions Enforced
- **Rule 1 (Option A)**: Dedicated `ViewDrafting` created per transferred CAD instance, model detail view, and isolated annotation.
- **Rule 2 (Option A)**: In "Sort by Sheet", only child CAD and detail elements are transferred into Drafting Views; parent `ViewSheet` replication is bypassed in CAD mode.
- **Rule 3 (Option A)**: Detail Component families are transferred into the target document's database in memory without creating placeholder instances in views.

### 3. "On Duplicates" Policy Integration
- **`AbortTransaction`**: Pre-flight validation checks whether any target view name or family name already exists in any selected destination document. If a conflict exists, the entire transfer is aborted before starting transactions, showing an informative `TaskDialog`.
- **`KeepOriginal`**: Skips existing views or families without aborting the batch.
- **`AppendSuffix`**: Dynamically appends the configured suffix (e.g. `_Copy`) and handles subsequent collisions iteratively (`_Copy_1`, `_Copy_2`, etc.).

### 4. Multi-Provider Support
Updated `ICadProvider` and all implementations (`LocalFolderCadProvider`, `AzureStorageCadProvider`, `AwsS3StorageCadProvider`, `AutodeskDocsCadProvider`, `OpenDocumentCadProvider`, `LinkedDocumentCadProvider`) to support `keepOriginal` and `suffix` parameters.

---

## Verification Results

### Build Verification
- **`Debug.R24`**: Build succeeded with 0 errors (`DeployAddin=true` deployed to Revit 2024 add-in folder).
- **`Release.R24`**: Build succeeded with 0 errors.
- **`Release.R25`**: Build succeeded with 0 errors (.NET 8).
- **`Release.R26`**: Build succeeded with 0 errors (.NET 8).
- **`Release.R27`**: Build succeeded with 0 errors (.NET 8).

### Knowledge Consolidation (SkillOpt)
- Extracted reusable code asset: `csharp-blueprints/assets/CadCrossModelTransferHelper.cs`.
- Authored technical reference guide: `csharp-blueprints/references/guide_cad_mode_cross_model_transfer_architecture_2026-09-16.md`.
- Updated index: `csharp-blueprints/SKILL.md`.
