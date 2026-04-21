# Plan: Optimización Avanzada y Gestión Inteligente de Modelos

Este plan describe la implementación técnica para el control total del renderizado y el soporte multi-modelo con gestión automática de espacio.

---

## 1. Gestión Inteligente de Modelos IA

Implementaremos una lógica de "Mesa de Mezclas" para los modelos:
- **Persistencia**: Si hay espacio suficiente (> 5GB libres tras la descarga), el sistema conservará los modelos anteriores.
- **Auto-Purga**: Si el disco está lleno, el Add-in preguntará o borrará automáticamente los modelos no utilizados para dar paso al nuevo seleccionado.
- **Selector de Activo**: Un `ComboBox` permitirá alternar instantáneamente entre los motores ya descargados.

---

## 2. Interfaz de Usuario y Comportamiento de Sliders

Rediseñaremos la ventana para incluir:
- **Panel de Control de Calidad**:
  - `Steps Slider` (1-50): Pasos de la IA.
  - `Guidance Slider` (1.0-15.0): Creatividad vs Fidelidad.
  - `Neg. Prompt`: Caja de texto para "evitar".
- **Comportamiento "Render Rápido"**:
  - Al pulsar el botón de rayo `⚡`, los Sliders se moverán automáticamente a `Steps: 12` y `Guidance: 5.0`.
  - Se bloquearán (IsEnabled=False) durante el proceso para indicar que se está usando una configuración optimizada.

---

## 3. Integración de Script de Renderizado Final

El script `render_engine.py` recibirá estos nuevos parámetros:
- `--steps`, `--guidance`, `--strength`, `--negative_prompt` y `--model_path`.
- Se optimizará para cargar únicamente el modelo seleccionado en el `ComboBox`.

---

## User Review Required
> [!IMPORTANT]
> **Modelo por Defecto**
> ¿Quieres que incluyamos el modelo **Realistic Vision V6.0** como la opción recomendada por defecto para arquitectura, o prefieres empezar con el **1.5 Base** que es más genérico para pruebas iniciales?
> 
> **Bloqueo tras Render Rápido**
> ¿Los Sliders deben volver a su valor anterior después de un render rápido, o deben quedarse en los valores bajos para que el usuario pueda ajustarlos desde ahí?

---

## Verification Plan
1. **Detección de Espacio**: Simularemos una situación de poco espacio y verificaremos que el Add-in ofrece borrar modelos antiguos.
2. **Sincronización UI**: Comprobaremos que al cambiar el modelo en el desplegable, los parámetros sugeridos (Steps por defecto) cambian según el tipo de motor.
3. **Renderizado**: Lanzaremos un render normal vs uno rápido y compararemos el tiempo de ejecución en los registros.
