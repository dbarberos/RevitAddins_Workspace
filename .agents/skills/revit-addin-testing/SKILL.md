---
name: revit-addin-testing
description: Guide for testing Revit Add-ins — unit testing with API mocks, build validation, and testing strategies without a Revit instance. Use this when configuring CI/CD, setting up tests, or validating business logic independently of the Revit API.
---

# Revit Add-in Testing — Índice de Contenidos

Este skill proporciona directrices completas para el desarrollo y ejecución de pruebas en add-ins de Revit, optimizando la separación de lógica de negocio pura y la API.

## 📚 Referencias Técnicas (Knowledge Base)
Para obtener guías y metodologías de pruebas en profundidad, consulta los archivos en la carpeta `references/`:

*   `references/testing_strategy.md`: El problema fundamental de la API headless, niveles de pruebas, validación mínima de build y reglas de comportamiento del agente.
*   `references/test_project_setup.md`: Jerarquía física de carpetas del proyecto de pruebas y comandos de ejecución (`dotnet test`).

## 📦 Assets (Plantillas y Ejemplos de Código)
Los siguientes archivos se encuentran en la carpeta `assets/` y pueden inyectarse o utilizarse como guía en los proyectos:

*   `assets/TestProjectTemplate.csproj`: Archivo base `.csproj` con referencias a xUnit, Moq y FluentAssertions para .NET 4.8 y .NET 8.
*   `assets/TestableArchitectureExample.cs`: Ejemplo de código comparativo que demuestra cómo extraer código con inyección de dependencias para aislar la API de Revit.
*   `assets/WallAnalysisServiceTests.cs`: Clase de prueba xUnit de ejemplo que valida la lógica de negocio de servicios agrupadores.
*   `assets/HelperTests.cs`: Clase de prueba xUnit para helpers genéricos (como `OperationResult`).
