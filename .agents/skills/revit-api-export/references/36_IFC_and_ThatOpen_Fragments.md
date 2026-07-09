# Skill Reference: OpenBIM & IFC Generation

## 1. High-Performance IFC Exporter
To integrate Revit models with modern web-based viewers (like ThatOpen Company's web-ifc fragment engines), the exported IFC files must be clean, structured, and contain rich metadata.

### Configuration Protocol:
- **IFC Version**: Set `FileVersion = IFCVersion.IFC4` or higher. IFC4 is optimized for coordinate accuracy and is much faster to parse than legacy IFC2x3.
- **Base Quantities**: Toggle `ExportBaseQuantities = true` to calculate net and gross areas/volumes for downstream cost estimation.
- **Internal Property Sets**: Add the custom setting Option `AddOption = "ExportInternalRevitPropertySets"` to ensure Revit parameters (e.g. Comments, Mark) are written to custom property sets, avoiding metadata loss.

```csharp
IFCExportOptions options = new IFCExportOptions
{
    FileVersion = IFCVersion.IFC4,
    WallAndColumnTracking = true,
    ExportBaseQuantities = true,
    AddOption = "ExportInternalRevitPropertySets"
};
```

## 2. Integration with Web Fragment Engines
ThatOpen fragments convert heavy IFC text files into compact binary geometries (`.frag`) and JSON properties.

### Optimizing Revit Models for Fragments:
1. **Coordinate Origin**: Ensure Project Base Point and Survey Point are synchronized to avoid spatial misalignment in web viewers.
2. **Category Mapping**: Set up standard IFC class overrides in Revit's IFC Export Options mapping table (e.g., mapping custom family templates to `IfcFlowSegment` or `IfcDistributionElement`).
3. **No Unneeded Views**: Only export the physical building 3D model geometry. Exclude analytical elements and temporary massing to reduce the size of the final `.frag` file.
