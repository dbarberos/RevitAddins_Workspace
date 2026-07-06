// Esta clase NO tiene using Autodesk.Revit.DB;
public class CalculadoraCostos
{
    public double CalcularCostoTotal(IEnumerable<IMuroData> murosDatos)
    {
        double costoTotal = 0;
        foreach(var muro in murosDatos)
        {
            costoTotal += muro.ObtenerAreaMetrica() * 15.5; // Lógica pura
        }
        return costoTotal;
    }
}
