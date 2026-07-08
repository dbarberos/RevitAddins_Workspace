# Debugging Lesson: Linked Elements Starvation and Missing Tree Nodes after PickObjects

**Date:** 2026-07-08
**Context:** Revit API Linked Documents, Custom TreeView Binding, Modeless UI Thread Context

## Symptom
1. When selecting "All Model Elements" with both the Active Model and Linked Models active, categories/families/types of the linked models are not populated in the tree explorer.
2. After calling `Select in Revit` and selecting linked elements, the picked elements do not show up in the tree explorer, even though they were successfully selected.

## Root Cause
1. **Starvation from Hard Limit Truncation:** To prevent UI thread freezing when loading large models without virtualization, the collector truncated all elements to 10,000 using `allRaw.Take(10000)`. Because elements of the host document are queried first, they completely starved and excluded the elements of the linked documents appended at the end of the collection.
2. **Missing UI Thread Mapper:** When `OnPickElementsFinished` was called with a list of `ElementSelectionKey` objects, it attempted to look up the corresponding `ElementModel` inside the `_allModelElements` collection. Since those linked elements were either truncated (due to the 10,000 limit) or not loaded at all, the lookup failed, preventing them from being injected into the TreeView's active elements list. Because the callback is invoked on the UI thread (via `InvokeAsync`), query operations directly on Revit documents to map the elements on the fly would cause a thread-safety exception.

## Solution / Design Pattern
1. **Increase Truncation Limit:** Raised the safety truncation limit to `50000` combined elements, which is fully supported by the WPF `VirtualizingStackPanel` with zero latency, ensuring both the host model and linked model components are loaded into memory.
2. **Pre-Map on the Revit API Thread:** Instead of passing raw selection keys to the UI context and resolving them on the UI thread, the resolution/mapping must happen inside the external event execution context (`IExternalEventHandler.Execute`):
   - Resolve the native `Element` objects inside the target host or link document.
   - Construct their corresponding `ElementModel` objects using the selection mapping service while still executing on the Revit API thread.
   - Pass both the keys and the resolved `ElementModel` objects to `OnPickElementsFinished`.
   - The UI callback can now directly inject the mapped models into both the explorer tree and active elements without thread-safety concerns.
