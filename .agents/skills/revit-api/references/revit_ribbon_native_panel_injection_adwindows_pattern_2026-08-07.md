# Technical Reference: Direct Injection of Add-in Buttons into Native Revit Panels via AdWindows

**Date:** 2026-08-07  
**Target Skills:** `revit-api`, `revit-api-ux`, `revit-addin-helpers`  
**Domain:** Revit UI / Ribbon Customization / AdWindows Interop / Native Settings Group Placement  

---

## 📌 Context & Problem Statement

In Revit add-in development:
1. **Standard Revit API behavior (`Application.CreatePanel("Name", "Manage")`):** Creates a **NEW separate panel** at the far right end of the specified tab with its own group header title.
2. **User Requirement:** Place the add-in PushButton **INSIDE an existing built-in native Revit panel** (specifically the **Settings / Configuración** panel on the **Manage / Gestionar** tab), positioned right next to native tools like *"Additional Settings / Configuración adicional"*.
3. **API Restriction:** The standard Revit API (`Autodesk.Revit.UI.RibbonPanel`) does not allow appending `AddItem()` items into built-in native Revit panels initialized by Revit's C++ core.

---

## 🛠️ Architectural Solution: WPF `AdWindows` Ribbon Injection

To insert a PushButton directly inside a native Revit group panel without creating a separate custom panel:

### 1. AdWindows Reflection-Based Injection Algorithm
Using Reflection to target `Autodesk.Windows.ComponentManager.Ribbon` ensures zero hard compile-time assembly dependencies across Revit versions (2023–2027+).

```csharp
public static bool TryAddButtonToNativeSettingsPanel()
{
    try
    {
        foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
        {
            if (asm.GetName().Name == "AdWindows")
            {
                var compMgrType = asm.GetType("Autodesk.Windows.ComponentManager");
                var ribbonProp = compMgrType?.GetProperty("Ribbon", BindingFlags.Public | BindingFlags.Static);
                var ribbon = ribbonProp?.GetValue(null);
                if (ribbon == null) break;

                var tabsProp = ribbon.GetType().GetProperty("Tabs");
                var tabs = tabsProp?.GetValue(ribbon) as IEnumerable;
                if (tabs == null) break;

                // 1. Locate Manage Tab (Language Independent)
                object? manageTab = null;
                foreach (var tab in tabs)
                {
                    var tabIdProp = tab.GetType().GetProperty("Id");
                    string? tabId = tabIdProp?.GetValue(tab)?.ToString();
                    if (!string.IsNullOrEmpty(tabId) && 
                       (tabId.Equals("Manage", StringComparison.OrdinalIgnoreCase) || 
                        tabId.Equals("tab_Manage", StringComparison.OrdinalIgnoreCase)))
                    {
                        manageTab = tab;
                        break;
                    }
                }

                if (manageTab == null) break;

                // 2. Locate Native Settings Panel Source (Language Independent)
                var panelsProp = manageTab.GetType().GetProperty("Panels");
                var panels = panelsProp?.GetValue(manageTab) as IEnumerable;
                if (panels == null) break;

                object? settingsPanelSource = null;
                foreach (var panel in panels)
                {
                    var sourceProp = panel.GetType().GetProperty("Source");
                    var source = sourceProp?.GetValue(panel);
                    if (source != null)
                    {
                        var sourceIdProp = source.GetType().GetProperty("Id");
                        string? sourceId = sourceIdProp?.GetValue(source)?.ToString();
                        if (!string.IsNullOrEmpty(sourceId) && 
                           (sourceId.IndexOf("Settings", StringComparison.OrdinalIgnoreCase) >= 0 || 
                            sourceId.IndexOf("Manage_Settings", StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            settingsPanelSource = source;
                            break;
                        }
                    }
                }

                if (settingsPanelSource == null) break;

                // 3. Access Items Collection
                var itemsProp = settingsPanelSource.GetType().GetProperty("Items");
                var items = itemsProp?.GetValue(settingsPanelSource) as IList;
                if (items == null) break;

                // Prevent Duplicate Buttons
                foreach (var item in items)
                {
                    var idProp = item.GetType().GetProperty("Id");
                    if (idProp?.GetValue(item)?.ToString() == "TransferPlus_CmdTransferPlus")
                        return true;
                }

                // 4. Instantiate AdWindows RibbonButton
                var ribbonButtonType = asm.GetType("Autodesk.Windows.RibbonButton");
                if (ribbonButtonType == null) break;

                var newButton = Activator.CreateInstance(ribbonButtonType);
                if (newButton == null) break;

                ribbonButtonType.GetProperty("Text")?.SetValue(newButton, "Transfer\nPlus");
                ribbonButtonType.GetProperty("ShowText")?.SetValue(newButton, true);
                ribbonButtonType.GetProperty("Id")?.SetValue(newButton, "TransferPlus_CmdTransferPlus");

                var sizeEnum = asm.GetType("Autodesk.Windows.RibbonItemSize");
                if (sizeEnum != null)
                {
                    var largeValue = Enum.Parse(sizeEnum, "Large");
                    ribbonButtonType.GetProperty("Size")?.SetValue(newButton, largeValue);
                }

                ribbonButtonType.GetProperty("Orientation")?.SetValue(newButton, System.Windows.Controls.Orientation.Vertical);

                // Set Pack URIs for Icons
                var img16 = new BitmapImage(new Uri("pack://application:,,,/TransferPlus;component/Resources/Icons/TransferPlus16x16.png"));
                var img32 = new BitmapImage(new Uri("pack://application:,,,/TransferPlus;component/Resources/Icons/TransferPlus32x32.png"));

                ribbonButtonType.GetProperty("Image")?.SetValue(newButton, img16);
                ribbonButtonType.GetProperty("LargeImage")?.SetValue(newButton, img32);

                // Wire ICommand Handler
                var commandHandler = new TransferPlusRibbonCommandHandler();
                ribbonButtonType.GetProperty("CommandHandler")?.SetValue(newButton, commandHandler);

                // 5. Append directly to Native Settings Group Panel!
                items.Add(newButton);
                return true;
            }
        }
    }
    catch (Exception ex)
    {
        System.Diagnostics.Debug.WriteLine("TryAddButtonToNativeSettingsPanel Error: " + ex.Message);
    }
    return false;
}
```

