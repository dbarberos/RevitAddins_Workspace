# Implementation Plan — FilterPlus: Select Panel UI Enhancement (Symmetry Update)

## Background
The user wants to fine-tune the "Select" panel layout for perfect symmetry and a more compact window.

## Proposed Changes

### SelectionFilterView.xaml [MODIFY]
- Reduced total Window `Width` from 700 to **675px**.
- Reduced right panel column `Width` from 320 to **295px**.
- Adjusted the "Select" card inner grid:
  - Set `HorizontalAlignment="Center"` on the inner grid to ensure equal margins on the left and right sides of the card.
  - Replaced stretching columns (`*`) with compact columns (`Auto`).
  - Set a fixed **20px** spacer between the two columns (50% reduction from previous implicit spacing).

## Verification Plan
1. Launch FilterPlus.
2. Verify that the window is slightly narrower.
3. Verify that the "Select" card content is perfectly centered within its border.
4. Verify the 20px gap between the radio buttons and switches.
