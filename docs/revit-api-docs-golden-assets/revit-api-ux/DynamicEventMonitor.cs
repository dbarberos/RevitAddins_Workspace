// ==============================================================================
// SKILL: SKILL-RVT-UX (Advanced UX/UI)
// PATTERN: Document Changed Event Monitor
// PURPOSE: Subscribes to native Revit database events to detect when elements 
//          are added, modified, or deleted. Used to trigger real-time UI refreshes.
// DEPENDENCIES: Autodesk.Revit.DB, Autodesk.Revit.UI, System
// ==============================================================================

using System;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;

namespace RevitAddinBase.UX
{
    /// <summary>
    /// Monitors real-time changes in the Revit database to keep Dockable Panes in sync.
    /// </summary>
    public class DynamicEventMonitor : IDisposable
    {
        private readonly Autodesk.Revit.ApplicationServices.Application _app;
        
        // Expose a standard .NET event that ViewModels can subscribe to
        public event EventHandler<DocumentChangedEventArgs> OnModelChanged;

        public DynamicEventMonitor(Autodesk.Revit.ApplicationServices.Application app)
        {
            _app = app ?? throw new ArgumentNullException(nameof(app));
            
            // Subscribe to the global document changed event
            _app.DocumentChanged += HandleDocumentChanged;
        }

        private void HandleDocumentChanged(object sender, DocumentChangedEventArgs e)
        {
            // Optional: Filter out changes happening inside Family Documents
            if (e.GetDocument().IsFamilyDocument) return;

            // Trigger the internal event to notify the ViewModels
            OnModelChanged?.Invoke(this, e);
        }

        /// <summary>
        /// CRITICAL: Must be called during IExternalApplication.OnShutdown() 
        /// to prevent severe memory leaks in the Revit process.
        /// </summary>
        public void Dispose()
        {
            if (_app != null)
            {
                _app.DocumentChanged -= HandleDocumentChanged;
            }
        }
    }
}