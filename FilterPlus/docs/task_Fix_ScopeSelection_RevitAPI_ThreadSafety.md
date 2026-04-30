# Task Checklist — FilterPlus Scope Selection Fix

## Phase: Debug & Stability (2026-04-30)

### Root Cause Investigation
- [x] Identify that Revit closes when switching scope
- [x] Add verbose logging to LoggerService (BeginInvoke-based, thread-safe)
- [x] Add LogView debug window (non-modal, dark theme, Consolas font)
- [x] Add IsBulkUpdating flag to suppress event storms during tree load
- [x] Confirm via logs that crash occurs during FilteredElementCollector call

### Failed Approaches (documented for future reference)
- [x] Try Dispatcher.BeginInvoke(DispatcherPriority.Background) → still crashes
- [x] Try Dispatcher.BeginInvoke(DispatcherPriority.Normal) → still crashes
- [x] Try IExternalEventHandler + ExternalEvent.Raise() → namespace ambiguity with Nice3point; execution instability
- [x] Try DoEvents() (DispatcherFrame) for live log flushing → causes deadlock, REMOVED

### Core Fix: Pre-fetch Architecture
- [x] Rewrite SelectionFilterViewModel constructor to pre-fetch all 3 scopes
  - [x] _currentSelectionElements  (CurrentSelection scope)
  - [x] _elementsInViewElements    (ElementsInView scope)
  - [x] _allModelElements          (AllModelElements, capped at 10,000)
- [x] Rewrite OnCurrentScopeChanged() — zero Revit API calls, pointer swap only
- [x] Add _activeElements field as the single source of truth for the active tree
- [x] Add BuildTree() method (UI-only, no API calls)
- [x] Remove all Dispatcher.BeginInvoke Revit API calls
- [x] Remove ExternalEvent infrastructure from StartupCommand

### UX Improvement: Loading Overlay
- [x] Add IsBusy observable property to ViewModel
- [x] Set IsBusy = true at start of BuildTree(), false in finally block
- [x] Add loading overlay Grid in SelectionFilterView.xaml
  - [x] Semi-transparent white background (#A0FFFFFF)
  - [x] Centered card with drop shadow
  - [x] Spinning arc SVG path (RotateTransform + DoubleAnimation, 1s loop)
  - [x] "Loading Elements..." message
  - [x] "This may take a moment for large projects" subtitle

### Selection Persistence Across Scopes
- [x] OnTreeSelectionChanged() updates _persistentCheckedIds on every checkbox change
- [x] InitializeTree() calls ApplyInitialSelection(root, _persistentCheckedIds) after build
- [x] ApplyFilter() command:
  - [x] Applies selection to Revit via SetSelection()
  - [x] Updates _persistentCheckedIds with applied ID set
  - [x] Rebuilds _currentSelectionElements from cross-scope pool (all 3 lists deduped)
  - [x] So switching to "Current Selection" after Apply shows the FULL new selection

### Build & Deployment
- [x] Build Release.R23 — 0 errors
- [x] Build Release.R24 — 0 errors
- [x] Build Release.R25 — 0 errors
- [x] Build Release.R26 — 0 errors
- [x] Build Release.R27 — 0 errors
- [x] Deploy Release.R24 to %APPDATA%\Autodesk\Revit\Addins\2024\
- [x] Verified working in Revit 2024 by user

### Documentation
- [x] Update .agent/skills/revit-api/SKILL.md with all thread-safety rules
- [x] Save implementation_plan.md to _Development_Logs
- [x] Save task.md to _Development_Logs
- [x] Save walkthrough.md to _Development_Logs
