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

## 3. Instrucciones de Instalación

1.  Cierra todas las sesiones activas de Autodesk Revit.
2.  Ejecuta el archivo instalador `.msi` o descomprime la carpeta `.bundle` en el directorio de complementos de Revit del usuario:
    `%APPDATA%\Autodesk\Revit\Addins\[Año]\`
3.  Inicia Revit. Si aparece el diálogo de seguridad, haz clic en **"Cargar siempre"** (Always Load).

---

## 4. Guía de Comandos (Ribbon UI)

| Comando / Botón | Clase Ejecutora (`FullClassName`) | Descripción Funcional y Uso |
|-----------------|-----------------------------------|----------------------------|
| **[Botón 1]** | `{{Namespace}}.Commands.Cmd[Action]` | [Explicación de qué hace al pulsarlo y qué parámetros o selecciones requiere.] |
| **[Botón 2]** | `{{Namespace}}.Commands.Cmd[Action2]` | [Explicación del segundo botón...] |

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
