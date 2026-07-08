// ==============================================================================
// SKILL: SKILL-RVT-CORE (Revit API Core Engine)
// PATTERN: Ribbon UI Factory / Builder
// PURPOSE: Abstracts the boilerplate required to build Revit Ribbon UI elements 
//          (Tabs, Panels, PushButtons) during the OnStartup event. Handles 
//          assembly resolution and image binding automatically.
// DEPENDENCIES: Autodesk.Revit.UI, System.Reflection, System.Windows.Media.Imaging
// ==============================================================================

using System;
using System.Reflection;
using System.Windows.Media.Imaging;
using Autodesk.Revit.UI;

namespace RevitAddinBase.Core
{
    /// <summary>
    /// Factory utility class to streamline the creation of Revit Ribbon interfaces.
    /// Must be invoked strictly from within the IExternalApplication.OnStartup() method.
    /// </summary>
    public static class RibbonUiFactory
    {
        /// <summary>
        /// Creates a new custom Ribbon Tab. 
        /// Safely ignores the creation if a tab with the same name already exists.
        /// </summary>
        /// <param name="uiApp">The UIControlledApplication from OnStartup.</param>
        /// <param name="tabName">The name of the tab to create.</param>
        public static void CreateTabSafe(UIControlledApplication uiApp, string tabName)
        {
            if (string.IsNullOrWhiteSpace(tabName)) return;

            try
            {
                uiApp.CreateRibbonTab(tabName);
            }
            catch (Autodesk.Revit.Exceptions.ArgumentException)
            {
                // Tab already exists. This is common if multiple add-ins share a company tab.
                // We swallow the exception to continue execution safely.
            }
        }

        /// <summary>
        /// Creates a new Panel inside a specific Tab.
        /// </summary>
        /// <param name="uiApp">The UIControlledApplication from OnStartup.</param>
        /// <param name="tabName">The name of the existing tab.</param>
        /// <param name="panelName">The name of the new panel.</param>
        /// <returns>The created RibbonPanel instance, or null if it fails.</returns>
        public static RibbonPanel CreatePanel(UIControlledApplication uiApp, string tabName, string panelName)
        {
            try
            {
                return uiApp.CreateRibbonPanel(tabName, panelName);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to create panel '{panelName}': {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Creates and configures a PushButton to trigger an IExternalCommand.
        /// </summary>
        /// <param name="panel">The RibbonPanel where the button will be hosted.</param>
        /// <param name="buttonInternalName">Unique internal identifier for the button.</param>
        /// <param name="buttonText">The text displayed to the user on the Ribbon.</param>
        /// <param name="commandType">The Type of the IExternalCommand class to execute.</param>
        /// <param name="tooltip">Detailed description shown on hover.</param>
        /// <param name="iconUri">Optional: Pack URI string for the 32x32 pixel icon (e.g., "pack://application:,,,/MyAddin;component/Resources/Icon.png").</param>
        /// <returns>The generated PushButton, allowing further customization (like Availability classes).</returns>
        public static PushButton AddPushButton(
            RibbonPanel panel, 
            string buttonInternalName, 
            string buttonText, 
            Type commandType, 
            string tooltip = "", 
            string iconUri = "")
        {
            if (panel == null || commandType == null) return null;

            // Extract the physical path of the DLL where the command class resides
            string assemblyPath = Assembly.GetAssembly(commandType).Location;
            string commandFullName = commandType.FullName;

            // Construct the button data payload
            PushButtonData buttonData = new PushButtonData(
                buttonInternalName, 
                buttonText, 
                assemblyPath, 
                commandFullName)
            {
                ToolTip = tooltip
            };

            // Attempt to bind the image if a URI is provided
            if (!string.IsNullOrWhiteSpace(iconUri))
            {
                try
                {
                    buttonData.LargeImage = new BitmapImage(new Uri(iconUri));
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Failed to load icon for button '{buttonInternalName}': {ex.Message}");
                }
            }

            // Inject the button into the panel
            return panel.AddItem(buttonData) as PushButton;
        }
    }
}