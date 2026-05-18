namespace {{Namespace}}.Helpers;

/// <summary>
/// Extensiones para lectura segura de parÃ¡metros de Element.
/// </summary>
public static class ElementExtensions
{
    /// <summary>
    /// Obtiene el valor de un parÃ¡metro como string, con fallback si no existe.
    /// </summary>
    public static string GetParamValue(this Element element, BuiltInParameter param, string fallback = "")
    {
        var p = element.get_Parameter(param);
        if (p == null || !p.HasValue) return fallback;

        return p.StorageType switch
        {
            StorageType.String  => p.AsString() ?? fallback,
            StorageType.Integer => p.AsInteger().ToString(),
            StorageType.Double  => p.AsDouble().ToString("F4"),
            // IMPORTANTE 2024+: .Value devuelve un long
            StorageType.ElementId => p.AsElementId().Value.ToString(), 
            _ => fallback
        };
    }

    /// <summary>
    /// Obtiene el nombre de categorÃ­a de un elemento de forma segura.
    /// </summary>
    public static string GetCategoryName(this Element element)
        => element.Category?.Name ?? "(Sin CategorÃ­a)";

    /// <summary>
    /// Obtiene el nombre de familia y tipo combinados.
    /// </summary>
    public static string GetFamilyAndTypeName(this Element element)
    {
        var typeId = element.GetTypeId();
        if (typeId == ElementId.InvalidElementId) return "(Sin Tipo)";

        var type = element.Document.GetElement(typeId) as ElementType;
        string familyName = type?.FamilyName ?? "";
        string typeName = type?.Name ?? "";

        return string.IsNullOrEmpty(familyName) ? typeName : $"{familyName} : {typeName}";
    }
}
