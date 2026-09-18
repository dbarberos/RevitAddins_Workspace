# Debugging Log: Transferencia de Parámetros de Ejemplar y Limpieza Segura de Vistas

**Fecha:** 2026-07-23  
**Proyecto:** TransferPlus  
**Componente:** `TransferOrchestrator.cs` (`CopyViewInstanceParameters`, `ponDependientes`)  

---

## 1. Causa Raíz Identificada del Doble Bug

### A. Pérdida de Campos Personalizados (`KRN_Grupo 1, 2, 3`)
- `ViewPlan.Create` crea vistas de planta con parámetros de ejemplar vacíos.
- La función previa `CopyViewSettings` solo copiaba Escala, Nivel de detalle, Estilo visual y Cuadro de Recorte (`CropBox`), omitiendo los parámetros compartidos/de proyecto (`OST_Views`).
- Al eliminar la vista clonada automáticamente por `CopyElements` y conservar la vista creada por `ViewPlan.Create`, los campos `KRN_Grupo 1, 2, 3` permanecían vacíos.

### B. Eliminación Errónea de Vistas Preexistentes en "Append Suffix"
- El filtro de limpieza previo en `ponDependientes` ejecutaba `.Where(v => v.Name.Contains(vistaorigen.Name))`.
- Si `P1 - EST - OFICINAS` ya existía en el documento destino antes de iniciar la transferencia, y se realizaba una segunda transferencia con `Append Suffix` (`P1 - EST - OFICINAS_Copy`), el comparador evaluaba la vista **preexistente** `P1 - EST - OFICINAS` como duplicado colateral y la eliminaba indebidamente del proyecto destino.

---

## 2. Solución Aplicada

1. **Copia Explícita de Parámetros de Ejemplar (`CopyViewInstanceParameters`)**:
   - Recorre `srcView.Parameters`, filtra parámetros de lectura/sistema y transfiere 1:1 todos los parámetros de proyecto/compartidos (`KRN_Grupo 1, 2, 3`) hacia `targetView`.

2. **Registro Previsto de IDs Preexistentes (`existingViewIdsBeforeCopy`)**:
   - Antes de llamar a `ElementTransformUtils.CopyElements`, se almacena un conjunto `HashSet<ElementId>` con **todas las vistas existentes en el modelo destino**.
   - Ninguna vista cuyo `ElementId` estuviera en el conjunto preexistente puede ser eliminada. Solo se destruyen vistas **recientemente creadas durante esa llamada concreta a `CopyElements`**.

3. **Filtrado Avanzado de `extentElem` por `StartsWith`**:
   - Se excluyen elementos cuyo nombre o clase empiece por `extentElem`, `ViewCrop` o `ExtentElem` antes de invocar a `CopyElements`.

---

## 3. Verificación
- Compilado e instalado en `%AppData%\Autodesk\Revit\Addins\2024\TransferPlus\TransferPlus.dll` (**0 Errores**).
