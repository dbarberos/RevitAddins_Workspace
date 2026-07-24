# Debugging Log: WPF Disabled Container Swallowing Command Execution

**Date:** 2026-07-22  
**Skill:** `revit-api`  
**UI Surface:** WPF / XAML `WrapPanel` `IsEnabled` Binding  

## 1. Symptom
Clicking a suggestion button intended to switch a RadioButton and set a property failed silently, resulting in the default RadioButton action executing instead.

## 2. Root Cause
The container panel wrapping the suggestion buttons had `IsEnabled="{Binding IsChecked, ElementName=RadioB}"`. Because `RadioB` was unchecked by default, WPF marked all child buttons as disabled. WPF swallows mouse click events on disabled controls, preventing the bound `ICommand` from executing to change `RadioB` state.

## 3. Solution Pattern
Do NOT disable action buttons that are intended to change the selection state. Keep buttons enabled so clicking them executes the command, sets the target property, and programmatically switches the RadioButton state:
```csharp
[RelayCommand]
private void SelectLevelAndMap(string levelName)
{
    SelectedTargetLevelName = levelName;
    SelectedAction = LevelMappingAction.MapToExisting; // Switches RadioButton
}
```
