# Plan de Recuperación y Modernización: TransferSingle a TransferPlus

Este plan documenta la estrategia de recuperación, análisis y modernización del add-in heredado **TransferSingle** (originalmente diseñado para Revit 2020) y su evolución a la versión **TransferPlus** (compatible con Revit 2024 y versiones superiores).

El propósito principal de este add-in es permitir la transferencia selectiva de elementos, configuraciones y reglas entre diferentes modelos de Revit abiertos, sin la necesidad de transferir todo el paquete completo del proyecto (evitando la sobrecarga y posibles corrupciones al usar la transferencia de normas de proyecto por defecto de Revit).

---

## Beneficios del Análisis de Código Heredado (Legacy Code)

El uso de la base de código original depositada en `references_examples/TransferSingle` sirve como un acelerador y garantía de calidad gracias a los siguientes pilares de desarrollo:

1. **Recuperación Directa de la Lógica de Negocio (Core API)**
   * **Propósito**: Identificar y extraer el flujo exacto de extracción de datos, filtrado de elementos del modelo origen y su posterior duplicación/creación en el modelo destino.
   * **Implementación**: Reutilización directa de los algoritmos de copia de familias, leyendas, tablas de planificación y elementos de vista, optimizando los tiempos de desarrollo al no tener que rediseñar las reglas de relación complejas del API de Revit.

2. **Modernización de la Arquitectura (UI/UX)**
   * **Propósito**: Migrar una interfaz antigua monolítica construida en Windows Forms (WinForms) altamente acoplada al código, hacia un patrón moderno de desacoplamiento.
   * **Implementación**: Implementación del patrón **MVVM (Model-View-ViewModel)** mediante WPF (Windows Presentation Foundation) y CommunityToolkit.Mvvm, separando la interfaz de usuario de la ejecución de comandos de Revit.

3. **Actualización de la API de Revit a Versiones Modernas (2024+)**
   * **Propósito**: Corregir llamadas deprecadas o eliminadas de la API de Revit del SDK 2020 para asegurar la compatibilidad con el nuevo compilador y las versiones más recientes.
   * **Implementación**: Actualización del uso de `ElementId.IntegerValue` a `ElementId.Value`, eliminación de sobrecargas obsoletas de transacciones, uso de los nuevos namespaces del SDK de Revit y adaptación de los tipos de almacenamiento (`StorageType`).

4. **Preservación del Flujo de Trabajo Original (UX Familiar)**
   * **Propósito**: Mantener las opciones clave que resuelven los problemas del usuario en el día a día.
   * **Implementación**: Preservación del comportamiento ante duplicados (Sobrescribir, Cancelar, Preguntar), configuración de importación de vistas de leyenda/tablas de planificación y lógica de renombrado masivo mediante expresiones regulares y búsquedas.

---

## Estructura del Add-in y Estrategia de Migración

### 1. Elementos Clave del Origen (`TransferSingle`)
- **Interfaz Monolítica (`TransferSingle.cs` / `formgeneral.cs`)**: Contiene controles WinForms embebidos directamente con llamadas a la base de datos de Revit.
- **Modelo de Datos (`Elemento.cs`, `Nodo.cs`, `Archivo.cs`)**: Gestiona la jerarquía del árbol de selección.
- **Herramientas de Renombrado (`RenameText.cs`, `TakeText.cs`)**: Pequeñas ventanas auxiliares para pedir textos de prefijos, sufijos y reemplazos.

### 2. Destino Modernizado (`TransferPlus`)
- **Vistas (`TransferPlusView.xaml`)**: Interfaz premium de dos columnas. Columna izquierda dedicada a la selección del origen (`From`), árbol de elementos (`What`) y modelos destino (`To`). Columna derecha dedicada a las opciones de renombrado rápido y reglas de importación.
- **ViewModels (`TransferPlusViewModel.cs`)**: Gestiona los comandos y la reactividad de la interfaz de forma asíncrona, previniendo el congelamiento de Revit.
- **Orquestador (`TransferOrchestrator.cs`)**: Centraliza la lógica de copiado y transacciones limpias de Revit.

---

## Plan de Verificación

### Pruebas Funcionales
- **Selección de Modelos**: Validar que el ComboBox origen solo muestre documentos abiertos y no permita seleccionar el mismo que el destino.
- **Operaciones de Transferencia**: Comprobar la copia limpia de leyendas, tipos de familias y vistas entre los documentos activos.
- **Acciones de Texto**: Verificar que los botones "Add Suffix", "Add Prefix" y "Find Replace" alteren correctamente las propiedades de renombrado de los elementos seleccionados antes del traspaso.
