# Guía de Uso - FilterPlus

**Versión Actual:** 1.1.0
**Desarrollador:** DBDev / dbase_Architecture

---

## 1. Descripción General
**FilterPlus** es un add-in avanzado para Autodesk Revit diseñado para agilizar la selección y filtrado de elementos en proyectos complejos. Ofrece una **navegación jerárquica total** (All > Category > Family > Type > Element ID) y un sistema de organización dinámica que permite reestructurar el árbol de selección según las necesidades del usuario.

## 2. Instrucciones de Instalación
El add-in se distribuye mediante un instalador profesional (MSI).

1.  Cierre todas las sesiones de Revit abiertas.
2.  Ejecute el archivo `FilterPlus.msi`.
3.  Siga los pasos del asistente de instalación.
4.  Al abrir Revit, si aparece un aviso de seguridad, seleccione **"Always Load"** (Cargar siempre).

> [!NOTE]
> La instalación se realiza en el perfil de usuario (`%AppData%\Autodesk\Revit\Addins`), por lo que no requiere privilegios de administrador para la mayoría de los usuarios.

## 3. Guía de Comandos y Funcionalidades

### 3.1. Explorador Jerárquico Avanzado
La interfaz principal permite una selección granular de elementos mediante un árbol de 5 niveles.
- **Memoria Semántica**: El explorador recuerda tu nivel de despliegue visual incluso al cambiar los criterios de organización.
- **Multiselección**: Checkboxes inteligentes que gestionan estados indeterminados en carpetas padres.

### 3.2. Organización Dinámica (Switches)
Puedes reorganizar la jerarquía del proyecto instantáneamente usando los interruptores laterales:
- **Sort by Phase**: Agrupa elementos por fase de creación.
- **Sort by Level**: Organiza la jerarquía según el nivel asociado.
- **Sort by Workset**: Útil para proyectos colaborativos con subproyectos.

### 3.3. Motor de Búsqueda Inteligente
- **Regex Support**: Búsqueda avanzada mediante expresiones regulares.
- **Lógica OR**: Permite acumular selecciones de múltiples búsquedas consecutivas.
- **Filtro por Nombre**: Opción para limitar la búsqueda solo al nombre del tipo/familia para mayor velocidad.

### 3.4. Menú Contextual (Revit 2025+)
Integración nativa en el clic derecho para filtrar selecciones existentes de forma instantánea.

## 4. Requisitos del Sistema

| Requisito | Detalle |
| :--- | :--- |
| **Versiones de Revit** | 2023, 2024, 2025, 2026, 2027 |
| **Sistema Operativo** | Windows 10 / 11 (64-bit) |
| **Framework** | .NET Framework 4.8 / .NET 8.0 (según versión de Revit) |

> [!WARNING]
> Para Revit 2025 y superiores, el add-in requiere que el entorno tenga instalado el runtime de .NET 8.

## 5. Historial de Versiones (Changelog)

### [1.1.0] - 2026-05-08
#### Añadido
- **Jerarquía Total**: Implementación del TreeView de 5 niveles (Categoría > Familia > Tipo > Elemento).
- **Sorting Dinámico**: Nuevos modos de organización por Fase, Nivel y Subproyecto (Workset).
- **Motor de Búsqueda Avanzado**: Soporte para Regex, lógica OR y modo "Only by Name".
- **Semantic Depth Memory**: Lógica para preservar la profundidad de expansión del usuario durante reorganizaciones.
- **Optimización UI**: Rediseño minimalista con iconos vectoriales y ajuste automático de dimensiones para pantallas 1080p.

#### Corregido
- **Virtualización WPF**: Solucionado el bug de corrupción de estado en el TreeView mediante el cambio a `VirtualizationMode="Standard"`.
- **Thread Safety**: Mejorada la estabilidad de las llamadas a la API de Revit desde hilos secundarios en procesos de selección masiva.

### [1.0.0] - 2026-04-29
#### Añadido
- **Instalador MSI**: Soporte multiversión automatizado (2023-2027).
- **Hardening de Seguridad**: Protección contra ataques XXE y validación de rutas.
- **Logging de Errores**: Sistema centralizado de registro de errores (`LoggerService`).

---
*Para soporte técnico, contacte a: dbarberos@outlook.com
