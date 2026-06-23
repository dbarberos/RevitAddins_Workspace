# Guía de Usuario: Estructura del Documento `User_Guide.md`

Este asset define la estructura de secciones obligatoria y las reglas de formato para el manual técnico `User_Guide.md` del add-in.

---

## 1. Plantilla de Estructura de Documento

```markdown
# [Nombre del Add-in]

> **Versión Actual:** [X.X.X]  
> **ID del Add-in (GUID):** `[GUID extraído del archivo .addin]`  

---

## 1. Descripción General

[Proporcionar un resumen ejecutivo del propósito del add-in, el problema que resuelve y el flujo principal.]

---

## 2. Requisitos y Compatibilidad

> [!WARNING]
> Este add-in requiere **Autodesk Revit 2021** o superior en sistemas Windows de 64 bits.

* **Plataforma**: .NET Framework 4.8 / .NET 8 (según la versión).
* **Versiones de Revit Soportadas**: [Ej. 2023, 2024, 2025].

---

## 3. Installation & Uninstallation

The installer that ran when you downloaded this plug-in from the Autodesk App Store has already installed the plug-in. You may need to restart the Autodesk product to activate the plug-in.

To uninstall this plug-in, exit the Autodesk product if you are currently running it, simply rerun the installer by downloading it again from the Autodesk App Store, and select the 'Uninstall' button, or you can uninstall it from 'Control Panel\\Programs\\Programs and Features' (Windows 10/11), just as you would uninstall any other application from your system.

---

## 4. Commands and Features Guide

### 4.1. Ribbon Panel Integration
The add-in creates a custom tab containing the plugin panel.

| Command | Function | Technical Class |
|---------|----------|-----------------|
| **[App Start]** | Initializes the Ribbon panel and the application. | `{{Namespace}}.Application` |
| **[Command 1]** | [Functional description] | `{{Namespace}}.Commands.Cmd[Action]` |

---

## 5. Comprehensive Usage Guide

### Main Interface / Explorer
[Provide an overview of the main UI, the hierarchical tree, or core views.]

### Scope and Filters
[List the available scope toggles and grouping options using bullet points]
- **Filter A**: Description.
- **Filter B**: Description.

### Advanced Logic and Tools
[Explain search functionality, expansions, or specific features using clear bullet points and alerts]
* **Constraint 1**: Description.
* **Exclusion 1**: Description.
> [!TIP]
> **Pro-Tip**: Explain hidden gems or workflow optimizations.

---

## 5. Historial de Versiones (Changelog)

### [Versión X.X.X] - [AAAA-MM-DD]

#### Added (Añadido)
- [Funcionalidad nueva 1 o comando inyectado.]

#### Changed (Modificado)
- [Mejora o refactorización del código.]

#### Fixed (Corregido)
- [Corrección de error de hilo, interfaz o API.]

---

## 6. Soporte y Contacto

Para reportar fallos, sugerencias o solicitar soporte comercial, contacta a:
* **Desarrollador / Compañía**: [Tu Compañía / DBDev_dbarberos]
* **Soporte**: [Email de soporte o canal de incidencias de Git]
```

---

## 2. Reglas de Estilo y Formato

1.  **Tablas Técnicas**: Usa tablas Markdown para organizar datos como compatibilidades de versiones, IDs de clientes o listas de comandos.
2.  **Mensajes de Alerta**: Emplea bloques de aviso estilo GitHub (`> [!WARNING]`, `> [!NOTE]`) para destacar prerrequisitos de sistema, riesgos en el modelo de Revit o transacciones que no se pueden deshacer.
3.  **Enlaces de Comandos**: Las clases ejecutoras de Revit (`FullClassName`) siempre deben ir formateadas como código `` `Clase` ``.
