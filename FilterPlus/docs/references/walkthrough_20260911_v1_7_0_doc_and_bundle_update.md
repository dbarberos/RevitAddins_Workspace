# Walkthrough: FilterPlus v1.7.0 Release, Monorepo Versioning, and Autodesk App Store Bundle

## Summary
In accordance with Autodesk App Store review requirements and monorepo versioning best practices, FilterPlus has been bumped to **v1.7.0**. This release standardizes the ribbon placement under the native **Add-Ins (Complementos)** tab, updates all technical and user-facing documentation, archives previous version packages, and introduces scoped Git tagging for independent multi-addin lifecycle tracking.

## 1. Monorepo Versioning & Traceability Architecture
- **Skill Instructions Updated**:
  - `revit-addin-doc-manager`: Added Rule 9 ("Monorepo Versioning & Tag Traceability") establishing that every add-in in the workspace maintains its own version lifecycle. Git tags follow `[AddInName]-v[Major].[Minor].[Patch]` (e.g. `FilterPlus-v1.7.0`, `TransferPlus-v1.1.0`), and changelog extractions are isolated with `git log [last_tag]..HEAD --oneline -- [AddInName]/`.
  - `revit-appstore-bundle`: Added Rule 5 ("Monorepo Versioning & Dynamic Package Resolution") enforcing that `PackageContents.xml` and package zip filenames dynamically reflect the `<Version>` defined in the target add-in's `.csproj`.
  - `build-bundle.ps1`: Upgraded to dynamically extract `<Version>` from `$AppName.csproj` if omitted, and strictly prioritize Release builds over Debug builds during package staging.

## 2. Changes Implemented in FilterPlus

### A. Configuration & Models
- `FilterPlus.csproj`: Bumped `<Version>` to `1.7.0`.
- `FilterPlusSettings.cs`: Removed `[Obsolete]` from `DBDevDefault` to ensure 100% backward compatibility with existing user configuration files in .NET Framework 4.8 `XmlSerializer`.
- `SettingsService.cs`: Implemented transparent auto-migration from `DBDevDefault` to `AddInsDefaultTab` on startup, silent fallback logging (`LogWarning`), and stream decoupling.

### B. User Interface & Ribbon
- `Application.cs`: FilterPlus panel is now created under Revit's native **Add-Ins (Complementos)** tab by default.
- `ConfigurationView.xaml` & `ConfigurationViewModel.cs`: Updated UI options to:
  1. `Place FilterPlus on Add-Ins tab (default)`
  2. `Place on Revit contextual tab`
  3. `Place on tab named: [Custom]`

### C. Documentation & Help
- `docs/references/user_guide.md`: Updated to v1.7.0, updated Section 5.1 Ribbon Panel description, and prepended the complete v1.7.0 changelog.
- `Resources/help.html`: Updated to v1.7.0, synchronized Section 4.1 Ribbon Panel, and prepended the complete v1.7.0 changelog.

## 3. Package Deliverables & Archiving
- Previous version zip packages (`FilterPlus_v1.0.0.zip`, `FilterPlus_v1.6.0.zip`) were moved to `FilterPlus/Deploy/Archive/`.
- Compiled Release binaries for Revit 2023, 2024, 2025, 2026, and 2027.
- Generated new Autodesk App Store production packages:
  - `FilterPlus\Deploy\FilterPlus_v1.7.0.zip` (22.8 MB)
  - `FilterPlus\FilterPlusPublishPackage\FilterPlus.bundle.zip` (22.8 MB)
  - `PackageContents.xml` with `AppVersion="1.7.0"` and individual component entries with `Version="1.7.0"`.
- Deployed local Debug builds with `LogView` window to `%APPDATA%\Autodesk\Revit\Addins\2024\FilterPlus\` and `2023\FilterPlus\`.

## 4. Git Versioning
- Scoped Git Tag: `FilterPlus-v1.7.0`
- Backward-compatibility Git Tag: `v1.7.0`
