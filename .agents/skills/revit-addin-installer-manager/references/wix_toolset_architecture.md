# Arquitectura de Compilación: WiX Toolset vs Visual Studio

Este documento explica cómo es posible crear archivos `.msi` y compilar proyectos de C# sin utilizar Visual Studio, desmitificando el rol del IDE en el proceso de compilación y empaquetado de add-ins para Revit.

## 1. Visual Studio es una Interfaz (IDE), no un Compilador

Visual Studio actúa como una interfaz gráfica (IDE) para motores de compilación subyacentes (`MSBuild`, `.NET CLI`) y herramientas de empaquetado (como `WiX Toolset`). Cuando presionas el botón "Compilar" (Build) en Visual Studio, la interfaz gráfica simplemente orquesta la ejecución de herramientas de consola pasándoles los parámetros que has configurado visualmente.

## 2. La compilación del código C# (`dotnet publish`)

Cuando compilas para múltiples versiones (2023 a 2027), Visual Studio lee tu archivo `.csproj` y envía las instrucciones a **MSBuild** (o a la interfaz moderna **.NET CLI**). 
Al ejecutar en consola el comando `dotnet publish` y especificar la configuración (`Release.R23`, `Release.R24`, etc.), el comando lee el `.csproj` e invoca al compilador (Roslyn). El resultado son los mismos archivos `.dll` exactos que obtendrías al compilar desde Visual Studio.

## 3. La creación del MSI mediante WiX Toolset

El archivo `.msi` no es un formato propio de Visual Studio, sino un instalador nativo de Windows (Windows Installer). Para construirlo a partir de código, se emplea el **WiX Toolset**. 
Cuando instalas la extensión de WiX en Visual Studio, la interfaz simplemente crea un atajo para invocar a dos programas que ya vienen incluidos en el Toolset de WiX:

*   **Candle.exe** (El compilador): Lee el código fuente XML (`Product.wxs`) y lo transforma en un archivo objeto (`.wixobj`).
*   **Light.exe** (El enlazador/linker): Toma el `.wixobj`, recolecta los `.dll` de las carpetas correspondientes, comprime los archivos en un formato `.cab` interno y genera el archivo `.msi` final.

Es posible ejecutar estas herramientas directamente desde la consola (por ejemplo, desde `C:\Program Files (x86)\WiX Toolset v3.14\bin\`) obteniendo el mismo `.msi` que generaría Visual Studio.

## 4. Condiciones de licencia, desinstalación y reparación

El comportamiento del instalador no se configura en Visual Studio, sino que reside íntegramente en el código del archivo `Product.wxs`:

*   **Licencia (EULA)**: Definida mediante variables de WiX, como `<WixVariable Id="WixUILicenseRtf" Value="Resources\License.rtf" />`. Al pasar por `light.exe`, WiX inyecta automáticamente la pantalla de licencia estándar (ej. `WixUI_Minimal`).
*   **Desinstalación y Reparación**: Las reglas de cómo el MSI se desinstala de forma limpia sin dejar basura (reglas ICE64 e ICE38) están codificadas en las directivas `<RemoveFolder>` y en las llaves de registro de tu `.wxs`. Windows Installer lee esto desde el `.msi` generado y sabe exactamente qué hacer desde el Panel de Control de Windows.
*   **Compatibilidad Multi-versión**: Las múltiples carpetas de Revit (2023, 2024...) están organizadas en los `ComponentGroup` dentro del `.wxs`. Al compilarlo, WiX empaqueta automáticamente los DLL adecuados en la ruta correcta.

## Resumen y CI/CD

Prescindir de Visual Studio y utilizar la línea de comandos es la base técnica de la **Integración Continua (CI/CD)**. Es el método estándar de la industria (utilizado en plataformas como GitHub Actions o Azure DevOps) para automatizar el proceso de tal modo que, cada vez que se sube un cambio al código, el `.msi` final se compile de manera impecable y lista para producción, sin requerir intervención humana en una interfaz gráfica.
