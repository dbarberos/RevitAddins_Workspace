# 📘 Blueprint: SelectionFilterViewModel

## Propósito
Este ViewModel es el corazón del explorador de elementos de FilterPlus. Gestiona una estructura de árbol de 5 niveles (o 6 si se filtra por fases) con capacidades de filtrado offline y sincronización en tiempo real con Revit.

---

## 🏗️ Estructura del Árbol (Hierarchy)
El árbol se construye dinámicamente en `InitializeTree` y puede alternar entre dos estructuras:

1. **Estándar**: All > Categoría > Familia > Tipo > Instancia (ID).
2. **Por Fase**: All > **Fase** > Categoría > Familia > Tipo > Instancia (ID).

### Reglas de Construcción:
- **Offline First**: El árbol se construye usando una lista pre-cargada de `ElementModel`. NUNCA se llama a la API de Revit durante la construcción del árbol para evitar crashes del hilo UI.
- **Bulk Updating**: Se utiliza el flag `TreeItemViewModel.IsBulkUpdating` para silenciar eventos de UI mientras se reconstruye el árbol o se realizan búsquedas.

---

## 🔍 Lógica de Filtrado (Offline Logic)
El método `GetFilteredElements()` centraliza los filtros sin llamar a Revit:

| Filtro | Lógica Interna |
|---|---|
| **Only 3D model objects** | `CategoryType == Model` + `HasBoundingBox` |
| **Only Annotations** | `CategoryType == Annotation` |
| **Has Bounding Box** | `BoundingBox != null` (Excluye materiales, cámaras, etc.) |

**Exclusión Mutua**: Los filtros de geometría son excluyentes entre sí. Al activar uno, se limpian los demás y se eliminan de la selección los elementos que quedan ocultos.

---

## ⚡ Sincronización en Vivo (Live Selection)
- **Propiedad**: `IsLiveSelection`
- **Comportamiento**: Si está activo, el método `OnTreeSelectionChanged` llama a `ApplyFilter()` tras cada clic.
- **Seguridad**: Solo dispara el comando si `IsBulkUpdating` es falso.

---

## 🔍 Lógica de Búsqueda y Selección Aditiva
El filtro actúa puramente sobre la selección y utiliza un sistema **Manual (Stateless)** para evitar inconsistencias de estado.

### Reglas de Búsqueda:
1. **Manual (On-Demand)**: En lugar de buscar al teclear (Debounce), se requiere pulsar un botón "Apply". Esto permite al usuario configurar los switches ("Use OR", "Only by name") tranquilamente antes de ejecutar.
2. **Filtro "Only by name"**: 
   - **ON**: Solo busca coincidencias en `node.Name`.
   - **OFF**: Busca en `node.Name` y también en el **Element ID** numérico.
3. **Lógica "Use OR" (Stateless)**:
   - **OFF**: El comando desmarca todo el árbol y luego marca las coincidencias (Búsqueda de reemplazo).
   - **ON**: El comando no desmarca nada, simplemente añade marcas a las coincidencias (Búsqueda aditiva).
4. **Auto-Clear**: Tras aplicar la búsqueda exitosamente, el campo de texto se limpia para indicar que la acción ha concluido.

### Gestión de Estado en Árboles (Lecciones Aprendidas):
- **Stateless vs Stateful**: Mantener estados previos (`_preSearchCheckedIds`) mientras el usuario teclea genera bugs visuales si cambian switches en medio del proceso. La arquitectura manual (leer estado de switches en el click del botón) es mucho más robusta para lógicas complejas de selección.
- **Bottom-Up Refresh**: Tras una operación masiva de checks, llamar a `node.RefreshState()` desde la raíz.
- **Dispatcher.InvokeAsync**: Usar para limpiar campos de texto desde comandos que interactúan con procesos pesados de Revit, asegurando que WPF procese la actualización visual.
- **Grouped Toggles (Left Alignment)**: Para evitar superposiciones al redimensionar la ventana, agrupar switches en `StackPanel` horizontales con `HorizontalAlignment="Left"` en lugar de repartirlos en columnas de rejilla con `*`.
- **Safe Parameter Extraction**: Evitar iterar por `el.Parameters` en colecciones masivas de elementos desconocidos. Esto puede causar `AccessViolationException`. Es preferible usar `get_Parameter(BuiltInParameter...)` para capturar campos específicos (Mark, Comments, etc.) y envolver la extracción en un bloque `try-catch`.
- **Safe UI Dispatcher**: En un entorno de Add-in, `System.Windows.Application.Current` suele ser `null` ya que Revit no es una aplicación nativa WPF pura. Para actualizaciones asíncronas de la UI, usar siempre `System.Windows.Threading.Dispatcher.CurrentDispatcher.InvokeAsync` en lugar de `Application.Current.Dispatcher`.

---


## ⚠️ Consideraciones de Hilos (Threading)
1. **Constructor**: Es el único lugar donde es 100% seguro recolectar datos de Revit directamente (se ejecuta en el hilo del comando).
2. **Dispatcher**: Toda modificación a la colección `RootNodes` que sea notificada a la UI debe ocurrir a través del `uiDispatcher.Invoke` o `BeginInvoke`.
3. **Persistencia**: Los IDs seleccionados se guardan en `_persistentCheckedIds` (HashSet) para que la selección sobreviva a cambios de scope o reconstrucciones del árbol.
4. **Bulk Updating**: El uso de `TreeItemViewModel.IsBulkUpdating` es crítico durante la búsqueda para evitar que cada cambio individual de checkbox dispare eventos de pesados de sincronización con Revit.
