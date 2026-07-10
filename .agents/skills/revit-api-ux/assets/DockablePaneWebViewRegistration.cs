// ==============================================================================
// SKILL: SKILL-RVT-UX (Advanced UX/UI)
// PATTERN: Dockable Pane Web Component Registration (WebView2)
// PURPOSE: Sets up and registers the WebView2 panel inside the Revit UI.
// ==============================================================================

using System;
using Autodesk.Revit.UI;

namespace RevitAddinBase.UX
{
    public class DockablePaneWebViewRegistration
    {
        public void RegisterWebViewPanel(UIControlledApplication application)
        {
            // Panel registration inside OnStartup (requires unique GUID)
            DockablePaneId myPaneId = new DockablePaneId(new Guid("A1B2C3D4-E5F6-7A8B-9C0D-1E2F3A4B5C6D"));
            
            // WebViewPage implements IDockablePaneProvider and inherits from System.Windows.Controls.Page
            WebViewPage webPanel = new WebViewPage(); 
            
            application.RegisterDockablePane(myPaneId, "AECO Web Dashboard", webPanel);
        }

        private class WebViewPage : IDockablePaneProvider
        {
            public void SetupDockablePane(DockablePaneProviderData data)
            {
                // Configures dock positioning/initial setups
            }
        }
    }
}
