# Debugging Report: Resolution of Invalid Path Character Exception in FamilyProviderFactory

**Fecha:** 2026-08-03  
**Add-in:** TransferPlus  
**Componente:** `FamilyProviderFactory.cs` / `LocalFolderFamilyProvider.cs`  

## 1. Síntoma
Logs reportaban el siguiente error al seleccionar un elemento en el desplegable de fuentes o abrir el Families Manager:
```text
[11:03:40.190] ERROR in OpenFamilyManager: Caracteres no válidos en la ruta de acceso.
[11:02:30.176] WARNING: Local folder path does not exist: 'Active Model: 2510000177_KRN_ARQ_G_00'
```

## 2. Causa Raíz
Los elementos del desplegable `"Apply transfer from:"` generaban nombres formateados con prefijo, tales como:
- `"Active Model: 2510000177_KRN_ARQ_G_00"`
- `"Link: 2510000177_KRN_STR_G_01.rvt : ..."`

Al evaluar `FamilyProviderFactory.CreateProvider(selectedSourceDisplay, ...)`, la comparación de igualdad estricta con `openDoc.Title` (que solo contiene `"2510000177_KRN_ARQ_G_00"`) no coincidía por el prefijo `"Active Model: "`.

Al no coincidir ni con fuentes guardadas ni con modelos abiertos, el método caía al proveedor fallback por defecto:
`return new LocalFolderFamilyProvider(selectedSourceDisplay, familyRevitService);`

`LocalFolderFamilyProvider` ejecutaba `Directory.GetFiles("Active Model: 2510000177_KRN_ARQ_G_00", ...)` en el sistema de archivos de Windows. Los dos puntos (`:`) de `"Active Model:"` son caracteres ilegales en rutas de Windows, lanzando una excepción `ArgumentException: Caracteres no válidos en la ruta de acceso`.

## 3. Solución
1. En `FamilyProviderFactory.cs`, se sanitiza `selectedSourceDisplay` eliminando los prefijos `"Active Model: "` y `"Link: "` antes de buscar títulos de modelos abiertos o vinculados.
2. Antes de instanciar `LocalFolderFamilyProvider`, se añade validación explícita mediante `cleanTitle.IndexOfAny(Path.GetInvalidPathChars()) < 0` y `Directory.Exists(cleanTitle)`.
3. En `LocalFolderFamilyProvider.cs`, se añade un guardas de protección previa para descartar rutas con caracteres inválidos antes de invocar `Directory.Exists()` o `Directory.GetFiles()`.

## 4. Verificación
- Compilación y auto-despliegue limpios con **0 Errores** (`Debug R24`).
