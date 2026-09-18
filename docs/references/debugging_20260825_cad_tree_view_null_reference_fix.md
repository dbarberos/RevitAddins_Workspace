# Debugging Report: Fix NullReferenceException in LoadCadItemsFromSource / BuildCadTree

**Fecha:** 2026-08-25  
**Proyecto:** TransferPlus  
**Módulos afectados:** `ViewModels/TransferPlusViewModel.cs`  
**Estado:** RESUELTO & VERIFICADO (0 Errores)

---

## 1. Descripción del Problema

Al cambiar la fuente activa en el modo CAD Details Manager a un modelo de Revit con vistas de diseño que no estaban colocadas en un plano (Sheet) (e.g. 78 Drafting Views en el proyecto `2510000177_KRN_ARQ_G_00`), el addin lanzaba la ventana de error:
`Ocurrió un error en LoadCadItemsFromSource: Referencia a objeto no establecida como instancia de un objeto.`

Log:
```text
[13:26:01.225] ERROR in LoadCadItemsFromSource: Referencia a objeto no establecida como instancia de un objeto.
[13:26:01.224] INFO: BuildCadTree: Generating TreeView nodes from collected CAD details...
[13:26:01.224] INFO: LoadCadItemsFromSource: Collection complete. Collected 78 items. Initiating tree build...
[13:26:01.223] INFO: DraftingViewProvider: Recolectadas 78 vistas de diseño en '2510000177_KRN_ARQ_G_00'.
```

---

## 2. Diagnóstico y Causa Raíz

En `TransferPlusViewModel.BuildCadTree()`:
Cuando la opción de ordenación activa es `CadSortByView`:
```csharp
var firstWithSheet = viewGroup.FirstOrDefault(x => !string.IsNullOrWhiteSpace(x.SheetName));
if (firstWithSheet != null && !string.IsNullOrWhiteSpace(firstWithSheet.SheetName))
{
    viewDisplayName = $"{viewGroup.Key} [{firstWithSheet.SheetName}]";
}

CadDetailItemModel? viewCadItem = null;
var firstWithView = viewGroup.FirstOrDefault(x => x.OwnerViewId != null && x.OwnerViewId != ElementId.InvalidElementId);
if (firstWithView != null && firstWithView.SourceDocument is Document viewDoc && firstWithView.OwnerViewId != null)
{
    var ownerView = viewDoc.GetElement(firstWithView.OwnerViewId) as View;
    viewCadItem = new CadDetailItemModel
    {
        Name = viewDisplayName,
        ViewName = viewGroup.Key,
        SheetName = firstWithSheet.SheetName, // <-- Excepción si firstWithSheet es null (elementos sin plano)
        SheetId = firstWithSheet.SheetId,     // <-- Excepción si firstWithSheet es null
```

Si ninguna de las vistas o elementos del grupo está colocado en un plano, `firstWithSheet` es `null`. Al intentar acceder directamente a `firstWithSheet.SheetName` y `firstWithSheet.SheetId`, el runtime de .NET lanzaba un `NullReferenceException`.

---

## 3. Solución Implementada

Se aplicó el operador de navegación segura `?.` con fallback de cadena vacía:
```csharp
SheetName = firstWithSheet?.SheetName ?? string.Empty,
SheetId = firstWithSheet?.SheetId,
```

---

## 4. Verificación de Compilación

```powershell
dotnet build TransferPlus/TransferPlus.csproj -c Debug.R24 /p:DeployAddin=false
=> 0 Errores, Tiempo: 09.46s
```
