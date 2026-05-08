# Walkthrough: "Use Regex" Advanced Search Integration

## What was built
The "Use Regex" feature allows power users to perform complex hierarchical searches within the Revit model.

### Key Features
1. **Advanced Queries**: Users can now use patterns like `^Muro` (starts with) or `\bMark\d+\b` (precise mark patterns).
2. **Robustness**: The engine includes a **2-second timeout** and syntax validation to ensure Revit never crashes due to malformed user input or malicious patterns (ReDoS).
3. **Deep Search Integration**: When combined with "Only by name" OFF, the Regex scans internal parameters like Comments, Marks, and Level Constraints.
4. **Live Selection & OR Logic**: Fully compatible with existing real-time selection and additive (OR) search modes.

## Technical Validation
- **Regex Performance**: Evaluated node-by-node with pre-compiled patterns.
- **Error Handling**: Validated that `(invalid_regex` pattern displays "Invalid Regex Pattern" in the UI status bar without exceptions.
- **UI Refresh**: Confirmed that toggling switches correctly updates the search context for the next "Apply" click.

## Verification Result
- [x] Project compiled with 0 errors.
- [x] Functional testing confirmed Regex matches against Categories, Types, and Element IDs.
