# Plan de Acción: Copia Completa de Contenido en Vistas de Diseño y Vistas de Detalle (CAD Mode)

## 1. Diagnóstico y Causa Raíz del Problema

El usuario reporta que al transferir elementos en **CAD Mode**:
1. Con la opción **"Drafting Views"** (Vistas de Diseño), la transferencia indica éxito y las vistas se crean en el modelo destino, pero su contenido interno (líneas de detalle, textos, cotas, regiones, componentes de detalle) **no se copia**, quedando las vistas completamente vacías.
2. Con la opción **"Details View/Details Callouts"** (Vistas de Detalle / Llamadas de Detalle), se debe asegurar igualmente que **todo el contenido 2D interno de las vistas se copie** íntegramente hacia las vistas de diseño de destino.
3. **Requisito específico del usuario**: Para vistas de detalle que poseen cotas o elementos referenciados a elementos 3D que existen en el modelo original pero no en el modelo destinatario, mostrar **una única vez al finalizar la transferencia (no por cada vista)** un mensaje informativo en inglés indicando la existencia de elementos referenciados a geometría 3D que no pudieron ser transferidos, confirmando que el resto de anotaciones 2D sí fueron transferidas exitosamente.

---

### ¿Por qué ocurre esto actualmente en el código?

#### Causa A: En `TransferDraftingViews` (`FamilyRevitService.cs`, líneas 926-967)
```csharp
var copyOptions = new CopyPasteOptions();
var copiedIds = ElementTransformUtils.CopyElements(sourceDoc, filteredViewIds, targetDoc, Transform.Identity, copyOptions);
```
- Se invoca `ElementTransformUtils.CopyElements` a nivel de documento (`sourceDoc -> targetDoc`) pasando los IDs de las vistas (`ViewDrafting`).
- En la API de Revit, copiar una vista a nivel de documento **únicamente clona la cabecera/definición de la vista** (nombre, escala, plantilla de vista), pero **NO copia los elementos dependientes de vista (`ViewSpecific`) contenidos en su interior**.
- En el bucle posterior, el código únicamente renombraba la vista creada (`targetElem.Name = targetName;`), pero **nunca invocaba la copia de los elementos hijos contenidos en `srcView` hacia `targetElem`**.
- Como consecuencia directa, las vistas de diseño se creaban en destino pero vacías al 100%.

#### Causa B: En `TransferModelDetailViewsToDraftingViews` (`FamilyRevitService.cs`, líneas 1368-1389)
```csharp
var viewElements = new FilteredElementCollector(sourceDoc, srcView.Id)
    .WhereElementIsNotElementType()
    .Where(e => e.ViewSpecific && e is not Viewport && e is not Level && e is not SketchPlane)
    .Select(e => e.Id)
    .ToList();

if (viewElements.Any())
{
    try
    {
        ElementTransformUtils.CopyElements(srcView, viewElements, newDraftingView, Transform.Identity, copyOptions);
    }
    catch (Exception exCopy)
    {
        TelemetryLogger.LogWarning($"... Error copiando anotaciones ...: {exCopy.Message}");
    }
}
```
- En las Vistas de Detalle de Modelo (`ViewSection` con `ViewType.Detail` o llamadas de corte/planta), coexisten elementos puramente 2D (líneas, textos, componentes de detalle, regiones) con **cotas o etiquetas que acotan o referencian elementos 3D del modelo** (muros, pilares, vigas, ventanas).
- Al copiar hacia una `ViewDrafting` (vista de diseño 2D pura), **la geometría 3D del modelo no existe en la vista de diseño destino**.
- Si `viewElements` contiene una sola cota o etiqueta dependiente de un elemento 3D inexistente, la llamada en bloque `ElementTransformUtils.CopyElements` **falla en su totalidad lanzando una excepción para todo el conjunto**.
- El bloque `catch` capturaba el error y continuaba, provocando que no se copiara ni un solo elemento (ni siquiera las líneas o textos 2D independientes).

---

## 2. Solución Diseñada

