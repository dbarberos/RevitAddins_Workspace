# -*- coding: utf-8 -*-
"""
geometry.py
Revit/Dynamo Python Utility Library — Geometric Algorithms
Compatible: IronPython 2.7 | CPython 3.x | Revit 2024-2027
"""

import clr
clr.AddReference("RevitAPI")
from Autodesk.Revit.DB import XYZ, Line, Arc, CurveLoop, DirectShape, BuiltInCategory

def create_line(start_xyz, end_xyz):
    """
    Creates a bound line between two points.

    Args:
        start_xyz: XYZ start point
        end_xyz: XYZ end point

    Returns:
        Line object
    """
    return Line.CreateBound(start_xyz, end_xyz)

def create_curveloop_from_curves(curves):
    """
    Creates a CurveLoop from a list of Revit curves.

    Args:
        curves: List of Curve objects

    Returns:
        CurveLoop object
    """
    loop = CurveLoop()
    for c in curves:
        loop.Append(c)
    return loop
