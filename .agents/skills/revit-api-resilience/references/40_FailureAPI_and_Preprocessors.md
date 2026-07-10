# Teoría de la API de Fallos y Preprocesadores (Failure API)

## 1. El Problema de las Ventanas Emergentes (Pop-ups)
En Revit, cuando una modificación geométrica o de datos rompe una regla del modelo (por ejemplo, un muro se solapa ligeramente con otro, o una cota pierde su referencia), el programa detiene la ejecución y muestra un cuadro de diálogo (Modal Dialog) al usuario. 
En un entorno de automatización (Add-ins) o ejecución en la nube (Design Automation), un solo cuadro de diálogo detendrá todo el proceso indefinidamente, ya que no hay un humano para hacer clic en "Ignorar" o "Cancelar".

## 2. El Ciclo de Procesamiento de Fallos
Revit maneja los errores al final de una `Transaction`. El ciclo es el siguiente:
1. **Pre-procesamiento (`IFailuresPreprocessor`):** La última oportunidad para que el Add-in intercepte, lea y resuelva los errores silenciosamente antes de que Revit reaccione.
2. **Procesamiento (`IFailuresProcessor`):** Nivel de aplicación global, generalmente reservado para reemplazar la interfaz de usuario nativa de errores de Revit.

## 3. Implementación Segura
Para automatizaciones, **siempre** debemos usar `IFailuresPreprocessor`. 
Las reglas de oro son:
* **Advertencias (Warnings):** Pueden y deben ser eliminadas silenciosamente usando `FailuresAccessor.DeleteWarning()`.
* **Errores (Errors):** No pueden ser ignorados. Si la API permite una resolución predeterminada (ej. desunir los elementos), se usa `FailuresAccessor.ResolveFailure()`. Si no tiene resolución, se debe devolver `ProceedWithRollBack` para deshacer la transacción limpiamente sin colapsar el programa.
* **Corrupción:** Nunca intentes suprimir un error de corrupción de documento.
