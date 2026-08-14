# Plan Técnico: Extracción e Integración Asíncrona de Miniaturas de Familias (`.rfa`)

Este plan define la estrategia para cargar las imágenes de vista previa (thumbnails) de las familias y tipos de Revit en la tarjeta de detalles de `TransferPlus` de forma **completamente asíncrona y no bloqueante**.

---

## User Review Required

> [!IMPORTANT]
> **Estrategia de Extracción de Archivos `.rfa` sin Bloqueo**:
> Para archivos `.rfa` en disco (proveedor local o Azure local cache), se evitará `BasicFileInfo.Extract` debido a los bloqueos de archivo nativos detectados. En su lugar se utilizará la API nativa de Windows Shell (`IShellItemImageFactory` / `SHGetItemFromParsingName`) en un hilo del `ThreadPool`, que lee el stream de vista previa integrado por Windows Explorer sin abrir ni bloquear en modo exclusivo el archivo `.rfa`.

> [!NOTE]
> **Compatibilidad con Revit.Async**:
> Para familias provenientes de modelos activos o vinculados, la llamada a `ElementType.GetPreviewImage()` se ejecutará mediante `RevitTask.RunAsync(...)` para respetar el hilo único de la API de Revit sin congelar la ventana flotante (Modeless) de WPF.

---

## Open Questions

1. **Placeholder por Defecto**: ¿Se requiere mostrar una miniatura o icono genérico por defecto mientras la miniatura real se carga en segundo plano? (Recomendado: Sí, usar un vector SVG/PNG gris suave).
2. **Caché en Memoria**: ¿Las miniaturas deben mantenerse en caché dentro del `FamilyItemModel` durante toda la sesión de la ventana para evitar re-extraerlas si el usuario conmuta repetidamente entre familias? (Recomendado: Sí).

---

## Proposed Changes

### Componente 1: Models & Async Bindings

#### [MODIFY] [FamilyItemModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Models/FamilyItemModel.cs)
- Heredar de `ObservableObject` (CommunityToolkit.Mvvm).
- Transformar `Thumbnail` a propiedad observable `_thumbnail` para notificar a la vista cuando se cargue asíncronamente.
- Añadir propiedad `_isLoadingThumbnail` (`bool`) para indicar estado de carga.

---

### Componente 2: Servicio de Miniaturas (`FamilyThumbnailService`)

#### [MODIFY] [FamilyThumbnailService.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/FamilyThumbnailService.cs)
- Implementar `GetPreviewImageAsync(FamilyItemModel family, CancellationToken cancellationToken)`:
  - **Para elementos de Modelo Abierto/Vinculado**: Invocar `ElementType.GetPreviewImage()` a través de `RevitTask.RunAsync(...)`. Convertir la imagen a `BitmapSource` e invocar `.Freeze()` para permitir su uso entre hilos (cross-thread safety).
  - **Para archivos `.rfa` en Disco**: Invocar extracción mediante Windows Shell Image Factory en `Task.Run(...)` (hilo secundario), convirtiendo el HBITMAP a `BitmapSource` y congelándolo con `.Freeze()`.
- Añadir manejo de excepciones silencioso con registro en `LoggerService` y retorno de `null` ante archivos corruptos o no encontrados.

---

### Componente 3: ViewModel & Control de Concurrencia

#### [MODIFY] [TransferPlusViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/ViewModels/TransferPlusViewModel.cs)
- Incorporar `CancellationTokenSource? _thumbnailCts` para cancelar extracciones en curso si el usuario selecciona rápidamente otra familia en el TreeView.
- En `OnSelectedFamilyChanged(FamilyItemModel? value)`:
  - Cancelar el token previo (`_thumbnailCts?.Cancel()`).
  - Si `value.Thumbnail` ya existe en caché, asignarlo inmediatamente a `SelectedFamilyThumbnail`.
  - Si es `null`, iniciar la tarea asíncrona `_ = LoadSelectedFamilyThumbnailAsync(value, _thumbnailCts.Token);`.
  - Actualizar `SelectedFamilyThumbnail` y notificar a la UI una vez completado.

---

### Componente 4: Interfaz de Usuario (XAML)

#### [MODIFY] [TransferPlusView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/TransferPlusView.xaml)
- Ajustar el elemento `<Image Source="{Binding SelectedFamilyThumbnail}" />` para mostrar un indicador visual/opacidad reducida mientras `IsLoadingThumbnail` sea `True`.

---

## Verification Plan

### Automated Tests & Compilation
- Verificar compilación limpia con `dotnet build -c Debug.R24`.
- Validar que no existan advertencias de HBITMAP leaks (liberación correcta con `DeleteObject`).

### Manual Verification
1. **Respuesta de la UI**: Abrir `TransferPlus` en Revit, activar el `Families Manager` y hacer clic en varias familias de forma rápida. Verificar que la ventana no sufra congelamientos (UI Freezing) y que las miniaturas se carguen secuencialmente.
2. **Prueba de Cancelación**: Seleccionar una familia pesada e inmediatamente cambiar a otra; verificar que la primera carga se cancele limpiamente sin sobrescribir la nueva selección.
3. **Prueba de Bloqueo de Archivos**: Intentar abrir/renombrar un archivo `.rfa` en el Explorador de Windows mientras `TransferPlus` muestra su miniatura, confirmando que no existe bloqueo de archivo exclusivo (file-lock).
