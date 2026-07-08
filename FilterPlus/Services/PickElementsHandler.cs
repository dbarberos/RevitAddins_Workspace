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

            if (selectedModels.Count == 0)
            {
                _viewModel.OnPickElementsFinished(new List<ElementSelectionKey>());
                return;
            }

            // Target flags
            bool runHost = false;
            bool runLinks = false;

            if (hasHost && hasLinks)
            {
                // Prompt user to choose target selection mode
                var dialog = new TaskDialog("FilterPlus - Selection Mode")
                {
                    MainInstruction = "Choose selection target",
                    MainContent = "Revit does not support picking host and linked elements simultaneously. Choose your selection target:",
                    AllowCancellation = true
                };

                dialog.AddCommandLink(TaskDialogCommandLinkId.CommandLink1, "Host Model Only", "Select elements from the active document.");
                dialog.AddCommandLink(TaskDialogCommandLinkId.CommandLink2, "Linked Models Only", "Select elements inside link instances.");
                dialog.AddCommandLink(TaskDialogCommandLinkId.CommandLink3, "Both (Sequential)", "Select host elements first, then select linked elements.");

                var result = dialog.Show();

                if (result == TaskDialogResult.CommandLink1)
                {
                    runHost = true;
                }
                else if (result == TaskDialogResult.CommandLink2)
                {
                    runLinks = true;
                }
                else if (result == TaskDialogResult.CommandLink3)
                {
                    runHost = true;
                    runLinks = true;
                }
                else
                {
                    // User canceled the choice dialog
                    _viewModel.OnPickElementsFinished(new List<ElementSelectionKey>());
                    return;
                }
            }
            else if (hasHost)
            {
                runHost = true;
            }
            else if (hasLinks)
            {
                runLinks = true;
            }

            // Get checked keys for preselection
            var checkedKeys = new List<ElementSelectionKey>();
            foreach (var node in _viewModel.RootNodes)
            {
                node.GetAllSelectedKeys(checkedKeys);
            }

            var finalKeys = new List<ElementSelectionKey>();

            // 1. Run Host Selection
            if (runHost)
            {
                var preSelectedHostRefs = new List<Reference>();
                foreach (var key in checkedKeys.Where(k => k.LinkInstanceId == ElementId.InvalidElementId))
                {
                    var elem = uiDoc.Document.GetElement(key.ElementId);
                    if (elem != null)
                    {
                        preSelectedHostRefs.Add(new Reference(elem));
                    }
                }

                try
                {
                    IList<Reference> selectedHostRefs = uiDoc.Selection.PickObjects(
                        ObjectType.Element,
                        new DummySelectionFilter(),
                        "Select elements in the Host Model only (active document). Click Finish (top-left) when done.",
                        preSelectedHostRefs
                    );

                    if (selectedHostRefs != null)
                    {
                        foreach (var r in selectedHostRefs)
                        {
                            var hostEl = uiDoc.Document.GetElement(r.ElementId);
                            if (hostEl is RevitLinkInstance rli)
                            {
                                if (selectedModels.Any(m => m.LinkInstance != null && m.LinkInstance.Id == rli.Id))
                                {
                                    finalKeys.Add(new ElementSelectionKey(r.LinkedElementId, rli.Id));
                                }
                            }
                            else
                            {
                                finalKeys.Add(new ElementSelectionKey(r.ElementId, ElementId.InvalidElementId));
                            }
                        }
                    }
                }
                catch (Autodesk.Revit.Exceptions.OperationCanceledException)
                {
                    // If user cancels during sequential or host phase, cancel the entire operation
                    _viewModel.OnPickElementsFinished(new List<ElementSelectionKey>());
                    return;
                }
            }

            // 2. Run Links Selection
            if (runLinks)
            {
                var preSelectedLinkRefs = new List<Reference>();
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
                                    preSelectedLinkRefs.Add(hostRef);
                                }
                                catch
                                {
                                    // Ignore reference errors
                                }
                            }
                        }
                    }
                }

                try
                {
                    IList<Reference> selectedLinkRefs = uiDoc.Selection.PickObjects(
                        ObjectType.LinkedElement,
                        new DummySelectionFilter(),
                        "Select elements in Linked Models only (use TAB to highlight). Click Finish (top-left) when done.",
                        preSelectedLinkRefs
                    );

                    if (selectedLinkRefs != null)
                    {
                        foreach (var r in selectedLinkRefs)
                        {
                            finalKeys.Add(new ElementSelectionKey(r.LinkedElementId, r.ElementId));
                        }
                    }
                }
                catch (Autodesk.Revit.Exceptions.OperationCanceledException)
                {
                    // If user cancels linked phase, finish with whatever was gathered (e.g. from host phase)
                }
            }

            _viewModel.OnPickElementsFinished(finalKeys);
        }
        catch (Autodesk.Revit.Exceptions.OperationCanceledException)
        {
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
