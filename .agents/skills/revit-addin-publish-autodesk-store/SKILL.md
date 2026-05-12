# Skill: Autodesk App Store Publisher (Autoloader Format)

**Version:** 1.2
**Description:** Automatiza la creación del formato `.bundle` y el archivo `PackageContents.xml` requeridos para publicar Add-ins de Revit en la Autodesk App Store, cumpliendo con los estándares de rechazo de instaladores personalizados.

---

## 🟢 1. Fase de Inspección y Metadatos
Al activar este skill, el Agente debe extraer proactivamente:
1.  **Metadatos Técnicos**: `AppName`, `Version`, `AddInId`, y `VendorId` desde los archivos `.csproj` y `.addin`.
2.  **Rango de Versiones**: Identificar `SeriesMin` y `SeriesMax` analizando las referencias a la API de Revit.
3.  **Checklist de Cumplimiento**:
    - **App Description**: Debe tener un mínimo de **4000 caracteres**.
    - **Privacy Policy**: Debe cubrir: Recolección de datos, Terceros, Retención/Borrado y Revocación de consentimiento.
    - **Screenshots**: Mínimo 4 imágenes (o 3 + 1 video).
    - **Website**: URL del sitio o perfil de publicador de Autodesk.

---

## 🛠 2. Lógica de Empaquetado (.bundle)

### Paso A: Estructura Autoloader
El Agente creará la carpeta `FilterPlusPublishPackage/FilterPlus.bundle/` con la siguiente jerarquía:
```text
FilterPlus.bundle/
├── PackageContents.xml (Raíz del bundle)
└── Contents/
    ├── 2023/ (Subcarpetas por versión si las DLLs difieren)
    │   ├── FilterPlus.dll
    │   └── FilterPlus.addin
    ├── 2024/ ...
    └── Resources/
        ├── Icon16.png
        ├── Icon32.png
        └── Help.html (Documentación convertida de Markdown)
```

### Paso B: Generación de `PackageContents.xml`
El archivo debe seguir este esquema para evitar el rechazo por "Advance Steel":
```xml
<?xml version="1.0" encoding="utf-8" ?>
<ApplicationPackage AppVersion="[Version]" Author="[VendorId]" AutodeskProduct="Revit" Name="[AppName]" SchemaVersion="1.0">
    <CompanyDetails Email="[Email]" Name="[Vendor]" Url="[URL]"/>
    <Components>
        <RuntimeRequirements OS="Win64" Platform="Revit" SeriesMax="[Year]" SeriesMin="[Year]"/>
        <ComponentEntry AppName="[AppName]" ModuleName="./Contents/[Year]/[AppName].addin" Version="[Version]"/>
    </Components>
</ApplicationPackage>
```

### Paso C: Modificación del Manifiesto `.addin`
**Regla Crítica**: La etiqueta `<Assembly>` dentro del archivo `.addin` distribuido NO debe tener rutas absolutas ni carpetas. Debe apuntar directamente al archivo en la misma carpeta:
` <Assembly>FilterPlus.dll</Assembly>`

---

## 🛡 3. Reglas de Publicación (Anti-Rechazo)

### 1. Reemplazo del Instalador Custom
Autodesk prefiere el formato bundle porque su portal genera automáticamente el MSI final. 
- **Acción**: Desactivar la generación de MSI propio a menos que el app requiera cambios en el Registro de Windows o dependencias externas complejas.

### 2. Política de Privacidad Interna
El app debe incluir un link a la política de privacidad accesible desde la interfaz (ej. en el botón de Configuración o Ayuda).

### 3. Soporte Multiversión
Si se detectan versiones desde Revit 2025+, el Agente debe advertir sobre el requisito de **.NET 8.0 Runtime** en la descripción del app.

---

## 📋 4. Flujo de Trabajo Final
1.  **Generar**: Crear la carpeta de publicación con todos los archivos `.md` de cumplimiento.
2.  **Validar**: Verificar que la descripción supere los 4000 caracteres.
3.  **Documentar**: Convertir `Guia_Uso.md` a `Help.html` usando el motor de renderizado disponible.
4.  **Empaquetar**: Instruir al usuario para comprimir SOLO la carpeta `.bundle` en un `.zip`.