public double CalcularDistanciaAlSuelo(Document doc, View3D vista3D, XYZ puntoOrigen)
{
    // 1. Configurar el Intersector para buscar solo elementos de clase Suelo/Forjado
    ElementClassFilter filtroSuelos = new ElementClassFilter(typeof(Floor));
    
    // Configurar para encontrar el elemento más cercano y que intercepte caras geométricas
    ReferenceIntersector intersector = new ReferenceIntersector(filtroSuelos, FindReferenceTarget.Face, vista3D)
    {
        FindSpatialElementFromBoundingBox = false
    };

    // 2. Disparar el rayo hacia abajo (Vector Z negativo)
    XYZ direccionRayo = new XYZ(0, 0, -1);
    ReferenceWithContext resultado = intersector.FindNearest(puntoOrigen, direccionRayo);

    if (resultado != null)
    {
        // 3. Extraer la distancia exacta en unidades internas (Pies)
        double proximidad = resultado.Proximity;
        return proximidad;
    }

    return double.PositiveInfinity; // No se encontró ningún suelo debajo
}
