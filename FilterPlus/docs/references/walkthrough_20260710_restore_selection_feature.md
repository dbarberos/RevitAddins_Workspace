# Walkthrough: Sincronización e Inclusión Automática de Vínculos al Restaurar Selección en FilterPlus

Hemos completado con éxito la implementación del botón de restauración de selección en el add-in **FilterPlus** en la rama `PreSelection`.

---

## Cambios Realizados

### 1. Interfaz de Usuario (WPF / XAML)
* **Archivo**: [SelectionFilterView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Views/SelectionFilterView.xaml)
* Se ha modificado el encabezado "Elements" añadiendo una nueva columna al Grid para colocar el botón de restauración.
* Se ha utilizado una plantilla de control (`ControlTemplate`) personalizada que renderiza un icono vectorial (Path) circular de restauración de 20x20 px, con los estilos visuales del botón de configuración:
  * Color gris oscuro en MouseOver.
  * Opacidad de `0.3` cuando está deshabilitado (`IsEnabled="False"`).
* Se enlazó el botón a:
  * `Command="{Binding RestoreRevitSelectionCommand}"`
  * `IsEnabled="{Binding CanRestoreRevitSelection}"`

### 2. Sincronización en Activación de Ventana
* **Archivo**: [SelectionFilterView.xaml.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Views/SelectionFilterView.xaml.cs)
* Se suscribió al evento `Activated` de la ventana WPF para disparar `viewModel.UpdateCanRestore()` de manera asíncrona cada vez que el usuario haga clic de vuelta en la ventana después de interactuar con Revit.

### 3. Lógica del ViewModel
* **Archivo**: [SelectionFilterViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/ViewModels/SelectionFilterViewModel.cs)
* **Propiedad `CanRestoreRevitSelection`**: Booleano observable que indica si el estado del árbol de FilterPlus difiere de la selección activa de Revit.
* **Sincronización (`UpdateCanRestore`)**:
  * Ejecuta una llamada en el hilo de la API de Revit para obtener los IDs y referencias seleccionados en el viewport (`GetElementIds()` y `GetReferences()`).
  * Construye un conjunto de claves `ElementSelectionKey` mapeando de manera separada los elementos de la base y los elementos pertenecientes a vínculos (resolviendo el id de la instancia del vínculo y el id interno del elemento).
  * Compara si ambos conjuntos coinciden exactamente (`SetEquals`). Si difieren, habilita el botón; si son iguales, lo deshabilita.
* **Comando de Restauración (`RestoreRevitSelectionCommand`)**:
  * Obtiene la selección actual de Revit en el hilo de la API.
  * **Auto-inclusión de Vínculos**: Si detecta elementos seleccionados pertenecientes a un modelo vinculado que no está en la lista de modelos de filtrado actual (`SelectedModels`), añade de manera automática ese vínculo a `SelectedModels`, actualiza su visualización y vuelve a computar los scopes (`LoadScopesAndHandleCache`) en el hilo de Revit.
  * Actualiza la selección del explorador (`_persistentCheckedIds`) con los elementos de Revit.
  * Cambia el alcance (`CurrentScope`) a `SelectionScope.CurrentSelection`.
  * Reconstruye la estructura del árbol (`BuildTree()`) y refresca los checks.

---

## Verificación

* **Compilación**: El proyecto se compila de forma limpia sin ningún error en la configuración `Debug.R24`.
  ```powershell
  dotnet build FilterPlus/FilterPlus.csproj -c Debug.R24
  ```
  **Resultado**: 0 Errores.
