# Prompt: Andamiaje de Nuevos Comandos en Revit (C# / Python)

Este prompt estandariza el flujo secuencial paso a paso para crear un nuevo comando en Revit, ya sea utilizando código compilado C# o un script dinámico de pyRevit.

---

## 🎯 Objetivo de la Tarea
Crear e inyectar un nuevo comando que se integre a la interfaz Ribbon de Revit, aplicando inyección de interfaces para aislamiento del modelo y transacciones seguras.

---

## 🚀 Flujo Secuencial para Comandos C#

### Paso 1: Definición del Servicio y Contrato (Inyección de Interfaces)
*   Extrae la firma del método de la API a una interfaz pura en la carpeta `/Services/`:
    ```csharp
    public interface IMyFeatureService
    {
        IList<MyDataModel> ExecuteQuery();
    }
    ```
*   Implementa el servicio real consumiendo la API de Revit.

### Paso 2: Creación de la Clase Comando C#
*   Crea un archivo `Cmd[Action][Entity].cs` en la carpeta `Commands/`.
*   Aplica el atributo de transacciones manuales:
    ```csharp
    [Transaction(TransactionMode.Manual)]
    public class CmdMyAction : IExternalCommand
    {
        private readonly IMyFeatureService _service;
        
        // Constructor primario o por inyección de dependencias
        public CmdMyAction(IMyFeatureService service)
        {
            _service = service;
        }

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Ejecutar consulta o delegar a servicios
            return Result.Succeeded;
        }
    }
    ```

### Paso 3: Enlace al Ribbon UI (`Application.cs`)
*   Localiza la inicialización de la Ribbon en `OnStartup` de `Application.cs` e inyecta el botón correspondiente referenciando el `FullClassName` de la clase del comando.

---

## 🚀 Flujo Secuencial para Scripts pyRevit (Python)

### Paso 1: Configurar la Jerarquía de Carpetas
*   Crea la carpeta correspondiente bajo la extensión de pyRevit en el disco:
    `MiModulo.extension > MiPanel.panel > MiAccion.pushbutton`

### Paso 2: Escribir el Manifiesto de Configuración (`bundle.yaml`)
*   Crea el archivo `bundle.yaml` con metadatos descriptivos mínimos:
    ```yaml
    title: "Nombre Botón"
    tooltip: "Breve descripción funcional de la macro al pasar el ratón."
    ```

### Paso 3: Escribir el Archivo de Lógica (`script.py`)
*   Crea el archivo `script.py` inyectando la inicialización del contexto y el wrapper de transacciones de pyRevit:
    ```python
    # -*- coding: utf-8 -*-
    from pyrevit import revit, DB, UI
    from pyrevit import forms

    # Recuperar sesión activa
    doc = revit.doc

    # Envolver ejecuciones de escritura en transacciones nativas
    with revit.Transaction("Nombre Acción"):
        # Tu lógica de manipulación del modelo de Revit aquí
        pass
    ```
