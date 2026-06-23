# -*- coding: utf-8 -*-
"""
collaborative.py
Revit/Dynamo Python Utility Library — Worksharing and Collaborative BIM Utilities
Compatible: IronPython 2.7 | CPython 3.x | Revit 2024-2027
"""

import clr
clr.AddReference("RevitAPI")
clr.AddReference("RevitServices")

from Autodesk.Revit.DB import (
    WorksharingSaveAsOptions, SaveAsOptions, SynchronizeWithCentralOptions,
    RelinquishOptions, TransactWithCentralOptions, Workset, WorksetTable, WorksetId
)
from RevitServices.Persistence import DocumentManager
from RevitServices.Transactions import TransactionManager

doc = DocumentManager.Instance.CurrentDBDocument

def enable_worksharing(default_workset_name="Workset1"):
    """
    Enables worksharing in the active document.
    Forces project to become a collaborative model with the specified default workset.

    Args:
        default_workset_name: Default workset name to create

    Returns:
        True if successfully enabled, False otherwise
    """
    if doc.IsWorkshared:
        return False
    TransactionManager.Instance.EnsureInTransaction(doc)
    try:
        doc.EnableWorksharing(default_workset_name, "Shared Levels and Grids")
        TransactionManager.Instance.TransactionTaskDone()
        return True
    except Exception:
        TransactionManager.Instance.TransactionTaskDone()
        return False

def save_as_central(file_path):
    """
    Saves a workshared document as a new central file.

    Args:
        file_path: Destination absolute file path (.rvt)

    Returns:
        True if successful, False otherwise
    """
    if not doc.IsWorkshared:
        return False
        
    s_opts = SaveAsOptions()
    w_opts = WorksharingSaveAsOptions()
    w_opts.SaveAsCentral = True
    s_opts.SetWorksharingSaveAsOptions(w_opts)
    
    TransactionManager.Instance.EnsureInTransaction(doc)
    try:
        doc.SaveAs(file_path, s_opts)
        TransactionManager.Instance.TransactionTaskDone()
        return True
    except Exception:
        TransactionManager.Instance.TransactionTaskDone()
        return False

def sync_with_central(comment="Synchronized via automation"):
    """
    Synchronizes the local model with the central model and relinquishes all ownerships.

    Args:
        comment: Synchronization log comment

    Returns:
        True if successful, False otherwise
    """
    if not doc.IsWorkshared:
        return False
        
    trans_opts = TransactWithCentralOptions()
    sync_opts = SynchronizeWithCentralOptions()
    relinq_opts = RelinquishOptions(True)
    relinq_opts.StandardWorksets = True
    relinq_opts.UserCreatedWorksets = True
    relinq_opts.ViewWorksets = True
    relinq_opts.FamilyWorksets = True
    
    sync_opts.SetRelinquishOptions(relinq_opts)
    sync_opts.Comment = comment
    
    TransactionManager.Instance.EnsureInTransaction(doc)
    try:
        doc.SynchronizeWithCentral(trans_opts, sync_opts)
        TransactionManager.Instance.TransactionTaskDone()
        return True
    except Exception:
        TransactionManager.Instance.TransactionTaskDone()
        return False

def create_workset(name):
    """
    Creates a new user-created workset in the model.

    Args:
        name: Name of workset as string

    Returns:
        Created Workset object, or None if it fails
    """
    if not doc.IsWorkshared:
        return None
    TransactionManager.Instance.EnsureInTransaction(doc)
    try:
        workset = Workset.Create(doc, name)
        TransactionManager.Instance.TransactionTaskDone()
        return workset
    except Exception:
        TransactionManager.Instance.TransactionTaskDone()
        return None

def get_worksets():
    """
    Retrieves all user-created worksets present in the document.

    Returns:
        List of Workset objects
    """
    if not doc.IsWorkshared:
        return []
    table = doc.GetWorksetTable()
    collector = Autodesk.Revit.DB.FilteredWorksetCollector(doc)
    collector.OfKind(Autodesk.Revit.DB.WorksetKind.UserWorkset)
    return list(collector)

def assign_workset_to_element(element, workset_id_int):
    """
    Assigns an element to a workset by its integer ID.

    Args:
        element: Revit element
        workset_id_int: Integer of the target WorksetId

    Returns:
        True if assigned, False otherwise
    """
    if not doc.IsWorkshared:
        return False
    param = element.get_Parameter(Autodesk.Revit.DB.BuiltInParameter.ELEM_PARTITION_PARAM)
    if param and not param.IsReadOnly:
        TransactionManager.Instance.EnsureInTransaction(doc)
        param.Set(workset_id_int)
        TransactionManager.Instance.TransactionTaskDone()
        return True
    return False

def get_element_workset(element):
    """
    Retrieves the Workset to which the element belongs.

    Args:
        element: Revit element

    Returns:
        Workset object
    """
    if not doc.IsWorkshared:
        return None
    table = doc.GetWorksetTable()
    w_id = element.WorksetId
    return table.GetWorkset(w_id)
