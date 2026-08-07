# Walkthrough: Inserción Directa DENTRO del Grupo Nativo "Configuración" (Settings) de la Pestaña "Gestionar" (Manage)

**Fecha:** 2026-08-07  
**Componentes Modificados:** `Application.cs`  

---

## 📌 Descripción del Requisito y Solución

Para la opción *"Place on Revit default tab"* (`TabOption.RevitDefault`):
- El botón **TransferPlus** se inserta **directamente dentro del panel de grupo nativo de Configuración** (*Settings*) de la **pestaña Gestionar** (*Manage*).
- No crea un grupo propio ni se coloca al final de la pestaña, sino que comparte el grupo de herramientas nativas de Configuración (junto a *"Configuración adicional"*).

---

## 🟢 Estado
- **Compilación:** 0 Errores.
- **Despliegue:** `%APPDATA%\Autodesk\Revit\Addins\2024\TransferPlus\TransferPlus.dll`
