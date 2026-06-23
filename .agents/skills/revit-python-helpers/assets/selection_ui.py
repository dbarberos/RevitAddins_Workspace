# -*- coding: utf-8 -*-
"""
selection_ui.py
Revit/Dynamo Python Utility Library — Interactive Selection UI Utilities
Compatible: IronPython 2.7 | CPython 3.x | Revit 2024-2027
"""

import clr
clr.AddReference("RevitAPI")
clr.AddReference("RevitAPIUI")
clr.AddReference("RevitServices")

from System.Collections.Generic import List
from Autodesk.Revit.DB import ElementId
from Autodesk.Revit.UI.Selection import ObjectType as UIObjectType
from RevitServices.Persistence import DocumentManager

doc = DocumentManager.Instance.CurrentDBDocument
uiapp = DocumentManager.Instance.CurrentUIApplication

def _selection():
    return uiapp.ActiveUIDocument.Selection

def select_element(message="Select an element"):
    """
    Prompts the user to select a single element in the Revit model.

    Args:
        message: Text displayed on the Revit status bar

    Returns:
        Selected native Revit element
    """
    ref = _selection().PickObject(UIObjectType.Element, message)
    return doc.GetElement(ref.ElementId)

def select_face(message="Select a face"):
    """
    Prompts the user to select a face of a Revit element.

    Args:
        message: Text displayed on the Revit status bar

    Returns:
        Tuple (element, face) where face is the native Face GeometryObject
    """
    ref = _selection().PickObject(UIObjectType.Face, message)
    elem = doc.GetElement(ref.ElementId)
    face = elem.GetGeometryObjectFromReference(ref)
    return elem, face

def select_edge(message="Select an edge"):
    """
    Prompts the user to select an edge of a Revit element.

    Args:
        message: Text displayed on the Revit status bar

    Returns:
        Tuple (element, edge) where edge is the native Edge GeometryObject
    """
    ref = _selection().PickObject(UIObjectType.Edge, message)
    elem = doc.GetElement(ref.ElementId)
    edge = elem.GetGeometryObjectFromReference(ref)
    return elem, edge

def select_point(message="Select a point on a workplane"):
    """
    Prompts the user to select a free point on the active workplane.

    Args:
        message: Text displayed on the Revit status bar

    Returns:
        XYZ point
    """
    return _selection().PickPoint(message)

def select_point_on_element(message="Select a point on an element"):
    """
    Prompts the user to select a point on a face or curve of an element.

    Args:
        message: Text displayed on the Revit status bar

    Returns:
        Tuple (reference, XYZ) where XYZ is the global coordinates of the selected point
    """
    ref = _selection().PickObject(UIObjectType.PointOnElement, message)
    return ref, ref.GlobalPoint

def select_multiple_elements(message="Select elements"):
    """
    Allows the user to select multiple elements in the model.

    Args:
        message: Text displayed on the Revit status bar

    Returns:
        List of selected native Revit elements
    """
    refs = _selection().PickObjects(UIObjectType.Element, message)
    return [doc.GetElement(r.ElementId) for r in refs]

def select_elements_by_rectangle(message="Drag a selection rectangle"):
    """
    Allows the user to select elements by drawing a selection rectangle.

    Args:
        message: Text displayed on the Revit status bar

    Returns:
        List of selected native Revit elements
    """
    return list(_selection().PickElementsByRectangle(message))

def select_linked_element(message="Select an element in a link"):
    """
    Prompts the user to select an element inside a Revit Link instance.

    Args:
        message: Text displayed on the Revit status bar

    Returns:
        Tuple (link_instance, reference)
    """
    ref = _selection().PickObject(UIObjectType.LinkedElement, message)
    link = doc.GetElement(ref.ElementId)
    return link, ref

def get_current_selection():
    """
    Retrieves the ElementIds of currently selected elements in Revit.

    Returns:
        List of selected ElementIds
    """
    return list(_selection().GetElementIds())

def set_current_selection(ids_list):
    """
    Sets the active selection in Revit using a list of ElementIds.

    Args:
        ids_list: List of ElementIds to select

    Returns:
        None
    """
    ids = List[ElementId](ids_list)
    _selection().SetElementIds(ids)
