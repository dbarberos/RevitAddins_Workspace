# Lesson Learned: ReDoS and Memory Deserialization/Formatting Hardening in WPF/Revit Add-ins

## Context
When building Revit Add-ins, developers often allow users to execute search-and-replace queries using Regular Expressions (Regex) or template parameters that are expanded recursively. Insecurely handled regex and template parameters can easily allow Denial of Service (DoS) conditions that crash the entire host Revit process.

## Vulnerabilities & Root Causes

### 1. Regular Expression Denial of Service (ReDoS)
- **Problem:** Allowing users to directly supply the pattern to `new Regex(userInput)` without a timeout. A malicious or accidental catastrophic backtracking regex (e.g. `(a+)+` against a long name of `aaaa...aaab`) causes the main execution thread to hang.
- **Root Cause:** In C#, `Regex` executes with no timeout by default, blocking the UI thread in WPF and eventually causing the user to force-close Revit.

### 2. Allocation Deserialization / Out of Memory Exceptions (OOM)
- **Problem:** User-supplied variables inside formatting templates (like `${padding=100000000}`) that dictate sizing limits.
- **Root Cause:** Code executing allocations like `string.PadLeft(padding)` or `new char[length]` will try to reserve gigabytes of heap memory instantly, crashing Revit with an unhandled `OutOfMemoryException`.

## Security Resolution & Hardening Patterns

### ReDoS Protection:
Always define a short timeout (e.g. 200 ms to 2 seconds) when compiling a user-provided Regex:
```csharp
try
{
    // Restricting execution duration to 500 milliseconds
    var safeRegex = new Regex(userInputPattern, options, TimeSpan.FromMilliseconds(500));
    bool isMatch = safeRegex.IsMatch(targetString);
}
catch (RegexMatchTimeoutException)
{
    // Log and handle timeout gracefully
}
```

### Allocation Guardrails (Input Clamping):
Enforce limits on numeric variables that govern string generation or array allocations before using them:
```csharp
// Clamp input size parameter to a maximum of 100 characters
int safePadding = Math.Min(Math.Max(0, userPaddingValue), 100);
string formattedValue = rawValue.PadLeft(safePadding, '0');
```
Clamping ensures that even if users write or generate large numbers in inputs, the application safely degrades to a harmless limit.
