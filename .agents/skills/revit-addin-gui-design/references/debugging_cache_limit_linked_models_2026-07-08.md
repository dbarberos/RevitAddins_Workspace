# Debugging Report: Cache Limit & UI Freeze with Linked Models

## Symptom
When a Revit user opens a UI (such as a TreeView or VirtualizingStackPanel list) designed to display selectable elements from both the active model and multiple linked models, the Revit UI thread freezes or experiences massive lag. Specifically, when the total combined element count across models exceeds roughly 100,000 items, the WPF UI virtualization cannot compensate for the sheer volume of memory consumed by the managed API wrappers and the data-binding payload.

## Root Cause
The `FilteredElementCollector` correctly retrieves elements quickly, but materializing those elements into ViewModels (e.g. `ElementViewModel` or `CategoryViewModel`) for the WPF UI breaks memory limits. Even with `VirtualizingStackPanel` correctly implemented, having >100,000 objects stored in an `ObservableCollection` in memory saturates the Garbage Collector and UI dispatcher, causing a freeze. Linked models, which can contain full architectural or MEP representations, quickly multiply the item count past safe thresholds.

## Solution / Lesson Learned
1. **Hard Limit Strategy**: Implement a hard safety cap on the number of elements cached into memory for UI display (e.g., 100,000 elements). 
2. **Fallback to Active Model Only**: If the element collection query predicts or counts a total exceeding the limit across all selected models, fallback to collecting elements from the **Active Model Only**, bypassing the linked models.
3. **UI Feedback**: Provide visual feedback to the user when this limitation occurs, such as a warning icon (e.g. an orange triangle `Alert24`) combined with a descriptive tooltip explaining that linked models were omitted due to performance safety limits.

### Code Snippet (ViewModel Logic)
```csharp
public async Task LoadScopesAndHandleCache()
{
    // ... logic to retrieve selected links ...
    
    int totalElements = 0;
    // 1. Fast count check before full materialization
    totalElements += new FilteredElementCollector(Doc).WhereElementIsNotElementType().GetElementCount();
    
    foreach (var link in selectedLinks)
    {
        totalElements += new FilteredElementCollector(link.GetLinkDocument()).WhereElementIsNotElementType().GetElementCount();
    }

    // 2. Cache Limit Fallback
    if (totalElements > 100000)
    {
        IsCacheLimited = true;
        LoggerService.LogInfo("Warning: >100k elements detected. Falling back to active model only to prevent UI freeze.");
        
        // Exclude linked models from full UI materialization
        selectedLinks.Clear();
    }
    else
    {
        IsCacheLimited = false;
    }

    // 3. Proceed with actual data extraction...
}
```
