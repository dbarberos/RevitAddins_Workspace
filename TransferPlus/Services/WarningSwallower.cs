using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace TransferPlus.Services;

public class WarningSwallower : IFailuresPreprocessor
{
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
                failuresAccessor.DeleteWarning(failure);
                hasWarnings = true;
            }
            else if (severity == FailureSeverity.Error)
            {
                return FailureProcessingResult.ProceedWithRollBack;
            }
        }

        return hasWarnings ? FailureProcessingResult.ProceedWithCommit : FailureProcessingResult.Continue;
    }

    public static void AttachToTransaction(Transaction transaction)
    {
        FailureHandlingOptions options = transaction.GetFailureHandlingOptions();
        options.SetFailuresPreprocessor(new WarningSwallower());
        options.SetClearAfterRollback(true); 
        transaction.SetFailureHandlingOptions(options);
    }
}
