# Walkthrough: Multi-Document Selection & Filtering UI

## Overview
This update provides a full multi-document filtering experience in **FilterPlus**. Instead of limiting the user to a single active document or linked instance through a drop-down ComboBox, users can now select any combination of documents (both the active host model and loaded links) to search, filter, and extract elements simultaneously.

## Changes Made

### 1. Main Window UI (`SelectionFilterView.xaml`)
- **ComboBox Replaced**: Removed the old ComboBox context selector.
- **Border Display**: Added a read-only text block wrapped in a Border styled with a `#007ACC` (primary blue) outline and white background, rendering it as a custom read-only input field.
- **Select Button**: Added a `"Select"` button to the right of the border. Its right edge aligns perfectly with the right boundary of the right-column cards and the bottom buttons.
- **ViewModel Binding**: Bound the display text block to `SelectedModelsText` and the select button to `OpenModelSelectionCommand`.

### 2. Model Selection Dialog (`ModelSelectionView.xaml` & `ModelSelectionView.xaml.cs`)
- **Modal Window**: Created a new window modal titled `"Select model or models"` with a fixed size of `500x400`.
- **Select All Checkbox**: Created a circular-styled checkbox (looks like a radio button but acts as a check) in the header to select/deselect all models.
- **Model Rows**: Placed active model and links in a list, each with a custom slide switch (`SwitchStyle`) and title.
- **Default Selection**: The host/active model is checked by default on startup.
- **Bidirectional Bindings**: Bound all toggles to a `ModelSelectionViewModel` that synchronizes individual switches with the "Select all" toggle in both directions (avoiding infinite setting loops).

### 3. ViewModel Logic (`SelectionFilterViewModel.cs` & `ModelSelectionViewModel.cs`)
- **AvailableModels**: Removed the dummy "All Models" model instance since it's now represented by the dialog's check-all toggle.
- **Properties**: Introduced `SelectedModels` list and `SelectedModelsText` property.
- **Model Switching**: Replaced the automatic dropdown changed trigger with `ApplySelectedModels(selected)` which triggers the background pre-fetching process for all selected documents combined.
- **docsToProcess Loop**: Simplified selection expansion (`ApplyIncreaseChecked`) to loop directly through all active documents in `SelectedModels`.

### 4. Revit Services (`RevitSelectionService.cs` & `PickElementsHandler.cs`)
- **GetAvailableElements**: Updated signature and collection logic. Elements are collected from the host or link documents associated with all selected model representations and returned in a consolidated list.
- **Execute (Pick Elements)**: Re-designed Revit interactive pick logic:
  - If a single link model is selected, uses `ObjectType.LinkedElement` and highlights only references from that link document.
  - If the active model or multiple models are selected, uses `ObjectType.Element` to allow selection in both active document and links, and filters references post-selection to verify they belong to the checked documents.

## Validation & Testing

### Compilation
- Compiled successfully with 0 errors targeting Revit 2024 (`dotnet build FilterPlus.csproj -c Debug.R24`).

### Visual Validation
- Checked top row alignment: The right edge of the "Select" button aligns vertically with the cards and bottom buttons.
- Tested border color: The border of the text display field uses the `#007ACC` blue color scheme correctly.
- Tested dialog buttons: The buttons in `ModelSelectionView` and `PreSelectionView` consistently show rounded corners (`CornerRadius="4"`).
