# Debugging Report: Prevention of Host Project (.rvt) Building Cover Image as Family Thumbnail Preview

**Date:** 2026-08-13  
**Domain:** WPF UI / Family Preview Thumbnail Extraction (`FamilyThumbnailService.cs`)  
**Context:** Autodesk Revit Add-in (`TransferPlus`) - Family Details Card Thumbnail Generation  

---

## 1. Symptom & Bug Description
When inspecting families or symbols inside the "Family Details" card in Family Mode:
- Standalone `.rfa` family files rendered 3D family thumbnails correctly.
- Native families loaded in an active Revit project document (`.rvt`) that lacked pre-rendered 3D preview bitmaps in memory (e.g. 2D detail components, annotations, or unrendered 3D families) displayed the **building cover image of the entire host Revit project (`.rvt`)** inside the 128x128 thumbnail container instead of a 2D symbol icon or family preview.

---

## 2. Root Cause Analysis
In `FamilyThumbnailService.cs`, the fallback path resolution function `ResolveDiskPath(FamilyItemModel family)` contained:

```csharp
private static string? ResolveDiskPath(FamilyItemModel family)
{
    if (!string.IsNullOrEmpty(family.ImagePreviewUrl) && File.Exists(family.ImagePreviewUrl))
        return family.ImagePreviewUrl;
    if (!string.IsNullOrEmpty(family.SourceName) && File.Exists(family.SourceName))
        return family.SourceName;
    if (family.NativeFamily is Family fam && fam.Document?.PathName is string docPath && File.Exists(docPath))
        return docPath; // <-- ROOT CAUSE: Returns host project .rvt path
    return null;
}
```

1. When `ExtractNativeFamilyThumbnail` failed or returned `null` for a native family inside a host project, Strategy B1/B2 (`ExtractShellThumbnail`) was invoked.
2. `ResolveDiskPath` returned `fam.Document.PathName`, which points to `Project.rvt` (the host Revit project file on disk).
3. Windows Shell (`IShellItemImageFactory`) extracted the 256px cover thumbnail of `Project.rvt`—which is the 3D building view of the host project.
4. Consequently, the family details card displayed the host building cover image instead of a 2D reference symbol or family thumbnail.

---

## 3. Technical Resolution

Strictly enforce file extension validation (`.rfa`) in `ResolveDiskPath` and eliminate `fam.Document.PathName` (`.rvt`) from thumbnail disk resolution:

```csharp
/// <summary>
/// Resolves the on-disk file path for Shell thumbnail extraction.
/// STRICT: Only returns paths ending with .rfa to prevent host project (.rvt) files
/// from displaying the host building model as a family thumbnail preview.
/// </summary>
private static string? ResolveDiskPath(FamilyItemModel family)
{
    if (!string.IsNullOrEmpty(family.ImagePreviewUrl) 
        && File.Exists(family.ImagePreviewUrl) 
        && family.ImagePreviewUrl.EndsWith(".rfa", StringComparison.OrdinalIgnoreCase))
    {
        return family.ImagePreviewUrl;
    }

    if (!string.IsNullOrEmpty(family.SourceName) 
        && File.Exists(family.SourceName) 
        && family.SourceName.EndsWith(".rfa", StringComparison.OrdinalIgnoreCase))
    {
        return family.SourceName;
    }

    return null;
}
```

### Fallback Execution Chain:
1. **Strategy A**: `ExtractNativeFamilyThumbnail` (Attempts native `elementType.GetPreviewImage(256, 256)`).
2. **Strategy B**: `ExtractRfaFileThumbnail` & `ExtractShellThumbnail` (Only executed if `ResolveDiskPath` returns a verified `.rfa` path).
3. **Strategy C**: `CreateFallback2DReferenceIcon` (Executes for native families or 2D elements without 3D bitmaps, rendering a vector 2D symbol icon with category label).

---

## 4. Key Takeaway & Rule
- **Rule**: `ShellThumbnail` extraction MUST NEVER accept `.rvt` project file paths when resolving family element previews. Always validate `path.EndsWith(".rfa", StringComparison.OrdinalIgnoreCase)` before invoking Windows Shell thumbnail factories.
