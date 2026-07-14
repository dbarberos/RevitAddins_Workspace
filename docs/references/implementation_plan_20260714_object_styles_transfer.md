# Plan de Implementación: Descomposición de Estilos de Objeto en TransferPlus

Este plan describe la incorporación de los **Estilos de Objeto (Object Styles)** como una categoría seleccionable e individualizada en el explorador del Add-in, permitiendo transferir la configuración de estilo (grocores, colores, patrones de línea y materiales) de categorías específicas (como Muros, Puertas o Anotaciones) de manera selectiva.

También se incluye un análisis comparativo entre las capacidades nativas de transferencia de Revit y las de TransferPlus para identificar posibles ausencias.

---

## Análisis Comparativo de Normas (Revit Nativo vs. TransferPlus)

Revit transfiere categorías completas como bloques cerrados. En contraste, **TransferPlus** permite descomponer casi todas las categorías en elementos individuales. A continuación se detallan los elementos nativos mostrados en tus capturas de pantalla y su cobertura en el Add-in:

### 1. Elementos ya cubiertos por TransferPlus
* **Tipos de [Familia/Muro/Ventana/etc.]**: Expuestos y descomponibles de forma individual en el Add-in en el paso de `Element Types` (Paso 1).
* **Filtros**: Expuestos individualmente (Paso 2).
* **Plantillas de vista**: Expuestas individualmente (Paso 3).
* **Organización del navegador**: Expuesta individualmente (Paso 4).
* **Configuración de impresión y configuración de revisión**: Expuestas individualmente (Pasos 12 y 18).
* **Materiales y Patrones de relleno/línea**: Expuestos individualmente (Pasos 10, 20 y 21).
* **Parámetros de proyecto e Información de proyecto**: Expuestos individualmente (Pasos 23 y 14).
* **Plantillas de tabla de planificación de paneles**: Expuestas individualmente (Paso 9).

### 2. Elementos ausentes que no son descomponibles
* **Grosores de línea**: Son tablas globales del documento y no elementos con ID. No se descomponen; se aplican de forma global.
* **Configuraciones de ingeniería (MEP/Estructura/Ductos/Tuberías)**: Configuración global interna del documento. No se pueden copiar mediante copia estándar de elementos (`CopyElements`) porque causan duplicados en singletons.
* **Estilos de objeto (Object Styles)**: **Falta actualmente en el Add-in**. Implementaremos su descomposición a continuación.

---

## Diseño Técnico para Estilos de Objeto

### 1. Recolección de Categorías de Estilo (`DocumentCollector.cs`)
Iteraremos sobre `doc.Settings.Categories` para recolectar las categorías raíz que definen estilos de objeto. Las organizaremos de la siguiente forma:
* **Categoría en el Explorador**: `"Object Styles"` (Estilos de objeto).
* **Familia (Disciplina/Pestaña)**: Mapeado según el `CategoryType` de Revit para coincidir con las pestañas nativas:
  * `Model` -> `"Model Objects"`
  * `Annotation` -> `"Annotation Objects"`
  * `AnalyticalModel` -> `"Analytical Model Objects"`
  * Si es una categoría personalizada/importada (`Id.Value > 0`) -> `"Imported Objects"`
* **Nombre**: Nombre de la categoría (ej. `"Walls"`, `"Doors"`, `"Dimensions"`).
* **ElementId (`eID`)**: Almacenaremos el ID de la categoría (que es un valor entero negativo en categorías del sistema, ej. `-2000011` para Muros). La API de Revit soporta IDs negativos para categorías integradas.

### 2. Lógica de Transferencia (`TransferOrchestrator.cs`)
Los estilos de objeto no se pueden transferir usando `ElementTransformUtils.CopyElements` porque no son elementos físicos de base de datos.
Implementaremos un proceso personalizado para los elementos donde `IsObjectStyle == true`:
1. Identificar la categoría en el modelo origen y destino por ID.
2. Copiar sus propiedades:
   * **Grosor de línea de Proyección**: `sourceCat.GetLineWeight(GraphicsStyleType.Projection)`
   * **Grosor de línea de Corte** (si es cortable): `sourceCat.GetLineWeight(GraphicsStyleType.Cut)`
   * **Color de línea**: `sourceCat.LineColor`
   * **Patrón de línea**: Transferir y asignar el patrón de línea asociado.
   * **Material**: Transferir y asignar el material asociado.
3. Si la categoría tiene subcategorías, transferiremos recursivamente todos los estilos de sus subcategorías.

### 3. Copia de Dependencias (Materiales y Patrones de Línea)
Para evitar que se pierdan las referencias a materiales o patrones de línea personalizados al transferir el estilo:
* Crearemos métodos auxiliares (`TransferLinePattern` y `TransferMaterial`) que buscarán si el patrón/material ya existe en el documento destino por su nombre.
* Si no existe, lo copiarán automáticamente desde el origen usando `CopyElements` para asegurar que el estilo se visualice idéntico en el destino.

---

## Preguntas y Decisiones para el Usuario

> [!IMPORTANT]
> **Subcategorías en el Explorador**:
> ¿Prefieres que cada subcategoría (por ejemplo, "Líneas ocultas" dentro de "Muros") se muestre como un elemento seleccionable individual en el árbol, o prefieres seleccionar la categoría raíz (ej. "Muros") y que se transfiera todo su estilo junto con todas sus subcategorías internas a la vez?
>
> *Recomendación*: Transferir la categoría raíz junto con todas sus subcategorías es más limpio y evita saturar el explorador con miles de subcategorías menores.

---

## Plan de Verificación

### Pruebas Manuales
1. Abrir el Add-in y verificar que aparece el grupo `"Object Styles"` en el árbol.
2. Comprobar que está dividido por familias: `"Model Objects"`, `"Annotation Objects"`, etc.
3. Seleccionar únicamente la categoría `"Muros"` (Walls).
4. Ejecutar la transferencia al modelo de destino.
5. Abrir el modelo de destino en Revit, ir a *Estilos de objeto* y verificar que el grosor, color, patrón y material de la categoría Muros coincide exactamente con el origen.
