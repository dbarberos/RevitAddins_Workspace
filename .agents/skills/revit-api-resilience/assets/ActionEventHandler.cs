using System;
using Autodesk.Revit.UI;

namespace RevitAddinBase.Resilience
{
    /// <summary>
    /// A generic ExternalEventHandler that executes an Action on the Revit UI thread.
    /// Extremely useful for Modeless WPF windows to safely interact with the Revit API
    /// without encountering InvalidOperationException.
    /// </summary>
    public class ActionEventHandler : IExternalEventHandler
    {
        private Action _action;
        private readonly object _lock = new object();

        public void Execute(UIApplication app)
        {
            Action currentAction = null;
            lock (_lock)
            {
                currentAction = _action;
                _action = null; // Clear to prevent double execution
            }

            if (currentAction != null)
            {
                try
                {
                    currentAction.Invoke();
                }
                catch (Exception ex)
                {
                    // Safe exception handling, prevent Revit from crashing silently
                    TelemetryLogger.LogException("ActionEventHandler Execution Error", ex, app.Application);
                }
            }
        }

        public string GetName() => "Generic Action Event Handler";

        /// <summary>
        /// Queues an action and safely raises the external event from a background thread.
        /// </summary>
        public void Raise(Action action, ExternalEvent externalEvent)
        {
            lock (_lock)
            {
                _action = action;
            }
            externalEvent?.Raise();
        }
    }
}
