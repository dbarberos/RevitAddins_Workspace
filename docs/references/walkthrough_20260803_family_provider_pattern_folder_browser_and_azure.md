# Walkthrough — Integración Completa de Fuentes de Familias (Local, Azure, Modelos Abiertos y Vínculos) en TransferPlus

**Fecha:** 2026-08-03  
**Add-in:** TransferPlus  
**Componentes Modificados:**
- `DirectorySourceViewModel.cs`
- `FamilyProviderFactory.cs`
- `LocalFolderFamilyProvider.cs`
- `AzureStorageFamilyProvider.cs`
- `OpenDocumentFamilyProvider.cs`
- `LinkedDocumentFamilyProvider.cs`
- `TransferPlusViewModel.cs`
- `Archivo.cs`

---

## 🎯 Objetivos Cumplidos

1. **Patrón Provider (`IFamilyProvider`)**:
   - Abstracción unificada para listar y cargar familias desde disco local, Azure Storage, modelos abiertos y vinculados.
   - Transferencia 100% en memoria para modelos abiertos y vínculos mediante `sourceDoc.EditFamily(family)` -> `familyDoc.LoadFamily(targetDoc)`.

2. **Explorador Directo de Carpetas**:
   - Invocación de `System.Windows.Forms.FolderBrowserDialog` vía reflexión dinámica en `DirectorySourceViewModel.cs`.
   - Permite seleccionar directorios locales directamente sin forzar la elección de un archivo `.rfa` dentro.

3. **Corrección de Excepción de Caracteres Inválidos (`ArgumentException`)**:
   - Limpieza y sanitización de prefijos `"Active Model: "` y `"Link: "` en `FamilyProviderFactory.cs`.
   - Validación previa de caracteres inválidos (`Path.GetInvalidPathChars()`) antes de abrir rutas en disco.

4. **Integración en Desplegable `"Apply transfer from:"`**:
   - Carga dinámica de fuentes de familias activas en `SourceDocuments` dentro de `TransferPlusViewModel.cs`.
   - Actualización en tiempo real al guardar nuevas fuentes en la interfaz.

5. **Trazabilidad y Trace Logs Detallados**:
   - Registro en vivo con `TelemetryLogger.LogInfo` de cada paso de conexión, escaneo, selección y carga de familias.

---

## 🛠️ Verificación de Compilación y Despliegue

- **MSbuild Command**: `dotnet build "TransferPlus\TransferPlus.csproj" -c "Debug R24"`
- **Resultado**: **0 ERRORS, 0 WARNINGS FATALES** (Build & Auto-Deploy Clean).
- **Ruta de Despliegue**: `%AppData%\Autodesk\Revit\Addins\2024\TransferPlus\TransferPlus.dll`.
