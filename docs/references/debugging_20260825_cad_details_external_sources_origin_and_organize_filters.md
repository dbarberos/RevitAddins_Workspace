# Debugging Report: Soporte Reactivo de Origen y Organización ("Select Details/CAD") para Fuentes Externas de CAD

**Fecha:** 2026-08-25  
**Proyecto:** TransferPlus  
**Módulos afectados:** `ViewModels/TransferPlusViewModel.cs`  
**Estado:** RESUELTO & COMPILADO (0 Errores)

---

## 1. Descripción del Problema

Cuando el usuario se encontraba en **CAD Details Manager** y seleccionaba una fuente de datos diferente al modelo abierto o vinculado (es decir, una **fuente externa de CAD** como carpetas locales en disco, Azure Blob Storage, AWS S3 o Autodesk Docs ACC):
1. Al pulsar sobre las opciones de la tarjeta **"Select Details/CAD"** (tanto en la columna **ORIGIN**: *CAD Links / CAD Imports*, *Drafting Views*, *Details Views*, *Details Groups*, *Details Items*, como en **ORGANIZE**: *Sort by Sheet*, *Sort by View*, *Sort by Name*), el explorador no reaccionaba y las opciones no funcionaban.
2. El árbol no filtraba reactivamente según el origen marcado ni organizaba los archivos CAD externos de forma clara.

---

## 2. Diagnóstico y Causa Raíz

1. **Condición restrictiva en los manejadores de cambio de origen**:
   - En los métodos `OnCadOriginLinksAndImportsChanged`, `OnCadOriginDraftingViewsChanged`, `OnCadOriginDetailViewsAndCalloutsChanged`, `OnCadOriginDetailGroupsChanged`, `OnCadOriginDetailItemsChanged`, existía la comprobación:
     ```csharp
     if (IsCadDetailsManagerActive && SelectedSourceDocument?.Adoc != null)
     {
         LoadCadItemsFromSource(SelectedSourceDocument.Adoc);
     }
     ```
   - Al tratarse de fuentes externas (carpetas, Azure, AWS S3, Autodesk Docs), `SelectedSourceDocument.Adoc` es `null`. Por tanto, cualquier cambio en los botones de radio de ORIGIN no ejecutaba ninguna acción.
2. **Pérdida de la colección maestra de origen (`_allCadSourceItems`)**:
   - Al cargar archivos CAD externos mediante `LoadCadFilesFromSourceAsync`, los elementos se asignaban directamente a la lista de trabajo `_cadItems = cadItems.ToList();` sin conservar la lista maestra `_allCadSourceItems`. Esto impedía refiltrar en memoria los elementos al cambiar de opción.
3. **Agrupación en `BuildCadTree` para fuentes externas**:
   - En `CadSortByView` y `CadSortBySheet`, los archivos CAD externos no disponen de vistas anfitrionas de Revit (`ViewDrafting`) ni de planos (`SheetName`), por lo que se agrupaban de manera redundante archivo por archivo en lugar de agruparse de forma limpia por contenedor/directorio fuente.

---

## 3. Solución Técnica Implementada

### A. Almacenamiento Maestro y Refiltrado Reactivo en Memoria
- Se introdujo el campo maestro:
  ```csharp
  private List<CadDetailItemModel> _allCadSourceItems = new();
  ```
- Se implementó el método unificado `RefreshCadSourceItems()`:
  - Si `SelectedSourceDocument.Adoc != null` (modelo Revit abierto o vinculado), invoca `LoadCadItemsFromSource(SelectedSourceDocument.Adoc)` consultando al proveedor de API correspondiente.
  - Si `SelectedSourceDocument.EsCadSource == true` (fuente externa en la nube o carpeta local), invoca `FilterAndBuildExternalCadItems()`.

### B. Lógica de Filtrado para Fuentes Externas (`FilterAndBuildExternalCadItems`)
- **`CadOriginLinksAndImports`**: Muestra la totalidad de archivos vectoriales CAD externos (.dwg, .dxf, .dgn, .sat, etc.) recolectados del proveedor.
- **`CadOriginDraftingViews` / `DetailViews` / `DetailGroups` / `DetailItems`**: Filtra sobre `_allCadSourceItems` según el tipo específico (para carpetas externas de archivos CAD puros, retornará 0 elementos de forma coherente, indicando que no existen vistas de diseño ni grupos de detalle de Revit en dicha carpeta).
- Al seleccionar una fuente CAD externa en `OnSelectedSourceDocumentChanged`, si el origen activo por defecto era *Drafting Views*, se conmuta automáticamente a `CadOriginLinksAndImports = true` para que los archivos CAD sean visibles de inmediato.

### C. Reorganización del Árbol Jerárquico en `BuildCadTree`
- **Sort by View / Container**: Para archivos externos (`IsExternalFile == true`), se agrupan todos los archivos bajo el nombre del contenedor o fuente (`SourceDocumentName`), mostrando la lista limpia `All -> [Nombre Fuente / Carpeta] -> [Archivos CAD]`.
- **Sort by Name**: Se agrupan por extensión/categoría (`All -> DWG File -> [Archivos CAD]`).
- **Sort by Sheet**: Los archivos externos sin plano asignado se agrupan ordenadamente bajo `All -> (No Sheet / Standalone) -> [Nombre Fuente] -> [Archivos CAD]`.

---

## 4. Verificación de Compilación

```powershell
dotnet build TransferPlus/TransferPlus.csproj -c Debug.R24 /p:DeployAddin=false
```
**Resultado:** `0 Errores`, código de salida 0.
