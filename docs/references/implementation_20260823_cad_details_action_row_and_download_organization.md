# Implementación: Fila de Acciones e Interruptores en Tarjeta Select Details/CAD (CAD Mode)

**Fecha:** 2026-08-23  
**Módulo:** `TransferPlus` (`CAD Details Manager`)

---

## 1. Contexto y Requerimiento

En la tarjeta **Select Details/CAD** (visible al activar el modo CAD), se requería añadir debajo del contenedor de miniatura de 200px:
1. Una línea separadora horizontal.
2. Una fila de acciones idéntica a la existente en la tarjeta de familias:
   - **Botón Delete**: Elimina elementos/vistas seleccionadas del modelo activo.
   - **Botón Download**: Descarga/exporta los elementos seleccionados abriendo el selector de carpetas de Windows (`FolderBrowserDialog`).
   - **Interruptor "Save Details/CAD as organized."**: Reproduce la estructura jerárquica de carpetas y subcarpetas mostrada en el explorador (por Planos, Vistas o Categorías).
   - **Interruptor "Overwrite Duplicates"**: Si está marcado, sobrescribe archivos existentes con el mismo nombre. Si no, genera una secuencia numérica incremental (`_1`, `_2`, ...) validando con el sistema de archivos que no existan colisiones.

---

## 2. Arquitectura de la Solución

### A. Vista XAML ([TransferPlusView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/TransferPlusView.xaml))
- Añadido separador `<Border BorderBrush="#E0E0E0" BorderThickness="0,1,0,0" Margin="0,8,0,8"/>`.
- Fila `StackPanel Orientation="Horizontal"` con botones circulares/cuadrados con plantilla SVG para Delete y Download.
- StackPanel vertical a la derecha con los dos `CheckBox` estilizados con `SwitchStyle`.

### B. ViewModel ([TransferPlusViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/ViewModels/TransferPlusViewModel.cs))
- **`SaveCadDetailsAsOrganized`** (`bool`, default `true`): Conmutador de organización.
- **`OverwriteCadDuplicates`** (`bool`, default `false`): Conmutador de sobreescritura.
- **`DeleteSelectedCadItemsCommand`**:
  - `CanDeleteSelectedCadItems()`: Requiere modelo activo modificable (`SelectedSourceDocument.Adoc != null && !SelectedSourceDocument.EsVinculo && !SelectedSourceDocument.Adoc.IsReadOnly`).
  - `DeleteSelectedCadItemsAsync()`: Confirmación mediante `MessageBox` y borrado en `Transaction`.
- **`DownloadSelectedCadItemsCommand`**:
  - `PromptFolderBrowserDialog(...)`: Abre el selector de carpetas nativo.
  - `ResolveOrganizedFolderForNode(...)`: Recorre la cadena `node.Parent` para construir dinámicamente el árbol de subdirectorios en disco.
  - `ResolveNonCollidingFilePath(...)`: Valida colisiones de nombres y aplica la secuencia `_{counter}` si `OverwriteCadDuplicates == false`.
  - `ExportOrDownloadCadItem(...)`:
    - Archivos CAD externos $\rightarrow$ `File.Copy(...)`.
    - Vistas de Diseño / Detalle $\rightarrow$ `doc.Export(..., DWGExportOptions)`.
    - Familias de Componentes $\rightarrow$ `_familyRevitService.ExportSelectiveFamilyToFolder(...)`.
    - Grupos de Detalle $\rightarrow$ exportación de vista/dibujo.

---

## 3. Verificación
Compilado con éxito:
```powershell
dotnet build TransferPlus/TransferPlus.csproj -c Debug.R24 /p:DeployAddin=false
```
**Resultado:** 0 errores, código de salida 0.
