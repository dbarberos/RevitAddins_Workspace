# Informe de Depuración: Excepción al Establecer 'System.Windows.ResourceDictionary.Source' en TransferPlus

*Fecha:* 2026-09-17  
*Componente:* Interfaz WPF / Recursos XAML (`TransferPlusView.xaml`)  
*Resolución:* Migración a la Arquitectura Inline de FilterPlus

---

## 1. Síntoma
Al ejecutar el comando de lanzamiento de `TransferPlus` en Revit, se interrumpe la apertura de la ventana y se muestra el cuadro de error nativo de Revit:
> **Fallo de comando para comando externo**  
> *Revit no ha podido completar el comando externo. Solicite asistencia a su proveedor...*  
> *Revit ha encontrado Se produjo una excepción al establecer la propiedad 'System.Windows.ResourceDictionary.Source'.*

---

## 2. Causa Raíz
1. **Host Nativo C++ sin Aplicación WPF Estándar:** Autodesk Revit es un proceso Win32 que aloja plugins .NET sin proporcionar el ciclo de vida de una `System.Windows.Application` estándar. Por ello, `Application.Current` es nulo o carece de la resolución Pack URI para recursos secundarios.
2. **Dependencia Externa en `TransferPlusView.xaml`:** Se cargaba el archivo de estilos mediante:
   ```xaml
   <ResourceDictionary Source="pack://application:,,,/TransferPlus;component/Resources/Styles/TransferPlusStyles.xaml"/>
   ```
   Al instanciarse la ventana, el motor BAML de WPF intenta resolver la URI de la aplicación anfitriona y falla con `System.Windows.Markup.XamlParseException`.
3. **Contaminación de BAML por Paquetes de Salida:** En `TransferPlus.csproj` no se excluían `Deploy/` ni `TransferPlusPublishPackage/`, haciendo que MSBuild indexara decenas de copias redundantes de archivos XAML en el ensamblado.

---

## 3. Comparativa frente a FilterPlus
En `FilterPlus` (`SelectionFilterView.xaml`), **nunca se utilizó una referencia externa de diccionario**. Todos los estilos, conversores y plantillas (`HeaderIconButtonStyle`, `SwitchStyle`, `CheckboxTreeTemplate`, scrollbars, etc.) están declarados **directamente dentro de `<Window.Resources>`**. Esto permite que se resuelvan al 100% en memoria local sin invocar al resolutor Pack URI del proceso Revit.

---

## 4. Acciones Realizadas
1. Se añadieron todos los estilos directamente dentro de `<Window.Resources>` en `TransferPlusView.xaml`.
2. Se eliminó la etiqueta `<ResourceDictionary.MergedDictionaries>` y la llamada a `TransferPlusStyles.xaml`.
3. Se eliminó el archivo innecesario `TransferPlus/Resources/Styles/TransferPlusStyles.xaml`.
4. Se agregó `<DefaultItemExcludes>$(DefaultItemExcludes);Deploy\**;TransferPlusPublishPackage\**</DefaultItemExcludes>` a `TransferPlus.csproj`.
5. Se actualizó el repositorio global de conocimiento (`revit-addin-gui-design` y `AGENTS.md`) mediante `apply-skillopt` para que cualquier add-in futuro adopte esta regla de forma obligatoria.
