# Estrategia de Pruebas para Add-ins de Revit

Este documento describe los niveles de prueba y los principios fundamentales para la validación de add-ins en Autodesk Revit.

---

## 1. El Problema Fundamental de las Pruebas en Revit

La API de Revit **no puede ejecutarse fuera de una sesión de Revit en ejecución** (no existe un modo *headless* nativo). 
* No es posible instanciar objetos como `Document`, `Element`, `FilteredElementCollector` o llamar a métodos de la API en pruebas unitarias normales ejecutadas en entornos externos (p. ej., el test runner de VS o consola de dotnet).
* Las pruebas unitarias deben centrarse en **aislar la lógica de negocio pura** de las llamadas a la API de Revit mediante patrones de inyección de interfaces.
* Las validaciones de integración completas requieren iniciar Revit y cargar el add-in manualmente o usando frameworks de automatización.

---

## 2. Niveles de Pruebas en Revit

| Nivel | Qué evalúa | Herramienta | Automatizable |
|-------|------------|-------------|---------------|
| **Build (Compilación)** | Ausencia de errores de sintaxis o enlace | `dotnet build` | ✅ Sí |
| **Unitarias (Unit)** | Lógica interna de servicios y modelos aislados | xUnit / NUnit + mocks | ✅ Sí |
| **Integración** | Comportamiento del add-in cargado en Revit | RevitTestFramework / manual | ⚠️ Parcial |
| **Manuales** | Interfaz de usuario (Ribbon), diálogos, flujo de trabajo completo | Revit real | ❌ No |

---

## 3. Validación de Build (Nivel Mínimo Obligatorio)

Ejecuta siempre este comando después de realizar cualquier cambio significativo:

```powershell
dotnet build {{Name}}.csproj --configuration Release
```

### Lista de Verificación Post-Compilación:
- [ ] La compilación finaliza correctamente (`exit code 0`).
- [ ] No existen advertencias críticas (ej. ambigüedad `CS0104`, métodos obsoletos `CS0618`).
- [ ] La DLL se ha generado en la carpeta de salida configurada.
- [ ] El archivo `.addin` (manifiesto) está presente y tiene el `FullClassName` correcto.

---

## 4. Reglas de Comportamiento del Agente (Cuándo y Qué Probar)

### Cuándo crear pruebas unitarias:
- **Siempre** que se cree o modifique un servicio que contenga lógica de procesamiento de datos pura (sin dependencias directas con clases de Revit).
- **Siempre** que se creen clases de extensión/helpers genéricos de utilidad.

### Qué NO probar unitariamente:
- Clases que implementen `IExternalCommand` (actúan únicamente como coordinadores del flujo).
- Servicios que dependan directamente de un `Document` real de Revit para consultas complejas.
- Código de la interfaz de usuario / archivos XAML y WPF.
- Configuración de la cinta de opciones (Ribbon) en `Application.cs`.

### Qué SÍ probar unitariamente:
- Lógica de transformación de datos (agrupación, filtrado, cálculos matemáticos o de unidades).
- Modelos de datos y sus reglas de validación interna.
- Helpers y extensiones independientes de la API de Revit.
- ViewModels (lógica de presentación aislada de Revit, simulando los comandos del usuario).
