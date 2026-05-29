# -*- coding: utf-8 -*-
"""
transactions.py
Revit/Dynamo Python Utility Library — Advanced Transaction Operations
Compatible: IronPython 2.7 | CPython 3.x | Revit 2024-2027
"""

import clr
clr.AddReference("RevitAPI")
clr.AddReference("RevitServices")

from Autodesk.Revit.DB import Transaction, TransactionGroup, SubTransaction
from RevitServices.Persistence import DocumentManager
from RevitServices.Transactions import TransactionManager

doc = DocumentManager.Instance.CurrentDBDocument
app = DocumentManager.Instance.CurrentUIApplication.Application

def run_in_transaction_group(group_name, function_calls):
    """
    Executes multiple functions within a native Revit TransactionGroup.
    Commit is performed via Assimilate, rollback is performed if any function fails.

    Args:
        group_name: Name of the transaction group as a string
        function_calls: List of tuples (callable, *args) to execute

    Returns:
        List of results of each function
    """
    group = TransactionGroup(doc, group_name)
    group.Start()
    results = []
    try:
        for item in function_calls:
            fn = item[0]
            args = item[1:] if len(item) > 1 else ()
            results.append(fn(*args))
        group.Assimilate()
    except Exception as e:
        group.RollBack()
        raise e
    return results

def start_native_transaction(name):
    """
    Starts a native Revit Transaction (not Dynamo's managed transaction) and returns it.

    Args:
        name: Name of transaction as string

    Returns:
        Active native Transaction object
    """
    t = Transaction(doc, name)
    t.Start()
    return t

def end_native_transaction(transaction, commit=True):
    """
    Commits or rolls back an active native Revit Transaction.

    Args:
        transaction: The active native Transaction object
        commit: True to Commit, False to Rollback

    Returns:
        None
    """
    if commit:
        transaction.Commit()
    else:
        transaction.RollBack()

def run_in_subtransaction(name, fn, *args):
    """
    Executes a function inside a SubTransaction.
    Requires an active native Transaction in the outer context.

    Args:
        name: Descriptive name of the subtransaction
        fn: Callable function to run
        *args: Arguments for the function

    Returns:
        Result of the function
    """
    sub = SubTransaction(doc)
    sub.Start()
    try:
        result = fn(*args)
        sub.Commit()
        return result
    except Exception as e:
        sub.RollBack()
        raise e

def run_in_native_transaction(name, fn, *args):
    """
    Executes a function inside a fresh native Transaction with automatic Rollback on error.

    Args:
        name: Name of transaction as string
        fn: Callable function
        *args: Arguments for the function

    Returns:
        Result of the function
    """
    t = Transaction(doc, name)
    t.Start()
    try:
        result = fn(*args)
        t.Commit()
        return result
    except Exception as e:
        t.RollBack()
        raise e

def force_close_transactions():
    """
    Forces the closing of all active Dynamo transactions.

    Returns:
        None
    """
    TransactionManager.Instance.ForceCloseTransaction()

def delete_element_in_subtransaction(element):
    """
    Deletes an element inside a SubTransaction.

    Args:
        element: Revit element to delete

    Returns:
        None
    """
    sub = SubTransaction(doc)
    sub.Start()
    doc.Delete(element.Id)
    sub.Commit()

def compare_documents(other_doc_path):
    """
    Compares the active document with another document specified by path and returns differences.

    Args:
        other_doc_path: Full path to the other .rvt file

    Returns:
        Tuple (created_ids, modified_ids, deleted_ids)
    """
    other_doc = app.OpenDocumentFile(other_doc_path)
    version_guid = other_doc.GetDocumentVersion().VersionGUID
    diff = doc.GetChangedElements(version_guid)
    return (
        list(diff.GetCreatedElementIds()),
        list(diff.GetModifiedElementIds()),
        list(diff.GetDeletedElementIds()),
    )
