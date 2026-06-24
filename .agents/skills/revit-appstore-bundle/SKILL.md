---
name: revit-appstore-bundle
description: Generates the Autodesk App Store .bundle folder structure and PackageContents.xml for Revit addins. Use when preparing a plugin for the Autodesk App Store marketplace.
---

# Revit AppStore Bundle

Este skill estandariza y automatiza la generación de paquetes con formato `.bundle` listos para ser publicados en la **Autodesk App Store**.

Cuando Autodesk rechaza un instalador MSI personalizado (especialmente para Add-ins gratuitos) o se requiere cumplir con su formato estándar, es necesario entregar el complemento dentro de una estructura estandarizada conocida como "Bundle Format" que luego la tienda de Autodesk compila en sus propios instaladores.

## Propósito
- Automatizar la creación de la carpeta `[AppName].bundle`.
- Generar el archivo `PackageContents.xml` requerido, rellenado con la información del autor, versiones soportadas, y estructura de carga de Revit.
- Copiar las librerías dinámicas (`.dll`) y el manifiesto (`.addin`) en las carpetas específicas por versión (`Contents/2024/`, etc.).
- Comprimir la estructura en un archivo `.zip` listo para su subida al portal de desarrolladores de Autodesk.

## 🚨 Reglas Críticas para Autodesk App Store
1. **Contextual Help (Obligatorio)**: El botón del Ribbon DEBE tener asociado un archivo de ayuda local HTML mediante `SetContextualHelp`. Este archivo (`help.html`) se debe generar a partir del User Guide y ubicarse en la carpeta `Resources/` del bundle.
2. **Exclusión del XML en ZIP**: Aunque generamos `PackageContents.xml` para pruebas locales del desarrollador, **NO** debe incluirse dentro del archivo `.zip` final. Autodesk genera este archivo automáticamente durante el proceso de sumisión en la tienda.

## 📦 Assets (Plantillas y Código Fuente)
Los siguientes archivos se encuentran en la carpeta `assets/`:
*   `assets/PackageContents.xml`: Plantilla base del manifiesto del Bundle que describe la compatibilidad, empresa y referencias a cargar.

## 🛠️ Scripts (Automatización)
Para ejecutar este skill, utiliza el script PowerShell proveído en la carpeta `scripts/`.

### `scripts/build-bundle.ps1`
**Uso típico:**
```powershell
.\.agents\skills\revit-appstore-bundle\scripts\build-bundle.ps1 -AppName "FilterPlus" -Version "1.1.0" -Author "Tu Nombre" -Email "tu@email.com"
```
**Parámetros:**
- `-AppName`: El nombre del Add-in (y de la carpeta resultante).
- `-Version`: La versión actual (p. ej., `1.0.0`).
- `-Author`: Nombre del desarrollador o compañía (p. ej., `DBDev_dbarberos`).
- `-Email`: Correo de contacto del desarrollador.

El script leerá las carpetas locales de compilación (`bin/Debug.R24`, `bin/Debug.R25`, etc.) y ensamblará el Bundle con las versiones que encuentre disponibles, creando finalmente un archivo zip.
