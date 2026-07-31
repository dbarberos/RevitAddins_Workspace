# Debugging Log: Revit API `ElementTransformUtils.CopyElements` View-Marker Side-Effect Duplication

**Fecha:** 2026-07-23  
**Proyecto / Add-in:** TransferPlus  
**Componente:** `TransferOrchestrator.cs` (`ponDependientes`, `ponCallouts`)  
**Stack Técnico:** C# 12 / .NET Framework 4.8 / Revit API 2024  

---

## 1. Resumen del Problema y Evidencia Log
Durante la transferencia de vistas de plano (`ViewPlan`) y planos (`ViewSheet`), a pesar de haber corregido el cálculo inicial de nombres con sufijo *upfront*, la ejecución generaba una segunda vista duplicada con sufijo numérico (`P1 - EST - OFICINAS_Nivel Oficinas1`).

La inspección granular de la línea de tiempo de logs reveló:
- **14:05:15.936**: `CreateViewPlan [API SUCCESS]` instanciaba la vista deseada `P1 - EST - OFICINAS_Nivel Oficinas` (`Target ViewId: 150684`).
- **14:05:17.557**: `ponDependientes` recolectaba 17 elementos 2D presentes en la vista origen.
- **14:05:18.173**: `ponDependientes` ejecutaba `ElementTransformUtils.CopyElements(vistaorigen, collection, vistadestino, ...)` para copiar en lote los 17 elementos 2D.
- **Resultado Inesperado**: Inmediatamente tras esa llamada, aparecía en el Navegador de Proyectos de Revit la vista duplicada `P1 - EST - OFICINAS_Nivel Oficinas1`.

---

## 2. Diagnóstico Técnico de la Causa Raíz

1. **Inclusión de Visores/Marcadores de Vista en `FilteredElementCollector`**:
   - `FilteredElementCollector(origen, vistaorigen.Id)` devuelve **todos** los elementos visibles en la vista origen.
   - Entre los 17 elementos recolectados se encontraban símbolos/marcadores de visor de vista (`ElevationMarker`, `ReferenceViewer`, categorías `OST_Viewers`, `OST_ReferenceViewer`, `OST_CalloutBoundary`, `OST_Elev`).

2. **Mecanismo NATIVO de Clonado Automático de la Revit API**:
   - Cuando la función nativa `ElementTransformUtils.CopyElements` recibe un elemento de tipo marcador/visor que apunta a otra vista, el motor C++ interno de Revit interpreta que debe mantener la integridad de la llamada copiada.
   - Para evitar dejar una llamada/sección con un puntero roto, **el motor interno de Revit duplica automáticamente la vista referenciada en el documento destino**, asignándole el sufijo numérico `1`.

3. **Duplicidad de Responsabilidades con `ponCallouts`**:
   - TransferPlus cuenta con la función dedicada `ponCallouts`, la cual procesa las llamadas de vista respetando el mapa de sesión (`processedViewsMap`) para evitar duplicados.
   - Pasar los visores de llamada a `ElementTransformUtils.CopyElements` dentro de `ponDependientes` puenteaba el control de `ponCallouts` y provocaba la duplicación automática por efecto colateral de Revit.

---

## 3. Solución Implementada y Reglas de Negocio

### A. Filtrado Estricto de Visores en `ponDependientes`
Se han excluido los elementos de marcador de visor sin afectar a los elementos 2D de anotación/detalle:
```csharp
var viewElements = new FilteredElementCollector(origen, vistaorigen.Id)
    .WhereElementIsNotElementType()
    .Where(e => e != null && e.IsValidObject && e.ViewSpecific && 
                e is not View && 
                e is not Viewport && 
                e is not SunAndShadowSettings && 
                e is not Level && 
                e is not SketchPlane &&
                e is not ElevationMarker &&
                e.GetType().Name != "ReferenceViewer" &&
                (e.Category == null || (
                    e.Category.Id.Value != (long)BuiltInCategory.OST_Viewers &&
                    e.Category.Id.Value != (long)BuiltInCategory.OST_ReferenceViewer &&
                    e.Category.Id.Value != (long)BuiltInCategory.OST_CalloutBoundary &&
                    e.Category.Id.Value != (long)BuiltInCategory.OST_Elev
                )))
    .ToList();
```

### B. Preservación del 100% de la Funcionalidad de Copia
- `ElementTransformUtils.CopyElements` **continúa ejecutándose normalmente** en `ponDependientes` para el 100% de los elementos de detalle 2D (cotas, textos, líneas de detalle, regiones rellenadas, nubes de revisión, componentes de detalle 2D, etiquetas).
- `ElementTransformUtils.CopyElements` **continúa ejecutándose normalmente** en la copia de elementos de plano (`processSheets`), elementos de modelo 3D, filtros, plantillas de vista, materiales y patrones.
- Se elimina la clonación lateral de vistas producida por el motor C++ de Revit.

---

## 4. Verificación y Despliegue
- Compilado para `.NET Framework 4.8` (`Debug.R24`) con **0 Errores**.
- Artefactos registrados bajo el estándar `AGENTS.md` y `apply-skillopt`.
