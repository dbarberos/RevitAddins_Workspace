using System;
using Autodesk.Revit.DB;

namespace TransactionTemplates
{
    public static class TransactionHelper
    {
        /// <summary>
        /// Standard Transaction block using the mandatory 'using' statement.
        /// </summary>
        public static void StandardTransactionExample(Document doc)
        {
            using (Transaction tx = new Transaction(doc, "Standard Operation"))
            {
                tx.Start();
                try
                {
                    // Logic to modify the document goes here
                    // ...

                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.RollBack();
                    throw;
                }
            }
        }

        /// <summary>
        /// Safe execution block that checks if the document is already modifiable.
        /// Uses a SubTransaction if a parent transaction exists, otherwise creates a new Transaction.
        /// </summary>
        public static void SafeExecutionExample(Document doc, Action action)
        {
            if (doc.IsModifiable)
            {
                // We are already inside a transaction (e.g. called from another method)
                using (SubTransaction subTx = new SubTransaction(doc))
                {
                    subTx.Start();
                    try
                    {
                        action();
                        subTx.Commit();
                    }
                    catch
                    {
                        subTx.RollBack();
                        throw;
                    }
                }
            }
            else
            {
                // No active transaction exists
                using (Transaction tx = new Transaction(doc, "Safe Operation"))
                {
                    tx.Start();
                    try
                    {
                        action();
                        tx.Commit();
                    }
                    catch
                    {
                        tx.RollBack();
                        throw;
                    }
                }
            }
        }
    }
}
