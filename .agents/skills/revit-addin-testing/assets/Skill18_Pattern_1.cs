// FATAL PARA TESTING: La lógica de cálculo está mezclada con la extracción de datos de Revit.
public double CalcularCostoTotal(Document doc, IList<Element> muros)
{
    double costoTotal = 0;
    foreach(var muro in muros)
    {
        // Imposible de probar sin Revit abierto
        Parameter pArea = muro.get_Parameter(BuiltInParameter.HOST_AREA_COMPUTED); 
        costoTotal += pArea.AsDouble() * 15.5;
    }
    return costoTotal;
}
