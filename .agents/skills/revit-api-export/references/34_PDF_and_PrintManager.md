# Skill Reference: PDF & Printing Automation

## 1. Native PDF Export (Revit 2022+)
Starting with Revit 2022, the API provides native, high-speed PDF export capability via `Document.Export(exportFolder, viewIds, PDFExportOptions)`. This eliminates the need to configure and wait for virtual PDF printer drivers.

### Key Programmatic Configurations:
- **Vector Fidelity**: Set `RasterQuality = RasterQualityType.High` and `AlwaysUseRaster = false` to guarantee sharp vector lines for CAD/PDF deliverables.
- **Combined Deliverable**: Toggle `Combine = true` to merge all selected sheet views into a single multi-page PDF document, or `false` to generate individual files named according to Revit's Sheet Number standards.
- **Visual Regeneration**: Always run `doc.Regenerate()` prior to invoking the exporter to avoid blank sheets or outdated parameters on the print layouts.

## 2. Legacy PDF Fallback (Revit 2021 and older)
For legacy Revit environments, native PDF export is unavailable. The agent must fallback to using the `PrintManager` database interface mapped to a virtual PDF printer driver (e.g., `"Microsoft Print to PDF"` or `"PDFCreator"`).

### Code Blueprint: Fallback Printing
```csharp
public static void ExportPdfLegacy(Document doc, ICollection<ElementId> viewIds, string printerName, string outputFilePath)
{
    PrintManager pm = doc.PrintManager;
    pm.SelectActivePrinter(printerName);
    pm.PrintRange = PrintRange.Select;
    
    // Configure Print Setting (Sheet size, Zoom, Vector)
    PrintSetting setting = new FilteredElementCollector(doc)
        .OfClass(typeof(PrintSetting))
        .Cast<PrintSetting>()
        .FirstOrDefault(); // Map appropriate setting
        
    pm.PrintSetup.CurrentPrintSetting = setting;
    pm.PrintToFile = true;
    pm.PrintToFileName = outputFilePath;
    
    // Create view set
    ViewSet viewSet = new ViewSet();
    foreach (ElementId id in viewIds)
    {
        View view = doc.GetElement(id) as View;
        if (view != null) viewSet.Insert(view);
    }
    
    ViewSheetSetting vss = pm.ViewSheetSetting;
    vss.CurrentViewSheetSet.Views = viewSet;
    vss.SaveAs("TempPrintSet");
    
    pm.SubmitPrint();
}
```
