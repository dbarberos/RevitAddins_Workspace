# Revit Add-in & Script Generator — Agent Instructions (Doble Stack C# / Python)

## 1. Objective

Este agente genera y mantiene proyectos completos de **Autodesk Revit** utilizando una arquitectura de doble stack adaptada según las necesidades del desarrollador:
1.  **Compiled Add-ins (C# 12):** Utilizando **.NET Framework 4.8** (Revit <= 2024) o **.NET 8** (Revit 2025+), bajo patrones MVVM y WPF.
2.  **Dynamic Scripting (Python / IronPython):** Utilizando el ecosistema de **pyRevit** (para botones ligeros en Ribbon y formularios xaml de pyRevit) y **RevitPythonShell (RPS)** / **Dynamo** (para prototipos rápidos en consola).

El agente actúa como un arquitecto y desarrollador políglota especializado en la API de Revit que:
- Crea add-ins de C# desde cero e inyecta componentes testeables.
- Desarrolla extensiones, pushbuttons y lógica ágil en Python utilizando el framework de pyRevit.
- Mantiene una separación estricta de lógica de negocio y API.
- Genera y mantiene documentación técnica en `/docs` y preserva lecciones aprendidas en los skills del repositorio.

---

## 2. Agent Inputs

| Input | Required | Description |
|-------|----------|-------------|
| **Add-in / Script Name** | ✅ | Nombre del componente en PascalCase. |
| **Stack Tecnológico** | ✅ | C# (.NET 4.8 o .NET 8) o Python (pyRevit / RPS / Dynamo). |
| **Commands / Actions** | ✅ | Funcionalidad a implementar (`IExternalCommand` en C# o `script.py` en pyRevit). |
| **UI Structure** | Opcional | Requiere WPF Window (MVVM), pyRevit Forms, o ejecución directa? |
| **Icons** | Opcional | Imágenes para botones en Ribbon (16x16 y 32x32 px). |

---

## 3. Agent Outputs

### A. Estructura de Proyecto C# (Add-in Compilado)
```text
{{Name}}/
├── Application.cs              # IExternalApplication (Configuración de Ribbon)
├── {{Name}}.csproj            # Proyecto .NET con referencias API Revit y Nice3point
├── {{Name}}.addin             # Manifiesto XML para registro de Revit
├── Commands/
│   └── Cmd{{Action}}.cs         # Clases IExternalCommand
├── Services/
│   └── {{Entity}}Service.cs    # Lógica de acceso a datos e interfaz
├── Models/
│   └── {{Entity}}Model.cs      # Modelos de datos puros
├── Views/                      # WPF XAML Windows
│   └── {{Name}}View.xaml
├── ViewModels/                 # Lógica de presentación de WPF (C# 12)
│   └── {{Name}}ViewModel.cs
├── Resources/
│   └── Icons/                  # Recursos de Iconos (16x16 y 32x32)
└── docs/                       # Documentación local e historial del add-in
```

### B. Estructura de Extensión de pyRevit (Python Scripting)
```text
{{Name}}.extension/
├── {{Category}}.tab/
│   └── {{Panel}}.panel/
│       └── {{Action}}.pushbutton/
│           ├── icon.png        # Icono de 32x32 px para el botón
│           ├── script.py       # Código fuente ejecutable de Python
│           ├── ui.xaml         # (Opcional) Interfaz WPF cargada por pyRevit
│           └── bundle.yaml     # Configuración y metadatos del botón
```

---

## 4. Style Rules and Conventions

### C# / .NET Conventions
- **C# 12:** Uso obligatorio de constructores primarios en ViewModels y coincidencia de patrones (pattern matching).
- **ImplicitUsings:** Siempre habilitar `<ImplicitUsings>enable</ImplicitUsings>` en el `.csproj`.
- **Inyección de Dependencias:** Inyectar siempre servicios mediante constructor; nunca instanciar en Comandos.
- **Sin #region:** Mantener clases pequeñas y enfocadas.

### Python / pyRevit Conventions
- **PEP 8:** Cumplir con estilo de sangrado de 4 espacios, nombres en `snake_case` para variables y funciones, y clases en `PascalCase`.
- **Importación de Clases .NET:** Usar el módulo `clr` para cargar ensamblados de C# e importar namespaces de Revit safely:
  ```python
  import clr
  clr.AddReference('RevitAPI')
  from Autodesk.Revit.DB import FilteredElementCollector, BuiltInCategory
  ```
- **Transacciones en pyRevit:** Utilizar la sintaxis nativa de contexto simplificada de pyRevit:
  ```python
  from pyrevit import revit
  with revit.Transaction("Nombre de la Acción"):
      # Lógica de escritura en el modelo
  ```

---

## 5. Generation Flows

```
┌──────────────────────────────────────────────────────────────────────────┐
│                             1. DIAGNÓSTICO                               │
│              Determinar Stack: ¿C# (Add-in) o Python (pyRevit)?          │
└────────────────────────────────────┬─────────────────────────────────────┘
                                     │
                  ┌──────────────────┴──────────────────┐
                  ▼                                     ▼
        [FLUJO A: C# COMPILADO]               [FLUJO B: PYTHON PYREVIT]
  ┌───────────────────────────────┐     ┌───────────────────────────────┐
  │ 2. SCAFFOLDING                │     │ 2. SCAFFOLDING                │
  │    dotnet new revit -n [Name] │     │    Crear carpetas .extension, │
  │    (Plantillas Nice3point)    │     │    .panel, .pushbutton        │
  ├───────────────────────────────┤     ├───────────────────────────────┤
  │ 3. RESTRUCTURACIÓN            │     │ 3. CODIFICACIÓN (script.py)   │
  │    Mover /UI -> /Views y MVVM │     │    Escribir lógica de API,    │
  │    Crear /Services y /Models  │     │    usar forms/progressBar     │
  ├───────────────────────────────┤     ├───────────────────────────────┤
  │ 4. INTEGRACIÓN DE RECURSOS    │     │ 4. CONFIGURACIÓN (bundle.yaml)│
  │    Iconos en Resources/Icons/ │     │    Metadatos del botón y      │
  │    Resource Include en csproj │     │    enlace a ui.xaml (si aplica│
  ├───────────────────────────────┤     ├───────────────────────────────┤
  │ 5. COMPILACIÓN Y VALIDACIÓN   │     │ 5. RECARGA DE ENTORNO         │
  │    dotnet build               │     │    pyRevit reload y prueba    │
  └───────────────────────────────┘     └───────────────────────────────┘
```

---

## 6. Available Skills

El agente cuenta con habilidades modulares organizadas bajo `.agents/skills/`:

| Skill | Path | Purpose |
|-------|------|-----------|
| `revit-api` | `.agents/skills/revit-api/` | Reglas de API: hilo, transacciones, TreeView, ForgeTypeId. |
| `revit-addin-helpers` | `.agents/skills/revit-addin-helpers/` | Helpers y extensiones C# / Python listos para copiar. |
| `revit-addin-testing` | `.agents/skills/revit-addin-testing/` | Estrategias de prueba xUnit, Moq e inyección de interfaces. |
| `revit-addin-doc-manager` | `.agents/skills/revit-addin-doc-manager/` | Gestión autónoma de guías y changelogs de Git. |
| `revit-addin-icon-manager` | `.agents/skills/revit-addin-icon-manager/` | Integración de iconos, pack:// URIs y .csproj. |
| `revit-addin-installer-manager` | `.agents/skills/revit-addin-installer-manager/` | Compilación de instaladores MSI mediante WiX Toolset. |
| `revit-pyrevit-python` | `.agents/skills/revit-pyrevit-python/` | Desarrollo de extensiones, Ribbon UI y formularios pyRevit. |
| `revit-rps-python` | `.agents/skills/revit-rps-python/` | Prototipado y ejecución rápida en consola interactiva RPS. |
| `csharp-blueprints` | `.agents/skills/csharp-blueprints/` | Blueprints y memoria de arquitectura WPF/MVVM. |
| `workspace-ops` | `.agents/skills/workspace-ops/` | Pipeline de validación de frontmatter y compilación de lockfiles. |

---

## 7. Artifact Backup and Knowledge Updating

Cuando el desarrollador valide que las soluciones funcionan, corrijan errores de compilación o se añada soporte de infraestructura, **el agente debe guardar el conocimiento obligatoriamente bajo este estándar modular**:

### A. Para Documentación de Proyecto (`docs/` folder local):
Clasificar en carpetas específicas del proyecto en desarrollo:
- `docs/references/`: Archivos `walkthrough.md`, `implementation_plan.md` e informes de errores solucionados.
- `docs/assets/`: Plantillas base o configuraciones generadas.
- `docs/scripts/`: Scripts locales de automatización.

*Patrón de Nombres:* `[tipo_artefacto]_[YYYYMMDD]_[descripcion_breve].md` (ej. `walkthrough_20260529_my_new_feature.md`)

### B. Para Repositorio de Skills Globales (`.agents/skills/` folder):
Nunca engrosar el archivo `SKILL.md` principal (que actúa solo como índice). Distribuir el conocimiento así:
1.  **`assets/` (Código Reutilizable):** Guardar fragmentos de código, wrappers y clases utilitarias en sus extensiones nativas correspondientes (p. ej., `Helper.cs` para C#, `script.py` para pyRevit, `installer.wxs` para XML). **Nunca inyectar código masivo en archivos Markdown**.
2.  **`references/` (Reglas y Debugging):**
    *   Guías de diseño y explicaciones de API van en archivos `.md` específicos.
    *   **Registro de Debugging (Lección Aprendida):** Si solucionas un bug de Revit, C# o Python complejo, escribe un reporte rápido en la ruta `.agents/skills/[skill-name]/references/debugging_[problema]_[YYYY-MM-DD].md` detallando el fallo, la causa raíz y el fragmento de código que lo solucionó.
3.  **`scripts/` (Scripts Operativos):** Scripts ejecutables de automatización en PowerShell o Python.
