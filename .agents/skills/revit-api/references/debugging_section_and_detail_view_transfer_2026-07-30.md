# Debugging & Lessons Learned: Section & Detail View Discovery in Copied Parent Views

## Fecha: 2026-07-31
## Componente: `TransferOrchestrator.cs` (`ponSections`)

### Síntoma
El complemento reportaba `ponSections: Found 0 Section/Detail child view(s)` al intentar transferir una vista de plano que contenía secciones dibujadas o visibles.

### Causa Raíz
1. **Colector Acotado**: `new FilteredElementCollector(doc, viewId)` no devuelve los símbolos 3D anotativos `OST_Viewers` (líneas/cabezas de sección) para vistas de plano (`ViewType.EngineeringPlan` / `FloorPlan`).
2. **`OfType<View>()` sobre `GetDependentElements`**: `GetDependentElements(null)` devuelve los IDs de visores `OST_Viewers`, no objetos `View`.
3. **Nombres de Vistas Copiadas**: Si la vista origen es una copia (`... Copia 1 1000`), el parámetro nativo `SECTION_PARENT_VIEW_NAME` conserva el nombre de la vista madre original (`ECI - EST - NAVES_DBS`).

### Patrón de Solución Garantizado (C#)

```csharp
// 1. Colector global a nivel de documento para visores
var allViewersInDoc = new FilteredElementCollector(origen)
    .WhereElementIsNotElementType()
    .Where(e => e != null && e.IsValidObject && e.Category != null &&
        (e.Category.Id.Value == (long)BuiltInCategory.OST_Viewers ||
         e.Category.Id.Value == (long)BuiltInCategory.OST_CalloutBoundary ||
         e.Category.Id.Value == (long)BuiltInCategory.OST_ReferenceViewer))
    .ToList();

// 2. Escaneo de ElementId params en elementos de GetDependentElements(null)
List<ElementId> depIds = vistaorigen.GetDependentElements(null)?.ToList() ?? new List<ElementId>();
List<Element> depElements = depIds.Select(id => origen.GetElement(id)).Where(e => e != null && e.IsValidObject).ToList();

foreach (var depElem in depElements.Where(e => e is not View))
{
    foreach (Parameter p in depElem.Parameters)
    {
        if (p != null && p.StorageType == StorageType.ElementId && p.AsElementId() != ElementId.InvalidElementId)
        {
            Element targetElem = origen.GetElement(p.AsElementId());
            if (targetElem is View targetView && (targetView.ViewType == ViewType.Section || targetView.ViewType == ViewType.Detail))
            {
                // Vista de sección hija identificada con éxito
            }
        }
    }
}

// 3. Normalización de nombre para emparejamiento con SECTION_PARENT_VIEW_NAME y baseViewId
string normalizedName = Regex.Replace(vistaorigen.Name, @"(?i)\s+(copia|copy).*$", "").Trim();

View? baseView = new FilteredElementCollector(origen).OfClass(typeof(View)).Cast<View>()
    .FirstOrDefault(v => v != null && v.IsValidObject && !v.IsTemplate && v.Name.Equals(normalizedName, StringComparison.OrdinalIgnoreCase));
ElementId baseViewId = baseView?.Id ?? ElementId.InvalidElementId;

// Los visores OST_Viewers pueden vincular a vistaorigen.Id o a baseViewId
```
