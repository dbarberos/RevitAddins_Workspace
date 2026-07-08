// ==============================================================================
// SKILL: SKILL-RVT-CORE (Revit API Core Engine)
// PATTERN: External Event Handler (Async to Sync Bridge)
// PURPOSE: Safely delegates operations from asynchronous or background threads 
//          (like Modeless WPF windows or WebView2 IPC events) to the main 
//          Revit API thread. Prevents fatal crashes during UI interactions.
// DEPENDENCIES: Autodesk.Revit.UI, System.Collections.Concurrent
// ==============================================================================

using System;
using System.Collections.Concurrent;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace RevitAddinBase.Core
{
    /// <summary>
    /// A robust implementation of IExternalEventHandler that manages a thread-safe 
    /// queue of actions. Allows modeless interfaces to push operations to the Revit API.
    /// </summary>
    public class ExternalEventBridge : IExternalEventHandler
    {
        // Thread-safe queue to hold pending actions requested by the UI
        private readonly ConcurrentQueue<Action<UIApplication>> _actionQueue;
        
        // The native Revit event trigger
        private readonly ExternalEvent _externalEvent;

        /// <summary>
        /// Initializes the bridge and registers it with the Revit host.
        /// This MUST be instantiated from a valid Revit API context (e.g., inside IExternalCommand or IExternalApplication).
        /// </summary>
        public ExternalEventBridge()
        {
            _actionQueue = new ConcurrentQueue<Action<UIApplication>>();
            _externalEvent = ExternalEvent.Create(this);
        }

        /// <summary>
        /// Main execution loop called by Revit when its thread is idle and the event has been raised.
        /// </summary>
        /// <param name="app">The application context provided by Revit.</param>
        public void Execute(UIApplication app)
        {
            // Process all pending actions in the queue
            while (_actionQueue.TryDequeue(out Action<UIApplication> actionToExecute))
            {
                try
                {
                    // Execute the requested business logic
                    actionToExecute.Invoke(app);
                }
                catch (Exception ex)
                {
                    // Catch exceptions to prevent one failing task from crashing the entire queue or Revit
                    System.Diagnostics.Debug.WriteLine($"[ExternalEventBridge] Execution Failed: {ex.Message}\n{ex.StackTrace}");
                    
                    TaskDialog.Show("Async Execution Error", 
                        $"An error occurred while executing a background task:\n{ex.Message}");
                }
            }
        }

        /// <summary>
        /// Enqueues an action from an external/background thread and signals Revit to process it.
        /// </summary>
        /// <param name="action">The logic to be executed on the Revit API thread.</param>
        public void EnqueueAndRaise(Action<UIApplication> action)
        {
            if (action == null) return;

            _actionQueue.Enqueue(action);
            
            // Flags the event. Revit will call the Execute() method as soon as it is idle.
            _externalEvent.Raise();
        }

        /// <summary>
        /// Returns the name of the handler for telemetry and debugging within Revit.
        /// </summary>
        public string GetName()
        {
            return "Generic Modeless UI Event Bridge";
        }
    }
}