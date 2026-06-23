***

### Archivo: `pyrevit-dev-mentor/references/02_wpf_mvvm_ui_design.md`

# Guía de Diseño de Interfaces: pyRevit Forms, WPF y Patrón MVVM

El desarrollo de herramientas para Revit requiere interactuar con el usuario para pedir datos o selecciones. pyRevit ofrece dos caminos principales: utilizar su librería integrada de formularios rápidos (`pyrevit.forms`) o, para herramientas más complejas, crear interfaces gráficas modernas usando WPF y el patrón MVVM.

## 1. Formularios Rápidos (`pyrevit.forms`)
Para scripts sencillos, pyRevit incluye una gran variedad de ventanas preconstruidas que te ahorran tener que diseñar una interfaz desde cero.

### A. Alertas y Mensajes (`forms.alert`)
Es una forma excelente de controlar el flujo del script (Flow Control) e interrumpir procesos si el usuario comete un error.
**Mejor práctica:** Utiliza alertas para advertir al usuario y cancela la ejecución mediante `script.exit()`.
```python
from pyrevit import forms, script

if not mi_seleccion:
    # Mostramos alerta y detenemos el script
    forms.alert("No has seleccionado ninguna revisión.", title="Script Cancelado", warn_icon=False)
    script.exit()
```

### B. Selección de Listas (`forms.SelectFromList`)
Permite al usuario elegir elementos de una lista generada por tu script. Soporta selección múltiple y posee una barra de búsqueda integrada.

**El Truco del `TemplateListItem` (Un "ViewModel" simplificado):**
Cuando envías elementos de Revit (ej. *ViewTemplates*) directamente a una lista, pyRevit suele mostrar su representación en código (`Autodesk.Revit.DB...`), lo cual no es legible para humanos. La mejor práctica es crear una clase personalizada heredada de `forms.TemplateListItem` para mostrar un nombre amigable en la interfaz (Front-end), pero pasar el ID del elemento o el objeto real por detrás (Back-end).

```python
from pyrevit import forms

# 1. Definimos la clase para "traducir" el objeto a la interfaz
class TemplateParaPurgar(forms.TemplateListItem):
    @property
    def name(self):
        # Mostramos solo el nombre del Template al usuario
        return self.item.Name 

# 2. Aplicamos la clase a nuestra lista de templates usando 'List Comprehension'
opciones_ui = [TemplateParaPurgar(vt) for vt in templates_unused]

# 3. Mostramos la ventana al usuario
seleccionados = forms.SelectFromList.show(
    opciones_ui,
    title="Selecciona Templates a Purgar",
    button_name="Purgar",
    multiselect=True
)
```

## 2. Interfaces Avanzadas con WPF (Windows Presentation Foundation)
Si necesitas una ventana totalmente personalizada (con campos de texto, menús desplegables múltiples, imágenes, etc.), debes usar el framework **WPF**. 

El desarrollo con WPF en pyRevit requiere estrictamente el uso de **dos archivos separados**:
1.  **Script XAML (Front-end):** Un archivo similar al HTML pero diseñado para aplicaciones de escritorio. Define el diseño visual (botones, listas, contenedores).
2.  **Script IronPython (Back-end):** Es la lógica que proveerá los datos de Revit, monitoreará los eventos (como clics en botones) y reaccionará a ellos.

**Mejor práctica (Uso de Inteligencia Artificial):**
Escribir código XAML desde cero tiene una curva de aprendizaje pronunciada. Se recomienda encarecidamente utilizar IA (como ChatGPT) para generar la estructura XAML básica proporcionándole un "esqueleto" funcional (como el que se incluye en los starter kits de pyRevit), y luego ajustar el diseño.

## 3. El Patrón de Diseño MVVM
Cuando usas WPF, la arquitectura de tu herramienta debe seguir el patrón de diseño **MVVM (Model-View-ViewModel)**. Este patrón sirve para separar completamente el diseño gráfico del código lógico, haciendo que tu herramienta sea más limpia y fácil de mantener.

*   **Model (Modelo):** Es tu script principal de Python. Es la parte que sabe cómo usar la API de Revit para recolectar datos (ej. obtener todas las vistas del proyecto) y ejecutar las reglas de negocio.
*   **View (Vista):** Es el archivo XAML. Muestra la información visualmente para que el usuario interactúe.
*   **View Model (Modelo de Vista):** Actúa como el **traductor** en medio de ambos. Prepara los datos "crudos" que sacaste de la API de Revit en el *Model* y los envuelve en clases y formatos compatibles para que el archivo XAML (*View*) los pueda leer y renderizar correctamente (por ejemplo, tomar una lista de vistas y adaptarlas para que encajen en un bloque `ListBox` visual).

## 4. Evolución a Complementos (C#)
Si en el futuro tu herramienta WPF de IronPython crece tanto que necesitas proteger el código fuente (compilarlo) y mejorar su velocidad de ejecución, la ruta recomendada es migrar a C#.
Para ello, existe la plantilla **`revit-wpf-template`** (disponible en GitHub). Esta plantilla te proporciona una estructura preconfigurada para Visual Studio que ya integra WPF y ejecuta comandos externos válidos dentro del contexto correcto de la API de Revit.
*   *Nota de mantenimiento:* Al usar esta plantilla de C#, es obligatorio refactorizar los nombres de espacio (namespaces), los nombres de los ensamblados y crear nuevos GUIDs para evitar conflictos con otras aplicaciones.

***
