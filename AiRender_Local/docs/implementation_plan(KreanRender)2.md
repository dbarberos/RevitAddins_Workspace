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
- **Motor NLP (Gemini Pro):** Usaremos el SDK de Google Generative AI (`google.generativeai`) con tu API Key. Gemini tomará la lista cruda de materiales y creará un *prompt* optimizado.
- **Motor de Renderizado (Gemini Imagen / Local Free Models):** 
  - Siguiendo tu directriz de máxima accesibilidad sin cuentas externas:
  - **Opción A (Gemini):** Dado que ya tienes una API Key de Gemini, usaremos el endpoint de generación de imágenes de Gemini (Imagen 3) si lo que buscamos es renderizado puro por *prompt*.
  - **Opción B (Local / ControlNet):** Si necesitamos respetar estrictamente las líneas de Revit, el servidor Python descargará automáticamente una vez (transparente para el usuario) un modelo ligero de `diffusers` (como SD v1.5 + ControlNet Canny) que corre 100% en local. Esto asegura que *cualquier* usuario pueda usar la herramienta sin crear cuentas en Hugging Face o pagar servicios a terceros.

---

## Fases de Desarrollo

### Fase 1: Backend Python (Gradio Server)
1. Instalar dependencias (`gradio`, `google-generativeai`, `requests`, y cliente HF si procede).
2. Crear la lógica de **Gemini Pro**: Función que reciba lista de materiales y retorne un *prompt* de imagen.
3. Crear la lógica de **Renderizado**: Función que haga uso de la API de Gemini (Imagen) o de un modelo local de `diffusers` completamente gratuito para generar la imagen final a partir de la vista exportada de Revit.
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

> [!IMPORTANT]
> **Modelo de Renderizado Arquitectónico vs API Gemini**: Usar la API de Gemini para crear imágenes requiere solo la API Key, pero suele generar desde cero (por *prompt*). Para arquitectura, es crítico respetar la volumetría original (las líneas). Por tanto, la vía más robusta que cumple tu requisito ("todo gratis en local sin cuentas extra") es usar `diffusers` (Hugging Face local, modelo SD1.5-ControlNet). ¿Te parece bien que el backend instale este modelo local tras bambalinas?

> [!NOTE]
> **Preferencia de UI**: ¿Diseñamos la interfaz en el Add-in de Revit (WPF) para que el control total ocurra en Autodesk, y usamos Gradio en Python solo como una "API invisible"?

## Plan de Verificación

### Pruebas Automatizadas/Técnicas
- Consumir el endpoint de Gradio vía un script Python de prueba con una imagen falsa para asegurar que todo el puente Gemini -> Modelo HF responde correctamente.

### Comprobación Manual
- Compilaremos y cargaremos el Add-in en Revit 2024.
- Abriremos una vista 3D de una fachada, lanzaremos el Add-in y verificaremos que (1) captura la imagen y materiales sin saturar memoria, (2) el servidor Python devuelve una imagen fotorrealista renderizada.
