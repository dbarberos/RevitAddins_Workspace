---
name: C# Component Blueprints
description: Guías específicas para los componentes y clases C# de los add-ins. Úsalo para entender la arquitectura interna y lógica de negocio de cada módulo.
---

# 🏗️ Índice de Blueprints de Componentes

Este directorio contiene la "memoria técnica" de los componentes C# más complejos. El objetivo es que cualquier agente o desarrollador pueda entender la lógica interna sin tener que analizar miles de líneas de código desde cero.

## 📂 Directorio de Guías

- [SelectionFilterViewModel_Blueprint](SelectionFilterViewModel_Blueprint.md): Lógica de árbol jerárquico, filtrado offline y sincronización en vivo del explorador.
- [1. Arquitectura Base y Patrones](1Arquitectura%20Base%20y%20Patrones%20Esenciales%20en%20Revit%20API.md): Cimientos del add-in, interfaces IExternalApplication/IExternalCommand, variables globales y genéricos.
- [2. Diseño de Interfaces (UI)](2Diseño%20Eficiente%20de%20Interfaces%20de%20Usuario%20para%20Revit%20API.md): Creación profesional del Ribbon, métodos de extensión para UI, gestión de iconos embebidos y organización de menús (PullDowns/Stacks).
- [3. Filtros y Selección](3Dominio%20de%20Filtros%20y%20Selección%20en%20Revit%20API.md): Uso avanzado de FilteredElementCollector, LINQ para Revit, recolección de Worksets y filtros de selección interactivos (ISelectionFilter).
- [4. Transacciones y Eventos](4Dominio%20de%20Transacciones,%20Colaboración%20y%20Eventos%20en%20Revit%20API.md): Gestión segura de la base de datos, editabilidad en modelos colaborativos (Worksharing) y suscripción a eventos nativos de Revit.
- [5. Formularios Avanzados (WinForms)](5Diseño%20de%20Interfaces%20Avanzadas%20con%20WinForms%20y%20Revit%20API.md): Patrón FormResult, layouts responsivos, ListViews con filtrado dinámico y barras de progreso asíncronas (DoEvents).
- [6. Escalabilidad y Rendimiento](6Escalabilidad,%20Interoperabilidad%20y%20Rendimiento%20de%20Add-ins.md): Soporte multiversión (#if), disponibilidad dinámica de comandos, interoperabilidad con Excel (ClosedXML) y diccionarios para alto rendimiento.
- [RevitSelectionService_Blueprint](RevitSelectionService_Blueprint.md): Gestión de colectores, pre-fetch de fases y thread-safety (Pendiente de redactar).

## 💡 Cómo usar estas guías
1. Cuando se te pida modificar una clase existente, busca primero si existe su Blueprint aquí.
2. Si creas una nueva lógica compleja, **es obligatorio** generar su correspondiente Blueprint en este directorio para futuras referencias.
3. Los Blueprints deben centrarse en el "POR QUÉ" y en las "REGLAS DE NEGOCIO", no solo en el "CÓMO".
