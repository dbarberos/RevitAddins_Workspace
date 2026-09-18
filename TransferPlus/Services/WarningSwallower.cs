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

        foreach (FailureMessageAccessor failure in failures)
        {
            FailureSeverity severity = failure.GetSeverity();

            if (severity == FailureSeverity.Warning)
            {
                failuresAccessor.DeleteWarning(failure);
            }
            else if (severity == FailureSeverity.Error)
            {
                LoggerService.LogWarning($"Revit Hard Error encountered: '{failure.GetDescriptionText()}'. Default Resolution attempt: {(failure.HasResolutions() ? "Resolve and Commit" : "Rollback")}");
                if (failure.HasResolutions())
                {
                    try
                    {
                        failuresAccessor.ResolveFailure(failure);
                        return FailureProcessingResult.ProceedWithCommit;
                    }
                    catch { }
                }
                return FailureProcessingResult.ProceedWithRollBack;
            }
        }

        return FailureProcessingResult.Continue;
    }

    public static void AttachToTransaction(Transaction transaction)
    {
        FailureHandlingOptions options = transaction.GetFailureHandlingOptions();
        options.SetFailuresPreprocessor(new WarningSwallower());
        options.SetClearAfterRollback(true); 
        transaction.SetFailureHandlingOptions(options);
    }
}
