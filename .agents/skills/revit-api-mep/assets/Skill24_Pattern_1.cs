using Autodesk.Revit.DB.Fabrication;

public void ConvertirRedAFabricacion(Document doc, ISet<ElementId> idsDiseno)
{
    // 1. Obtener la configuración de fabricación cargada en el documento
    FabricationConfiguration config = FabricationConfiguration.GetFabricationConfiguration(doc);
    if (config == null) throw new InvalidOperationException("No hay base de datos de fabricación cargada.");

    // 2. Definir el Servicio (ej. 'Chilled Water - Copper')
    // El ID del servicio debe buscarse previamente en config.GetAllLoadedServices()
    int serviceId = ObtenerIdServicio(config, "CHW_Copper"); 

    using (Transaction t = new Transaction(doc, "Convertir a LOD 400"))
    {
        t.Start();

        // 3. Instanciar el conversor
        DesignToFabricationConverter conversor = new DesignToFabricationConverter(doc);
        
        // 4. Ejecutar la conversión
        // Devuelve un enumerador con los resultados. Si falla por falta de piezas
        // en la base de datos (ej. falta una T de ese diámetro), devuelve PartialFailure.
        DesignToFabricationConverterResult resultado = conversor.Convert(idsDiseno, serviceId);

        if (resultado == DesignToFabricationConverterResult.Success)
        {
            // Opcional: Borrar los elementos de diseño originales (Pipe/Duct) si la conversión fue total
            // doc.Delete(idsDiseno);
        }
        
        t.Commit();
    }
}
