# Teoría de Telemetría, Logging y Reporte de Errores

## 1. La Necesidad de Observabilidad (AppOps)
Cuando un Add-in se despliega en un entorno empresarial (docenas o cientos de usuarios), depender de que el usuario reporte un error ("El botón no funciona") es insostenible. El código debe reportar sus propios fallos de manera estructurada.

## 2. Captura Global de Excepciones
Cualquier método expuesto al usuario (como `Execute` en `IExternalCommand` o la lógica dentro de un `IExternalEventHandler`) debe estar envuelto en un bloque `try-catch` global. Ninguna excepción debe "escapar" hacia Revit, ya que esto mostrará el temido mensaje de "Error en el comando externo" de Autodesk.

## 3. Sanitización de Datos (PII)
Antes de enviar un log de errores a un servidor en la nube (ej. Azure Application Insights, AWS CloudWatch, o un archivo de texto en red), el código debe eliminar cualquier Información de Identificación Personal (PII).
* **Rutas de archivo:** `C:\Users\JuanPerez\Desktop\Modelo.rvt` debe limpiarse usando expresiones regulares (Regex) para ocultar el nombre de usuario de Windows.
* **Nombres de PC:** Ocultar el nombre de la máquina si contiene nombres personales.

## 4. Estructura de un Payload de Telemetría
Un log corporativo siempre debe incluir:
* **Acción:** Nombre del comando que falló.
* **Versión de Revit:** Build exacta de Revit (ej. `2024.1.2`), vital para detectar bugs específicos de Autodesk.
* **Versión del Add-in:** Para saber si el usuario no ha actualizado.
* **StackTrace:** La traza de la pila limpia para ubicar la línea exacta de código fuente donde ocurrió el colapso.
