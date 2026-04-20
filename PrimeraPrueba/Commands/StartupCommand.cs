using Autodesk.Revit.Attributes;
using Nice3point.Revit.Toolkit.External;
using PrimeraPrueba.Services;
using PrimeraPrueba.ViewModels;
using PrimeraPrueba.Views;
using JetBrains.Annotations;

namespace PrimeraPrueba.Commands;

/// <summary>
///     External command entry point
/// </summary>
[UsedImplicitly]
[Transaction(TransactionMode.Manual)]
public class StartupCommand : ExternalCommand
{
    public override void Execute()
    {
        var selectionService = new RevitSelectionService(UiDocument);
        var viewModel = new SelectionFilterViewModel(selectionService);
        var view = new SelectionFilterView(viewModel);
        
        view.Show();
    }
}