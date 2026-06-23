namespace {{Namespace}}.Helpers;

/// <summary>
/// Helper exclusivo para la nueva API de Toposolids (Revit 2024+).
/// </summary>
public static class TopoHelper
{
    /// <summary>
    /// Obtiene todos los sÃ³lidos topogrÃ¡ficos del documento.
    /// </summary>
    public static IList<Toposolid> GetToposolids(this Document doc)
    {
        return doc.GetInstances<Toposolid>();
    }
}
