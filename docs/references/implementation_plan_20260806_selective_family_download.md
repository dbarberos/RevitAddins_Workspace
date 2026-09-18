# Implementation Plan: Descarga Selectiva de Familias y Tipos desde "Families Details"

Implementar la lógica completa del botón **Download** en la tarjeta `"Families Details"`. Al pulsar el botón, el sistema solicitará al usuario una carpeta destino local mediante un diálogo estándar de selección de directorio. Posteriormente, exportará las familias marcadas o la familia activa seleccionada en el explorador (*TreeView*), garantizando que los archivos `.rfa` descargados contengan **única y exclusivamente los tipos de familia que están seleccionados/marcados en el explorador**.

---

## 🎯 Requisitos de Funcionalidad

1. **Apertura de Selección de Carpeta:**  
   Al hacer clic en el botón de descarga, se abrirá un diálogo (`System.Windows.Forms.FolderBrowserDialog` o `CommonOpenFileDialog`) para seleccionar la carpeta destino local.
2. **Determinación de Familias y Tipos a Descargar:**  
   - Si hay 1 familia seleccionada o familias marcadas con checkboxes, se procesan únicamente las familias que tengan al menos 1 tipo activo.
   - Para cada familia, se obtiene la lista estricta de nombres de tipos marcados (`IsActive == true`).
3. **Procesado Unificado Multi-Fuente:**
   - **Modelos Abiertos y Vinculados:**  
     Se edita la familia en memoria con `sourceDoc.EditFamily(family)`, se filtran sus tipos con `ProcessFamilyDocTypes(familyDoc, checkedSymbolNames)`, y se guarda el archivo resultante en la carpeta elegida mediante `familyDoc.SaveAs(targetRfaPath)`.
   - **Carpetas Locales, Azure Storage y ACC Cloud:**  
     Se obtiene el archivo `.rfa` local (descargando temporalmente desde blob o ACC si corresponde), se abre en memoria con `app.OpenDocumentFile(localRfaPath)`, se eliminan los tipos no marcados con `ProcessFamilyDocTypes(familyDoc, checkedSymbolNames)`, y se guarda la familia limpia en la carpeta destino elegida por el usuario con `familyDoc.SaveAs(targetRfaPath)`.
4. **Binding de Comando UI:**  
   Enlazar `DownloadSelectedFamiliesCommand` con el botón de icono **Download** en `TransferPlusView.xaml`.
5. **Notificación y Progreso:**  
   Mostrar en la barra de estado el progreso de descarga y registrar eventos en `TelemetryLogger`.
