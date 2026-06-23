# Reglas de Oro para un WXS Robusto en Entornos Windows Installer

Este documento detalla las directivas técnicas obligatorias al estructurar instaladores con **WiX Toolset v3.11+**, diseñadas específicamente para evitar errores de validación de Windows Installer (ICE) y garantizar desinstalaciones limpias en directorios `AppData` de usuario.

---

## 1. Gestión de IDs y Símbolos Únicos
*   **Regla**: Nunca permitas que WiX asigne identificadores automáticos a los archivos en instaladores de múltiples versiones.
*   **Ejecución**: Cada archivo empaquetado debe tener un `Id` explícito y único que incluya el sufijo de su versión de Revit (p. ej., `Id="F_Dll24"`, `Id="F_Dll25"`). 
*   **Razón**: Evita el error de compilación en WiX *"Duplicate symbol 'File:YourAddin.dll' found"* al compilar múltiples DLLs con el mismo nombre físico pero ubicadas en distintas subcarpetas de versión.

---

## 2. GUIDs Estáticos vs Automáticos
*   **Regla**: Usa siempre GUIDs explícitos y fijos en cada `<Component>` (`Guid="NUEVO_GUID_AQUI-..."`). Evita utilizar el asterisco de generación automática (`Guid="*"`).
*   **Razón**: El comodín automático de WiX falla al compilar componentes complejos que agrupan múltiples archivos o llaves de registro. Un GUID estático garantiza la estabilidad del ID de componente en el registro de Windows y evita problemas en futuras actualizaciones (*MajorUpgrade*).

---

## 3. Validación de Seguridad de Windows (Normas ICE)

Al instalar archivos en `AppDataFolder` (instalación por usuario, sin privilegios elevados de administrador):

### A. ICE38 (Registry KeyPath en HKCU)
*   **Regla**: Cada componente que instale archivos en la carpeta de usuario de Revit **debe** tener un `RegistryValue` en `HKCU` definido como su KeyPath principal (`KeyPath="yes"`). No utilices el archivo `.dll` o `.addin` directamente como KeyPath.
*   **Ejemplo**:
    ```xml
    <Component Id="C_Dll24" Guid="[GUID-ESTATICO]" Directory="REVIT2024">
      <RegistryValue Root="HKCU" Key="Software\DBDev_dbarberos\FilterPlus\2024" Name="installed" Type="integer" Value="1" KeyPath="yes" />
      <File Id="F_Dll24" Name="FilterPlus.dll" Source="bin\Release.R24\FilterPlus\FilterPlus.dll" />
    </Component>
    ```

### B. ICE64 (Remoción de Carpetas en Desinstalación)
*   **Regla**: Cada directorio de la jerarquía de instalación de usuario (`Autodesk`, `Revit`, `Addins`, `2024`, etc.) debe incluir una instrucción de remoción `<RemoveFolder Id="..." On="uninstall"/>` enlazada a un componente del instalador.
*   **Razón**: Garantiza que el desinstalador de Windows limpie las carpetas del complemento si quedan vacías, evitando advertencias de seguridad y directorios huérfanos.

### C. Componente de Limpieza Centralizado
*   **Estrategia Recomendada**: Define un `ComponentGroup` con nombre `CleanupComponents` que agrupe exclusivamente las instrucciones de remoción `<RemoveFolder>` de los directorios superiores comunes de Revit, previniendo advertencias de validación ICE64 en los componentes de versión.
