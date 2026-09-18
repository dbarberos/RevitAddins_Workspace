# Informe de Depuración: Aislamiento de Hilos, Supresión de Avisos Modales y Resolución de Rutas de Nube Azure en Descarga Selectiva de Familias

**Fecha:** 2026-08-07  
**Componentes Afectados:** `TransferPlusViewModel.cs`, `FamilyRevitService.cs`, `AzureStorageFamilyProvider.cs`  
**Autor:** AI Software Architect  

---

## 📌 1. Descripción de los Problemas

Durante las pruebas de descarga selectiva de familias y tipos a una carpeta local especificada por el usuario en modo *Family Mode*, se identificaron tres fallos críticos en cascada:

1. **Excepción de Violación de Hilos en la API de Revit (`Task.Run`):**  
   - *Sintoma:* `EXCEPTION in SafeEditFamily fallback copy ... A managed exception was thrown by Revit or by one of its external applications.` en las 27 familias del bucle.
   - *Causa Raíz:* El bucle de descarga en `DownloadSelectedFamiliesAsync` estaba envuelto en `await Task.Run(() => ...)`. La API de Revit es estrictamente monohilo; invocar `doc.EditFamily`, `SaveAs` o `CopyElements` desde un hilo secundario del `ThreadPool` viola la afinidad de hilo.

2. **Interrupción por Diálogos Modales Emergentes de Revit ("El hueco no corta nada"):**  
   - *Sintoma:* El proceso de descarga masiva se pausaba bloqueando la interfaz al mostrar cuadros emergentes nativos de Revit ("Aviso: El hueco no corta nada. [Suprimir ejemplares] [Aceptar] [Cancelar]").
   - *Causa Raíz:* La apertura inicial de la familia (`SafeEditFamily` o `OpenDocumentFile`) y la purga de tipos (`ProcessFamilyDocTypes`) generaban advertencias geométricas (`FailureSeverity.Warning`) no suprimidas. Sin vincular `WarningSwallower` ni interceptar `UIApplication.DialogBoxShowing`, Revit abría el diálogo modal esperando la confirmación manual del usuario.

3. **Fallo de Descarga en Fuentes de Nube Azure / Azurite (0 Familias Exportadas):**  
   - *Sintoma:* `Successfully downloaded 0 family file(s) to: C:\Users\...\FamilyText`.
   - *Causa Raíz:* `AzureStorageFamilyProvider` asignaba el nombre de ruta de Blob de Azure (ej. `mile/modificados/Puerta_PC06.rfa`) a `familyItem.ImagePreviewUrl` en lugar de la ruta del archivo descargado localmente en caché (`cachedFilePath`). Al intentar abrir `OpenDocumentFile("mile/modificados/Puerta_PC06.rfa")`, `File.Exists` devolvía `false`.

---

## 🛠️ 2. Soluciones Implementadas

### A. Aislamiento Monohilo de Revit y Bombeo de Eventos WPF
Se eliminó la envoltura `Task.Run` en `DownloadSelectedFamiliesAsync`. Las operaciones de Revit API se ejecutan en el hilo principal de Revit, mientras se bombea la cola de eventos WPF con `DispatcherPriority.Background` para mantener la barra de carga responsiva:

```csharp
for (int i = 0; i < total; i++)
{
    var (family, activeSymbols) = familiesToDownload[i];
    StatusMessage = $"Downloading family '{family.Name}' ({i + 1}/{total})...";
    ProgressPercentage = (int)((double)(i + 1) / total * 100);

    // Actualiza la UI sin abandonar el hilo principal de la API de Revit
    System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke(
        System.Windows.Threading.DispatcherPriority.Background,
        new Action(() => { }));

    bool ok = _familyRevitService.ExportSelectiveFamilyToFolder(
        _app, SelectedSourceDocument.Adoc, family, selectedFolder, activeSymbols);

    if (ok) countSuccess++;
}
```

### B. Envoltura de Supresión Total de Avisos y Diálogos
Se vinculó `WarningSwallower` a las transacciones de purga de tipos y se envolvió la función completa `ExportSelectiveFamilyToFolder` (desde la apertura hasta el guardado y cierre) dentro de `ExecuteWithWarningSuppression`:

```csharp
ExecuteWithWarningSuppression(uiApp, () =>
{
    if (familyItem.NativeFamily is Family nativeFam && sourceDoc != null)
    {
        familyDoc = SafeEditFamily(uiApp, sourceDoc, nativeFam, out tempContainerDoc);
    }
    else if (!string.IsNullOrWhiteSpace(familyItem.ImagePreviewUrl))
    {
        string rfaPath = familyItem.ImagePreviewUrl;
        if (!File.Exists(rfaPath))
        {
            string fileName = Path.GetFileName(rfaPath);
            string tempFamiliesPath = Path.Combine(Path.GetTempPath(), "TransferPlus_Families", fileName);
            string tempAzurePath = Path.Combine(Path.GetTempPath(), "TransferPlus_AzureCache", fileName);
            string tempAccPath = Path.Combine(Path.GetTempPath(), "TransferPlus_AccCache", fileName);

            if (File.Exists(tempFamiliesPath)) rfaPath = tempFamiliesPath;
            else if (File.Exists(tempAzurePath)) rfaPath = tempAzurePath;
            else if (File.Exists(tempAccPath)) rfaPath = tempAccPath;
        }

        if (File.Exists(rfaPath))
        {
            familyDoc = uiApp.Application.OpenDocumentFile(rfaPath);
        }
    }

    if (familyDoc == null) return;

    ProcessFamilyDocTypes(familyDoc, targetSymbolNames, null);
    var saveOptions = new SaveAsOptions { OverwriteExistingFile = true };
    familyDoc.SaveAs(targetRfaPath, saveOptions);
});
```

### C. Resolución de Rutas de Nube Azure
En `AzureStorageFamilyProvider.cs`, se asigna ahora la ruta absoluta en disco descargada en caché:

```csharp
ImagePreviewUrl = File.Exists(cachedFilePath) ? cachedFilePath : blob.BlobName,
```

---

## ✅ 3. Verificación de Resultados

- **Modelos Abiertos y Vinculados:** Extracción e independización perfecta de tipos seleccionados.
- **Carpetas Locales, Azure/Azurite y ACC Cloud:** Descarga, apertura en memoria, filtrado de tipos y guardado `.rfa` limpio en destino de forma 100% desatendida.
- **Estado de Compilación:** **0 Errores**.
