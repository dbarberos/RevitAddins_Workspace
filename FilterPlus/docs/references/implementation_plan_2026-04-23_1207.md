# Implementation Plan - XAML TreeView Sticky Header alignment

## Goal
Bind the "Elements | Count" table header structurally so it exactly mimics rows below it horizontally, specifically tracking against the width loss incurred when automatic WPF vertical scrollbars appear on the child items.

## Implementation details
1. Discard conventional static grids atop `TreeView` blocks in favor of mimicking the background container lines (`Border`) equipped with custom `#f0f0f0` hex coloring corresponding to typical header styling traits.
2. Injected a `HorizontalScrollBarVisibility` permanent `Visible` assignment onto the master `TreeView` control grid. This statically reserves internal sizing logic on child contents eliminating unpredictable width jumping rendering UI stutters.
3. Added a rigid `Margin="0,0,10,0"` right offset to the header border grid synchronizing physical screen pixels exactly inline with the `VerticalScrollBarWidth` properties implemented earlier.
4. Assigned `BorderBrush` mapping downward with `#d0d0d0` to establish the clear "grey separator line" explicitly distinguishing titles from active elements.
