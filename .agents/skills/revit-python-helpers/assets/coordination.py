# -*- coding: utf-8 -*-
"""
coordination.py
Revit/Dynamo Python Utility Library — Coordination and Levels Utilities
Compatible: IronPython 2.7 | CPython 3.x | Revit 2024-2027
"""

import clr
clr.AddReference("RevitAPI")
clr.AddReference("RevitServices")

from Autodesk.Revit.DB import FilteredElementCollector, Level, Grid, RevitLinkInstance, BuiltInCategory
from RevitServices.Persistence import DocumentManager
from RevitServices.Transactions import TransactionManager

doc = DocumentManager.Instance.CurrentDBDocument

def get_levels():
    """
    Retrieves all levels in the document sorted by elevation.

    Returns:
        List of Level elements
    """
    levels = list(FilteredElementCollector(doc).OfClass(Level).ToElements())
    return sorted(levels, key=lambda l: l.ProjectElevation)

def create_level(elevation_meters, name=None):
    """
    Creates a Level at the specified elevation.

    Args:
        elevation_meters: Elevation in meters
        name: Optional name for level

    Returns:
        Created Level element
    """
    from assets.general import meters_to_feet
    elev_feet = meters_to_feet(elevation_meters)
    TransactionManager.Instance.EnsureInTransaction(doc)
    level = Level.Create(doc, elev_feet)
    if name:
        try:
            level.Name = name
        except Exception:
            pass
    TransactionManager.Instance.TransactionTaskDone()
    return level

def create_levels_in_batch(elevations_meters, names=None):
    """
    Creates multiple levels in a single transaction.

    Args:
        elevations_meters: List of elevations in meters
        names: Optional list of level names

    Returns:
        List of created Level elements
    """
    from assets.general import meters_to_feet
    created = []
    TransactionManager.Instance.EnsureInTransaction(doc)
    for idx, elev in enumerate(elevations_meters):
        elev_feet = meters_to_feet(elev)
        level = Level.Create(doc, elev_feet)
        if names and idx < len(names):
            try:
                level.Name = names[idx]
            except Exception:
                pass
        created.append(level)
    TransactionManager.Instance.TransactionTaskDone()
    return created

def get_warnings():
    """
    Retrieves all active warnings in the document.

    Returns:
        List of FailureMessage objects
    """
    return list(doc.GetWarnings())

def analyze_warnings_by_type():
    """
    Groups warnings by their type and returns descriptive statistics.

    Returns:
        List of dicts: [{"description": text, "count": int, "failing_ids": [int]}]
    """
    warnings = get_warnings()
    groups = {}
    from assets.general import id_to_int
    
    for w in warnings:
        desc = w.GetDescriptionText()
        ids = [id_to_int(i) for i in w.GetFailingElements()]
        groups.setdefault(desc, []).extend(ids)
        
    analysis = []
    for desc, ids in groups.items():
        analysis.append({
            "description": desc,
            "count": len(ids),
            "failing_ids": sorted(list(set(ids)))
        })
    return sorted(analysis, key=lambda a: a["count"], reverse=True)

def get_linked_elements(link_instance, category_bic):
    """
    Retrieves elements of a category from a Revit Link document.

    Args:
        link_instance: RevitLinkInstance
        category_bic: BuiltInCategory

    Returns:
        Tuple (elements_list, transform) where transform is the coordinate transform of link
    """
    link_doc = link_instance.GetLinkDocument()
    if link_doc is None:
        return [], None
    col = FilteredElementCollector(link_doc).OfCategory(category_bic).WhereElementIsNotElementType()
    return list(col.ToElements()), link_instance.GetTransform()

def acquire_coordinates_from_link(link_instance):
    """
    Acquires shared coordinate system coordinates from a linked Revit document.

    Args:
        link_instance: RevitLinkInstance

    Returns:
        True if successfully acquired, False otherwise
    """
    TransactionManager.Instance.EnsureInTransaction(doc)
    try:
        doc.AcquireCoordinates(link_instance.Id)
        TransactionManager.Instance.TransactionTaskDone()
        return True
    except Exception:
        TransactionManager.Instance.TransactionTaskDone()
        return False
