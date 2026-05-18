namespace {{Namespace}}.Helpers;

/// <summary>
/// Extensiones de conveniencia para Autodesk.Revit.DB.Document
/// </summary>
public static class DocumentExtensions
{
    /// <summary>
    /// Obtiene todos los elementos de un tipo especÃ­fico, excluyendo tipos de elemento.
    /// </summary>
    public static IList<T> GetInstances<T>(this Document doc) where T : Element
    {
        return new FilteredElementCollector(doc)
            .OfClass(typeof(T))
            .WhereElementIsNotElementType()
            .Cast<T>()
            .ToList();
    }

    /// <summary>
    /// Obtiene todos los elementos de una categorÃ­a especÃ­fica en la vista activa.
    /// </summary>
    public static IList<Element> GetElementsInView(this Document doc, BuiltInCategory category, ElementId viewId)
    {
        return new FilteredElementCollector(doc, viewId)
            .OfCategory(category)
            .WhereElementIsNotElementType()
            .ToElements();
    }

    /// <summary>
    /// Ejecuta una acciÃ³n dentro de una transacciÃ³n de forma segura.
    /// Devuelve true si la transacciÃ³n se completÃ³ con Ã©xito.
    /// </summary>
    public static bool RunInTransaction(this Document doc, string name, Action<Transaction> action)
    {
        using var tx = new Transaction(doc, name);
        try
        {
            tx.Start();
            action(tx);
            tx.Commit();
            return true;
        }
        catch (Exception ex)
        {
            if (tx.HasStarted() && !tx.HasEnded())
                tx.RollBack();
            System.Diagnostics.Debug.WriteLine($"[Transaction Error] {name}: {ex.Message}");
            return false;
        }
    }
}
