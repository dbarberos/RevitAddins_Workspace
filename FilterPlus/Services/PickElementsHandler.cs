using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using FilterPlus.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterPlus.Services;

public class PickElementsHandler : IExternalEventHandler
{
    private readonly SelectionFilterViewModel _viewModel;

    public PickElementsHandler(SelectionFilterViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    private class DummySelectionFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem) => true;
        public bool AllowReference(Reference reference, Autodesk.Revit.DB.XYZ position) => true;
    }

    public void Execute(UIApplication app)
    {
        try
        {
            var uiDoc = app.ActiveUIDocument;
            if (uiDoc == null) return;

            // Get current selection to visually highlight them during PickObjects
            var currentSelectionIds = uiDoc.Selection.GetElementIds();
            var preSelectedRefs = new List<Reference>();
            
            foreach(var id in currentSelectionIds)
            {
                var elem = uiDoc.Document.GetElement(id);
                if (elem != null)
                {
                    preSelectedRefs.Add(new Reference(elem));
                }
            }

            // Allow the user to select multiple elements, with existing selection highlighted
            IList<Reference> selectedRefs = uiDoc.Selection.PickObjects(
                ObjectType.Element, 
                new DummySelectionFilter(),
                "Selecciona elementos. Haz clic en Finalizar (arriba a la izquierda) al terminar.",
                preSelectedRefs
            );

            if (selectedRefs != null && selectedRefs.Count > 0)
            {
                List<ElementId> newIds = selectedRefs.Select(r => r.ElementId).ToList();
                _viewModel.OnPickElementsFinished(newIds);
            }
            else
            {
                // Finished with empty selection
                _viewModel.OnPickElementsFinished(new List<ElementId>());
            }
        }
        catch (Autodesk.Revit.Exceptions.OperationCanceledException)
        {
            // User pressed Escape
            LoggerService.LogInfo("PickObjects operation canceled by user.");
            _viewModel.OnPickElementsFinished(new List<ElementId>());
        }
        catch (Exception ex)
        {
            LoggerService.LogError("PickElementsHandler", ex);
            _viewModel.OnPickElementsFinished(new List<ElementId>());
        }
    }

    public string GetName() => "Pick Elements Event Handler";
}
