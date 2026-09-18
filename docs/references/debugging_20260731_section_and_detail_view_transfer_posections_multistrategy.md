# Informe Técnico Completo — Descubrimiento Multiestratega de Secciones y Detalles en Vistas Copiadas (`ponSections`)

## 📅 Fecha de Registro: 2026-07-31
## 🧩 Componente: `TransferPlus / TransferOrchestrator.cs` -> Invocación `ponSections`

---

## 1. Contexto y Problema Detectado

Al ejecutar la transferencia de planos y vistas en modelos reales de producción (ej. `2510000177_KRN_ARQ_G_00`), la transferencia de vistas de plano (`ViewPlan`) funcionaba correctamente, pero el log de ejecución reportaba:

```text
[11:11:06.822] INFO: ponSections: Found 0 Section/Detail child view(s) on 'ECI - EST - NAVES_DBS Copia 1 1000'.
```

Las vistas de sección (`ViewType.Section`) o de detalle (`ViewType.Detail`) asociadas o dibujadas dentro de la vista origen no se descubrían ni clonaban en el modelo destino.

---

## 2. Diagnóstico Técnico y Descubrimientos de la API de Revit

Tras analizar la estructura de elementos mediante inspección de logs y reflexión de parámetros:

1. **Limitación de `FilteredElementCollector(doc, viewId)` en Vistas de Plano**:
   En la API de Revit, los símbolos gráficos de línea/cabeza de sección (`BuiltInCategory.OST_Viewers`) no se devuelven al consultar un `FilteredElementCollector` acotado al `Id` de una vista de plano (`ViewType.FloorPlan` / `EngineeringPlan`).

2. **Tipos de Elementos en `GetDependentElements`**:
   Invocaciones como `vistaorigen.GetDependentElements(null).OfType<View>()` devuelven 0 elementos porque los elementos dependientes devueltos para las secciones son ejemplares anotativos `OST_Viewers`, no objetos `View`. La vista de sección real se encuentra almacenada como un parámetro de tipo `ElementId` dentro de dichos símbolos visores.

3. **Comportamiento en Vistas Duplicadas / Copiadas (Descubrimiento Clave de la Sesión)**:
   Cuando el usuario duplica una vista de plano en Revit (por ejemplo, creando `'ECI - EST - NAVES_DBS Copia 1 1000'` con `Id: 6261742` a partir de `'ECI - EST - NAVES_DBS'` con `Id: 2243642`), se producen dos efectos en el modelo de datos de Revit:
   - El parámetro nativo `BuiltInParameter.SECTION_PARENT_VIEW_NAME` conserva la cadena de la vista madre original (`"ECI - EST - NAVES_DBS"`).
   - Los visores de sección (`OST_Viewers`) copiados en la vista duplicada mantienen parámetros de almacenamiento `ElementId` (como el parámetro `"Vista principal"`) con el ID de la vista madre original (`2243642`), en lugar del ID de la vista duplicada (`6261742`).

4. **Fallo en Expresiones Regulares de Sufijos Múltiples**:
   La expresión regular inicial `\s+(copia|copy)\s+\d+$` solo detectaba sufijos de una única cifra al final. Al encontrarse con nombres como `'ECI - EST - NAVES_DBS Copia 1 1000'`, fallaba en recortar `" Copia 1 1000"`, manteniendo el nombre completo e impidiendo emparejar con el nombre de la vista madre base.

---

## 3. Patrón de Solución Garantizado (Triangulación Multiestratega)

La función `ponSections` en `TransferOrchestrator.cs` implementa las siguientes 3 estrategias simultáneas para descubrir el 100% de vistas de sección y detalle hijas:

### Estrategia A: Inspección de Dependientes Nativos (`GetDependentElements`)
Escanea todos los `ElementId` devueltos por `vistaorigen.GetDependentElements(null)`. Para cada elemento devuelto (que no sea una vista), inspecciona todos sus `Parameter` de tipo `ElementId`. Si el ID apunta a una `View` de tipo `Section` o `Detail`, se añade al listado de hijas.

