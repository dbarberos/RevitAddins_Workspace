# Plan de Implementación: Autoejecución del Servidor Python

El objetivo es eliminar la fricción técnica para el usuario final. El usuario de Revit **no debería ver una terminal ni saber qué es Python**. Todo debe instalarse y lanzarse "entre bambalinas".

## Estrategia Propuesta

Implementaremos un **"Bootstrapper" (Trazador de Arranque) en C#** integrado directamente dentro de KreanRender.

### 1. Detección y Uso de "Python Integrado" (Portable Python)
- En lugar de requerir que el usuario instale Python o Docker, el instalador del Add-in entregará un directorio llamado `PythonRuntime`.
- Se tratará de una versión auto-contenida (Portable/Embedded) de Python de Windows.
- El Add-in C# nunca llamará al `python` del sistema, sino que ejecutará la ruta relativa: `.\PythonRuntime\python.exe app.py`.

### 2. Auto-Instalación Silenciosa (Si es necesario)
- La ventaja de usar Python Embebido es que podemos entregar un `.zip` del Add-in que ya contenga todas las dependencias (`torch`, `diffusers`, `gradio`) pre-descargadas de nuestro lado.
- El usuario solo instala el Add-in, la carpeta pesará algunos gigas, pero no tendrá que **descargar ni instalar nada** durante el uso de Revit. Cero carga, cero esperas, "Plug & Play".

### 3. Cierre Limpio
- Cuando se cierre Revit (o mediante el gestor de tareas interno), el Add-in enviará una orden de cierre (Kill Process) a nuestro `python.exe` independiente para no consumir memoria residual.

---

## Modificaciones en Código

### [MODIFY] [StartupCommand.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/KreanRender/Commands/StartupCommand.cs)
Añadiremos una llamada a un servicio `PythonServerManager.StartServerIfNotRunning()` justo antes de levantar la ventana WPF.

### [NEW] `KreanRender.Services.PythonServerManager`
Una clase especializada en:
- Buscar la ruta de instalación de Python en la máquina del usuario (o usar la variable de entorno PATH).
- Ejecutar un subproceso (`cmd.exe /c python app.py`) manteniéndolo oculto de la vista.
- Comprobar vía HTTP Ping rápido si la API de Python ya está despierta.

### [NEW] `run_server.bat` / `install.bat`
Scripts auxiliares locales acompañando al Add-in para instalar bibliotecas con `pip install -r requirements.txt`.

---

## Preguntas Abiertas y Decisiones

> [!CAUTION]
> **El problema con Docker**: Desplegar Docker con un Add-in de Revit es problemático para usuarios no técnicos porque requiere obligarles a instalar "Docker Desktop", habilitar la virtualización en su BIOS y disponer del subsistema de Windows WSL2. Docker Desktop, además, tiene licencias de pago para empresas medianas. La solución **Portable Python (Python Embebido)** garantiza el aislamiento exacto que buscas (como un contenedor) pero sin requerir la virtualización pesada de Docker. ¿Te encaja este enfoque empaquetado?

> [!IMPORTANT]
> **Peso del Instalador Final**: Al incluir dependencias pre-instaladas (Torch y Diffusers) y posiblemente un modelo base para trabajar puramente offline, el paquete de instalación del Add-in pasará de pesar un par de MBs a **pesar entre 5 GB y 8 GB**. Para distribución de herramientas IA esto es habitual, pero debes tener en consideración los tiempos de descarga de tu aplicación para la empresa.
