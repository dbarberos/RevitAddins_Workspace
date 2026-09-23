using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using JetBrains.Annotations;
using Nice3point.Revit.Toolkit.External;
using TablePlus.Services;
using TablePlus.ViewModels;
using TablePlus.Views;

namespace TablePlus.Commands;

/// <summary>
/// External command entry point for TablePlus Master Dashboard.
/// Runs in the Revit API context to initialize services, configure the ViewModel,
/// and display the modal dashboard window.
/// </summary>
[UsedImplicitly]
[Transaction(TransactionMode.Manual)]
public class CmdImportTable : ExternalCommand
{
    public override void Execute()
    {
        var uiDoc = Application.ActiveUIDocument;
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

        try
        {
            // Instantiate decoupled services
            var excelService = new ExcelReaderService();
            var schemaService = new SchemaService();
            var geometryService = new TableGeometryService(schemaService);
            var registryService = new TableRegistryService(schemaService, excelService);

            // Instantiate ViewModel and display master dashboard
            var viewModel = new MainWindowViewModel(doc, uiDoc, registryService, geometryService, excelService, schemaService);
            var view = new MainWindowView(viewModel);

            view.ShowDialog();
        }
        catch (Exception ex)
        {
            TaskDialog.Show("TablePlus Error", $"An unexpected error occurred while launching TablePlus: {ex.Message}");
        }
    }
}
