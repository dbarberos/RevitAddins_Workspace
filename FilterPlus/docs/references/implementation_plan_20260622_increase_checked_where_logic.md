# Implementation Plan - Update 'Where' Logic, Selection Merging, and Revit 2024 Target

This plan resolves the issue where "Increase Checked" does not update the explorer tree when running inside Revit 2024, fixes a selection-merging bug where checked items from other scopes were discarded, and adds a third domain option: "Visible in current view".

## User Review Required

> [!IMPORTANT]
> **Revit 2024 Environment**: The active installation on the developer machine is **Revit 2024**. Target compilation is set to `Debug.R24` deploying to the `2024` add-in directory.
>
> **Visible in current view**: Adds a third option to "WHERE". It filters elements only to those that are visible in the active view (corresponding to `SelectionScope.ElementsVisibleInView` or `FilteredElementCollector(doc, doc.ActiveView.Id)`).

## Proposed Changes

### FilterPlus Add-in

#### [MODIFY] [SelectionFilterView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Views/SelectionFilterView.xaml)

1. Add a new `RadioButton` in the "WHERE" StackPanel:
   ```xml
   <RadioButton Content="Visible in current view" IsChecked="{Binding IncreaseWhereVisibleInView}" GroupName="WhereGroup" Margin="0,0,0,6" FontSize="11"/>
   ```

#### [MODIFY] [SelectionFilterViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/ViewModels/SelectionFilterViewModel.cs)

1. **Add Property**:
   `[ObservableProperty] private bool _increaseWhereVisibleInView;`

2. **Conditional Query for Domain Elements**:
   Add the condition to query only elements visible in the active view when `IncreaseWhereVisibleInView` is true:
   ```csharp
   if (IncreaseWhereVisibleInView)
   {
       var visibleCollector = new Autodesk.Revit.DB.FilteredElementCollector(doc, doc.ActiveView.Id);
       domainElements = visibleCollector.WhereElementIsNotElementType().ToElements().ToList();
   }
   ```

3. **Preserve Checkmarks in Other Scopes**:
   In `ApplyIncreaseChecked()`, retrieve `idsFromOtherScopes` and merge them into `finalCheckedIds` before updating `_persistentCheckedIds`.

---

## Verification Plan

### Manual Verification
1. **Scope: Current Selection -> Where: Visible in current view**:
   - Select a Wall in Revit 2024.
   - Run "Increase Checked" -> "What: Hosted Elements" -> "Where: Visible in current view".
   - Verify that only hosted windows visible in the active view are added/checked.
   - Verify that debug logs appear in the log window.

### Automated Verification
- Run `dotnet build -c Debug.R24` to compile and deploy to the Revit 2024 Addins directory.
