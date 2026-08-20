# Debugging Log: Fallback to Drafting Views on Radio Category Selection

**Date:** 2026-08-20  
**Context:** Multi-category selector in Revit add-in UI (CAD Links/Imports, Drafting Views, Detail Views, Detail Groups, Detail Items).  

### Symptom
Selecting different category options in the UI always displayed Drafting Views, even when selecting Detail Views, Detail Groups, or Detail Items.

### Root Cause
Missing individual branches for secondary categories in the provider dispatch method, causing all unhandled radio states to fall through to a default `DraftingViewProvider` call instead of specialized collectors.

### Resolution
1. Create explicit provider methods for each distinct category (`DetailViewProvider`, `DetailGroupProvider`, `DetailItemProvider`).
2. Dispatch each radio state to its dedicated collector.
3. Return an empty list if a category contains no elements, properly clearing the UI tree.
