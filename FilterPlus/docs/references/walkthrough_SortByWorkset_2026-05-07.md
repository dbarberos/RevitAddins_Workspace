# Walkthrough: Triple Dynamic Hierarchy (Phase, Level & Workset)

## Enhanced Data Discovery
FilterPlus now offers three independent but stackable grouping criteria, allowing for unprecedented granular control over the Revit element explorer.

### 1. New "Sort by Workset" Switch
A third toggle has been integrated into the UI. When active, elements are grouped by their Revit subproject/workset.

### 2. The Power of Recursive Grouping
The system now handles any combination of the three switches:
- **Order Matters**: The hierarchy (e.g. Workset > Phase > Level vs Phase > Workset > Level) is determined by the sequence in which you toggle the switches ON.
- **Deep Nesting**: All three can be active simultaneously, creating a rich 4-level deep hierarchy before reaching the Category level.

### 3. Data Integrity
Elements created in default worksets or shared levels are correctly grouped, and any empty workset assignments are labeled as "None" to maintain tree consistency.

## Technical Results
- **Build Status**: Successful (0 Errors).
- **Scalability**: The recursive logic successfully scales to three levels of dynamic nesting without performance degradation.