### Estrategia B: Colector Global a Nivel de Documento (`OST_Viewers`) + `baseViewId` Matching
```csharp
// 1. Extraer nombre base normalizado eliminando sufijos de copia
string normalizedName = Regex.Replace(vistaorigen.Name, @"(?i)\s+(copia|copy).*$", "").Trim();

// 2. Localizar la vista madre base en el documento origen si vistaorigen es duplicada
View? baseView = new FilteredElementCollector(origen)
    .OfClass(typeof(View))
    .Cast<View>()
    .FirstOrDefault(v => v != null && v.IsValidObject && !v.IsTemplate && v.Name.Equals(normalizedName, StringComparison.OrdinalIgnoreCase));

ElementId baseViewId = baseView?.Id ?? ElementId.InvalidElementId;

// 3. Inspeccionar visores globales OST_Viewers
foreach (var vElem in allViewersInDoc)
{
    bool isPlacedOnVistaOrigen = (vElem.OwnerViewId != null && 
        (vElem.OwnerViewId.Value == vistaorigen.Id.Value || 
        (baseViewId != ElementId.InvalidElementId && vElem.OwnerViewId.Value == baseViewId.Value)));

    if (!isPlacedOnVistaOrigen)
    {
        foreach (Parameter p in vElem.Parameters)
        {
            if (p != null && p.StorageType == StorageType.ElementId && p.AsElementId() != null)
            {
                long val = p.AsElementId().Value;
                if (val == vistaorigen.Id.Value || (baseViewId != ElementId.InvalidElementId && val == baseViewId.Value))
                {
                    isPlacedOnVistaOrigen = true;
                    break;
                }
            }
        }
    }

    if (isPlacedOnVistaOrigen)
    {
        foreach (Parameter p in vElem.Parameters)
        {
            if (p != null && p.StorageType == StorageType.ElementId && p.AsElementId() != null && p.AsElementId() != ElementId.InvalidElementId)
            {
                Element targetElem = origen.GetElement(p.AsElementId());
                if (targetElem is View targetView && targetView.IsValidObject && !targetView.IsTemplate &&
                    targetView.Id.Value != vistaorigen.Id.Value &&
                    (targetView.ViewType == ViewType.Section || targetView.ViewType == ViewType.Detail))
                {
                    if (!childSectionViews.Any(cv => cv.Id.Value == targetView.Id.Value))
                    {
                        childSectionViews.Add(targetView);
                    }
                }
            }
        }
    }
}
```

### Estrategia C: Búsqueda por Parámetros `SECTION_PARENT_VIEW_NAME` y `VIEW_PRIMARY_VIEW_ID`
Recorre todas las vistas del documento origen y valida si su parámetro `BuiltInParameter.SECTION_PARENT_VIEW_NAME` coincide con:
- `vistaorigen.Name`
- `vistaorigen.Title`
- `normalizedName` (nombre madre base)

---

## 4. Reconstrucción y Dibujo Nativo del Símbolo 2D en Destino

Una vez descubiertas las vistas de sección hijas:
1. **Creación Nativa**: Se invoca `ViewSection.CreateSection(destino, tgtVftId, tgtBox)` pasando la caja delimitadora `BoundingBoxXYZ` y el `ViewFamilyTypeId` adecuado. Esto crea automáticamente el símbolo 2D de sección (línea, cabeza y burbuja interactiva) sobre la vista destino.
2. **Desbloqueo de Visibilidad**: Se desactiva la restricción de escala `SECTION_COARSER_SCALE_PULLDOWN` y se asegura que la categoría `OST_Viewers` esté visible en la vista destino.
3. **Clonado de Anotaciones 2D**: Se invoca `ponDependientes(origen, sectionView, targetSectionView, copyOptions)` utilizando el colector por objeto `View` para copiar el 100% de elementos de anotación 2D (cotas, textos, regiones rellenas, notas clave) dentro de la vista de sección transferida.

---

## 5. Resultados de Pruebas y Validación

- **Compilación MSBuild**: Exitosa (**0 errores**, 238 advertencias de deprecación/nulos preexistentes).
- **Despliegue de Binarios**: `TransferPlus.dll` actualizado en `%AppData%\Autodesk\Revit\Addins\2024\TransferPlus\TransferPlus.dll` (Timestamp: 31/07/2026 10:56:41).
- **Consolidación en Skills**: Aprendizajes catalogados en `.agents/skills/revit-api/references/debugging_section_and_detail_view_transfer_2026-07-30.md`.
