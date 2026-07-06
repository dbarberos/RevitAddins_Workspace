// ==============================================================================
// SKILL: SKILL-RVT-FAM (Families & Documentation)
// PATTERN: Sheet & Viewport Automation
// PURPOSE: Automates the generation of 2D deliverables (Sheets) and safely 
//          embeds model Views onto them without violating uniqueness constraints.
// DEPENDENCIES: Autodesk.Revit.DB
// ==============================================================================

using System;
using Autodesk.Revit.DB;

namespace RevitAddinBase.Families
{
    /// <summary>
    /// Utility class for generating and managing project Sheets and Viewports.
    /// </summary>
    public static class ViewSheetManager
    {
        /// <summary>
        /// Creates a new empty Sheet using a specific Titleblock.
        /// Requires an active Transaction.
        /// </summary>
        /// <param name="doc">The active Document.</param>
        /// <param name="titleBlockId">The ElementId of the Titleblock FamilySymbol.</param>
        /// <param name="sheetNumber">The unique sheet number (e.g., "A-101").</param>
        /// <param name="sheetName">The descriptive name of the sheet.</param>
        /// <returns>The created ViewSheet.</returns>
        public static ViewSheet CreateSheet(Document doc, ElementId titleBlockId, string sheetNumber, string sheetName)
        {
            if (doc == null || titleBlockId == ElementId.InvalidElementId) return null;

            try
            {
                ViewSheet sheet = ViewSheet.Create(doc, titleBlockId);
                if (sheet != null)
                {
                    if (!string.IsNullOrWhiteSpace(sheetNumber)) sheet.SheetNumber = sheetNumber;
                    if (!string.IsNullOrWhiteSpace(sheetName)) sheet.Name = sheetName;
                }
                return sheet;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[SheetAPI] Failed to create sheet: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Safely places a View onto a Sheet as a Viewport.
        /// Includes strict validation to prevent Revit from crashing if the view is already placed.
        /// Requires an active Transaction.
        /// </summary>
        /// <param name="doc">The active Document.</param>
        /// <param name="sheet">The target ViewSheet.</param>
        /// <param name="viewToPlace">The Model View, Drafting View, or Schedule to place.</param>
        /// <param name="placementPoint">The XYZ coordinate on the sheet paper space.</param>
        /// <returns>The created Viewport, or null if invalid.</returns>
        public static Viewport PlaceViewOnSheet(Document doc, ViewSheet sheet, View viewToPlace, XYZ placementPoint)
        {
            if (doc == null || sheet == null || viewToPlace == null) return null;

            // CRITICAL CHECK: Most views (except Legends and Schedules) can only exist on one sheet.
            if (!Viewport.CanAddViewToSheet(doc, sheet.Id, viewToPlace.Id))
            {
                System.Diagnostics.Debug.WriteLine($"[SheetAPI] Cannot add View '{viewToPlace.Name}' to Sheet. It may already be placed.");
                return null;
            }

            try
            {
                return Viewport.Create(doc, sheet.Id, viewToPlace.Id, placementPoint);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[SheetAPI] Failed to create viewport: {ex.Message}");
                return null;
            }
        }
    }
}