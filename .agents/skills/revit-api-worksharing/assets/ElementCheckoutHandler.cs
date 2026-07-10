// ==============================================================================
// SKILL: SKILL-RVT-WS (Worksharing & Coordinates)
// PATTERN: Element Ownership & Checkout
// PURPOSE: Evaluates if an element can be modified, checks it out programmatically, 
//          and handles relinquishing permissions back to the Central Model.
// DEPENDENCIES: Autodesk.Revit.DB, System.Collections.Generic
// ==============================================================================

using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace RevitAddinBase.Worksharing
{
    /// <summary>
    /// Utility class for safely handling element borrowing in Central Models.
    /// </summary>
    public static class ElementCheckoutHandler
    {
        /// <summary>
        /// Verifies if an element is available for modification by the current user.
        /// </summary>
        /// <param name="doc">The active workshared Document.</param>
        /// <param name="elementId">The ElementId to check.</param>
        /// <returns>True if the element is owned by the current user or is free to be borrowed.</returns>
        public static bool CanModifyElement(Document doc, ElementId elementId)
        {
            if (doc == null || elementId == ElementId.InvalidElementId) return false;
            
            // If the document is local/non-workshared, all elements can be modified
            if (!doc.IsWorkshared) return true;

            CheckoutStatus status = WorksharingUtils.GetCheckoutStatus(doc, elementId);

            // Element is free, or we already own it
            return status == CheckoutStatus.NotBorrowed || status == CheckoutStatus.OwnedByCurrentUser;
        }

        /// <summary>
        /// Attempts to explicitly borrow a collection of elements.
        /// </summary>
        /// <param name="doc">The active workshared Document.</param>
        /// <param name="elementIds">The elements to checkout.</param>
        /// <returns>A collection of ElementIds that were successfully checked out.</returns>
        public static ICollection<ElementId> CheckoutElements(Document doc, ICollection<ElementId> elementIds)
        {
            if (doc == null || !doc.IsWorkshared || elementIds == null || elementIds.Count == 0) 
                return new List<ElementId>();

            try
            {
                // This native method contacts the Central Model to lock the elements for the current user
                return WorksharingUtils.CheckoutElements(doc, elementIds);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[WorksharingAPI] Checkout failed: {ex.Message}");
                return new List<ElementId>();
            }
        }
    }
}
