# Tareas de Implementación: KreanRender

- [x] **Fase 1: Configuración de la Interfaz WPF (Revit Add-in)**
  - [x] Crear el esqueleto principal del Add-in (`KreanRender.addin`, `Application.cs`, `Command.cs`).
  - [x] Diseñar el archivo `.xaml` con:
    - [x] Cabecero dinámico que muestre el nombre de la vista actual.
    - [x] Caja de texto para introducir el *prompt* manualmente.
    - [x] Checkbox: "Usar API de Gemini (saltar modelo local)".
    - [x] Caja de texto para inyectar la *API Key* de Gemini (mostrada/habilitada si el checkbox está activo).
    - [x] Botones para exportar/analizar vista y para "Renderizar".
    - [x] Visualizador de la imagen original y de la imagen renderizada.

- [x] **Fase 2: Lógica Interna de Revit (C#)**
  - [x] Extraer la imagen de la vista activa (usando `ImageExportOptions`).
  - [x] Leer los elementos visibles de la vista e iterar para obtener sus materiales.
  - [x] Serializar los datos (Imagen base64, Prompt, Configuración: Gemini vs Local) y enviarlos mediante `HttpClient` por `POST` al servidor Python.

- [x] **Fase 3: Servidor Python Backend**
  - [x] Iniciar un script con `gradio` o `fastapi` local, accesible desde Revit.
  - [x] Implementar la **Ruta Local**: Configuración `diffusers` (ej: Stable Diffusion v1.5 + ControlNet) leyendo el prompt enviado.
  - [x] Implementar la **Ruta Gemini**: Lógica que puentea hacia `google.generativeai` generando la imagen vía API si se marcó el checkbox.

- [ ] **Fase 4: Pruebas e Integración**
  - [ ] Correr el script Python en segundo plano.
  - [ ] Compilar y ejecutar KreanRender en Revit 2024.
  - [ ] Probar extracción de parámetros y renderizado.
