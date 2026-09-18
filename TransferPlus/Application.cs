using System;
using Autodesk.Revit.UI;
using Nice3point.Revit.Toolkit.External;
using TransferPlus.Commands;
using TransferPlus.Services;
using TransferPlus.Models;

namespace TransferPlus;

/// <summary>
///     Application entry point
/// </summary>
[UsedImplicitly]
public class Application : ExternalApplication
{
    public override void OnStartup()
    {
        AppDomain.CurrentDomain.AssemblyResolve += OnAssemblyResolve;
        try
        {
            LoggerService.LogInfo("TransferPlus: Application.OnStartup started.");
            CreateRibbon();
            LoggerService.LogInfo("TransferPlus: Application.OnStartup completed.");
        }
        catch (Exception ex)
        {
            LoggerService.LogError("OnStartup Error creating ribbon", ex);
        }
    }

    private static System.Reflection.Assembly? OnAssemblyResolve(object? sender, ResolveEventArgs args)
    {
        try
        {
            string assemblyName = new System.Reflection.AssemblyName(args.Name).Name + ".dll";
            string folderPath = System.IO.Path.GetDirectoryName(typeof(Application).Assembly.Location) ?? string.Empty;
            string assemblyPath = System.IO.Path.Combine(folderPath, assemblyName);

            if (System.IO.File.Exists(assemblyPath))
            {
                return System.Reflection.Assembly.LoadFrom(assemblyPath);
            }
        }
        catch
        {
            // Ignore assembly resolve errors
        }
        return null;
    }

