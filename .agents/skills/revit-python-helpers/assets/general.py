# -*- coding: utf-8 -*-
"""
general.py
Revit/Dynamo Python Utility Library — General Utilities
Compatible: IronPython 2.7 | CPython 3.x | Revit 2024-2027
"""

import clr
import sys

# ── Python 2/3 Compatibility ────────────────────────────────────────────────
PY3 = sys.version_info[0] >= 3
if PY3:
    string_types = (str,)
    text_type = str
else:
    string_types = (str, unicode)  # noqa: F821
    text_type = unicode            # noqa: F821

# ── Revit API ────────────────────────────────────────────────────────────────
clr.AddReference("RevitAPI")
clr.AddReference("RevitAPIUI")
clr.AddReference("RevitServices")
clr.AddReference("RevitNodes")

from Autodesk.Revit.DB import (  # noqa: E402
    FilteredElementCollector, StorageType, ElementId,
    ElementTransformUtils, UnitUtils, UnitTypeId,
    BoundingBoxIntersectsFilter, BoundingBoxIsInsideFilter,
    BoundingBoxContainsPointFilter, Outline,
    LogicalOrFilter, LogicalAndFilter, ExclusionFilter,
    ElementOwnerViewFilter, ElementFilter,
    Group, AssemblyInstance,
    ReferencePlane, Grid, Line, XYZ
)
from RevitServices.Persistence import DocumentManager  # noqa: E402
from RevitServices.Transactions import TransactionManager  # noqa: E402

import Revit  # noqa: E402
clr.ImportExtensions(Revit.Elements)

doc = DocumentManager.Instance.CurrentDBDocument
uiapp = DocumentManager.Instance.CurrentUIApplication
app = uiapp.Application
uidoc = uiapp.ActiveUIDocument

REVIT_VERSION = int(app.VersionNumber) if app else 0


def unwrap(element):
    """
    Unwraps a Dynamo element to get the underlying native Revit element.

    Args:
        element: Dynamo element or native Revit element

    Returns:
        native Revit element
    """
    try:
        return element.InternalElement
    except AttributeError:
        try:
            return UnwrapElement(element)  # noqa: F821
        except Exception:
            return element


def unwrap_list(elements):
    """
    Unwraps a list of Dynamo elements to native Revit elements.

    Args:
        elements: List of Dynamo or native Revit elements

    Returns:
        List of native Revit elements
    """
    return [unwrap(e) for e in elements]


def id_to_int(element_id):
    """
    Converts a Revit ElementId to an integer in a version-safe manner.

    Args:
        element_id: Revit ElementId object

    Returns:
        Integer representation of the ElementId
    """
    try:
        return int(element_id.Value)       # Revit 2024+ (Int64)
    except AttributeError:
        return element_id.IntegerValue     # Revit <= 2023


def start_transaction(name="Transaction"):
    """
    Starts or resumes the active Dynamo transaction.

    Args:
        name: Descript name for the transaction

    Returns:
        None
    """
    TransactionManager.Instance.EnsureInTransaction(doc)


def end_transaction():
    """
    Marks the active Dynamo transaction task as completed.

    Returns:
        None
    """
    TransactionManager.Instance.TransactionTaskDone()


def get_parameter_value(element, param_name):
    """
    Reads the value of an instance parameter by name safely.

    Args:
        element: Revit element
        param_name: Parameter name as a string

    Returns:
        Parameter value (str, int, float, or ElementId) or None if it doesn't exist
    """
    param = element.LookupParameter(param_name)
    if param is None:
        return None
    t = param.StorageType
    if t == StorageType.String:
        return param.AsString()
    elif t == StorageType.Integer:
        return param.AsInteger()
    elif t == StorageType.Double:
        return param.AsDouble()
    elif t == StorageType.ElementId:
        return param.AsElementId()
    return None


