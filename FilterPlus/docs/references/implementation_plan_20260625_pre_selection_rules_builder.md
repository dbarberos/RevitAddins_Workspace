# Pre-Selection Nested Rules Builder Feature

Implement a composite rules builder dialog for the "Pre-Selection" feature. Clicking the "Pre-Selection" button opens a custom dialog allowing users to create nested logical criteria using AND and OR operators recursively, matching Revit's advanced filter rules structure.

## User Review Required
> [!IMPORTANT]
> - **Composite/Recursive Structure:** Users can add single rules or entire sets. A set can contain rules and other nested sets.
> - **Color Coding (matching the image):**
>   - **AND** sets will display with green text/borders (`#3E7D3F`).
>   - **OR** sets will display with blue text/borders (`#004F8C`).
> - **Indentation & Nesting:** Every nested level automatically indents to visually represent the logical grouping.
> - **Deletion Controls:** Individual rules have a minus button (`—`). Nested sets have a delete cross button (`❌`) in their headers, except for the top-level root set.

## Proposed Changes

### Component: Models
---
#### [NEW] [IPreselRuleNode.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Models/IPreselRuleNode.cs)
Define a common interface for nodes in the rules hierarchy.
```csharp
namespace FilterPlus.Models;

public interface IPreselRuleNode
{
    PreSelectionRuleSet Parent { get; }
}
```

#### [MODIFY] [PreSelectionRule.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Models/PreSelectionRule.cs)
- Implement `IPreselRuleNode`.
- Add constructor taking `PreSelectionRuleSet parent` and `IEnumerable<ElementModel> allElements`.
- Make it a simple property-holding class (removes `IsLast` since every rule now has a delete button).

#### [NEW] [PreSelectionRuleSet.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Models/PreSelectionRuleSet.cs)
Represent a logical set containing rules and nested sets.
- Implements `IPreselRuleNode`.
- Properties:
  - `LogicalOperator` (AND/OR options)
  - `Children` (ObservableCollection of `IPreselRuleNode`)
  - `IsRoot` (Boolean, true for top-level set)
- Commands:
  - `AddRuleCommand` (Adds a rule to `Children`)
  - `AddSetCommand` (Adds a nested set to `Children`)

### Component: ViewModels
---
#### [MODIFY] [PreSelectionViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/ViewModels/PreSelectionViewModel.cs)
- Expose a `RootSet` property (type `PreSelectionRuleSet`) instead of a flat list of rules.
- Commands:
  - `RemoveRuleCommand(PreSelectionRule rule)` (Deletes a rule from its parent)
  - `RemoveSetCommand(PreSelectionRuleSet set)` (Deletes a set from its parent)
  - `ApplyCommand` (Recursively evaluates the composite rule tree against elements)

### Component: Views
---
#### [MODIFY] [PreSelectionView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Views/PreSelectionView.xaml)
Update the window resources to declare implicit `DataTemplates` for `PreSelectionRule` and `PreSelectionRuleSet`.
- **PreSelectionRule template:** Renders properties, values, and delete minus button.
- **PreSelectionRuleSet template:** Renders a Border whose BorderBrush and inner ComboBox Foreground are dynamically colored (Green for AND, Blue for OR) using DataTriggers. Renders the logical operator, Add buttons, delete set `❌` button, and an `ItemsControl` bound to `Children`.

## Verification Plan

### Manual Verification
1. Open Revit 2024, start the add-in.
2. Click "Pre-Selection" and verify the window opens.
3. Test combinations:
   - Add a rule, select "Categorías" and check distinct values.
   - Click "Add Set" and verify a nested border appears inside.
   - Switch the operator of the nested set from AND to OR and verify its border/text changes color from green to blue.
   - Try nested combinations (e.g. `Category = Walls` AND (`MEP Domain = Piping` OR `MEP Domain = Mechanical`)).
   - Click "Apply" and verify the tree view matches and updates checkmarks.
