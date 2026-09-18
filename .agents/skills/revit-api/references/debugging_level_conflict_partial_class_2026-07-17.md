# Debugging Report: Missing partial modifier with CommunityToolkit.Mvvm [CS0260]

## Info
* **Fecha:** 2026-07-17
* **Proyecto:** TransferPlus
* **Componente:** `LevelConflict.cs`
* **Tecnología:** C# 12 / .NET 8 / CommunityToolkit.Mvvm 8.4.2

---

## 1. El Problema
Al compilar el proyecto tras implementar la clase `LevelConflict`, el compilador arrojó el siguiente error:
```text
Models\LevelConflict.cs(15,18): error CS0260: Falta el modificador parcial en la declaración de tipo 'LevelConflict'; existe otra declaración parcial de este tipo
```

---

## 2. Causa Raíz
La clase `LevelConflict` contiene la anotación `[RelayCommand]` sobre un método privado para delegar el comando del botón en la UI:
```csharp
[RelayCommand]
private void SelectLevelAndMap(string levelName) { ... }
```
El generador de código de **CommunityToolkit.Mvvm** intercepta esta anotación y autogenera una clase parcial en segundo plano (en el archivo `LevelConflict.g.cs`) que implementa la propiedad pública del comando (`SelectLevelAndMapCommand`). 

En C#, si parte de una clase se genera automáticamente como parcial, la declaración principal que hace el desarrollador **también debe llevar obligatoriamente** el modificador `partial`. De lo contrario, el compilador genera el error `CS0260` al intentar unificar el tipo.

---

## 3. Solución Aplicada
Se añadió el modificador `partial` a la definición de la clase:

### Antes:
```csharp
namespace TransferPlus.Models
{
    public class LevelConflict : ObservableObject
    {
        ...
    }
}
```

### Después:
```csharp
namespace TransferPlus.Models
{
    public partial class LevelConflict : ObservableObject
    {
        ...
    }
}
```

Esta adición permite que el compilador combine la clase declarada a mano con la generada por el kit de herramientas de MVVM, resolviendo el conflicto de compilación de inmediato.
