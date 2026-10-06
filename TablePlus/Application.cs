using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using JetBrains.Annotations;
using Nice3point.Revit.Extensions;
using Nice3point.Revit.Toolkit.External;
using TablePlus.Commands;
using TablePlus.Models;
using TablePlus.Services;

namespace TablePlus;

/// <summary>
/// Application entry point for TablePlus.
/// Configures Revit Ribbon tab, panels, pushbuttons, registers the dynamic assembly resolver,
/// and hooks document lifecycle events for automatic background synchronization.
/// </summary>
[UsedImplicitly]
public class Application : ExternalApplication
{
    public override void OnStartup()
    {
        AppDomain.CurrentDomain.AssemblyResolve += OnAssemblyResolve;

        try
        {
            LoggerService.LogInfo("TablePlus: Application.OnStartup started.");
            CreateRibbon();
            LoggerService.LogInfo("TablePlus: Application.OnStartup completed.");
        }
        catch (Exception ex)
        {
            LoggerService.LogError("OnStartup Error creating ribbon", ex);
        }

        try
        {
            Application.ControlledApplication.DocumentOpened += OnDocumentOpened;
            LoggerService.LogInfo("TablePlus: DocumentOpened auto-sync hook registered.");
        }
        catch (Exception ex)
        {
            LoggerService.LogError("OnStartup AutoSync Hook Error", ex);
        }
    }

    public override void OnShutdown()
    {
        AppDomain.CurrentDomain.AssemblyResolve -= OnAssemblyResolve;

        try
        {
            Application.ControlledApplication.DocumentOpened -= OnDocumentOpened;
        }
        catch
        {
            // Silently swallow unhook exceptions on exit
        }

        CloseDebugLogWindow();
    }

    /// <summary>
    /// Background check executed when a project document is opened.
    /// Automatically updates any table views marked with IsAutoSyncEnabled if their source file was modified.
    /// </summary>
    private static void OnDocumentOpened(object? sender, Autodesk.Revit.DB.Events.DocumentOpenedEventArgs e)
    {
        var doc = e.Document;
        if (doc == null || doc.IsFamilyDocument || doc.IsReadOnly) return;

        try
        {
            var schemaService = new SchemaService();
            var excelService = new ExcelReaderService();
            var registryService = new TableRegistryService(schemaService, excelService);

            var tables = registryService.DiscoverTablesAsync(doc).GetAwaiter().GetResult();
            var autoSyncTables = tables.Where(t => t.IsAutoSyncEnabled && t.Status == TableSyncStatus.Modified).ToList();

            if (autoSyncTables.Count > 0)
            {
                var geometryService = new TableGeometryService(schemaService);

                using var tg = new TransactionGroup(doc, "TablePlus: Auto-Sync Tables on Document Open");
                tg.Start();

                foreach (var item in autoSyncTables)
                {
                    if (!System.IO.File.Exists(item.SourceFilePath)) continue;

                    try
                    {
                        var cells = excelService.ExtractCells(item.SourceFilePath, item.SelectedSheetName, item.Config.CustomRangeAddress);
                        var merges = excelService.ExtractMergedCells(item.SourceFilePath, item.SelectedSheetName);

#if REVIT2024_OR_GREATER
                        var viewId = new ElementId(item.ViewId);
#else
                        var viewId = new ElementId((int)item.ViewId);
#endif
                        if (doc.GetElement(viewId) is View targetView)
                        {
                            if (targetView is ViewSchedule scheduleView && item.Config.ImportType == TableImportType.KeySchedule)
                            {
                                var keyService = new KeyScheduleService(schemaService);
                                keyService.UpdateKeySchedule(doc, scheduleView, item.Config, cells);
                            }
                            else if (targetView is ViewSchedule scheduleViewHdr && item.Config.ImportType == TableImportType.HeaderSchedule)
                            {
                                var headerService = new HeaderScheduleService(schemaService);
                                headerService.UpdateHeaderSchedule(doc, scheduleViewHdr, item.Config, cells, merges);
                            }
                            else
                            {
                                geometryService.UpdateTableInView(doc, targetView, item.Config, cells, merges);
                            }
                        }
                    }
                    catch
                    {
                        // Proceed with remaining tables if one fails
                    }
                }

                tg.Assimilate();
            }
        }
        catch
        {
            // Document open must never be interrupted by background auto-sync exceptions
        }
    }

