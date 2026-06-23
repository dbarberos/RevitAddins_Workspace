# -*- coding: utf-8 -*-
"""
databases.py
Revit/Dynamo Python Utility Library — Database, JSON, and CSV Integrations
Compatible: IronPython 2.7 | CPython 3.x | Revit 2024-2027
"""

import json
import csv
import clr
clr.AddReference("RevitAPI")
clr.AddReference("RevitServices")

from Autodesk.Revit.DB import FilteredElementCollector, BuiltInCategory
from RevitServices.Persistence import DocumentManager

doc = DocumentManager.Instance.CurrentDBDocument

def read_json(file_path):
    """
    Reads and parses a JSON file into standard Python dictionaries.

    Args:
        file_path: Absolute path to json file

    Returns:
        Parsed JSON dictionary or list
    """
    with open(file_path, 'r') as f:
        return json.load(f)

def write_json(file_path, data):
    """
    Formats and writes Python dictionary/list data to a JSON file.

    Args:
        file_path: Target absolute path
        data: Dictionary or list to save

    Returns:
        None
    """
    with open(file_path, 'w') as f:
        json.dump(data, f, indent=4)

def read_csv(file_path, delimiter=','):
    """
    Reads rows of a CSV file.

    Args:
        file_path: Absolute path to CSV file
        delimiter: Column delimiter character

    Returns:
        List of lists containing cell values
    """
    data = []
    with open(file_path, 'r') as f:
        reader = csv.reader(f, delimiter=delimiter)
        for row in reader:
            data.append(row)
    return data

def write_csv(file_path, data, delimiter=','):
    """
    Writes a list of lists matrix to a CSV file.

    Args:
        file_path: Target absolute path
        data: Matrix of values
        delimiter: Delimiter character

    Returns:
        None
    """
    with open(file_path, 'w') as f:
        writer = csv.writer(f, delimiter=delimiter, lineterminator='\n')
        writer.writerows(data)

def export_element_parameters(category_bic, param_names, target_csv_path):
    """
    Collects elements of a category, extracts specified parameters, and exports them to a CSV.

    Args:
        category_bic: BuiltInCategory of elements
        param_names: List of parameter names to extract
        target_csv_path: Absolute path to CSV file

    Returns:
        Number of elements exported
    """
    elements = (FilteredElementCollector(doc)
                .OfCategory(category_bic)
                .WhereElementIsNotElementType()
                .ToElements())
                
    from assets.general import get_parameter_value
    
    header = ["ElementId", "UniqueId"] + param_names
    rows = [header]
    
    for e in elements:
        row = [str(e.Id.Value), e.UniqueId]
        for p in param_names:
            val = get_parameter_value(e, p)
            row.append(str(val) if val is not None else "")
        rows.append(row)
        
    write_csv(target_csv_path, rows)
    return len(elements)

def import_parameters_from_json(file_path):
    """
    Reads a JSON map of {"UniqueId": {"ParameterName": "Value"}} and updates Revit parameters.
    Requires active transaction.

    Args:
        file_path: Absolute path to JSON file

    Returns:
        Number of successfully updated parameters
    """
    data = read_json(file_path)
    from assets.general import set_parameter_value
    
    count = 0
    from RevitServices.Transactions import TransactionManager
    TransactionManager.Instance.EnsureInTransaction(doc)
    
    for uid, params in data.items():
        try:
            elem = doc.GetElement(uid)
            if elem:
                for p_name, val in params.items():
                    if set_parameter_value(elem, p_name, val):
                        count += 1
        except Exception:
            pass
            
    TransactionManager.Instance.TransactionTaskDone()
    return count