def set_parameter_value(element, param_name, value):
    """
    Writes a value to an instance parameter by name.
    Requires an active transaction.

    Args:
        element: Revit element
        param_name: Parameter name as a string
        value: Value to assign (must be compatible with StorageType)

    Returns:
        True if successfully written, False otherwise
    """
    param = element.LookupParameter(param_name)
    if param is None or param.IsReadOnly:
        return False
    t = param.StorageType
    try:
        if t == StorageType.String:
            param.Set(str(value))
        elif t == StorageType.Integer:
            param.Set(int(value))
        elif t == StorageType.Double:
            param.Set(float(value))
        elif t == StorageType.ElementId:
            param.Set(value)
        return True
    except Exception:
        return False


def get_all_parameters(element):
    """
    Returns all parameters of an element as a dictionary {name: value}.

    Args:
        element: Revit element

    Returns:
        Dictionary of {parameter_name: value}
    """
    result = {}
    for param in element.Parameters:
        name = param.Definition.Name
        try:
            t = param.StorageType
            if t == StorageType.String:
                result[name] = param.AsString()
            elif t == StorageType.Integer:
                result[name] = param.AsInteger()
            elif t == StorageType.Double:
                result[name] = param.AsDouble()
            elif t == StorageType.ElementId:
                result[name] = id_to_int(param.AsElementId())
        except Exception:
            result[name] = None
    return result


def feet_to_meters(val_feet):
    """
    Converts Revit internal feet to meters.

    Args:
        val_feet: Numeric value in internal feet

    Returns:
        Value in meters (float)
    """
    return UnitUtils.ConvertFromInternalUnits(val_feet, UnitTypeId.Meters)


def meters_to_feet(val_meters):
    """
    Converts meters to Revit internal feet.

    Args:
        val_meters: Numeric value in meters

    Returns:
        Value in internal feet (float)
    """
    return UnitUtils.ConvertToInternalUnits(val_meters, UnitTypeId.Meters)


def mm_to_feet(val_mm):
    """
    Converts millimeters to Revit internal feet.

    Args:
        val_mm: Numeric value in millimeters

    Returns:
        Value in internal feet (float)
    """
    return UnitUtils.ConvertToInternalUnits(val_mm, UnitTypeId.Millimeters)


def feet_to_mm(val_feet):
    """
    Converts Revit internal feet to millimeters.

    Args:
        val_feet: Numeric value in internal feet

    Returns:
        Value in millimeters (float)
    """
    return UnitUtils.ConvertFromInternalUnits(val_feet, UnitTypeId.Millimeters)


def sqm_to_sqft(val_sqm):
    """
    Converts square meters to Revit internal square feet.

    Args:
        val_sqm: Numeric value in square meters

    Returns:
        Value in internal square feet (float)
    """
    return UnitUtils.ConvertToInternalUnits(val_sqm, UnitTypeId.SquareMeters)


def sqft_to_sqm(val_sqft):
    """
    Converts Revit internal square feet to square meters.

    Args:
        val_sqft: Numeric value in internal square feet

    Returns:
        Value in square meters (float)
    """
    return UnitUtils.ConvertFromInternalUnits(val_sqft, UnitTypeId.SquareMeters)


def copy_element(element, vector_xyz):
    """
    Copies a Revit element offset by the specified vector.

    Args:
        element: Revit element to copy
        vector_xyz: XYZ displacement vector in internal feet

    Returns:
        Copied Revit element, or None if it fails
    """
    TransactionManager.Instance.EnsureInTransaction(doc)
    new_ids = ElementTransformUtils.CopyElement(doc, element.Id, vector_xyz)
    TransactionManager.Instance.TransactionTaskDone()
    return doc.GetElement(list(new_ids)[0]) if new_ids else None


def move_element(element, vector_xyz):
    """
    Moves a Revit element by the specified vector.

    Args:
        element: Revit element to move
        vector_xyz: XYZ displacement vector in internal feet

    Returns:
        None
    """
    TransactionManager.Instance.EnsureInTransaction(doc)
    ElementTransformUtils.MoveElement(doc, element.Id, vector_xyz)
    TransactionManager.Instance.TransactionTaskDone()


