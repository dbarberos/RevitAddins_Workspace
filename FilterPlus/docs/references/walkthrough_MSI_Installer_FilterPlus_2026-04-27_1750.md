# 🚶 Walkthrough: Creación y Configuración del Instalador MSI

## 📝 Resumen del Proceso

Se ha automatizado la preparación del instalador profesional para FilterPlus. Se han generado los binarios para todas las versiones de Revit (2023-2027) y se ha configurado el script de instalación de WiX Toolset.

### 🛠️ Archivos Generados
1.  **Product.wxs**: El archivo de configuración de WiX que define la instalación en múltiples rutas de Revit.
2.  **License.rtf**: Licencia MIT en Inglés (Permite uso y modificación libre citando al autor).
3.  **Binarios**: Carpetas `bin/Release.RXX` listas para ser empaquetadas.

---

## 🚀 Pasos Finales en Visual Studio (Acción Requerida)

Para finalizar la creación del archivo `.msi` en tu ordenador, sigue estos pasos:

1.  **Añadir el Proyecto a la Solución**:
    - En el explorador de soluciones, clic derecho en la Solución -> *Add* -> *New Project*.
    - Selecciona **Setup Project (WiX v3)**.
    - Nómbralo `FilterPlus.Installer`.
    - **Importante**: Borra el archivo `Product.wxs` que crea por defecto y arrastra el que yo he creado en la carpeta `FilterPlus/Installer/`.

2.  **Añadir Referencias de Interfaz (UI)**:
    - En el proyecto `FilterPlus.Installer`, clic derecho en **References** -> **Add Reference**.
    - Navega hasta la carpeta de instalación de WiX (normalmente `C:\Program Files (x86)\WiX Toolset v3.11\bin`) y selecciona **WixUIExtension.dll**.

3.  **Vincular Recursos**:
    - Asegúrate de que el archivo `License.rtf` esté dentro de una carpeta llamada `Resources` en el proyecto del instalador (o que la ruta en el `.wxs` coincida).

4.  **Compilar el Instalador**:
    - Cambia la configuración a **Release** en Visual Studio.
    - Haz clic derecho en el proyecto `FilterPlus.Installer` -> **Build**.
    - El archivo final aparecerá en `FilterPlus.Installer/bin/Release/FilterPlus.msi`.

## ✅ Validación Final
El instalador resultante colocará los archivos automáticamente en `%AppData%\Autodesk\Revit\Addins\[Version]`, permitiendo que FilterPlus aparezca en todas las versiones de Revit instaladas en el equipo del cliente.