    /// <summary>
    /// Resolves referenced dependencies located in the add-in directory,
    /// crucial for .NET 8 (Revit 2025+) isolated load contexts and third-party libraries.
    /// </summary>
    private static System.Reflection.Assembly? OnAssemblyResolve(object? sender, ResolveEventArgs args)
    {
        try
        {
            var assemblyName = new System.Reflection.AssemblyName(args.Name).Name + ".dll";
            var folderPath = System.IO.Path.GetDirectoryName(typeof(Application).Assembly.Location) ?? string.Empty;
            var assemblyPath = System.IO.Path.Combine(folderPath, assemblyName);

            if (System.IO.File.Exists(assemblyPath))
            {
                return System.Reflection.Assembly.LoadFrom(assemblyPath);
            }
        }
        catch
        {
            // Silently swallow resolve failures to allow standard probing
        }
        return null;
    }

    private void CreateRibbon()
    {
        var settings = SettingsService.Load();
        RibbonPanel? panel = null;

        LoggerService.LogInfo($"CreateRibbon: SelectedTabOption={settings.SelectedTabOption}, CustomTabName='{settings.CustomTabName}'");

        try
        {
            if (settings.SelectedTabOption == TabOption.RevitDefault)
            {
                bool addedToNativePanel = TryAddButtonToNativeManageProjectPanel();
                if (addedToNativePanel)
                {
                    LoggerService.LogInfo("CreateRibbon: Button successfully attached to native Manage Project panel on Manage tab.");
                }
                else
                {
                    LoggerService.LogWarning("CreateRibbon: Could not attach to native Manage Project panel via AdWindows. Using fallback panel.");
                    try
                    {
                        panel = Application.CreatePanel("Gestionar proyecto", "Manage");
                    }
                    catch
                    {
                        panel = Application.CreatePanel("TablePlus", "Manage");
                    }
                }
            }
            else if (settings.SelectedTabOption == TabOption.Custom && !string.IsNullOrWhiteSpace(settings.CustomTabName))
            {
                string tabName = settings.CustomTabName;
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
                    panel = Application.CreatePanel("TablePlus", tabName);
                    LoggerService.LogInfo($"CreateRibbon: Created panel 'TablePlus' on tab '{tabName}'.");
                }
                catch (Exception exPanel)
                {
                    LoggerService.LogWarning($"CreateRibbon: CreatePanel 'TablePlus' on tab '{tabName}' failed: {exPanel.Message}. Attempting fallback to Add-Ins tab.");
                    panel = Application.CreatePanel("TablePlus");
                }
            }
            else
            {
                // AddInsDefaultTab (Default): Place directly on Revit's native Add-Ins tab (Complementos)
                panel = Application.CreatePanel("TablePlus");
                LoggerService.LogInfo("CreateRibbon: Created panel 'TablePlus' on native Add-Ins tab.");
            }
        }
        catch (Exception ex)
        {
            LoggerService.LogError("CreateRibbon: CreatePanel 'TablePlus' failed", ex);
        }

