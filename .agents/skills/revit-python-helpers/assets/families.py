# -*- coding: utf-8 -*-
"""
families.py
Revit/Dynamo Python Utility Library — Family Management Utilities
Compatible: IronPython 2.7 | CPython 3.x | Revit 2024-2027
"""

import clr
clr.AddReference("RevitAPI")
clr.AddReference("RevitServices")

from Autodesk.Revit.DB import IFamilyLoadOptions, FamilySource, ElementId, Structure
from RevitServices.Persistence import DocumentManager
from RevitServices.Transactions import TransactionManager

doc = DocumentManager.Instance.CurrentDBDocument

class FamilyLoadOptions(IFamilyLoadOptions):
    def OnFamilyFound(self, familyInUse, overwriteParameterValues):
        overwriteParameterValues = True
        return True
    def OnSharedFamilyFound(self, sharedFamily, familyInUse, source, overwriteParameterValues):
        overwriteParameterValues = True
        return True

def load_family(family_path):
    """
    Loads a family file into the active document safely, overwriting existing if present.

    Args:
        family_path: Full absolute path to the .rfa file

    Returns:
        Loaded Family object, or None if it fails
    """
    TransactionManager.Instance.EnsureInTransaction(doc)
    loaded = clr.Reference[Autodesk.Revit.DB.Family]()
    success = doc.LoadFamily(family_path, FamilyLoadOptions(), loaded)
    TransactionManager.Instance.TransactionTaskDone()
    return loaded.Value if success else None

def get_family_types(family):
    """
    Retrieves all available family symbols (types) of a loaded family.

    Args:
        family: Revit Family object

    Returns:
        List of FamilySymbol objects
    """
    return [doc.GetElement(i) for i in family.GetFamilySymbolIds()]

def activate_family_type(family_symbol):
    """
    Ensures a family symbol (type) is active and loaded into memory before placing.

    Args:
        family_symbol: FamilySymbol object

    Returns:
        None
    """
    if not family_symbol.IsActive:
        TransactionManager.Instance.EnsureInTransaction(doc)
        family_symbol.Activate()
        doc.Regenerate()
        TransactionManager.Instance.TransactionTaskDone()

def place_family_instance(family_symbol, point_xyz, level=None, structural=False):
    """
    Places a family instance at the specified point, level, and structural type.

    Args:
        family_symbol: Active FamilySymbol
        point_xyz: XYZ insertion point
        level: Optional Level object
        structural: True to place as structural framing, False otherwise

    Returns:
        Placed FamilyInstance element
    """
    activate_family_type(family_symbol)
    struct_type = (Structure.StructuralType.Column if structural else Structure.StructuralType.NonStructural)
    
    TransactionManager.Instance.EnsureInTransaction(doc)
    if level is not None:
        instance = doc.Create.NewFamilyInstance(point_xyz, family_symbol, level, struct_type)
    else:
        instance = doc.Create.NewFamilyInstance(point_xyz, family_symbol, struct_type)
    TransactionManager.Instance.TransactionTaskDone()
    return instance

def get_family_parameters(family):
    """
    Retrieves list of parameter names defined within a Family object.

    Args:
        family: Revit Family object

    Returns:
        List of strings containing family parameter names
    """
    names = []
    family_doc = doc.EditFamily(family)
    if family_doc:
        for param in family_doc.FamilyManager.Parameters:
            names.append(param.Definition.Name)
        family_doc.Close(False)
    return names
