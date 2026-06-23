# Implementation Plan — FilterPlus: Bug Fix (Selection & UI Gap)

## Background
Fix two issues: 
1. UI gap in the Select card was not symmetrical (15px requested).
2. 'Apply Selection' incorrectly selected all elements when nothing was checked in the tree.

## Proposed Changes

### SelectionFilterView.xaml [MODIFY]
- Increased Window `Width` to **710px**.
- Increased Right Panel `Width` to **330px**.
- Set `Padding="15,10"` on the Select card `Border` to ensure the 15px gap on both sides of the columns.

### SelectionFilterViewModel.cs [MODIFY]
- **ApplyFilter**: Removed the legacy fallback logic that applied dropdown filters when the tree selection was empty. Now, the selection in Revit strictly follows the tree's checked state. If nothing is checked, the Revit selection will be cleared.

## Verification Plan
1. Launch FilterPlus.
2. Verify the 15px gap on the left of "Current Selection" and right of the switches.
3. Uncheck all elements in the tree.
4. Press "Apply Selection".
5. Verify that Revit's selection is cleared (0 elements) instead of selecting everything.
