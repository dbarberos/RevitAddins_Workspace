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

## ⚠️ Consideraciones de Hilos (Threading)
1. **Constructor**: Es el único lugar donde es 100% seguro recolectar datos de Revit directamente (se ejecuta en el hilo del comando).
2. **Dispatcher**: Toda modificación a la colección `RootNodes` que sea notificada a la UI debe ocurrir a través del `uiDispatcher.Invoke` o `BeginInvoke`.
3. **Persistencia**: Los IDs seleccionados se guardan en `_persistentCheckedIds` (HashSet) para que la selección sobreviva a cambios de scope o reconstrucciones del árbol.
