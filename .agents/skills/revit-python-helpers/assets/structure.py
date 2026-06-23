# -*- coding: utf-8 -*-
"""
structure.py
Revit/Dynamo Python Utility Library — Structural Engineering Utilities
Compatible: IronPython 2.7 | CPython 3.x | Revit 2024-2027
"""

import clr
clr.AddReference("RevitAPI")
clr.AddReference("RevitServices")

from Autodesk.Revit.DB import (
    FilteredElementCollector, BuiltInCategory, Line, XYZ
)
from RevitServices.Persistence import DocumentManager
from RevitServices.Transactions import TransactionManager

doc = DocumentManager.Instance.CurrentDBDocument
