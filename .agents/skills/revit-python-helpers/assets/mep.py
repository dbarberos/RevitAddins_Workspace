# -*- coding: utf-8 -*-
"""
mep.py
Revit/Dynamo Python Utility Library — MEP and System Utilities
Compatible: IronPython 2.7 | CPython 3.x | Revit 2024-2027
"""

import clr
clr.AddReference("RevitAPI")
clr.AddReference("RevitServices")

from Autodesk.Revit.DB import (
    FilteredElementCollector, BuiltInCategory, ElementId, XYZ
)
from Autodesk.Revit.DB.Plumbing import Pipe
from Autodesk.Revit.DB.Mechanical import Duct
from RevitServices.Persistence import DocumentManager
from RevitServices.Transactions import TransactionManager

doc = DocumentManager.Instance.CurrentDBDocument

def get_connected_elements(mep_element):
    """
    Retrieves all connected MEP elements physically attached to the specified element.

    Args:
        mep_element: MEP curve or equipment

    Returns:
        List of connected Revit elements
    """
    connected = []
    conn_manager = None
    try:
        conn_manager = mep_element.ConnectorManager
    except AttributeError:
        try:
            conn_manager = mep_element.MEPModel.ConnectorManager
        except AttributeError:
            pass
            
    if conn_manager:
        for conn in conn_manager.Connectors:
            for ref_conn in conn.AllRefs:
                owner = ref_conn.Owner
                if owner.Id != mep_element.Id:
                    connected.append(owner)
    return connected
