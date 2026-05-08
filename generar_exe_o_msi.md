

### 📄 Guía de Empaquetado para AiRender Local

#### 1. Preparación de los archivos (Crucial para ambos)
Antes de crear cualquier instalador, debes tener lista la carpeta de distribución. En tu caso, los archivos necesarios están en:
`bin\Release.R24\` (o R25)
*   **Archivo Manifiesto**: `AiRenderLocal.addin`
*   **Carpeta de DLLs**: `AiRenderLocal/`
*   **Carpeta de Motor**: `Server/` (debe ir dentro de la carpeta del addin).

---

#### 2. Generar el archivo .EXE (Vía Inno Setup)
Es la opción más recomendada para add-ins de Revit por su facilidad de scripting.

*   **Paso 1**: Descarga e instala [Inno Setup](https://jrsoftware.org/isdl.php).
*   **Paso 2**: Crea un archivo de texto llamado `installer.iss`.
*   **Paso 3**: Pega este ejemplo de configuración básica (adaptado a tu proyecto):

```iss
[Setup]
AppName=AiRender Local
AppVersion=1.0
DefaultDirName={userappdata}\Autodesk\Revit\Addins\2024
DisableDirPage=yes
OutputBaseFilename=AiRenderLocal_Setup

[Files]
; Copia el manifest
Source: "C:\Ruta\Tu\Proyecto\AiRenderLocal.addin"; DestDir: "{app}"
; Copia la carpeta con las DLLs y el Server
Source: "C:\Ruta\Tu\Proyecto\AiRenderLocal\*"; DestDir: "{app}\AiRenderLocal"; Flags: recursesubdirs
```

*   **Paso 4**: Pulsa **Compile** en Inno Setup y obtendrás tu `.exe` listo para enviar.

---

#### 3. Generar el archivo .MSI (Vía WiX Toolset)
El formato MSI es preferible si el add-in se va a desplegar de forma masiva en una oficina mediante GPO o SCCM.

*   **Paso 1**: Instala [WiX Toolset](https://wixtoolset.org/).
*   **Paso 2**: Instala la extensión de WiX para Visual Studio.
*   **Paso 3**: Crea un nuevo proyecto de tipo **"Setup Project (WiX)"** en tu solución de Visual Studio.
*   **Paso 4**: Configura el archivo `Product.wxs` definiendo:
    *   `Directory`: Apuntando a `AppDataFolder\Autodesk\Revit\Addins\2024`.
    *   `Component`: Listando cada archivo que debe instalarse.
*   **Paso 5**: Compila el proyecto y Visual Studio generará el archivo `.msi` en la carpeta `bin`.

---

### 💡 Recomendación Profesional
Si buscas el equilibrio entre potencia y sencillez, utiliza **Inno Setup**. La mayoría de desarrolladores de Autodesk (incluyendo apps oficiales de la Exchange Store) utilizan este formato porque permite incluir lógica personalizada (como comprobar si Revit está abierto antes de instalar) de forma mucho más sencilla que el formato MSI.