def delete_element(element):
    """
    Deletes an element from the document.

    Args:
        element: Revit element to delete

    Returns:
        ElementId of the deleted element
    """
    eid = element.Id
    TransactionManager.Instance.EnsureInTransaction(doc)
    doc.Delete(eid)
    TransactionManager.Instance.TransactionTaskDone()
    return eid


def group_by_parameter(elements, param_name):
    """
    Groups elements by the value of an instance parameter.

    Args:
        elements: List of Revit elements
        param_name: Parameter name as a string

    Returns:
        Dict {parameter_value: [elements]}
    """
    groups = {}
    for e in elements:
        val = get_parameter_value(e, param_name)
        key = str(val) if val is not None else "No value"
        groups.setdefault(key, []).append(e)
    return groups


def get_int_ids(elements):
    """
    Returns a list of integer IDs for the given elements.

    Args:
        elements: List of Revit elements

    Returns:
        List of integers containing the element IDs
    """
    return [id_to_int(e.Id) for e in elements]


def filter_by_parameter_value(category_bic, param_name, value):
    """
    Collects elements of a category and filters them by an instance parameter value.
    The comparison is done as a string for compatibility across storage types.

    Args:
        category_bic: Revit BuiltInCategory
        param_name: Parameter name as a string
        value: Value to match

    Returns:
        List of matching Revit elements
    """
    elements = list(
        FilteredElementCollector(doc)
        .OfCategory(category_bic)
        .WhereElementIsNotElementType()
        .ToElements()
    )
    val_str = str(value)
    return [
        e for e in elements
        if str(get_parameter_value(e, param_name)) == val_str
    ]


def flatten_list(nested_list):
    """
    Recursively flattens a nested list of any depth.

    Args:
        nested_list: Potentially nested list or tuple

    Returns:
        Flat list containing all elements in order
    """
    result = []
    for item in nested_list:
        if isinstance(item, (list, tuple)):
            result.extend(flatten_list(item))
        else:
            result.append(item)
    return result


def get_type_parameters(element):
    """
    Returns type parameters of an element as a dict {name: value}.

    Args:
        element: Revit element

    Returns:
        Dict of type {parameter_name: value}, or empty dict if it has no type
    """
    el_type = doc.GetElement(element.GetTypeId())
    if el_type is None:
        return {}
    result = {}
    for param in el_type.Parameters:
        name = param.Definition.Name
        try:
            t = param.StorageType
            if t == StorageType.String:
                result[name] = param.AsString()
            elif t == StorageType.Integer:
                result[name] = param.AsInteger()
            elif t == StorageType.Double:
                result[name] = param.AsDouble()
            elif t == StorageType.ElementId:
                result[name] = id_to_int(param.AsElementId())
        except Exception:
            result[name] = None
    return result


def filter_by_boundingbox(bbox_xyz, category_bic=None, tolerance_m=0.0):
    """
    Finds elements whose bounding box intersects the given bounding box.
    Uses BoundingBoxIntersectsFilter (fast filter).

    Args:
        bbox_xyz: Revit BoundingBoxXYZ defining search zone
        category_bic: Optional BuiltInCategory to limit results
        tolerance_m: Additional margin in meters

    Returns:
        List of intersecting Revit elements
    """
    tol = UnitUtils.ConvertToInternalUnits(tolerance_m, UnitTypeId.Meters)
    outline = Outline(bbox_xyz.Min, bbox_xyz.Max)
    fltr = BoundingBoxIntersectsFilter(outline, tol)
    col = FilteredElementCollector(doc).WherePasses(fltr)
    if category_bic is not None:
        col = col.OfCategory(category_bic)
    return list(col.WhereElementIsNotElementType().ToElements())


