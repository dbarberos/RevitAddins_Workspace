# Implementation Plan - Restoring UI for Development (Logs & Full Filters)

The goal is to reactivate the UI elements that were hidden for the initial App Store submission, specifically the **Debug Log window** and the **"Add Checked" card** (mockup switches).

## User Review Required

> [!NOTE]
> As requested, the obsolete "Quick Filters" (ComboBoxes) will **not** be restored, as they have been superseded by the switch-based logic.

## Proposed Changes

### 1. Main View Code-Behind
#### [MODIFY] SelectionFilterView.xaml.cs
- Uncomment `_logView.Show()` to ensure the debug window opens on startup.

### 2. Main View XAML
#### [MODIFY] SelectionFilterView.xaml
- **"Add Checked" Card**: Verify and ensure the `Visibility` property is set to `Visible`.
- **Layout Optimization**: Ensure the right column grid and window height allow the card to be displayed correctly.
- **Column Alignment**: Sync columns with the "Select" card using `SharedSizeGroup`.
