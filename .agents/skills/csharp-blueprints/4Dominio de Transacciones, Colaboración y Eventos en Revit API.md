***

# Guía 4: Dominio de Transacciones, Colaboración y Eventos en Revit API

Protocolos de seguridad que debes seguir para alterar la base de datos de Revit, respetando los entornos colaborativos (Worksets) y reaccionando a eventos del programa como las sincronizaciones.

## 1. Transacciones: El Salvavidas de la Base de Datos (Lección 17)

En Revit, la base de datos está bloqueada por defecto. Para realizar cualquier cambio (crear, modificar o eliminar elementos), debes solicitar un lugar en la cola de procesamiento mediante una `Transaction`.

**Mejores Prácticas:**
*   **Declaración con using**: Siempre envuelve tus transacciones en un bloque `using`. Esto asegura que la transacción se limpie de la memoria y se cierre adecuadamente (`Dispose`), incluso si ocurre un error inesperado durante la ejecución.
*   **Nomenclatura clara**: Al iniciar la transacción, proporcionale un nombre claro (ej. "MiPlugin: Modificar Muros"). Este nombre es el que aparecerá en el menú de "Deshacer" (*Undo*) del usuario, por lo que debe ser descriptivo.

**Ejemplo de Código: Estructura de una Transacción**

```csharp
using Autodesk.Revit.DB; 

// ... dentro de tu método Execute ... 
// Se asume que has recolectado las hojas (sheets) que deseas modificar 

// El bloque using asegura que la memoria de la transacción se libere al terminar 
using (Transaction t = new Transaction(doc, "Guru: Añadir Revisiones")) 
{ 
    // 1. Iniciamos la transacción 
    t.Start(); 

    foreach (ViewSheet sheet in selectedSheets) 
    { 
        // 2. Modificamos el modelo (ej. añadir un ID de revisión a una hoja) 
        var currentRevisions = sheet.GetAdditionalRevisionIds(); 
        currentRevisions.Add(myRevisionId); 
        sheet.SetAdditionalRevisionIds(currentRevisions); 
    } 

    // 3. Confirmamos y guardamos los cambios en la base de datos 
    t.Commit(); 
}
```

## 2. Editabilidad en Modelos Colaborativos - Worksharing (Lección 16)

Antes de modificar un elemento en una transacción, debes asegurarte de que tienes permiso para hacerlo. En un modelo colaborativo (*Workshared*), un elemento podría estar prestado a otro usuario o desactualizado respecto al modelo central. Intentar modificarlo causará un error fatal en tu Add-in.

**Mejores Prácticas:**
*   **Comprobación Temprana**: Primero verifica si el documento es colaborativo usando `doc.IsWorkshared`. Si no lo es, todos los elementos son editables y puedes omitir las comprobaciones complejas.
*   **Verificar Estado de Préstamo y Actualización**: Utiliza la clase `WorksharingUtils` para obtener el `CheckoutStatus` (quién posee el elemento) y el `ModelUpdatesStatus` (si está sincronizado con el central).

**Ejemplo de Código: Método de Extensión para comprobar Editabilidad**

```csharp
using Autodesk.Revit.DB; 

public static class ElementExtensions 
{ 
    public static bool IsEditable(this Element element) 
    { 
        Document doc = element.Document; 

        // Si el modelo no es colaborativo, siempre es editable 
        if (!doc.IsWorkshared) return true; 

        // Obtener el estado del elemento 
        CheckoutStatus checkoutStatus = WorksharingUtils.GetCheckoutStatus(doc, element.Id); 
        ModelUpdatesStatus updateStatus = WorksharingUtils.GetModelUpdatesStatus(doc, element.Id); 

        // Si es propiedad de otro usuario, no podemos editarlo 
        if (checkoutStatus == CheckoutStatus.OwnedByOtherUser) return false; 

        // Si es propiedad del usuario actual, sí podemos 
        if (checkoutStatus == CheckoutStatus.OwnedByCurrentUser) return true; 

        // Si nadie lo posee, verificamos que esté actualizado con el archivo central 
        return updateStatus == ModelUpdatesStatus.CurrentWithCentral; 
    } 
}
```

*Uso Práctico: En tu bucle de ejecución, antes de modificar el elemento, simplemente consultas `if (miElemento.IsEditable()) { ... }` para evitar colapsos.*

## 3. Manejo de Eventos y Delegación (Lección 28)

La API de Revit está constantemente disparando "Eventos" en segundo plano (cuando un documento se abre, cuando se imprime, cuando se sincroniza, etc.). Puedes suscribir tus propios métodos a estos eventos para ejecutar código automáticamente.

**Mejores Prácticas:**
*   **Bloques try/catch obligatorios**: Cuando te suscribes a un evento nativo de Revit (como `DocumentSynchronizingWithCentral`), tu código se inyecta en el flujo principal del programa. Si tu código falla y arroja una excepción no controlada, podrías detener por completo la sincronización del usuario. Debes envolver el interior de tu evento en un `try/catch`.
*   **Suscripción responsables**: Te suscribes a un evento usando `+=` y debes asegurarte de anular la suscripción usando `-=` (preferiblemente en el método `OnShutdown` de tu `IExternalApplication`) para no dejar procesos fantasma en la memoria.

**Ejemplo de Código: Suscripción a un Evento de Sincronización**

```csharp
using Autodesk.Revit.ApplicationServices; 
using Autodesk.Revit.DB.Events; 
using System; 
using System.Diagnostics; 

public static class SyncTimer 
{ 
    private static DateTime _syncStart; 

    // Método para suscribirse (Llamado en el OnStartup de la aplicación) 
    public static void Register(ControlledApplication app) 
    { 
        // Nos suscribimos al evento que ocurre al iniciar una sincronización 
        app.DocumentSynchronizingWithCentral += OnSyncStarted; 
    } 

    // Método para desuscribirse (Llamado en el OnShutdown) 
    public static void Deregister(ControlledApplication app) 
    { 
        app.DocumentSynchronizingWithCentral -= OnSyncStarted; 
    } 

    // El método delegado que reacciona al evento 
    private static void OnSyncStarted(object sender, DocumentSynchronizingWithCentralEventArgs e) 
    { 
        // Envolver en try/catch para jamás interrumpir la sincronización del usuario 
        try 
        { 
            _syncStart = DateTime.Now; // Guardamos la hora de inicio 
            Debug.WriteLine($"Sincronización iniciada a las: {_syncStart}"); 
        } 
        catch (Exception ex) 
        { 
            // Registro silencioso de errores 
            Debug.WriteLine($"Error en el evento de sincronización: {ex.Message}"); 
        } 
    } 
}
```

***