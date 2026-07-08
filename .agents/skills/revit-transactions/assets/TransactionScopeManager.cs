// ==============================================================================
// SKILL: SKILL-RVT-CORE (Revit API Core Engine)
// PATTERN: Transaction Scope Wrapper
// PURPOSE: Encapsulates Revit database modifications in safe transactional 
//          blocks. Automatically handles Commits, Rollbacks on exceptions, 
//          and TransactionGroup assimilation to keep the Undo menu clean.
// DEPENDENCIES: Autodesk.Revit.DB, System
// ==============================================================================

using System;
using Autodesk.Revit.DB;

namespace RevitAddinBase.Core
{
    /// <summary>
    /// Utility class to safely execute database modifications.
    /// Eliminates repetitive boilerplate for starting, committing, and rolling back transactions.
    /// </summary>
    public static class TransactionScopeManager
    {
        /// <summary>
        /// Executes an action within a standard Revit Transaction.
        /// </summary>
        /// <param name="doc">The active Revit Document database.</param>
        /// <param name="transactionName">Name of the transaction (visible to the user in the Undo menu).</param>
        /// <param name="action">The encapsulated business logic to execute.</param>
        /// <returns>True if the transaction was committed successfully; otherwise, false.</returns>
        public static bool DoInTransaction(Document doc, string transactionName, Action action)
        {
            if (doc == null) throw new ArgumentNullException(nameof(doc));
            if (action == null) throw new ArgumentNullException(nameof(action));

            // Prevent exceptions if the document is not modifiable (e.g., opened in a background thread without UI)
            if (doc.IsReadOnly)
            {
                System.Diagnostics.Debug.WriteLine($"[Transaction Error] Document '{doc.Title}' is read-only.");
                return false;
            }

            using (Transaction t = new Transaction(doc, transactionName))
            {
                try
                {
                    t.Start();
                    
                    // Execute the injected business logic
                    action.Invoke();
                    
                    // If no exception is thrown and the transaction is still open, commit the changes
                    if (t.GetStatus() == TransactionStatus.Started)
                    {
                        t.Commit();
                        return true;
                    }
                    
                    return false;
                }
                catch (Exception ex)
                {
                    // Safe Rollback on failure to prevent database corruption
                    if (t.GetStatus() == TransactionStatus.Started || t.GetStatus() == TransactionStatus.RolledBack)
                    {
                        t.RollBack();
                    }
                    
                    System.Diagnostics.Debug.WriteLine($"[Transaction Failed] {transactionName}: {ex.Message}\n{ex.StackTrace}");
                    
                    // Rethrow the exception so the BaseCommandBoilerplate can catch it and display the UI Dialog
                    throw; 
                }
            }
        }

        /// <summary>
        /// Executes multiple actions within a TransactionGroup.
        /// Highly recommended for batch operations (e.g., creating 50 sheets) so the user 
        /// only has to press CTRL+Z once to undo the entire operation.
        /// </summary>
        /// <param name="doc">The active Revit Document database.</param>
        /// <param name="groupName">Name of the transaction group (visible in the Undo menu).</param>
        /// <param name="action">The encapsulated business logic containing multiple individual transactions.</param>
        /// <param name="assimilate">If true, merges all nested transactions into a single Undo step.</param>
        /// <returns>True if the group was committed/assimilated successfully; otherwise, false.</returns>
        public static bool DoInTransactionGroup(Document doc, string groupName, Action action, bool assimilate = true)
        {
            if (doc == null) throw new ArgumentNullException(nameof(doc));
            if (action == null) throw new ArgumentNullException(nameof(action));

            using (TransactionGroup tg = new TransactionGroup(doc, groupName))
            {
                try
                {
                    tg.Start();
                    
                    // Execute logic that contains one or more TransactionScopeManager.DoInTransaction calls
                    action.Invoke();
                    
                    if (tg.GetStatus() == TransactionStatus.Started)
                    {
                        if (assimilate)
                        {
                            tg.Assimilate(); // Merges all inner transactions into one invisible step
                        }
                        else
                        {
                            tg.Commit(); // Leaves inner transactions as separate, individual undo items
                        }
                        return true;
                    }
                    
                    return false;
                }
                catch (Exception ex)
                {
                    if (tg.GetStatus() == TransactionStatus.Started || tg.GetStatus() == TransactionStatus.RolledBack)
                    {
                        tg.RollBack(); // Reverts ALL inner transactions automatically
                    }
                    
                    System.Diagnostics.Debug.WriteLine($"[TransactionGroup Failed] {groupName}: {ex.Message}");
                    throw; 
                }
            }
        }
    }
}