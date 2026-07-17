# Walkthrough: TransferPlus Rename Input Security Hardening

## Overview
A security evaluation was performed on the rename and numbering settings views of TransferPlus to ensure user-supplied input fields are resilient against Denial of Service (DoS) attacks, such as Regular Expression Denial of Service (ReDoS) and OutOfMemoryException crashes.

## Changes Implemented

1. **ReDoS Defense in Rename Search**
   - **Flaw:** The regex-based "Find" pattern did not specify a timeout, allowing backtracking patterns (e.g. `(a+)+`) to hang the Revit execution context thread.
   - **Fix:** In `TransferPlusViewModel.cs`, all `new Regex(..., options)` instantiations processing user-defined searches were updated to specify a 500 ms timeout:
     ```csharp
     regex = new Regex(RenameSearchText, options, TimeSpan.FromMilliseconds(500));
     ```

2. **DoS Protection against Large Padding/String Allocations**
   - **Flaw:** The user-supplied custom variables in "Changed by:" allows `${padding=X}` or `${rstringalpha=Y}`. If extremely high numbers (e.g. `200000000`) were supplied, the string allocation logic would trigger an `OutOfMemoryException` crash in Revit.
   - **Fix:** Upper limits of **100** characters were introduced using clamping functions for the padding and length arguments:
     ```csharp
     padding = Math.Min(Math.Max(0, val), 100);
     length = Math.Min(Math.Max(0, length), 100);
     ```

3. **Revit API Safety Evaluation**
   - The rename transactions in Revit were confirmed secure. Modifying Revit database element names is not vulnerable to SQL Injection or Script Execution. Potential formatting/illegal naming exceptions (e.g., trying to name a parameter with forbidden characters like `:` or `\`) are securely trapped in structured `try-catch` blocks, preventing application crashes.

## Validation and Compilation
The project successfully compiles in Revit 2024 configurations when Revit is closed to free the assembly lock.
