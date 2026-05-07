# Goal Description
The objective was to activate the 3rd switch (previously "Mockup 2") and transform it into an advanced "Use Regex" mode. When enabled, the search text is evaluated as a Regular Expression, allowing complex queries (e.g., `^Wall.*`, `(100|200)$`). This mode is fully compatible with "Use OR" and "Only by name" switches.

## Technical Details
- **Safety**: Implemented a 2-second timeout (`TimeSpan.FromSeconds(2)`) to prevent ReDoS (Regular Expression Denial of Service) attacks.
- **Error Handling**: Wrapped Regex compilation and evaluation in `try-catch` blocks. Syntax errors are caught and reported in the StatusMessage without crashing Revit.
- **Sanitization**: Bypassed standard input sanitization for Regex mode to allow special characters like `^`, `$`, `<`, `>`.

## Proposed Changes
### ViewModel Layer
- Renamed `_isMockup3` to `_isUseRegex`.
- Updated `ApplySearch()` to handle Regex compilation and error reporting.
- Updated `FilterNode()` to support both standard and Regex matching.

### View Layer
- Updated `SelectionFilterView.xaml` checkbox text to "Use Regex" and updated data binding.
