# Plan de Implementación por Fases: Adaptación de UI y Tarjetas en Modo Familia

Para garantizar la estabilidad y facilitar la depuración, el plan se ha dividido en 3 fases incrementales:

---

## 🎯 Fase 1: Control Dinámico de Fuentes en "Apply transfer from" (Fase Actual)

### Objetivo
- **Modo General (`IsFamiliesManagerActive = false`):** El desplegable *"Apply transfer from:"* **NO mostrará** ninguna de las fuentes de familias configuradas en la ventana *Sources* (directorios locales o Azure Blob Storage). Únicamente listará los modelos de Revit abiertos y vinculados.
- **Modo Familia (`IsFamiliesManagerActive = true`):** El desplegable *"Apply transfer from:"* listará tanto las fuentes activas de familias (locales / Azure) como los modelos de Revit abiertos y vinculados.
- **Refresco Automático:** Al conmutar entre *Activate* y *Desactivate* en el Families Manager, o al guardar cambios en la ventana *Sources*, la lista de fuentes y la vista de árbol del explorador se actualizarán dinámicamente.

### Cambios Propuestos para Fase 1

#### [MODIFY] [TransferPlusViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/ViewModels/TransferPlusViewModel.cs)
1. **Validación en `LoadDocuments()`:**
   - Asegurar la limpieza y segregación estricta de `SourceDocuments`:
     - Si `IsFamiliesManagerActive == false`, omitir la carga de `FamilySourceConfigService.LoadSources()`.
     - Si la fuente seleccionada previamente era un `isFamilySource`, restaurar la selección por defecto al modelo activo actual (`_targetDoc`).
2. **Sincronización en Conmutación de Modo (`OnIsFamiliesManagerActiveChanged`):**
   - Ejecutar `LoadDocuments()` y forzar la recarga del árbol principal según la nueva fuente seleccionada.
3. **Persistencia desde la Ventana `Sources` (`OpenSourcesWindow`):**
   - Confirmar que tras guardar cambios en `FamilySourcesViewModel`, sólo se agreguen al desplegable si `IsFamiliesManagerActive == true`.

---

## 📋 Fase 2: Visibilidad de Tarjetas XAML y Selección en Modo Familia (Siguiente Fase)

### Objetivo
- Cambiar el estilo en XAML de las tarjetas **Filter**, **On Duplicates** y **Rename** para que no se oculten al activar `IsFamiliesManagerActive`.
- Habilitar los conteos y botones (`Apply`, `Clear`) en Modo Familia cuando existan familias/tipos seleccionados en el árbol.

---

## 📋 Fase 3: Lógica de Renombrado y Duplicados en Familias (Fase Final)

### Objetivo
- Integrar la paleta lateral de **PowerRename** con `FamilyItemModel` (previsualización y modificación de nombres).
- Integrar la rule de **On Duplicates** (*Keep Original*, *Abort Transaction*, *Append Suffix*) en la descarga y transferencia de archivos `.rfa`.

---

## Plan de Verificación de la Fase 1

### Compilación
- `dotnet build "TransferPlus\TransferPlus.csproj" -c "Debug R24"`

### Pruebas Manuales (Fase 1)
1. **Modo General por Defecto:**
   - Abrir TransferPlus con `Activate Families Manager` desmarcado.
   - Desplegar *"Apply transfer from:"*: Verificar que **solo se muestran los modelos de Revit** (abiertos/vinculados) y **ninguna** carpeta de fuentes o Azure Storage.
2. **Activación de Modo Familia:**
   - Pulsar `Activate` en la tarjeta Families Manager.
   - Desplegar *"Apply transfer from:"*: Verificar que **aparecen las fuentes configuradas** junto a los modelos abiertos.
3. **Uso de la ventana Sources:**
   - Pulsar el botón `Sources`, agregar/desactivar una fuente local o de Azure y pulsar `Apply`.
   - Verificar que el desplegable se actualiza de inmediato con la nueva configuración.
4. **Desactivación de Modo Familia:**
   - Pulsar `Desactivate`: Verificar que las fuentes de familias **desaparecen inmediatamente** del desplegable y la selección vuelve al modelo Revit activo.
