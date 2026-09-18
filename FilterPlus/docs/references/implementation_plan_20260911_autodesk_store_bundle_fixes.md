# Plan de Corrección: Incidencias Autodesk App Store en FilterPlus (Revit 2023)

Este plan aborda y soluciona las dos primeras incidencias notificadas por el equipo de revisión de Autodesk App Store sobre el add-in **FilterPlus**:

1. **Resource folder in 2023 bundle**: La carpeta de recursos/ayuda no estaba presente en la carpeta de versión 2023, impidiendo el funcionamiento de la ayuda contextual (F1).
2. **Revit logo in App UI of Revit 2023**: En Revit 2023 se visualizaba el logotipo de producto de Autodesk Revit en la cabecera de la UI, lo cual infringe las directrices de marcas registradas de Autodesk.

---

## 🔍 Diagnóstico de Causa Raíz

Tras investigar a fondo el código fuente, los scripts y los binarios del bundle previo:
1. **Fallo de compilación silente en Revit 2023 (`Release.R23`)**:
   Al compilar en .NET Framework 4.8 / Revit 2023, existían 9 errores de compilación (`CS1061` y `CS1503`) en [SelectionFilterViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/ViewModels/SelectionFilterViewModel.cs) debido a que `ElementId.Value` (introducido en Revit 2024 para IDs de 64 bits) no existe en la API de Revit 2023 (donde se utiliza `IntegerValue` de 32 bits), y a un casteo innecesario `(long)` incompatible con el constructor de `ElementId` en 2023.
2. **Impacto en el bundle anterior**:
   Debido a ese error de compilación, el script empaquetador no pudo generar binarios frescos de 2023 y arrastró una versión antigua (de mayo de 2026):
   - Dicha versión antigua **no incluía los iconos personalizados** en las ventanas WPF (`Icon="pack://application:,,,/FilterPlus;component/Resources/Icons/RibbonIcon32.png"`), por lo que Revit 2023 le asignaba automáticamente a la ventana el icono de la aplicación anfitriona: el **logo oficial de Revit ("R")**.
   - Dicha versión antigua **no tenía la carpeta `Resources/help.html`** copiada en `Contents/2023/`.
3. **Sincronización del Bundle y del Revit local**:
   El usuario necesita que el bundle empaquetado sea la versión final de **Producción** (Release, sin ventanas de depuración) y que su instalación local en Revit se actualice con la versión **Debug** (que abre automáticamente la ventana `LogView` / debug log en tiempo real).

---

## Proposed Changes

### Componente 1: Corrección de Compatibilidad Multi-versión (Revit 2023 vs 2024+)

#### [MODIFY] [SelectionFilterViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/ViewModels/SelectionFilterViewModel.cs)
- Adaptar las llamadas a `ElementId.Value` vs `ElementId.IntegerValue` mediante `#if REVIT2024_OR_GREATER`:
  - En la serialización de `SavedElementKey` (líneas 1827-1828).
  - En la recuperación/instanciación de `ElementId` en `ApplySavedSelectionAsync` (línea 1992, 2008, 2093-2094).
  - En el comparador `ElementIdEqualityComparer` (líneas 2280 y 2286).

#### [MODIFY] [FilterPlus.csproj](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/FilterPlus.csproj)
- Asegurar que `Resources\help.html` se copie siempre a la carpeta de salida en todos los targets usando `<Content Include="Resources\help.html"><CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory></Content>`.

---

### Componente 2: Resolución Robusta de Ayuda Contextual F1

#### [MODIFY] [Application.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Application.cs)
- Implementar búsqueda resiliente para `help.html` en `Application.cs`:
  1. Carpeta local `[AssemblyDir]\Resources\help.html`.
  2. Carpeta local `[AssemblyDir]\Resources\Help.html`.
  3. Raíz del bundle `[AssemblyDir]\..\Resources\help.html`.
  4. Alias `[AssemblyDir]\Resource\help.html`.

---

### Componente 3: Activación Condicional del Debug Log en Entorno Local

#### [MODIFY] [SelectionFilterView.xaml.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Views/SelectionFilterView.xaml.cs)
- Reemplazar el código comentado de `_logView` por una directiva `#if DEBUG`:
  ```csharp
  #if DEBUG
          _logView = new LogView();
          _logView.Show();
          this.Closed += (s, e) => _logView?.Close();
  #endif
  ```
  - En compilaciones **Debug** (para el Revit del usuario): la ventana `LogView` se abre automáticamente.
  - En compilaciones **Release** (para Autodesk App Store): el código queda excluido sin intervención manual.

---

### Componente 4: Actualización del Script y del Paquete Bundle

#### [MODIFY] [build-bundle.ps1](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-appstore-bundle/scripts/build-bundle.ps1)
- Añadir `"2023"` en `$TargetYears`: `@("2023", "2024", "2025", "2026", "2027")`.
- Garantizar que para **todas** las versiones (incluida 2023), se cree y copie explícitamente la carpeta `Resources` con `help.html` y una copia de compatibilidad `Resource/help.html`.
- Regenerar el paquete `FilterPlus.bundle` y `FilterPlus.bundle.zip` bajo `FilterPlus/FilterPlusPublishPackage/` y `FilterPlus/Deploy/`.

---

### Componente 5: Despliegue Local en Modo Debug

- Compilar `Debug.R24` (y `Debug.R23`) con `DeployAddin=true` hacia `%APPDATA%\Autodesk\Revit\Addins\2024\` para que el usuario disponga de la versión interactiva con la ventana de Debug Log activa y todos los iconos propios aplicados.

---

## Verification Plan

### Automated / Build Verification
- Compilar limpiamente `Release.R23` con `dotnet build -c Release.R23` sin errores.
- Compilar las versiones restantes: `Release.R24`, `Release.R25`, `Release.R26`, `Release.R27`.
- Ejecutar `build-bundle.ps1` y verificar que:
  - `Contents/2023/` contiene `Resources/help.html` (y `Resource/help.html`).
  - `Contents/2023/FilterPlus.dll` contiene las referencias a los recursos embebidos `RibbonIcon32.png` y ningún icono genérico de Revit.
  - El archivo ZIP de despliegue (`FilterPlus.bundle.zip`) queda actualizado y listo para subir a Autodesk Store.
- Compilar `Debug.R24` con `DeployAddin=true` y verificar que los binarios y el `.addin` se copian en `%APPDATA%\Autodesk\Revit\Addins\2024`.

### Manual Verification
- Solicitar al usuario que abra su Revit (2024) y confirme:
  1. Al iniciar FilterPlus, se abre la ventana de `Debug Log` en tiempo real.
  2. La barra de título de la ventana muestra el icono azul de embudo de FilterPlus y NO el logo "R" de Revit.
  3. Al pulsar F1 sobre el botón de FilterPlus en el Ribbon, se carga la página de ayuda `help.html`.
