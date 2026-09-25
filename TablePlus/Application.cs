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
            CreateRibbon();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"TablePlus Ribbon Error: {ex.Message}");
        }

        try
        {
            Application.ControlledApplication.DocumentOpened += OnDocumentOpened;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"TablePlus AutoSync Hook Error: {ex.Message}");
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
                            geometryService.UpdateTableInView(doc, targetView, item.Config, cells, merges);
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
        RibbonPanel? panel = null;

        try
        {
            // Placed on Revit's standard Add-Ins (Complementos) tab,
            // strictly complying with Autodesk App Store single-tool requirements.
            panel = Application.CreatePanel("TablePlus");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"TablePlus Ribbon Panel Creation Error: {ex.Message}");
        }

        if (panel != null)
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
        }
    }
}
