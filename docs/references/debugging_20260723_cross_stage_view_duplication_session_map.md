# Debugging Log: Eliminación de Transferencia Duplicada Inter-Secciones (Mapa de Sesión `processedViewsMap`)

**Fecha:** 2026-07-23  
**Add-in:** TransferPlus  
**Componente:** `TransferOrchestrator.cs` (`processedViewsMap`, `processSheetViewports`, `planViewsToTransfer`, `ponCallouts`)  

## 1. Análisis del Problema
Al seleccionar simultáneamente un plano (`ViewSheet`) y sus vistas de plano (`ViewPlan`) o llamadas (`Callouts`) en el árbol:
1. **Sección 4 (`sheetsToTransfer`)** procesaba el plano e instanciaba/resolvía la vista colocada en el plano.
2. **Sección 5 (`planViewsToTransfer`)** volvía a procesar de forma independiente la misma vista seleccionada en el árbol, intentando crearla o buscarla de nuevo en una fase posterior.
3. Si la vista no se registraba unívocamente en un mapa de sesión global, las llamadas y etapas posteriores ejecutaban comprobaciones y duplicaciones independientes.

## 2. Solución Arquitectónica Aplicada
- Se creó `var processedViewsMap = new Dictionary<ElementId, ElementId>()` a nivel de la sesión `TransferElements`.
- Mapea unívocamente `Source ViewId` -> `Target ViewId`.
- **En la Sección de Planos (`processSheetViewports`)**: Antes de crear o copiar una vista del plano, consulta `processedViewsMap`. Si ya fue procesada, reutiliza la vista destino mapeada sin crear duplicados. Al crear/resolver una vista, registra `processedViewsMap[srcId] = targetId`.
- **En la Sección de Vistas de Plano (`planViewsToTransfer`)**: Consulta `processedViewsMap`. Si la vista ya fue creada/resuelta durante la transferencia del plano, omite `CreateViewPlan` y reutiliza directamente el `targetId` mapeado.
- **En la Función de Llamadas (`ponCallouts`)**: Recibe `processedViewsMap`. Si la llamada dependiente ya fue creada en etapas anteriores, reutiliza su `targetId` sin volver a ejecutar `CopyElements`.

## 3. Verificación
- Compilado e instalado para `.NET Framework 4.8` (`Debug.R24`) con **0 Errores**.
