using Autodesk.Revit.Attributes;
using Nice3point.Revit.Toolkit.External;
using FilterPlus.Services;
using FilterPlus.ViewModels;
using FilterPlus.Views;
using JetBrains.Annotations;

namespace FilterPlus.Commands;

/// <summary>
///     External command entry point
/// </summary>
[UsedImplicitly]
[Transaction(TransactionMode.Manual)]
public class StartupCommand : ExternalCommand
{
    public override void Execute()
    {
        try
        {
            var selectionService = new RevitSelectionService(UiDocument);
            var viewModel = new SelectionFilterViewModel(selectionService);
            var view = new SelectionFilterView(viewModel);
            
            view.Show();
        }
        catch (Exception ex)
        {
            LoggerService.LogError("Startup Command", ex);
        }
    }
}