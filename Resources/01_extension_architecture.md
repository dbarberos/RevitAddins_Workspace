Me parece una excelente iniciativa. Siguiendo la filosofía de "revelación progresiva" detallada en tus fuentes (`Guia\_pyRevit\_base.txt`), estructuraremos el conocimiento en archivos individuales y separados. Esto no solo creará un repositorio robusto y escalable, sino que le dará al agente de IA un contexto mucho más enfocado y limpio al cual recurrir, repleto de buenas prácticas y código real de las lecciones.



Para respetar tu directriz, te entregaré la primera guía ahora y te preguntaré si deseas continuar con la siguiente.



Empezaremos con el primer documento que define las bases absolutas para crear herramientas, estructurar la interfaz y reutilizar código.



\*\*\*



\### Archivo: `pyrevit-dev-mentor/references/01\_extension\_architecture.md`



\# Guía de Arquitectura de Extensiones y Herramientas en pyRevit



\## 1. Jerarquía de Carpetas de pyRevit

Para que pyRevit reconozca una herramienta, la estructura de carpetas debe seguir un esquema estricto de sufijos que imita la jerarquía de la interfaz de usuario (UI) de Revit.



\*   \*\*`.extension`\*\*: La carpeta raíz de tu paquete corporativo (ej. `MisHerramientas.extension`).

\*   \*\*`.tab`\*\*: Define la pestaña en la cinta de opciones superior de Revit (ej. `Arquitectura.tab`).

\*   \*\*`.panel`\*\*: Un bloque o grupo de botones dentro de la pestaña (ej. `Automatizacion.panel`).

\*   \*\*Tipos de Botones\*\*:

&#x20;   \*   \*\*`.pushbutton`\*\*: Un botón estándar que ejecuta un script.

&#x20;   \*   \*\*`.pulldown`\*\*: Un menú desplegable que agrupa varios `.pushbutton` en su interior para ahorrar espacio.

&#x20;   \*   \*\*`.stack`\*\*: Permite apilar botones pequeños verticalmente.

\*   \*\*`script.py`\*\*: El archivo Python obligatorio que contiene la lógica de tu herramienta. Debe terminar exactamente así para ser reconocido.



\## 2. Configuración del Botón (`bundle.yaml` y Metadatos)

Dentro de la carpeta de tu botón (ej. `Renombrar.pushbutton`), es obligatorio usar un archivo `bundle.yaml` para definir cómo se presenta la herramienta al usuario. 



\### A. Archivo `bundle.yaml`

Este archivo controla el título, descripción e incluso cuándo debe estar disponible el botón:



```yaml

title: Renombrado Masivo

tooltip: |

&#x20; Aplica un renombrado a las vistas seleccionadas.

&#x20; Shift + Click: Elimina el prefijo en lugar de agregarlo.

author: Tu Nombre

context: ProjectDocument

```

\*\*El concepto de `context` (Contexto):\*\*

El atributo `context` es una práctica avanzada que indica a pyRevit cuándo activar o deshabilitar (poner en gris) el botón.

\*   `ProjectDocument`: Solo se activa si hay un proyecto abierto (se deshabilita en familias).

\*   `ZeroDoc`: La herramienta puede ejecutarse incluso si no hay ningún documento abierto en Revit (ej. para abrir enlaces web o configuraciones).

\*   `Selection`: Requiere que el usuario seleccione un elemento en la vista antes de ejecutarse.



\### B. Iconos y Tooltips (Recomendaciones)

\*   \*\*Mejor práctica de Iconos:\*\* Usa siempre un archivo nombrado `icon.png` con resolución de \*\*96x96 píxeles\*\* para la mejor calidad. Sitios como \*Icons8\* son ideales para mantener consistencia visual.

\*   \*\*Mejor práctica de Tooltips:\*\* Los \*tooltips\* (descripciones al pasar el ratón) deben describir claramente si el script requiere una selección previa y advertir si la acción \*\*elimina\*\* elementos del modelo para evitar sustos.



\## 3. Lógica Alternativa (El poder de "Shift + Click")

Una de las funciones más potentes de pyRevit es poder darle dos usos al mismo botón. Por ejemplo, Click normal "Añade" revisiones, y Shift + Click las "Elimina".



Para lograr esto, importamos la clase `EXEC\_PARAMS` y leemos el `config\_mode`:



```python

from pyrevit import EXEC\_PARAMS



\# Detecta si el usuario está ejecutando con Shift+Click

modo\_alternativo = EXEC\_PARAMS.config\_mode



if modo\_alternativo:

&#x20;   print("Modo de eliminación activado (Shift+Click)")

&#x20;   action = "remove"

else:

&#x20;   print("Modo estándar: Añadir revisión")

&#x20;   action = "apply"

```

\*Nota: Si vas a requerir ajustes de configuración de la herramienta (ej. que recuerde si debe usar un patrón de corte o no), pyRevit guardará automáticamente las opciones en su configuración si diseñas tu script para ello\*.



\## 4. Reutilización de Código (Carpetas `lib`)

A medida que la extensión crece, no debes repetir código (ej. funciones para borrar elementos o crear transacciones) en cada script. Tienes dos métodos para estandarizar código:



\### A. La carpeta interna `lib`

En la raíz de tu `.extension`, crea una carpeta llamada `lib` y dentro, añade carpetas de módulos con el archivo obligatorio `\_\_init\_\_.py`. Todos los botones de esa extensión tendrán acceso a ella automáticamente.



\### B. Extensiones de Librería (`.lib`)

Para corporaciones grandes, puedes crear una extensión separada con el sufijo `.lib` (ej. `CoreCompany.lib`). pyRevit cargará esta ruta globalmente y \*\*todas tus diferentes extensiones\*\* podrán importar sus métodos en Python (ej. `import my\_company\_standards`).



\## 5. Implementación Rápida y Plantillas

\*   \*\*EF-pyRevit StarterKit:\*\* En lugar de crear toda esta estructura de carpetas a mano, se recomienda el uso del "EF-pyRevit StarterKit" mencionado en las lecciones, el cual genera toda la plantilla de la extensión base, incluyendo módulos estándar, en apenas 2 minutos.



\*\*\*





