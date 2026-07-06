public ReferencePlane CrearPlanoParametrico(Document doc, XYZ punto, XYZ vectorNormal, XYZ vectorDireccion, string nombre)
{
    // 1. Crear el plano usando FamilyItemFactory
    ReferencePlane plano = doc.FamilyCreate.NewReferencePlane(punto, vectorDireccion, vectorNormal, doc.ActiveView);
    plano.Name = nombre;
    
    // 2. Configurar si es un origen o si define referencia
    // Importante: No se puede acceder a la propiedad IsReference directamente, 
    // se debe hacer a través de su parámetro interno.
    Parameter paramIsRef = plano.get_Parameter(BuiltInParameter.EXTENT_ELEM_IS_REFERENCE);
    if (paramIsRef != null && !paramIsRef.IsReadOnly)
    {
        paramIsRef.Set(1); // 1 = Strong Reference, 0 = Not a Reference
    }
    
    return plano;
}
