# Guía de Uso - FilterPlus

**Versión Actual:** 1.0.0
**Desarrollador:** DBDev / dbase_Architecture

---

## 1. Descripción General
**FilterPlus** es un add-in avanzado para Autodesk Revit diseñado para agilizar la selección y filtrado de elementos en proyectos complejos. Permite una navegación jerárquica (Categoría > Familia > Tipo > Elemento) y un filtrado dinámico que supera las limitaciones del filtro nativo de Revit.

## 2. Instrucciones de Instalación
El add-in se distribuye mediante un instalador profesional (MSI).

1.  Cierre todas las sesiones de Revit abiertas.
2.  Ejecute el archivo `FilterPlus.msi`.
3.  Siga los pasos del asistente de instalación.
4.  Al abrir Revit, si aparece un aviso de seguridad, seleccione **"Always Load"** (Cargar siempre).

> [!NOTE]
> La instalación se realiza en el perfil de usuario (`%AppData%\Autodesk\Revit\Addins`), por lo que no requiere privilegios de administrador para la mayoría de los usuarios.

## 3. Guía de Comandos y Funcionalidades

### 3.1. Panel en la Cinta de Opciones (Ribbon)
El add-in crea una pestaña llamada **"DBDev"** (configurable) con el panel **FilterPlus**.

| Comando | Función | Clase Técnica |
| :--- | :--- | :--- |
| **FilterPlus** | Abre la interfaz principal de filtrado y selección jerárquica. | `FilterPlus.Commands.StartupCommand` |

### 3.2. Menú Contextual (Revit 2025+)
En versiones de Revit 2025 y superiores, FilterPlus se integra en el menú contextual (clic derecho) cuando hay elementos seleccionados, permitiendo filtrar la selección actual de forma instantánea.

## 4. Requisitos del Sistema

| Requisito | Detalle |
| :--- | :--- |
| **Versiones de Revit** | 2023, 2024, 2025, 2026, 2027 |
| **Sistema Operativo** | Windows 10 / 11 (64-bit) |
| **Framework** | .NET Framework 4.8 / .NET 8.0 (según versión de Revit) |

> [!WARNING]
> Para Revit 2025 y superiores, el add-in requiere que el entorno tenga instalado el runtime de .NET 8.

## 5. Historial de Versiones (Changelog)

### [1.0.0] - 2026-04-29
#### Añadido
- **Instalador MSI**: Soporte multiversión automatizado (2023-2027).
- **Hardening de Seguridad**: Protección contra ataques XXE en archivos XML y validación de rutas contra Path Traversal.
- **Logging de Errores**: Sistema centralizado de registro de errores (`LoggerService`) para facilitar el soporte técnico.
- **Menú Contextual**: Integración contextual para Revit 2025+.

#### Corregido
- Estabilidad de la carga de configuraciones de usuario.
- Gestión de excepciones en el punto de entrada del add-in.

---
*Para soporte técnico, contacte a: dbarberos@outlook.com
