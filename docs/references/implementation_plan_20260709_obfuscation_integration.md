# Plan de Implementación: Creación del Skill de Ofuscación y DevOps Anti-Tampering (`revit-addin-obfuscation`)

Este plan detalla el proceso para estructurar el nuevo skill de ofuscación de Add-ins de Revit en `.agents/skills/revit-addin-obfuscation/`, integrar plantillas universales y actualizar las directivas de automatización del agente.

## 1. Explicación del Proceso de Ofuscación (Sin Duplicación de Código)
Para responder a tu inquietud sobre conservar el código original para futuras iteraciones:
* **No es necesario copiar el proyecto C#**: Obfuscar **no modifica el código fuente (`.cs`)** en absoluto.
* **Ofuscación a Nivel de Ensamblado (IL)**: El compilador de C# toma tus archivos `.cs` originales e intactos y genera el archivo `.dll` normal en la carpeta `bin/Release/`.
* **Post-Build Action**: Justo después de compilar, Obfuscar toma ese `.dll` recién compilado, lo analiza, encripta las cadenas de texto, ofusca los nombres de variables/clases privadas, y genera un nuevo `.dll` ofuscado.
* **Reemplazo Seguro**: El script `Obfuscar.targets` reemplaza automáticamente el `.dll` original en `bin/Release/` con la versión ofuscada.
* Tu código fuente en C# sigue estando 100% limpio y con sus nombres originales. Siempre podrás compilar en modo `Debug` para depurar sin ofuscación.

---

## 2. Cambios Propuestos

### A. Crear la Habilidad Global del Agente (`revit-addin-obfuscation`)

#### [NEW] [SKILL.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-obfuscation/SKILL.md)
* Archivo índice con ID `SKILL-RVT-OBF` que define las directivas sobre cómo ofuscar Add-ins de Revit de forma segura en CI/CD.

#### [NEW] [Assets del nuevo Skill]
Moveremos y adaptaremos las plantillas de `docs\revit-cdci-obfuscation` a `.agents/skills/revit-addin-obfuscation/assets/`:
1. [obfuscar.xml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-obfuscation/assets/obfuscar.xml): Enriquecido con exclusiones universales automáticas de Revit (Commands, App, WPF, WebView2).
2. [Obfuscar.targets](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-obfuscation/assets/Obfuscar.targets): Destino de MSBuild para automatizar la ofuscación en modo `Release`.
3. [build-and-pack.ps1](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-obfuscation/assets/build-and-pack.ps1): Script PowerShell maestro interactivo. **Preguntará al usuario al inicio si desea compilar en modo Producción (Release + Ofuscación) o en modo Desarrollo/Debug (Debug + Símbolos PDB sin ofuscar) para permitir la depuración de errores con stack traces completos.**

#### [NEW] [Referencias del nuevo Skill]
Crearemos la guía teórica basada en tus notas y el archivo txt:
* [44_AntiTampering_and_Obfuscation.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/.agents/skills/revit-addin-obfuscation/references/44_AntiTampering_and_Obfuscation.md): Documentación técnica sobre cómo funciona el pipeline, cómo seleccionar los perfiles interactivos (Production vs Debug), cómo usar `[Obfuscation]` en C# y cómo evitar que se rompa el Add-in en Revit.

---

### B. Registro e Instrucciones Globales del Agente

#### [MODIFY] [AGENTS.md](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/AGENTS.md)
* **Sección 6 (Skills)**: Registrar `revit-addin-obfuscation`.
* **Sección 6.1 (Planning Gate)**: Añadir regla estricta:
  * *CI/CD Obfuscation & Exclusions (`revit-addin-obfuscation`)*: Cada vez que se configure un pipeline de publicación o un `.csproj` en modo Release, se debe importar `Obfuscar.targets`, proveer un `obfuscar.xml` y asegurar que las clases de comandos/UI estén excluidas de la ofuscación mediante la directiva `[Obfuscation(Exclude = true, ApplyToMembers = true)]` en C#. Además, se debe soportar el selector interactivo (Producción vs Debug) en scripts de despliegue local para mantener la depuración de trazas de error (PDB).

---

### C. Configurar el Proyecto Local `FilterPlus`

#### [MODIFY] [FilterPlus.csproj](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/FilterPlus.csproj)
* Importar el archivo de targets al final del proyecto:
  ```xml
  <Import Project="$(SolutionDir)Obfuscar.targets" Condition="Exists('$(SolutionDir)Obfuscar.targets')" />
  ```

#### [NEW] [Archivos de Configuración en el Proyecto/Solución]
* Copiar `obfuscar.xml` y `Obfuscar.targets` a la raíz de la solución.
* Copiar `build-and-pack.ps1` a la carpeta de herramientas de compilación o raíz.

---

## 3. Plan de Verificación

1. **Linter de Habilidades**: Comprobar que los archivos `.md` cumplen con el formato estándar.
2. **Validación de la Plantilla XML**: Comprobar que las reglas de exclusión en `obfuscar.xml` abarcan correctamente los entrypoints.
3. **Limpieza**: Eliminar la carpeta `docs\revit-cdci-obfuscation` cuando finalice el traslado.
