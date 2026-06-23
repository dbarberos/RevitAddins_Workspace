namespace {{Namespace}}.Helpers;

/// <summary>
/// PatrÃ³n estÃ¡ndar para mapear Elementos de Revit a DTOs para la UI.
/// Los Ids deben ser siempre 'long' para compatibilidad con Revit 2024+.
/// </summary>
public record ElementDto(long ElementId, string Name, string Category);

public static class ElementMappers
{
    public static ElementDto ToDto(this Element element) =>
        new(
            ElementId: element.Id.Value, // Obligatorio .Value (long) en 2024+
            Name: element.Name,
            Category: element.GetCategoryName()
        );
}
