using Autodesk.Revit.UI;
using JetBrains.Annotations;
using Nice3point.Revit.Extensions;
using Nice3point.Revit.Toolkit.External;
using TablePlus.Commands;

namespace TablePlus;

/// <summary>
/// Application entry point for TablePlus.
/// Configures Revit Ribbon tab, panels, pushbuttons, and registers the dynamic assembly resolver.
/// </summary>
[UsedImplicitly]
public class Application : ExternalApplication
{
    public override void OnStartup()
    {
        AppDomain.CurrentDomain.AssemblyResolve += OnAssemblyResolve;
        CreateRibbon();
    }

    public override void OnShutdown()
    {
        AppDomain.CurrentDomain.AssemblyResolve -= OnAssemblyResolve;
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
            // Prefer dedicated company tab "DBDev Tools"
            panel = Application.CreatePanel("Tables", "DBDev Tools");
        }
        catch
        {
            try
            {
                // Fallback to standard "Add-Ins" tab
                panel = Application.CreatePanel("Tables");
            }
            catch
            {
                // Ribbon creation failed
            }
        }

        if (panel != null)
        {
            var button = panel.AddPushButton<CmdImportTable>("Import\nExcel");
            button.SetImage("/TablePlus;component/Resources/Icons/RibbonIcon16.png");
            button.SetLargeImage("/TablePlus;component/Resources/Icons/RibbonIcon32.png");
            button.ToolTip = "TablePlus — Import Excel Spreadsheet";
            button.LongDescription = "Import Excel spreadsheets (.xlsx, .xls, .csv) into native Revit Drafting Views or Legend Views as editable 2D vector tables with cell fills, borders, and text formatting.";
        }
    }
}
