# -*- coding: utf-8 -*-
"""
architecture.py
Revit/Dynamo Python Utility Library — Architecture BIM Utilities
Compatible: IronPython 2.7 | CPython 3.x | Revit 2024-2027
"""

import clr
clr.AddReference("RevitAPI")
clr.AddReference("RevitServices")

from Autodesk.Revit.DB import (
    FilteredElementCollector, BuiltInCategory, SpatialElementBoundaryOptions,
    Room, CurveLoop, Wall, Floor, XYZ
)
from RevitServices.Persistence import DocumentManager
from RevitServices.Transactions import TransactionManager

doc = DocumentManager.Instance.CurrentDBDocument

def get_rooms():
    """
    Retrieves all rooms in the model.

    Returns:
        List of Room elements
    """
    col = FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Rooms).WhereElementIsNotElementType()
    return [r for r in col if isinstance(r, Room)]

def get_room_boundary_curves(room):
    """
    Extracts boundary geometry curves of a room.

    Args:
        room: Revit Room object

    Returns:
        List of Curve objects
    """
    opts = SpatialElementBoundaryOptions()
    segments = room.GetBoundarySegments(opts)
    curves = []
    if segments:
        for loop in segments:
            for seg in loop:
                curves.append(seg.GetCurve())
    return curves

def create_floor_from_room(room, floor_type, level):
    """
    Generates a Floor element matching the boundaries of a Room.

    Args:
        room: Revit Room object
        floor_type: FloorType object
        level: Level object

    Returns:
        Created Floor element
    """
    opts = SpatialElementBoundaryOptions()
    segments = room.GetBoundarySegments(opts)
    if not segments:
        return None
        
    # Build curve loops
    loops = []
    for seg_loop in segments:
        loop = CurveLoop()
        for seg in seg_loop:
            loop.Append(seg.GetCurve())
        loops.append(loop)
        
    from System.Collections.Generic import List
    loops_net = List[CurveLoop](loops)
    
    TransactionManager.Instance.EnsureInTransaction(doc)
    floor = Floor.Create(doc, loops_net, floor_type.Id, level.Id)
    TransactionManager.Instance.TransactionTaskDone()
    return floor
