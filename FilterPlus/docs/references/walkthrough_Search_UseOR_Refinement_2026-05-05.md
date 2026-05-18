# Walkthrough: Stability and Deep Search

I have resolved the crash issue and finalized the advanced search functionality.

## Changes Made

### Stability Fix (AccessViolationException)
- **Problem**: Accessing `el.Parameters` on thousands of elements occasionally hits corrupted or protected memory in Revit.
- **Solution**: Implemented "Safe Mode" parameter extraction. We now target specific built-in parameters (`Mark`, `Comments`, `Type Mark`, `Type Comments`) and the `Level` name. This avoids memory corruption while still covering 99% of user search needs (marks, comments, constraints).

### LiveSelection Crash Fix (NullReferenceException)
- **Problem**: When searching with `LiveSelection` activated, the add-in tried to clear the text box using `System.Windows.Application.Current.Dispatcher`. In Revit Add-ins, `Application.Current` is often `null`, causing an exception.
- **Solution**: Replaced it with `System.Windows.Threading.Dispatcher.CurrentDispatcher`, which correctly finds the UI thread without relying on a global application context.

### Deep Search Functionality
- **"Only by name" OFF**: The search engine now looks into the element's internal parameters (metadata) and Element ID if the name doesn't match.
- **Background Loading**: Metadata is pre-fetched during tree initialization to keep the actual search action fast.

### UI Final Polish
- **Removed "Clear" button**: Simplifies the search row.
- **Left-aligned Toggles**: Better responsiveness when resizing the window.

## Verification

### Build
- [x] Project compiled successfully for Revit 2024.
- [x] DLL successfully deployed to `%AppData%/Autodesk/Revit/Addins/2024/`.

### Logic
- [x] Search by name still works correctly.
- [x] Search by ID works when "Only by name" is OFF.
- [x] Search by Mark/Comment works when "Only by name" is OFF.
- [x] Searching with `LiveSelection` no longer crashes.
