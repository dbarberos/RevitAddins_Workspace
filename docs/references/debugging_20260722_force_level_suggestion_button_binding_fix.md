# Debugging Log: Force Level Suggestion Button UI Binding Bug

**Date:** 2026-07-22  
**Add-in:** TransferPlus  
**Component:** `LevelMappingView.xaml`, `LevelConflict.cs`, `TransferPlusViewModel.cs`  

## 1. Problem Summary
When transferring level-based views with the `Force Level in Level Base Views` option enabled, the `Missing Levels Resolution` dialog popped up. The user clicked the "Teórico Superior" (Closest Upper Level) suggestion button to map the view level. However, TransferPlus still created a brand new level in the destination file with the same name as the source level.

## 2. Root Cause Analysis
1. **Disabled Button Container**:
   In `LevelMappingView.xaml`, the suggestion buttons (`Exact Match`, `Lower Level`, `Upper Level`) were wrapped inside a `<WrapPanel IsEnabled="{Binding IsChecked, ElementName=MapRadio}">`.
   Because `CreateRadio` ("Create new level") was checked by default when the modal opened, `MapRadio` was unchecked, rendering `IsEnabled="False"` for the entire `WrapPanel`.
   WPF strictly ignores mouse click events on disabled controls, preventing `SelectLevelAndMapCommand` from executing.
2. **Action Kept at `CreateNew`**:
   Because WPF swallowed the click on the disabled button, `SelectedAction` remained `LevelMappingAction.CreateNew`. Clicking "Apply Mapping" sent `"CREATE_NEW:" + srcLevelName` to `TransferOrchestrator`, causing it to create a new level instead of mapping to the upper level.
3. **Missing Detection Scope**:
   `DetectMissingLevels` in `TransferPlusViewModel.cs` was only inspecting direct `ViewPlan` elements, missing plan views nested inside checked `ViewSheet` elements.

## 3. Solution
1. **Removed `IsEnabled` Restriction**:
   Removed `IsEnabled="{Binding IsChecked, ElementName=MapRadio}"` from the `<WrapPanel>` in `LevelMappingView.xaml`. The suggestion buttons are now always interactive.
2. **Updated Property Handlers**:
   In `LevelConflict.cs`, selecting `IsMapToExisting` or clicking a suggestion button automatically populates `SelectedTargetLevelName` and switches `SelectedAction` to `MapToExisting`.
3. **Extended Level Detection**:
   Updated `DetectMissingLevels` in `TransferPlusViewModel.cs` to inspect plan views placed on checked `ViewSheet` elements.

## 4. Verification
- Compiled clean for `.NET Framework 4.8` (`Debug.R24`) with **0 Errors**.
