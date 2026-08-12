# Implementation Plan: Rename Palette Functionality in Family Mode (Families & Types)

Implement complete support for the **Rename palette** in **Family Mode**, enabling users to rename both **Family Names** and **Type Names** before transferring or downloading, with full support for regex, text formatting, numbering, selection checkboxes, and original name restoration upon closing the Rename panel.

---

## 🎯 Requisitos y Especificaciones

1. **Poblado Jerárquico en la Paleta de Renombrado (`RenamePreviewItems`)**:
   - En **Family Mode**, al abrir o sincronizar la paleta de renombrado, se listarán tanto los **nombres de las familias** como los **nombres de los tipos/símbolos seleccionados** bajo cada familia.
   - Cada entrada permitirá renombrar de forma independiente la familia (ej. `Puerta_Madera` -> `Puerta_Madera_V2`) y sus tipos asociados (ej. `80x200` -> `P-80x200`).

2. **Aplicación de Renombrado en la Exportación y Descargas (`DownloadSelectedFamiliesAsync`)**:
   - Si la paleta de renombrado está activa (o contiene ítems modificados con `IsSelected == true`), se extraerán los diccionarios de renombrado (`familyRenameMap` y `symbolRenameMap`).
   - El archivo `.rfa` se descargará guardándose con el nuevo nombre de la familia (`NewName + ".rfa"`).
   - Los tipos internos de la familia dentro del documento `.rfa` se actualizarán con sus nuevos nombres de tipo (`NewName`) antes de guardar el archivo en la carpeta elegida.

3. **Aplicación de Renombrado en Transferencias a Modelos (`TransferCommand`)**:
   - Al transferir familias en Family Mode hacia un documento de Revit destino, se aplicará `overrideFamilyName` para el nombre de la familia y `symbolRenameMap` para modificar los nombres de los tipos internos en memoria previo a la ejecución de `LoadFamily(targetDoc)`.

4. **Restauración al Cerrar la Paleta (`CloseRenamePanel`)**:
   - Al hacer clic en el botón **"Close Rename"** (o cerrar la paleta de renombrado), se limpiará la colección `RenamePreviewItems` y se descartarán todos los mapas de renombrado.
   - De este modo, las subsiguientes transferencias o descargas volverán a utilizar automáticamente los **nombres originales** de las familias y tipos.

5. **Preservación de Toda la Lógica Existente del Rename Panel**:
   - Omitir elementos desmarcados (`IsSelected == false`).
   - Soporte completo de expresiones regulares (Regex).
   - Formateo de texto (Mayúsculas, Minúsculas, Title Case, etc.).
   - Modos "Apply all" y "Apply only filtered".
   - Secuencias de numeración (prefijo, sufijo, inicio, paso).

---

## 💻 Cambios Propuestos

### [TransferPlus Component]

#### [MODIFY] [RenamePreviewItem.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/ViewModels/RenamePreviewItem.cs)
- Añadir las propiedades `public bool IsType { get; init; }` y `public string? ParentFamilyName { get; init; }`.
- Actualizar constructores para identificar si el ítem corresponde a una Familia o a un Tipo/Símbolo.

#### [MODIFY] [TransferPlusViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/ViewModels/TransferPlusViewModel.cs)
- En `OpenRenamePanel` y `UpdateCheckedCount` (sincronización dinámica de la paleta en Family Mode):
  - Recorrer `checkedFamilies` y añadir tanto la entrada de la Familia como las entradas de los Tipos/Símbolos seleccionados bajo ella.
- En `CloseRenamePanel`:
  - Limpiar la lista `RenamePreviewItems` para restaurar los nombres originales para cualquier transferencia o descarga posterior.
- En `DownloadSelectedFamiliesAsync`:
  - Consultar `RenamePreviewItems` para construir `familyRenameMap` y `symbolRenameMap`.
  - Aplicar el nombre renombrado de la familia para el archivo `.rfa` de salida y pasar `symbolRenameMap` a `ExportSelectiveFamilyToFolder`.
- En el flujo de transferencia de familias:
  - Pasar los mapas de renombrado de familias y tipos a `_familyRevitService.TryTransferInMemoryFamily` / `provider.TransferFamilyAsync`.

#### [MODIFY] [FamilyRevitService.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/FamilyRevitService.cs)
- En `ExportSelectiveFamilyToFolder`:
  - Aceptar los parámetros opcionales `string? overrideFamilyName` y `Dictionary<string, string>? symbolRenameMap`.
  - Renombrar los tipos internos en `familyDoc` usando `familyManager.RenameCurrentType(newTypeName)` antes de guardar el archivo `.rfa` en disco.
- En `ProcessFamilyDocTypes`:
  - Asegurar que si un tipo está presente en `symbolRenameMap`, se renombre correctamente con `familyManager.RenameCurrentType(newTypeName)`.

---

## 🧪 Plan de Verificación

### Compilación Básica
- Ejecutar compilación MSBuild / dotnet build para validar que no haya errores de sintaxis ni de tipos.
```powershell
dotnet build "c:\Users\david.barbero\Documents\DOCUMENTOS\ALTEN\Workbench\RevitAddins_Workspace\RevitAddins_Workspace\TransferPlus\TransferPlus.csproj" -c Debug.R24 /p:DeployAddin=false
```

### Verificación Manual
1. **Verificación de Lista en Paleta Rename:** Abrir la paleta Rename en Family Mode y verificar que aparecen listadas las familias y sus tipos seleccionados.
2. **Prueba de Renombrado (Buscar/Reemplazar, Regex, Formato):** Aplicar reglas de renombrado (ej. añadir prefijo `MOD_` a las familias o tipos) y verificar la columna "New Name".
3. **Prueba de Descarga con Renombrado:** Descargar las familias a una carpeta local y verificar que los archivos `.rfa` se guardan con el nuevo nombre y que al abrirlos en Revit sus tipos contienen los nuevos nombres.
4. **Prueba de Cierre de Paleta (Restauración de Nombres):** Pulsar "Close Rename", realizar la descarga nuevamente y verificar que las familias y tipos se descargan con sus nombres originales.
