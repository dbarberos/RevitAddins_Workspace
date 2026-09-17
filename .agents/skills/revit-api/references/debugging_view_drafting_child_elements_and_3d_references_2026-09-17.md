# Debugging Log: Copia de Elementos 2D en Vistas de Diseño y Vistas de Detalle con Referencias 3D (CAD Mode)

**Fecha:** 2026-09-17  
**Componente:** `TransferPlus` (`FamilyRevitService.cs`, `TransferPlusViewModel.cs`)  
**Contexto:** Copia entre documentos de Vistas de Diseño (`ViewDrafting`) y Vistas de Detalle de Modelo (`ViewSection` con `ViewType.Detail`) hacia Vistas de Diseño en documentos abiertos o vinculados.

---

## 1. Problema Identificado

1. **Vistas de Diseño en blanco:** Al seleccionar "Drafting Views" en CAD Mode, `ElementTransformUtils.CopyElements(sourceDoc, viewIds, targetDoc, ...)` creaba con éxito la entidad `ViewDrafting` en el documento destino, pero **no copiaba ninguno de los elementos dependientes de vista (`ViewSpecific`) en su interior** (líneas, textos, cotas, tramas, componentes de detalle). Las vistas destino quedaban completamente vacías.
2. **Fallo en lote al transferir Vistas de Detalle:** Al transferir vistas de detalle de modelo hacia vistas de diseño 2D, si una sola cota o etiqueta dependía de geometría 3D inexistente en la vista de diseño 2D, la copia en lote (`CopyElements`) fallaba en su totalidad arrojando `ArgumentException` o `InvalidOperationException`, y ningún elemento (ni líneas ni textos independientes) se transfería.

---

## 2. Causa Raíz

1. En la API de Revit, copiar una vista con `ElementTransformUtils.CopyElements(Document sourceDoc, ICollection<ElementId> elementsToCopy, Document targetDoc, ...)` únicamente clona la cabecera/propiedades de la vista. Para transferir los elementos 2D que contiene, es indispensable llamar a la sobrecarga view-to-view:
   `ElementTransformUtils.CopyElements(View sourceView, ICollection<ElementId> elementsToCopy, View destinationView, Transform transform, CopyPasteOptions options)`.
2. Al transformar vistas de modelo a vistas de diseño 2D, las cotas y etiquetas que acotan geometría 3D no pueden existir sin sus anfitriones 3D. Un intento en bloque falla para todos los elementos del lote.

---

## 3. Solución Implementada

### A. Regeneración del documento y filtrado estricto
Se requiere invocar `targetDoc.Regenerate()` tras crear la vista de destino antes de intentar pegar elementos. Se deben excluir explícitamente elementos del sistema como `ViewCrop`, `ExtentElem`, `Viewport`, `Level` y `SketchPlane`.

### B. Estrategia Multinivel (Batch Copy + Fallback Elemento a Elemento)
```csharp
var childElements = new FilteredElementCollector(sourceDoc, srcView.Id)
    .WhereElementIsNotElementType()
    .Where(e => e.ViewSpecific && e is not Viewport && e is not Level && e is not SketchPlane)
    .Where(e => !e.Name.StartsWith("ViewCrop", StringComparison.OrdinalIgnoreCase) &&
                !e.Name.StartsWith("extentElem", StringComparison.OrdinalIgnoreCase) &&
                !e.GetType().Name.Equals("ViewCrop", StringComparison.OrdinalIgnoreCase) &&
                !e.GetType().Name.Equals("ExtentElem", StringComparison.OrdinalIgnoreCase))
    .Select(e => e.Id)
    .ToList();

if (childElements.Any())
{
    try
    {
        // Nivel 1: Intento en bloque de alta velocidad
        ElementTransformUtils.CopyElements(srcView, childElements, targetElem, Transform.Identity, copyOptions);
    }
    catch (Exception exBatch)
    {
        TelemetryLogger.LogWarning($"Copia en bloque falló: {exBatch.Message}. Ejecutando fallback elemento a elemento...");
        // Nivel 2: Fallback elemento a elemento (aísla cotas/etiquetas dependientes de 3D)
        foreach (var cid in childElements)
        {
            try
            {
                ElementTransformUtils.CopyElements(srcView, new List<ElementId> { cid }, targetElem, Transform.Identity, copyOptions);
            }
            catch (Exception exSingle)
            {
                skippedAny = true;
                TelemetryLogger.LogWarning($"Elemento {cid.GetIdValue()} omitido: {exSingle.Message}");
            }
        }
    }
}
```

### C. Notificación Agrupada en la UI
Para no saturar al usuario con un diálogo por cada vista o elemento omitido, la operación reporta una bandera booleana (`hadSkipped3dReferences`). Si alguna vista requirió omitir cotas o etiquetas por dependencias 3D, se presenta un único `TaskDialog` informativo en inglés al terminar el proceso de todos los modelos destino.
