# Walkthrough: Rediseño de la Interface Gráfica de `TransferPlus` a Dos Columnas (v5.0.0)

Hemos rediseñado la distribución visual del addin **`TransferPlus`** para ajustarla fielmente a la estructura de dos columnas de la interfaz clásica (v5.0.0), manteniendo los estilos del sistema de diseño premium (tarjetas, interruptores y márgenes).

## Cambios Realizados

### 1. Reorganización de Columnas (Izquierda vs Derecha)
* **Columna Izquierda (Explorador y Selección)**:
  * Fila superior: Selector de documento origen (`From:`) usando un combobox premium.
  * Sección intermedia: Cabecera con columnas alineadas `Elements`, `Num` y `Count` directamente sobre el control `TreeView` (el cual ahora tiene `All` como nodo raíz con la suma total de elementos de forma jerárquica).
  * Sección inferior: Listado scrollable con checkboxes (`To:`) para elegir los documentos destino.
* **Columna Derecha (Filtros y Operaciones)**:
  * Agrupadas todas las tarjetas de configuración de copiado, transformaciones de coordenadas, renombrado de texto y conteo en un panel vertical scrollable con orientación derecha a izquierda (scrollbar a la izquierda).
  * Añadida la tarjeta dinámica de conteo `Elements Checked` en color azul que muestra en tiempo real cuántos elementos hoja han sido seleccionados.

### 2. Panel Inferior de Acciones
* Alineado en la parte inferior izquierda: Entrada `Filter Elements:` con su respectivo botón `Clear` y los switches avanzados de búsqueda (`Use OR`, `Only Use Names`, `Use Regex`).
* Enlazado dinámicamente en el ViewModel mediante la suscripción desacoplada de mensajes de cambio en el árbol `CheckedItemsChangedMessage` de `TreeItemViewModel`.
* Alineados en la parte inferior derecha: Los botones de acción principal (`Transfer Single`, `Select`, `View Log`).

## Verificación
* Se corrigió la inclusión del namespace `CommunityToolkit.Mvvm.Messaging` en `TreeItemViewModel.cs` para el envío del evento de conteo.
* El código compila completamente bajo la configuración `Debug.R24` del SDK de Revit 2024.
