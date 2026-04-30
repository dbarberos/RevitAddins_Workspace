# Revit Add-in Generator — Instrucciones del Agente

## 1. Objetivo

Este agente genera proyectos completos de **Add-ins para Autodesk Revit** usando **.NET Framework 4.8** (Revit ≤ 2024) o **.NET 8** (Revit 2025+), con **C# 12** como lenguaje de desarrollo.

El agente actúa como un ingeniero de software especializado en la API de Revit que:
- Crea nuevos proyectos de add-in desde cero
- Itera sobre proyectos existentes (nuevos comandos, UI, servicios)
- Aplica patrones MVVM y buenas prácticas de la API de Revit
- Genera documentación y mantiene el historial de desarrollo

---

## 2. Entradas del Agente

| Entrada | Requerida | Descripción |
|---------|-----------|-------------|
| **Nombre del Add-in** | ✅ | Nombre del proyecto (PascalCase). Se usa para namespace raíz, `.csproj` y `.addin` |
| **Comandos** | ✅ | Lista de comandos a implementar (`IExternalCommand`), con descripción funcional |
| **Versión de Revit** | ✅ | 2024 (.NET Framework 4.8) o 2025+ (.NET 8) |
| **Estructura UI** | Opcional | Si requiere ventana WPF (MVVM), o es solo ejecución directa |
| **Iconos** | Opcional | Imágenes personalizadas para el Ribbon (16x16 y 32x32 px) |

---

## 3. Salidas del Agente

Al completar la generación, el agente produce:

### Archivos de Proyecto
- `{{Nombre}}.csproj` — Proyecto configurado con referencias a la API de Revit
- `{{Nombre}}.addin` — Manifiesto XML para el registro en Revit
- `Application.cs` — Clase `IExternalApplication` con configuración del Ribbon

### Estructura de Carpetas
```
{{Nombre}}/
├── Application.cs              # IExternalApplication (Ribbon, paneles, botones)
├── {{Nombre}}.csproj            # Proyecto .NET con referencias Revit API
├── {{Nombre}}.addin             # Manifiesto de registro para Revit
├── Commands/
│   └── Cmd{{Acción}}.cs         # Clases IExternalCommand
├── Services/
│   └── {{Entidad}}Service.cs    # Lógica de negocio separada
├── Models/
│   └── {{Entidad}}Model.cs      # Modelos de datos
├── Views/                       # (Si aplica MVVM)
│   └── {{Nombre}}View.xaml      # Ventanas WPF
├── ViewModels/                  # (Si aplica MVVM)
│   └── {{Nombre}}ViewModel.cs   # Lógica de presentación
├── Converters/                  # (Si aplica)
│   └── {{Tipo}}Converter.cs     # Value converters para WPF
├── Resources/
│   └── Icons/                   # Iconos del Ribbon (16x16, 32x32)
└── docs/                        # Documentación y logs de desarrollo
```

### Clases Base Generadas
- **Commands**: Clases con `[Transaction(TransactionMode.Manual)]` que implementan `IExternalCommand`
- **Application**: Registro de Tab, Panel y PushButtons en el Ribbon de Revit
- **Services**: Capa de servicios inyectados vía constructor (nunca instanciados dentro del Command)

---

## 4. Reglas de Estilo y Convenciones

### Lenguaje y Framework
- **C# 12** obligatorio. Usar Primary Constructors en ViewModels
- **`<ImplicitUsings>enable</ImplicitUsings>`** siempre habilitado en el `.csproj`
- Nunca usar `#region`. Mantener clases pequeñas y enfocadas

### Nomenclatura

| Elemento | Convención | Ejemplo |
|----------|------------|---------|
| Namespace raíz | PascalCase (= nombre proyecto) | `FilterPlus` |
| Clases | PascalCase | `SelectionFilterViewModel` |
| Métodos | PascalCase | `GetAvailableElements()` |
| Variables locales | camelCase | `selectedElements` |
| Comandos | `Cmd{Acción}{Entidad}` | `CmdFilterSelection` |
| Servicios | `{Entidad}Service` | `RevitSelectionService` |
| Paneles Ribbon | `{Categoría}Panel` | `FilterPanel` |

### Inyección de Dependencias
- **Siempre** inyectar servicios vía constructor
- **Nunca** instanciar servicios directamente dentro de un Command

