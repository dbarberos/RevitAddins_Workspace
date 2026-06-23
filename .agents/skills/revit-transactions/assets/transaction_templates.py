# pyRevit and IronPython Transaction Templates

import clr
clr.AddReference('RevitAPI')
from Autodesk.Revit.DB import SubTransaction
from pyrevit import revit

# 1. Standard pyRevit Context Manager
# This is the preferred way to execute transactions in pyRevit scripts.
# It automatically starts, commits (or rolls back on exception), and refreshes the UI.
def standard_pyrevit_transaction():
    doc = revit.doc
    
    with revit.Transaction("pyRevit Operation"):
        # Logic to modify the document goes here
        # e.g., element.LookupParameter("Comments").Set("Updated")
        pass


# 2. Nested SubTransaction in Python
# Use this when you are already inside a pyRevit Transaction (or a clean transaction environment)
# and you want to try an operation that might fail, without rolling back the entire parent transaction.
def subtransaction_example():
    doc = revit.doc
    
    with revit.Transaction("Main Operation"):
        # Perform some main operation that we want to keep
        # ...

        # Attempt a risky sub-operation
        sub_tx = SubTransaction(doc)
        sub_tx.Start()
        
        try:
            # Risky logic goes here
            # ...
            sub_tx.Commit()
        except Exception as e:
            # Rollback only the sub-transaction if it fails
            sub_tx.RollBack()
            print("Sub-operation failed, but main operation continues: {}".format(e))
