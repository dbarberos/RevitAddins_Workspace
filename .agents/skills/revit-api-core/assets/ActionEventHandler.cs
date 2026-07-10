using System;
using System.Collections.Generic;
using Autodesk.Revit.UI;

namespace FilterPlus.Services;

/// <summary>
/// A generic ExternalEventHandler that executes Actions on the Revit UI thread sequentially.
/// </summary>
public class ActionEventHandler : IExternalEventHandler
{
    private readonly Queue<Action> _actions = new Queue<Action>();
    private readonly object _lock = new object();

    public void Execute(UIApplication app)
    {
        LoggerService.LogInfo("ActionEventHandler: Execute started on Revit thread.");
        var actionsToRun = new List<Action>();

        lock (_lock)
        {
            while (_actions.Count > 0)
            {
                actionsToRun.Add(_actions.Dequeue());
            }
        }

        LoggerService.LogInfo($"ActionEventHandler: Found {actionsToRun.Count} actions to execute.");

        foreach (var action in actionsToRun)
        {
            try
            {
                LoggerService.LogInfo("ActionEventHandler: Invoking action...");
                action.Invoke();
                LoggerService.LogInfo("ActionEventHandler: Action invoked successfully.");
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
        LoggerService.LogInfo("ActionEventHandler: Raise called from UI thread.");
        lock (_lock)
        {
            _actions.Enqueue(action);
        }
        if (externalEvent != null)
        {
            LoggerService.LogInfo("ActionEventHandler: Raising external event.");
            externalEvent.Raise();
        }
        else
        {
            LoggerService.LogInfo("ActionEventHandler: External event is null.");
        }
    }
}