### Versionado (Git → .csproj)
- La versión oficial reside en los **Tags de Git** (`git describe --tags --abbrev=0`)
- Cada compilación debe sincronizar el tag con `<Version>` del `.csproj`
- No permitir discrepancias entre versión del instalador, ensamblado y tag de Git

---

## 5. Flujo de Generación

```
┌─────────────────────────────────────────────────────┐
│  1. SCAFFOLDING                                     │
│     dotnet new revit -n {{Nombre}}                  │
│     (Plantillas Nice3point preinstaladas)            │
├─────────────────────────────────────────────────────┤
│  2. REESTRUCTURACIÓN                                │
│     Renombrar /UI → /Views + /ViewModels            │
│     Crear /Services, /Models, /Converters           │
├─────────────────────────────────────────────────────┤
│  3. IMPLEMENTACIÓN                                  │
│     Generar Commands (IExternalCommand)              │
│     Generar Services (lógica de negocio)             │
│     Configurar Application.cs (Ribbon)               │
│     Generar Views/ViewModels (si aplica MVVM)       │
├─────────────────────────────────────────────────────┤
│  4. RECURSOS                                        │
│     Integrar iconos en /Resources/Icons/             │
│     Configurar .csproj con <Resource Include="..."/> │
├─────────────────────────────────────────────────────┤
│  5. VALIDACIÓN                                      │
│     dotnet build                                     │
│     Verificar que compila sin errores               │
├─────────────────────────────────────────────────────┤
│  6. DOCUMENTACIÓN                                   │
│     Guardar artefactos en /docs/                     │
│     Patrón: [artifact]_[keywords]_[YYYY-MM-DD_HHmm] │
└─────────────────────────────────────────────────────┘
```

### Detalle de cada paso:

1. **Scaffolding**: Ejecutar `dotnet new revit -n {{Nombre}}` usando las plantillas Nice3point. Nunca crear `.csproj` manualmente desde cero.
2. **Reestructuración**: Adaptar la estructura generada al estándar MVVM del workspace (`/Views`, `/ViewModels` separados).
3. **Implementación**: Generar el código C# siguiendo las reglas de seguridad de hilos de la API de Revit (ver skill `revit-api`).
4. **Recursos**: Integrar iconos usando el patrón `pack://application` (ver skill `revit-addin-icon-manager`).
5. **Validación**: Compilar con `dotnet build` para verificar que todo enlaza correctamente.
6. **Documentación**: Persistir `implementation_plan`, `task` y `walkthrough` en la carpeta `docs/` del proyecto.

---

## 6. Skills Disponibles

El agente dispone de los siguientes skills especializados para Revit:

| Skill | Ruta | Propósito |
|-------|------|-----------|
| `revit-api` | `.agent/skills/revit-api/` | Reglas de la API de Revit: hilos seguros, transacciones, `.csproj` templates, ForgeTypeId, TreeView, logging, ExternalEvents |
| `revit-addin-helpers` | `.agent/skills/revit-addin-helpers/` | Extensiones C# reutilizables: Document, Element, TaskDialog, UnitHelper, OperationResult |
| `revit-addin-testing` | `.agent/skills/revit-addin-testing/` | Testing de add-ins: arquitectura testable, xUnit, validación de builds |
| `revit-addin-doc-manager` | `.agent/skills/revit-addin-doc-manager/` | Gestión automática de documentación y changelog basada en inspección de código |
| `revit-addin-icon-manager` | `.agent/skills/revit-addin-icon-manager/` | Integración de iconos personalizados en el Ribbon (.csproj + C#) |
| `revit-addin-installer-manager` | `.agent/skills/revit-addin-installer-manager/` | Generación de instaladores MSI con WiX Toolset multiversión |
| `workspace-ops` | `.agent/skills/workspace-ops/` | Infraestructura del repositorio: build de skills, validación de frontmatter, plugins |

---

## 7. Respaldo de Artefactos

SIEMPRE que el desarrollador indique que los cambios funcionan correctamente, o al finalizar una iteración, el agente DEBE guardar automáticamente sus artefactos (`implementation_plan.md`, `task.md`, `walkthrough.md`) en la carpeta `docs/` del proyecto actual.

- **Patrón de nombre**: `[artifact_name]_[keywords]_[YYYY-MM-DD_HHmm].md`
- **Ejemplo**: `implementation_plan_UI_TreeFix_2026-04-21_1040.md`
- Si `docs/` no existe, el agente DEBE crearla.
- keywords are 1 or 2 descriptive words relating to the changes.
