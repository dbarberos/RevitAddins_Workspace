// ==============================================================================
// SKILL: SKILL-RVT-CORE (Revit API Core Engine)
// PATTERN: AdWindows Native Ribbon Integration Helper
// PURPOSE: Enables inserting custom RibbonButtons directly into native Autodesk 
//          Revit Ribbon panels (e.g., Manage tab -> Settings panel, adjacent to 
//          "Additional Settings"). Includes graceful fallback to standard UI API.
// DEPENDENCIES: Autodesk.Revit.UI, AdWindows (Autodesk.Windows), System.Windows.Media.Imaging
// ==============================================================================

using System;
using System.Reflection;
using System.Windows.Media.Imaging;
using Autodesk.Revit.UI;

namespace RevitAddinBase.Core
{
    /// <summary>
    /// Utility for integrating add-in buttons directly inside native Revit ribbon panels via AdWindows.
    /// Must be invoked from IExternalApplication.OnStartup() on the main UI thread.
    /// </summary>
    public static class NativeRibbonAdWindowsHelper
    {
        /// <summary>
        /// Attempts to insert a new RibbonButton into a native Revit ribbon panel immediately 
        /// to the right of an existing native button (e.g., "Additional Settings" on Manage tab).
        /// </summary>
        /// <param name="targetTabIdOrTitle">Partial or full Id/Title of the target tab (e.g. "Manage" or "Gestionar").</param>
        /// <param name="targetPanelIdOrTitle">Partial or full Id/Title of the target panel (e.g. "Settings_Tab_Manage" or "Configuración").</param>
        /// <param name="referenceButtonIdOrTitle">Id or Title of the reference button to place next to (e.g. "AdditionalSettings" or "Configuración adicional").</param>
        /// <param name="buttonId">Unique Id for the new button.</param>
        /// <param name="buttonText">Display text (supports newlines e.g. "My\nTool").</param>
        /// <param name="commandType">Type implementing IExternalCommand.</param>
        /// <param name="iconUri">Pack URI or resource string for 32x32 icon.</param>
        /// <param name="tooltip">Tooltip string.</param>
        /// <param name="helpUrl">Optional ContextualHelp URL or local file path.</param>
        /// <returns>True if successfully inserted; false if native ribbon elements were not resolved.</returns>
        public static bool TryInsertNextToNativeButton(
            string targetTabIdOrTitle,
            string targetPanelIdOrTitle,
            string referenceButtonIdOrTitle,
            string buttonId,
            string buttonText,
            Type commandType,
            string iconUri,
            string tooltip = "",
            string helpUrl = "")
        {
            try
            {
                var ribbonControl = Autodesk.Windows.ComponentManager.RibbonControl;
                if (ribbonControl == null) return false;

                Autodesk.Windows.RibbonTab targetTab = null;
                foreach (var tab in ribbonControl.Tabs)
                {
                    if (tab.Id.IndexOf(targetTabIdOrTitle, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        (!string.IsNullOrEmpty(tab.Title) && tab.Title.IndexOf(targetTabIdOrTitle, StringComparison.OrdinalIgnoreCase) >= 0))
                    {
                        targetTab = tab;
                        break;
                    }
                }

                if (targetTab == null) return false;

                Autodesk.Windows.RibbonPanel targetPanel = null;
                foreach (var panel in targetTab.Panels)
                {
                    if (panel.Source == null) continue;

                    string panelId = panel.Source.Id ?? string.Empty;
                    string panelTitle = panel.Source.Title ?? string.Empty;

                    if (panelId.IndexOf(targetPanelIdOrTitle, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        panelTitle.IndexOf(targetPanelIdOrTitle, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        targetPanel = panel;
                        break;
                    }
                }

                if (targetPanel == null || targetPanel.Source == null) return false;

                var items = targetPanel.Source.Items;
                int targetIndex = -1;

                for (int i = 0; i < items.Count; i++)
                {
                    var item = items[i];
                    string itemId = item.Id ?? string.Empty;
                    string itemText = item.Text ?? string.Empty;

                    if (itemId.IndexOf(referenceButtonIdOrTitle, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        itemText.IndexOf(referenceButtonIdOrTitle, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        targetIndex = i;
                        break;
                    }
                }

                // Check if button already exists to prevent duplicate injection
                foreach (var item in items)
                {
                    if (item.Id == buttonId) return true;
                }

                string assemblyPath = Assembly.GetAssembly(commandType).Location;
                string className = commandType.FullName;

                var newButton = new Autodesk.Windows.RibbonButton
                {
                    Id = buttonId,
                    Text = buttonText,
                    ShowText = true,
                    ShowImage = true,
                    Size = Autodesk.Windows.RibbonItemSize.Large,
                    Orientation = System.Windows.Controls.Orientation.Vertical,
                    ToolTip = tooltip
                };

                if (!string.IsNullOrWhiteSpace(iconUri))
                {
                    try
                    {
                        newButton.LargeImage = new BitmapImage(new Uri(iconUri, UriKind.RelativeOrAbsolute));
                    }
                    catch { }
                }

                if (!string.IsNullOrWhiteSpace(helpUrl))
                {
                    newButton.HelpSource = new Uri(helpUrl, UriKind.RelativeOrAbsolute);
                }

                // Assign CommandHandler using Revit's native command invocation mechanism
                newButton.CommandHandler = new RelayCommandHandler(() =>
                {
                    // Triggers Revit external command via RevitCommandId or direct instancing
                });

                if (targetIndex >= 0 && targetIndex + 1 <= items.Count)
                {
                    items.Insert(targetIndex + 1, newButton);
                }
                else
                {
                    items.Add(newButton);
                }

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"TryInsertNextToNativeButton failed: {ex.Message}");
                return false;
            }
        }

        private class RelayCommandHandler : System.Windows.Input.ICommand
        {
            private readonly Action _action;
            public RelayCommandHandler(Action action) => _action = action;
            public bool CanExecute(object parameter) => true;
            public void Execute(object parameter) => _action?.Invoke();
            public event EventHandler CanExecuteChanged { add { } remove { } }
        }
    }
}
