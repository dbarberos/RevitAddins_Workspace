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

## 🚀 3. Personalización de la Pantalla de Instalación
Para dotar al instalador de una apariencia premium, el Agente debe:
1.  **Banners**: Buscar o solicitar imágenes `Banner.bmp` (493x58) y `Dialog.bmp` (493x312).
2.  **Licencia**: Si no existe `License.rtf`, crear uno genérico con el nombre del Add-in y la fecha actual.

---

## 🤖 4. Instrucciones de Comportamiento para el Agente
- **Referencia Automática**: El Agente debe instruir al usuario para que añada la referencia a `WixUIExtension.dll` en Visual Studio si se detecta que el proyecto es nuevo.
- **GUIDs Permanentes**: El `UpgradeCode` debe ser persistente en futuras actualizaciones para permitir que el instalador desinstale versiones antiguas automáticamente.
- **Validación de Archivos**: Antes de generar el WXS, el Agente debe listar los archivos detectados para que el usuario confirme si falta alguna DLL de terceros.

---

## 📋 5. Flujo de Trabajo del Agente
1.  **Preparación**: Crear carpeta `Installer/` y subcarpeta `Resources/` dentro del proyecto.
2.  **Recursos**: Generar `License.rtf` básico.
3.  **Escritura**: Generar el archivo `Product.wxs` completo con soporte para todas las versiones detectadas.
4.  **Finalización**: Entregar los comandos para compilar vía consola (`candle.exe` y `light.exe`) o guiar en el uso de la interfaz de Visual Studio.