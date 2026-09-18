# Architectural Blueprint: CAD Details Manager Provider Pattern & Multi-Cloud Integration

## 1. Overview & Purpose
This blueprint defines the architecture for managing, querying, and transferring multi-source CAD and drafting details (`.dwg`, `.dxf`, `.axm`, `.sat`, `.dgn`, `.obj`, `.3dm`, `.skp`, `.stl`) into Revit models.

---

## 2. Architecture & Design Pattern

```
                 ┌────────────────────────────────┐
                 │       CadProviderFactory       │
                 └───────────────┬────────────────┘
                                 │ resolves
        ┌────────────────────────┼────────────────────────┐
        ▼                        ▼                        ▼
┌──────────────────┐  ┌──────────────────┐  ┌──────────────────┐
│LocalFolderCadProv│  │AzureStorageCadPro│  │AwsS3StorageCadPro│
└──────────────────┘  └──────────────────┘  └──────────────────┘
        │                        │                        │
        └────────────────────────┼────────────────────────┘
                                 ▼
                 ┌────────────────────────────────┐
                 │          ICadProvider          │
                 ├────────────────────────────────┤
                 │ GetCadItemsAsync()             │
                 │ TransferCadItemAsync()         │
                 └────────────────────────────────┘
```

---

## 3. Business Rules & Guardrails

1. **Storage Isolation**:
   - Configured CAD sources are stored in `%APPDATA%\TransferPlus\cad_sources.json` and protected via DPAPI (`System.Security.Cryptography.ProtectedData`).
2. **Transfer Context (Import vs Link)**:
   - **`Link CAD`**: Enabled exclusively for local disk paths and Autodesk Docs (cloud Desktop Connector).
   - **`Import CAD`**: Forced for blob storages (Azure Blob, AWS S3) and internal models (open docs / links).
3. **Drafting View Creation**:
   - Each transferred CAD item is placed on a dedicated `ViewDrafting` (scale 1:1, centered at origin `XYZ.Zero`).
   - View name uniqueness is guaranteed via numbered suffix loop (`CAD - [FileName]`, `CAD - [FileName]_1`, etc.).
