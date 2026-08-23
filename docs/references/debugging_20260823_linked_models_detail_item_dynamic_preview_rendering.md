# Debugging Report: Renderizado Dinámico de Miniaturas en CAD Mode para Elementos de Modelos Vinculados

**Fecha:** 2026-08-23  
**Proyecto:** TransferPlus  
**Módulos afectados:** `Services/FamilyRevitService.cs` (`GenerateElementPreview`), `Services/CadThumbnailService.cs` (`GetPreviewImageAsync`)  
**Estado:** RESUELTO & COMPILADO (0 Errores)

---

## 1. Descripción del Problema

Al seleccionar un elemento 2D de detalle (por ejemplo, un **Detail Item**, **Detail Group** o **FilledRegion**) perteneciente a un modelo vinculado (`RevitLinkInstance` / `linkDoc`) en el explorador de **CAD Details Manager**, el visor de previsualización mostraba el icono gráfico vectorial 2D genérico en lugar de generar una imagen renderizada real del elemento aislado.

---

## 2. Diagnóstico y Causa Raíz

1. **Restricción de Transacciones en Modelos Vinculados**:
   - En Revit, cualquier documento vinculado cargado en memoria (`linkDoc.IsLinked == true` o `linkDoc.IsReadOnly == true`) es de solo lectura.
   - En versiones previas, `GenerateElementPreview` detectaba `if (doc.IsLinked || doc.IsReadOnly)` y retornaba inmediatamente `null` o intentaba exportar la vista anfitriona completa (`GenerateViewPreview`), la cual fallaba o exportaba toda la planta en lugar del elemento aislado.
2. **Coincidencia de Categoría en `CadThumbnailService`**:
   - En `CadThumbnailService.cs`, la condición `CASO A` no contemplaba de forma explícita todos los elementos 2D (`FilledRegion`, `GroupType`, `"Detail Groups"`).
   - No se aplicaba la estrategia de renderizado en memoria delegada sobre el documento activo anfitrión (`CadThumbnailService.ActiveDocument`).

---

## 3. Solución Técnica Implementada

### A. Renderizado Dinámico en Documento Anfitrión con RollBack
En [FamilyRevitService.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/FamilyRevitService.cs) (`GenerateElementPreview`):
1. **Intento Directo de Familia**: Si el elemento es un `FamilySymbol` o `FamilyInstance` con su `Family` accesible en memoria, se ejecuta `GenerateFamilyRenderedPreview(family, ActiveDocument)`.
2. **Copia Aislada y Transacción Temporal en `workDoc`**:
   - Si `doc` es un modelo vinculado (`doc.IsLinked || doc.IsReadOnly`), se establece como documento de trabajo el modelo activo (`workDoc = CadThumbnailService.ActiveDocument ?? doc`).
   - Se inicia una `Transaction(workDoc, "Generate Isolated Element Preview")` con supresión de advertencias (`WarningSwallower`).
   - Se crea una `ViewDrafting` temporal en `workDoc`.
   - Se copia el elemento/símbolo desde `linkDoc` hacia `workDoc` mediante `ElementTransformUtils.CopyElements(doc, new List<ElementId> { elem.Id }, workDoc, Transform.Identity, new CopyPasteOptions())`.
   - Si es un `FamilySymbol`, se activa e instancia en la `ViewDrafting` temporal (`workDoc.Create.NewFamilyInstance(XYZ.Zero, workSym, tempView)`).
   - Si es una instancia, grupo o región copiada desde su vista anfitriona, se posiciona en `tempView`.
   - Se regenera `workDoc` y se ajusta el `CropBox` ceñido al `BoundingBox` del elemento con un margen del 8%.
   - Se exporta a PNG (512x512) mediante `workDoc.ExportImage(options)` y se aplica encuadre inteligente (`OptimizeImageFraming`).
   - En el bloque `finally`, se ejecuta **`tx.RollBack()`**, garantizando que no quede ninguna modificación residual ni en el modelo activo ni en el vínculo.

### B. Enrutamiento en `CadThumbnailService`
En [CadThumbnailService.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/CadThumbnailService.cs):
- Se amplió la condición de `CASO A` para cubrir `Detail Items`, `Detail Groups`, `Details Groups`, `FamilyInstance`, `FamilySymbol`, `Group`, `GroupType` y `FilledRegion`.
- Se integraron fallbacks de renderizado directo de familias y extracción nativa antes de recurrir al icono informativo.

---

## 4. Verificación de Compilación

Compilación exitosa con 0 errores en .NET:
```powershell
dotnet build TransferPlus/TransferPlus.csproj -c Debug.R24 /p:DeployAddin=false
```
**Resultado:** `0 Errores`, tiempo transcurrido `11.36s`.
