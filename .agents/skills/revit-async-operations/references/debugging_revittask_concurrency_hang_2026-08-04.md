# Debugging Log: RevitTask Concurrency Overwrite & Hanging Awaits in Modeless WPF

**Date:** 2026-08-04  
**Skill:** `revit-async-operations`  
**Tags:** `RevitTask`, `ExternalEvent`, `IExternalEventHandler`, `Concurrency`, `TaskCompletionSource`, `WPF`

---

## Problem Description
When triggering async operations from modeless WPF UI buttons or selection changes (e.g., requesting 3D family thumbnails during rapid TreeView navigation), the UI would lock into an infinite loading spinner state.

Log inspection showed that `RevitTask.RunAsync` was called, but the callback inside `RevitTask` never executed and never returned a result or exception.

---

## Root Cause Analysis
The static wrapper `RevitTask` implemented `IExternalEventHandler` using single instance fields:

```csharp
// BROKEN PATTERN (DO NOT USE)
private class RevitTaskEventHandler : IExternalEventHandler
{
    private Action<UIApplication>? _currentAction;
    private TaskCompletionSource<object?>? _tcs;

    public Task RunAsync(Action<UIApplication> action, ExternalEvent externalEvent)
    {
        _currentAction = action;
        _tcs = new TaskCompletionSource<object?>();
        externalEvent.Raise();
        return _tcs.Task;
    }
}
```

If `RunAsync` was invoked for Request A, and then invoked for Request B before Revit's idle event loop processed Request A:
1. `_currentAction` was overwritten with Request B's action.
2. `_tcs` was overwritten with Request B's `TaskCompletionSource`.
3. Request A's `TaskCompletionSource` was orphaned without calling `SetResult` or `SetException`.
4. The `await RevitTask.RunAsync(...)` for Request A hung indefinitely.

---

## Solution
Replace single fields with a thread-safe `ConcurrentQueue<RevitTaskWorkItem>`:

```csharp
// CORRECT PATTERN
public static class RevitTask
{
    private class RevitTaskWorkItem
    {
        public Action<UIApplication> Action { get; set; } = null!;
        public TaskCompletionSource<object?> Tcs { get; set; } = null!;
    }

    private class RevitTaskEventHandler : IExternalEventHandler
    {
        private readonly ConcurrentQueue<RevitTaskWorkItem> _queue = new();

        public void Execute(UIApplication app)
        {
            while (_queue.TryDequeue(out var workItem))
            {
                try
                {
                    workItem.Action.Invoke(app);
                    workItem.Tcs.TrySetResult(null);
                }
                catch (Exception ex)
                {
                    workItem.Tcs.TrySetException(ex);
                }
            }
        }

        public string GetName() => "TransferPlus RevitTask Handler";

        public Task RunAsync(Action<UIApplication> action, ExternalEvent externalEvent)
        {
            var tcs = new TaskCompletionSource<object?>();
            _queue.Enqueue(new RevitTaskWorkItem { Action = action, Tcs = tcs });
            externalEvent.Raise();
            return tcs.Task;
        }
    }

    private static readonly RevitTaskEventHandler _handler = new();
    private static readonly ExternalEvent _externalEvent = ExternalEvent.Create(_handler);

    public static Task RunAsync(Action<UIApplication> action) => _handler.RunAsync(action, _externalEvent);
}
```

---

## Key Takeaways
1. Never use single instance fields for `TaskCompletionSource` inside singleton or static `IExternalEventHandler` implementations.
2. Use `ConcurrentQueue` to buffer multiple incoming UI event requests.
3. Drain the entire queue inside `Execute(UIApplication app)` to process all pending UI actions cleanly in a single Revit idle loop cycle.
