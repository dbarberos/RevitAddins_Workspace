# -*- coding: utf-8 -*-
"""
scientific.py
Revit/Dynamo Python Utility Library — Advanced Numerical Integrations
Compatible: IronPython 2.7 | CPython 3.x | Revit 2024-2027
"""

# Check for scientific modules (CPython 3 environment)
def check_dependencies_status():
    """
    Queries importing availability of advanced external dependencies.

    Returns:
        Dict: {"pandas": bool, "numpy": bool, "scipy": bool, "matplotlib": bool}
    """
    status = {}
    for lib in ["pandas", "numpy", "scipy", "matplotlib"]:
        try:
            __import__(lib)
            status[lib] = True
        except ImportError:
            status[lib] = False
    return status
