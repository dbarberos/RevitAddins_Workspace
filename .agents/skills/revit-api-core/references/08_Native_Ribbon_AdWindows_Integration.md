# Skill: Native Revit Ribbon Panel Integration via AdWindows (Autodesk.Windows)

## 1. Technical Data Sheet & Context
* **Skill ID:** SKILL-RVT-008
* **Technical Area:** Ribbon Customization / Native Panel Integration
* **API Dependencies:** `Autodesk.Revit.UI`, `AdWindows.dll` (`Autodesk.Windows`), `System.Windows.Media.Imaging`
* **Design Pattern:** Host Extension / Structural Injection Pattern
* **Scope:** Inserting custom add-in tools into existing native Autodesk Revit panels (such as `Manage` tab -> `Settings` panel, adjacent to "Additional Settings").

---

## 2. Motivation & Official API Constraints

The official Revit API (`UIControlledApplication.CreateRibbonPanel` / `CreateRibbonTab`) only permits:
1. Creating brand new custom ribbon tabs.
2. Creating new panels inside custom tabs or standard tabs (`Add-Ins`, `Analyze`, `Modify`).

However, the official API does **not** allow inserting a command button into pre-existing native panels (e.g., adding an enterprise configuration tool into the native **Settings** group on the **Manage** tab, right next to *Additional Settings*).

To achieve this without breaking host UI or causing unstable interop, add-ins access the underlying WPF ribbon control via `Autodesk.Windows.ComponentManager.RibbonControl` (`AdWindows.dll`).

---

## 3. Implementation Workflow

### 3.1. Threading & Lifecycle
* Must execute on the main UI thread inside `IExternalApplication.OnStartup()`.
* Must be wrapped in non-blocking try-catch blocks to prevent halting Revit startup if the native panel structure changes across future Revit releases or localized language packs.

### 3.2. Panel & Button Discovery
1. Retrieve `Autodesk.Windows.ComponentManager.RibbonControl`.
2. Find the target tab (e.g., `Manage` / `Gestionar` by Id or Title).
3. Locate the target panel (e.g., `Settings_Tab_Manage` or Title containing `Settings` / `Configuración`).
4. Iterate over `targetPanel.Source.Items` to locate the reference button (e.g. `AdditionalSettings` / `Configuración adicional`).
5. Insert the new `Autodesk.Windows.RibbonButton` at `targetIndex + 1` (`items.Insert(targetIndex + 1, newButton)`).

### 3.3. Graceful Fallback Pattern
If `AdWindows` cannot resolve the native panel (e.g., headless Revit, Dynamo batch, or unexpected language translation), always fall back to creating a standard panel via the official Revit API:

```csharp
bool added = TryAddButtonToNativeSettingsPanel();
if (!added)
{
    // Fallback: Place in custom panel on Manage tab
    panel = uiApp.CreateRibbonPanel("Manage", "Revit Configuration");
    panel.AddItem(buttonData);
}
```

---

## 4. Contextual Help Integration (F1)
Native `Autodesk.Windows.RibbonButton` supports contextual F1 help directly via the `HelpSource` property:
```csharp
newButton.HelpSource = new Uri(helpUrl, UriKind.RelativeOrAbsolute);
```
This ensures consistent behavior matching Revit's native help integration.