        if (panel != null)
        {
            try
            {
                var button = panel.AddPushButton<CmdImportTable>("TablePlus");
                button.SetImage("/TablePlus;component/Resources/Icons/TablePlus16x16.png");
                button.SetLargeImage("/TablePlus;component/Resources/Icons/TablePlus32x32.png");
                button.ToolTip = "TablePlus — Master Table Dashboard";
                button.LongDescription = "Open the TablePlus Master Dashboard to manage, synchronize, and format Excel spreadsheets and schedules in Revit Drafting and Legend views.";

                // Contextual F1 Help configuration
                try
                {
                    var assemblyDir = System.IO.Path.GetDirectoryName(typeof(Application).Assembly.Location) ?? string.Empty;
                    var helpPath = System.IO.Path.Combine(assemblyDir, "Resources", "help.html");
                    if (!System.IO.File.Exists(helpPath))
                    {
                        var helpPathCapitalized = System.IO.Path.Combine(assemblyDir, "Resources", "Help.html");
                        if (System.IO.File.Exists(helpPathCapitalized))
                        {
                            helpPath = helpPathCapitalized;
                        }
                        else
                        {
                            var bundleHelp = System.IO.Path.GetFullPath(System.IO.Path.Combine(assemblyDir, "..", "Resources", "help.html"));
                            if (System.IO.File.Exists(bundleHelp))
                            {
                                helpPath = bundleHelp;
                            }
                        }
                    }

                    if (System.IO.File.Exists(helpPath))
                    {
                        button.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, helpPath));
                    }
                }
                catch
                {
                    // Silently ignore help resolution failures
                }

                LoggerService.LogInfo("CreateRibbon: PushButton 'TablePlus' registered successfully.");
            }
            catch (Exception ex)
            {
                LoggerService.LogError("CreateRibbon: PushButton registration failed", ex);
            }
        }
        else
        {
            LoggerService.LogInfo("CreateRibbon: panel is null (attached to native panel or skipped).");
        }

#if REVIT2025_OR_GREATER
        if (settings.UseAsContextualFilter)
        {
            try
            {
                this.Application.RegisterContextMenu("TablePlus", new TableContextMenuCreator());
                LoggerService.LogInfo("CreateRibbon: Registered right-click context menu for TablePlus.");
            }
            catch (Exception ex)
            {
                LoggerService.LogError("CreateRibbon: Context Menu Registration", ex);
            }
        }
