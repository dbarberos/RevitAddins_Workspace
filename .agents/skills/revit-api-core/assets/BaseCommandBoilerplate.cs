// ==============================================================================
// SKILL: SKILL-RVT-CORE (Revit API Core Engine)
// PATTERN: IExternalCommand Boilerplate Framework
// PURPOSE: Provide a secure, reusable, and structured base class for all
//          synchronous Revit external commands with embedded multi-level 
//          exception handling, context extraction, and safe execution logging.
// DEPENDENCIES: Autodesk.Revit.DB, Autodesk.Revit.UI
// ==============================================================================

using System;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace RevitAddinBase.Core
{
    /// <summary>
    /// Base class that wraps the Revit IExternalCommand execution lifecycle.
    /// All standard add-in commands should inherit from this class and override 
    /// the abstract OnExecute method to ensure uniform enterprise-level error handling.
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public abstract class BaseCommandBoilerplate : IExternalCommand
    {
        /// <summary>
        /// Main entry point invoked by the Revit API thread.
        /// </summary>
        /// <param name="commandData">Contains references to the application and active document context.</param>
        /// <param name="message">Error message string to be displayed by the native Revit dialog if failed.</param>
        /// <param name="elements">Set of elements to be highlighted visually if an error occurs.</param>
        /// <returns>A <see cref="Result"/> value indicating success, failure, or user cancellation.</returns>
        public Result Execute(
            ExternalCommandData commandData, 
            ref string message, 
            ElementSet elements)
        {
            // 1. Fail-safe check for command context validation
            if (commandData?.Application?.ActiveUIDocument == null)
            {
                message = "The command execution context is invalid. No active document found.";
                return Result.Failed;
            }

            // 2. Extract context shortcuts for downstream utilization
            UIApplication uiApp = commandData.Application;
            UIDocument uiDoc = uiApp.ActiveUIDocument;
            Document doc = uiDoc.Document;

            try
            {
                // 3. Delegate business logic to the derived command class
                return OnExecute(uiDoc, doc, commandData, ref message, elements);
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                // 4. Graceful handling of explicit user cancellations (e.g., escaping a PickObject action)
                return Result.Cancelled;
            }
            catch (Exception ex)
            {
                // 5. Global multi-level exception logging and UI warning propagation
                string errorHeader = $"Critical failure in Command: [{GetType().Name}]";
                string errorDetails = $"Exception Type: {ex.GetType().FullName}\n" +
                                      $"Message: {ex.Message}\n\n" +
                                      $"Stack Trace:\n{ex.StackTrace}";

                // Log the exact error internally for automated IT auditing
                System.Diagnostics.Debug.WriteLine($"{errorHeader}\n{errorDetails}");

                // Display an enterprise-branded Dialog to the end user
                TaskDialog mainDialog = new TaskDialog("Add-in Core Error")
                {
                    MainInstruction = errorHeader,
                    MainContent = ex.Message,
                    ExpandedContent = errorDetails,
                    TitleAutoPrefix = false,
                    MainIcon = TaskDialogIcon.TaskDialogIconError,
                    CommonButtons = TaskDialogCommonButtons.Close
                };

                mainDialog.Show();

                // Populate native message buffer for Revit telemetry
                message = ex.Message;
                return Result.Failed;
            }
        }

        /// <summary>
        /// Derived classes must override this method to execute specific business logic 
        /// inside a protected API context.
        /// </summary>
        /// <param name="uiDoc">The active UI document proxy.</param>
        /// <param name="doc">The underlying active project database instance.</param>
        /// <param name="commandData">The original command execution payload for advanced queries.</param>
        /// <param name="message">Reference buffer to pass custom messages back to the host process.</param>
        /// <param name="elements">Reference set to highlight elements in case of non-fatal operational alerts.</param>
        /// <returns>Operational execution result state.</returns>
        protected abstract Result OnExecute(
            UIDocument uiDoc, 
            Document doc, 
            ExternalCommandData commandData, 
            ref string message, 
            ElementSet elements);
    }
}