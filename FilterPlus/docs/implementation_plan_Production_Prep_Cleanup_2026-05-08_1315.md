# Implementation Plan: Production Preparation & UI Cleanup

## Goal Description
Prepare the FilterPlus add-in for production release by removing redundant UI elements and hiding debug-only features to provide a cleaner user experience.

## Proposed Changes

### [SelectionFilter View]

#### [MODIFY] [SelectionFilterView.xaml.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Views/SelectionFilterView.xaml.cs)
- Comment out the `_logView.Show()` call to hide the debug log window by default.

#### [MODIFY] [SelectionFilterView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Views/SelectionFilterView.xaml)
- Remove the `ScrollViewer` containing the Category, Family, Type, Level, and Workset dropdowns.
- Update the right column `Grid.RowDefinitions` to eliminate the now-empty third row.

## Verification Plan

### Manual Verification
- Launch Revit and verify that the Debug Log window does NOT appear.
- Verify that the Right Column only shows the "Filter" and "Select" cards.
- Verify that the space between the cards and the bottom buttons is correctly balanced.
