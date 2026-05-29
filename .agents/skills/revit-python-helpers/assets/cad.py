# -*- coding: utf-8 -*-
"""
cad.py
Revit/Dynamo Python Utility Library — CAD (DWG/DXF) Integration Utilities
Compatible: IronPython 2.7 | CPython 3.x | Revit 2024-2027
"""

import clr
clr.AddReference("RevitAPI")
clr.AddReference("RevitServices")

from Autodesk.Revit.DB import FilteredElementCollector, ImportInstance, CADLinkType, Line, Arc, Curve
from RevitServices.Persistence import DocumentManager
from RevitServices.Transactions import TransactionManager

doc = DocumentManager.Instance.CurrentDBDocument

def classify_cad_links():
    """
    Lists and classifies all imported and linked CAD files in the document.

    Returns:
        Dict with keys:
          "imported": List of imported ImportInstances
          "linked": List of linked CAD CADLinkTypes
    """
    imports = list(FilteredElementCollector(doc).OfClass(ImportInstance).ToElements())
    links = list(FilteredElementCollector(doc).OfClass(CADLinkType).ToElements())
    
    imported_instances = [i for i in imports if not i.IsLinked]
    linked_instances = [i for i in imports if i.IsLinked]
    return {
        "imported": imported_instances,
        "linked": linked_instances,
        "types": links
    }

def get_cad_layer_names(import_instance):
    """
    Retrieves list of all layer names present in a CAD import instance.

    Args:
        import_instance: Revit ImportInstance element

    Returns:
        List of layer name strings
    """
    layers = set()
    geom_elem = import_instance.get_Geometry(Autodesk.Revit.DB.Options())
    if geom_elem:
        for obj in geom_elem:
            if isinstance(obj, Autodesk.Revit.DB.GeometryInstance):
                ins_geom = obj.GetInstanceGeometry()
                for o in ins_geom:
                    gs = o.GraphicsStyle
                    if gs:
                        layers.add(gs.GraphicsStyleCategory.Name)
    return sorted(list(layers))

def get_curves_by_layer(import_instance, layer_name):
    """
    Extracts geometric curves from a specific layer of a CAD link/import.

    Args:
        import_instance: ImportInstance element
        layer_name: Name of layer as string

    Returns:
        List of Revit Curve objects
    """
    curves = []
    geom_elem = import_instance.get_Geometry(Autodesk.Revit.DB.Options())
    if geom_elem:
        for obj in geom_elem:
            if isinstance(obj, Autodesk.Revit.DB.GeometryInstance):
                ins_geom = obj.GetInstanceGeometry()
                for o in ins_geom:
                    gs = o.GraphicsStyle
                    if gs and gs.GraphicsStyleCategory.Name == layer_name:
                        if isinstance(o, Curve):
                            curves.append(o)
    return curves

def get_cad_block_data(import_instance):
    """
    Retrieves origin and names of block instances inside a CAD file.

    Args:
        import_instance: ImportInstance element

    Returns:
        List of dicts: [{"name": name, "origin": XYZ}]
    """
    blocks = []
    geom_elem = import_instance.get_Geometry(Autodesk.Revit.DB.Options())
    if geom_elem:
        for obj in geom_elem:
            if isinstance(obj, Autodesk.Revit.DB.GeometryInstance):
                # Sub-instance represents blocks
                ref_geom = obj.GetSymbolGeometry()
                if ref_geom:
                    blocks.append({
                        "name": obj.Symbol.Name,
                        "origin": obj.Transform.Origin
                    })
    return blocks

def get_cad_link_origin(import_instance):
    """
    Retrieves the origin XYZ coordinates of a CAD link/import in project space.

    Args:
        import_instance: ImportInstance element

    Returns:
        XYZ origin point
    """
    return import_instance.GetTransform().Origin

def delete_cad_link(import_instance):
    """
    Deletes a CAD link or import instance from the project.

    Args:
        import_instance: ImportInstance element to delete

    Returns:
        ElementId of deleted element
    """
    eid = import_instance.Id
    TransactionManager.Instance.EnsureInTransaction(doc)
    doc.Delete(eid)
    TransactionManager.Instance.TransactionTaskDone()
    return eid

def delete_all_cad_links():
    """
    Deletes all CAD link and import instances present in the model.

    Returns:
        Number of deleted instances
    """
    imports = list(FilteredElementCollector(doc).OfClass(ImportInstance).ToElements())
    TransactionManager.Instance.EnsureInTransaction(doc)
    count = 0
    for imp in imports:
        try:
            doc.Delete(imp.Id)
            count += 1
        except Exception:
            pass
    TransactionManager.Instance.TransactionTaskDone()
    return count
