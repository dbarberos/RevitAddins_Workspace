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

## 📚 Technical References
- `references/debugging_appstore_bundle_missing_dependencies_and_identity_collision_2026-08-17.md`: Root cause analysis and resolution for AppStore bundle loading failures.

## 🛠️ Scripts & Automation
```powershell
.\.agents\skills\revit-appstore-bundle\scripts\build-bundle.ps1 -AppName "FilterPlus" -Version "1.6.0" -ProjectDir ".\FilterPlus"
```
