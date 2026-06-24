using System;
using Autodesk.Revit.UI;

namespace FilterPlus.Services;

/// <summary>
/// A generic ExternalEventHandler that executes an Action on the Revit UI thread.
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
                LoggerService.LogError("ActionEventHandler Execution", ex);
            }
        }
    }

    public string GetName()
    {
        return "Generic Action Event Handler";
    }

    /// <summary>
    /// Queues an action and raises the external event.
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
