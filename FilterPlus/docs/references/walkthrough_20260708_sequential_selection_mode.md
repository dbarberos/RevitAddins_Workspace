# Walkthrough: Sequential Selection and Selection Mode Prompt

## 1. Goal
Support selecting individual elements within linked models alongside elements in the active host model, bypassing the Revit API limit of not allowing mixed selection types in a single `PickObjects` call.

## 2. Changes Made
- **PickElementsHandler**: Updated `Execute` in [PickElementsHandler.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/FilterPlus/Services/PickElementsHandler.cs):
  - When the selection scope contains BOTH host and links, it displays a `TaskDialog` prompt offering 3 choices:
    - **Host Model Only**: Limits the selection to active document elements (`ObjectType.Element`).
    - **Linked Models Only**: Limits the selection to elements nested inside links (`ObjectType.LinkedElement`).
    - **Both (Sequential)**: Sequentially prompts the user to select host elements first (and click Finish), followed by a prompt to select linked elements (and click Finish).
  - Merges the references from both sequential phases to present the unified selection to the main ViewModel.
  - Updates status bar/options bar prompts accordingly:
    - Host phase: `"Select elements in the Host Model only (active document). Click Finish (top-left) when done."`
    - Links phase: `"Select elements in Linked Models only (use TAB to highlight). Click Finish (top-left) when done."`

## 3. Verification
- Verified compilation and publishing.
- Created final MSI and ZIP bundle.
