# Debugging Revit Add-in: Modeless WPF and Revit API Thread Deadlock

**Date:** 2026-07-07  
**Symptoms:**  
Clicking a WPF command button (e.g., "Save New" selection) causes Revit to hang completely. The interface freezes, becomes unresponsive, and must be forced closed via Task Manager. No error messages or exceptions are thrown.

**Root Cause:**
This is a classic **Thread Deadlock** arising from synchronous cross-thread dependencies between the WPF UI Thread and the Revit API Thread.

1. **Revit Thread Blocks on WPF UI Thread:**
   From the WPF Command, an `ExternalEvent` is raised to run logic on the Revit API Thread. Inside the Revit event handler delegate (running on the Revit thread), a synchronous `Dispatcher.Invoke(...)` is executed to run a callback on the WPF UI thread. This blocks the Revit thread until the UI thread finishes processing the callback.
2. **WPF UI Thread Blocks on Revit Thread:**
   Inside that synchronous `Dispatcher.Invoke` callback (running on the UI thread), the code attempts to call a Revit API method or service (e.g., loading entities from `Document` or accessing `doc.ProjectInformation`). Accessing Revit API members requires the Revit thread lock.
3. **Deadlock:**
   The Revit thread is waiting for the UI thread to complete `Dispatcher.Invoke`. The UI thread is waiting for the Revit thread to release the API lock. Neither can proceed.

```
Revit Thread (Blocked)  ──────> Dispatcher.Invoke() ──────> WPF UI Thread (Blocked)
        ▲                                                          │
        └──────────── (Acquire Revit API lock) ────────────────────┘
```

**Solution (Pattern):**
To break the deadlock dependency chain, you must separate database operations from UI updates and enforce asynchronous communication.

1. **Perform Revit API Reads on the Revit Thread:**
   Extract any Revit API database reads (like loading saved selections from the document's Extensible Storage) out of the UI thread callback and perform them entirely within the Revit thread context inside the `ExternalEvent`.
2. **Use Asynchronous Dispatching (`BeginInvoke`):**
   When passing results back from the Revit API context to the WPF ViewModel, **never** use `Dispatcher.Invoke()`. Always use `Dispatcher.BeginInvoke(...)` (asynchronous). This allows the Revit thread to finish its work and commit transactions without waiting for the UI thread to execute the callback.
3. **Manage UI Busy State:**
   To prevent user interaction during the asynchronous execution:
   - Set a boolean flag (e.g. `IsBusy = true`) on the UI thread before raising the event.
   - Reset the flag (e.g. `IsBusy = false`) in the `finally` block of the asynchronous callback dispatched back to the UI thread.

**Correct Code Structure:**
```csharp
// 1. From WPF UI Thread: Set state and trigger event
IsBusy = true;
StatusMessage = "Processing...";

// Capture UI dispatcher safely
var uiDispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;

_externalEvent.Raise(() => 
{
    // 2. On Revit API Thread: Execute all database reads, writes, and transactions
    var resultData = RevitDatabaseService.PerformWork(doc);
    
    // 3. Dispatch UI updates asynchronously back to UI thread (non-blocking)
    uiDispatcher.BeginInvoke(new Action(() => 
    {
        try
        {
            ViewModelList.Clear();
            foreach(var item in resultData)
            {
                ViewModelList.Add(item);
            }
            StatusMessage = "Success!";
        }
        catch(Exception ex)
        {
            Logger.Error(ex);
        }
        finally
        {
            IsBusy = false; // Always release UI block
        }
    }));
});
```
