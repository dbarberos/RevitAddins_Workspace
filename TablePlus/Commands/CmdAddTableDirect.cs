using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using JetBrains.Annotations;
using Nice3point.Revit.Toolkit.External;
using TablePlus.Services;
using TablePlus.ViewModels;
using TablePlus.Views;

namespace TablePlus.Commands;

/// <summary>
/// External command directly launching the "Add Linked Table" wizard.
/// Invoked from Revit 2025+ canvas context menu without needing to search or open from Ribbon.
/// </summary>
[UsedImplicitly]
[Transaction(TransactionMode.Manual)]
public class CmdAddTableDirect : ExternalCommand
{
    public override void Execute()
    {
        var uiDoc = Application.ActiveUIDocument;
        var doc = uiDoc?.Document;

        if (doc == null)
        {
            TaskDialog.Show("TablePlus", "No active document found. Please open a Revit project before creating a linked table.");
            return;
        }

        if (doc.IsFamilyDocument || doc.IsReadOnly)
        {
            TaskDialog.Show("TablePlus", "TablePlus can only run in an editable Revit project (.rvt) document. Family documents (.rfa) are not supported.");
            return;
        }

        try
        {
            LoggerService.LogInfo("CmdAddTableDirect: Opening TableImportView wizard directly from context menu...");

            var excelService = new ExcelReaderService();
            var schemaService = new SchemaService();
            var geometryService = new TableGeometryService(schemaService);

            var importVm = new TableImportViewModel(doc, excelService, geometryService, schemaService);
            var importView = new TableImportView(importVm);

            if (Application.MainWindowHandle != IntPtr.Zero)
            {
                new System.Windows.Interop.WindowInteropHelper(importView).Owner = Application.MainWindowHandle;
            }

            var result = importView.ShowDialog();
            if (result == true || importVm.CreatedView != null)
            {
                LoggerService.LogInfo($"CmdAddTableDirect: Table successfully created: '{importVm.CreatedView?.Name ?? "OK"}'");
            }
        }
        catch (Exception ex)
        {
            LoggerService.LogError("CmdAddTableDirect.Execute Error", ex);
            TaskDialog.Show("TablePlus Error", $"Failed to open Table Wizard: {ex.Message}");
        }
    }
}
