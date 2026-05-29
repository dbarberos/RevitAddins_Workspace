# -*- coding: utf-8 -*-
"""
excel.py
Revit/Dynamo Python Utility Library — Excel Spreadsheet Utilities
Compatible: IronPython 2.7 | CPython 3.x | Revit 2024-2027
"""

import os
import sys

def read_excel_com(file_path, sheet_name=None):
    """
    Reads an Excel spreadsheet using COM Interop (requires MS Excel installed locally).

    Args:
        file_path: Absolute path to the .xlsx or .xls file
        sheet_name: Name of worksheet to read (reads first sheet if None)

    Returns:
        List of lists containing cell values
    """
    import clr
    clr.AddReference("System.Runtime.InteropServices")
    from System.Runtime.InteropServices import Marshal
    
    # Try importing Excel Interop
    try:
        clr.AddReference("Microsoft.Office.Interop.Excel")
        import Microsoft.Office.Interop.Excel as Excel
    except Exception:
        raise ImportError("Excel Interop is not installed or available on this system.")

    app = Excel.ApplicationClass()
    app.Visible = False
    app.DisplayAlerts = False
    
    books = app.Workbooks
    book = books.Open(file_path)
    
    if sheet_name:
        sheet = book.Sheets[sheet_name]
    else:
        sheet = book.Sheets[1]
        
    data = []
    used_range = sheet.UsedRange
    rows_count = used_range.Rows.Count
    cols_count = used_range.Columns.Count
    
    for r in range(1, rows_count + 1):
        row_data = []
        for c in range(1, cols_count + 1):
            cell = used_range.Cells[r, c]
            row_data.append(cell.Value2)
        data.append(row_data)
        
    book.Close(False)
    app.Quit()
    
    # Release COM resources
    Marshal.ReleaseComObject(sheet)
    Marshal.ReleaseComObject(book)
    Marshal.ReleaseComObject(books)
    Marshal.ReleaseComObject(app)
    
    return data

def write_excel_com(file_path, data, sheet_name="Revit Data"):
    """
    Writes data matrix to an Excel spreadsheet using COM Interop.

    Args:
        file_path: Target absolute file path
        data: List of lists containing values
        sheet_name: Sheet title name

    Returns:
        True if successfully written, False otherwise
    """
    import clr
    clr.AddReference("System.Runtime.InteropServices")
    from System.Runtime.InteropServices import Marshal
    
    try:
        clr.AddReference("Microsoft.Office.Interop.Excel")
        import Microsoft.Office.Interop.Excel as Excel
    except Exception:
        return False

    app = Excel.ApplicationClass()
    app.Visible = False
    app.DisplayAlerts = False
    
    books = app.Workbooks
    book = books.Add()
    sheet = book.Sheets[1]
    sheet.Name = sheet_name
    
    for r_idx, row in enumerate(data, start=1):
        for c_idx, val in enumerate(row, start=1):
            sheet.Cells[r_idx, c_idx].Value2 = val
            
    if os.path.exists(file_path):
        os.remove(file_path)
        
    book.SaveAs(file_path)
    book.Close(False)
    app.Quit()
    
    Marshal.ReleaseComObject(sheet)
    Marshal.ReleaseComObject(book)
    Marshal.ReleaseComObject(books)
    Marshal.ReleaseComObject(app)
    return True

def get_excel_sheets(file_path):
    """
    Retrieves worksheet names from an Excel workbook without reading full content.

    Args:
        file_path: Absolute file path

    Returns:
        List of sheet name strings
    """
    import clr
    try:
        clr.AddReference("Microsoft.Office.Interop.Excel")
        import Microsoft.Office.Interop.Excel as Excel
    except Exception:
        return []

    app = Excel.ApplicationClass()
    app.Visible = False
    books = app.Workbooks
    book = books.Open(file_path)
    
    names = [s.Name for s in book.Sheets]
    
    book.Close(False)
    app.Quit()
    return names
