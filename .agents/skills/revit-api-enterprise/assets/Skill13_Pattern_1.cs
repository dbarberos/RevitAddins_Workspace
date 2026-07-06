public void ExportarPlanosADwg(Document doc, string carpetaDestino, ICollection<ElementId> vistasIds)
{
    // 1. Instanciar opciones de exportación estrictas
    DWGExportOptions dwgOptions = new DWGExportOptions
    {
        MergedViews = true, // Vincular referencias externas (XREFs) en un solo archivo
        ExportOfSolids = SolidGeometryObjectExport.Polymesh,
        TargetUnit = ExportUnit.Meter
    };

    // 2. Ejecutar exportación
    // El método Export acepta un sufijo, que se añadirá al nombre de la vista/plano
    bool exito = doc.Export(carpetaDestino, "Replanteo_BIM", vistasIds, dwgOptions);
    
    if (!exito) throw new InvalidOperationException("Fallo en el motor de exportación DWG.");
}