def filter_inside_bbox(bbox_xyz, category_bic=None, tolerance_m=0.0):
    """
    Finds elements whose bounding boxes are completely inside the given box.
    Uses BoundingBoxIsInsideFilter.

    Args:
        bbox_xyz: Revit BoundingBoxXYZ defining zone
        category_bic: Optional BuiltInCategory
        tolerance_m: Tolerance margin in meters

    Returns:
        List of contained Revit elements
    """
    tol = UnitUtils.ConvertToInternalUnits(tolerance_m, UnitTypeId.Meters)
    outline = Outline(bbox_xyz.Min, bbox_xyz.Max)
    fltr = BoundingBoxIsInsideFilter(outline, tol)
    col = FilteredElementCollector(doc).WherePasses(fltr)
    if category_bic is not None:
        col = col.OfCategory(category_bic)
    return list(col.WhereElementIsNotElementType().ToElements())


def filter_contains_point(point_xyz, category_bic=None, tolerance_m=0.0):
    """
    Finds elements whose bounding box contains the specified point.
    Uses BoundingBoxContainsPointFilter.

    Args:
        point_xyz: XYZ point
        category_bic: Optional BuiltInCategory
        tolerance_m: Tolerance margin in meters

    Returns:
        List of matching Revit elements
    """
    tol = UnitUtils.ConvertToInternalUnits(tolerance_m, UnitTypeId.Meters)
    fltr = BoundingBoxContainsPointFilter(point_xyz, tol)
    col = FilteredElementCollector(doc).WherePasses(fltr)
    if category_bic is not None:
        col = col.OfCategory(category_bic)
    return list(col.WhereElementIsNotElementType().ToElements())


def combine_filters_or(filters):
    """
    Combines a list of ElementFilters with Logical OR.

    Args:
        filters: List of Revit ElementFilters

    Returns:
        LogicalOrFilter
    """
    from System.Collections.Generic import List as NetList  # noqa: E402
    net_list = NetList[ElementFilter](filters)
    return LogicalOrFilter(net_list)


def combine_filters_and(filters):
    """
    Combines a list of ElementFilters with Logical AND.

    Args:
        filters: List of Revit ElementFilters

    Returns:
        LogicalAndFilter
    """
    from System.Collections.Generic import List as NetList  # noqa: E402
    net_list = NetList[ElementFilter](filters)
    return LogicalAndFilter(net_list)


def exclude_elements(exclude_ids, category_bic=None):
    """
    Collects elements from the document excluding the given IDs.
    Uses ExclusionFilter.

    Args:
        exclude_ids: List of ElementIds to exclude
        category_bic: Optional BuiltInCategory

    Returns:
        List of Revit elements
    """
    from System.Collections.Generic import List as NetList  # noqa: E402
    net_list = NetList[ElementId](exclude_ids)
    fltr = ExclusionFilter(net_list)
    col = FilteredElementCollector(doc).WherePasses(fltr)
    if category_bic is not None:
        col = col.OfCategory(category_bic)
    return list(col.WhereElementIsNotElementType().ToElements())


def get_annotations_in_view(view, category_bic=None):
    """
    Retrieves view-specific elements (annotations, tags, detail lines) in the view.
    Uses ElementOwnerViewFilter.

    Args:
        view: Revit View
        category_bic: Optional BuiltInCategory

    Returns:
        List of view-specific elements
    """
    fltr = ElementOwnerViewFilter(view.Id)
    col = FilteredElementCollector(doc).WherePasses(fltr)
    if category_bic is not None:
        col = col.OfCategory(category_bic)
    return list(col.ToElements())


def get_visible_elements_in_view(view, category_bic=None):
    """
    Retrieves model elements visible in the specified view.

    Args:
        view: Revit View
        category_bic: Optional BuiltInCategory

    Returns:
        List of visible Revit elements
    """
    col = FilteredElementCollector(doc, view.Id)
    if category_bic is not None:
        col = col.OfCategory(category_bic)
    return list(col.WhereElementIsNotElementType().ToElements())