La solución se basa en una arquitectura multinivel de alta resiliencia:
1. Copiar la vista de diseño / crear la vista de diseño destino.
2. Forzar regeneración del documento destino (`targetDoc.Regenerate()`).
3. Recolectar los elementos 2D hijos de la vista origen (excluyendo contornos de recorte como `ViewCrop` y `ExtentElem`).
4. **Estrategia Multinivel de Copia (Batch -> Element-by-Element Fallback):**
   - **Nivel 1 (Batch Copy):** Intentar copiar todos los elementos 2D en una única operación `ElementTransformUtils.CopyElements(srcView, childIds, targetView, Transform.Identity, copyOptions)`.
   - **Nivel 2 (Element-by-Element Fallback):** Si el lote falla (típico en vistas de modelo donde alguna cota o etiqueta depende de un objeto 3D), iterar elemento a elemento:
     - Todas las líneas de detalle (`DetailCurve`), textos (`TextNote`), regiones rellenadas (`FilledRegion`), instancias CAD (`ImportInstance`), grupos de detalle (`Group`), componentes de detalle (`FamilyInstance`), y cotas 2D independientes **se copian con éxito absoluto**.
     - Únicamente las cotas o etiquetas huérfanas de geometría 3D se omiten individualmente con un registro en TelemetryLogger y activando la bandera `hadSkipped3dReferences = true`.
5. **Notificación Única en Inglés en la UI (`TransferPlusViewModel.cs`):**
   - Rastrear si alguna de las vistas transferidas tuvo elementos dependientes de 3D omitidos (`anyHadSkipped3dReferences`).
   - Al finalizar el bucle completo de transferencia de destinos, si la bandera es verdadera, desplegar **una única ventana de diálogo** (`TaskDialog.Show`):
     ```text
     Title: TransferPlus - Notice
     Message: Some annotations (such as dimensions or tags referenced to 3D model geometry) could not be transferred to the destination 2D Drafting View(s) because their referenced 3D model elements are not present in the destination.

     All independent 2D lines, text notes, filled regions, detail components, and CAD elements have been successfully transferred.
     ```

---

## 3. Plan de Implementación

### Paso 1: `TransferDraftingViews` y `TransferModelDetailViewsToDraftingViews` en [FamilyRevitService.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/FamilyRevitService.cs)
- Añadir sobrecargas con parámetro `out bool hadSkippedElements` y `out bool hadSkipped3dReferences`.
- Ejecutar `targetDoc.Regenerate()`.
- Excluir elementos del sistema de vista (`ViewCrop`, `ExtentElem`, etc.).
- Implementar Nivel 1 (Batch) y Nivel 2 (Fallback elemento a elemento).
- Activar la bandera `hadSkipped3dReferences = true` / `hadSkippedElements = true` cuando se omitan elementos incompatibles.

### Paso 2: Integración en [TransferPlusViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/ViewModels/TransferPlusViewModel.cs)
- En `TransferCadDetailsToDestinationDocuments`:
  - Declarar `bool anyHadSkipped3dReferences = false;`.
  - Invocación a `TransferDraftingViews(..., out bool hadSkippedDrafting)`. Si es true, `anyHadSkipped3dReferences = true;`.
  - Invocación a `TransferModelDetailViewsToDraftingViews(..., out bool hadSkippedDetail)`. Si es true, `anyHadSkipped3dReferences = true;`.
  - Tras finalizar todos los destinos, mostrar el mensaje de éxito habitual y, si `anyHadSkipped3dReferences` es true, mostrar el `TaskDialog.Show("TransferPlus - Notice", ...)` **una única vez**.

### Paso 3: Compilación y Despliegue
- Compilar `TransferPlus` en `Debug.R24` con `/p:DeployAddin=true` hacia Revit 2024.
- Compilar en `Release.R24`.
- Regenerar el bundle de App Store mediante `build-bundle.ps1`.

### Paso 4: Documentación y Lecciones Aprendidas
- Actualizar `walkthrough.md`.
- Crear informe técnico de depuración en `TransferPlus/docs/references/`.

---

## 4. Plan de Verificación

1. **Compilación Limpia:**
   - Validar 0 errores y 0 advertencias críticas en C#.
2. **Verificación de Notificación Única:**
   - Comprobar que el `TaskDialog` se invoca únicamente una vez después del ciclo de todos los destinos y vistas, sin interrumpir con múltiples popups molestos.
3. **Verificación en Revit:**
   - Seleccionar un modelo con Vistas de Diseño y Vistas de Detalle con cotas referenciadas a muros/suelos 3D.
   - Ejecutar la transferencia en CAD Mode.
   - Constatar que las vistas de destino contienen todas las líneas, textos y tramas 2D, y que la ventana informativa en inglés aparece una sola vez.
