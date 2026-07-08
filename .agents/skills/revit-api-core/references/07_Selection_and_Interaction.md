# Skill: User Interaction, References and Advanced Selection Filters (Selection API)

## 1. Technical Data Sheet and Metadata for the Agent
* **Skill ID:** SKILL-RVT-007
* **Technical Area:** User Experience (UX) / Synchronous Input Filtering / Mouse Event Interception
* **API dependencies:** `Autodesk.Revit.UI.Selection.Selection`, `Autodesk.Revit.UI.Selection.ISelectionFilter`, `Autodesk.Revit.DB.Reference`
* **Design Patterns:** Strategy Pattern (Injected selection filters)
* **Operational Impact:** Critical (Prevents exceptions due to invalid user clicks and optimizes the on-screen workflow).

---

## 2. The Selection API and the Reference Concept

Visual interaction in Revit is managed through the `Selection` property of the `UIDocument`. When a script stops the execution thread to wait for a user click (synchronous operation), the API does not immediately return an `Element`, but a **`Reference`** object.

### Why a `Reference` instead of an `Element`?
A `Reference` contains the pointer to the database object (`ElementId`), but also includes click-specific metadata:
* The exact coordinate of the three-dimensional plane where the cursor impacted (`GlobalPoint`).
* The specific geometric component selected (a face, edge, or vertex), which is essential for precise modeling tools or placement of face-based elements.

---

## 3. Control Interfaces: The Power of `ISelectionFilter`

The biggest design mistake in Add-ins is allowing the user to click on any element in the model and *subsequently* evaluating whether the element is valid within the C# code. This forces the user to repeat clicks by mistake and degrades the user experience.

The architectural solution is to implement the **`ISelectionFilter`** interface. This interface intercepts mouse movement in real time within the Revit canvas and evaluates the conditions *before* allowing the click. If the element under the cursor does not meet the requirements, Revit prevents its highlighting and locks the selection.

### Implementation of the `ISelectionFilter` Contract
The interface requires the development of two logical evaluation methods:


[See pattern implementation in: assets/StructuralWallSelectionFilter.cs]
json?chameleon
{"component":"LlmGeneratedComponent","props":{"height":"650px","prompt":"Educational simulator of the Selection API (ISelectionFilter) in Revit. The objective is for the user to understand how functions in C# intercept mouse events. The component must have a top panel with C# filter controls using switches or selectors to define the rules of the active filter: 'Allow only the Wall Class (is Wall)', 'Allow only Structural Category' and 'Allow only Instances with Valid Parameters'. Below the controls, an interactive graphical canvas should be displayed that represents a plan view with multiple Revit geometric elements: Architectural Walls, Structural Walls, Doors, Structural Columns and Windows. When you hover over the canvas elements, the system should evaluate the active filter rules in real time: if the rule returns true, the element lights up in a color of preselect to indicate that the click is valid; if it returns false, the element remains opaque or displays a visual blocking indicator. When you click a valid element, a console panel at the bottom that simulates the C# execution is updated, showing the executed method, the obtained reference, the generated ElementId, and the return status (Result.Succeeded). Result.Cancelled. All text, labels and console logs must be presented in Spanish.","id":"im_8c2d03f761bb437a"}}