def create_group(elements):
    """
    Creates a GroupType and places a Group instance containing elements.

    Args:
        elements: List of Revit elements to group

    Returns:
        Created Group instance
    """
    from System.Collections.Generic import List as NetList  # noqa: E402
    ids = NetList[ElementId]([e.Id for e in elements])
    TransactionManager.Instance.EnsureInTransaction(doc)
    group = doc.Create.NewGroup(ids)
    TransactionManager.Instance.TransactionTaskDone()
    return group


def ungroup(group):
    """
    Ungroups a Group and returns the ElementIds of members.

    Args:
        group: Revit Group

    Returns:
        List of ElementIds of ungrouped elements
    """
    TransactionManager.Instance.EnsureInTransaction(doc)
    ids = list(group.UngroupMembers())
    TransactionManager.Instance.TransactionTaskDone()
    return ids


def get_group_members(group):
    """
    Retrieves members of a Group without ungrouping it.

    Args:
        group: Revit Group

    Returns:
        List of Revit elements
    """
    return [doc.GetElement(i) for i in group.GetMemberIds()]


def get_groups():
    """
    Retrieves all Group instances in the document.

    Returns:
        List of Group instances
    """
    return list(FilteredElementCollector(doc).OfClass(Group).ToElements())


def create_assembly(elements, name=None):
    """
    Creates an AssemblyInstance from a list of elements.

    Args:
        elements: List of Revit elements to assemble
        name: Optional name for the assembly

    Returns:
        Created AssemblyInstance, or None if it fails
    """
    from System.Collections.Generic import List as NetList  # noqa: E402
    ids = NetList[ElementId]([e.Id for e in elements])
    TransactionManager.Instance.EnsureInTransaction(doc)
    try:
        cat_id = elements[0].Category.Id
        assembly = AssemblyInstance.Create(doc, ids, cat_id)
        if name:
            if AssemblyInstance.IsAssemblyNameUnique(doc, name):
                assembly.AssemblyTypeName = name
        TransactionManager.Instance.TransactionTaskDone()
        return assembly
    except Exception:
        TransactionManager.Instance.TransactionTaskDone()
        return None


def get_assembly_members(assembly):
    """
    Retrieves members of an AssemblyInstance.

    Args:
        assembly: Revit AssemblyInstance

    Returns:
        List of Revit elements
    """
    return [doc.GetElement(i) for i in assembly.GetMemberIds()]


def create_reference_plane(point1_xyz, point2_xyz, name=None):
    """
    Creates a ReferencePlane between two points in the active view.

    Args:
        point1_xyz: XYZ first definition point
        point2_xyz: XYZ second definition point
        name: Optional name of reference plane

    Returns:
        Created ReferencePlane
    """
    TransactionManager.Instance.EnsureInTransaction(doc)
    ref_plane = doc.Create.NewReferencePlane(
        point1_xyz, point2_xyz, XYZ(0, 0, 1), doc.ActiveView
    )
    if name:
        try:
            ref_plane.Name = name
        except Exception:
            pass
    TransactionManager.Instance.TransactionTaskDone()
    return ref_plane


def create_grid(point1_xyz, point2_xyz, name=None):
    """
    Creates a Grid line between two points.

    Args:
        point1_xyz: XYZ start point of the grid line
        point2_xyz: XYZ end point of the grid line
        name: Optional name for the grid line

    Returns:
        Created Grid
    """
    line = Line.CreateBound(point1_xyz, point2_xyz)
    TransactionManager.Instance.EnsureInTransaction(doc)
    grid = Grid.Create(doc, line)
    if name:
        try:
            grid.Name = name
        except Exception:
            pass
    TransactionManager.Instance.TransactionTaskDone()
    return grid


def get_grids():
    """
    Retrieves all Grid instances in the document.

    Returns:
        List of Grid instances
    """
    return list(FilteredElementCollector(doc).OfClass(Grid).ToElements())


def get_reference_planes():
    """
    Retrieves all ReferencePlane instances in the document.

    Returns:
        List of ReferencePlane instances
    """
    return list(
        FilteredElementCollector(doc).OfClass(ReferencePlane).ToElements()
    )