### 2. Modeless Command Handler Implementation
```csharp
public class TransferPlusRibbonCommandHandler : System.Windows.Input.ICommand
{
    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter)
    {
        try
        {
            var uiApp = Nice3point.Revit.Toolkit.Context.UiApplication;
            if (uiApp != null && uiApp.ActiveUIDocument != null)
            {
                var viewModel = new ViewModels.TransferPlusViewModel(uiApp, uiApp.ActiveUIDocument.Document);
                var view = new Views.TransferPlusView(viewModel);
                if (uiApp.MainWindowHandle != IntPtr.Zero)
                {
                    new System.Windows.Interop.WindowInteropHelper(view).Owner = uiApp.MainWindowHandle;
                }
                view.ShowDialog();
            }
        }
        catch (Exception ex)
        {
            LoggerService.LogError("TransferPlusRibbonCommandHandler Execute Error", ex);
        }
    }
}
```

---

## 📋 Decision Matrix for Ribbon Button Placement

| Placement Requirement | Recommended Method | Visual Result |
| :--- | :--- | :--- |
| **Inside Built-in Native Panel** (e.g. Settings group on Manage tab) | `AdWindows` reflection injection into `RibbonPanelSource.Items` | Button appears **inside** native group alongside native Revit tools. |
| **Dedicated Add-in Panel on Built-in Tab** | Native API `Application.CreatePanel("Revit Configuration", "Manage")` | New separate panel created at the far right of built-in tab. |
| **Custom Add-in Tab** | `Application.CreateRibbonTab("DBDev")` + `Application.CreatePanel()` | Entirely separate tab and panel group. |
