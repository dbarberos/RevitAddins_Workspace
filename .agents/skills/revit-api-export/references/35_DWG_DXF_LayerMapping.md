# Skill Reference: CAD Export & Layer Setup

## 1. Mapped DWG Export Configurations
When generating DWG/DXF files for commercial deliverables, hardcoding default settings is forbidden. BIM standards (e.g. AIA, BS 1192, ISO 13567) mandate specific layer assignments, colors, and line patterns for every Revit category.

To enforce layer standards:
1. Retrieve a named `ExportDWGSettings` element from the document's database.
2. Extract the associated `DWGExportOptions` using `.GetDWGExportOptions()`.
3. Force visual fidelity overrides (like combining XREFs into a single master sheet).

### Code Blueprint: Standard Settings Query
```csharp
ExportDWGSettings dwgSettings = new FilteredElementCollector(doc)
    .OfClass(typeof(ExportDWGSettings))
    .Cast<ExportDWGSettings>()
    .FirstOrDefault(s => s.Name.Equals("ISO_13567_Standard", StringComparison.InvariantCultureIgnoreCase));

DWGExportOptions options = dwgSettings != null 
    ? dwgSettings.GetDWGExportOptions() 
    : new DWGExportOptions(); // Fallback if settings are missing
```

## 2. Advanced Layer Customization
If your Add-in needs to customize layer mappings programmatically:
- Query the `ExportLayerTable` from the document.
- Iterate over Revit categories and define layer names/color integers.
- Pass the custom table back to the export options.

> [!WARNING]
> **Transaction Management**: Querying `ExportDWGSettings` is read-only, but modifying mappings on a saved configuration modifies the document. Wrap mapping changes in a `Transaction` and call `doc.Regenerate()` before dispatching the export operation.
