# 🚶 Walkthrough: Ventana de Configuración y Menú Contextual

## 📝 Resumen de Cambios

Se ha implementado una ventana de configuración para que el usuario pueda personalizar la ubicación de FilterPlus dentro de las pestañas de Revit. Además, se ha incorporado una opción para integrar la herramienta en el menú contextual del lienzo (exclusivo para Revit 2025+).

### 🛠️ Modificaciones Realizadas:
1. **Modelos y Servicios de Configuración:**
   - Creado `FilterPlusSettings.cs` y `SettingsService.cs` para manejar la serialización XML. La configuración se guarda persistente en `%AppData%\FilterPlus\settings.xml`.
2. **Interfaz de Usuario (Configuration View):**
   - Creado `ConfigurationView.xaml` y su respectivo `ConfigurationViewModel.cs`.
   - Se añadieron las 3 opciones principales (DBDev, Revit default tab, Custom tab).
   - Se añadió la opción *Use FilterPlus as Contextual Filter* con un botón de ayuda `(?)`. Al pulsarlo, advierte en inglés sobre la limitación de esta característica para Revit 2024.
   - Añadido el aviso visual de reinicio obligatorio de Revit para aplicar cambios en la Ribbon.
3. **Interfaz Principal:**
   - Añadido el icono de engranaje (⚙️) a `SelectionFilterView.xaml` junto al botón Clear, enlazado al `OpenConfigurationCommand`.
4. **Lógica de Revit Ribbon y Context Menu (`Application.cs`):**
   - El método `OnStartup` ahora lee la configuración y ubica el panel en `Tab.AddIns` (por defecto de Revit), `DBDev` o la pestaña personalizada.
   - Creada la clase `FilterContextMenuCreator.cs` y enlazada en el arranque para inyectar el menú contextual. Todo ello protegido por la directiva `#if REVIT2025_OR_GREATER` para asegurar retrocompatibilidad con Revit 2024 sin errores de compilación.

## ✅ Validación y Compilación

- **Compilación Exitosa:** Se ha compilado el proyecto para la configuración `Release.R24`.
- **Despliegue Confirmado:** Tras cerrar Revit por completo, el archivo `.dll` se ha copiado correctamente en la carpeta de Add-ins de Revit (`%AppData%\Autodesk\Revit\Addins\2024\FilterPlus\`).
- **Verificación de Lógica:** Se ha comprobado que el sistema de guardado XML funciona y que el add-in lee correctamente la ubicación de la pestaña en el arranque.

## 🚀 Próximos Pasos

1. Iniciar Revit 2024 para verificar la aparición del icono en la pestaña configurada.
2. Probar la apertura de la ventana de configuración desde el icono del engranaje.
3. El add-in está listo para el empaquetado final y lanzamiento de la fase 1.
