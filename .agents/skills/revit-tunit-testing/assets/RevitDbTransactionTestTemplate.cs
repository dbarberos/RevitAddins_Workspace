using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Nice3point.TUnit.Revit;
using Nice3point.TUnit.Revit.Executors;
using TUnit.Assertions;
using TUnit.Assertions.Extensions;
using TUnit.Core;

namespace YourAddin.Tests.Integration;

/// <summary>
/// Validates transactional database operations inside an isolated, in-memory Revit project document.
/// </summary>
public sealed class RevitDbTransactionTestTemplate : RevitApiTest
{
    private Document? _doc;

    [Before(Test)]
    [HookExecutor<RevitThreadExecutor>]
    public void SetupDocument()
    {
        // Arrange: Create a fresh, pristine in-memory metric project
        _doc = Application.Application.NewProjectDocument(UnitSystem.Metric);
    }

    [After(Test)]
    [HookExecutor<RevitThreadExecutor>]
    public void TeardownDocument()
    {
        // Cleanup: Close document without saving to prevent disk pollution and state leaks
        if (_doc != null && _doc.IsValidObject)
        {
            _doc.Close(false);
            _doc = null;
        }
    }

    [Test]
    [TestExecutor<RevitThreadExecutor>]
    public async Task CreateDraftingView_Transaction_CommitsSuccessfully()
    {
        // Pre-condition
        await Assert.That(_doc).IsNotNull();
        await Assert.That(_doc!.IsValidObject).IsTrue();

        ViewDrafting? newView = null;

        // Act: Open transaction and create drafting view
        using (var trans = new Transaction(_doc, "Test Create Drafting View"))
        {
            // Register failure preprocessor to swallow non-fatal warnings
            var options = trans.GetFailureHandlingOptions();
            options.SetFailuresPreprocessor(new SilentWarningSwallower());
            trans.SetFailureHandlingOptions(options);

            trans.Start();

            var viewFamilyType = new FilteredElementCollector(_doc)
                .OfClass(typeof(ViewFamilyType))
                .Cast<ViewFamilyType>()
                .FirstOrDefault(t => t.ViewFamily == ViewFamily.Drafting);

            await Assert.That(viewFamilyType).IsNotNull();

            newView = ViewDrafting.Create(_doc, viewFamilyType!.Id);
            newView.Name = $"Test_DraftingView_{Guid.NewGuid():N}";

            trans.Commit();
        }

        // Assert
        await Assert.That(newView).IsNotNull();
        await Assert.That(newView!.IsValidObject).IsTrue();
        await Assert.That(newView.Id).IsNotEqualTo(ElementId.InvalidElementId);
    }

    /// <summary>
    /// Swallows non-fatal Revit warnings to prevent UI popups from locking test execution.
    /// </summary>
    private sealed class SilentWarningSwallower : IFailuresPreprocessor
    {
        public FailureProcessingResult PreprocessFailures(FailuresAccessor failuresAccessor)
        {
            var failureMessages = failuresAccessor.GetFailureMessages();
            foreach (var message in failureMessages)
            {
                if (message.GetSeverity() == FailureSeverity.Warning)
                {
                    failuresAccessor.DeleteWarning(message);
                }
            }
            return FailureProcessingResult.Continue;
        }
    }
}
