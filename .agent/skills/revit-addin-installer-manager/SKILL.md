# Skill: Revit Add-in Installer Manager (WiX Toolset Automation)

**Versión:** 1.1
**Descripción:** Automatiza la creación de instaladores MSI profesionales para Add-ins de Revit multiversión (2023-2027), utilizando WiX Toolset v3.11+.

---

## 🟢 1. Fase de Configuración Inicial (Entrada de Usuario)
Al activar este skill, el Agente debe recopilar:
1.  **Versiones de Revit Objetivo:** (Ej. 2023, 2024, 2025, 2026, 2027).
2.  **Nombre Comercial:** Nombre del Add-in para el Panel de Control.
3.  **Fabricante:** Nombre del desarrollador o empresa.
4.  **UI Deseada:** ¿Mínima (Minimal) o con selección de ruta (InstallDir)?

---

## 🛠 2. Lógica de Ejecución Automática

### Paso A: Escaneo de Estructura Multi-Configuración
El Agente mapeará las carpetas de salida del proyecto (basado en el patrón de Nice3point):
- Busca `bin/Release.R24/FilterPlus/`, `bin/Release.R25/FilterPlus/`, etc.
- Verifica la existencia del manifiesto `.addin` en la raíz del proyecto.

### Paso B: Generación de `Product.wxs` (Lógica Central)
El Agente escribirá el archivo con la siguiente estructura técnica:

1.  **Namespaces**: Incluir `xmlns="http://schemas.microsoft.com/wix/2006/wi"`.
2.  **Variables de UI**:
    - `<UIRef Id="WixUI_Minimal" />` o `<UIRef Id="WixUI_InstallDir" />`.
    - `<WixVariable Id="WixUILicenseRtf" Value="Resources\License.rtf" />`.
3.  **Jerarquía de Directorios**:
    ```xml
    <Directory Id="TARGETDIR" Name="SourceDir">
      <Directory Id="AppDataFolder">
        <Directory Id="Autodesk" Name="Autodesk">
          <Directory Id="Revit" Name="Revit">
            <Directory Id="Addins" Name="Addins">
              <Directory Id="REVIT2024" Name="2024" />
              <Directory Id="REVIT2025" Name="2025" />
              <!-- Repetir según versiones -->
            </Directory>
          </Directory>
        </Directory>
      </Directory>
    </Directory>
    ```

### Paso C: Definición de Componentes por Versión
El Agente generará un `ComponentGroup` por cada versión de Revit, vinculando el `.addin` específico y la carpeta de binarios correspondiente.

---

## 🛡 3. Reglas de Oro para un WXS Robusto (Anti-Errores)
Para evitar errores de compilación comunes en WiX (ICE64, ICE38, Duplicate Symbols), el Agente debe seguir estas reglas estrictas al generar el código:

### A. Gestión de IDs y Símbolos Únicos
*   **Nunca** dejes que WiX asigne IDs automáticos a los archivos en instaladores multiversión.
*   **Regla**: Cada archivo debe tener un `Id` único que incluya la versión (ej: `Id="F_Dll24"`, `Id="F_Dll25"`). Esto evita el error *"Duplicate symbol 'File:Nombre.dll' found"*.

### B. GUIDs Estáticos vs Automáticos
*   **Regla**: Usa siempre **GUIDs fijos y estáticos** para los componentes (`Guid="XXXX-..."`). 
*   **Por qué**: El uso de `Guid="*"` (automático) falla si el componente contiene más de un elemento (ej: un Archivo + una Clave de Registro). Al ser instalaciones multiversión complejas, el GUID fijo garantiza estabilidad.

### C. Validación de Seguridad Windows (ICE)
Para instalaciones en `AppData` (Per-User):
1.  **ICE38 (KeyPath de Registro)**: Cada componente **debe** tener una `RegistryValue` en `HKCU` como `KeyPath="yes"`. No uses el archivo como KeyPath.
2.  **ICE64 (Borrado de Carpetas)**: Cada nivel de la jerarquía de directorios (`Autodesk`, `Revit`, `Addins`, `2024`, etc.) debe tener una instrucción `<RemoveFolder Id="..." On="uninstall"/>` vinculada a un componente.
3.  **Componente de Limpieza**: Se recomienda crear un `ComponentGroup` llamado `CleanupComponents` que se encargue exclusivamente de las instrucciones `RemoveFolder` de las carpetas superiores.

---

## 🤖 4. Instrucciones de Comportamiento para el Agente
- **Referencia Automática**: El Agente debe instruir al usuario para que añada la referencia a `WixUIExtension.dll` en Visual Studio si se detecta que el proyecto es nuevo.
- **UpgradeCode**: Debe ser persistente para permitir actualizaciones (`MajorUpgrade`).
- **Validación de Rutas**: Verificar siempre que las rutas relativas (ej: `..\..\..\`) coincidan con la profundidad de la carpeta del instalador respecto a los binarios.
- **Estructura de Componentes**: Cada archivo importante (DLL, .addin) debe ir en su propio `<Component>`.

---

## 📋 5. Flujo de Trabajo del Agente
1.  **Preparación**: Crear carpeta `Installer/` y subcarpeta `Resources/` dentro del proyecto.
2.  **Recursos**: Generar `License.rtf` básico.
3.  **Escritura**: Generar el archivo `Product.wxs` completo aplicando las **Reglas de Oro** de la Sección 3.
4.  **Finalización**: Entregar los comandos para compilar vía consola o guiar en el uso de la interfaz de Visual Studio.