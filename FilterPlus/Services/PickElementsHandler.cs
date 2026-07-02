using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using FilterPlus.ViewModels;
using FilterPlus.Models;
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

            // Get pre-selected references to visually highlight them during PickObjects
            var preSelectedRefs = new List<Reference>();
            var linkInstance = _viewModel.SelectedModel?.LinkInstance;

            if (linkInstance == null)
            {
                var currentSelectionIds = uiDoc.Selection.GetElementIds();
                foreach (var id in currentSelectionIds)
                {
                    var elem = uiDoc.Document.GetElement(id);
                    if (elem != null)
                    {
                        preSelectedRefs.Add(new Reference(elem));
                    }
                }
            }
            else
            {
                var checkedKeys = new List<ElementSelectionKey>();
                foreach (var node in _viewModel.RootNodes)
                {
                    node.GetAllSelectedKeys(checkedKeys);
                }

                var linkedDoc = linkInstance.GetLinkDocument();
                if (linkedDoc != null)
                {
                    foreach (var key in checkedKeys)
                    {
                        var elem = linkedDoc.GetElement(key.ElementId);
                        if (elem != null)
                        {
                            try
                            {
                                var refInLink = new Reference(elem);
                                var hostRef = refInLink.CreateLinkReference(linkInstance);
                                preSelectedRefs.Add(hostRef);
                            }
                            catch
                            {
                                // Ignore reference errors
                            }
                        }
                    }
                }
            }

            ObjectType pickType = (linkInstance == null) ? ObjectType.Element : ObjectType.LinkedElement;
            bool isAllModels = _viewModel.SelectedModel?.DisplayName == "All Models";
            if (isAllModels)
            {
                pickType = ObjectType.Element; // Fallback to picking host elements for All Models context
            }

            // Allow the user to select multiple elements, with existing selection highlighted
            IList<Reference> selectedRefs = uiDoc.Selection.PickObjects(
                pickType, 
                new DummySelectionFilter(),
                "Selecciona elementos. Haz clic en Finalizar (arriba a la izquierda) al terminar.",
                preSelectedRefs
            );

            if (selectedRefs != null && selectedRefs.Count > 0)
            {
                var newKeys = new List<ElementSelectionKey>();
                if (isAllModels)
                {
                    foreach (var r in selectedRefs)
                    {
                        var hostEl = uiDoc.Document.GetElement(r.ElementId);
                        if (hostEl is RevitLinkInstance rli)
                        {
                            newKeys.Add(new ElementSelectionKey(r.LinkedElementId, rli.Id));
                        }
                        else
                        {
                            newKeys.Add(new ElementSelectionKey(r.ElementId, ElementId.InvalidElementId));
                        }
                    }
                }
                else if (linkInstance == null)
                {
                    newKeys = selectedRefs.Select(r => new ElementSelectionKey(r.ElementId, ElementId.InvalidElementId)).ToList();
                }
                else
                {
                    newKeys = selectedRefs
                        .Where(r => r.ElementId == linkInstance.Id)
                        .Select(r => new ElementSelectionKey(r.LinkedElementId, linkInstance.Id))
                        .ToList();
                }
                _viewModel.OnPickElementsFinished(newKeys);
            }
            else
            {
                // Finished with empty selection
                _viewModel.OnPickElementsFinished(new List<ElementSelectionKey>());
            }
        }
        catch (Autodesk.Revit.Exceptions.OperationCanceledException)
        {
            // User pressed Escape
            LoggerService.LogInfo("PickObjects operation canceled by user.");
            _viewModel.OnPickElementsFinished(new List<ElementSelectionKey>());
        }
        catch (Exception ex)
        {
            LoggerService.LogError("PickElementsHandler", ex);
            _viewModel.OnPickElementsFinished(new List<ElementSelectionKey>());
        }
    }

    public string GetName() => "Pick Elements Event Handler";
}
