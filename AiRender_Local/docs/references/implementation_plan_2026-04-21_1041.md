# Plan: Flujo de Instalación Guiada (Análisis de Hardware)

Basado en tu petición, implementaremos un sistema de seguridad que obligue a seguir un proceso paso a paso. Esto evitará que los usuarios intenten instalar el motor en ordenadores que no pueden soportarlo o en discos sin espacio.

---

## 1. Diseño de la Interfaz (Paso a Paso)

Modificaremos la ventana para que los controles se activen de forma secuencial:

| Estado | Acción del Usuario | Resultado | Siguiente Paso Habilitado |
| :--- | :--- | :--- | :--- |
| **Inicio** | Pulsar **"🔍 Analizar Mi PC"** | Se detecta GPU, VRAM y CPU. | **📁 Buscar Carpeta** |
| **Paso 2** | Seleccionar Carpeta | Se verifica el espacio libre en dicho disco. | **📥 Instalar Motor** |
| **Paso 3** | Pulsar **"Instalar"** | Se descarga Python, librerías y modelos. | **🚀 Renderizar** |

---

## 2. Nueva Arquitectura UI (`RenderWindow.xaml`)

Añadiremos los siguientes elementos visuales "premium":
- **Panel de Diagnóstico**: Un cuadro de texto o iconos que indiquen: 
  - ✅ GPU Detectada: [Nombre]
  - ✅ Memoria Vídeo: [VRAM]
  - ℹ️ Modo Recomendado: [CPU / GPU]
- **Botón de Instalación Dedicado**: Separaremos el botón de "Instalar" del de "Renderizar" para que el usuario sepa que es un proceso de una sola vez.

---

## 3. Lógica de Control (C#)

1.  **`OnAnalyzeHardware`**: Usaremos WMI para leer el hardware y guardaremos el "Modo Recomendado".
2.  **`OnBrowseFolder`**: Al elegir ruta, el código restará el espacio necesario del espacio libre total del disco.
3.  **`OnInstall`**: Lanzará el proceso en segundo plano para no bloquear Revit mientras descarga los modelos pesados.

---

## User Review Required
> [!IMPORTANT]
> **Modo Recomendado vs Bloqueo**
> Si el diagnóstico detecta que el ordenador es **demasiado antiguo** (menos de 8GB RAM total), ¿quieres que simplemente le avisemos o que **bloqueemos** el botón de instalar para evitar que el PC se cuelgue?
> 
> **Barra de Progreso**
> ¿Quieres que incluyamos una barra de progreso visual o con el texto de "Descargando... X%" es suficiente?

## Verification Plan
1. **Flujo de Bloqueo**: Abriremos el Add-in y comprobaremos que el botón de "Buscar Carpeta" está gris (deshabilitado) hasta que pulsemos Análisis.
2. **Diagnóstico**: Verificaremos que tras el análisis, aparece el texto con tu MX350 y la recomendación de modo CPU.
3. **Instalación**: Comprobaremos que el botón de "Instalar" solo se activa una vez elegida la ruta.
