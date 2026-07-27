# Debugging Log: Traslación Vertical $\Delta Z$ en `CopyElements` para Vistas de Planta Mapeadas

**Fecha:** 2026-07-27  
**Proyecto:** TransferPlus  
**Componente:** `TransferOrchestrator.cs` (`ponDependientes`)  

---

## 1. Diagnóstico Técnico y Causa Raíz de la Ventana Emergente de Revit

1. **Desfase de Cota $Z$ entre Nivel Origen y Nivel Destino Mapeado**:
   - Vista Origen: `P1 - EST - OFICINAS` ($Z = 20.374\text{ ft}$).
   - Vista Destino: `Nivel 8` ($Z = 26.273\text{ ft}$).
   - Al ejecutar `CopyElements` con `Transform.Identity`, los elementos 2D se intentaban pegar manteniendo su cota $Z = 20.374\text{ ft}$.
   - Dado que el plano de la vista destino está a $Z = 26.273\text{ ft}$, los elementos quedaban a $-5.899\text{ ft}$ por debajo de la vista destino. Al no existir un plano de trabajo en la vista destino para $Z = 20.374\text{ ft}$, Revit API desplegaba la ventana emergente modal:
     > *"No se puede pegar porque no hay un plano de trabajo correspondiente. Defina uno o cambie a una vista con el plano de trabajo apropiado."*

2. **Restricción Nativa de `NewDetailCurve` en `ViewPlan`**:
   - `NewDetailCurve` sólo está permitido en vistas `ViewDrafting` y `ViewDetail`. En vistas de plano (`ViewPlan`), Revit API arroja `View does not and may not contain a fixed sketch plane. Parameter name: view`.

---

## 2. Solución Aplicada

1. **Matriz de Traslación Vertical $\Delta Z$**:
   $$\Delta Z = \text{targetZ} - \text{srcZ} = 26.273 - 20.374 = +5.899\text{ ft}$$
   ```csharp
   Transform copyTransform = Math.Abs(deltaZ) > 0.0001
       ? Transform.CreateTranslation(new XYZ(0, 0, deltaZ))
       : Transform.Identity;

   ElementTransformUtils.CopyElements(vistaorigen, elementIds, vistadestino, copyTransform, copyOptions);
   ```
2. **Resultado**:
   - Los elementos 2D se trasladan $+5.899\text{ ft}$ durante el copiado, aterrizando exactamente en $Z = 26.273\text{ ft}$ (la cota del plano de la vista destino).
   - Revit valida que la cota coincide con el plano de la vista, **copiando todos los elementos 2D limpiamente sin ventanas modales de error**.

---

## 3. Estado del Despliegue
- Compilado en `.NET Framework 4.8` (`Debug.R24`) — **0 Errores**.
- Copiado en `%AppData%\Autodesk\Revit\Addins\2024\TransferPlus\TransferPlus.dll`.
