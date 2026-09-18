# Walkthrough: Eliminación Selectiva de Familias y Tipos en Modelo Activo (Botón Papelera)

**Fecha:** 2026-08-07  
**Componentes Modificados:** `TransferPlusViewModel.cs`, `TransferPlusView.xaml`  

---

## 📌 Resumen de la Funcionalidad

1. **Habilitación Condicional (`CanDeleteSelectedFamilies`):**  
   - Activado solo en **Modelo Activo Abierto** (`Adoc != null` Y `EsVinculo == false`) con al menos un elemento marcado.
   - Deshabilitado en Modelos Vinculados, Directorios Locales, Azure Storage y Autodesk Docs/ACC.

2. **Lógica de Borrado:**  
   - Todos los tipos marcados -> `doc.Delete(family.Id)` (Familia completa).
   - Solo algunos tipos marcados -> `doc.Delete(symbol.Id)` (Tipos individuales). La familia se preserva.

3. **Mensaje de Confirmación en Inglés:**  
   - Mensaje `Confirm Element Deletion` informando de la cantidad de familias y tipos a eliminar y advirtiendo sobre la eliminación de instancias colocadas en el modelo.

---

## 🟢 Estado
- **Compilación:** 0 Errores.
- **Despliegue:** `%APPDATA%\Autodesk\Revit\Addins\2024\TransferPlus\TransferPlus.dll`
