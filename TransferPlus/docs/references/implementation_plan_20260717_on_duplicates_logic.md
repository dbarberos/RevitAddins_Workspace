# Plan de Implementación: "On Duplicates" Logic & UI

Este plan detalla los cambios necesarios para implementar las tres nuevas estrategias frente a elementos duplicados ("Keep Original", "Abort Transaction" y "Append Suffix") desde la interfaz de la tarjeta "On Duplicates" hasta la ejecución en el motor `TransferOrchestrator`.

## Decisiones Técnicas y Soluciones

> [!NOTE]
> **Limitación de la API de Revit con "Append Suffix" en Vínculos (Revit Links)**
> Revit no permite copiar un elemento (como un `ElementType`) si en el destino ya existe uno con el mismo nombre sin fusionarlo. Además, como el documento de origen puede ser un **Vínculo (Linked Model)**, este es estrictamente de "Solo Lectura", por lo que no podemos abrir transacciones en el origen para renombrar el elemento antes de copiarlo.
> 
> Para solucionar esto se implementó la **Estrategia del Documento Puente (Temp Doc)**:
> 1. Crear programáticamente un documento temporal vacío (en memoria).
> 2. Copiar los elementos del origen a este documento temporal.
> 3. Aplicar el renombrado (Sufijo) en el documento temporal.
> 4. Copiar desde el documento temporal al documento de destino real.
> 5. Cerrar el documento temporal.
> *Beneficio:* 100% seguro. No modifica el archivo origen (soporta vínculos) y no requiere alterar temporalmente elementos existentes en el modelo destino (que podrían estar bloqueados por worksets).

> [!IMPORTANT]
> **Abort Transaction:** Si se detectan duplicados durante el copiado con esta opción activa, se lanzará un aviso ("Transfer canceled due to duplicated names") y la transacción principal del add-in aplicará un `RollBack()`, dejando el modelo destino intacto.

## Cambios Realizados

### UI & ViewModels

- **`TransferPlusView.xaml`:** Reemplazados los RadioButtons "Ok", "Abort", "Ask User" por "Keep Original", "Abort Transaction" y "Append Suffix:". Añadido un `TextBox` asociado a "Append Suffix:".
- **`TransferPlusViewModel.cs`:** Agregadas las propiedades `KeepOriginal`, `AbortTransaction`, `AppendSuffix` y `DuplicatesSuffixText` mapeando a `cf_rbKeepOriginal`, `cf_rbAbortTransaction`, `cf_rbAppendSuffix` y `cf_suffixText`.

### Core Logic (Transfer Orchestrator)

- **Keep Original:** Modificado `IDuplicateTypeNamesHandler` para que retorne `DuplicateTypeAction.UseDestinationTypes`.
- **Abort Transaction:** Retorna `DuplicateTypeAction.Abort`. La transacción de copiado se cancela mediante `t.RollBack()`.
- **Append Suffix:** Copiado mediante el *Documento Puente* (`Application.NewProjectDocument(UnitSystem)`), renombrando los duplicados en el puente antes de la importación final.
