# Debugging Report: FailuresAccessor.CanCommitElements is missing [CS1061]

## Info
* **Fecha:** 2026-07-17
* **Proyecto:** TransferPlus
* **Componente:** `WarningSwallower.cs`
* **Tecnología:** Revit 2024 API / C#

---

## 1. El Problema
Al implementar la lógica de resolución automática de fallos y errores del skill `revit-api-resilience`, se produjo el siguiente error en tiempo de compilación:
```text
C:\Users\david.barbero\Documents\DOCUMENTOS\ALTEN\Workbench\RevitAddins_Workspace\RevitAddins_Workspace\TransferPlus\Services\WarningSwallower.cs(25,155): error CS1061: "FailuresAccessor" no contiene una definición para "CanCommitElements" ni un método de extensión accesible "CanCommitElements" que acepte un primer argumento del tipo "FailuresAccessor"
```

---

## 2. Causa Raíz
La plantilla o blueprint de código incluida en el skill global de resiliencia (`.agents/skills/revit-api-resilience/assets/WarningSwallower.cs`) contenía un método de verificación inexistente en la clase `FailuresAccessor` de Revit:
```csharp
if (failuresAccessor.CanCommitElements()) { ... }
```
En el SDK de la API de Autodesk Revit (desde versiones anteriores hasta Revit 2024+), la clase `FailuresAccessor` **no posee** ningún método denominado `CanCommitElements`. Para comprobar si un error (`FailureMessageAccessor`) dispone de resoluciones que se puedan aplicar mediante programación en lugar de forzar el rollback, se debe consultar el estado de resoluciones de la propia anomalía a nivel del elemento individual.

---

## 3. Solución Aplicada
Se reemplazó la llamada inválida por la evaluación del método `HasResolutions()` expuesto por el objeto `FailureMessageAccessor` de la anomalía:

### Antes:
```csharp
else if (severity == FailureSeverity.Error)
{
    if (failuresAccessor.CanCommitElements())
    {
        failuresAccessor.ResolveFailure(failure);
        return FailureProcessingResult.ProceedWithCommit;
    }
    return FailureProcessingResult.ProceedWithRollBack;
}
```

### Después:
```csharp
else if (severity == FailureSeverity.Error)
{
    LoggerService.LogWarning($"Revit Hard Error encountered: '{failure.GetDescriptionText()}'. Default Resolution attempt: {(failure.HasResolutions() ? "Resolve and Commit" : "Rollback")}");
    if (failure.HasResolutions())
    {
        try
        {
            failuresAccessor.ResolveFailure(failure);
            return FailureProcessingResult.ProceedWithCommit;
        }
        catch { }
    }
    return FailureProcessingResult.ProceedWithRollBack;
}
```

Al utilizar `failure.HasResolutions()`, la API valida de forma segura si la incidencia dispone de alternativas predeterminadas (como desunir geometrías), permitiendo llamar de manera segura a `ResolveFailure` y compilar el proyecto sin errores.
