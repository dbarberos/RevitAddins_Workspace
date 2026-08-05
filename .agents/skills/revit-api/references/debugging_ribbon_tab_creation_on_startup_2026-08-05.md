# Debugging Report: Ribbon Panel & Tab Registration Pre-requisites on Application Startup

**Date:** 2026-08-05  
**Domain:** Revit API / ExternalApplication / Ribbon UI Registration  
**Target Skill:** `revit-api`  

---

## 🔴 Symptom
The add-in binary and `.addin` manifest are present in `%APPDATA%\Autodesk\Revit\Addins\2024\`, but the add-in button does not appear in the Revit ribbon upon starting Revit.

---

## 🔍 Root Cause Analysis

In Revit API:
1. `Application.CreatePanel("PanelName", "TabName")` requires the target `TabName` to exist in the Revit UI.
2. If `TabName` is a custom tab (e.g. `"DBDev"`) and `Application.CreateRibbonTab("DBDev")` has NOT been executed during `OnStartup()`, `CreatePanel` throws `Autodesk.Revit.Exceptions.ArgumentException: The tab name does not exist.`
3. If this exception is unhandled during `OnStartup()`, Revit suppresses the entire add-in startup.

---

## 🟢 Resolution Pattern

Always ensure `Application.CreateRibbonTab(tabName)` is called inside a safe `try-catch` block before invoking `Application.CreatePanel("PanelName", tabName)`:

```csharp
public override void OnStartup()
{
    try
    {
        CreateRibbon();
    }
    catch (Exception ex)
    {
        System.Diagnostics.Debug.WriteLine("OnStartup Error: " + ex.Message);
    }
}

private void CreateRibbon()
{
    try
    {
        var settings = SettingsService.Load();
        RibbonPanel? panel = null;

        string tabName = "DBDev";
        if (settings.SelectedTabOption == TabOption.RevitDefault)
        {
            tabName = "Modify";
        }
        else if (settings.SelectedTabOption == TabOption.Custom && !string.IsNullOrWhiteSpace(settings.CustomTabName))
        {
            tabName = settings.CustomTabName;
        }

        // Ensure custom ribbon tab is created
        if (!tabName.Equals("Modify", StringComparison.OrdinalIgnoreCase) &&
            !tabName.Equals("Add-Ins", StringComparison.OrdinalIgnoreCase) &&
            !tabName.Equals("AddIns", StringComparison.OrdinalIgnoreCase))
        {
            try
            {
                Application.CreateRibbonTab(tabName);
            }
            catch
            {
                // Ignore if tab already exists in current Revit session
            }
        }

        try
        {
            panel = Application.CreatePanel("TransferPlus", tabName);
        }
        catch
        {
            panel = Application.CreatePanel("TransferPlus");
        }

        if (panel != null)
        {
            panel.AddPushButton<CmdTransferPlus>("Transfer\nPlus")
                .SetImage("/TransferPlus;component/Resources/Icons/TransferPlus16x16.png")
                .SetLargeImage("/TransferPlus;component/Resources/Icons/TransferPlus32x32.png");
        }
    }
    catch (Exception ex)
    {
        System.Diagnostics.Debug.WriteLine("Ribbon Creation Error: " + ex.Message);
    }
}
```
