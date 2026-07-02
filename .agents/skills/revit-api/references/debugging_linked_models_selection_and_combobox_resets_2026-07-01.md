# Debugging: WPF ComboBox resets and Revit Multi-Model selection tracking

## Symptoms

1. **WPF ComboBox binding loss of selected value**: When modifying logical Pre-Selection rules (like choosing a Category or Family), WPF's ComboBox binding automatically triggered updates that cleared sibling/child values or threw selection-changed exceptions.
2. **Revit multi-document selection coordination collisions**: Attempting to track elements from host and linked models using raw `ElementId`s led to collisions (duplicate IDs across documents) and silent failures when applying selections in the Revit viewport.
3. **UI Thread Blocking Overlay & Animation Freeze**: Setting `IsBusy = true` was immediately followed by raising Revit external events or running synchronous CPU-intensive tree builds. This blocked the main thread before WPF's dispatcher had a chance to render the visibility change, preventing the loading overlay from appearing. Furthermore, any active WPF Storyboard animations (like spinner rotations or indeterminate progress bars) were shown frozen because the UI thread was completely occupied by the synchronous operations, preventing new frames from rendering.

---

## Root Causes

1. **ComboBox resets**: Sibling list property updates (e.g. changing the list of families available based on a new category) dynamically reset WPF binding targets to `null` because the old value was briefly not found in the newly-generated list.
2. **Element ID Collisions**: In Revit, `ElementId` values are only unique inside a specific `Document`. When loading elements from linked files, matching elements on ID alone caused target conflicts, resulting in checked elements disappearing or mapping to wrong items in the explorer tree.
3. **Main Thread Blocking & Animation Freeze**: Revit and modeless WPF windows share the same single-threaded main execution context. Raising external events or building trees immediately blocks execution. Visual state changes (like showing a spinner overlay) queued on the Dispatcher are never drawn unless pumped. Additionally, because WPF animations (Storyboards/DoubleAnimations) require continuous UI thread loops to update property values and redraw frames, they freeze entirely while a synchronous Revit API or tree rebuilding block executes.

---

## Solutions

### 1. Guard ComboBox collections and perform Cascading Pruning
Add state flags (`_isUpdatingBinding`) to ignore binding-driven selections during list rebuilds, and implement explicit cascading rule pruning. When a parent rule changes (e.g. Category), manually delete or nullify dependent sibling selections (e.g. Family and Type) instead of relying on WPF binding resets.

### 2. Composite Element Selection Keys
Use `ElementSelectionKey` to uniquely identify elements across multiple documents:
```csharp
public struct ElementSelectionKey : IEquatable<ElementSelectionKey>
{
    public ElementId ElementId { get; }
    public ElementId LinkInstanceId { get; }

    public ElementSelectionKey(ElementId elementId, ElementId linkInstanceId)
    {
        ElementId = elementId;
        LinkInstanceId = linkInstanceId;
    }
}
```

Implement the selection check by mapping link references using coordinate-transformed references in the host context:
```csharp
var refInLink = new Reference(linkedElement);
var hostRef = refInLink.CreateLinkReference(linkInstance);
refs.Add(hostRef);
```
Select all references simultaneously:
```csharp
_uiDoc.Selection.SetReferences(refs);
```

### 3. Pump Dispatcher & Static Status Card Design
*   **Dispatcher Pump**: Force a synchronous UI layout update and render pass by pumping the thread's Dispatcher queue at `Background` priority immediately after setting `IsBusy = true`:
    ```csharp
    IsBusy = true;
    System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke(
        System.Windows.Threading.DispatcherPriority.Background,
        new Action(delegate { }));
    ```
    This processes the visibility change of the loading overlay before executing the heavy synchronous blocks.
*   **Static Status Card**: Since Storyboard animations cannot render while the UI thread is blocked, do not use spinning SVGs or indeterminate progress bars. Instead, design a static, compact status card. Bind its text to a dynamic `StatusMessage` (e.g. *"Switching model context..."*, *"Rebuilding tree explorer..."*) to give the user immediate visual feedback of the current task. This behaves reliably, looks highly professional, and prevents the add-in from appearing crashed or frozen.
