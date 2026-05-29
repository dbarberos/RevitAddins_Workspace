# -*- coding: utf-8 -*-
"""
transformations.py
Revit/Dynamo Python Utility Library — Geometric Transformations
Compatible: IronPython 2.7 | CPython 3.x | Revit 2024-2027
"""

import clr
import sys
import math

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

from System.Collections.Generic import List  # noqa: E402

from Autodesk.Revit.DB import (  # noqa: E402
    ElementId, ElementTransformUtils, Transform, Plane,
    Line, XYZ, LocationPoint, LocationCurve,
    UnitUtils, UnitTypeId
)
from Autodesk.Revit.DB.Structure import (  # noqa: E402
    StructuralFramingUtils
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


# ── Internal Helpers ──────────────────────────────────────────────────────────

def _start():
    TransactionManager.Instance.EnsureInTransaction(doc)


def _end():
    TransactionManager.Instance.TransactionTaskDone()


def _rad(degrees):
    return math.radians(degrees)


def _meters_to_feet(v):
    return UnitUtils.ConvertToInternalUnits(v, UnitTypeId.Meters)


def _feet_to_meters(v):
    return UnitUtils.ConvertFromInternalUnits(v, UnitTypeId.Meters)


# ── Location Queries ──────────────────────────────────────────────────────────

def get_location(element):
    """
    Reads the location of an element and returns a dict with its type and value.
    Centralizes logic distinguishing LocationPoint and LocationCurve.

    Args:
        element: Revit element

    Returns:
        Dict with keys:
          "type":            "point", "curve", or "unknown"
          "point":           XYZ (if LocationPoint) or None
          "curve":           Curve (if LocationCurve) or None
          "rotation_deg":    float or None
    """
    loc = element.Location
    if isinstance(loc, LocationPoint):
        rot = (math.degrees(loc.Rotation) if hasattr(loc, "Rotation") else None)
        return {
            "type": "point",
            "point": loc.Point,
            "curve": None,
            "rotation_deg": rot,
        }
    if isinstance(loc, LocationCurve):
        return {
            "type": "curve",
            "point": None,
            "curve": loc.Curve,
            "rotation_deg": None,
        }
    return {
        "type": "unknown",
        "point": None,
        "curve": None,
        "rotation_deg": None,
    }


def get_location_point(element):
    """
    Returns the location point of an element with LocationPoint.

    Args:
        element: Revit element

    Returns:
        XYZ or None if the element has no LocationPoint
    """
    loc = element.Location
    return loc.Point if isinstance(loc, LocationPoint) else None


def get_location_curve(element):
    """
    Returns the location curve of an element with LocationCurve.

    Args:
        element: Revit element

    Returns:
        Curve or None if the element has no LocationCurve
    """
    loc = element.Location
    return loc.Curve if isinstance(loc, LocationCurve) else None


def get_location_rotation(element):
    """
    Returns the current rotation in degrees of an element with LocationPoint.

    Args:
        element: Revit element

    Returns:
        float in degrees, or None if the element has no LocationPoint
    """
    loc = element.Location
    if isinstance(loc, LocationPoint) and hasattr(loc, "Rotation"):
        return math.degrees(loc.Rotation)
    return None


def get_angle_from_hand_orientation(element):
    """
    Calculates rotation angle of an element in degrees from its HandOrientation
    (angle relative to the positive X axis in plan).

    Args:
        element: FamilyInstance or element with HandOrientation

    Returns:
        float angle in degrees [0, 360), or None if not applicable
    """
    try:
        h = element.HandOrientation
        return math.degrees(math.atan2(h.Y, h.X)) % 360.0
    except AttributeError:
        return None


# ── Direct Location Modification ──────────────────────────────────────────────

def set_location_point(element, point_xyz):
    """
    Sets the location point of an element directly.
    Alternative to move_element when absolute coordinates are known.

    Args:
        element: Revit element with LocationPoint
        point_xyz: XYZ of the new absolute position

    Returns:
        True if successfully set, False if not a LocationPoint
    """
    loc = element.Location
    if not isinstance(loc, LocationPoint):
        return False
    _start()
    loc.Point = point_xyz
    _end()
    return True


def set_location_curve(element, curve):
    """
    Redefines the location curve of an element directly.
    Allows redefining length/shape of walls, beams, pipes, etc.

    Args:
        element: Revit element with LocationCurve
        curve: Revit Curve (Line, Arc, etc.)

    Returns:
        True if successfully set, False if not a LocationCurve
    """
    loc = element.Location
    if not isinstance(loc, LocationCurve):
        return False
    _start()
    loc.Curve = curve
    _end()
    return True


# ── Move ──────────────────────────────────────────────────────────────────────

def move_element(element, vector_xyz):
    """
    Moves a Revit element by a vector (in internal feet).

    Args:
        element: Revit element
        vector_xyz: XYZ displacement vector in Revit internal feet

    Returns:
        None
    """
    _start()
    ElementTransformUtils.MoveElement(doc, element.Id, vector_xyz)
    _end()


def move_element_m(element, dx_m=0.0, dy_m=0.0, dz_m=0.0):
    """
    Moves an element by displacements specified in meters.

    Args:
        element: Revit element
        dx_m: X displacement in meters
        dy_m: Y displacement in meters
        dz_m: Z displacement in meters

    Returns:
        None
    """
    v = XYZ(
        _meters_to_feet(dx_m),
        _meters_to_feet(dy_m),
        _meters_to_feet(dz_m),
    )
    move_element(element, v)


def move_elements(elements_list, vector_xyz):
    """
    Moves multiple elements by the same vector in a single batch operation (MoveElements).

    Args:
        elements_list: List of Revit elements
        vector_xyz: XYZ displacement vector in internal feet

    Returns:
        None
    """
    ids = List[ElementId]([e.Id for e in elements_list])
    _start()
    ElementTransformUtils.MoveElements(doc, ids, vector_xyz)
    _end()


def align_to_point(element, target_point_xyz):
    """
    Moves an element so that its location point matches the target point.

    Args:
        element: Revit element with LocationPoint
        target_point_xyz: XYZ target absolute position

    Returns:
        True if successfully moved, False if not LocationPoint
    """
    loc = element.Location
    if not isinstance(loc, LocationPoint):
        return False
    vector = target_point_xyz - loc.Point
    move_element(element, vector)
    return True


# ── Copy ──────────────────────────────────────────────────────────────────────

def copy_element(element, vector_xyz):
    """
    Copies a Revit element offset by the specified vector.

    Args:
        element: Revit element to copy
        vector_xyz: XYZ displacement vector in internal feet

    Returns:
        Copied Revit element, or None if it fails
    """
    _start()
    new_ids = ElementTransformUtils.CopyElement(doc, element.Id, vector_xyz)
    _end()
    return doc.GetElement(list(new_ids)[0]) if new_ids else None


def copy_elements(elements_list, vector_xyz):
    """
    Copies multiple elements offset by the same vector in a single batch operation.

    Args:
        elements_list: List of Revit elements to copy
        vector_xyz: XYZ displacement vector in internal feet

    Returns:
        List of copied Revit elements
    """
    ids = List[ElementId]([e.Id for e in elements_list])
    _start()
    new_ids = ElementTransformUtils.CopyElements(doc, ids, vector_xyz)
    _end()
    return [doc.GetElement(i) for i in new_ids]


def copy_element_to_level(element, target_level):
    """
    Copies an element to the elevation of a different level, calculating Z offset automatically.

    Args:
        element: Revit element
        target_level: Target Revit Level

    Returns:
        Copied element, or None if it fails
    """
    loc = element.Location
    if isinstance(loc, LocationPoint):
        current_z = loc.Point.Z
    else:
        bb = element.BoundingBox[None]
        current_z = bb.Min.Z if bb else 0.0
    dz = target_level.ProjectElevation - current_z
    return copy_element(element, XYZ(0, 0, dz))


def copy_elements_between_documents(
        src_doc, ids_list, dest_doc, transform=None, paste_options=None):
    """
    Copies elements from one document to another, applying an optional Transform.

    Args:
        src_doc: Source Revit Document
        ids_list: List of ElementIds in source document
        dest_doc: Target Revit Document
        transform: Revit Transform (defaults to Identity)
        paste_options: CopyPasteOptions (optional)

    Returns:
        List of copied elements in destination document
    """
    if transform is None:
        transform = Transform.Identity
    ids_net = List[ElementId](ids_list)
    _start()
    new_ids = ElementTransformUtils.CopyElements(
        src_doc, ids_net, dest_doc, transform, paste_options
    )
    _end()
    return [dest_doc.GetElement(i) for i in new_ids]


# ── Rotate ────────────────────────────────────────────────────────────────────

def rotate_element(element, center_xyz, angle_degrees, axis_xyz=None):
    """
    Rotates an element around an axis passing through the specified point.

    Args:
        element: Revit element
        center_xyz: XYZ point through which rotation axis passes
        angle_degrees: Rotation angle in degrees
        axis_xyz: XYZ axis direction vector (defaults to vertical Z axis)

    Returns:
        None
    """
    if axis_xyz is None:
        axis_xyz = XYZ.BasisZ
    axis_line = Line.CreateBound(center_xyz, center_xyz + axis_xyz)
    _start()
    ElementTransformUtils.RotateElement(
        doc, element.Id, axis_line, _rad(angle_degrees)
    )
    _end()


def rotate_element_on_own_point(element, angle_degrees, axis_xyz=None):
    """
    Rotates an element around its own location point (or BoundingBox centroid).

    Args:
        element: Revit element
        angle_degrees: Rotation angle in degrees
        axis_xyz: XYZ axis direction (defaults to vertical Z)

    Returns:
        None
    """
    loc = element.Location
    if isinstance(loc, LocationPoint):
        center = loc.Point
    else:
        bb = element.BoundingBox[None]
        if bb is None:
            return
        center = XYZ(
            (bb.Min.X + bb.Max.X) / 2.0,
            (bb.Min.Y + bb.Max.Y) / 2.0,
            (bb.Min.Z + bb.Max.Z) / 2.0,
        )
    rotate_element(element, center, angle_degrees, axis_xyz)


def rotate_elements(elements_list, center_xyz, angle_degrees, axis_xyz=None):
    """
    Rotates multiple elements around a single axis in a single batch operation.

    Args:
        elements_list: List of Revit elements
        center_xyz: XYZ point through which rotation axis passes
        angle_degrees: Rotation angle in degrees
        axis_xyz: XYZ axis direction (defaults to vertical Z)

    Returns:
        None
    """
    if axis_xyz is None:
        axis_xyz = XYZ.BasisZ
    axis_line = Line.CreateBound(center_xyz, center_xyz + axis_xyz)
    ids = List[ElementId]([e.Id for e in elements_list])
    _start()
    ElementTransformUtils.RotateElements(
        doc, ids, axis_line, _rad(angle_degrees)
    )
    _end()


def rotate_view(view, center_xyz, angle_degrees):
    """
    Rotates a plan, section, or elevation view around the Z axis at the specified center.

    Args:
        view: Revit View
        center_xyz: XYZ center point
        angle_degrees: Rotation angle in degrees

    Returns:
        None
    """
    axis_line = Line.CreateBound(
        center_xyz, XYZ(center_xyz.X, center_xyz.Y, center_xyz.Z + 1.0)
    )
    _start()
    ElementTransformUtils.RotateElement(
        doc, view.Id, axis_line, _rad(angle_degrees)
    )
    _end()


# ── Mirror ────────────────────────────────────────────────────────────────────

def create_mirror_plane(normal_xyz, origin_xyz):
    """
    Creates a Revit Plane by its normal and origin point.

    Args:
        normal_xyz: XYZ unit normal vector of plane
        origin_xyz: XYZ origin point on plane

    Returns:
        Revit Plane
    """
    return Plane.CreateByNormalAndOrigin(normal_xyz, origin_xyz)


def mirror_elements(elements_list, normal_xyz, origin_xyz, create_copy=True):
    """
    Mirrors a list of elements relative to a plane.

    Args:
        elements_list: List of Revit elements
        normal_xyz: XYZ unit normal vector of mirror plane
        origin_xyz: XYZ point on mirror plane
        create_copy: True to keep originals and copy; False to mirror in-place

    Returns:
        List of resulting ElementIds
    """
    plane = Plane.CreateByNormalAndOrigin(normal_xyz, origin_xyz)
    ids = List[ElementId]([e.Id for e in elements_list])
    _start()
    results = ElementTransformUtils.MirrorElements(doc, ids, plane, not create_copy)
    _end()
    return list(results)


def mirror_element(element, normal_xyz, origin_xyz, create_copy=True):
    """
    Mirrors a single element relative to a plane.

    Args:
        element: Revit element
        normal_xyz: XYZ unit normal vector of mirror plane
        origin_xyz: XYZ point on mirror plane
        create_copy: True to copy; False to mirror in-place

    Returns:
        List of resulting ElementIds
    """
    return mirror_elements([element], normal_xyz, origin_xyz, create_copy)


# ── Flip ──────────────────────────────────────────────────────────────────────

def flip_element(element):
    """
    Flips an element using its native Flip() method.

    Args:
        element: Revit element supporting Flip()

    Returns:
        True if successfully flipped, False otherwise
    """
    _start()
    try:
        element.Flip()
        _end()
        return True
    except Exception:
        _end()
        return False


def flip_facing(family_instance):
    """
    Flips the facing orientation of a FamilyInstance.

    Args:
        family_instance: Revit FamilyInstance

    Returns:
        True if flipped successfully, False otherwise
    """
    _start()
    try:
        try:
            family_instance.flipFacing()
        except AttributeError:
            family_instance.FlipFacing()
        _end()
        return True
    except Exception:
        _end()
        return False


def flip_hand(family_instance):
    """
    Flips the hand orientation of a FamilyInstance.

    Args:
        family_instance: Revit FamilyInstance

    Returns:
        True if flipped successfully, False otherwise
    """
    _start()
    try:
        try:
            family_instance.flipHand()
        except AttributeError:
            family_instance.FlipHand()
        _end()
        return True
    except Exception:
        _end()
        return False


def flip_beam_ends(beam):
    """
    Flips the start and end of a structural framing beam (FlipEnds).

    Args:
        beam: Revit structural framing beam element

    Returns:
        True if successfully flipped, False otherwise
    """
    _start()
    try:
        StructuralFramingUtils.FlipEnds(beam)
        _end()
        return True
    except Exception:
        _end()
        return False


# ── Pin / Unpin ───────────────────────────────────────────────────────────────

def pin_element(element, pin=True):
    """
    Pins or unpins a Revit element.

    Args:
        element: Revit element
        pin: True to pin, False to unpin

    Returns:
        None
    """
    _start()
    element.Pinned = pin
    _end()


def unpin_element(element):
    """
    Unpins a Revit element.

    Args:
        element: Revit element

    Returns:
        None
    """
    pin_element(element, False)


def is_pinned(element):
    """
    Checks if a Revit element is pinned.

    Args:
        element: Revit element

    Returns:
        True if pinned, False otherwise
    """
    return bool(element.Pinned)


def pin_elements_list(elements_list, pin=True):
    """
    Pins or unpins a list of elements in a single batch.

    Args:
        elements_list: List of Revit elements
        pin: True to pin, False to unpin

    Returns:
        Number of successfully modified elements
    """
    _start()
    count = 0
    for e in elements_list:
        try:
            e.Pinned = pin
            count += 1
        except Exception:
            pass
    _end()
    return count


# ── Orientation Queries ────────────────────────────────────────────────────────

def get_hand_orientation(element):
    """
    Returns the HandOrientation vector of a FamilyInstance.

    Args:
        element: FamilyInstance element

    Returns:
        XYZ vector, or None if not applicable
    """
    try:
        return element.HandOrientation
    except AttributeError:
        return None


def get_facing_orientation(element):
    """
    Returns the FacingOrientation vector of a FamilyInstance.

    Args:
        element: FamilyInstance element

    Returns:
        XYZ vector, or None if not applicable
    """
    try:
        return element.FacingOrientation
    except AttributeError:
        return None


def is_mirrored(family_instance):
    """
    Checks if a FamilyInstance is mirrored.

    Args:
        family_instance: Revit FamilyInstance

    Returns:
        True if mirrored, False otherwise
    """
    try:
        return bool(family_instance.Mirrored)
    except AttributeError:
        return False


def is_facing_flipped(family_instance):
    """
    Checks if a FamilyInstance facing direction is flipped relative to the family definition.

    Args:
        family_instance: Revit FamilyInstance

    Returns:
        True if facing flipped, False otherwise
    """
    try:
        return bool(family_instance.FacingFlipped)
    except AttributeError:
        return False


def is_hand_flipped(family_instance):
    """
    Checks if a FamilyInstance hand direction is flipped relative to the family definition.

    Args:
        family_instance: Revit FamilyInstance

    Returns:
        True if hand flipped, False otherwise
    """
    try:
        return bool(family_instance.HandFlipped)
    except AttributeError:
        return False


def get_complete_orientation(family_instance):
    """
    Returns all orientation and flip information for a FamilyInstance in a dictionary.

    Args:
        family_instance: Revit FamilyInstance

    Returns:
        Dict with keys:
          "hand":           XYZ HandOrientation or None
          "facing":         XYZ FacingOrientation or None
          "mirrored":       bool Mirrored
          "facing_flipped": bool FacingFlipped
          "hand_flipped":   bool HandFlipped
          "angle_deg":      float rotation angle in plan view or None
    """
    hand = get_hand_orientation(family_instance)
    angle = None
    if hand is not None:
        angle = math.degrees(math.atan2(hand.Y, hand.X)) % 360.0
    return {
        "hand": hand,
        "facing": get_facing_orientation(family_instance),
        "mirrored": is_mirrored(family_instance),
        "facing_flipped": is_facing_flipped(family_instance),
        "hand_flipped": is_hand_flipped(family_instance),
        "angle_deg": angle,
    }


# ── Transform Math ────────────────────────────────────────────────────────────

def create_translation_transform(vector_xyz):
    """
    Creates a translation transform from a vector.

    Args:
        vector_xyz: XYZ displacement vector in internal feet

    Returns:
        Transform
    """
    return Transform.CreateTranslation(vector_xyz)


def create_rotation_transform(axis_xyz, angle_degrees):
    """
    Creates a rotation transform around a unit axis vector.

    Args:
        axis_xyz: XYZ unit rotation axis vector
        angle_degrees: Rotation angle in degrees

    Returns:
        Transform
    """
    return Transform.CreateRotation(axis_xyz, _rad(angle_degrees))


def create_axes_transform(origin_xyz, axis_x, axis_y, axis_z=None):
    """
    Creates a Transform from origin and basis axes vectors.
    Useful for local coordinate systems (e.g. sections, bounding box crops).

    Args:
        origin_xyz: XYZ origin of coordinate system
        axis_x:     XYZ unit X basis vector
        axis_y:     XYZ unit Y basis vector
        axis_z:     XYZ Z basis vector (defaults to axis_x cross axis_y)

    Returns:
        Transform
    """
    if axis_z is None:
        axis_z = axis_x.CrossProduct(axis_y)
    t = Transform.Identity
    t.Origin = origin_xyz
    t.BasisX = axis_x
    t.BasisY = axis_y
    t.BasisZ = axis_z
    return t


def transform_point(transform, point_xyz):
    """
    Applies a Transform to an XYZ point (includes translation).

    Args:
        transform: Revit Transform
        point_xyz: XYZ point

    Returns:
        XYZ transformed point
    """
    return transform.OfPoint(point_xyz)


def transform_vector(transform, vector_xyz):
    """
    Applies a Transform to an XYZ vector (rotation only, no translation).

    Args:
        transform: Revit Transform
        vector_xyz: XYZ vector

    Returns:
        XYZ transformed vector
    """
    return transform.OfVector(vector_xyz)


def invert_transform(transform):
    """
    Returns the inverse of a Transform.
    Useful for projecting host coordinates to a link's coordinate space.

    Args:
        transform: Revit Transform

    Returns:
        Transform inverse
    """
    return transform.Inverse


def combine_transforms(transform_a, transform_b):
    """
    Combines two Transforms in sequence (A followed by B).

    Args:
        transform_a: Transform applied first
        transform_b: Transform applied second

    Returns:
        Combined Transform
    """
    return transform_b.Multiply(transform_a)


def get_element_transform(element):
    """
    Retrieves the Transform of a FamilyInstance or other instanced element.

    Args:
        element: FamilyInstance or element supporting GetTransform()

    Returns:
        Transform, or None if not applicable
    """
    try:
        return element.GetTransform()
    except AttributeError:
        return None


# ── Geometric Utilities ───────────────────────────────────────────────────────

def vector_between_points(origin_xyz, target_xyz):
    """
    Calculates the displacement vector between two points.

    Args:
        origin_xyz: XYZ origin point
        target_xyz: XYZ target point

    Returns:
        XYZ displacement vector (target_xyz - origin_xyz)
    """
    return target_xyz - origin_xyz


def distance_between_points_m(point_a, point_b):
    """
    Calculates distance between two points in meters.

    Args:
        point_a: XYZ first point
        point_b: XYZ second point

    Returns:
        float distance in meters
    """
    return _feet_to_meters(point_a.DistanceTo(point_b))


def get_bbox_centroid(element):
    """
    Returns the centroid of the BoundingBox of an element in project coordinates.

    Args:
        element: Revit element

    Returns:
        XYZ centroid point, or None if BoundingBox not found
    """
    bb = element.BoundingBox[None]
    if bb is None:
        return None
    return XYZ(
        (bb.Min.X + bb.Max.X) / 2.0,
        (bb.Min.Y + bb.Max.Y) / 2.0,
        (bb.Min.Z + bb.Max.Z) / 2.0,
    )
