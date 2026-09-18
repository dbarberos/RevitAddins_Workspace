# Walkthrough: Resolución del Botón "Logs Window" e Intercambio de Botones

**Fecha:** 2026-08-07  
**Componentes Modificados:** `ConfigurationView.xaml`, `ConfigurationViewModel.cs`, `TransferPlusView.xaml.cs`  

---

## 📌 Resumen de Mejoras e Incidencias Resueltas

1. **Resolución del Fallo al Pulsar "Logs Window":**  
   - **Causa Raíz:** En add-ins de Revit en C#, `System.Windows.Application.Current` devuelve `null` porque `Revit.exe` es una aplicación Win32 nativa. Intentar buscar ventanas mediante `Application.Current.Windows` fallaba en silencio.
   - **Solución:** Se implementó un delegado de acción directo (`ConfigurationViewModel.ToggleDebugWindowAction`) registrado en el constructor de `TransferPlusView`. Se ejecuta sobre `this.Dispatcher.Invoke(() => ToggleDebugLogWindow())`, respondiendo siempre a la pulsación.

2. **Intercambio de Botones:**  
   - Posición de botones en `ConfigurationView.xaml`:
     1. **`Logs Window`** (`Width="92"`)
     2. **`Cancel`** (`Width="92"`)
     3. **`Save`** (`Width="92"`, fondo `#007ACC`)

---

## 🟢 Estado de Compilación y Despliegue
- **Compilación:** 0 Errores.
- **Despliegue:** `%APPDATA%\Autodesk\Revit\Addins\2024\TransferPlus\TransferPlus.dll`
