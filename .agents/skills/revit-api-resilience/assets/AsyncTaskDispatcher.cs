// ==============================================================================
// SKILL: SKILL-RVT-RES (Resilience & Operations)
// PATTERN: External Event Task Dispatcher
// PURPOSE: Queues actions requested by modeless WPF windows and executes them 
//          safely on the main Revit thread using IExternalEventHandler.
// DEPENDENCIES: Autodesk.Revit.UI, System.Collections.Concurrent, System
// ==============================================================================

using System;
using System.Collections.Concurrent;
using Autodesk.Revit.UI;

namespace RevitAddinBase.Resilience
{
    /// <summary>
    /// Thread-safe queue for dispatching API tasks from background UI threads.
    /// </summary>
    public class AsyncTaskDispatcher : IExternalEventHandler
    {
        // Thread-safe queue to hold pending actions
        private readonly ConcurrentQueue<Action<UIApplication>> _taskQueue;
        private ExternalEvent _externalEvent;

        public AsyncTaskDispatcher()
        {
            _taskQueue = new ConcurrentQueue<Action<UIApplication>>();
        }

        /// <summary>
        /// Initializes the underlying External Event. 
        /// MUST be called during IExternalApplication.OnStartup() or IExternalCommand.Execute().
        /// </summary>
        public void Initialize()
        {
            if (_externalEvent == null)
            {
                _externalEvent = ExternalEvent.Create(this);
            }
        }

        /// <summary>
        /// Queues an action from a WPF ViewModel and signals Revit to execute it when idle.
        /// </summary>
        /// <param name="task">The lambda function containing Revit API code.</param>
        public void EnqueueTask(Action<UIApplication> task)
        {
            if (task == null) return;
            
            _taskQueue.Enqueue(task);
            _externalEvent?.Raise();
        }

        /// <summary>
        /// Called natively by Revit on the main thread when the application is idle.
        /// </summary>
        public void Execute(UIApplication app)
        {
            while (_taskQueue.TryDequeue(out Action<UIApplication> task))
            {
                try
                {
                    task.Invoke(app);
                }
                catch (Exception ex)
                {
                    TelemetryLogger.LogException("Dispatcher Execution Failed", ex);
                }
            }
        }

        public string GetName() => "Async Task Dispatcher";
    }
}
