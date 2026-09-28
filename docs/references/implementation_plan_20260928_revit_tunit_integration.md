# Plan de Implementación — Integración de Testing Autónomo In-Process con Nice3point.TUnit.Revit

**Fecha:** 2026-09-28  
**Autor:** Antigravity / Polyglot Architect  
**Objetivo:** Establecer un flujo de trabajo autónomo gobernado para que el agente escriba, ejecute y auto-repare pruebas unitarias y de integración (UI y DB) directamente en el contexto real de la API de Revit mediante `Nice3point.TUnit.Revit` (basado en TUnit y Microsoft.Testing.Platform), sin intervención manual ni sobrecarga de tokens.

---

## 1. Diagnóstico y Arquitectura Seleccionada

### 1.1 El Problema
Tradicionalmente, las pruebas en add-ins de Revit estaban limitadas a mocks desconectados de la base de datos o frameworks lentos/pesados sin acceso al contexto de UI (`UIApplication`, Ribbon, WPF).
Con el lanzamiento de **Nice3point.TUnit.Revit (RevitUnit)**:
- Se permite la ejecución dentro del hilo de Revit (STA) mediante `[TestExecutor<RevitThreadExecutor>]` y `[HookExecutor<RevitThreadExecutor>]`.
- Se habilita el acceso total a `Application` (`UIApplication`), Ribbon, selección, vistas y paneles acoplables.
- Se ejecuta directamente vía CLI mediante `dotnet run -c "Release.R26"` o `dotnet test`.

### 1.2 La Solución Híbrida Gobernada (Sin Bloat)
1. **Regla de Flujo Activo (Quality Gate 6.2 en `AGENTS.md`):**
   - Una directriz obligatoria de ~15 líneas que fuerza al agente a crear/ejecutar pruebas tras modificar lógica de negocio o UI y ejecutar el bucle de auto-corrección ("self-healing") si fallan.
2. **Skill Modular Técnico (`.agents/skills/revit-tunit-testing/`):**
   - Aloja todo el conocimiento profundo, atributos, plantillas de `.csproj` y tests C#, consumiendo 0 tokens de base y cargándose solo bajo demanda.
3. **Plantillas y Scripts Operacionales:**
   - Plantilla de `.csproj` multi-versión (`RevitVersion`).
   - Plantilla de test de UI (`RevitUiIntegrationTestTemplate.cs`).
   - Plantilla de test transaccional aislado (`RevitDbTransactionTestTemplate.cs`).
   - Script PowerShell de ejecución rápida (`scripts/run_revit_tests.ps1`).

---

## 2. Tareas de Implementación

- [ ] **Tarea 1:** Crear la estructura física del skill `.agents/skills/revit-tunit-testing/` (`SKILL.md`, `references/`, `assets/`, `scripts/`).
- [ ] **Tarea 2:** Escribir la documentación técnica profunda en `references/revit_unit_architecture.md`.
- [ ] **Tarea 3:** Escribir las pautas de testing autónomo y ciclo de auto-reparación en `references/autonomous_testing_guidelines.md`.
- [ ] **Tarea 4:** Crear los assets de código reutilizables:
  - `assets/TestProjectTemplate.csproj`
  - `assets/RevitUiIntegrationTestTemplate.cs`
  - `assets/RevitDbTransactionTestTemplate.cs`
  - `scripts/run_revit_tests.ps1`
- [ ] **Tarea 5:** Actualizar `AGENTS.md` inyectando el Quality Gate 6.2 y registrando el nuevo skill en la tabla de skills.
- [ ] **Tarea 6:** Generar el informe de cierre en `docs/references/walkthrough_20260928_revit_tunit_integration.md`.
