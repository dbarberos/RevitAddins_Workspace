using System;
using Autodesk.Revit.UI;

namespace FilterPlus.Services;

/// <summary>
/// A generic ExternalEventHandler that executes an Action on the Revit UI thread.
/// Solves silent thread crash issues when invoking Revit API methods from WPF Modeless Windows.
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
                // Fallback to standard WPF MessageBox if logging service fails
                System.Windows.MessageBox.Show(ex.Message, "ActionEventHandler Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
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
