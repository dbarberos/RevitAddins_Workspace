# Plan de Implementación: Lógica "On Views" y Pre-flight Check de Niveles

Este plan describe la arquitectura y diseño para las opciones de la tarjeta **"On Views"** en `TransferPlus`. Incluye un pre-chequeo de niveles antes de transferir vistas de planta, un diálogo WPF interactivo para resolver niveles faltantes, y la replicación exacta de planos con sus vistas y viewports.

---

## 1. Accept on all Dialogs (Gestión de Advertencias)

### WarningSwallower
Modificaremos `WarningSwallower.cs` para cumplir estrictamente con las reglas de Revit:
- Solo se eliminan advertencias (`FailureSeverity.Warning`).
- Los errores (`FailureSeverity.Error`) se mantienen intactos para no corromper el modelo y permitir que Revit los maneje o aborte.
- Retornará siempre `FailureProcessingResult.Continue`.

### Integración Condicional
En `TransferOrchestrator.cs`, la inyección de `WarningSwallower` mediante `GetFailureHandlingOptions()` se realizará únicamente si `config.cf_chk_AcceptAll` es verdadero.

---

## 2. Force Level in Level Base Views (Pre-flight Check de Niveles)

Una vista de planta (`ViewPlan`) no puede existir sin su nivel asociado (`GenLevel`). Si el nivel no existe en el destino, `CopyElements` fallará. Para evitarlo, implementaremos un chequeo antes de iniciar transacciones:

### Paso 1: Recolección y Cruce de Datos (Pre-flight)
Antes de transferir, el ViewModel escaneará los elementos seleccionados:
1. Filtrar las vistas de planta (`ViewPlan`).
2. Obtener el nivel asociado (`GenLevel`) de cada planta en el documento origen.
3. Buscar en el documento destino si existe un nivel con el **mismo nombre**.
4. Si no existe, crear un objeto `LevelConflict` con:
   - Nombre del nivel origen y su elevación.
   - Lista de niveles disponibles en el destino.
   - Nivel destino con coincidencia exacta de elevación (si existe).
   - Los dos niveles destino más cercanos por cota (por encima y por debajo).

### Paso 2: Diálogo WPF (`LevelMappingView.xaml`)
Si la casilla `ForceLevelInLevelBaseViews` está activa y se encuentra algún `LevelConflict`:
- Se abrirá la ventana modal `LevelMappingView`.
- El usuario podrá elegir por cada nivel en conflicto:
  - **Crear Nivel:** Crear un nuevo nivel con el mismo nombre y elevación.
  - **Mapear a Existente:** Seleccionar un nivel del destino (sugerirá el de igual cota o los límites superior/inferior).

### Paso 3: Estrategia de Mapeo en la Transacción (Orquestador)
Para evitar que Revit cree niveles duplicados (ej. "Nivel 1(1)") al copiar la vista:
- **Si el usuario elige "Crear Nivel":** Creamos el nivel en el destino con el mismo nombre antes de copiar la vista. Revit lo mapeará automáticamente por nombre.
- **Si el usuario elige "Mapear a Existente":** 
  - Temporáneamente renombramos el nivel destino elegido para que coincida con el nombre del nivel origen.
  - Ejecutamos `CopyElements` para copiar las vistas (Revit asociará la vista a este nivel debido a la coincidencia de nombre).
  - En el bloque `finally`, renombramos el nivel destino de vuelta a su nombre original.

---

## 3. Transfer Sheet with Views (Replicación de Planos)

Portaremos la lógica de planos de `TransferSingle.cs` a `TransferOrchestrator.cs`:
1. Si un elemento copiado es `ViewSheet` y `config.cf_chk_SheetWithViews` está activo:
2. Iterar por las vistas colocadas en el plano origen (`sourceSheet.GetAllPlacedViews()`).
3. Para cada vista colocada:
   - **Verificación de Leyendas, Tablas y Ensamblajes:** 
     - Si la vista es de este tipo y su flag `Use[Type]IfExists` está activo:
       - Buscar en el destino una vista con el mismo nombre y `ViewType`.
       - Si existe, aplicar la política de **"On Duplicates"**:
         - *Keep Original:* Usar la vista existente del destino.
         - *Abort Transaction:* Cancelar la transferencia y rollback.
         - *Append Suffix:* Copiar la vista del origen asignándole el sufijo.
     - Si no se cumple lo anterior (o no se encuentra en el destino), se realiza la copia normal de la vista.
4. Crear la vista correspondiente en el destino (copiada o reutilizada).
5. Crear el viewport en el nuevo plano: `Viewport.Create(...)`.
6. Obtener el bounding box del viewport origen y alinear el nuevo viewport en las mismas coordenadas exactas del plano destino.

---

## 4. Proposed Changes

### Modelos y ViewModels
#### [MODIFY] [Configuraciones.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Models/Configuraciones.cs)
Añadir propiedades de configuración para las sub-opciones de planos y vistas.

#### [NEW] [LevelConflict.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Models/LevelConflict.cs)
Modelo para guardar los datos de un nivel faltante y las opciones de resolución.

#### [NEW] [LevelMappingViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/ViewModels/LevelMappingViewModel.cs)
ViewModel para la ventana de mapeo de niveles.

### Vistas
#### [NEW] [LevelMappingView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/LevelMappingView.xaml)
#### [NEW] [LevelMappingView.xaml.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/LevelMappingView.xaml.cs)
Ventana premium WPF con tarjetas y diseño moderno consistente para resolver los niveles.

### Lógica
#### [MODIFY] [WarningSwallower.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/WarningSwallower.cs)
Limitar la supresión únicamente a `FailureSeverity.Warning` y retornar `Continue`.

#### [MODIFY] [TransferOrchestrator.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/TransferOrchestrator.cs)
Integrar la inyección condicional de `WarningSwallower`, la copia de planos/viewports con resolución de Leyendas/Tablas, y el renombrado temporal para mapeo de niveles.

#### [MODIFY] [TransferPlusViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/ViewModels/TransferPlusViewModel.cs)
Integrar la fase de **Pre-flight Check** en el comando `Transfer` y abrir el diálogo si es necesario.

---

## 5. Plan de Verificación

### Pruebas Unitarias y Manuales
1. **Advertencias:** Simular la copia de un elemento con advertencia leve (ej. línea fuera de eje) con la opción activada y desactivada para comprobar la supresión de diálogos de Revit.
2. **Planos y Reutilización:** Transferir un plano con una leyenda existente en destino. Verificar que según la opción "On Duplicates", se reutiliza la leyenda existente o se crea una nueva con sufijo.
3. **Mapeo de Niveles:** Transferir una planta cuyo nivel no existe. Verificar que la ventana WPF sugiere los niveles correctos, y que tras la copia la planta queda asignada al nivel elegido sin duplicados residuales.
