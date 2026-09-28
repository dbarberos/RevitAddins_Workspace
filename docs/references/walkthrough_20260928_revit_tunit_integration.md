# Walkthrough — Integración de Testing Autónomo In-Process con Nice3point.TUnit.Revit

**Fecha:** 2026-09-28  
**Autor:** Antigravity / Polyglot Architect  
**Estado:** ✅ Implementado y Verificado  

---

## 1. Resumen de la Implementación

Se ha establecido e integrado en el workspace el nuevo flujo de trabajo para **pruebas unitarias y de integración in-process (UI y DB)** basadas en la biblioteca oficial **`Nice3point.TUnit.Revit`** (TUnit y Microsoft.Testing.Platform).

Este flujo permite que el agente:
1. Pruebe no solo la base de datos de Revit (`Document`, transacciones, parámetros, vistas), sino también la interfaz (`UIApplication`, Ribbon tabs, paneles, botones, selección y dockable panes).
2. Valide autónomamente cada nueva funcionalidad o modificación sin necesidad de que el usuario lo solicite en el chat.
3. Ejecute un ciclo de auto-reparación ("Self-Healing Loop") al detectar fallos en la consola, corrigiendo el código y repitiendo la prueba hasta que pase en verde.

---

## 2. Artefactos y Componentes Generados

### A. Skill Modular: `.agents/skills/revit-tunit-testing/`
*   [`SKILL.md`](file:///b:/REVIT/C#/RevitAddins_Workspace/.agents/skills/revit-tunit-testing/SKILL.md): Manifiesto e índice semántico del skill (bajo consumo de tokens).
*   [`references/revit_unit_architecture.md`](file:///b:/REVIT/C#/RevitAddins_Workspace/.agents/skills/revit-tunit-testing/references/revit_unit_architecture.md): Guía conceptual completa de `RevitApiTest`, `RevitThreadExecutor`, `Application` (UIApplication), aislamiento de estado con `[Before(Test)]` / `[HookExecutor]`, multi-versión con `RevitVersion` y comandos de CLI.
*   [`references/autonomous_testing_guidelines.md`](file:///b:/REVIT/C#/RevitAddins_Workspace/.agents/skills/revit-tunit-testing/references/autonomous_testing_guidelines.md): Reglas de comportamiento del agente, matriz de diagnóstico de errores (violaciones STA, warnings modales, null references, transacciones) y ciclo de auto-curación.
*   [`assets/TestProjectTemplate.csproj`](file:///b:/REVIT/C#/RevitAddins_Workspace/.agents/skills/revit-tunit-testing/assets/TestProjectTemplate.csproj): Plantilla base de proyecto `.csproj` con `Nice3point.Revit.Sdk` y `Nice3point.TUnit.Revit`.
*   [`assets/RevitUiIntegrationTestTemplate.cs`](file:///b:/REVIT/C#/RevitAddins_Workspace/.agents/skills/revit-tunit-testing/assets/RevitUiIntegrationTestTemplate.cs): Plantilla C# para pruebas de interfaz (Ribbon, paneles, botones y metadatos de UI).
*   [`assets/RevitDbTransactionTestTemplate.cs`](file:///b:/REVIT/C#/RevitAddins_Workspace/.agents/skills/revit-tunit-testing/assets/RevitDbTransactionTestTemplate.cs): Plantilla C# para pruebas transaccionales con documento métrico en blanco aislado y preprocesador de avisos (`SilentWarningSwallower`).
*   [`scripts/run_revit_tests.ps1`](file:///b:/REVIT/C#/RevitAddins_Workspace/.agents/skills/revit-tunit-testing/scripts/run_revit_tests.ps1): Script ejecutor en PowerShell con validación de versión (`R24`, `R25`, `R26`, `R27`).

---

### B. Quality Gate 6.2 en `AGENTS.md`
En el archivo central de instrucciones [AGENTS.md](file:///b:/REVIT/C#/RevitAddins_Workspace/AGENTS.md) se incorporó la sección:
*   **`6.2. Autonomous In-Process Testing Gate (Nice3point.TUnit.Revit)`**: Obliga al agente a escribir o verificar pruebas para toda nueva lógica de negocio o interfaz, ejecutarlas por terminal y resolver cualquier error de forma autónoma antes de dar por cerrada la tarea.
*   Registro oficial en la tabla de **Available Skills**.

---

### C. Documentación del Proyecto en `docs/`
*   [`docs/references/implementation_plan_20260928_revit_tunit_integration.md`](file:///b:/REVIT/C#/RevitAddins_Workspace/docs/references/implementation_plan_20260928_revit_tunit_integration.md): Plan de arquitectura y fases de ejecución.
*   [`docs/references/walkthrough_20260928_revit_tunit_integration.md`](file:///b:/REVIT/C#/RevitAddins_Workspace/docs/references/walkthrough_20260928_revit_tunit_integration.md): Este informe técnico de cierre.

---

## 3. Guía Rápida de Comandos para el Desarrollador

Para lanzar las pruebas de integración en cualquier momento desde la terminal:

```powershell
# Ejecución directa con Microsoft.Testing.Platform runner:
dotnet run --project <NombreAddin>.Tests/<NombreAddin>.Tests.csproj -c "Release.R26"

# O mediante el script operativo del skill:
powershell -File .agents/skills/revit-tunit-testing/scripts/run_revit_tests.ps1 -ProjectPath "<NombreAddin>.Tests/<NombreAddin>.Tests.csproj" -RevitVersion "R26"
```

---

## 4. Conclusión

El entorno y las instrucciones del agente están completamente adaptados. A partir de ahora, cada vez que se implemente una nueva característica de Revit o de interfaz WPF, el agente aplicará este Quality Gate autónomo, garantizando robustez y código verificado en el runtime de Revit.
