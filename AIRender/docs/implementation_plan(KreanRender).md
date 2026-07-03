# Plan de Implementación: KreanRender

El objetivo central es desarrollar un ecosistema compuesto por un **Add-in de Revit (C#)** y un **Servidor Python (Gradio)**. El Add-in exportará la vista actual (y extraerá los materiales de los elementos visibles) enviándolos al servidor. El servidor usará Gemini Pro (para deducir un *prompt* avanzado basado en los materiales) y un modelo de generación de imágenes (para producir el render fotorrealista conservando la geometría) antes de devolverlo a Revit.

## Arquitectura Propuesta

La solución se dividirá en dos módulos principales:

### 1. Revit Add-In (`KreanRender`) (C# / .NET 7.0+ para Revit 2024)
- **Extracción de Vista:** Usará la API de Revit (`Document.ExportImage`) para guardar la vista actual 3D o alzado temporalmente.
- **Extracción de Materiales:** Usará un `FilteredElementCollector` para analizar los elementos visibles en la vista, extrayendo los nombres de los materiales (ej: Hormigón, Vidrio, Acero).
- **Interfaz (WPF):** Una ventana interactiva donde el usuario puede ver la imagen exportada, decidir si quiere añadir un *prompt* manual o usar los materiales extraídos automáticamente, y un botón de "Renderizar".
- **Comunicación HTTP:** Enviará la imagen y los datos (materiales/prompt) vía HTTP `POST` a la API del servidor Python local. 

### 2. Servidor Backend de IA (Python / Gradio)
- **Servidor Web Rápido:** Utilizaremos la librería `gradio`. Además de darnos una interfaz web muy vistosa para "debuggear" el modelo en el navegador, expone automáticamente una API (`/api/predict` o clientes de Gradio) a la que el Add-in de Revit se puede conectar.
- **Motor NLP (Gemini Pro):** Usaremos el SDK de Google Generative AI (`google.generativeai`) con tu API Key. Gemini tomará la lista cruda de materiales (ej: `["Ladrillo Visto", "Cristal Reflectante", "Aluminio Negro"]`) y creará un *prompt* en inglés altamente optimizado para modelos de difusión (ej: `"A highly detailed, photorealistic architectural render of a modern facade featuring exposed brick, reflective glass windows, and black aluminum frames, cinematic lighting, 8k..."`).
- **Motor de Renderizado ("Nano Banana" / ControlNet):** 
  - *Nota sobre "Nano Banana": Asumo que esto podría ser un typo para algún modelo de vanguardia o servicio rápido (como LCM, Banana.dev, o Modelos rápidos estilo FLUX).* 
  - La mejor estrategia para arquitectura es **ControlNet (Canny o MLSD)** combinado con un modelo base potente como **SDXL** o usar la API gratuita/de pago de Hugging Face. El ControlNet asegura que la imagen generada respete el 100% de las líneas de la fachada exportadas desde Revit, y el *prompt* de Gemini le aplicará las texturas e iluminación fotorrealistas.

---

## Fases de Desarrollo

### Fase 1: Backend Python (Gradio Server)
1. Instalar dependencias (`gradio`, `google-generativeai`, `requests`, y cliente HF si procede).
2. Crear la lógica de **Gemini Pro**: Función que reciba lista de materiales y retorne un *prompt* de imagen.
3. Crear la lógica de **Renderizado**: Función que consuma la API de inferencia de Hugging Face (ej. un pipeline Image-to-Image o ControlNet) pasándole la imagen de Revit y el *prompt* de Gemini.
4. Levantar el endpoint de Gradio.

### Fase 2: Proyecto Revit Add-In (`KreanRender`)
1. Crear el manifiesto (`KreanRender.addin`) y estructura base (`Application.cs`, `Command.cs`).
2. Implementar la extracción de imagen (`ImageExportOptions`).
3. Implementar un colector para iterar la vista activa, buscar sólidos y recolectar IDs/nombres de Elementos y **Materiales**.
4. Crear la ventana WPF que haga de cliente, llamando al servidor local (ej. `http://127.0.0.1:7860/api`).

### Fase 3: Pruebas e Iteración
1. Abrir Revit, lanzar "KreanRender" y probar el flujo completo con una fachada simple.
2. Ajustar los parámetros de ControlNet (fuerza, umbrales) en Python para mejorar el realismo arquitectónico.

---

## Preguntas Abiertas y Decisiones

> [!CAUTION]
> **Modelo de Imagen**: Mencionaste "nano banana". ¿Te referías a algún servicio de alojamiento rápido (como *Banana.dev*), a un modelo en particular, o fue un error ortográfico y te refieres a cualquier modelo veloz que sirva bien para arquitectura (como FLUX.1-schnell o SDXL con ControlNet local)? Si prefieres que Python lo ejecute en local en tu GPU o a través de la API en la nube (Hugging Face / externa).

> [!IMPORTANT]
> **API Key de Gemini**: Para que el servidor de Python se comunique con Gemini Pro necesitaremos inyectar tu API Key en las variables de entorno (`GEMINI_API_KEY`). ¿Tienes la API Key a mano para configurarla una vez empecemos?

> [!NOTE]
> **Preferencia de UI**: ¿Prefieres que el usuario pase más tiempo reajustando parámetros en la Interfaz de Gradio (navegador), o diseñamos la interfaz WPF en Revit para que se pueda hacer **todo** sin salir del programa de Autodesk?

## Plan de Verificación

### Pruebas Automatizadas/Técnicas
- Consumir el endpoint de Gradio vía un script Python de prueba con una imagen falsa para asegurar que todo el puente Gemini -> Modelo HF responde correctamente.

### Comprobación Manual
- Compilaremos y cargaremos el Add-in en Revit 2024.
- Abriremos una vista 3D de una fachada, lanzaremos el Add-in y verificaremos que (1) captura la imagen y materiales sin saturar memoria, (2) el servidor Python devuelve una imagen fotorrealista renderizada.
