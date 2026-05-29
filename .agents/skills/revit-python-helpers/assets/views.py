# -*- coding: utf-8 -*-
"""
views.py
Revit/Dynamo Python Utility Library — Graphics, Views and Sheets Utilities
Compatible: IronPython 2.7 | CPython 3.x | Revit 2024-2027
"""

import clr
clr.AddReference("RevitAPI")
clr.AddReference("RevitServices")

from Autodesk.Revit.DB import (
    FilteredElementCollector, ViewPlan, ViewFamilyType, ViewFamily, ElementId
)
from RevitServices.Persistence import DocumentManager
from RevitServices.Transactions import TransactionManager

doc = DocumentManager.Instance.CurrentDBDocument

def create_floor_plan(level, name=None):
    """
    Generates a floor plan view for the specified level.

    Args:
        level: Level element
        name: Plan view name string

    Returns:
        Created ViewPlan
    """
    col = FilteredElementCollector(doc).OfClass(ViewFamilyType)
    vt = None
    for t in col:
        if t.ViewFamily == ViewFamily.FloorPlan:
            vt = t
            break
            
    if vt is None:
        return None
        
    TransactionManager.Instance.EnsureInTransaction(doc)
    view = ViewPlan.Create(doc, vt.Id, level.Id)
    if name:
        try:
            view.Name = name
        except Exception:
            pass
    TransactionManager.Instance.TransactionTaskDone()
    return view
