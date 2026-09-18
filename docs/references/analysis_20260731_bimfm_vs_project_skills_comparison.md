# Comparativa Arquitectónica: `BimFM` vs. Principios y Skills del Proyecto

## 📅 Fecha de Registro: 2026-07-31
## 🧩 Componente: `references_examples\BimFM` vs. `TransferPlus` Architecture Rules

---

## 1. Resumen Ejecutivo

Al realizar una auditoría técnica cruzada entre el add-in **Bim.FamilyManager** (`references_examples\BimFM`) y las reglas y skills de nuestro proyecto (**`AGENTS.md`**, `revit-api`, `revit-addin-gui-design`, `security-engineer`, `revit-api-resilience`, `revit-async-operations`), se han identificado tanto las coincidencias como las áreas de mejora en las que los guardarraíles de nuestro proyecto optimizarían significativamente a `BimFM`.

---

## 2. Puntos en los que `BimFM` Cumple con Nuestros Skills

1. **Coordinación Asíncrona y Modeless (`revit-async-operations`)**:
   - `BimFM` registra y utiliza `RevitTask` (basado en el patrón `IExternalEventHandler` de Kennan Chen) para ejecutar las operaciones de modificación del modelo desde comandos y ViewModels de WPF sin bloquear el hilo principal de Revit.
2. **Registro de Dockable Panes en `OnStartup()` (`revit-api-ux`)**:
   - `RevitFamilyManagerApp` registra el panel acoplable exclusivamente en `OnStartup()`, evitando excepciones de registro tardío.
3. **Gestión de Transacciones en Modos de Lectura/Escritura (`revit-transactions`)**:
   - En la generación de miniaturas (`CreatePreviewImage`), hace un uso impecable de `TransactionGroup` iniciando y deshaciendo (`RollBack()`) los cambios para no alterar el modelo al capturar vistas.
   - Todas las escrituras y cargas de familias están encapsuladas dentro de bloques `using var transaction = new Transaction(...)`.
4. **Serialización Segura (`security-engineer`)**:
   - Utiliza `System.Text.Json` en lugar de `Newtonsoft.Json` con `TypeNameHandling.All`, eliminando vulnerabilidades de ejecución remota de código (RCE).

---

## 3. Aspectos donde los Principios de Nuestro Proyecto MEJORAN a `BimFM`

A pesar de su buena estructura, `BimFM` adolece de varios puntos débiles frente a las reglas y guardarraíles de nuestro ecosistema de skills:

### A. Rendimiento de UI y Virtualización WPF (`revit-addin-gui-design`)
* **Debilidad en `BimFM`**:
  - En `FamilyManagerView.xaml` y `FolderView.xaml`, las listas de familias (`ListView`) y el árbol de carpetas (`TreeView`) no tienen activada la virtualización de UI nativa de WPF.
  - Al conectar librerías corporativas masivas (más de 1,000 familias .rfa o carpetas de almacenamiento en Azure Blob), la interfaz WPF sufrirá **congelamiento de renderizado (UI Lag/Freeze)**.
* **Mejora con nuestros Skills**:
  - Aplicar las reglas de `revit-addin-gui-design`: exigir `VirtualizingStackPanel.IsVirtualizing="True"`, `ScrollViewer.CanContentScroll="True"` y la verificación del **límite de seguridad de 100,000 elementos** para garantizar una tasa de 60 fps constante incluso con catálogo masivo.

### B. Resilience API y Supresión de Diálogos Modales (`revit-api-resilience`)
* **Debilidad en `BimFM`**:
  - En `TryLoadFamily` y `TryLoadFamilySymbol`, el proceso de carga invoca `document.LoadFamily()` directamente dentro de una transacción. Si la familia a cargar genera advertencias de Revit (ej. *"Línea ligeramente fuera de eje"* o *"Un tipo de familia duplicado se sobrescribirá"*), Revit lanzará un diálogo modal emergente que detendrá la automatización del usuario.
* **Mejora con nuestros Skills**:
  - Integrar nuestro patrón **`WarningSwallower` / `IFailuresPreprocessor`** en las transacciones de carga para interceptar y eliminar warnings no fatales automáticamente en segundo plano sin interrumpir la experiencia de usuario.

### C. Hardening de Seguridad y Sanitización PII (`security-engineer`)
* **Debilidad en `BimFM`**:
  - En `FamilyManager.cs`, las rutas de temporales (`CreateFamilyLocalFile`) y la escritura de logs escriben nombres de usuario y rutas del sistema sin sanitizar (`C:\Users\david.barbero\...`), exponiendo Información de Identificación Personal (PII) en los logs corporativos.
  - No valida la elevación de rutas en operaciones de archivos locales (potencial Path Traversal `../`).
* **Mejora con nuestros Skills**:
  - Incorporar nuestro **`TelemetryLogger`** que reemplaza automáticamente directorios de usuario por tokens anónimos (`%USERPROFILE%`) y aplicar validación estricta de rutas de archivos con `Path.GetFullPath()`.

### D. Independencia Ecosistémica y C# 12 (`AGENTS.md`)
* **Debilidad en `BimFM`**:
  - Depende fuertemente de una suite de librerías propietarias de terceros (`Scotec.Revit`, `Scotec.Wpf.ViewModels`, `ScaleHQ.DotScreen`). Esto añade dependencias de ensamblados externos que pueden entrar en conflicto de versión con otros complementos instalados en la sesión de Revit.
* **Mejora con nuestros Skills**:
  - Desarrollar la integración en `TransferFamily` utilizando **C# 12 nativo** (constructores primarios, `CommunityToolkit.Mvvm`), eliminando capas middleware obsoletas y reduciendo la huella de DLLs a cargar en Revit.

---

## 4. Matriz Comparativa

| Dimensión | `BimFM` (`references_examples`) | Principios de Nuestro Proyecto | Veredicto |
| :--- | :--- | :--- | :--- |
| **Inyección de Dependencias** | Host / Autofac | Generic Host / DI C# 12 | **Alineado** |
| **Modelo de Hilos** | `RevitTask` (Async) | `RevitTask` (`revit-async-operations`) | **Alineado** |
| **Rendimiento UI en Ecosistema Grande** | Sin virtualización explícita | Virtualización WPF Mandatoria (`revit-addin-gui-design`) | 🚀 **Nuestro skill lo mejora** |
| **Gestión de Advertencias Revit** | Diálogos emergentes sin capturar | Supresión por `WarningSwallower` (`revit-api-resilience`) | 🚀 **Nuestro skill lo mejora** |
| **Seguridad de Logs & Rutas** | Logs con PII / Rutas sin sanitizar | Sanitización PII + Anti-Path Traversal (`security-engineer`) | 🚀 **Nuestro skill lo mejora** |
| **Simplicidad de Código** | Dependencias Scotec de terceros | C# 12 Primary Constructors + CommunityToolkit.Mvvm | 🚀 **Nuestro skill lo mejora** |
