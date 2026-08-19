# Debugging: AppStore Bundle Runtime Failure & Identity Collisions (2026-08-17)

## 1. Incident Summary

During the Autodesk App Store automated and manual validation of the submitted installer (`DBDevFilterPlus.msi` / `.bundle`), the application failed to launch across all supported Revit versions (2023–2027), throwing:

```text
External Tools - External Tool Failure
Revit cannot run the external application "FilterPlus". Contact the provider for assistance.
Information they provided to Revit about their identity: AI Solutions.

System.IO.FileNotFoundException
Could not load file or assembly 'Nice3point.Revit.Toolkit, Version=2027.0.0.0, Culture=neutral, PublicKeyToken=null'.
The system cannot find the file specified.
```

---

## 2. Root Cause Analysis

Investigation of the packaged `.bundle` and `.msi` identified three separate root causes:

### A. Missing Third-Party & SDK Runtime Dependencies
When constructing the multi-version directory structure (`Contents/2023/`, `Contents/2024/`, `Contents/2025/`, `Contents/2026/`, `Contents/2027/`), only the primary entry assembly (`FilterPlus.dll`) was copied.
Revit's CLR runtime does not resolve referenced dependencies across parent directories. Because `Nice3point.Revit.Toolkit.dll`, `Nice3point.Revit.Extensions.dll`, `CommunityToolkit.Mvvm.dll`, and `System.Text.Json.dll` were missing from the version folder, the add-in crashed immediately upon executing `ExternalApplication.OnStartup()`.

### B. Legacy Identity Metadata in Manifests (`FilterPlus.addin`)
The `.addin` manifests placed inside `Contents/202X/` still contained legacy placeholder tags:
```xml
<VendorId>AI_CORP</VendorId>
<VendorDescription>AI Solutions</VendorDescription>
<VendorEmail>support@filterplus.ai</VendorEmail>
```
When Revit encounters a fatal load error, it extracts `VendorDescription` directly from the `.addin` manifest to display in the user warning dialog. This exposed outdated corporate identity attributes inconsistent with the publisher profile (`DBDev Solutions` / `DBDev_dbarberos`).

### C. Malformed XML Version Declaration in `PackageContents.xml`
The bundle manifest `PackageContents.xml` used `<?xml version="1.6.0" encoding="utf-8" ?>`. Under the W3C XML specification, the `version` attribute strictly permits `"1.0"` or `"1.1"`. Setting the add-in semantic version in the XML declaration header causes strict XML parsers to reject the package manifest.

---

## 3. Resolution & Permanent Standard

1. **Full Dependency Bundling**:
   Every version folder (`Contents/202X/`) MUST contain the entire output of the publish directory (`bin/Release.R2X/publish/[AppName]/*`), including:
   - `[AppName].dll`
   - `Nice3point.Revit.Toolkit.dll`
   - `Nice3point.Revit.Extensions.dll`
   - `CommunityToolkit.Mvvm.dll`
   - All runtime satellite packages (`System.Text.Json.dll`, `Microsoft.Bcl.AsyncInterfaces.dll`, `System.Buffers.dll`, etc.).

2. **Standardized Identity Enforcement**:
   Every `.addin` file across all version folders must enforce:
   - `<Assembly>[AppName].dll</Assembly>` (direct relative path within the version folder).
   - `<VendorId>DBDev_dbarberos</VendorId>`
   - `<VendorDescription>DBDev Solutions</VendorDescription>`
   - `<VendorEmail>dbarberos@outlook.com</VendorEmail>`
   - `<ContextName>[AppName]</ContextName>`

3. **Compliant XML Declaration**:
   `PackageContents.xml` must start with `<?xml version="1.0" encoding="utf-8" ?>`. The software release version belongs exclusively inside `<ApplicationPackage AppVersion="1.6.0" ...>`.

4. **Automated Packaging via `build-bundle.ps1`**:
   The deployment script has been updated to automatically verify all dependency DLLs and enforce publisher identity sanitization.
