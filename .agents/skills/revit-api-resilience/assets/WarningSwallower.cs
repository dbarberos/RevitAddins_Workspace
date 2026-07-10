// ==============================================================================
// SKILL: SKILL-RVT-RES (Resilience & Operations)
// PATTERN: IFailuresPreprocessor (Warning Suppression)
// PURPOSE: Silently resolves minor warnings and ignores non-fatal errors during 
//          automated transactions, preventing the Revit UI from locking up.
// DEPENDENCIES: Autodesk.Revit.DB, System.Collections.Generic
// ==============================================================================

using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace RevitAddinBase.Resilience
{
    /// <summary>
    /// Preprocessor that intercepts and dismisses warnings before they appear to the user.
    /// </summary>
    public class WarningSwallower : IFailuresPreprocessor
    {
        /// <summary>
        /// Evaluates all failures in the current transaction and attempts to resolve them.
        /// </summary>
        public FailureProcessingResult PreprocessFailures(FailuresAccessor failuresAccessor)
        {
            IList<FailureMessageAccessor> failures = failuresAccessor.GetFailureMessages();
            
            if (failures.Count == 0)
                return FailureProcessingResult.Continue;

            bool hasWarnings = false;

            foreach (FailureMessageAccessor failure in failures)
            {
                FailureSeverity severity = failure.GetSeverity();

                if (severity == FailureSeverity.Warning)
                {
                    // Silently delete the warning message
                    failuresAccessor.DeleteWarning(failure);
                    hasWarnings = true;
                }
                else if (severity == FailureSeverity.Error)
                {
                    // If there is a hard error, try the default resolution (e.g., unjoin elements)
                    if (failuresAccessor.CanCommitElements())
                    {
                        failuresAccessor.ResolveFailure(failure);
                        return FailureProcessingResult.ProceedWithCommit;
                    }
                    
                    // If it cannot be resolved safely, let Revit roll back the transaction
                    return FailureProcessingResult.ProceedWithRollBack;
                }
            }

            return hasWarnings ? FailureProcessingResult.ProceedWithCommit : FailureProcessingResult.Continue;
        }

        /// <summary>
        /// Helper method to easily attach this preprocessor to any Transaction.
        /// </summary>
        public static void AttachToTransaction(Transaction transaction)
        {
            FailureHandlingOptions options = transaction.GetFailureHandlingOptions();
            options.SetFailuresPreprocessor(new WarningSwallower());
            // Clears any forced modal dialogs
            options.SetClearAfterRollback(true); 
            transaction.SetFailureHandlingOptions(options);
        }
    }
}
