# Guide 6: Scalability, Interoperability, and Version Control

This guide covers structuring your code so that it handles multiple Revit API versions gracefully, implements dynamic Ribbon command availability, integrates with external spreadsheets (Excel) via third-party NuGet packages, and maintains ultra-fast execution times using C# Dictionary lookups.

## 1. Handling Multiple Revit API Versions (Revit 2024+)

The Revit API evolves annually, with new methods being introduced and older ones deprecated. For instance, in Revit 2024+, retrieving the integer value of an `ElementId` via `IntegerValue` is deprecated in favor of `Value` (which returns a 64-bit `long` value).

**Best Practices: Preprocessor Directives**
Using Nice3point templates automatically configures build targets (e.g., `Release R24`, `Release R25`). You can use `#if` preprocessor directives to compile version-specific code paths depending on the build target.

**Code Example: Multi-version ElementId Extension Method**

```csharp
public static class ElementIdExt 
{ 
    // Unified method to retrieve the numerical value of an ElementId regardless of Revit version 
    public static long GetIdValue(this ElementId elementId) 
    { 
        if (elementId == null) return -1; 

        // Compiled ONLY when targeting Revit 2024, 2025, or 2026 
        #if Revit2024 || Revit2025 || Revit2026 
        return elementId.Value; 
        // Compiled ONLY when targeting Revit 2023 or older 
        #else 
        return elementId.IntegerValue; 
        #endif 
    } 
}
```

---

## 2. Dynamic Command Availability

Allowing users to execute a command (e.g., "Modify Worksets") when they are in a Family Document is bad UX and will trigger runtime errors. You should actively disable (gray out) the button in these contexts.

**Best Practices:**
*   Implement the `IExternalCommandAvailability` interface.
*   **Golden Rule**: The `IsCommandAvailable` method is queried constantly in the background by Revit whenever the user moves the mouse or selects items. **Under no circumstances should you run heavy queries, transactions, or element collectors here**. It must be a simple, fast boolean check.

**Code Example: Disabling Buttons in Family Documents**

```csharp
using Autodesk.Revit.DB; 
using Autodesk.Revit.UI; 

public class AvailabilityProjectOnly : IExternalCommandAvailability 
{ 
    public bool IsCommandAvailable(UIApplication uiApp, CategorySet selectedCategories) 
    { 
        if (uiApp.ActiveUIDocument == null) return false; // No document open 
        Document doc = uiApp.ActiveUIDocument.Document; 
        
        // Command is available only if the active document is NOT a Family document 
        return !doc.IsFamilyDocument; 
    } 
}
```

*Practical Usage: In your `Application.cs` (`OnStartup`), bind this availability rule to the button by setting the `AvailabilityClassName` property of the `PushButtonData` class.*

---

## 3. Excel Interoperability and NuGet Packages

To read or write Excel files, the C# ecosystem relies on NuGet package management to install open-source libraries.

**Best Practices (ClosedXML Library):**
*   Use `ClosedXML` rather than native Office Interop. `ClosedXML` processes spreadsheets in memory much faster without requiring MS Excel to be installed on the user's computer.
*   NuGet dependencies (external DLLs) will be downloaded and copied to your Add-in's output folder. To avoid "DLL Hell" (where different add-ins load different versions of the same DLL and crash Revit), compile them carefully.
*   **Safe File Opening**: Before trying to read spreadsheet data, verify the spreadsheet is not already open in another program by opening a `FileStream` using `FileShare.Read` in a `try-catch` block.

---

## 4. Extreme Performance with Dictionaries

When comparing Revit model elements with Excel spreadsheet rows (e.g., matching model sheets to Excel table rows), using nested `foreach` loops with `.Where()` queries creates an exponential algorithmic complexity of O(N^2). As the model scales, this causes unacceptable lag.

**The O(1) Solution:**
Using a **Dictionary** (`Dictionary<TKey, TValue>`) resolves this by organizing data using hash tables. Querying a dictionary is practically instantaneous (O(1)) whether it contains 100 or 100,000 sheets.

**Code Example: Mapping Revit Sheets to a Dictionary**

```csharp
using System.Collections.Generic; 
using Autodesk.Revit.DB; 

// ... Assumes you have already queried the model for all ViewSheet instances ... 

// 1. Declare the Dictionary (Key = Sheet Number, Value = Revit ViewSheet object) 
Dictionary<string, ViewSheet> sheetDictionary = new Dictionary<string, ViewSheet>(); 

// 2. Populate the Dictionary 
foreach (ViewSheet sheet in allSheetsInModel) 
{ 
    // Normalize keys to lowercase to prevent casing mismatches 
    string sheetNumberKey = sheet.SheetNumber.ToLower(); 
    
    // Prevent duplicate key errors by verifying existence first 
    if (!sheetDictionary.ContainsKey(sheetNumberKey)) 
    { 
        sheetDictionary.Add(sheetNumberKey, sheet); 
    } 
} 

// 3. Fast O(1) Lookup (e.g., checking a spreadsheet row for sheet number "A101") 
string searchSheetNum = "a101"; 

// TryGetValue performs the lookup in 0 milliseconds and assigns the match to 'existingSheet' 
if (sheetDictionary.TryGetValue(searchSheetNum, out ViewSheet existingSheet)) 
{ 
    // Sheet found! Update it here 
    string name = existingSheet.Name; 
} 
else 
{ 
    // Excel sheet doesn't exist in the Revit model (needs to be created) 
}
```
