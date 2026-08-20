# Debugging Log: CS0103 'ZoomFitToPage' does not exist in Revit API ImageExportOptions

**Date:** 2026-08-20  
**Context:** Compiling C# Revit Add-in exporting view images via `ImageExportOptions`.  

### Symptom
Compilation error:
```text
error CS0103: El nombre 'ZoomFitToPage' no existe en el contexto actual
```

### Root Cause
In Autodesk Revit DB API, the enum controlling zoom behavior on `ImageExportOptions.ZoomType` is `ZoomFitType` with values `ZoomFitType.FitToPage` and `ZoomFitType.Zoom`, not `ZoomFitToPage`.

### Resolution
Replace `options.ZoomType = ZoomFitToPage.FitToPage` with:
```csharp
var options = new ImageExportOptions
{
    ExportRange = ExportRange.SetOfViews,
    ZoomType = ZoomFitType.FitToPage,
    PixelSize = 512,
    ImageResolution = ImageResolution.DPI_72,
    ShadowViewsFileType = ImageFileType.PNG,
    HLRandWFViewsFileType = ImageFileType.PNG,
    FilePath = baseFilePath,
    FitDirection = FitDirectionType.Horizontal
};
options.SetViewsAndSheets(new List<ElementId> { viewId });
doc.ExportImage(options);
```
