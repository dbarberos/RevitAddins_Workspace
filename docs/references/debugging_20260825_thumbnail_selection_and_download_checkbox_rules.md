# Debugging Report: Desacoplamiento de Previsualización (Thumbnail) y Reglas de Activación de Descarga/Eliminación por Checkbox

**Fecha:** 2026-08-25  
**Proyecto:** TransferPlus  
**Módulos afectados:** `ViewModels/TransferPlusViewModel.cs`, `Views/TransferPlusView.xaml`  
**Estado:** RESUELTO & COMPILADO (0 Errores)

---

## 1. Descripción del Problema y Requerimientos

1. **Visualización de Miniaturas (Thumbnail)**:
   - Al seleccionar múltiples elementos en el explorador mediante sus casillas de verificación (checkboxes), la tarjeta de detalles colapsaba la previsualización individual y mostraba el texto genérico *"Multiple details/CAD selected"*, impidiendo ver la miniatura y metadatos del elemento sobre el que el usuario hacía clic con el ratón.
   - **Requisito**: Siempre que el usuario haga clic sobre el nombre de un elemento en el árbol (tenga o no marcada su casilla de verificación), se debe mostrar **siempre su miniatura y metadatos individuales**. El texto de selección múltiple solo debe mostrarse si no hay ningún elemento activo clicado con el ratón.
2. **Activación de Comandos de Acción (Download y Delete)**:
   - El botón de descarga se habilitaba si había un elemento seleccionado/clicado (`SelectedCadDetail != null`), lo cual permitía descargar elementos que no tenían su checkbox marcado.
   - **Requisito**: El botón de descarga (y eliminación) **solo debe activarse cuando exista al menos una casilla de verificación (checkbox) marcada** en el explorador. Nunca se debe descargar o eliminar un elemento que no tenga su checkbox marcado, aunque se esté mostrando su miniatura.

---

## 2. Diagnóstico y Causa Raíz

1. **Condición de `IsSingleCadDetails` e `IsSingleFamilyDetails`**:
   - Previamente, `IsSingleCadDetails` estaba definida como:
     ```csharp
     public bool IsSingleCadDetails => (SelectedCadDetail != null && SelectedCadCount <= 1) || SelectedCadCount == 1;
     ```
     En cuanto `SelectedCadCount > 1`, esta propiedad se evaluaba como `false`, lo que activaba el `DataTrigger` de XAML para ocultar el Grid de previsualización individual y mostrar el `TextBlock` de *"Multiple details/CAD selected"*.
2. **Reseteo en `UpdateCheckedCount()`**:
   - Al marcar o desmarcar checkboxes, `UpdateCheckedCount()` ejecutaba:
     ```csharp
     if (checkedCadItems.Count > 1 && SelectedCadDetail != null && !checkedCadItems.Contains(SelectedCadDetail))
     {
         SelectedCadDetail = null;
     }
     ```
     Esto borraba la referencia del elemento que el usuario estaba inspeccionando si no estaba en la lista de checkboxes marcados.
3. **Condición `CanExecute` y fallback en `DownloadSelectedCadItemsAsync` y `DownloadSelectedFamiliesAsync`**:
   - `CanDownloadSelectedCadItems` retornaba `true` si `SelectedCadDetail != null`, sin exigir que hubiera elementos en `checkedCadItems`.
   - `DownloadSelectedCadItemsAsync` y `DownloadSelectedFamiliesAsync` tenían un bloque de rescate `if (!itemsToDownload.Any() && SelectedCadDetail != null)` que añadía el elemento del panel de detalles a la descarga aunque su checkbox no estuviera marcado.

---

## 3. Solución Técnica Implementada

### A. Desacoplamiento de Propiedades en `TransferPlusViewModel.cs`
- **Previsualización individual**: `IsSingleCadDetails => SelectedCadDetail != null;` e `IsSingleFamilyDetails => SelectedFamily != null;`.
- **Marcador de selección múltiple**: Se crearon propiedades dedicadas `ShowMultipleCadDetailsPlaceholder => SelectedCadDetail == null && SelectedCadCount > 1;` y `ShowMultipleFamilyDetailsPlaceholder => SelectedFamily == null && SelectedFamilyCount > 1;`.
- **Persistencia del elemento clicado**: Se eliminó en `UpdateCheckedCount()` cualquier asignación o anulación forzada sobre `SelectedCadDetail`. El elemento clicado con el ratón permanece activo en el visor.

### B. Enrutamiento en XAML ([TransferPlusView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/TransferPlusView.xaml))
- El Grid con la miniatura 128x128 y los metadatos se muestra siempre que `IsSingleCadDetails` (o `IsSingleFamilyDetails`) sea `True`.
- El TextBlock de selección múltiple se muestra únicamente cuando `ShowMultipleCadDetailsPlaceholder` (o `ShowMultipleFamilyDetailsPlaceholder`) es `True`.
- Si no hay ningún elemento clicado ni checkboxes marcados, se muestra el texto guía inicial de *"Select or click a detail/CAD item in the tree to view details"*.

### C. Restricción Estricta de Descarga y Eliminación por Checkboxes
- **`CanDownloadSelectedCadItems`**: Exige `checkedCadItems.Any()` (`SelectedCadCount > 0`). Se eliminó `if (SelectedCadDetail != null) return true;`.
- **`DownloadSelectedCadItemsAsync`**: Recolecta únicamente nodos con `IsChecked == true`. Se eliminó el fallback de añadir `SelectedCadDetail`.
- **`CanDeleteSelectedCadItems` (Modo CAD)**:
  - Exige que la fuente sea el modelo de proyecto abierto en la sesión de Revit (`SelectedSourceDocument.Adoc != null && !SelectedSourceDocument.EsVinculo && !SelectedSourceDocument.Adoc.IsReadOnly`).
  - Para fuentes externas (carpetas locales, Azure, AWS S3, Autodesk Docs) o modelos vinculados (`EsVinculo == true`), el botón **Delete** se deshabilita automáticamente (`IsEnabled = false`, opacidad 0.4, color #cccccc).
  - Exige que exista al menos una casilla de verificación (checkbox) marcada en el explorador (`checkedCadItems.Any()`).
  - En `DeleteSelectedCadItemsAsync`, se eliminan exclusivamente los elementos cuyos checkboxes estén marcados (`itemsToDelete`), solicitando previa confirmación al usuario mediante ventana emergente (`MessageBox` con botón Sí/No e icono de advertencia).
- **`CanDownloadSelectedFamilies` y `CanDeleteSelectedFamilies`**: Aplican exactamente el mismo criterio para el modo de familias.
- **Notificación Reactiva**: Se añadieron llamadas a `DeleteSelectedCadItemsCommand.NotifyCanExecuteChanged()` y `DownloadSelectedCadItemsCommand.NotifyCanExecuteChanged()` en `OnSelectedCadCountChanged`, `OnSelectedFamilyCountChanged`, `OnIsCadDetailsManagerActiveChanged`, `OnIsFamiliesManagerActiveChanged`, en el manejador del `WeakReferenceMessenger` y al cambiar el documento de origen.

---

## 4. Verificación de Compilación

```powershell
dotnet build TransferPlus/TransferPlus.csproj -c Debug.R24 /p:DeployAddin=false
```
**Resultado:** `0 Errores`, código de salida 0.
