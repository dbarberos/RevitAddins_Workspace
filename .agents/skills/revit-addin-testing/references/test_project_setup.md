# Configuración y Ejecución del Proyecto de Pruebas

Este documento detalla la estructura física recomendada para un proyecto de pruebas unitarias de un add-in de Revit y los comandos para su ejecución automatizada.

---

## 1. Estructura de Carpetas Recomendada

Es fundamental separar físicamente el proyecto de código del add-in y su correspondiente suite de pruebas. Sigue este patrón organizativo en el repositorio:

```
{{Name}}/
├── {{Name}}.csproj          # Proyecto principal de la aplicación
└── {{Name}}.Tests/
    ├── {{Name}}.Tests.csproj # Proyecto de pruebas unitarias
    ├── Services/
    │   └── WallAnalysisServiceTests.cs # Pruebas unitarias de servicios
    └── Helpers/
        └── UnitHelperTests.cs          # Pruebas unitarias de extensiones/helpers
```

---

## 2. Comandos de Consola para Ejecución de Pruebas

El agente y las herramientas de automatización de CI/CD pueden ejecutar las pruebas mediante los siguientes comandos nativos de la CLI de .NET:

```powershell
# 1. Ejecutar todas las pruebas del proyecto
dotnet test {{Name}}.Tests/{{Name}}.Tests.csproj

# 2. Ejecutar pruebas con salida e información detallada
dotnet test --verbosity normal

# 3. Filtrar y ejecutar solo pruebas de una clase específica
dotnet test --filter "FullyQualifiedName~WallAnalysisServiceTests"
```
