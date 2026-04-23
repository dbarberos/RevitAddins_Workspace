# Implementation Plan - TreeView Full Width Styling and ThreeState CheckBox Interception

## Bug Description
1. The cascade selection logic failed because of infinite loop exceptions disrupting WPF bindings (`InvalidOperationException` via `Nullable<bool>.Value`).
2. WPF `TreeViewItems` naturally staggered margins to the right, causing left-sided background highlighting to appear staircase-shaped instead of full-row bands.
3. Users clicking a `True` TreeView node when `IsThreeState="True"` caused the checkbox to enter `Null` state explicitly, breaking the logical UX cyclic toggling (True/Null -> False, False -> True).

## Proposed Changes
1. Rewrite WPF TreeItemViewModel.cs `ReevaluateState()` logic: wrap it inside conditional flags `_isUpdatingState` to block `null` invalid bindings and double recursion loops.
2. Formulate explicit `ControlTemplate` inline for `TreeViewItem` within XAML: Stripping all parent margin gaps and generating indentation margins manually based on physical tree depths retrieved from the ViewModel.
3. Update ViewModel `IsChecked` setter to actively intercept WPF cyclic ThreeState clicking: if user commands a direct transmission from `True` to `Null`, hijack the command and force transition to `False`.
