using Autodesk.Revit.Attributes;
using Nice3point.Revit.Toolkit.External;
using FilterPlus.Services;
using FilterPlus.ViewModels;
using FilterPlus.Views;
using JetBrains.Annotations;

namespace FilterPlus.Commands;

/// <summary>
///     External command entry point. Runs in Revit API context – safe to call Revit API here.
/// </summary>
[UsedImplicitly]
[Transaction(TransactionMode.Manual)]
public class StartupCommand : ExternalCommand
{
    public override void Execute()
    {
        try
        {
            // Register dispatcher for logging as early as possible
            LoggerService.SetDispatcher(System.Windows.Threading.Dispatcher.CurrentDispatcher);
            LoggerService.LogInfo("Addin Startup command started.");

            var selectionService = new RevitSelectionService(UiDocument);

            // ViewModel constructor pre-fetches ALL scope data here (safe: we are in Revit API thread)
            var viewModel = new SelectionFilterViewModel(selectionService);
            
            // Register external event for interactive selection
            var pickElementsHandler = new PickElementsHandler(viewModel);
            var externalEvent = Autodesk.Revit.UI.ExternalEvent.Create(pickElementsHandler);
            viewModel.SetExternalEvent(externalEvent);

            // Register generic external event for executing Actions on Revit UI thread
            var genericActionHandler = new ActionEventHandler();
            var genericExternalEvent = Autodesk.Revit.UI.ExternalEvent.Create(genericActionHandler);
            viewModel.SetActionEventHandler(genericActionHandler, genericExternalEvent);
            
            LoggerService.LogInfo("ViewModel created. Showing window...");

            var view = new SelectionFilterView(viewModel);
            view.Show();
        }
        catch (Exception ex)
        {
            LoggerService.LogError("Startup Command", ex);
        }
    }
}