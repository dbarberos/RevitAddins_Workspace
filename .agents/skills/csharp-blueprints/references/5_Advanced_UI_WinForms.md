# Guide 5: Advanced Form Design (WinForms and ListView)

This guide covers separating the graphical user interface (Front-end) from the plugin's core database commands (Back-end) using `System.Windows.Forms`. It covers building standard form results wrappers, designing responsive UI layouts, using ListViews with robust backend data caches, and implementing interactive async progress bars that don't freeze the host application.

## 1. The Result Wrapper: `FormResult<T>`

Before creating visual forms, you need a standardized way to process their outcomes. A common mistake is reading selection values directly from form controls, which causes a crash if the user simply closes the form by clicking the "X" button.

**Best Practices:**
*   Create a generic wrapper class `FormResult<T>` that tracks whether the form was validated, if it was cancelled, and what objects it returns.
*   The form should always initialize assuming it was **cancelled**. Only toggle it to validated when the user actively clicks "OK" or "Apply".

**Code Example: FormResult Structure**

```csharp
public class FormResult<T> 
{ 
    public T Object { get; set; } 
    public List<T> Objects { get; set; } 
    public bool Cancelled { get; set; } 
    public bool IsValid { get; set; } 

    // Assume form was cancelled by default 
    public FormResult() 
    { 
        this.Cancelled = true; 
        this.IsValid = false; 
    } 

    // Validate and store the result when the user clicks "OK" 
    public void Validate(T obj) 
    { 
        this.Object = obj; 
        this.Cancelled = false; 
        this.IsValid = true; 
    } 
}
```

---

## 2. Selection Forms (ComboBoxes) and Responsive Layouts

When using Visual Studio's drag-and-drop designer to build Windows Forms, you will face class name collisions and scaling issues.

**Resolving Class Name Collisions:**
Revit has its own native class named `Form` (for structural/mass geometry) and Windows uses `System.Windows.Forms.Form`. In your form's code-behind file (`.cs`), you must explicitly define which class to use by declaring an alias:

```csharp
using Form = System.Windows.Forms.Form; // Resolves naming conflict
```

**Responsive Layouts with TableLayoutPanel:**
To prevent your interface from stretching awkwardly on 4K monitors or when resized, never use absolute control coordinates. Instead, drag a `TableLayoutPanel` into the designer, define cell heights/widths using percentages or fixed pixels, and set the control `Dock` properties to `Fill`.

**Using the Tag Property:**
When the user clicks "OK", you can store the selected item in the form's native `.Tag` property to pass it back to your calling command block safely.

---

## 3. Advanced ListViews with Backend Cache Classes

A `ListView` is ideal for displaying lists of sheets, views, or families. Ensure you set `View = View.Details` so it renders as a clean tabular grid rather than giant desktop icons.

**The Filter Persistence Problem:**
If you implement a search box to dynamically filter list elements, a native `ListView` will lose the checked state of any item that becomes hidden as the list is reconstructed.

**The Solution: The `KeyedValue` Cache Pattern**
You must decouple the UI controls from your state data by keeping a permanent backend list of cache objects to track checking states independently.

**Code Example: KeyedValue Wrapper Class**

```csharp
public class KeyedValue<T> 
{ 
    public string ItemKey { get; set; } // Visual text (e.g. "A101 - Sheet") 
    public T ItemValue { get; set; } // Underlying Revit object (e.g. ViewSheet) 
    public int ItemIndex { get; set; } // Original list position 
    public bool Visible { get; set; } // Whether it passes active text search 
    public bool Checked { get; set; } // User selection state 

    public KeyedValue(string key, T value, int index) 
    { 
        ItemKey = key; 
        ItemValue = value; 
        ItemIndex = index; 
        Visible = true; 
        Checked = false; 
    } 
}
```

When search box text changes, update the `Visible` property of your `KeyedValue` items and rebuild the UI `ListView` controls using only items where `Visible == true`, making sure to restore checkboxes for items with `Checked == true`.

---

## 4. Progress Bars and Asynchronous UI Repainting

Iterating over hundreds of elements will freeze Revit. An interactive progress bar fixes this and allows the user to cancel operations mid-run.

**Forcing Asynchronous UI Repainting (`DoEvents`):**
Because the Revit API locks the main execution thread, the progress bar window will freeze visually. You must call `System.Windows.Forms.Application.DoEvents()` on each iteration cycle to force Windows to redraw the UI.

**The WinForms Progress Bar Retrack Bug:**
The Windows progress bar animates with a slight delay, making it look sluggish and preventing it from instantly reflecting a `100%` complete state. To force an instant visual update, increment the progress slightly above, then decrease it, and restore it.

**Code Example: Safe Progress Loop**

```csharp
using System.Windows.Forms; 

public void IncrementProgress() 
{ 
    this.ProgressCount++; // Increment count 

    // Hack to correct the Windows Progress Bar animation lag 
    if (this.ProgressCount > 1 && this.ProgressCount <= this.Total) 
    { 
        this.ProgressBarObj.Value = this.ProgressCount; 
        this.ProgressBarObj.Value = this.ProgressCount - 1; 
        this.ProgressBarObj.Value = this.ProgressCount; 
    } 

    // Force the visual window to repaint even while Revit is busy 
    Application.DoEvents(); 
}
```

If the user clicks "Cancel", raise a flag: `this.Cancelled = true`. In your main Revit command block, query this flag after calling `IncrementProgress()`. If `true`, call `transaction.RollBack()` to safely undo modifications.
