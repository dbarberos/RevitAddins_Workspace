using Autodesk.Revit.DB;

namespace TablePlus.Services;

/// <summary>
/// Preprocessor that automatically dismisses non-fatal warnings (such as overlapping lines or small geometry)
/// during batch table creation without interrupting execution or displaying modal alerts.
/// </summary>
public class WarningSwallower : IFailuresPreprocessor
{
    public FailureProcessingResult PreprocessFailures(FailuresAccessor failuresAccessor)
    {
        var failureMessages = failuresAccessor.GetFailureMessages();
        foreach (var message in failureMessages)
        {
            var severity = message.GetSeverity();
            if (severity == FailureSeverity.Warning)
            {
                // Silently eliminate benign warnings (line overlap, slightly off-axis, etc.)
                failuresAccessor.DeleteWarning(message);
            }
        }

        return FailureProcessingResult.Continue;
    }
}
