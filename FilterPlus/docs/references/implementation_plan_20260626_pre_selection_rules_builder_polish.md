# Pre-Selection Nested Rules Builder - Polish & Sorting Plan

This plan addresses visual and layout organization refinements requested for the Pre-Selection Rules Builder.

## User Review Required

> [!IMPORTANT]
> - **Visual Delete Buttons (Red Emojis):**
>   - **Set deletion:** Revert to the native red glossy `❌` emoji (using a completely transparent borderless button).
>   - **Rule deletion:** Change from the plain red dash/hyphen to the red glossy `❌` emoji. This makes the UI elements cohesive, colorful, and visually appealing.
> - **Coherent Element Grouping:**
>   - Rules (`PreSelectionRule`) will always be kept at the top of a set's list.
>   - Sub-sets (`PreSelectionRuleSet`) will always be placed at the bottom.
>   - When a user adds new rules or sets, they will automatically be inserted at the correct position (rules after the last existing rule, sets at the end of the collection) to prevent a mixed, disorganized layout.

## Proposed Changes

### Component: Models

---

#### [MODIFY] [PreSelectionRuleSet.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Models/PreSelectionRuleSet.cs)
- Introduce a helper method `AddNode(IPreselRuleNode node)`:
  - If the node is a `PreSelectionRule`, insert it after the last rule (at index equal to `Children.Count(c => c is PreSelectionRule)`).
  - If the node is a `PreSelectionRuleSet`, add/append it at the end of the collection.
- Refactor the `AddRule()` and `AddSet()` relay commands to call `AddNode(node)` instead of adding to `Children` directly.

### Component: ViewModels

---

#### [MODIFY] [PreSelectionViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/ViewModels/PreSelectionViewModel.cs)
- Update the constructor initialization where the default rule is added: change from `RootSet.Children.Add(defaultRule)` to `RootSet.AddNode(defaultRule)` to follow the uniform insertion logic.

### Component: Views

---

#### [MODIFY] [PreSelectionView.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Views/PreSelectionView.xaml)
- **PreSelectionRule template:** Update the rule delete button's content to the `❌` emoji, and ensure it inherits the transparent, borderless style.
- **PreSelectionRuleSet template:** Change the set delete button's content back to the `❌` emoji, keeping its transparent, borderless style.

## Verification Plan

### Manual Verification
1. Verify Revit 2024 is closed before building.
2. Compile the add-in using `dotnet build FilterPlus.csproj -c Release.R24`.
3. Open Revit 2024, start the FilterPlus add-in, and open the "Pre-Selection" builder.
4. Verify the deletion buttons show as the red `❌` emoji.
5. Add multiple rules and sets in different sequences. Verify that rules always cluster at the top and sets always sit at the bottom.
6. Apply filters and confirm everything works seamlessly.
