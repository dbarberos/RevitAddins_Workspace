# Debugging & Architecture Report: Sequential Accumulative Renaming & Empty Replacement

## 1. Problem Description & Intent
In Revit addin renaming tools, users frequently need multi-pass sequential operations (e.g. Pass 1: Replace "Doors" with "D", Pass 2: Append "_V1", Pass 3: Remove term "OLD").
Two main challenges arise:
1. **Name Reset Bug**: If transformations are evaluated directly from `OriginalName` on every keypress, executing a second operation overwrites the results of the first operation.
2. **Empty String Replacement / Button Disable Lock**: Standard `CanExecute` validation checks `!string.IsNullOrWhiteSpace(RenameReplaceText)`. This prevents replacing matched text with nothing (empty string `""` to remove a term from the string).

## 2. Root Cause
- **Direct Evaluation against `OriginalName`**: Lacking an in-memory `WorkingName` property forced preview calculations to reset from `OriginalName`.
- **Global CanExecute Rule**: `CanExecute` relied solely on `!string.IsNullOrWhiteSpace(RenameReplaceText)`, rendering the Apply button disabled whenever the target replacement box was empty.

## 3. Technical Solution Architecture

### A. Intermediate Working Memory State (`WorkingName`)
Add a `WorkingName` property to the table item viewmodel, initialized to `OriginalName`:

```csharp
public partial class RenamePreviewItem : ObservableObject
{
    [ObservableProperty]
    private string _workingName = string.Empty;

    public string OriginalName { get; init; }

    public RenamePreviewItem(ElementId sourceId, string originalName)
    {
        SourceId = sourceId;
        OriginalName = originalName;
        WorkingName = originalName;
        NewName = originalName;
    }
}
```

### B. Segregation of Match Filter vs Replacement Base
In `UpdateRenamePreviews()`:
- **`isMatch`**: Evaluated strictly against **`item.OriginalName`** so light blue row highlights remain predictable.
- **Replacement & Formatting**: Performed taking **`item.WorkingName`** as the input base string.

```csharp
foreach (var item in RenamePreviewItems)
{
    // Filter matching strictly checks OriginalName
    bool isMatch = !string.IsNullOrEmpty(RenameSearchText) && regex.IsMatch(item.OriginalName);
    item.IsMatchingFilter = isMatch;

    if (!item.IsSelected)
    {
        item.NewName = item.WorkingName;
        continue;
    }

    // Transformations operate on top of WorkingName
    string newName = item.WorkingName;
    if (isMatch)
    {
        newName = regex.Replace(item.WorkingName, evaluatedReplaceText);
    }
    item.NewName = newName;
}
```

### C. Explicit State Flag for Empty Replacements (`_isReplaceEmptyAllowed`)
To allow replacing a matched term with empty string `""` without keeping the Apply button permanently enabled:

1. Maintain an internal `_isReplaceEmptyAllowed` boolean field in the main ViewModel.
2. When the user selects the `(no text / vacio)` helper option in the popup, set `_isReplaceEmptyAllowed = true` and call `NotifyCanExecuteChanged()`.
3. In `CanApplyRenameReplace()`, check `!string.IsNullOrWhiteSpace(RenameReplaceText) || _isReplaceEmptyAllowed`.
4. In `ApplyRenameReplace()`, commit `item.WorkingName = item.NewName`, reset `_isReplaceEmptyAllowed = false`, clear input text boxes, and call `NotifyCanExecuteChanged()`.

```csharp
private bool _isReplaceEmptyAllowed;

private bool CanApplyRenameReplace() => !string.IsNullOrWhiteSpace(RenameReplaceText) || _isReplaceEmptyAllowed;

[RelayCommand(CanExecute = nameof(CanApplyRenameReplace))]
private void ApplyRenameReplace()
{
    foreach (var item in RenamePreviewItems)
    {
        if (item.IsSelected)
        {
            item.WorkingName = item.NewName;
        }
    }

    _isReplaceEmptyAllowed = false;
    RenameSearchText = string.Empty;
    RenameReplaceText = string.Empty;
    ApplyRenameReplaceCommand.NotifyCanExecuteChanged();
    UpdateRenamePreviews();
}
```

## 4. Key Takeaway & Rule
For multi-pass string manipulation UI panels:
- Use `WorkingName` to accumulate transformations across `Apply` operations while keeping `OriginalName` intact for original filter matching.
- Use explicit per-operation flags (`_isReplaceEmptyAllowed`) to allow empty string replacements while automatically disabling the Apply button after execution.
