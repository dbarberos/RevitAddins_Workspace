public FamilyInstance GenerarCodoAutomatico(Document doc, Pipe tuboA, Pipe tuboB)
{
    // 1. Encontrar los conectores más cercanos entre ambos tubos (lógica auxiliar de SKILL 20)
    Connector connA = ObtenerConectorMasCercano(tuboA, tuboB.LocationCurve.GetEndPoint(0));
    Connector connB = ObtenerConectorMasCercano(tuboB, tuboA.LocationCurve.GetEndPoint(1));

    if (connA != null && connB != null)
    {
        // 2. Delegar la creación geométrica al motor nativo MEP
        FamilyInstance codo = doc.Create.NewElbowFitting(connA, connB);
        return codo;
    }
    
    return null;
}
