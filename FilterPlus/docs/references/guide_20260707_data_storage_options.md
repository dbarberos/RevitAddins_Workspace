# Guía de Opciones de Almacenamiento y Persistencia de Datos en Revit

Este documento explica cómo el Add-in almacena información estructurada (como las selecciones guardadas) y qué opciones ofrece la API de Revit para garantizar que estos datos persistan entre diferentes sesiones y usuarios.

## 1. La Solución Adoptada: Extensible Storage (Almacenamiento Extensible)

La arquitectura actual de la aplicación utiliza **Extensible Storage**, que es el estándar de la industria y la opción más robusta y nativa proporcionada por la API de Revit para persistencia de datos complejos.

*   **Implementación:** Los datos (por ejemplo, listas de elementos seleccionados) se convierten a texto mediante serialización JSON. Este texto JSON se introduce de forma segura en un contenedor oculto (`Entity`) y se adhiere directamente a un elemento inborrable del proyecto de Revit llamado `ProjectInformation` (Información del Proyecto).
*   **Portabilidad Incondicional:** Dado que la información se almacena dentro de la propia base de datos del archivo `.rvt`, **los datos viajan siempre con el modelo**. Si el archivo se copia a otro ordenador, se envía a un cliente, o se sube a la nube (BIM 360 / ACC), las selecciones guardadas seguirán intactas y accesibles para cualquier sesión que ejecute el Add-in.
*   **Seguridad:** Los esquemas de Extensible Storage están protegidos por un `VendorId` único. Esto hace que la información sea invisible para el usuario estándar (no contamina las tablas de propiedades ni de planificación) y no pueda ser eliminada accidentalmente a menos que se use el propio Add-in.
*   **Requisito de Guardado:** Puesto que esta escritura altera la base de datos interna, el usuario debe **guardar el modelo de Revit (`Ctrl + S`)** antes de cerrarlo. De lo contrario, los cambios en las selecciones se descartarán junto con el resto de modificaciones del proyecto.

---

## 2. Alternativas en la API de Revit (y por qué se descartaron)

Para contexto arquitectónico, existen otras formas de persistir información, pero presentan desventajas significativas para este caso de uso:

### Opción A: Archivos Locales o Bases de Datos Externas (JSON / SQLite externos)
*   **Mecanismo:** El Add-in guarda un archivo en el disco duro (ej. `C:\Users\Nombre\AppData\...`).
*   **Motivo de descarte:** **No viaja con el archivo RVT.** Si el modelo se abre en otro puesto de trabajo, las selecciones no estarán disponibles. Se rompería la coherencia colaborativa.

### Opción B: Parámetros del Proyecto (Project Parameters)
*   **Mecanismo:** Se crea un parámetro de texto visible asignado a la categoría de Información de Proyecto, y se inyecta el JSON en él.
*   **Motivo de descarte:** El usuario puede visualizar ese campo de texto enorme en la paleta de propiedades. Podría editarlo manualmente, corromper el formato JSON o eliminar el parámetro por completo.

### Opción C: Filtros de Selección Nativos de Revit (`SelectionFilterElement`)
*   **Mecanismo:** La herramienta nativa de Revit que permite crear conjuntos en la pestaña *Gestionar -> Selección*.
*   **Motivo de descarte:** Tienen capacidades muy limitadas. No soportan almacenamiento de metadatos complejos (como jerarquías, reglas dinámicas, descripciones adicionales) y el usuario puede borrarlos muy fácilmente desde la interfaz de usuario sin control por parte del Add-in.

---

## Conclusión

El sistema de **Extensible Storage** empleado garantiza que las selecciones guardadas se comporten como un componente nativo, eficiente y portátil del proyecto, satisfaciendo completamente la necesidad de que la información esté disponible independientemente del ordenador o sesión desde donde se abra el archivo `.rvt`.
