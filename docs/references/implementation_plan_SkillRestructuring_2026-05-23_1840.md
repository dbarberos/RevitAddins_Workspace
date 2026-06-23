# Plan de Implementación - Modularización de Skills Restantes

Este plan detalla el proceso técnico para completar la migración de los skills de Revit y C# restantes (`revit-addin-testing`, `revit-addin-doc-manager`, `revit-addin-icon-manager` y `revit-addin-installer-manager`) a la arquitectura modular (`references/`, `assets/`, `scripts/`). Esto optimiza el consumo de tokens y la mantenibilidad del agente.

## User Review Required

> [!IMPORTANT]
> Esta reestructuración **no cambia la lógica de comportamiento ni las reglas del agente**, sino que distribuye el conocimiento masivo en archivos especializados dentro de cada skill. 
> Todos los enlaces de los archivos `SKILL.md` se actualizarán con rutas relativas a las carpetas `references/` y `assets/`, garantizando que sean completamente legibles y navegables para cualquier LLM consumidor o por el script de compilación `build.ps1`.

## Proposed Changes

A continuación se detallan los cambios organizados por cada skill component:

---

### Component: `revit-addin-testing`

Se extraerán todas las guías de estrategia de pruebas, plantillas de configuración y ejemplos de código unitario para reducir el archivo principal de 290 líneas a un índice ligero.

#### [NEW] [testing_strategy.md](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-addin-testing/references/testing_strategy.md)
* Contendrá las explicaciones teóricas del problema headless del Revit API (Sección 1), la validación de build (Sección 2) y las reglas de comportamiento del agente al crear pruebas (Sección 8).

#### [NEW] [test_project_setup.md](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-addin-testing/references/test_project_setup.md)
* Contendrá las instrucciones de configuración del proyecto de pruebas, jerarquía de directorios (Sección 4) y comandos de ejecución de consola (Sección 7).

#### [NEW] [TestProjectTemplate.csproj](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-addin-testing/assets/TestProjectTemplate.csproj)
* Archivo XML limpio con la plantilla base de `.csproj` de xUnit para .NET 4.8 y .NET 8 (Sección 4).

#### [NEW] [TestableArchitectureExample.cs](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-addin-testing/assets/TestableArchitectureExample.cs)
* Código de ejemplo comparativo (malo vs testable con inyección de interfaz) de inyección del Revit API (Sección 3).

#### [NEW] [WallAnalysisServiceTests.cs](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-addin-testing/assets/WallAnalysisServiceTests.cs)
* Código C# de ejemplo completo de pruebas de servicios con xUnit y FluentAssertions (Sección 5).

#### [NEW] [HelperTests.cs](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-addin-testing/assets/HelperTests.cs)
* Código C# de ejemplo para pruebas de clases de utilidades independientes (Sección 6).

#### [MODIFY] [SKILL.md](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-addin-testing/SKILL.md)
* Se reescribirá como un índice simplificado de menos de 45 líneas, referenciando las nuevas guías y assets con rutas relativas correctas.

---

### Component: `revit-addin-doc-manager`

Se modularizarán las fases de extracción de datos, procedimientos por escenarios y la estructura requerida del `User_Guide.md`.

#### [NEW] [doc_extraction_and_scenarios.md](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-addin-doc-manager/references/doc_extraction_and_scenarios.md)
* Contendrá las instrucciones de inspección automática (Sección 1) y los procedimientos lógicos silenciosos para escenarios A y B de generación/actualización (Sección 2).

#### [NEW] [user_guide_template.md](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-addin-doc-manager/assets/user_guide_template.md)
* Estructura técnica estandarizada y campos requeridos para el archivo `User_Guide.md` (Sección 4 y 5).

#### [MODIFY] [SKILL.md](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-addin-doc-manager/SKILL.md)
* Reducido a un índice estructurado de menos de 35 líneas, apuntando a los archivos de referencia.

---

### Component: `revit-addin-icon-manager`

Se aislará el código utilitario C# y la explicación del esquema WPF `pack://application`.

#### [NEW] [icon_loading_strategy.md](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-addin-icon-manager/references/icon_loading_strategy.md)
* Detalles técnicos sobre soporte DPI, temas oscuros en Revit 2024+, preparación de tamaños (16/32px) e integración en `.csproj` (Secciones 1, 2.A, y 2.B).

#### [NEW] [GetImageSource.cs](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-addin-icon-manager/assets/GetImageSource.cs)
* Fragmento de código C# optimizado y seguro para inyección de carga de recursos WPF.

#### [MODIFY] [SKILL.md](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-addin-icon-manager/SKILL.md)
* Simplificado como un índice semántico de menos de 30 líneas.

---

### Component: `revit-addin-installer-manager`

Se finalizará la modularización extrayendo las reglas de validación ICE y plantillas de instalación.

#### [NEW] [wxs_golden_rules.md](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-addin-installer-manager/references/wxs_golden_rules.md)
* Reglas de oro anti-errores (ICE38, ICE64, IDs únicos, GUIDs estáticos) del instalador en entornos AppData.

#### [NEW] [ProductTemplate.wxs](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-addin-installer-manager/assets/ProductTemplate.wxs)
* Plantilla XML de WiX Toolset para estructura de directorios y componentes multi-versión (Sección 2).

#### [NEW] [LicenseTemplate.rtf](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-addin-installer-manager/assets/LicenseTemplate.rtf)
* Plantilla básica en formato RTF para licencias EULA.

#### [MODIFY] [SKILL.md](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-addin-installer-manager/SKILL.md)
* Convertido en un índice ligero que enlaza tanto a `wix_toolset_architecture.md` (existente) como a las nuevas adiciones.

---

## Verification Plan

### Automated Tests
- Ejecutar la suite de compilación de skills usando el validador del repositorio para confirmar que la frontmatter y el formato siguen siendo 100% correctos:
  ```powershell
  pwsh agentic-workflows/dotnet-msbuild/build.ps1
  ```
- Verificar que no haya enlaces de archivos rotos y que el script compile todos los lockfiles adecuadamente.

### Manual Verification
- Comprobar visualmente que los archivos `SKILL.md` sean extremadamente cortos, legibles y estén enlazados a través de rutas relativas válidas que se puedan seguir en VS Code u otros entornos.
