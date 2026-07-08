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

            var selectedModels = _viewModel.SelectedModels;
            bool hasHost = selectedModels.Any(m => m.LinkInstance == null);
            bool hasLinks = selectedModels.Any(m => m.LinkInstance != null);

            ObjectType pickType = (hasLinks && !hasHost) ? ObjectType.LinkedElement : ObjectType.Element;

            // Get pre-selected references to visually highlight them during PickObjects
            var preSelectedRefs = new List<Reference>();

            var checkedKeys = new List<ElementSelectionKey>();
            foreach (var node in _viewModel.RootNodes)
            {
                node.GetAllSelectedKeys(checkedKeys);
            }

            if (pickType == ObjectType.Element)
            {
                // Highlight host elements only (adding linked references with ObjectType.Element will throw: "pPreSelected has invalid object")
                foreach (var key in checkedKeys.Where(k => k.LinkInstanceId == ElementId.InvalidElementId))
                {
                    var elem = uiDoc.Document.GetElement(key.ElementId);
                    if (elem != null)
                    {
                        preSelectedRefs.Add(new Reference(elem));
                    }
                }
            }
            else // ObjectType.LinkedElement
            {
                // Highlight elements from selected links (adding host references with ObjectType.LinkedElement will throw)
                foreach (var model in selectedModels.Where(m => m.LinkInstance != null))
                {
                    var linkInst = model.LinkInstance;
                    var linkedDoc = linkInst.GetLinkDocument();
                    if (linkedDoc != null)
                    {
                        foreach (var key in checkedKeys.Where(k => k.LinkInstanceId == linkInst.Id))
                        {
                            var elem = linkedDoc.GetElement(key.ElementId);
                            if (elem != null)
                            {
                                try
                                {
                                    var refInLink = new Reference(elem);
                                    var hostRef = refInLink.CreateLinkReference(linkInst);
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
                if (pickType == ObjectType.LinkedElement)
                {
                    foreach (var r in selectedRefs)
                    {
                        newKeys.Add(new ElementSelectionKey(r.LinkedElementId, r.ElementId));
                    }
                }
                else
                {
                    // Multi-model (or Host only) with ObjectType.Element
                    foreach (var r in selectedRefs)
                    {
                        var hostEl = uiDoc.Document.GetElement(r.ElementId);
                        if (hostEl is RevitLinkInstance rli)
                        {
                            // Verify if this link instance is in selected models
                            if (selectedModels.Any(m => m.LinkInstance != null && m.LinkInstance.Id == rli.Id))
                            {
                                newKeys.Add(new ElementSelectionKey(r.LinkedElementId, rli.Id));
                            }
                        }
                        else
                        {
                            // Verify if host model is in selected models
                            if (selectedModels.Any(m => m.LinkInstance == null))
                            {
                                newKeys.Add(new ElementSelectionKey(r.ElementId, ElementId.InvalidElementId));
                            }
                        }
                    }
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