    private void CreateRibbon()
    {
        try
        {
            var settings = SettingsService.Load();
            RibbonPanel? panel = null;

            LoggerService.LogInfo($"CreateRibbon: SelectedTabOption={settings.SelectedTabOption}, CustomTabName='{settings.CustomTabName}'");

            if (settings.SelectedTabOption == TabOption.RevitDefault)
            {
                // Try inserting directly inside the native "Settings" (Configuración) panel on "Manage" tab
                bool addedToNativePanel = TryAddButtonToNativeSettingsPanel();
                if (addedToNativePanel)
                {
                    LoggerService.LogInfo("CreateRibbon: Button added to native Settings panel on Manage tab.");
                    return; // Button successfully placed inside native Settings group!
                }

                // Fallback: Place on Manage Tab under panel group "Revit Configuration"
                string panelName = "Revit Configuration";
                try
                {
                    panel = Application.CreatePanel(panelName, "Manage");
                }
                catch
                {
                    try
                    {
                        panel = Application.CreatePanel(panelName);
                    }
                    catch (Exception exP)
                    {
                        LoggerService.LogWarning($"CreateRibbon: Fallback create panel '{panelName}' failed: {exP.Message}");
                    }
                }
            }
            else if (settings.SelectedTabOption == TabOption.Custom && !string.IsNullOrWhiteSpace(settings.CustomTabName))
            {
                string tabName = settings.CustomTabName;

                // Ensure custom tab exists in Revit ribbon
                if (!tabName.Equals("Modify", StringComparison.OrdinalIgnoreCase) &&
                    !tabName.Equals("Add-Ins", StringComparison.OrdinalIgnoreCase) &&
                    !tabName.Equals("AddIns", StringComparison.OrdinalIgnoreCase) &&
                    !tabName.Equals("Manage", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        Application.CreateRibbonTab(tabName);
                        LoggerService.LogInfo($"CreateRibbon: Created ribbon tab '{tabName}'.");
                    }
                    catch
                    {
                        // Tab already exists in current Revit session
                        LoggerService.LogInfo($"CreateRibbon: Ribbon tab '{tabName}' already exists.");
                    }
                }

                try
                {
                    panel = Application.CreatePanel("TransferPlus", tabName);
                    LoggerService.LogInfo($"CreateRibbon: Created panel 'TransferPlus' on tab '{tabName}'.");
                }
                catch (Exception exPanel)
                {
                    LoggerService.LogWarning($"CreateRibbon: CreatePanel 'TransferPlus' on tab '{tabName}' failed: {exPanel.Message}. Attempting fallback to Add-Ins tab.");
                    try
                    {
                        panel = Application.CreatePanel("TransferPlus");
                    }
                    catch (Exception exDef)
                    {
                        LoggerService.LogError("CreateRibbon: Fallback CreatePanel 'TransferPlus' failed", exDef);
                    }
                }
            }
            else
            {
                // AddInsDefaultTab (Default): Place directly on Revit's native Add-Ins tab (Complementos)
                try
                {
                    panel = Application.CreatePanel("TransferPlus");
                    LoggerService.LogInfo("CreateRibbon: Created panel 'TransferPlus' on native Add-Ins tab.");
                }
                catch (Exception exPanel)
                {
                    LoggerService.LogError("CreateRibbon: CreatePanel 'TransferPlus' on Add-Ins tab failed", exPanel);
                }
            }

            if (panel != null)
            {
                var pushButton = panel.AddPushButton<CmdTransferPlus>("Transfer\nPlus");
                pushButton.SetImage("/TransferPlus;component/Resources/Icons/TransferPlus16x16.png");
                pushButton.SetLargeImage("/TransferPlus;component/Resources/Icons/TransferPlus32x32.png");
                pushButton.ToolTip = "TransferPlus Multi-Document & Cloud Transfer";
                pushButton.LongDescription = "Advanced transfer of elements, views, sheets, phases, and standards across Revit models, local disks, Autodesk Docs, Azure, and AWS.";

                // Configure Contextual F1 Help
                string assemblyDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) ?? string.Empty;
                string helpPath = System.IO.Path.Combine(assemblyDir, "Resources", "help.html");
                if (!System.IO.File.Exists(helpPath))
                {
                    string helpCapitalized = System.IO.Path.Combine(assemblyDir, "Resources", "Help.html");
                    if (System.IO.File.Exists(helpCapitalized))
                    {
                        helpPath = helpCapitalized;
                    }
                    else
                    {
                        string bundleRootHelp = System.IO.Path.GetFullPath(System.IO.Path.Combine(assemblyDir, "..", "Resources", "help.html"));
                        string bundleRootHelpCap = System.IO.Path.GetFullPath(System.IO.Path.Combine(assemblyDir, "..", "Resources", "Help.html"));
                        string singularResource = System.IO.Path.Combine(assemblyDir, "Resource", "help.html");
                        if (System.IO.File.Exists(bundleRootHelp))
                        {
                            helpPath = bundleRootHelp;
                        }
                        else if (System.IO.File.Exists(bundleRootHelpCap))
                        {
                            helpPath = bundleRootHelpCap;
                        }
                        else if (System.IO.File.Exists(singularResource))
                        {
                            helpPath = singularResource;
                        }
                    }
                }
                if (System.IO.File.Exists(helpPath))
                {
                    ContextualHelp contextHelp = new ContextualHelp(ContextualHelpType.Url, helpPath);
                    pushButton.SetContextualHelp(contextHelp);
                }

                LoggerService.LogInfo("CreateRibbon: PushButton 'TransferPlus' successfully registered on Ribbon.");
            }
            else
            {
                LoggerService.LogError("CreateRibbon: Panel is null, could not add PushButton.", new InvalidOperationException("RibbonPanel is null"));
            }
        }
        catch (Exception ex)
        {
            LoggerService.LogError("CreateRibbon Error", ex);
        }
    }

    private RibbonPanel? FindOrGetSettingsPanel()
    {
        try
        {
            var panels = Application.GetRibbonPanels();

            // 1. Try finding via AdWindows Panel Id (100% Language Independent)
            string? targetTitle = GetSettingsPanelTitleFromAdWindows();
            if (!string.IsNullOrEmpty(targetTitle))
            {
                foreach (var p in panels)
                {
                    if (p.Name.Equals(targetTitle, StringComparison.OrdinalIgnoreCase))
                    {
                        return p;
                    }
                }
            }

            // 2. Multilingual Fallback Matching
            var knownSettingsNames = new System.Collections.Generic.HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "Settings", "Configuración", "Configuracion", "Einstellungen", "Paramètres", "Parametres",
                "Impostazioni", "Impostaciones", "Configurações", "Configuracoes", "Настройки", "設定", "設置", "설정"
            };

            foreach (var p in panels)
            {
                if (knownSettingsNames.Contains(p.Name))
                {
                    return p;
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("FindOrGetSettingsPanel Exception: " + ex.Message);
        }
        return null;
    }

    private static string? GetSettingsPanelTitleFromAdWindows()
    {
        try
        {
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (asm.GetName().Name == "AdWindows")
                {
                    var compMgrType = asm.GetType("Autodesk.Windows.ComponentManager");
                    var ribbonProp = compMgrType?.GetProperty("Ribbon", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                    var ribbon = ribbonProp?.GetValue(null);
                    if (ribbon == null) break;

                    var tabsProp = ribbon.GetType().GetProperty("Tabs");
                    var tabs = tabsProp?.GetValue(ribbon) as System.Collections.IEnumerable;
                    if (tabs == null) break;

                    foreach (var tab in tabs)
                    {
                        var tabIdProp = tab.GetType().GetProperty("Id");
                        string? tabId = tabIdProp?.GetValue(tab)?.ToString();
                        if (tabId != null && (tabId.Equals("Manage", StringComparison.OrdinalIgnoreCase) || tabId.Equals("tab_Manage", StringComparison.OrdinalIgnoreCase)))
                        {
                            var panelsProp = tab.GetType().GetProperty("Panels");
                            var panels = panelsProp?.GetValue(tab) as System.Collections.IEnumerable;
                            if (panels == null) break;

                            foreach (var panel in panels)
                            {
                                var sourceProp = panel.GetType().GetProperty("Source");
                                var source = sourceProp?.GetValue(panel);
                                if (source != null)
                                {
                                    var sourceIdProp = source.GetType().GetProperty("Id");
                                    string? sourceId = sourceIdProp?.GetValue(source)?.ToString();
                                    if (!string.IsNullOrEmpty(sourceId) && (sourceId.IndexOf("Settings", StringComparison.OrdinalIgnoreCase) >= 0 || sourceId.IndexOf("Manage_Settings", StringComparison.OrdinalIgnoreCase) >= 0))
                                    {
                                        var titleProp = source.GetType().GetProperty("Title");
                                        return titleProp?.GetValue(source)?.ToString();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        catch
        {
            // Safe reflection fallback
        }
        return null;
    }

    private static bool TryAddButtonToNativeSettingsPanel()
    {
        try
        {
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (asm.GetName().Name == "AdWindows")
                {
                    var compMgrType = asm.GetType("Autodesk.Windows.ComponentManager");
                    var ribbonProp = compMgrType?.GetProperty("Ribbon", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                    var ribbon = ribbonProp?.GetValue(null);
                    if (ribbon == null) break;

                    var tabsProp = ribbon.GetType().GetProperty("Tabs");
                    var tabs = tabsProp?.GetValue(ribbon) as System.Collections.IEnumerable;
                    if (tabs == null) break;

                    object? manageTab = null;
                    foreach (var tab in tabs)
                    {
                        var tabIdProp = tab.GetType().GetProperty("Id");
                        string? tabId = tabIdProp?.GetValue(tab)?.ToString();
                        if (!string.IsNullOrEmpty(tabId) && (tabId.Equals("Manage", StringComparison.OrdinalIgnoreCase) || tabId.Equals("tab_Manage", StringComparison.OrdinalIgnoreCase)))
                        {
                            manageTab = tab;
                            break;
                        }
                    }

                    if (manageTab == null) break;

                    var panelsProp = manageTab.GetType().GetProperty("Panels");
                    var panels = panelsProp?.GetValue(manageTab) as System.Collections.IEnumerable;
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
                            if (!string.IsNullOrEmpty(sourceId) && (sourceId.IndexOf("Settings", StringComparison.OrdinalIgnoreCase) >= 0 || sourceId.IndexOf("Manage_Settings", StringComparison.OrdinalIgnoreCase) >= 0))
                            {
                                settingsPanelSource = source;
                                break;
                            }
                        }
                    }

                    if (settingsPanelSource == null) break;

                    var itemsProp = settingsPanelSource.GetType().GetProperty("Items");
                    var items = itemsProp?.GetValue(settingsPanelSource) as System.Collections.IList;
                    if (items == null) break;

                    // Check if already added
                    foreach (var item in items)
                    {
                        var idProp = item.GetType().GetProperty("Id");
                        if (idProp?.GetValue(item)?.ToString() == "TransferPlus_CmdTransferPlus")
                        {
                            return true;
                        }
                    }

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

                    var img16 = new System.Windows.Media.Imaging.BitmapImage(new Uri("pack://application:,,,/TransferPlus;component/Resources/Icons/TransferPlus16x16.png"));
                    var img32 = new System.Windows.Media.Imaging.BitmapImage(new Uri("pack://application:,,,/TransferPlus;component/Resources/Icons/TransferPlus32x32.png"));

                    ribbonButtonType.GetProperty("Image")?.SetValue(newButton, img16);
                    ribbonButtonType.GetProperty("LargeImage")?.SetValue(newButton, img32);

                    var commandHandler = new TransferPlusRibbonCommandHandler();
                    ribbonButtonType.GetProperty("CommandHandler")?.SetValue(newButton, commandHandler);

                    // Locate "Additional Settings" / "Configuración adicional" to insert right next to it (to its right)
                    int targetIndex = -1;
                    for (int i = 0; i < items.Count; i++)
                    {
                        var it = items[i];
                        if (it == null) continue;
                        var itType = it.GetType();
                        string? itemId = itType.GetProperty("Id")?.GetValue(it)?.ToString();
                        string? itemText = itType.GetProperty("Text")?.GetValue(it)?.ToString();

                        if (!string.IsNullOrEmpty(itemId) && (itemId.IndexOf("AdditionalSettings", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                             itemId.IndexOf("Additional_Settings", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                             itemId.IndexOf("MenuAdditionalSettings", StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            targetIndex = i;
                            break;
                        }
                        if (!string.IsNullOrEmpty(itemText) && (itemText.IndexOf("Additional Settings", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                               itemText.IndexOf("Configuración adicional", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                               itemText.IndexOf("Configuracion adicional", StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            targetIndex = i;
                            break;
                        }
                    }

                    if (targetIndex >= 0 && targetIndex + 1 <= items.Count)
                    {
                        items.Insert(targetIndex + 1, newButton);
                        LoggerService.LogInfo($"TryAddButtonToNativeSettingsPanel: Inserted button at index {targetIndex + 1} to the right of Additional Settings.");
                    }
                    else
                    {
                        items.Add(newButton);
                        LoggerService.LogInfo("TryAddButtonToNativeSettingsPanel: Additional Settings not found, appended button to items collection.");
                    }

                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("TryAddButtonToNativeSettingsPanel Exception: " + ex.Message);
        }
        return false;
    }
}

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