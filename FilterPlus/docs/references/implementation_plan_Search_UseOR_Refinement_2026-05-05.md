# UI Cleanup, Deep Search and Stability Fixes

## Problem: AccessViolationException
During the implementation of "Deep Search", iterating through all parameters of all model elements caused an `AccessViolationException` in Revit. This happened because some internal or corrupted elements cannot have their parameters safely iterated.

## Proposed Changes (Implemented)
1. **Remove Search Clear Button**: Simplified the search row.
2. **Realign Toggles**: Grouped switches to the left using a `StackPanel`.
3. **Safe Deep Search**:
   - Instead of iterating all parameters, we specifically fetch:
     - `ALL_MODEL_MARK`
     - `ALL_MODEL_INSTANCE_COMMENTS`
     - `ALL_MODEL_TYPE_MARK`
     - `ALL_MODEL_TYPE_COMMENTS`
     - `LevelName` (as base constraint)
   - Wrapped extraction in `try-catch` to ensure stability.
4. **Data Propagation**: Ensure leaf nodes carry `SearchableMetadata` for the `FilterNode` logic.
