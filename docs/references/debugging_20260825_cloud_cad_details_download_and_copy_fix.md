# Debugging Report: Descarga y Copia de Archivos CAD desde Fuentes Cloud (Azure/Azurite, AWS S3, Autodesk Docs)

**Fecha:** 2026-08-25  
**Proyecto:** TransferPlus  
**Módulos afectados:** `ViewModels/TransferPlusViewModel.cs`  
**Estado:** RESUELTO & COMPILADO (0 Errores)

---

## 1. Descripción del Problema

Al descargar o exportar detalles/archivos CAD desde una fuente en la nube (como Azure Blob Storage / Azurite, AWS S3 o Autodesk Docs ACC):
- Se creaba la carpeta de destino en el disco (`\caddetails`), pero **no se copiaba ningún archivo** (resultado: *"Exported 0 of 3 detail/CAD file(s)"*).
- El log registraba: `INFO: [Download] Successfully downloaded/exported 0 of 3 CAD details to '%USERPROFILE%\Desktop\Borrar\caddetails'.`

---

## 2. Diagnóstico y Causa Raíz

1. **Ruta remota tratada como ruta de archivo local**:
   - Para fuentes cloud, `cadItem.FilePath` contiene la clave o nombre del blob en el contenedor (e.g. `detalles/2510000177_KRN_ARQ_G_00-Sección - xref_seccion tra.dwg` o el URN de Autodesk Docs), **no** una ruta física en disco.
2. **Método síncrono `ExportOrDownloadCadItem`**:
   - El método comprobaba directamente `File.Exists(srcPath)` en el sistema de archivos local.
   - Al no existir el archivo localmente (porque nunca se había descargado previamente a la caché), `File.Exists` retornaba `false`.
   - Seguidamente, intentaba el caso 2 (exportación desde documento nativo de Revit), el cual también era nulo (`Adoc == null`).
   - En consecuencia, el método finalizaba retornando `false` para todos los elementos seleccionados.

---

## 3. Solución Implementada

### Conversión a `ExportOrDownloadCadItemAsync` con Descarga Automática bajo Demanda
Se transformó `ExportOrDownloadCadItem` en un método asíncrono `ExportOrDownloadCadItemAsync` que gestiona cada tipo de proveedor cloud:

1. **Azure Blob Storage / Azurite**:
   - Resuelve la configuración activa (`ConnectionString` y `ContainerName`).
   - Invoca `AzureStorageService.DownloadCadBlob(connStr, container, blobName)` para descargar el archivo a almacenamiento temporal local.
   - Copia el archivo descargado a la ruta final seleccionada por el usuario (`ResolveNonCollidingFilePath(targetFolder, cadItem.Name, ext)`).
2. **AWS S3**:
   - Resuelve la fuente S3 activa.
   - Invoca `AwsS3StorageService.DownloadCadBlobAsync(source, objectKey, localTempDir)`.
   - Copia el archivo descargado a la carpeta de destino.
3. **Autodesk Docs (ACC)**:
   - Obtiene la URL de descarga segura vía `AutodeskDocsService.GetLatestVersionDownloadUrlAsync`.
   - Descarga el archivo CAD a través de `AutodeskDocsService.DownloadAccFamilyFileAsync`.
   - Copia el archivo en la carpeta de destino seleccionada.
4. **Archivos Locales en Disco y Modelos de Revit**:
   - Conserva la lógica de copia directa (`File.Copy`) para archivos locales y de exportación nativa (`doc.Export(..., DWGExportOptions)`) para vistas de Revit.

---

## 4. Verificación de Compilación

```powershell
dotnet build TransferPlus/TransferPlus.csproj -c Debug.R24 /p:DeployAddin=false
```
**Resultado:** `0 Errores`, código de salida 0.
