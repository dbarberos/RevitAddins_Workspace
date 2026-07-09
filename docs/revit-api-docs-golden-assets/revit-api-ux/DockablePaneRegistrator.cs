// ==============================================================================
// SKILL: SKILL-RVT-UX (Advanced UX/UI)
// PATTERN: Dockable Pane Provider
// PURPOSE: Implements the interface required to register a custom WPF Page 
//          as a native dockable window inside the Revit UI shell.
// DEPENDENCIES: Autodesk.Revit.UI, System.Windows.Controls
// ==============================================================================

using System;
using Autodesk.Revit.UI;
using System.Windows.Controls;

namespace RevitAddinBase.UX
{
    /// <summary>
    /// Wrapper class linking a WPF Page to Revit's Dockable Pane framework.
    /// </summary>
    public class DockablePaneRegistrator : IDockablePaneProvider
    {
        private readonly Page _wpfPage;
        private readonly Guid _paneId;
        private readonly string _paneTitle;

        /// <summary>
        /// Initializes the provider with the XAML Page and unique identifiers.
        /// </summary>
        public DockablePaneRegistrator(Page wpfPage, Guid paneId, string paneTitle)
        {
            _wpfPage = wpfPage ?? throw new ArgumentNullException(nameof(wpfPage));
            _paneId = paneId;
            _paneTitle = paneTitle;
        }

        /// <summary>
        /// Called automatically by Revit during pane initialization.
        /// Maps the WPF visual tree to the Revit pane container.
        /// </summary>
        public void SetupDockablePane(DockablePaneProviderData data)
        {
            // Assign the WPF Page as the visual root
            data.FrameworkElement = _wpfPage as System.Windows.FrameworkElement;
            
            // Define initial state and docking position
            data.InitialState = new DockablePaneState
            {
                DockPosition = DockPosition.Right,
                TabBehind = DockablePanes.BuiltInDockablePanes.ProjectBrowser
            };
        }

        /// <summary>
        /// Registers the pane with the Revit UI Application.
        /// CRITICAL: Must be called exclusively inside IExternalApplication.OnStartup().
        /// </summary>
        public void RegisterPane(UIControlledApplication uiApp)
        {
            try
            {
                DockablePaneId dpid = new DockablePaneId(_paneId);
                uiApp.RegisterDockablePane(dpid, _paneTitle, this);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[UX_API] Failed to register Dockable Pane: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Opens or brings the pane to the front.
        /// Can be called from an IExternalCommand (e.g., a Ribbon button).
        /// </summary>
        public static void ShowPane(UIApplication app, Guid paneId)
        {
            DockablePaneId dpid = new DockablePaneId(paneId);
            DockablePane pane = app.GetDockablePane(dpid);
            
            if (pane != null && !pane.IsShown())
            {
                pane.Show();
            }
        }
    }
}