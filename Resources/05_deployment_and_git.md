### Archivo: `pyrevit-dev-mentor/references/05_deployment_and_git.md`

# Guía de Despliegue, Git y Librerías en pyRevit

Para implementar automatizaciones a nivel corporativo, no basta con tener los scripts funcionando en tu computadora local. Es vital utilizar control de versiones (Git) para el mantenimiento del código, estandarizar librerías para no repetir código, y usar las herramientas de administración de pyRevit para distribuir estas extensiones a los usuarios de la empresa.

## 1. Control de Versiones con Git
Mantener tu código en un repositorio (como GitHub o Bitbucket) te permite rastrear el historial de cambios, revertir errores y colaborar con otros desarrolladores.

*   **Configuración del Repositorio:** Crea un repositorio vacío en tu plataforma preferida (GitHub, Bitbucket) y copia la URL que termina en `.git` (ej. `https://github.com/usuario/mis_herramientas.git`).
*   **Archivos Base:** Clona el repositorio en tu máquina y mueve la carpeta de tu extensión (`.extension`) dentro de él. Asegúrate de incluir un archivo `README.md` formateado en Markdown para documentar el propósito de la herramienta.
*   **Ramas (Branches):** Para un entorno corporativo estable, debes mantener entornos separados: una rama `main` (para producción, lo que usan los usuarios finales) y ramas de desarrollo (`dev`) para probar código nuevo antes de publicarlo.

## 2. Librerías Compartidas (Reutilización de Código)
A medida que desarrollas múltiples herramientas, notarás que repites funciones (ej. coleccionar elementos, crear transacciones). pyRevit ofrece dos enfoques para crear librerías de Python y evitar esta repetición:

### A. La carpeta interna `lib`
Si las funciones compartidas solo aplican a una extensión específica, crea una carpeta llamada `lib` en la raíz de tu carpeta `.extension`. Todos los scripts dentro de esa misma extensión podrán importar estos módulos (ej. `import mi_modulo_empresa`).

### B. Extensiones de Librería (`.lib`)
Si desarrollas múltiples extensiones (ej. una para Arquitectura y otra para Estructuras) y deseas compartir código entre todas, debes crear una **Library Extension**.
*   Crea una carpeta que termine en `.lib` (ej. `CompanyCore.lib`).
*   pyRevit añadirá automáticamente la ruta de esta carpeta a los directorios del sistema de Python (`sys.path`), haciéndola accesible globalmente para cualquier otra extensión cargada en pyRevit.

## 3. Definición de la Extensión (`extensions.json`)
Para que el gestor de extensiones de pyRevit (Extension Manager) reconozca tus herramientas personalizadas y sepa dónde descargarlas/actualizarlas, debes crear un archivo llamado `extensions.json`. Este archivo debe colocarse en la carpeta padre que contiene tus extensiones.

**Estructura del archivo `extensions.json`:**
```json
{
  "extensions": [
    {
      "type": "extension",
      "name": "MisHerramientasCorp",
      "description": "Herramientas BIM para la empresa",
      "author": "Tu Nombre",
      "url": "https://github.com/usuario/mis_herramientas.git",
      "builtin": false,
      "enabled": true
    }
  ]
}
```
*   `type`: Define si es una "extension" (herramientas de UI) o una "library" (librería de código).
*   `url`: La dirección `.git` exacta de tu repositorio. Esto permite que el actualizador de pyRevit descargue los cambios directamente desde Git.

### Control de Acceso (`authorized_users`)
Si tienes extensiones sensibles (ej. herramientas de administración o en fase Beta) y no quieres que todos en la empresa las vean, puedes usar una clave oculta en tu archivo `extensions.json` llamada `authorized_users`.
*   Añade: `"authorized_users": ["usuario1", "usuario2"]`.
*   Solo los usuarios de Windows o de Revit cuyo nombre de usuario coincida con los listados podrán cargar y ver esa extensión en su cinta de opciones.

## 4. Despliegue Corporativo

Existen dos vías principales para desplegar tu extensión en las computadoras de los demás usuarios:

### A. Vía Directorio de Red (Rutas Personalizadas)
Puedes alojar tu carpeta `.extension` en un servidor de red compartido. En cada computadora, abre pyRevit, ve a `Settings` > `Custom User Extension Folders` y añade la ruta de esa carpeta de red. Tras recargar, pyRevit leerá las herramientas directamente desde el servidor.

### B. Vía Consola de Comandos (pyRevit CLI y Git)
Para despliegues más profesionales e independientes de una conexión local al servidor de la oficina, pyRevit CLI (Command Line Interface) permite instalar extensiones alojadas en repositorios Git mediante comandos de Windows. 

Este comando descargará la extensión directamente desde Git y configurará la máquina del usuario:
```cmd
pyrevit extend ui NombreDeTuExtension https://github.com/usuario/repo.git --dest="C:\RutaInstalacion" --branch=main
```
Una vez instalado, el usuario solo necesita usar el botón de **"Reload"** (Recargar) en pyRevit para traer la última versión de la rama `main` y actualizar sus herramientas.