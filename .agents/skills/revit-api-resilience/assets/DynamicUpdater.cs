// ==============================================================================
// SKILL: SKILL-RVT-RES (Resilience & Operations)
// PATTERN: Dynamic Model Update (DMU)
// PURPOSE: Registers a background watcher that executes business logic immediately 
//          when specific elements are added, modified, or deleted by the user.
// DEPENDENCIES: Autodesk.Revit.DB, System
// ==============================================================================

using System;
using Autodesk.Revit.DB;

namespace RevitAddinBase.Resilience
{
    /// <summary>
    /// Base class for creating self-auditing triggers inside the Revit database.
    /// </summary>
    public class DynamicUpdater : IUpdater
    {
        private readonly UpdaterId _updaterId;

        public DynamicUpdater(AddInId addInId, Guid updaterGuid)
        {
            _updaterId = new UpdaterId(addInId, updaterGuid);
        }

        public UpdaterId GetUpdaterId() => _updaterId;
        public string GetUpdaterName() => "Enterprise Dynamic Updater";
        public string GetAdditionalInformation() => "Triggers automated parameter syncing.";
        public ChangePriority GetChangePriority() => ChangePriority.MEPFixtures;

        /// <summary>
        /// The execution block that runs when the trigger conditions are met.
        /// </summary>
        public void Execute(UpdaterData data)
        {
            Document doc = data.GetDocument();

            // Elements that triggered the update
            foreach (ElementId addedId in data.GetAddedElementIds())
            {
                // Inject business logic here (e.g., auto-fill a 'Creation Date' parameter)
            }

            foreach (ElementId modifiedId in data.GetModifiedElementIds())
            {
                // Inject business logic here (e.g., recalculate custom coordinates)
            }
        }

        /// <summary>
        /// Registers the updater to listen for changes on a specific Category.
        /// MUST be called in IExternalApplication.OnStartup().
        /// </summary>
        public static void RegisterUpdater(DynamicUpdater updater, Document doc, BuiltInCategory category)
        {
            if (UpdaterRegistry.IsUpdaterRegistered(updater.GetUpdaterId()))
                return;

            UpdaterRegistry.RegisterUpdater(updater, doc, true);

            ElementCategoryFilter filter = new ElementCategoryFilter(category);
            
            // Trigger when elements of this category are added or modified
            UpdaterRegistry.AddTrigger(updater.GetUpdaterId(), filter, Element.GetChangeTypeElementAddition());
            UpdaterRegistry.AddTrigger(updater.GetUpdaterId(), filter, Element.GetChangeTypeGeometry());
        }
    }
}
