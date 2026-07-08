# Debugging Revit Add-in: WPF Dispatcher Null Reference & Topmost Dialog Parenting

**Date:** 2026-07-07  
**Symptoms:**  
1. Saving a selection (e.g. "BLANK") causes the saving progress overlay ("Saving selection... Please wait a moment...") to freeze the WPF window indefinitely, although Revit logs show the background transaction committing and writing data successfully.
2. Modals like `SaveSelectionView` or confirmation/Yes-No dialogs appear behind the main `Topmost` WPF window, rendering the application unresponsive (frozen) because the active dialog is hidden.

**Root Causes:**
1. **Application.Current is Null in Revit Context:** In Revit add-ins, WPF's `System.Windows.Application.Current` is frequently `null` or behaves unexpectedly because Revit acts as the primary Win32 host process instead of running a standard WPF Application loop. Using `System.Windows.Application.Current?.Dispatcher.BeginInvoke(...)` short-circuits silently via the `?.` null-conditional operator, preventing callbacks that reset state (like `IsBusy = false`) from running on the UI thread.
2. **Topmost Conflict with Native Dialogs:** When a modeless WPF window uses `Topmost="True"`, displaying a native Revit API `TaskDialog` (which runs outside WPF window hierarchy) throws the dialog *behind* the WPF topmost window.
3. **Loss of Modal Window Ownership:** If two windows are set to `Topmost="True"` (e.g., `SelectionFilterView` and a child modal `SaveSelectionView`) and their parent-child `Owner` property is not explicitly set, they fight for z-order focus, often causing the child modal to pop underneath.

**Solution (Pattern):**
1. **Capture Local UI Dispatcher:** Capture the UI thread's dispatcher using `System.Windows.Threading.Dispatcher.CurrentDispatcher` directly from a UI thread context *before* executing background events (e.g. inside a command handler). Use the captured `uiDispatcher` variable to marshal asynchronously back to WPF.
   ```csharp
   // Capture on the UI thread
   var uiDispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
   
   _actionHandler.Raise(() => {
       // background Revit API logic
       
       uiDispatcher.BeginInvoke(new Action(() => {
           // Safe UI thread updates
           IsBusy = false;
       }));
   });
   ```
2. **WPF Window Parenting fallback:** Explicitly query the active WPF window list to find the parent, link the `Owner` property, and configure startup centering on the owner.
   ```csharp
   if (System.Windows.Application.Current != null)
   {
       var owner = System.Windows.Application.Current.Windows
           .OfType<System.Windows.Window>()
           .FirstOrDefault(w => w is Views.SelectionFilterView && w.IsVisible);
       
       if (owner == null)
       {
           owner = System.Windows.Application.Current.Windows
               .OfType<System.Windows.Window>()
               .FirstOrDefault(x => x.IsActive);
       }
       if (owner != null)
       {
           view.Owner = owner;
           view.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
       }
   }
   ```
3. **Replace TaskDialog with MessageBox in WPF Views:** Switch `TaskDialog.Show` to `System.Windows.MessageBox.Show` inside WPF context, passing the parent WPF `Window` object. This correctly maps the z-order and topmost state.
   ```csharp
   var ownerWin = windowObj as System.Windows.Window;
   var res = System.Windows.MessageBox.Show(
       ownerWin,
       "Save the Selection?", 
       "FilterPlus", 
       System.Windows.MessageBoxButton.YesNo, 
       System.Windows.MessageBoxImage.Question);
   ```
