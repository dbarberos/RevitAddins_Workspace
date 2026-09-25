---
name: revit-appstore-bundle
description: Generates the Autodesk App Store .bundle folder structure and PackageContents.xml for Revit addins. Use when preparing a plugin for the Autodesk App Store marketplace.
---

# Revit AppStore Bundle

Automates packaging multi-version Revit add-ins (2023–2027) into standardized Autodesk App Store `.bundle` packages and `.zip` archives.

## 🚨 Mandatory Bundle Rules
1. **Full Dependency Bundling**: Every version folder (`Contents/202X/`) must contain the primary assembly (`[AppName].dll`) alongside all required dependencies (`Nice3point.Revit.Toolkit.dll`, `Nice3point.Revit.Extensions.dll`, `CommunityToolkit.Mvvm.dll`, `System.*.dll`). Never leave isolated single DLLs.
2. **Identity Sanitization**: Every `.addin` manifest must strictly declare:
   - `<VendorId>DBDev_dbarberos</VendorId>`
   - `<VendorDescription>DBDev Solutions</VendorDescription>`
   - `<VendorEmail>dbarberos@outlook.com</VendorEmail>`
   - `<Assembly>[AppName].dll</Assembly>`
   Never allow placeholder identities (e.g. `AI_CORP` / `AI Solutions`).
3. **Valid XML Declaration**: `PackageContents.xml` must strictly start with `<?xml version="1.0" encoding="utf-8"?>`.
4. **Contextual Help**: Associated `help.html` and icons must be present inside `Contents/Resources/`.
5. **Monorepo Versioning & Dynamic Package Resolution**: In multi-project workspaces, the version declared in `PackageContents.xml` (`AppVersion`) and in the output archive (`[AppName]_v[Version].zip`) MUST strictly match the target add-in's `<Version>` tag from its `.csproj` (e.g., `FilterPlus.csproj`).
6. **Autoloader Series Prefix ("R")**: In `PackageContents.xml`, `SeriesMin` and `SeriesMax` MUST strictly include the `"R"` prefix (`R2023`, `R2024`, `R2025`, `R2026`, `R2027`). Omitting the `"R"` causes Revit's Autoloader to silently reject the bundle across all versions.
7. **Native Add-Ins Tab Ribbon Placement**: By Autodesk App Store review mandate, single-command or standard add-ins must place their ribbon panel on Revit's native **Add-Ins (Complementos)** tab (`Application.CreatePanel("[AppName]")`). Never create custom ribbon tabs by default; custom tabs are only allowed as optional secondary user settings.
8. **Forced Clean Multi-Version Compilation (`-Rebuild`)**: When building App Store bundles, `build-bundle.ps1` must clean previous `bin/Release.R*` folders and force fresh compilation with `/p:DeployAddin=false` for all target versions to prevent shipping stale binaries.

## 📚 Technical References
- `references/debugging_appstore_bundle_missing_dependencies_and_identity_collision_2026-08-17.md`: Root cause analysis and resolution for AppStore bundle loading failures.
- `references/debugging_appstore_bundle_autoloader_series_prefix_and_multiversion_2026-09-21.md`: Autoloader series prefix omission, multi-version ElementId compatibility (2023 vs 2024+), and assembly resolution.
- `references/debugging_appstore_bundle_custom_tab_rejection_and_stale_binaries_2026-09-24.md`: Root cause analysis for custom tab rejection (DBDev) and stale binary packaging prevention.

## 🛠️ Scripts & Automation
```powershell
.\.agents\skills\revit-appstore-bundle\scripts\build-bundle.ps1 -AppName "FilterPlus" -ProjectDir ".\FilterPlus" -Rebuild
```
