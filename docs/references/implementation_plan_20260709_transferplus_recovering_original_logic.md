# Plan de Implementación: Migración y Recuperación de la Lógica de `TransferSingle` a `TransferPlus`

Este plan describe el proceso detallado para recuperar y adaptar el 100% de la lógica de negocio y los elementos de interacción de la UI del addin original `references_examples/TransferSingle` (desarrollado originalmente para Revit 2020) e integrarla en nuestro nuevo proyecto multi-versión **`TransferPlus`** para Revit 2024+, sustituyendo la interfaz WinForms por la vista WPF premium.

---

## 1. Justificación y Beneficios del Análisis del Código Heredado

El andamiaje inicial se realizó con una plantilla limpia de `Nice3point.Revit.Sdk` para asegurar la configuración multi-versión (.NET Framework 4.8 / .NET 8), WPF y ofuscación desatendida. Sin embargo, para no perder las complejas características de recolección de Revit (las 37 categorías, copiado recursivo de vistas dependientes/callouts, copiado de planos y traducción de coordenadas de vínculos), se recuperan y adaptan los archivos lógicos originales bajo las siguientes premisas:

1. **Recuperación Directa de la Lógica de Negocio (Core API)**: Reutilización de los algoritmos de extracción y mapeo de elementos sin necesidad de rediseñar las complejas dependencias y relaciones de bases de datos de Revit.
2. **Modernización de la Arquitectura (UI/UX)**: Abstracción de la interfaz gráfica WinForms obsoleta hacia un patrón desacoplado **MVVM (Model-View-ViewModel)** en WPF, mejorando la mantenibilidad.
3. **Actualización de la API de Revit (2024+)**: Adaptación de métodos e interfaces deprecadas al SDK moderno de Revit 2024+ para asegurar la compilación.
4. **Preservación del Workflow Familiar**: Conservación de reglas críticas ante duplicados y lógica de renombrado que los usuarios ya dominan.

---

## 2. Cambios de la API de Revit en la Modernización (2024+)

Para asegurar la correcta compilación y compatibilidad con Revit 2024 y versiones superiores, se han identificado y adaptado los siguientes elementos del API:
* **`ElementId.IntegerValue`**: Reemplazado por **`ElementId.Value`** (de tipo `Int64` / `long`) debido a la obsolescencia de los IDs de 32 bits en favor de los IDs de 64 bits en versiones recientes de Revit.
* **Sobrecarga de `get_Parameter(int)`**: Reemplazada mediante el casteo explícito de los enteros de BuiltInParameters utilizando **`el.get_Parameter((BuiltInParameter)id)`**.
* **Tipos de almacenamiento (`StorageType`)**: Actualización de comparaciones numéricas directas (`StorageType == 4`) a la enumeración tipada de Revit **`StorageType == (StorageType)4`** o su equivalente nominal.

---

## 3. Estructura de la Interfaz en Dos Columnas (WPF / MVVM)

La vista principal `TransferPlusView.xaml` ha sido adaptada para organizar de manera eficiente el espacio y optimizar el flujo de trabajo:
* **Columna Izquierda (Flujo de Transferencia)**:
  * **From**: Selector combobox del documento origen.
  * **What**: Tabla/Explorador jerárquico de categorías, familias y tipos (TreeView con columnas alineadas para Nombre, Num y Cantidad de elementos).
  * **To**: Lista de documentos abiertos destino con selectores de tipo checkbox.
* **Columna Derecha (Opciones y Configuración)**:
  * **Include Links**: Reglas de coordenadas y transformaciones espaciales (None, Link, Shared Coordinates).
  * **Manage Checked**: Acciones rápidas sobre el texto de los ítems seleccionados (Eliminar, Añadir prefijos/sufijos, cambiar de caja tipográfica, Buscar y Reemplazar).
  * **Options**: Resolución de duplicados (Sobrescribir, Cancelar, Preguntar) y vinculación de elementos de vista (Leyendas, Tablas, etc.).

---

## 4. Archivos Recuperados y Adaptados en TransferPlus

### A. Modelos y Estructuras de Datos
* **[Elemento.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Models/Elemento.cs)**: Mantiene propiedades vitales como `IsView`, `IsLegend`, `IsSheet`, `IsSchedule`, `IsWorkset`, `SheetNumber`, `NoTransferible`, `wID` y `eID`.
* **[Nodo.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Models/Nodo.cs)**: Mantiene la agrupación jerárquica de categorías (All -> Categoría -> Familia -> Tipo -> Elementos).
* **[Archivo.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Models/Archivo.cs)**: Mapea los documentos vinculados y abiertos de la sesión activa de Revit.
* **[Estructura.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Models/Estructura.cs)**: Estructura contenedora del árbol de elementos y logs.
* **[Configuraciones.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Models/Configuraciones.cs)**: Serialización de los parámetros del usuario (evitando dependencias obsoletas de coordenadas WinForms).

### B. Servicios y Lógica de Negocio
* **[Serializaciones.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/Serializaciones.cs)**: Gestión del guardado/cargado de configuraciones XML en disco.
* **[DocumentCollector.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/DocumentCollector.cs)**: Implementa los 37 `FilteredElementCollector` originales y reporta el progreso actual de forma asíncrona a la interfaz WPF.
* **[TransferOrchestrator.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/TransferOrchestrator.cs)**: Centraliza la ejecución de las copias físicas (`ElementTransformUtils`), la traducción geométrica de vínculos y el manejo silencioso de advertencias mediante un `WarningSwallower` nativo.

### C. Capa de Presentación
* **[TransferPlusViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/ViewModels/TransferPlusViewModel.cs)**: Gestiona la reactividad, los comandos de renombrado, y la actualización de los contadores de selección.
* **[TransferPlusView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/TransferPlusView.xaml)**: Ventana WPF premium con diseño de dos columnas, tarjetas y barras de progreso flotantes.

---

## 5. Plan de Verificación
1. **Compilación en Revit SDK (R24)**: Validar con `dotnet build` usando perfiles multi-versión.
2. **Pruebas de Transacciones**: Asegurar que todas las transacciones de Revit estén adecuadamente contenidas en bloques `using`.
3. **Verificación de Coordenadas**: Comprobar el traslado geométrico de familias hospedadas en vínculos Revit.