#endif
    }

    /// <summary>
    /// Attaches the TablePlus Ribbon button directly to Revit's native "Manage Project" ("Gestionar proyecto")
    /// panel under the "Manage" tab using AdWindows reflection.
    /// </summary>
    private static bool TryAddButtonToNativeManageProjectPanel()
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
                        var tabIdProp = tab?.GetType().GetProperty("Id");
                        string? tabId = tabIdProp?.GetValue(tab)?.ToString();
                        if (tabId != null && (string.Equals(tabId, "Manage", StringComparison.OrdinalIgnoreCase) || string.Equals(tabId, "tab_Manage", StringComparison.OrdinalIgnoreCase)))
                        {
                            manageTab = tab;
                            break;
                        }
                    }

                    if (manageTab == null) break;

                    var panelsProp = manageTab.GetType().GetProperty("Panels");
                    var panels = panelsProp?.GetValue(manageTab) as System.Collections.IEnumerable;
                    if (panels == null) break;

                    object? projectPanelSource = null;

                    // Pass 1: Localized title match for "Manage Project" / "Gestionar proyecto"
                    foreach (var panel in panels)
                    {
                        var sourceProp = panel?.GetType().GetProperty("Source");
                        var source = sourceProp?.GetValue(panel);
                        if (source == null) continue;

                        var sourceIdProp = source.GetType().GetProperty("Id");
                        string? sourceId = sourceIdProp?.GetValue(source)?.ToString();
                        var titleProp = source.GetType().GetProperty("Title");
                        string? title = titleProp?.GetValue(source)?.ToString();

                        if (IsExcludedManageTabPanel(title, sourceId)) continue;

                        if (title != null && (
                            string.Equals(title.Trim(), "Gestionar proyecto", StringComparison.OrdinalIgnoreCase) ||
                            string.Equals(title.Trim(), "Manage Project", StringComparison.OrdinalIgnoreCase) ||
                            title.IndexOf("Gestionar proyecto", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            title.IndexOf("Manage Project", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            title.IndexOf("Projektverwaltung", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            title.IndexOf("Gestion de projet", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            title.IndexOf("Gestione del progetto", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            title.IndexOf("Gerenciar projeto", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            title.IndexOf("Управление проектом", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            title.IndexOf("プロジェクト管理", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            title.IndexOf("项目管理", StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            projectPanelSource = source;
                            LoggerService.LogInfo($"TryAddButtonToNativeManageProjectPanel: Matched 'Manage Project' panel by title: '{title}'.");
                            break;
                        }
                    }

                    // Pass 2: Match by unique item "ManageLinks" / "Gestionar vínculos"
                    if (projectPanelSource == null)
                    {
                        foreach (var panel in panels)
                        {
                            var sourceProp = panel?.GetType().GetProperty("Source");
                            var source = sourceProp?.GetValue(panel);
                            if (source == null) continue;

                            var sourceIdProp = source.GetType().GetProperty("Id");
                            string? sourceId = sourceIdProp?.GetValue(source)?.ToString();
                            var titleProp = source.GetType().GetProperty("Title");
                            string? title = titleProp?.GetValue(source)?.ToString();

                            if (IsExcludedManageTabPanel(title, sourceId)) continue;

                            var testItemsProp = source.GetType().GetProperty("Items");
                            if (testItemsProp?.GetValue(source) is System.Collections.IList testItems)
                            {
                                bool hasManageLinks = false;
                                foreach (var it in testItems)
                                {
                                    if (it == null) continue;
                                    var itId = it.GetType().GetProperty("Id")?.GetValue(it)?.ToString() ?? "";
                                    var itText = it.GetType().GetProperty("Text")?.GetValue(it)?.ToString() ?? "";
                                    if (itId.IndexOf("ManageLinks", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                        itId.IndexOf("Manage_Links", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                        itText.IndexOf("Gestionar vínculos", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                        itText.IndexOf("Gestionar vinculos", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                        itText.IndexOf("Manage Links", StringComparison.OrdinalIgnoreCase) >= 0)
                                    {
                                        hasManageLinks = true;
                                        break;
                                    }
                                }
                                if (hasManageLinks)
                                {
                                    projectPanelSource = source;
                                    LoggerService.LogInfo($"TryAddButtonToNativeManageProjectPanel: Matched 'Manage Project' panel by ManageLinks item (title: '{title}').");
                                    break;
                                }
                            }
                        }
                    }

                    // Pass 3: Match by Source ID (Manage_Project, ManageProject, ProjectManagement)
                    if (projectPanelSource == null)
                    {
                        foreach (var panel in panels)
                        {
                            var sourceProp = panel?.GetType().GetProperty("Source");
                            var source = sourceProp?.GetValue(panel);
                            if (source == null) continue;

                            var sourceIdProp = source.GetType().GetProperty("Id");
                            string? sourceId = sourceIdProp?.GetValue(source)?.ToString();
                            var titleProp = source.GetType().GetProperty("Title");
                            string? title = titleProp?.GetValue(source)?.ToString();

                            if (IsExcludedManageTabPanel(title, sourceId)) continue;

                            if (sourceId != null && (
                                sourceId.IndexOf("Manage_Project", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                sourceId.IndexOf("ManageProject", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                sourceId.IndexOf("ProjectManagement", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                sourceId.IndexOf("Project_Management", StringComparison.OrdinalIgnoreCase) >= 0))
                            {
                                projectPanelSource = source;
                                LoggerService.LogInfo($"TryAddButtonToNativeManageProjectPanel: Matched 'Manage Project' panel by SourceId: '{sourceId}'.");
                                break;
                            }
                        }
                    }

                    if (projectPanelSource == null)
                    {
                        LoggerService.LogWarning("TryAddButtonToNativeManageProjectPanel: Native Manage Project panel not found.");
                        break;
                    }

                    // Remove any stale button from all other panels on the Manage tab (e.g. Ubicación de proyecto)
                    foreach (var panel in panels)
                    {
                        var sourceProp = panel?.GetType().GetProperty("Source");
                        var source = sourceProp?.GetValue(panel);
                        if (source != null && source != projectPanelSource)
                        {
                            var otherItemsProp = source.GetType().GetProperty("Items");
                            if (otherItemsProp?.GetValue(source) is System.Collections.IList otherItems)
                            {
                                for (int i = otherItems.Count - 1; i >= 0; i--)
                                {
                                    var it = otherItems[i];
                                    var itId = it?.GetType().GetProperty("Id")?.GetValue(it)?.ToString();
                                    if (itId == "TablePlus_CmdImportTable")
                                    {
                                        otherItems.RemoveAt(i);
                                        LoggerService.LogInfo("TryAddButtonToNativeManageProjectPanel: Removed stale TablePlus button from non-target panel.");
                                    }
                                }
                            }
                        }
                    }

                    var itemsProp = projectPanelSource.GetType().GetProperty("Items");
                    var items = itemsProp?.GetValue(projectPanelSource) as System.Collections.IList;
                    if (items == null) break;

                    // Check if already added
                    foreach (var item in items)
                    {
                        var idProp = item.GetType().GetProperty("Id");
                        if (idProp?.GetValue(item)?.ToString() == "TablePlus_CmdImportTable")
                        {
                            return true;
                        }
                    }

                    var ribbonButtonType = asm.GetType("Autodesk.Windows.RibbonButton");
                    if (ribbonButtonType == null) break;

                    var newButton = Activator.CreateInstance(ribbonButtonType);
                    if (newButton == null) break;

                    ribbonButtonType.GetProperty("Text")?.SetValue(newButton, "Table\nPlus");
                    ribbonButtonType.GetProperty("ShowText")?.SetValue(newButton, true);
                    ribbonButtonType.GetProperty("Id")?.SetValue(newButton, "TablePlus_CmdImportTable");

                    var sizeEnum = asm.GetType("Autodesk.Windows.RibbonItemSize");
                    if (sizeEnum != null)
                    {
                        var largeValue = Enum.Parse(sizeEnum, "Large");
                        ribbonButtonType.GetProperty("Size")?.SetValue(newButton, largeValue);
                    }

                    ribbonButtonType.GetProperty("Orientation")?.SetValue(newButton, System.Windows.Controls.Orientation.Vertical);

                    var img16 = new System.Windows.Media.Imaging.BitmapImage(new Uri("pack://application:,,,/TablePlus;component/Resources/Icons/TablePlus16x16.png"));
                    var img32 = new System.Windows.Media.Imaging.BitmapImage(new Uri("pack://application:,,,/TablePlus;component/Resources/Icons/TablePlus32x32.png"));

                    ribbonButtonType.GetProperty("Image")?.SetValue(newButton, img16);
                    ribbonButtonType.GetProperty("LargeImage")?.SetValue(newButton, img32);

                    var commandHandler = new TablePlusRibbonCommandHandler();
                    ribbonButtonType.GetProperty("CommandHandler")?.SetValue(newButton, commandHandler);

                    ribbonButtonType.GetProperty("ToolTip")?.SetValue(newButton, "TablePlus — Master Table Dashboard\nManage, synchronize, and format Excel spreadsheets and schedules in Revit Drafting and Legend views.");

                    // Insert next to Purge Unused or Transfer Project Standards if found, or append
                    int targetIndex = -1;
                    for (int i = 0; i < items.Count; i++)
                    {
                        var it = items[i];
                        if (it == null) continue;
                        var itType = it.GetType();
                        string? itemId = itType.GetProperty("Id")?.GetValue(it)?.ToString();
                        string? itemText = itType.GetProperty("Text")?.GetValue(it)?.ToString();

                        if (itemId != null && (
                            itemId.IndexOf("PurgeUnused", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            itemId.IndexOf("TransferProjectStandards", StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            targetIndex = i;
                            break;
                        }
                        if (itemText != null && (
                            itemText.IndexOf("Purge", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            itemText.IndexOf("Limpiar", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            itemText.IndexOf("Normas de proyecto", StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            targetIndex = i;
                            break;
                        }
                    }

                    if (targetIndex >= 0 && targetIndex + 1 <= items.Count)
                    {
                        items.Insert(targetIndex + 1, newButton);
                        LoggerService.LogInfo($"TryAddButtonToNativeManageProjectPanel: Inserted button at index {targetIndex + 1} next to Purge/Transfer Standards.");
                    }
                    else
                    {
                        items.Add(newButton);
                        LoggerService.LogInfo("TryAddButtonToNativeManageProjectPanel: Appended button to Manage Project items collection.");
                    }

                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            LoggerService.LogError("TryAddButtonToNativeManageProjectPanel Error", ex);
        }
        return false;
    }

    /// <summary>
    /// Checks whether a panel on the Manage tab is an excluded non-target panel
    /// such as Project Location, Design Options, Generative Design, Phasing, or Settings.
    /// </summary>
    private static bool IsExcludedManageTabPanel(string? title, string? sourceId)
    {
        if (sourceId != null)
        {
            if (sourceId.IndexOf("Location", StringComparison.OrdinalIgnoreCase) >= 0 ||
                sourceId.IndexOf("Ubicacion", StringComparison.OrdinalIgnoreCase) >= 0 ||
                sourceId.IndexOf("DesignOption", StringComparison.OrdinalIgnoreCase) >= 0 ||
                sourceId.IndexOf("Generative", StringComparison.OrdinalIgnoreCase) >= 0 ||
                sourceId.IndexOf("Phasing", StringComparison.OrdinalIgnoreCase) >= 0 ||
                sourceId.IndexOf("Settings", StringComparison.OrdinalIgnoreCase) >= 0 ||
                sourceId.IndexOf("Macro", StringComparison.OrdinalIgnoreCase) >= 0 ||
                sourceId.IndexOf("Visual", StringComparison.OrdinalIgnoreCase) >= 0 ||
                sourceId.IndexOf("Select", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return true;
            }
        }
        if (title != null)
        {
            if (title.IndexOf("Ubicación", StringComparison.OrdinalIgnoreCase) >= 0 ||
                title.IndexOf("Ubicacion", StringComparison.OrdinalIgnoreCase) >= 0 ||
                title.IndexOf("Location", StringComparison.OrdinalIgnoreCase) >= 0 ||
                title.IndexOf("Opciones de diseño", StringComparison.OrdinalIgnoreCase) >= 0 ||
                title.IndexOf("Design Options", StringComparison.OrdinalIgnoreCase) >= 0 ||
                title.IndexOf("Diseño generativo", StringComparison.OrdinalIgnoreCase) >= 0 ||
                title.IndexOf("Generative Design", StringComparison.OrdinalIgnoreCase) >= 0 ||
                title.IndexOf("Configuración", StringComparison.OrdinalIgnoreCase) >= 0 ||
                title.IndexOf("Settings", StringComparison.OrdinalIgnoreCase) >= 0 ||
                title.IndexOf("Fases", StringComparison.OrdinalIgnoreCase) >= 0 ||
                title.IndexOf("Phasing", StringComparison.OrdinalIgnoreCase) >= 0 ||
                title.IndexOf("Selección", StringComparison.OrdinalIgnoreCase) >= 0 ||
                title.IndexOf("Select", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return true;
            }
        }
        return false;
    }

    private static Views.LogView? _debugLogView;

    /// <summary>
    /// Toggles the visibility of the TablePlus Debug Log window.
    /// Operates identically in both Debug and Production/Release modes.
    /// </summary>
    public static void ToggleDebugLogWindow(System.Windows.Window? owner = null)
    {
        try
        {
            var app = System.Windows.Application.Current;
            var dispatcher = app?.Dispatcher ?? System.Windows.Threading.Dispatcher.CurrentDispatcher;

            if (dispatcher != null && !dispatcher.CheckAccess())
            {
                dispatcher.BeginInvoke(new Action(() => ToggleDebugLogWindow(owner)));
                return;
            }

            if (_debugLogView != null && _debugLogView.IsVisible)
            {
                _debugLogView.Hide();
                LoggerService.LogInfo("ToggleDebugLogWindow: Hidden LogView.");
            }
            else
            {
                ShowDebugLogWindow(owner);
                LoggerService.LogInfo("ToggleDebugLogWindow: Shown LogView.");
            }
        }
        catch (Exception ex)
        {
            LoggerService.LogError("ToggleDebugLogWindow Error", ex);
        }
    }

    public static void ShowDebugLogWindow(System.Windows.Window? owner = null)
    {
        try
        {
            var app = System.Windows.Application.Current;
            var dispatcher = app?.Dispatcher ?? System.Windows.Threading.Dispatcher.CurrentDispatcher;

            if (dispatcher != null && !dispatcher.CheckAccess())
            {
                dispatcher.BeginInvoke(new Action(() => ShowDebugLogWindow(owner)));
                return;
            }

            if (_debugLogView == null)
            {
                _debugLogView = new Views.LogView();
                if (owner != null)
                {
                    _debugLogView.Owner = owner;
                }
                _debugLogView.Closed += (s, e) => _debugLogView = null;
                _debugLogView.Show();
            }
            else
            {
                if (owner != null && _debugLogView.Owner != owner)
                {
                    try { _debugLogView.Owner = owner; } catch { }
                }
                if (!_debugLogView.IsVisible)
                {
                    _debugLogView.Show();
                }
                _debugLogView.Activate();
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"ShowDebugLogWindow Error: {ex.Message}");
        }
    }

    public static void CloseDebugLogWindow()
    {
        try
        {
            if (_debugLogView != null)
            {
                _debugLogView.AllowClose = true;
                _debugLogView.Close();
                _debugLogView = null;
            }
        }
        catch
        {
            // Ignore close errors
        }
    }
}

/// <summary>
/// Command handler for the TablePlus ribbon button when hosted inside native Revit panels via AdWindows.
/// </summary>
public class TablePlusRibbonCommandHandler : System.Windows.Input.ICommand
{
    public event EventHandler? CanExecuteChanged
    {
        add { }
        remove { }
    }

    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter)
    {
        try
        {
#pragma warning disable CS0618
            var uiApp = Nice3point.Revit.Toolkit.Context.UiApplication;
#pragma warning restore CS0618
            var uiDoc = uiApp?.ActiveUIDocument;
            var doc = uiDoc?.Document;

            if (doc == null)
            {
                TaskDialog.Show("TablePlus", "No active document found. Please open a Revit project before running TablePlus.");
                return;
            }

            if (doc.IsFamilyDocument || doc.IsReadOnly)
            {
                TaskDialog.Show("TablePlus", "TablePlus can only run in an editable Revit project (.rvt) document. Family documents (.rfa) are not supported.");
                return;
            }

            var excelService = new ExcelReaderService();
            var schemaService = new SchemaService();
            var geometryService = new TableGeometryService(schemaService);
            var registryService = new TableRegistryService(schemaService, excelService);

            var viewModel = new ViewModels.MainWindowViewModel(doc, uiDoc, registryService, geometryService, excelService, schemaService);
            var view = new Views.MainWindowView(viewModel);

            if (uiApp != null && uiApp.MainWindowHandle != IntPtr.Zero)
            {
                new System.Windows.Interop.WindowInteropHelper(view).Owner = uiApp.MainWindowHandle;
            }

            view.ShowDialog();
        }
        catch (Exception ex)
        {
            LoggerService.LogError("TablePlusRibbonCommandHandler Execute Error", ex);
        }
    }
}
