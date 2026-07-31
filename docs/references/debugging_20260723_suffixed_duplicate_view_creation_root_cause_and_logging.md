# Debugging Log: Solución del Renombrado de Vistas y Generación de Sufijos en TransferPlus

**Fecha:** 2026-07-23  
**Proyecto:** TransferPlus  
**Componente:** `TransferOrchestrator.cs`, `TransferPlusViewModel.cs`  

---

## 1. Síntomas Reportados
1. Al transferir planos y vistas con la opción `Append Suffix` activa:
   - Se creaban dos vistas en el modelo destino.
   - En la primera vista creada no se trasladaban todas las propiedades gráficas/anotaciones.
   - En la segunda vista duplicada (con el sufijo numérico) sí se trasladaban todas las propiedades.
2. Al transferir subproyectos (`Worksets`) a modelos no colaborativos, la operación finalizaba imprimiendo "Transfer complete!" sin advertir que no se habían transferido los subproyectos.

---

## 2. Diagnóstico Técnico de la Causa Raíz

### A. Renombrado en Caliente de la Vista Existente
- En `processSheetViewports`, `CreateViewPlan` intentaba crear una vista con el nombre original (`P1 - EST - OFICINAS`).
- Al colisionar el nombre en el destino, `CreateViewPlan` ejecutaba `FindExistingViewByName`, localizaba la vista existente en el modelo destino y la devolvía.
- `processSheetViewports` asumía erróneamente que la vista devuelta era una vista recién creada y ejecutaba `newPlan.Name = srcPlacedView.Name + " 1"`. Esto **renombraba en caliente la vista existente del proyecto destino**.
- Posteriormente, en la Etapa 5 (`planViewsToTransfer`), el buscador intentaba localizar `P1 - EST - OFICINAS` (que acababa de ser renombrada a `... 1`), no la encontraba y creaba una segunda vista por defecto, aplicando las propiedades únicamente a una de ellas.

### B. Falta de Intercepción Pre-flight en Worksets
- `TransferOrchestrator` omitía silenciosamente la creación de Worksets cuando `targetDoc.IsWorkshared == false`, pero no notificaba a `TransferPlusViewModel`, el cual procedía a mostrar el diálogo de éxito.

---

## 3. Solución Implementada

1. **Parámetro `forceNewSuffixedView: true` en `CreateViewPlan`**:
   - Se calcula el nombre único con sufijo (`desiredName = GetUniqueViewName(targetDoc, srcViewPlan.Name + suffixText, srcViewPlan.ViewType)`) **antes** de llamar a `ViewPlan.Create`.
   - La nueva vista se crea directamente con su nombre único definitivo, evitando mutar el nombre de la vista original.

2. **Validación Pre-flight de Worksets en `TransferPlusViewModel`**:
   - Evalúa `hasWorksetsSelected` y despliega la advertencia `TaskDialog` en inglés antes de modificar la base de datos de Revit.

3. **Inyección de Logs Traza Granulares Etiquetados**:
   - Etiquetas añadidas: `CreateViewPlan [START]`, `[PRE-CHECK]`, `[RE-USE EXISTING]`, `[SUFFIX NAME GENERATED]`, `[LEVEL RESOLVED]`, `[API CALL]`, `[API SUCCESS]`, `[NAME ASSIGNED]`, `[COPY SETTINGS]`.

---

## 4. Verificación
- Compilado e instalado en `%AppData%\Autodesk\Revit\Addins\2024\TransferPlus\TransferPlus.dll` (0 errores).
